use BeautyExpress
go

INSERT INTO Estabelecimentos(Nome, Endereco, Telefone) VALUES('Beauty Express', 'Rua 1234', '99-9999-9999')
INSERT INTO DataHorarios(Data, DataInicio, DataFim, StatusDataHorario) VALUES('2024-08-06 00:00:00.000', '2024-08-06 08:00:00.000', '2024-08-06 09:00:00.000', 0)
INSERT INTO DataHorarios(Data, DataInicio, DataFim, StatusDataHorario) VALUES('2024-08-06 00:00:00.000', '2024-08-06 09:01:00.000', '2024-08-06 10:00:00.000', 0)
INSERT INTO DataHorarios(Data, DataInicio, DataFim, StatusDataHorario) VALUES('2024-08-06 00:00:00.000', '2024-08-06 10:01:00.000', '2024-08-06 11:00:00.000', 0)
INSERT INTO DataHorarios(Data, DataInicio, DataFim, StatusDataHorario) VALUES('2024-08-06 00:00:00.000', '2024-08-06 11:01:00.000', '2024-08-06 12:00:00.000', 0)
INSERT INTO DataHorarios(Data, DataInicio, DataFim, StatusDataHorario) VALUES('2024-08-06 00:00:00.000', '2024-08-06 12:01:00.000', '2024-08-06 13:00:00.000', 0)
INSERT INTO DataHorarios(Data, DataInicio, DataFim, StatusDataHorario) VALUES('2024-08-06 00:00:00.000', '2024-08-06 13:01:00.000', '2024-08-06 14:00:00.000', 0)
INSERT INTO DataHorarios(Data, DataInicio, DataFim, StatusDataHorario) VALUES('2024-08-06 00:00:00.000', '2024-08-06 14:01:00.000', '2024-08-06 15:00:00.000', 0)
INSERT INTO DataHorarios(Data, DataInicio, DataFim, StatusDataHorario) VALUES('2024-08-06 00:00:00.000', '2024-08-06 15:01:00.000', '2024-08-06 16:00:00.000', 0)
INSERT INTO DataHorarios(Data, DataInicio, DataFim, StatusDataHorario) VALUES('2024-08-06 00:00:00.000', '2024-08-06 16:01:00.000', '2024-08-06 17:00:00.000', 0)

DECLARE @Estabelecimento INT
SELECT TOP 1 @Estabelecimento = Id FROM Estabelecimentos

INSERT INTO Profissionais(Nome, Especialidade, EstabelecimentoId) VALUES('Ana Maria', 'Cabelo', @Estabelecimento)
INSERT INTO Profissionais(Nome, Especialidade, EstabelecimentoId) VALUES('Beatriz', 'Unha', @Estabelecimento)
INSERT INTO Profissionais(Nome, Especialidade, EstabelecimentoId) VALUES('Andre', 'Cabelo', @Estabelecimento)
INSERT INTO Profissionais(Nome, Especialidade, EstabelecimentoId) VALUES('Ana Julia', 'Depilação', @Estabelecimento)
INSERT INTO Profissionais(Nome, Especialidade, EstabelecimentoId) VALUES('Juliana', 'Sobrancelha', @Estabelecimento)

INSERT INTO Servicos(Nome, DuracaoHoras,Categoria, ProfissionalId,IdProfissional) VALUES('Cabelo',1,1,1,1)
INSERT INTO Servicos(Nome, DuracaoHoras,Categoria, ProfissionalId,IdProfissional) VALUES('Unha',1,0,2,2)
INSERT INTO Servicos(Nome, DuracaoHoras,Categoria, ProfissionalId,IdProfissional) VALUES('Cabelo',1,1,3,3)
INSERT INTO Servicos(Nome, DuracaoHoras,Categoria, ProfissionalId,IdProfissional) VALUES('Depilação',1,2,4,4)
INSERT INTO Servicos(Nome, DuracaoHoras,Categoria, ProfissionalId,IdProfissional) VALUES('Cabelo',1,3,5,5)