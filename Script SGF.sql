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
  `idCliente` INT NOT NULL,
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
 if (exists(select* from usuarios where Nombre = idp  and pass = contrasp))
 then set Mensaje = concat("Bienvenido ",idp); 
 else set Mensaje = "Datos Incorrectos";
 end if;
END//
DELIMITER ;



CALL Validacion('Elton','123',@me);
SELECT @me;

insert into usuarios (Nombre, Pass) values ('Elton','123');


