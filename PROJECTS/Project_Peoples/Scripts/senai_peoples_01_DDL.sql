-- DDL

CREATE DATABASE T_Peoples;
GO

USE T_Peoples;
GO

CREATE TABLE funcionarios(
	idFuncionario INT PRIMARY KEY IDENTITY,
	nome VARCHAR(100) NOT NULL,
	sobrenome VARCHAR(200) NOT NULL,
	dataNascimento DATE NOT NULL
);
GO