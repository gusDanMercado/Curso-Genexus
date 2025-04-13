CREATE TABLE [Empleado] ([EmpleadoId] smallint NOT NULL IDENTITY(1,1), [EmpleadoNombre] nvarchar(40) NOT NULL , [EmpleadoApellido] nvarchar(40) NOT NULL , [EmpleadoDireccion] nvarchar(1024) NULL , [EmpleadoTelefono] nchar(20) NULL , [EmpleadoEmail] nvarchar(100) NULL , PRIMARY KEY([EmpleadoId]));

