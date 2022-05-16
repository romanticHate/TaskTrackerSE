/*******************************************/
/**************** Security *****************/
/*******************************************/
CREATE TABLE Seguridad
(
 IdSeguridad INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
 Usuario varchar(50) NOT NULL,
 NombreUsuario varchar(100) NOT NULL,
 Contrasena varchar(200) NOT NULL,
 Rol varchar(15)
 )

/*******************************************/
/**************** Task-Item ****************/
/*******************************************/
CREATE TABLE TareaItem
(
 IdTaskItem INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
 Descripcion varchar(500) NOT NULL,
 Titulo varchar(100) NOT NULL,
 Fecha datetime, 
 Habilitado bit NOT NULL DEFAULT (0),
 IdEmpleado INT NOT NULL
 )

/*******************************************/
/**************** Employee *****************/
/*******************************************/
CREATE TABLE Employee
(
 IdEmpleado INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
 Usuario varchar(500) NOT NULL,
 Pass varchar(100) NOT NULL,
 Fecha datetime, 
 Habilitado bit NOT NULL DEFAULT (0)
 )

