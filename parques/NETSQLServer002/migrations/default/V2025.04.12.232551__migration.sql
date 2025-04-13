ALTER TABLE [parqueAtraccion] ADD [ShowId] smallint NOT NULL CONSTRAINT ShowIdparqueAtraccion_DEFAULT DEFAULT convert(int, 0);
ALTER TABLE [parqueAtraccion] DROP CONSTRAINT ShowIdparqueAtraccion_DEFAULT;
INSERT INTO [Show] ([ShowId], [ShowNombre], [ShowImagen], [ShowImagen_GXI]) SELECT TOP 1 convert(int, 0), ' ', CONVERT(varbinary(1), ''), ' ' FROM [parqueAtraccion] WHERE NOT EXISTS (SELECT 1 FROM [Show] WHERE ShowId=convert(int, 0));
CREATE NONCLUSTERED INDEX [IPARQUEATRACCION2] ON [parqueAtraccion] ([ShowId] );

ALTER TABLE [parqueAtraccion] ADD CONSTRAINT [IPARQUEATRACCION2] FOREIGN KEY ([ShowId]) REFERENCES [Show] ([ShowId]);

