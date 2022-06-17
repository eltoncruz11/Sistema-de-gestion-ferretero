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
  `Telefono` INT NULL,
  `Correo` NVARCHAR(45) NULL,
  `Dirreccion` VARCHAR(65) NULL,
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
  `Precio` DECIMAL NOT NULL,
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
  `Total_Monto` DECIMAL NOT NULL,
  `Ganancia_Total` DECIMAL NULL,
  PRIMARY KEY (`idVenta`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Venta_Cd`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Venta_Cd` (
  `idVenta_Cd` INT NOT NULL AUTO_INCREMENT,
  `Fecha` DATE NOT NULL,
  `Total_Monto` DECIMAL NOT NULL,
  `Ganancia_Total` DECIMAL NULL,
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
  `Monto` DECIMAL NOT NULL,
  `Venta_Ct_idVenta` INT NOT NULL,
  `Producto_idProducto` INT NOT NULL)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Detalle_venta_cd`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS SGF.Detalle_venta_cd (
  Cantidad INT NOT NULL,
  Monto DECIMAL NOT NULL,
  Venta_Cd_idVenta_Cd INT NOT NULL,
  Producto_idProducto INT NOT NULL,
  INDEX fk_Detalle_venta_cd_Venta_Cd1_idx (Venta_Cd_idVenta_Cd ASC) VISIBLE,
  INDEX fk_Detalle_venta_cd_Producto1_idx (Producto_idProducto ASC) VISIBLE,
  CONSTRAINT fk_Detalle_venta_cd_Venta_Cd1
    FOREIGN KEY (Venta_Cd_idVenta_Cd)
    REFERENCES SGF.Venta_Cd (idVenta_Cd)
    ON DELETE cascade
    ON UPDATE cascade,
  CONSTRAINT fk_Detalle_venta_cd_Producto1
    FOREIGN KEY (Producto_idProducto)
    REFERENCES SGF.Producto (idProducto)
    ON DELETE Cascade
    ON UPDATE cascade)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Descuento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Descuento` (
   id integer auto_increment ,
  `Pocentaje` INT NOT NULL,
  `Inicio` DATE NULL,
  `Final` DATE NULL,
   Precio decimal ,
   estado bool,
  `Producto_idProducto` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
    INDEX `fk_Descuento_Producto1_idx` (`Producto_idProducto` ASC) VISIBLE,
  CONSTRAINT `fk_Descuento_Producto1`
    FOREIGN KEY (`Producto_idProducto`)
    REFERENCES `SGF`.`Producto` (`idProducto`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `SGF`.`Compra`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Compra` (
  `idCompra` INT NOT NULL AUTO_INCREMENT,
  `Fecha` DATE NOT NULL,
  `Total_Monto` DECIMAL NULL,
  `Proveedor_idProveedor` INT NOT NULL,
  PRIMARY KEY (`idCompra`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SGF`.`Detalle_Compra`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SGF`.`Detalle_Compra` (
  `Cantidad` INT NOT NULL,
  `Precio` DECIMAL NOT NULL,
  `Monto` DECIMAL NOT NULL,
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



-- -- Clientes - ----------------------------------------------------------------------------------------
DELIMITER //
Create procedure Agregar_Cliente (
in id nvarchar(17)
, in Nom varchar(30)
, in Apell varchar(30)
, in Contac nvarchar(50)
, in Dir varchar(85)
, out Mensaje varchar(80))
begin
  if (length(id) = 0 or length(Nom) = 0 or length(Apell) = 0 or length(Contac) = 0 or length(Dir) = 0)
  then set Mensaje = "Por favor rellene todos los campos";
  else if (exists(select* from cliente where idCliente = id))
  then set Mensaje = "Ya xiste un cliente registrado con ese ID";
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
  set Mensaje = "Los datos se actualizaron exitosamente";
  end if;
END //
DELIMITER ;


DELIMITER //
Create procedure Eliminar_cliente (
in id nvarchar(17))
begin 
   Delete FROM cliente where idCliente = id;
end //
DELIMITER ;

DELIMITER //
Create procedure Buscar_cliente (
IN dato varchar(50)
, in ind integer
)
begin
if (ind = 0)
then select* from cliente where idCliente like CONCAT('%',dato,'%');
else if (ind = 1)
then select* from cliente where Nombre like  CONCAT('%',dato,'%');
else if (ind = 2)
then select* from cliente where Apellido like CONCAT('%',dato,'%');
else if (ind = 3)
then select* from cliente where Direccion like CONCAT('%',dato,'%');
end if;
end if;
end if;
end if;
end //
DELIMITER ;


DELIMITER //
Create procedure Listar_clientes ()
BEGIN
SELECT idCliente as Id, Nombre, Apellido, Contacto, Direccion FROM cliente;
end //
DELIMITER ;

-- -- Categorias ---------------------------------------------------------------------------------------- -

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
set Mensaje = "Categoria registrada exitosamente";
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
in id integer )
Begin 
delete from categoria where idCategoria = id ;
end //
DELIMITER ;

select* from categoria;

call Eliminar_categoria(4);

-- -- Producto -------------------------------------------------------------------------------------------------


DELIMITER //
Create procedure Buscar_prod (
IN dato varchar(50)
, in ind integer
)
begin
if (ind = 0)
then select p.idProducto as Id, p.Nombre , p.Precio , p.Existencias ,c.Nombre as Categoria from producto as p , categoria as c where c.idCategoria = p.Categoria_idCategoria and p.idProducto like CONCAT('%',dato,'%');
else if (ind = 1)
then select p.idProducto as Id, p.Nombre , p.Precio , p.Existencias ,c.Nombre as Categoria from producto as p , categoria as c where c.idCategoria = p.Categoria_idCategoria and p.Nombre like CONCAT('%',dato,'%');
else if (ind = 2)
then select p.idProducto as Id, p.Nombre , p.Precio , p.Existencias ,c.Nombre as Categoria from producto as p , categoria as c where c.idCategoria = p.Categoria_idCategoria and c.Nombre like CONCAT('%',dato,'%');
end if;
end if;
end if;
end //
DELIMITER ; 


DELIMITER //
Create procedure Contar_producto ()
BEGIN 
SELECT count(idProducto) as Cantidad FROM producto;
END //
DELIMITER ;

DELIMITER //
Create procedure Contar_Marca ()
begin
select count(Marca) as Cantidad from producto group by Marca;
end //
DELIMITER ;

DELIMITER //
Create procedure Contar_categoria ()
begin
select count(idCategoria) as Cantidad from categoria ; 
end //
DELIMITER ;



DELIMITER //
Create procedure Listar_producto()
begin 
select p.idProducto as Id, p.Nombre , p.Precio , p.Existencias ,c.Nombre as Categoria from producto as p , categoria as c where c.idCategoria = p.Categoria_idCategoria ;
end //
DELIMITER ;


DELIMITER //
Create procedure Informacion_c (
in Id integer)
begin
SELECT p.idProducto , p.Nombre, p.Descripcion, p.Precio, p.Marca , p.Existencias, p.Fecha_Vec, c.Nombre as Categoria from producto as p ,categoria as c where idCategoria = Categoria_idCategoria and idProducto = Id ;
end //
DELIMITER ;



DELIMITER //
Create procedure Eliminar_producto (
in id integer)
begin
delete from producto where idProducto = id;
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
else if (length(Fec) = 0)
Then Update producto set Nombre=Nom, Descripcion=Descrip, Precio=Prec, Marca=Marc, Fecha_Vec='NONE', Categoria_idCategoria=Cat where idProducto = Id; 
set Mensaje = "Producto editado de manera exitosa";
else
Update producto set Nombre=Nom, Descripcion=Descrip, Precio=Prec, Marca=Marc, Fecha_Vec=Fec, Categoria_idCategoria=Cat where idProducto = Id; 
set Mensaje = "Producto editado de manera exitosa";
end if;
end if;
end //
DELIMITER ;



-- -- Deudas ------------------------------------------------------------------------------------------
 DELIMITER //
 Create procedure Listar_deudas(
 in idc nvarchar(17))
 begin
 Select de.idDeuda as Id , de.Venta_Cd_idVenta_Cd as Id_Venta,cd.FECHA, cd.Total_Monto as Monto from  venta_cd as cd, deuda as de , cliente as cl
 where de.Cliente_idCliente = idc and de.Venta_Cd_idVenta_Cd = cd.idVenta_Cd ;
 end //
 DELIMITER ;
 
 DELIMITER //
 Create procedure Eliminar_deuda(
 in Idc nvarchar(17)
 , in Idv integer)
 begin
 Delete from deuda where idDeuda = Idc and Venta_Cd_idVenta_Cd = Idv ;
 END //
DELIMITER ;

DELIMITER //
Create procedure Eliminar_deudas (
in Idc nvarchar(17))
begin
 Delete from deuda where idDeuda = Idc ;
end //
DELIMITER ;

DELIMITER //
Create procedure Informe_d ()
begin 
Select cl.idCliente as Id, cl.Nombre,cl.Apellido, cl.Contacto,SUM(cd.Total_Monto) as Monto from  venta_cd as cd, deuda as de , cliente as cl
 where de.Cliente_idCliente = cl.idCliente  and de.Venta_Cd_idVenta_Cd = cd.idVenta_Cd group by cl.Nombre ;
end //
DELIMITER ;



-- -- Informes ----------------------------------------------------------------------------------------
-- ---------------------------------------------------------------------------------------------------
DELIMITER //
Create procedure Infor_venta (
in fecha_i date
, in fecha_f date )
begin
select idVenta as Id, Fecha , Total_Monto as Sub_Total , Ganancia_Total as Ganancia from venta_ct where Fecha between fecha_i and fecha_f;
end //
DELIMITER ;


DELIMITER //
Create procedure Infor_compra (
in fecha_i date
, in fecha_f date )
begin
select c.idCompra as Id, c.Fecha , p.Nombre as Proveedor,c.Total_Monto as Sub_Total  from compra as c, proveedor as p where p.idProveedor = c.Proveedor_idProveedor and  Fecha between fecha_i and fecha_f;
end //
DELIMITER ;

-- -- Descuentos ----------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------

DELIMITER //
Create procedure Agregar_descuento (
in id_p int 
, in ini date 
,in fin date
,in Prec decimal
,in Porc int 
, out Mensaje varchar(80)
)
Begin
if (length(ini) = 0 or length(fin) = 0 or length(Porc) = 0)
then set Mensaje = "Por favor rellenar todos los campos" ;
else 
insert into descuento (Pocentaje,Inicio,Final,Precio,Estado,Producto_idProducto) values (Porc,ini,fin,Prec,true,id_p);
set Mensaje = "El descuento se ha aplicado con exito" ;
end if;
end //
DELIMITER ;

DELIMITER //
create procedure Actualizar_des(
)
update descuento set estado = false where Final >= curdate();
END //
DELIMITER ;

DELIMITER //
Create procedure Temp_res (
in id_p integer)
begin 
select p.Nombre , datediff(    curdate(), d.Inicio) as tiemp, p.Precio , d.Precio from descuento as d , producto as p where p.idProducto = d.Producto_idProducto and p.idProducto = id_p and d.id in (select max(id) from descuento);
end //
DELIMITER ;


DELIMITER //
Create procedure obtener_est (
in id_p integer )
begin 
select estado from descuento where Producto_idProducto = id_p and id in (select max(id) from descuento);

end //
DELIMITER ;

DELIMITER //
Create procedure Fin_des (
in id_p integer
, out Mensaje varchar(80))
Begin 
update descuento set estado = false where Producto_IdProducto = id_p ;
set Mensaje = "El descuento ha terminado";
end //
DELIMITER ;

-- -- Proveedor -------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------

-- Agregar
DELIMITER //
Create procedure Agregar_Proveedor (
  in idProveed INT,
  in Nombr VARCHAR(45),
  in Telefo INT,
  in Corr NVARCHAR(45),
  in Dirrec VARCHAR(65),
  out Mensaje varchar(80))
  begin 
  if (length(idProveed) = 0 or length(Nombr) = 0 or length(Telefo) = 0 or length(Corr) = 0 or length(Dirrec) = 0)
  then set Mensaje = "Por favor rellene todos los campos";
  else if (exists(select* from proveedor where idProveedor = idProveed))
  then set Mesaje = "Ya xiste un proveedor registrado con ese ID";
  else 
  insert into proveedor values (idProveed,Nombr,Telefo,Corr,Dirrec);
   set Mensaje = "Proveedor registrado exitosamente";
  end if;
  end if;
end //
DELIMITER ;
-- ----------------------------------------  
-- Mostrar
DELIMITER //
Create procedure Mostrar_Proveedor ()
  begin 
select* from proveedor;
end //
DELIMITER ;
-- ----------------------------------------
-- Editar
DELIMITER //
Create procedure Editar_Proveedor (
  in idProveed INT,
  in Nombr VARCHAR(45),
  in Telefo INT,
  in Corr NVARCHAR(45),
  in Dirrec VARCHAR(65),
  out Mensaje varchar(80))
BEGIN
  if (length(Nombr) = 0 or length(Telefo) = 0 or length(Corr) = 0 or length(Dirrec) = 0)
  then set Mensaje = "Por favor rellene todos los campos";
  else 
  update proveedor set  Nombre = Nombr, Telefono = Telefo, Correo = Corr, Direccion = Dirrec
  WHERE idProveedor = idProveed;
  set Mesaje = "Los datos de actualizaron exitosamente";
  end if;
END //
DELIMITER ;
-- ----------------------------------------
-- Eliminar
DELIMITER //
Create procedure Eliminar_proveedor (
in idProveed nvarchar(17)
, out Mensaje varchar(80))
begin 
   Delete FROM proveedor where idProveedor = idProveed;
   set Mensaje = "proveedor eliminado con exito";
end //
DELIMITER ;
-- -----------------------------------------
-- Buscar
DELIMITER //
Create procedure Buscar_proveedor (
IN dato varchar(50)
, in ind integer
)
begin
if (ind = 0)
then select* from proveedor where idProveedor like concat('%',dato ,'%');
else if (ind = 1)
then select* from proveedor where Nombre like concat('%',dato ,'%');
else if (ind = 2)
then select* from proveedor where Telefonico like concat('%',dato ,'%');
else if (ind = 3)
then select* from proveedor where Correo like concat('%',dato ,'%');
else if (ind = 4)
then select* from proveedor where Dirrecion like concat('%',dato ,'%');
end if;
end if;
end if;
end if;
end if;
end //
DELIMITER ;

-- -- Compras -----------------------------------------------------------------------------------
-- ---------------------------------------------------------------------------------------------
-- Agregar
DELIMITER //
Create procedure Agregar_compra (
  in Fech DATE,
  in Total_Mont BIGINT(30),
  in Proveedor_idProveedo INT,
  out Mensaje varchar(80))
  begin 
  if (length(Fech) = 0 or length(Total_Mont) = 0 or length(Proveedor_idProveedo) = 0)
  then set Mensaje = "Por favor rellene todos los campos";
  else 
  insert into compra values (Fech,Total_Mont,Proveedor_idProveedo);
   set Mensaje = "compra registrado exitosamente";
  end if;
end //
DELIMITER ;
-- ----------------------------------------  
-- Mostrar
DELIMITER //
Create procedure Mostrar_compra ()
  begin 
select* from compra;
end //
DELIMITER ;
-- ----------------------------------------
-- Eliminar
DELIMITER //
Create procedure Eliminar_compra (
in idCompr nvarchar(17)
, out Mensaje varchar(80))
begin 
   Delete FROM compra where idCompra = idCompr;
   set Mensaje = "compra eliminada con exito";
end //
DELIMITER ;
-- -----------------------------------------
-- Buscar
DELIMITER //
Create procedure Buscar_compra (
IN dato varchar(50)
, in ind integer
)
begin
if (ind = 0)
then select* from compra where idCompra like concat('%',dato ,'%');
else if (ind = 1)
then select* from compra where Fecha like concat('%',dato ,'%');
else if (ind = 2)
then select* from compra where Total_Monto like concat('%',dato ,'%');
else if (ind = 3)
then select* from compra where Proveedor_idProveedor like concat('%',dato ,'%');
end if;
end if;
end if;
end if;
end //
DELIMITER ;
-- -------------------------------------------------------------------------------------------
-- Agregar
DELIMITER //
Create procedure Agregar_detalle_compra (
  in Cantida INT,
  in Preci DECIMAL,
  in Mont INT,
  in Compra_idCompr INT,
  in Producto_idProduct INT)
  begin 
  insert into detalle_compra values (Cantida,Preci,Mont,Compra_idCompr,Producto_idProduct);
  end //
DELIMITER ;

DELIMITER //
Create procedure Agregar_productos (
  in Nombr VARCHAR(35))
  begin
  select idProducto,Nombre, Precio from producto where Nombre=Nombr;
  end ;
  DELIMITER  //
  
  DELIMITER //
  create procedure mostrar_detalles_por_Compra(
    in Compra_idCompr INT)
  begin
  select* from detalle_compra where Compra_idCompra = Compra_idCompr;
  end //
  DELIMITER ;
  
  DELIMITER //
Create procedure Eliminar_detalle_compra (
  in Compra_idCompr INT
  , out Mensaje varchar(80))
  begin 
  Delete FROM compra where  Compra_idCompra= Compra_idCompr;
   set Mensaje = "detalle eliminado con exito";
  end //
DELIMITER ;
    

-- Ventas ---------------------------------------------------------------------------------------
-- ----------------------------------------------------------------------------------------------
-- Agregar
DELIMITER //
Create procedure Agregar_venta_ct (
  in Fech DATE,
  in Total_Mont decimal,
  in Ganancia_Tot decimal,
  out Mensaje varchar(80))
  begin 
  if (length(Fech) = 0  or length(Total_Mont) = 0 or length(Ganancia_Tot) = 0)
  then set Mensaje = "Por favor rellene todos los campos";
  else 
  insert into venta_ct values (Fech,Total_Mont,Ganancia_Tot);
   set Mensaje = "venta registrada exitosamente";
  end if;
end //
DELIMITER ;

DELIMITER //
Create procedure Agregar_detalle_venta_ct (
  in Cantid INT,
  in Mont decimal,
  in Venta_Ct_idVent INT,
  in Producto_idProduct INT)
  begin 
  insert into venta_ct values (Cantid,Mont,Gananc,Venta_Ct_idVent,Producto_idProduct);
end //
DELIMITER ;
-- ------------------------------------------------------------------------------------------
-- Agregar
DELIMITER //
Create procedure Agregar_venta_cd (
  in Fech DATE,
  in Total_Mont decimal,
  in Ganancia_Tot decimal,
  out Mensaje varchar(80))
  begin 
  if (length(Fech) = 0  or length(Total_Mont) = 0 or length(Ganancia_Tot) = 0)
  then set Mensaje = "Por favor rellene todos los campos";
  else 
  insert into venta_ct values (Fech,Total_Mont,Ganancia_Tot);
   set Mensaje = "venta registrada exitosamente";
  end if;
end //
  
DELIMITER //
Create procedure Agregar_detalle_venta_cd (
  in Cantid INT,
  in Mont decimal,
  in Venta_Cd_idVenta INT,
  in Producto_idProduct INT)
  begin 
  insert into venta_ct values (Cantid,Mont,Gananc,Venta_Cd_idVenta,Producto_idProduct);
end //
DELIMITER ;

DELIMITER //
Create procedure Agregar_productos (
  in Nombr VARCHAR(35))
  begin
  select idProducto, Precio from producto where Nombre= Nombr;
  end ;
  DELIMITER  //

-- Usuarios ----------------------------------------------------------------------------------------
-- -------------------------------------------------------------------------------------------------

-- Agregar
DELIMITER //
Create procedure Agregar_usuarios (
  in Nombr VARCHAR(45),
  in contrasp VARCHAR(45),
  OUT Mensaje varchar (80))
  begin 
  if (length(Nombr) = 0 or length(contrasp) = 0 )
  then set Mensaje = "Por favor rellene todos los campos";
  else 
  insert into usuarios values (Nombr,contrasp);
   set Mensaje = "usuario registrado exitosamente";
  end if;
end //
DELIMITER ;
-- ----------------------------------------  
-- Mostrar
DELIMITER //
Create procedure Mostrar_usuarios ()
  begin 
select* from usuarios;
end //
DELIMITER ;
-- ----------------------------------------
-- Editar
DELIMITER //
Create procedure Editar_usuarios (
  in idp INT,
    in Nombr VARCHAR(45),
, in contrasp varchar (45)
, OUT Mensaje varchar (80))
BEGIN
  if (length(Nombr) = 0 or length(contrasp) = 0 )
  then set Mensaje = "Por favor rellene todos los campos";
  else 
  update usuarios set  Nombre = Nombr, Pass = contrasp
  WHERE id = idp;
  set Mesaje = "Los datos de actualizaron exitosamente";
  end if;
END //
DELIMITER ;
-- ----------------------------------------
-- Eliminar
DELIMITER //
Create procedure Eliminar_usuarios (
in idp varchar(45)
, out Mensaje varchar(80))
begin 
   Delete FROM usuarios where id = idp;
   set Mensaje = "usuario eliminado con exito";
end //
DELIMITER ;
-- -----------------------------------------
-- Buscar
DELIMITER //
Create procedure Buscar_usuarios (
IN dato varchar(50)
, in ind integer
)
begin
if (ind = 0)
then select* from usuarios where id like concat('%',dato ,'%');
else if (ind = 1)
then select* from usuarios where Nombre like concat('%',dato ,'%');
else if (ind = 2)
then select* from usuarios where Pass like concat('%',dato ,'%');
end if;
end if;
end if;
end //
DELIMITER ;
