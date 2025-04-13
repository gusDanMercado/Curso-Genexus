DROP INDEX [IJUEGO2] ON [Juego];
ALTER TABLE [Juego] DROP CONSTRAINT [IJUEGO2];
ALTER TABLE [Juego] ALTER COLUMN [CategoriaId] smallint NULL;
CREATE NONCLUSTERED INDEX [IJUEGO2] ON [Juego] ([CategoriaId] );

ALTER TABLE [Juego] ADD CONSTRAINT [IJUEGO1] FOREIGN KEY ([parqueAtraccionId]) REFERENCES [parqueAtraccion] ([parqueAtraccionId]);
ALTER TABLE [Juego] ADD CONSTRAINT [IJUEGO2] FOREIGN KEY ([CategoriaId]) REFERENCES [Categoria] ([CategoriaId]);

