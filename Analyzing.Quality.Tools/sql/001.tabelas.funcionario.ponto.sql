USE [ProvaDeConceito]
GO

/*	Trecho de Rollback do script:
DROP TABLE [ProvaDeConceito].[dbo].[IntervalosDeTarefa];
GO
DROP TABLE [ProvaDeConceito].[dbo].[Tarefa];
GO
DROP TABLE [ProvaDeConceito].[dbo].[Intervalo];
GO
DROP TABLE [ProvaDeConceito].[dbo].[Ponto];
GO
DROP TABLE [ProvaDeConceito].[dbo].[Funcionario];
GO
*/

CREATE TABLE [dbo].[Funcionario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[IdDoUsuarioIceScrum] [bigint] NULL,
	[Situacao] [char](1) NULL
)
GO

CREATE TABLE [dbo].[Ponto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdFuncionario] [int] NOT NULL,
	[Dia] [smalldatetime] NOT NULL,
	[Horas] [time](7) NULL
)
GO

CREATE TABLE [dbo].[Intervalo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPonto] [int] NOT NULL,
	[Entrada] [time](7) NULL,
	[Saida] [time](7) NULL
)
GO

CREATE TABLE [dbo].[Tarefa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdFuncionario] [int] NOT NULL,
	[Titulo] [varchar](200) NULL,
	[Descricao] [varchar](max) NULL,
	[Executada] [bit] NULL,
	[IdIceScrum] [bigint] NULL,
	[Situacao] [char](1) NULL
)
GO

CREATE TABLE [dbo].[IntervalosDeTarefa](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdTarefa] [int] NOT NULL,
	[Inicio] [smalldatetime] NULL,
	[Fim] [smalldatetime] NULL
)
GO

ALTER TABLE [dbo].[Funcionario] ADD CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [dbo].[Ponto] ADD CONSTRAINT [PK_Ponto] PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [dbo].[Ponto] ADD CONSTRAINT [FK_Ponto_Funcionario] FOREIGN KEY([IdFuncionario]) REFERENCES [dbo].[Funcionario] ([Id])
GO

ALTER TABLE [dbo].[Intervalo] ADD CONSTRAINT [PK_Intervalo] PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [dbo].[Intervalo]  WITH NOCHECK ADD  CONSTRAINT [FK_Intervalo_Ponto] FOREIGN KEY([IdPonto]) REFERENCES [dbo].[Ponto] ([Id])
GO

ALTER TABLE [dbo].[Intervalo] CHECK CONSTRAINT [FK_Intervalo_Ponto]
GO

ALTER TABLE [dbo].[Tarefa] ADD CONSTRAINT [PK_Tarefa] PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [dbo].[Tarefa] ADD CONSTRAINT [FK_Tarefa_Funcionario] FOREIGN KEY([IdFuncionario]) REFERENCES [dbo].[Funcionario] ([Id])
GO

ALTER TABLE [dbo].[IntervalosDeTarefa] ADD CONSTRAINT [PK_IntervalosDeTarefa] PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [dbo].[IntervalosDeTarefa] ADD CONSTRAINT [FK_Tarefa_IntervalosDeTarefa] FOREIGN KEY([IdTarefa]) REFERENCES [dbo].[Tarefa] ([Id])
GO