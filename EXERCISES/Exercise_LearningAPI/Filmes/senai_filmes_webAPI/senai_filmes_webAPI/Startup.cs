using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai_filmes_webAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // define o uso de Controllers
            services.AddControllers();

            // adiciona o serviço do Swagger:
            // link de onde foram tirados os comandos: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Filmes.webAPI", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services
                // definindo a forma de autenticação JwtBearer
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })
                // define os parâmetros de validação do token
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // vamos validar quem está emitindo?
                        ValidateIssuer = true, // true = sim

                        // vamos validar quem está recebendo?
                        ValidateAudience = true, // true = sim

                        // vamos validar o tempo de expiração?
                        ValidateLifetime = true, // true = sim

                        // validação da forma de criptografia e a chave de autenticação?
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao")),
                        
                        // qual foi o tempo de expiração do token?
                        ClockSkew = TimeSpan.FromMinutes(30), // olhando a diferença do tempo do token com o tempo atual, vai verificar se o tempo é maior que 30min, se for maior que 30min, o token expira
                        
                        // nome do issuer, de onde está vindo?
                        ValidIssuer = "Filmes.webAPI",

                        // nome do audience, para onde está indo?
                        ValidAudience = "Filmes.webAPI"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Filmes.webAPI");
            });

            // habilita a autenticação (ou tá logado ou não tá logado)
            app.UseAuthentication();

            // habilita a autorização
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // define o mapeamento dos Controllers
                endpoints.MapControllers();
            });
        }
    }
}
