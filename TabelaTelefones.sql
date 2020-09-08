CREATE TABLE [dbo].[ContatoTelEmail] (
    [Id]         INT          NOT NULL,
    [Id_Contato] INT          NOT NULL,
    [Telefone]   INT          NULL,
    [Email]      VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Table_ToTable] FOREIGN KEY ([Id_Contato]) REFERENCES [dbo].[Contato] ([Id_Contato])
);