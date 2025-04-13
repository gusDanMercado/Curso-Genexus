CREATE TABLE [Juego] ([JuegoId] smallint NOT NULL IDENTITY(1,1), [JuegoNombre] nvarchar(40) NOT NULL , [parqueAtraccionId] smallint NOT NULL , PRIMARY KEY([JuegoId]));
CREATE NONCLUSTERED INDEX [IJUEGO1] ON [Juego] ([parqueAtraccionId] );

ALTER TABLE [Juego] ADD CONSTRAINT [IJUEGO1] FOREIGN KEY ([parqueAtraccionId]) REFERENCES [parqueAtraccion] ([parqueAtraccionId]);

