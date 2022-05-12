/**************** Security ****************/
CREATE TABLE Seguridad
(
 IdSeguridad INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
 usuario varchar(50) NOT NULL,
 NombreUsuario varchar(100) NOT NULL,
 Contrasena varchar(200) NOT NULL,
 Rol varchar(15)
 )

 /**************** Task-Items ****************/
CREATE TABLE TaskItems
(
 Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
 Descripcion varchar(50) NOT NULL,
 Titulo varchar(100) NOT NULL,
 Fecha varchar(200) NOT NULL,
 Habilitado varchar(15)
 )

