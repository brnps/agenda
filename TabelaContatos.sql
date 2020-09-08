CREATE TABLE [dbo].[Contato] (
    [Id_Contato]   INT          IDENTITY (1, 1) NOT NULL,
    [Nome_Contato] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Contato] ASC)
);