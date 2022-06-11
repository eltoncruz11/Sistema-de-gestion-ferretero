-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema SGF
-- -----------------------------------------------------
-- Base de datos perteneciente al proyecto "Sistema de gextion ferretero"

-- -----------------------------------------------------
-- Schema SGF
--
-- Base de datos perteneciente al proyecto "Sistema de gextion ferretero"
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `SGF` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin ;
USE `SGF` ;

-- -----------------------------------------------------
-- Table `SGF`.`Cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Cliente` (
  `idCliente` nvarchar(17) NOT NULL,
  `Nombre` VARCHAR(30) NOT NULL,
  `Apellido` VARCHAR(30) NOT NULL,
  `Contacto` NVARCHAR(50) NOT NULL,
  `Direccion` VARCHAR(65) NULL,
  PRIMARY KEY (`idCliente`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Proveedor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Proveedor` (
  `idProveedor` INT NOT NULL,
  `Nombre` VARCHAR(45) NOT NULL,
  `N° Telefonico` INT NULL,
  `Correo` NVARCHAR(45) NULL,
  `Dirrecion` VARCHAR(65) NULL,
  PRIMARY KEY (`idProveedor`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Categoria`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Categoria` (
  `idCategoria` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idCategoria`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Producto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Producto` (
  `idProducto` INT NOT NULL,
  `Nombre` VARCHAR(35) NOT NULL,
  `Descripcion` VARCHAR(65) NOT NULL,
  `Precio` INT NOT NULL,
  `Marca` VARCHAR(45) NULL,
  `Existencias` INT NOT NULL,
  `Fecha_Vec` NVARCHAR(15) NULL,
  `Categoria_idCategoria` INT NOT NULL,
  PRIMARY KEY (`idProducto`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Venta_Ct`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Venta_Ct` (
  `idVenta` INT NOT NULL AUTO_INCREMENT,
  `Fecha` DATE NOT NULL,
  `Nombre del cliente` VARCHAR(45) NULL,
  `Total_Monto` BIGINT(30) NOT NULL,
  `Ganancia_Total` INT NULL,
  PRIMARY KEY (`idVenta`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Venta_Cd`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Venta_Cd` (
  `idVenta_Cd` INT NOT NULL AUTO_INCREMENT,
  `Fecha` DATE NOT NULL,
  `Total_Monto` BIGINT(30) NOT NULL,
  `Ganancia_Total` INT NULL,
  PRIMARY KEY (`idVenta_Cd`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Deuda`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Deuda` (
  `idDeuda` INT NOT NULL AUTO_INCREMENT,
  `Estado` VARCHAR(25) NOT NULL,
  `Cliente_idCliente` INT NOT NULL,
  `Venta_Cd_idVenta_Cd` INT NOT NULL,
  PRIMARY KEY (`idDeuda`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Detalle_venta_Ct`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Detalle_venta_Ct` (
  `Cantidad` INT NULL,
  `Monto` INT NOT NULL,
  `Ganancia` INT NULL,
  `Venta_Ct_idVenta` INT NOT NULL,
  `Producto_idProducto` INT NOT NULL)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Detalle_venta_cd`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Detalle_venta_cd` (
  `Cantidad` INT NOT NULL,
  `Monto` INT NOT NULL,
  `Ganancia` INT NULL,
  `Venta_Cd_idVenta_Cd` INT NOT NULL)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Descuento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Descuento` (
  `Pocentaje` INT NOT NULL,
  `Inicio` DATETIME(6) NULL,
  `Final` DATETIME(6) NULL,
  `Producto_idProducto` INT NOT NULL)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Compra`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Compra` (
  `idCompra` INT NOT NULL AUTO_INCREMENT,
  `Fecha` DATE NOT NULL,
  `Total_Monto` BIGINT(30) NULL,
  `Proveedor_idProveedor` INT NOT NULL,
  PRIMARY KEY (`idCompra`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Detalle_Compra`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Detalle_Compra` (
  `Cantidad` INT NOT NULL,
  `Precio` INT NOT NULL,
  `Monto` INT NOT NULL,
  `Compra_idCompra` INT NOT NULL,
  `Producto_idProducto` INT NOT NULL)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Usiarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Usuarios` (
  `id` INT not null AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NULL,
  `Pass` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- -- Procedimientos almacenados
-- -----------------------------------------------------

-- -- Usuarios

DELIMITER //
Create Procedure Validacion (
 in idp varchar(45)
, in contrasp varchar (45)
, OUT Mensaje varchar (80))
begin 
 if (length(idp) = 0 or length(contrasp) = 0)
 then set Mensaje = "Por favor rellene todos los campos";
 else if (exists(select* from usuarios where Nombre = idp  and pass = contrasp))
 then set Mensaje = concat("Bienvenido ",idp); 
 else set Mensaje = "Datos Incorrectos";
 end if;
 end if;
END//
DELIMITER ;

CALL Validacion('Elton','',@me);
SELECT @me;






-- -- Clientes
DELIMITER //
Create procedure Agregar_Cliente (
in id nvarchar(17)
, in Nom varchar(30)
, in Apell varchar(30)
, in Contac nvarchar(50)
, in Dir varchar(65)
, out Mensaje varchar(80))
begin
  if (length(id) = 0 or length(Nom) = 0 or length(Apell) = 0 or length(Contac) = 0 or length(Dir) = 0)
  then set Mensaje = "Por favor rellene todos los campos";
  else if (exists(select* from cliente where idCliente = id))
  then set Mesaje = "Ya xiste un cliente registrado con ese ID";
  else 
  insert into cliente values (id,Nom,Apell,Contac,Dir);
   set Mensaje = "Cliente registrado exitosamente";
  end if;
  end if;
end //
DELIMITER ;


DELIMITER //
Create procedure Editar_cliente (
in id nvarchar(17)
, in Nom varchar(30)
, in Apell varchar(30)
, in Contac nvarchar(50)
, in Dir varchar(65)
, out Mensaje varchar(80))
BEGIN
  if (length(Nom) = 0 or length(Apell) = 0 or length(Contac) = 0 or length(Dir) = 0)
  then set Mensaje = "Por favor rellene todos los campos";
  else 
  update cliente set  Nombre = Nom, Apellido = Apell, Contacto= Contac, Direccion = Dir
  WHERE idCliente = id;
  set Mesaje = "Los datos de actualizaron exitosamente";
  end if;
END //
DELIMITER ;


DELIMITER //
Create procedure Eliminar_cliente (
in id nvarchar(17)
, out Mensaje varchar(80))
begin 
   Delete FROM cliente where idCliente = id;
   set Mensaje = "Cliente eliminado con exito";
end //
DELIMITER ;

DELIMITER //
Create procedure Buscar_cliente (
IN dato varchar(50)
, in ind integer
)
begin
if (ind = 0)
then select* from cliente where idCliente like '%'|| dato ||'%';
else if (ind = 1)
then select* from cliente where Nombre like '%' || dato ||'%';
else if (ind = 2)
then select* from cliente where Apellido like '%'|| dato || '%';
else if (ind = 3)
then select* from cliente where Direccion like '%' || dato || '%';
end if;
end if;
end if;
end if;
end //
DELIMITER ;

DELIMITER //
Create procedure Listar_clientes ()
BEGIN
SELECT* FROM clientes;
end //
DELIMITER ;

-- -- Categorias

DELIMITER //
Create procedure Listar_categoria ()
begin
select* from  categoria;
end //
DELIMITER ;

DELIMITER //
Create procedure Agregar_categoria (
in Nomb varchar(45)
, out Mensaje varchar(80))
BEGIN
if (length(Nomb) = 0)
then set Mensaje = "Por favor introducir el nombre de la categoria";
else 
Insert into categoria (Nombre) values (Nomb);
end if;
end //
DELIMITER ;

DELIMITER //
Create procedure Editar_categoria (
in id integer
, in Nom varchar(45)
, out Mensaje varchar(80))
begin
if (length(Nom) = 0)
then set Mensaje = "Por favor introducir el nombre de la categoria";
else 
update categoria set Nombre = Nom WHERE idCategoria = id;
set Mensaje = "La categoria se edito de manera exitosa";
end if;
end //
DELIMITER ;

DELIMITER //
Create procedure Eliminar_categoria (
in id integer
, out Mensaje varchar(80))
Begin 
delete from categoria where idCategoria = id ;
set Mensaje = "La categoria fue eliminada de manera exitosa";
end //
DELIMITER ;

-- -- Producto 

DELIMITER //
Create procedure Listar_producto ()
begin 
select* from producto;
end //
DELIMITER ; 

DELIMITER //
Create procedure Eliminar_producto (
in id integer 
, out Mensaje varchar(80))
begin
delete from producto where idProducto = id;
set Mensaje = "El producto se elimino de manera exitosa";
end //
DELIMITER ;

DELIMITER //
Create procedure Agregar_producto (
in Id integer 
, in Nom varchar(35)
, in Descrip varchar(65)
, in Prec integer
, in Marc varchar(45)
, in Fec varchar(15)
, in Cat integer 
, out Mensaje varchar(80))
begin 
if (length(Id)=0 or length(Nom)=0 or length(Descrip)=0 or length(Prec)=0 or length(Marc)=0 or length(Cat) = 0)
then set Mensaje = "Por favor rellene todos los campos";
else if (exists(select* from producto where idProducto = Id))
then set Mensaje = "Ya existe un producto con el mismo ID";
else if (length(Fec) = 0)
then Insert into producto values (Id,Nom,Descrip,Prec,Marc,0,'NONE',Cat);
set Mensaje = "Producto Registrado de manera exitosa";
else
Insert into producto values (Id,Nom,Descrip,Prec,Marc,0,Fec,Cat);
set Mensaje = "Producto Registrado de manera exitosa";
end if;
end if;
end if;
end //
DELIMITER ;

DELIMITER //
Create procedure Editar_producto (
in Id integer 
, in Nom varchar(35)
, in Descrip varchar(65)
, in Prec integer
, in Marc varchar(45)
, in Fec varchar(15)
, in Cat integer 
, out Mensaje varchar(80))
begin 
if (length(Nom)=0 or length(Descrip)=0 or length(Prec)=0 or length(Marc)=0 or length(Cat) = 0)
then set Mensaje = "Por favor rellene todos los campos";
else if (exists(select* from producto where idProducto = Id))
then set Mensaje = "Ya existe un producto con el mismo ID";
else if (length(Fec) = 0)
Then Update producto set Nombre=Nom, Descripcion=Descrip, Precio=Prec, Marca=Marc, Fecha_Vec='NONE', Categoria_id=Cat where idProducto = Id; 
set Mensaje = "Producto editado de manera exitosa";
else
Update producto set Nombre=Nom, Descripcion=Descrip, Precio=Prec, Marca=Marc, Fecha_Vec=Fec, Categoria_id=Cat where idProducto = Id; 
set Mensaje = "Producto editado de manera exitosa";
end if;
end if;
end if;
end //
DELIMITER ;

-- -- 



