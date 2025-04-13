ALTER TABLE [Juego] ADD [CategoriaId] smallint NOT NULL CONSTRAINT CategoriaIdJuego_DEFAULT DEFAULT 1;
ALTER TABLE [Juego] DROP CONSTRAINT CategoriaIdJuego_DEFAULT;
SET IDENTITY_INSERT [Categoria] ON;
INSERT INTO [Categoria] ([CategoriaId], [CategoriaNombre]) SELECT TOP 1 1, ' ' FROM [Juego] WHERE NOT EXISTS (SELECT 1 FROM [Categoria] WHERE CategoriaId=1);
SET IDENTITY_INSERT [Categoria] OFF;
CREATE NONCLUSTERED INDEX [IJUEGO2] ON [Juego] ([CategoriaId] );

ALTER TABLE [Juego] ADD CONSTRAINT [IJUEGO2] FOREIGN KEY ([CategoriaId]) REFERENCES [Categoria] ([CategoriaId]);

