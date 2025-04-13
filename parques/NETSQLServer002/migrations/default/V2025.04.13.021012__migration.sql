ALTER TABLE [parqueAtraccion] ADD [CiudadId] smallint NULL;
DROP INDEX [IPARQUEATRACCION1] ON [parqueAtraccion];
CREATE NONCLUSTERED INDEX [IPARQUEATRACCION1] ON [parqueAtraccion] ([PaisId] ,[CiudadId] );

ALTER TABLE [parqueAtraccion] ADD CONSTRAINT [IPARQUEATRACCION1] FOREIGN KEY ([PaisId], [CiudadId]) REFERENCES [PaisCiudad] ([PaisId], [CiudadId]);

