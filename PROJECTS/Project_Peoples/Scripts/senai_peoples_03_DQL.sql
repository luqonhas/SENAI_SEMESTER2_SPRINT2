-- DQL

USE T_Peoples;
GO

SELECT * FROM funcionarios;
GO

SELECT idFuncionario, funcionarios.nome, funcionarios.sobrenome, CONVERT (VARCHAR, dataNascimento, 106) AS dataNascimento FROM funcionarios;
GO