CREATE TABLE [PaisCiudad] ([PaisId] smallint NOT NULL , [CiudadId] smallint NOT NULL , [CiudadNombre] nvarchar(40) NOT NULL , PRIMARY KEY([PaisId], [CiudadId]));

ALTER TABLE [PaisCiudad] ADD CONSTRAINT [IPAISCIUDAD1] FOREIGN KEY ([PaisId]) REFERENCES [Pais] ([PaisId]);

