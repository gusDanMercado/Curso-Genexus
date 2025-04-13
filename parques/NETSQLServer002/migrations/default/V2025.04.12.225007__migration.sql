CREATE TABLE [parqueAtraccion] ([parqueAtraccionId] smallint NOT NULL IDENTITY(1,1), [parqueAtraccionNombre] nvarchar(20) NOT NULL , [parqueAtraccionSitioWeb] nvarchar(60) NOT NULL , [parqueAtraccionDireccion] nvarchar(1024) NOT NULL , [parqueAtraccionFoto] VARBINARY(MAX) NOT NULL , [parqueAtraccionFoto_GXI] varchar(2048) NOT NULL , PRIMARY KEY([parqueAtraccionId]));

