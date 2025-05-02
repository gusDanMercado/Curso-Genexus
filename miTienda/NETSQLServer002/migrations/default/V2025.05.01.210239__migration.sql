CREATE TABLE [Catalogo] ([CatalogoID] int NOT NULL IDENTITY(1,1), [CatalogoDescripcion] nvarchar(80) NOT NULL , [CatalogoImagen] VARBINARY(MAX) NOT NULL , [CatalogoImagen_GXI] varchar(2048) NOT NULL , [CatalogoFchInicio] datetime NOT NULL , [CatalogoFchFin] datetime NOT NULL , PRIMARY KEY([CatalogoID]));

