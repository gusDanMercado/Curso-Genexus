ALTER TABLE [parqueAtraccion] ADD [CiudadId] smallint NOT NULL CONSTRAINT CiudadIdparqueAtraccion_DEFAULT DEFAULT convert(int, 0);
ALTER TABLE [parqueAtraccion] DROP CONSTRAINT CiudadIdparqueAtraccion_DEFAULT;
DROP INDEX [IPARQUEATRACCION1] ON [parqueAtraccion];
CREATE NONCLUSTERED INDEX [IPARQUEATRACCION1] ON [parqueAtraccion] ([PaisId] ,[CiudadId] );
ALTER TABLE [parqueAtraccion] DROP CONSTRAINT [IPARQUEATRACCION1];

ALTER TABLE [parqueAtraccion] ADD CONSTRAINT [IPARQUEATRACCION1] FOREIGN KEY ([PaisId], [CiudadId]) REFERENCES [PaisCiudad] ([PaisId], [CiudadId]);

