-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: acs_sistema
-- ------------------------------------------------------
-- Server version	8.0.18

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `acs_sistema`
--
start transaction;
/*!40000 DROP DATABASE IF EXISTS `acs_sistema`*/;

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `acs_sistema` /*!40100 DEFAULT CHARACTER SET latin1 */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `acs_sistema`;

--
-- Table structure for table `acciones`
--

DROP TABLE IF EXISTS `acciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acciones` (
  `Codigo` int(8) unsigned zerofill NOT NULL,
  `Descripcion` varchar(150) DEFAULT NULL,
  `Fecha` datetime DEFAULT NULL COMMENT 'Fecha y Hora que se  agrego la accion',
  `tipo_orden` varchar(45) NOT NULL,
  PRIMARY KEY (`Codigo`),
  KEY `Index_codigo_accion` (`Codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acciones`
--

LOCK TABLES `acciones` WRITE;
/*!40000 ALTER TABLE `acciones` DISABLE KEYS */;
INSERT INTO `acciones` VALUES (00001000,'ORDEN GENERICA Sistema Nuevo','2020-01-06 21:41:35','SALIDA'),(00001001,'INGRESO EQUIPOS NUEVOS','2021-10-03 13:49:45','ENTRADA');
/*!40000 ALTER TABLE `acciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `buscar_pedido_equipos`
--

DROP TABLE IF EXISTS `buscar_pedido_equipos`;
/*!50001 DROP VIEW IF EXISTS `buscar_pedido_equipos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `buscar_pedido_equipos` AS SELECT 
 1 AS `Codigo_Institucion`,
 1 AS `Centro_educativo`,
 1 AS `id_registro`,
 1 AS `id_orden`,
 1 AS `fecha_registro`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `cambios`
--

DROP TABLE IF EXISTS `cambios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cambios` (
  `idplaca` varchar(30) NOT NULL,
  `idserie` varchar(30) NOT NULL,
  `orden` int(8) unsigned zerofill NOT NULL,
  `estado` varchar(20) NOT NULL,
  `numero_estacion` int(11) DEFAULT NULL,
  `fecha` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`idplaca`,`orden`),
  KEY `fk_orden_idx` (`orden`),
  CONSTRAINT `fk_orden` FOREIGN KEY (`orden`) REFERENCES `acciones` (`Codigo`),
  CONSTRAINT `fk_placa` FOREIGN KEY (`idplaca`) REFERENCES `equipos` (`placa`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cambios`
--

LOCK TABLES `cambios` WRITE;
/*!40000 ALTER TABLE `cambios` DISABLE KEYS */;
/*!40000 ALTER TABLE `cambios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `cantidad_materiales_inventario`
--

DROP TABLE IF EXISTS `cantidad_materiales_inventario`;
/*!50001 DROP VIEW IF EXISTS `cantidad_materiales_inventario`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `cantidad_materiales_inventario` AS SELECT 
 1 AS `codigo_material`,
 1 AS `descripcion`,
 1 AS `cantidad_stock`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `cantidad_pendientes`
--

DROP TABLE IF EXISTS `cantidad_pendientes`;
/*!50001 DROP VIEW IF EXISTS `cantidad_pendientes`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `cantidad_pendientes` AS SELECT 
 1 AS `Total`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `cantidad_stock_materiales`
--

DROP TABLE IF EXISTS `cantidad_stock_materiales`;
/*!50001 DROP VIEW IF EXISTS `cantidad_stock_materiales`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `cantidad_stock_materiales` AS SELECT 
 1 AS `cantidad`,
 1 AS `descripcion`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `carteles`
--

DROP TABLE IF EXISTS `carteles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `carteles` (
  `id_cartel` varchar(30) NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  `fecha_registro` varchar(30) NOT NULL,
  PRIMARY KEY (`id_cartel`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carteles`
--

LOCK TABLES `carteles` WRITE;
/*!40000 ALTER TABLE `carteles` DISABLE KEYS */;
INSERT INTO `carteles` VALUES ('000-00-0','0000PP-00000-PROV-ACS','2021-05-05'),('2018-11-01','2018-000011PP-PROV-FOD','2019-10-20'),('2019-08-02','2019PP-00008-PROV-FOD','2019-11-12'),('2020-10-01','Lote 1 del Cartel 2020PP-000010-PROV-FOD','23/9/2021 08:16:24'),('2020-10-02','Lote 2 Cartel 2020PP-000010-PROV-FOD','23/9/2021 08:17:11');
/*!40000 ALTER TABLE `carteles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `danos`
--

DROP TABLE IF EXISTS `danos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `danos` (
  `id_danos` int(3) unsigned zerofill NOT NULL,
  `dano` varchar(100) NOT NULL,
  PRIMARY KEY (`id_danos`,`dano`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `danos`
--

LOCK TABLES `danos` WRITE;
/*!40000 ALTER TABLE `danos` DISABLE KEYS */;
INSERT INTO `danos` VALUES (001,'TARJETA MADRE'),(002,'WLAN'),(003,'LAN'),(004,'MEMORIA RAM'),(005,'TECLADO'),(006,'VENTILADOR(COOLING FAN)'),(007,'PUERTO USB'),(008,'FLEX'),(009,'DAÑO TOTAL'),(010,'ENCLOUSURE'),(011,'CAMARA WEB'),(012,'FLASHEO'),(013,'BIOS'),(014,'NO ENCIENDE'),(015,'BISAGRAS'),(016,'TOUCHPAD'),(017,'DISCO DURO'),(018,'BATERIA'),(019,'CARGADOR'),(020,'BACKCOVER'),(021,'BEZEL'),(022,'TOP COVER'),(023,'PANTALLA'),(024,'DAÑO FISICO');
/*!40000 ALTER TABLE `danos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipos`
--

DROP TABLE IF EXISTS `equipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipos` (
  `codigo_modelo` int(3) unsigned zerofill NOT NULL,
  `placa` varchar(30) NOT NULL,
  `serie` varchar(30) NOT NULL,
  `id_cartel` varchar(30) NOT NULL,
  PRIMARY KEY (`placa`,`serie`),
  KEY `modelo_ibfk_1_idx` (`codigo_modelo`),
  KEY `cartel_ibfk_idx` (`id_cartel`),
  CONSTRAINT `cartel_ibfk` FOREIGN KEY (`id_cartel`) REFERENCES `carteles` (`id_cartel`),
  CONSTRAINT `modelo_ibfk_1` FOREIGN KEY (`codigo_modelo`) REFERENCES `modelos_equipos` (`codigo_modelo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipos`
--

LOCK TABLES `equipos` WRITE;
/*!40000 ALTER TABLE `equipos` DISABLE KEYS */;
INSERT INTO `equipos` VALUES (018,'402019','SMP20BZAA','2020-10-01'),(018,'482013','SMP20C1LJ','2020-10-01'),(018,'482014','SMP20BX03','2020-10-01'),(018,'482015','SMP20BZB4','2020-10-01'),(018,'482016','SMP20BZ94','2020-10-01'),(018,'482017','SMP20BZ8H','2020-10-01'),(018,'482018','SMP20BWXX','2020-10-01'),(018,'482020','SMP20C1JV','2020-10-01'),(018,'482021','SMP20C1LH','2020-10-01'),(018,'482022','SMP20C1KN','2020-10-01'),(018,'482023','SMP20BZ8L','2020-10-01'),(018,'482024','SMP20BZ9M','2020-10-01'),(018,'482025','SMP20BZ8R','2020-10-01'),(018,'482026','SMP20C1KH','2020-10-01'),(018,'482027','SMP20C3VB','2020-10-01'),(018,'482028','SMP20C1JY','2020-10-01'),(018,'482029','SMP20BZ7Z','2020-10-01'),(018,'482030','SMP20BZ9Q','2020-10-01'),(018,'482031','SMP20BWY4','2020-10-01'),(018,'482032','SMP20C1JM','2020-10-01'),(018,'482033','SMP20C1JA','2020-10-01'),(018,'482034','SMP20BX23','2020-10-01'),(018,'482035','SMP20BZ9Y','2020-10-01'),(018,'482036','SMP20BZ98','2020-10-01'),(018,'482037','SMP20BZB1','2020-10-01'),(018,'482038','SMP20BZBP','2020-10-01'),(018,'482039','SMP20BZAK','2020-10-01'),(018,'482040','SMP20BX2D','2020-10-01'),(018,'482041','SMP20BZ8T','2020-10-01'),(018,'482042','SMP20BZBF','2020-10-01'),(018,'482043','SMP20BX1X','2020-10-01'),(018,'482044','SMP20BWXZ','2020-10-01'),(018,'482045','SMP20BWY7','2020-10-01'),(018,'482046','SMP20BX06','2020-10-01'),(018,'482047','SMP20BX0A','2020-10-01'),(018,'482048','SMP20BWZ1','2020-10-01'),(018,'482049','SMP20BZ9C','2020-10-01'),(018,'482050','SMP20BWZF','2020-10-01'),(018,'482051','SMP20C3P8','2020-10-01'),(018,'482052','SMP20C3LV','2020-10-01'),(018,'482053','SMP20C3NE','2020-10-01'),(018,'482054','SMP20C3N6','2020-10-01'),(018,'482055','SMP20BWYB','2020-10-01'),(018,'482056','SMP20BWZ0','2020-10-01'),(018,'482057','SMP20BWZQ','2020-10-01'),(018,'482058','SMP20C3N9','2020-10-01'),(018,'482059','SMP20BZMF','2020-10-01'),(018,'482060','SMP20C70S','2020-10-01'),(018,'482061','SMP20C71S','2020-10-01'),(018,'482062','SMP20C72B','2020-10-01'),(018,'482063','SMP20BZK6','2020-10-01'),(018,'482064','SMP20C3LQ','2020-10-01'),(018,'482065','SMP20BX1B','2020-10-01'),(018,'482066','SMP209FPZ','2020-10-01'),(018,'482067','SMP20BX19','2020-10-01'),(018,'482068','SMP20BZHQ','2020-10-01'),(018,'482069','SMP20BZKT','2020-10-01'),(018,'482070','SMP20C70W','2020-10-01'),(018,'482071','SMP20BZMK','2020-10-01'),(018,'482072','SMP20BZJN','2020-10-01'),(018,'482073','SMP20BZG1','2020-10-01'),(018,'482074','SMP20C71C','2020-10-01'),(018,'482075','SMP20C72K','2020-10-01'),(018,'482076','SMP20BZKV','2020-10-01'),(018,'482077','SMP20C71W','2020-10-01'),(018,'482078','SMP20BX15','2020-10-01'),(018,'482079','SMP20BXB2','2020-10-01'),(018,'482080','SMP20BX0X','2020-10-01'),(018,'482081','SMP20BWZW','2020-10-01'),(018,'482082','SMP207SRJ','2020-10-01'),(018,'482083','SMP20BX1V','2020-10-01'),(018,'482084','SMP20C727','2020-10-01'),(018,'482085','SMP20C72J','2020-10-01'),(018,'482086','SMP20C72D','2020-10-01'),(018,'482087','SMP20C3X4','2020-10-01'),(018,'482088','SMP20BWY5','2020-10-01'),(018,'482089','SMP20BWYJ','2020-10-01'),(018,'482090','SMP20BWYF','2020-10-01'),(018,'482091','SMP20C2W5','2020-10-01'),(018,'482092','SMP20BX14','2020-10-01'),(018,'482093','SMP20BX0K','2020-10-01'),(018,'482094','SMP20BW3L','2020-10-01'),(018,'482095','SMP20CDW7','2020-10-01'),(018,'482096','SMP20BX04','2020-10-01'),(018,'482097','SMP20C71Y','2020-10-01'),(018,'482098','SMP20C71M','2020-10-01'),(018,'482099','SMP20BZLV','2020-10-01'),(018,'482100','SMP20BZML','2020-10-01'),(018,'482101','SMP20BZLC','2020-10-01'),(018,'482102','SMP20BZHF','2020-10-01'),(018,'482103','SMP20BX7S','2020-10-01'),(018,'482104','SMP20BZL3','2020-10-01');
/*!40000 ALTER TABLE `equipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipos_instalacion_instituciones`
--

DROP TABLE IF EXISTS `equipos_instalacion_instituciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipos_instalacion_instituciones` (
  `Codigo_Institucion` varchar(5) DEFAULT NULL,
  `Modalidad` varchar(45) DEFAULT NULL,
  `Condicion` varchar(45) DEFAULT NULL,
  `Port_1_docente` int(11) DEFAULT '0',
  `Port_1_preeescolar` int(11) DEFAULT '0',
  `Port_1_estudiante` int(11) DEFAULT '0',
  `Port_2_estudiante` int(11) DEFAULT '0',
  `Servidor` int(11) DEFAULT '0',
  `Nas` int(11) DEFAULT '0',
  `Proyector` int(11) DEFAULT '0',
  `Impresora` int(11) DEFAULT '0',
  `Audifonos` int(11) DEFAULT '0',
  `Mouse` int(11) DEFAULT '0',
  `Candados` int(11) DEFAULT '0',
  `ConvertirdorPolarizado` int(11) DEFAULT '0',
  `Extensiones` int(11) DEFAULT '0',
  `Regletas` int(11) DEFAULT '0',
  `Maletin_proyector` int(11) DEFAULT '0',
  `Maletin_portatil` int(11) DEFAULT '0',
  `Router` int(11) DEFAULT '0',
  `Switch` int(11) DEFAULT '0',
  `ApInterno` int(11) DEFAULT '0',
  `ApExterno` int(11) DEFAULT '0',
  `Parlantes_1` int(11) DEFAULT '0',
  `Parlantes_2` int(11) DEFAULT '0',
  `Unidad_optica` int(11) DEFAULT '0',
  `Unidad_36` int(11) DEFAULT '0',
  `Unidad_24` int(11) DEFAULT '0',
  `Unidad_30` int(11) DEFAULT '0',
  `Unidad_16` int(11) DEFAULT '0',
  `Ups_1` int(11) DEFAULT NULL,
  `Ups_2` int(11) DEFAULT NULL,
  KEY `Codigo_idx` (`Codigo_Institucion`),
  CONSTRAINT `Codigo` FOREIGN KEY (`Codigo_Institucion`) REFERENCES `instituciones` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipos_instalacion_instituciones`
--

LOCK TABLES `equipos_instalacion_instituciones` WRITE;
/*!40000 ALTER TABLE `equipos_instalacion_instituciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `equipos_instalacion_instituciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipos_instalacion_instituciones_final`
--

DROP TABLE IF EXISTS `equipos_instalacion_instituciones_final`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipos_instalacion_instituciones_final` (
  `Codigo_Institucion` varchar(5) DEFAULT NULL,
  `Modalidad` varchar(45) DEFAULT NULL,
  `Condicion` varchar(45) DEFAULT NULL,
  `Port_1_docente` int(11) DEFAULT '0',
  `Port_1_preeescolar` int(11) DEFAULT '0',
  `Port_1_estudiante` int(11) DEFAULT '0',
  `Port_2_estudiante` int(11) DEFAULT '0',
  `Servidor` int(11) DEFAULT '0',
  `Nas` int(11) DEFAULT '0',
  `Proyector` int(11) DEFAULT '0',
  `Impresora` int(11) DEFAULT '0',
  `Audifonos` int(11) DEFAULT '0',
  `Mouse` int(11) DEFAULT '0',
  `Candados` int(11) DEFAULT '0',
  `ConvertirdorPolarizado` int(11) DEFAULT '0',
  `Extensiones` int(11) DEFAULT '0',
  `Regletas` int(11) DEFAULT '0',
  `Maletin_proyector` int(11) DEFAULT '0',
  `Maletin_portatil` int(11) DEFAULT '0',
  `Router` int(11) DEFAULT '0',
  `Switch` int(11) DEFAULT '0',
  `ApInterno` int(11) DEFAULT '0',
  `ApExterno` int(11) DEFAULT '0',
  `Parlantes_1` int(11) DEFAULT '0',
  `Parlantes_2` int(11) DEFAULT '0',
  `Unidad_optica` int(11) DEFAULT '0',
  `Ups_1` int(11) DEFAULT NULL,
  `Ups_2` int(11) DEFAULT NULL,
  `Cargador_Ap` int(11) DEFAULT NULL,
  `Patch_blanco` int(11) DEFAULT NULL,
  `Patch_verde` int(11) DEFAULT NULL,
  `Cable_Hdmi` int(11) DEFAULT NULL,
  `Cable_vga` int(11) DEFAULT NULL,
  `Cable_usb` int(11) DEFAULT NULL,
  `Cartucho_tinta` int(11) DEFAULT NULL,
  `id_registro` int(11) unsigned zerofill NOT NULL,
  `fecha_registro` varchar(30) NOT NULL,
  `id_orden` int(8) unsigned zerofill NOT NULL DEFAULT '00000000',
  PRIMARY KEY (`id_registro`),
  KEY `Codigo_id` (`Codigo_Institucion`),
  KEY `orden_ibfk_idx` (`id_orden`),
  CONSTRAINT `Codigo_id` FOREIGN KEY (`Codigo_Institucion`) REFERENCES `instituciones` (`codigo`),
  CONSTRAINT `orden` FOREIGN KEY (`id_orden`) REFERENCES `acciones` (`Codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipos_instalacion_instituciones_final`
--

LOCK TABLES `equipos_instalacion_instituciones_final` WRITE;
/*!40000 ALTER TABLE `equipos_instalacion_instituciones_final` DISABLE KEYS */;
/*!40000 ALTER TABLE `equipos_instalacion_instituciones_final` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipos_reparacion`
--

DROP TABLE IF EXISTS `equipos_reparacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipos_reparacion` (
  `serie` varchar(30) NOT NULL,
  `placa` varchar(30) NOT NULL,
  `danos` varchar(250) NOT NULL,
  `id_estado` int(11) NOT NULL,
  PRIMARY KEY (`serie`,`placa`),
  KEY `placa_ibfk_idx` (`placa`),
  KEY `estado_ibfk_idx` (`id_estado`),
  CONSTRAINT `estado_ibfk` FOREIGN KEY (`id_estado`) REFERENCES `estados_equipos` (`id_estado`),
  CONSTRAINT `placa_ibfk` FOREIGN KEY (`placa`) REFERENCES `equipos` (`placa`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipos_reparacion`
--

LOCK TABLES `equipos_reparacion` WRITE;
/*!40000 ALTER TABLE `equipos_reparacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `equipos_reparacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estado_accion`
--

DROP TABLE IF EXISTS `estado_accion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estado_accion` (
  `accion` int(8) unsigned zerofill NOT NULL,
  `estado_accion` int(2) unsigned zerofill NOT NULL,
  PRIMARY KEY (`accion`),
  KEY `estado_accion_ibfk_2` (`estado_accion`),
  CONSTRAINT `estado_accion_ibfk_1` FOREIGN KEY (`accion`) REFERENCES `acciones` (`Codigo`),
  CONSTRAINT `estado_accion_ibfk_2` FOREIGN KEY (`estado_accion`) REFERENCES `ubicacion` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estado_accion`
--

LOCK TABLES `estado_accion` WRITE;
/*!40000 ALTER TABLE `estado_accion` DISABLE KEYS */;
INSERT INTO `estado_accion` VALUES (00001001,01);
/*!40000 ALTER TABLE `estado_accion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estado_orden_produccion`
--

DROP TABLE IF EXISTS `estado_orden_produccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estado_orden_produccion` (
  `id_estado_orden` int(8) unsigned zerofill NOT NULL,
  `estado` varchar(20) NOT NULL,
  PRIMARY KEY (`id_estado_orden`),
  KEY `orden_estado_idx` (`id_estado_orden`),
  CONSTRAINT `orden_estado` FOREIGN KEY (`id_estado_orden`) REFERENCES `acciones` (`Codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estado_orden_produccion`
--

LOCK TABLES `estado_orden_produccion` WRITE;
/*!40000 ALTER TABLE `estado_orden_produccion` DISABLE KEYS */;
/*!40000 ALTER TABLE `estado_orden_produccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estados_equipos`
--

DROP TABLE IF EXISTS `estados_equipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estados_equipos` (
  `id_estado` int(11) NOT NULL,
  `estado` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_estado`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estados_equipos`
--

LOCK TABLES `estados_equipos` WRITE;
/*!40000 ALTER TABLE `estados_equipos` DISABLE KEYS */;
INSERT INTO `estados_equipos` VALUES (1,'REPARADA'),(2,'MALA'),(3,'EN REVISION'),(4,'BUENA');
/*!40000 ALTER TABLE `estados_equipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instalaciones_cableado`
--

DROP TABLE IF EXISTS `instalaciones_cableado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instalaciones_cableado` (
  `codigo_institucion` varchar(5) NOT NULL,
  `cantidad_instalada` int(11) NOT NULL,
  `descripcion` varchar(500) DEFAULT NULL,
  `documento` varchar(250) DEFAULT NULL,
  `fecha_registro` varchar(50) NOT NULL,
  PRIMARY KEY (`codigo_institucion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instalaciones_cableado`
--

LOCK TABLES `instalaciones_cableado` WRITE;
/*!40000 ALTER TABLE `instalaciones_cableado` DISABLE KEYS */;
/*!40000 ALTER TABLE `instalaciones_cableado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instituciones`
--

DROP TABLE IF EXISTS `instituciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instituciones` (
  `Codigo` varchar(5) NOT NULL,
  `Centro_educativo` varchar(200) NOT NULL,
  PRIMARY KEY (`Codigo`,`Centro_educativo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instituciones`
--

LOCK TABLES `instituciones` WRITE;
/*!40000 ALTER TABLE `instituciones` DISABLE KEYS */;
INSERT INTO `instituciones` VALUES ('.4028','COLEGIO REDENTORISTA SAN ALFONSO'),('0001','SOLICITUDES PARA CASOS'),('0326','JN ESMERALDA OREAMUNO'),('0419','JN ROBERTO CANTILLANO VINDAS'),('0420','JN JARDINES DE TIBÁS'),('0448','JN JUAN RAFAEL MORA'),('0450','JN FLORA CHACÓN C.'),('0451','JN JUSTO A. FACIO'),('0452','JN LILIA RAMOS VALVERDE'),('0473','ESC. HERBERTH FARRER KNIGHTS'),('0486','JN COLONIA KENNEDY'),('0495','ESC. LA LAGUNA'),('0508','ESC. EL TIGRE'),('0520','ESC. CEIBA BAJA'),('0522','ESC. IEGB LA CRUZ'),('0537','ESC. BRAULIO ODIO HERRERA'),('0541','JN REPÚBLICA DE HAITÍ'),('0549','ESC. LINDA VISTA (0549)'),('0562','JN SOTERO GONZÁLEZ BARQUERO'),('0566','JN MARÍA RETANA SALAZAR'),('0569','JN SAN SEBASTIÁN'),('0574','JN MANUEL ORTUÑO BOUTÍN'),('0577','ESC. TIQUIRITOS'),('0581','ESC. LAS GRAVILIAS'),('0592','ESC. JESUS MORALES'),('0596','ESC. LUIS AGUILAR'),('0609','ESC. LOS ALTOS'),('0627','ESC. I.D.A. BIJAGUAL'),('0633','ESC. CONCEPCION'),('0635','ESC. CORTEZAL'),('0649','ESCUELA GAMALOTILLO'),('0677','ESC. MORADO'),('0683','ESC. ESTEBAN LORENZO'),('0686','ESC. QUEBRADA AZUL'),('0690','ESC. EL RODEO'),('0700','ESC. SAN RAFAEL'),('0717','ESC. MATA DE PLÁTANO'),('0726','ESC. TSENE DIKOL'),('0728','ESC. LA COLONIA'),('0740','ESC. EL GUAYACÁN'),('0748','ESC. SAN VICENTE (PUNTARENAS)'),('0765','ESC. ESCALERAS'),('0766','ESC. EL CAMPO'),('0767','ESC. SAN ISIDRO'),('0781','ESC. BOLAS'),('0808','ESC. BELLA VISTA'),('0816','ESC. EL VERGEL'),('0817','ESC. CONDORCILLO'),('0819','ESC. SANTA ELENA'),('0841','ESC. EL CEIBO'),('0851','ESC. GUANACASTE'),('0874','ESC. PALMITAL'),('0896','ESC. LINDA VISTA (0896)'),('0915','ESC. OLAN'),('0942','ESCUELA SAN RAFAEL'),('1033','ESC. CALDERÓN'),('1063','ESC. SIKEBATA'),('1188','JN REPÚBLICA DE GUATEMALA'),('1298','JN FELÍCITAS RAMÍREZ VEGA'),('1328','JN MANUEL BERNARDO GÓMEZ'),('1437','ESC. EL ROBLE'),('1449','ESCUELA LA VIRGEN'),('1463','ESC. POCOSOL'),('1487','ESC. MATAPALO'),('1494','ESC. CURIRE'),('1547','ESCUELA CRUCITAS'),('1591','ESCUELA PALENQUE MARGARITA'),('1591|','ESCUELA PALENQUE MARGARITA'),('1696','ESC. EL JARDIN'),('1705','ESC. SAN FERNANDO'),('1804','JN CARLOS J. PERALTA'),('1817','JN JESÚS JIMÉNEZ ZAMORA'),('1823','ESCUELA LLANO BONITO'),('1919','JN CONEJITO FELÍZ'),('1964','ESCUELA ALTO ALMIRANTE'),('1966','ESCUELA TSINICLARI'),('1976','ESC. JAK TAIN'),('1978','ESC. BAYEIÑAK'),('1980','ESC. KSARIÑAK'),('1992','ESC. KOIYABA'),('2056','ESCUELA JARDÍN DE NIÑOS DE TURRIALBA'),('2141','JN PEDRO MURILLO PÉREZ'),('2189','JN. RAFAEL MOYA M.'),('2201','JN ESTADOS UNIDOS DE AMÉRICA'),('2215','JN JUAN MORA FERNÁNDEZ'),('2230','JN CLETO GONZÁLEZ VÍQUEZ'),('2270','JN LIBERIA'),('2480','ESC. GIL GONZALEZ'),('2497','ESCUELA BAJO LOS INDIOS'),('2629','ESC. PARAISO'),('2717','ESC. ISLA DE CEDROS'),('2760','ESC. ISLA DE CHIRA'),('2878','JN ESPARZA'),('2885','JN FRAY CASIANO DE MADRID'),('2920','ESCUELA ALTAMIRA'),('2934','ESCUELA NGOBEGUE'),('2947','ESC. BAJO DE LOS INDIOS'),('2953','ESC. PUNTA VENEGAS'),('2958','ESC. LA BALSA'),('2960','ESC. KOGORIBTDA'),('2977','ESC. MIRAMAR'),('3033','ESC. SAN JOSECITO'),('3050','ESC. EL REFUGIO'),('3089','ESC. IRIGUI'),('3125','ESC. SAN MIGUEL'),('3138','ESC. RIO ESQUINAS'),('3260','ESC. PUESTO LA PLAYA'),('3266','ESC. GAVILÁN CANTA'),('3277','ESC. EL PORVENIR'),('3304','ESCUELA BAMBU'),('3330','ESC. FINCA OCHO'),('3348','ESC. MELERUK'),('3349','ESC. SAN VICENTE (LIMÓN)'),('3359','ESC. BAJO COÉN'),('3395','ESCUELA BOCA COHEN'),('3409','ESCUELA AKBERIE'),('3445','ESC. KËKÖLDI'),('3447','ESC. SOKI'),('3456','ESC. SAN MIGUEL'),('3489','ESCUELA SEPECUE (3489)'),('3500','ESC. YORKIN'),('3518','ESC. SHUABB'),('3526','ESC. ASUNCION'),('3549','ESC. RÍO SARDINAS'),('3556','ESC. BARRA DEL CORODADO SUR'),('3747','ESC. ISLA DAMAS NUMERO N°2'),('3789','ESC. SAN CRITOBAL'),('3938','COLEGIO SUPERIOR DE SEÑORITAS'),('3941','LICEO SAN JOSE LAB1'),('3941B','LICEO SAN JOSE LAB2'),('3945','LICEO NAPOLEÓN QUESADA SALAZAR'),('3949','LICEO DE MORAVIA'),('3952','LICEO DE ESCAZÚ LAB1'),('3952B','LICEO DE ESCAZÚ LAB2'),('3956','LICEO EDGAR CERVANTES VILLALTA'),('3959','LICEO DE SANTA ANA LAB1'),('3959B','LICEO DE SANTA ANA LAB2'),('3960','LICEO DE CURRIDABAT'),('3971','UP CUATRO REINAS'),('3973','LICEO EXPERIMENTAL BILINGÜE LA TRINIDAD'),('3979','LICEO TEODORO PICADO'),('3982','LICEO MONSEÑOR RUBÉN ODIO HERRERA'),('3983','LICEO DE CALLE FALLAS'),('3988','LICEO DE SAN ANTONIO'),('3991','LICEO DE SAN GABRIEL'),('3993','LICEO DE SABANILLAS'),('3995','LICEO JOAQUÍN GUTIÉRREZ MANGEL'),('3996','LICEO DE CUIDAD COLÓN'),('3997','LICEO DE PURISCAL'),('4000','UP DR. RAFAEL ÁNGEL CALDERÓN'),('4003','LICEO EL CARMEN DE BIOLLEY'),('4004','LICEO DE BORUCA'),('4006','LICEO YOLANDA OREAMUNO UNGER'),('4009','LICEO UNESCO LAB1'),('4009B','LICEO UNESCO LAB2'),('4014','LICEO SAN ROQUE'),('4019','LICEO DE ATENAS MARTHA MIRAMELL LAB1'),('4019B','LICEO DE ATENAS MARTHA MIRAMELL LAB2'),('4020','LICEO LEÓN CORTÉS CASTRO LAB1'),('4020B','LICEO LEÓN CORTÉS CASTRO LAB2'),('4021','LICEO DE POÁS'),('4022','COLEGIO JOSE RAMIREZ LAB1'),('4023','COLEGIO EL CARMEN DE ALAJUELA'),('4027','LICEO SAN RAFAEL'),('4028','COLEGIO REDENTORISTA SAN ALFONSO'),('4030','LICEO EXPERIMETAL BILINGÜE DE GRECIA'),('4032','LICEO NUESTRA SEÑORA DE LOS ANGELES'),('4033','INSTITUTO SUPERIOR JULIO ACOSTA GARCIA LAB1'),('4033B','INSTITUTO SUPERIOR JULIO ACOSTA GARCIA LAB2'),('4034','COLEGIO EXPERIMENTAL BILINGÜE DE PALMARES'),('4034B','COLEGIO EXPERIMENTAL BILINGÜE DE PALMARES LAB2'),('4035','COLEGIO DE NARANJO'),('4036','COLEGIO VALLE AZUL'),('4039','COLEGIO DR. RICARDO MORENO CAÑAS'),('4040','LICEO DE ALFARO RUIZ'),('4041','LICEO SUCRE'),('4043','LICEO DE PAVÓN'),('4047','LICEO DE CHACHAGUA'),('4048','LICEO ENRIQUE GUIER SÁENZ'),('4049','LICEO MANUEL E. RODRÍGUEZ'),('4050','LICEO VICENTE LACHNER SANDOVAL'),('4051','COLEGIO SAN LUIS GONZAGA LAB1'),('4051B','COLEGIO SAN LUIS GONZAGA LAB2'),('4052','LICEO DE PARAISO LAB1'),('4052B','LICEO DE PARAISO LAB2'),('4054','COLEGIO SERÁFICO SAN FRANCISCO'),('4056','UP RAFAEL HERNANDEZ MADRIZ'),('4057','LICEO DE TARRAZÚ'),('4058','LICEO DE COT FRANCISCO J. ORLICH'),('4060','LICEO DANIEL ODUBER (SAN FRANCISCO)'),('4061','LICEO DE CORRALILLO'),('4065','LICEO INGENIERO ALEJANDRO QUESADA RAMIREZ'),('4066','LICEO EXPERIMENTAL JOSÉ FIGUERES FERRER LAB1'),('4066B','LICEO EXPERIMENTAL JOSÉ FIGUERES FERRER LAB2'),('4067','LICEO BRAULIO CARRILLO COLINA'),('4070','LICEO HERNAN VARGAS RAMIREZ'),('4073','EXPERIMENTAL BILINGÜE DE TURRIALBA'),('4074','LICEO TRES EQUIS'),('4077','LICEO INGENIERO SAMUEL SAENZ FLORES'),('4078','LICEO DE HEREDIA LAB1'),('4078B','LICEO DE HEREDIA LAB2'),('4079','LICEO REGIONAL DE FLORES'),('4083','CONSERVATORIO CASTELLA'),('4084','LICEO SANTA BÁRBARA'),('4085','LICEO INGENIERO MANUEL BENAVIDES RODRIGUEZ LAB1'),('4085B','LICEO INGENIERO MANUEL BENAVIDES RODRIGUEZ LAB2'),('4086','COLEGIO DE SAN ISIDRO LAB1'),('4086B','COLEGIO DE SAN ISIDRO LAB2'),('4087','LICEO EXPERIMENTAL BILINGÜE DE BELEN'),('4090','LICEO DE SANTO DOMINGO'),('4090B','LICEO DE SANTO DOMINGO LAB2'),('4091','COLEGIO NOCTURNO DE RÍO FRÍO'),('4096','COLEGIO FELIPE PÉREZ PEREZ'),('4098','COLEGIO CAÑAS DULCES'),('4101','COLEGIO DE BAGACES'),('4102','INSTITUTO DE GUANACCASTE LAB1'),('4102B','INSTITUTO DE GUANACASTE'),('4103','LICEO LABORATORIO DE LIBERIA'),('4107','LICEO EXPERIMENTAL BILINGÜE DE SANTA CRUZ'),('4110','LICEO MAURILIO ALVARADO VARGAS'),('4111','LICEO MIGUEL ARAYA VENEGAS'),('4111B','LICEO MIGUEL ARAYA VENEGAS LAB2'),('4112','LICEO SAN RAFAEL'),('4113','LICEO DE COLORADO'),('4114','LICEO EXPERIMENTAL BILINGÜE NUEVO ARENAL'),('4118','LICEO MIRAMAR'),('4119','LICEO DE CHACARITA'),('4123','LICEO ACADEMICO DE COMTE'),('4125','LICEO DE CIUDAD NEILLY'),('4130','LICEO RODRIGO SOLANO QUIROS'),('4139','LICEO DE POCORA'),('4144','LICEO ACADEMICO DE JIMÉNEZ'),('4145','COLEGIO ACADEMICO LA RITA'),('4148','LICEO AGUAS CLARAS'),('4149','LICEO KATIRA'),('4150','LICEO DE BIJAGUA'),('4198','CTP DE NICOYA'),('4207','CTP DE ABANGARES'),('4208','CTP DE JICARAL'),('4215','CTP UMBERTO MELLONI C.'),('4218','CTP DE CORREDORES'),('4225','COLEGIO DEPORTIVO DE LIMÓN'),('4227','CTP DE POCOCÍ LAB1'),('4227B','CTP DE POCOCÍ LAB2'),('4869','LICEO NOCTURNO DE LIBERIA'),('4913','LICEO DOS RIOS'),('4918','JN GENERAL MANUEL BELGRANO'),('4965','JN JUAN VÁSQUEZ DE CORONADO'),('5005','JN MONSEÑOR LUIS LEIPOLD'),('5038','ESC. SARDINA'),('5080','COLEGIO JORGE VOLIO JIMÉNEZ'),('5134','COLEGIO SANTA EDUVIGES'),('5151','LICEO BUENOS AIRES DE POCOSOL'),('5166','LICEO FINCA ALAJUELA'),('5178','LICEO LAS DELICIAS'),('5300','LICEO LAS ESPERANZAS'),('5303','LICEO CAPITÁN MANUEL QUIRÓS'),('5304','LICEO NICOLÁS AGUILAR MURILLO'),('5305','ESC. TSIPIRIÑAK'),('5306','ESC. NIMARI TÄWÄ'),('5308','ESC. KARKO'),('5309','ESC. YÖLDI KICHA'),('5310','ESC. MANZANILLO'),('5311','ESC. SHUKËBACHARI'),('5313','ESC. SHIKIARI TÄWÄ'),('5316','LICEO CAPITÁN RAMÓN RIVAS'),('5323','JN DULCE NOMBRE'),('5345','JN SIMÓN BOLÍVAR'),('5349','JN EL ROBLE'),('5450','JN REPÚBLICA DE COLOMBIA'),('5522','ESC. CARTAGO'),('5523','ESC. SANTA MARÍA'),('5532','LICEO BOCA DE ARENAL'),('5533','COLEGIO EXPERIMENTAL BILINGÜE DE LOS ANGELES'),('5535','LICEO DE GUARDIA'),('5543','JN JUAN E. PESTALOZZI'),('5550','ESC. UKA TIPËY'),('5577','LICEO EL SAÍNO'),('5581','LICEO RURAL SAN RAFAEL DE CABAGRA'),('5583','LICEO CUATRO BOCAS'),('5586','LICEO EL PARAISO'),('5641','JN LAS LETRAS'),('5643','JN JOSÉ J. SALAS PÉREZ'),('5645','LICEO RURAL BEBEDERO'),('5653','ESC. TKAK-RI'),('5679','COLEGIO CANDELARIA'),('5694','JN SARCHÍ NORTE'),('5695','ESC. SËLIKÖ'),('5697','ESC. BUKERI'),('5698','ESC. TSIRBÄKLÄ'),('5699','ESC. TKANYÄKÄ'),('5704','ESC. GUAYABA YÄKÄ'),('5707','LICEO COSTA DE PÁJAROS'),('5728','LICEO SANTA MARTA'),('5735','UP LA VALENCIA'),('5800','ESC. DIKËKLÄRIÑAK'),('5802','ESC. KJALARI'),('5808','JN FEDERICO SALAS CARVAJAL'),('5811','JN JOSEFINA LÓPEZ BONILLA'),('5812','ESC. JAKUE'),('5820','LICEO DE TÉRRABA'),('5861','ESC. JAMARI TÄWÄ'),('5864','ESC. TOLOK KICHA'),('5865','ESC. MARIARIBUTA'),('5873','LICEO DE BARBACOAS'),('5874','LICEO AMBIENTALISTA HORQUETAS'),('5877','ESC. JALA KICHA'),('5979','LICEO BILINGÜE SAN NICOLAS DE TOLENTINO'),('5988','LICEO QUEBRADA GANADO'),('5989','ESC. SWAKBLI'),('5996','LICEO EXPERIMENTAL BILINGÜE DE SAN RAMÓN'),('6000','LICEO CUATRO ESQUINAS'),('6020','LICEO DEPORTIVO DE GRECIA'),('6023','JN PRIMO VARGAS VALVERDE'),('6024','ESC. WAWET'),('6045','LICEO RAUL YORQUIN'),('6046','LICEO RURAL LA CASONA'),('6073','CTP DE TURRUBARES'),('6095','JN FINCA LA CAJA'),('6112','LICEO FINCA NARANJO'),('6115','LICEO SAN RAFAEL'),('6137','LICEO OCCIDENTAL'),('6139','ESC. CHORRERAS'),('6154','ESC. KONOBATA'),('6156','LICEO ITALO COSTARRICENSE'),('6216','LICEO LLANO LOS ANGELES'),('6223','ESC. LOS ÁNGELES'),('6275','ESC. BOCA BRAVA'),('6372','LICEO TIERRA BLANCA'),('6374','ESC. BAKÖM DI'),('6376','LICEO SAN JOSE DEL RIO'),('6384','LICEO DE TOBOSI'),('6402','ESC. JUITÖ'),('6403','ESC. KSARABATA'),('6404','ESC. KONYÖÚ'),('6405','ESC. AKOM'),('6407','LICEO RURAL KJAKUO SULO'),('6505','CTP PALMICHAL'),('6512','LICEO SANTISIMA TRINIDAD'),('6524','CTP SAN ISIDRO DE HEREDIA'),('6526','CTP MERCEDES NORTE'),('6535','CTP CALLE ZAMORA'),('6543','ESC. BLÚJURIÑAK'),('6581','CTP DE OROSI'),('6584','CTP LAS PALMITAS'),('6666','COLEGIO SAN FRANCISCO DE LA PALMERA'),('6676','COLEGIO DE LEPANTO'),('6714','LICEO NUEVO DE PURISCAL'),('6716','LICEO DE GUARARI'),('6717','COLEGIO DE SIQUIRRES'),('6742','LICEO DE SANTIAGO'),('6796','COLEGIO LA CRUZ'),('747','ESCUELA LA SABANA');
/*!40000 ALTER TABLE `instituciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lista_inventarios`
--

DROP TABLE IF EXISTS `lista_inventarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lista_inventarios` (
  `Serie` varchar(30) NOT NULL,
  `Placa` varchar(30) NOT NULL,
  `Numero_Estacion` int(11) DEFAULT NULL,
  `Institucion` varchar(150) DEFAULT NULL,
  `Modalidad` varchar(50) DEFAULT NULL,
  `Accion` int(8) unsigned zerofill NOT NULL,
  PRIMARY KEY (`Accion`,`Serie`,`Placa`),
  KEY `lista_inventario_ibfk_1` (`Accion`),
  KEY `placa_ibfk_2_idx` (`Placa`),
  CONSTRAINT `lista_inventario_ibfk_1` FOREIGN KEY (`Accion`) REFERENCES `acciones` (`Codigo`),
  CONSTRAINT `placa_ibfk_2` FOREIGN KEY (`Placa`) REFERENCES `equipos` (`placa`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lista_inventarios`
--

LOCK TABLES `lista_inventarios` WRITE;
/*!40000 ALTER TABLE `lista_inventarios` DISABLE KEYS */;
INSERT INTO `lista_inventarios` VALUES ('SMP207SRJ','482082',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP209FPZ','482066',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BW3L','482094',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWXX','482018',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWXZ','482044',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWY4','482031',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWY5','482088',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWY7','482045',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWYB','482055',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWYF','482090',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWYJ','482089',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWZ0','482056',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWZ1','482048',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWZF','482050',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWZQ','482057',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BWZW','482081',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX03','482014',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX04','482096',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX06','482046',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX0A','482047',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX0K','482093',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX0X','482080',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX14','482092',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX15','482078',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX19','482067',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX1B','482065',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX1V','482083',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX1X','482043',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX23','482034',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX2D','482040',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BX7S','482103',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BXB2','482079',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZ7Z','482029',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZ8H','482017',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZ8L','482023',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZ8R','482025',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZ8T','482041',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZ94','482016',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZ98','482036',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZ9C','482049',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZ9M','482024',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZ9Q','482030',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZ9Y','482035',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZAA','402019',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZAK','482039',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZB1','482037',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZB4','482015',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZBF','482042',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZBP','482038',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZG1','482073',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZHF','482102',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZHQ','482068',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZJN','482072',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZK6','482063',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZKT','482069',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZKV','482076',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZL3','482104',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZLC','482101',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZLV','482099',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZMF','482059',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZMK','482071',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20BZML','482100',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C1JA','482033',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C1JM','482032',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C1JV','482020',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C1JY','482028',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C1KH','482026',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C1KN','482022',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C1LH','482021',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C1LJ','482013',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C2W5','482091',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C3LQ','482064',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C3LV','482052',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C3N6','482054',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C3N9','482058',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C3NE','482053',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C3P8','482051',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C3VB','482027',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C3X4','482087',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C70S','482060',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C70W','482070',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C71C','482074',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C71M','482098',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C71S','482061',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C71W','482077',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C71Y','482097',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C727','482084',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C72B','482062',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C72D','482086',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C72J','482085',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20C72K','482075',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001),('SMP20CDW7','482095',0,'INGRESO EQUIPOS NUEVOS','N/A',00001001);
/*!40000 ALTER TABLE `lista_inventarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lista_inventarios_materiales`
--

DROP TABLE IF EXISTS `lista_inventarios_materiales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lista_inventarios_materiales` (
  `codigo_material` varchar(50) NOT NULL,
  `cantidad_unidad` int(11) NOT NULL,
  `tecnico` int(2) unsigned zerofill DEFAULT NULL,
  `codigo_orden` int(8) unsigned zerofill NOT NULL,
  PRIMARY KEY (`codigo_material`,`codigo_orden`),
  KEY `codigo_orden_idx` (`codigo_orden`),
  KEY `id_tecnico_idx` (`tecnico`),
  CONSTRAINT `codigo_material_ibfk` FOREIGN KEY (`codigo_material`) REFERENCES `materiales_unidades` (`codigo_material`),
  CONSTRAINT `codigo_orden` FOREIGN KEY (`codigo_orden`) REFERENCES `ordenes_materiales` (`codigo`),
  CONSTRAINT `id_tecnico` FOREIGN KEY (`tecnico`) REFERENCES `tecnicos` (`idtecnicos`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lista_inventarios_materiales`
--

LOCK TABLES `lista_inventarios_materiales` WRITE;
/*!40000 ALTER TABLE `lista_inventarios_materiales` DISABLE KEYS */;
INSERT INTO `lista_inventarios_materiales` VALUES ('140-119601',50,03,00001014),('140-119601',50,03,00001030),('140-17303',1000,03,00001017),('140-17303',1000,03,00001018),('140-17303',1000,03,00001023),('140-17303',850,04,00001031),('140-322673',500,03,00001029),('140-322674',500,03,00001029),('140-35951',1000,03,00001019),('140-35951',1000,03,00001020),('140-35951',1000,04,00001025),('140-35951',1000,03,00001026),('140-35951',850,04,00001031),('140-41001',10,03,00001014),('140-41001',5,04,00001031),('140-4120089',40,03,00001015),('140-4120089',5,04,00001031),('140-420033',10,03,00001014),('140-420033',5,04,00001031),('140-46665',1000,03,00001015),('140-46665',1000,03,00001016),('140-46729',1000,03,00001015),('140-46729',550,04,00001031),('140-46794',1000,03,00001015),('140-46794',1000,03,00001016),('140-46794',500,04,00001031),('140-47708',1000,03,00001020),('140-47708',850,04,00001031),('140-50075P',500,03,00001002),('140-50848',500,03,00001002),('140-50852',500,03,00001002),('140-50852',500,04,00001031),('140-50854',500,03,00001001),('140-50854',500,04,00001031),('140-50858',1000,03,00001001),('140-50858',500,04,00001031),('140-50859',500,03,00001001),('140-50859',500,04,00001031),('140-50865',1000,03,00001001),('140-50865',500,04,00001031),('140-50866',500,03,00001001),('140-7007303',60,03,00001028),('140-7016615',60,03,00001028),('140-7017603',40,03,00001028),('140-7029264',40,03,00001028),('140-7133158',30,03,00001028),('140-ARA20PL21',500,03,00001002),('140-ARA20PL21',500,04,00001031),('140-ARA20PL22',500,03,00001002),('140-ARA20PL22',500,04,00001031),('140-ARA50PR20',500,03,00001002),('140-ARA50PR20',500,04,00001031),('140-ARA50PR21',500,03,00001002),('140-ARA50PR21',500,04,00001031),('140-CONE3/4',1000,03,00001015),('140-CONE3/4',500,04,00001031),('140-CRPVC1',40,03,00001028),('140-PCGU6ALZB',200,03,00001027),('140-PCGU6ALZB',5,04,00001031),('140-SPANDER7',1000,03,00001002),('140-SPANDER7',500,04,00001004),('140-SPANDER7',1000,04,00001031),('140-SPANDER8',1000,03,00001002),('140-SPANDER8',500,03,00001003),('140-SPANDER8',1000,04,00001031),('140-SPANDERM1',500,03,00001009),('140-SPANDERM1',500,04,00001031),('140-SPANDERM1',1,04,00001032),('140-SPANDERM1',1,03,00001033),('140-SPGRGY',1000,03,00001013),('140-SPGRGY',500,04,00001031),('140-TGPB2',500,03,00001002),('140-TGPB2',500,04,00001031),('140-TGPC2',500,03,00001002),('140-TGPC2',500,04,00001031),('140-UEMT3/4',1000,03,00001021),('140-UEMT3/4',187,03,00001022),('140-UEMT3/4',850,04,00001031);
/*!40000 ALTER TABLE `lista_inventarios_materiales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materiales`
--

DROP TABLE IF EXISTS `materiales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `materiales` (
  `codigo` varchar(50) NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materiales`
--

LOCK TABLES `materiales` WRITE;
/*!40000 ALTER TABLE `materiales` DISABLE KEYS */;
INSERT INTO `materiales` VALUES ('140-119601','Riel Canal Strut 13/16x1-5/8'),('140-13529P','Clavos de Impacto 1/2'),('140-17303','Tubo 3/4 EMT certificado'),('140-1CRM','Caja de rectangular, 3/4, 3 huecos, p/interperie, metalica'),('140-322673','Tornillo Gypson Punta Broca Frijolillo '),('140-322674','Tornillo Gypsun Punta Fina Frijolillo 7/16'),('140-35951','Conectores 3/4, EMT'),('140-41001','Aceite Penetrante W40\r\n'),('140-4120089','Pegamento PVC resistente al agua'),('140-420033','Duretan Gris'),('140-42944010','Tuerca Hexagonal GALV 3/8'),('140-42944020','Tornillo K-Lath Punta Fina 1/2'),('140-42944030','Tornillo K-Lath Punta Broca 1/2'),('140-45039','Tubo 3/4 conduit, tipo A, Cedula 40'),('140-45119','Curvas 3/4, Cedula 40'),('140-45120','Uniones 3/4, Cedula 40'),('140-46665','Tubo 3/4 conduit, tipo A, Cedula 18'),('140-46729','Curvas 3/4, Cedula 18'),('140-46794','Uniones 3/4, Cedula 18'),('140-47708','Gaza de 3/4\"EMT-1 Oreja'),('140-47714','Gaza de 3/4\"EMT-2 Orejas'),('140-47725','Tapa ciega rectangular interperie, metalica'),('140-50075P','TORNILLO GYPSUM P.B.      6 X 1- 1/2 (PAQ 100 UND)'),('140-50837','TORNILLO Frijolito punta corriente 3/4'),('140-50838','TORNILLO Frijolito punta Corriente 1'),('140-50840','TORNILLO Frijolito punta broca 3/4'),('140-50843','Tornillo Gypsum 1\" Punta Broca'),('140-50845','Tornillo Gypsum 1 1/2 Punta Broca'),('140-50848','Tornillo Carroceria Galv 3/8x5'),('140-50849','tornillo Gypsum PC.  6X   3/4                                            '),('140-50852','Tornillo Gypsum 1 1/2 Punta Corriente'),('140-50854','Tornillo para Techo Punta Broca 1,5'),('140-50858','Tornillo para Techo Punta Broca 1'),('140-50859','Tornillo para Techo Punta Broca 2'),('140-50864','Tornillo para Techo Punta Corriente 1'),('140-50865','Tornillo para Techo Punta Corriente 1,5'),('140-50866','Tornillo para Techo punta fina 3'),('140-7007303','Tubo Biex Metalico con Forro 3/4'),('140-7016615','Conector Biex Recto con Forro 3/4'),('140-7017603','Caja Cuadrada EMT 1/2x3/4x2.1/8'),('140-7029264','Placa Cuadrada EMT Hueco UL '),('140-7133158','Caja Para Canaleta '),('140-726454','Canaleta 1-1/4\" X 3/4\" X 6\" Blanca con adhesivo'),('140-ARA20PL21','Arandela Plana Galv 3/8'),('140-ARA20PL22','Arandela Plana Galv 1/2'),('140-ARA50PR20','Arandela de Presion 3/8'),('140-ARA50PR21','Arandela de Presion 1/2'),('140-AW131NXT03','Puntos RJ45, Categoria 6A'),('140-AW160NXT01','Tapas de 1 para puntos de red'),('140-AW160NXT02','Tapas de 2 para puntos de red'),('140-AW160NXT50','MODULO ciego para tapas de punto de red'),('140-BASEEXT','bases externas'),('140-BASEINT','bases internas'),('140-CASU4X2','Cajetin Superficial 4\"X2\" Profunda Blanca'),('140-CB1413','BANDEJA NEWLINK 19.7 ILBS'),('140-CONE3/4','Conectores 3/4 PVC'),('140-CRPVC1','Cajas rectangulares PVC'),('140-LG638141','Angulo Interno 3/4'),('140-LG638142','Angulo Externo 3/4'),('140-LG638143','Angulo Plano 3/4'),('140-LG638145','Tapa Final'),('140-LG638146','Union de canaleta 3/4'),('140-LG638154','TEE de canaleta 3/4'),('140-LTK562','CARRUCHA DE CABLE UTP INTEMPERI CON MENSAJERO'),('140-PCGU6ALZB','CARRUCHA Cable Categoria 6A'),('140-SPANDER7','Spander #7'),('140-SPANDER8','Spander #8'),('140-SPANDERM1','Spander Mariposa (Plastico)'),('140-SPGRGY','Spander Gypsum Grande Plus'),('140-TFPB1','TORNILLO Frijolito punta broca 1'),('140-TGPB2','Tornillo Gypsum 2\" Punta Broca'),('140-TGPC1','Tornillo Gypsum 1\" Punta Corriente'),('140-TGPC2','Tornillo Gypsum 2\" Punta Corriente'),('140-TORKLATH20','Tornillo K-Lath Punta Fina 1/2'),('140-TORKLATH21','Tornillo K-Lath Punta Broca 1/2'),('140-TPCM2','Tapa ciega rectangular, metalica'),('140-TUERKHEX20','Tuerca Hexagonal Galv 3/8'),('140-UEMT3/4','Uniones 3/4, EMT');
/*!40000 ALTER TABLE `materiales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `materiales_en_inventario`
--

DROP TABLE IF EXISTS `materiales_en_inventario`;
/*!50001 DROP VIEW IF EXISTS `materiales_en_inventario`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `materiales_en_inventario` AS SELECT 
 1 AS `codigo_material`,
 1 AS `descripcion`,
 1 AS `cantidad_stock`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `materiales_unidades`
--

DROP TABLE IF EXISTS `materiales_unidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `materiales_unidades` (
  `codigo_material` varchar(50) NOT NULL,
  `cantidad_stock` int(11) NOT NULL,
  PRIMARY KEY (`codigo_material`),
  KEY `codigo_material_ibfk1_idx` (`codigo_material`),
  CONSTRAINT `codigo_material_ibfk1` FOREIGN KEY (`codigo_material`) REFERENCES `materiales` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materiales_unidades`
--

LOCK TABLES `materiales_unidades` WRITE;
/*!40000 ALTER TABLE `materiales_unidades` DISABLE KEYS */;
INSERT INTO `materiales_unidades` VALUES ('140-119601',100),('140-17303',2150),('140-322673',500),('140-322674',500),('140-35951',3150),('140-41001',5),('140-4120089',35),('140-420033',5),('140-46665',2000),('140-46729',450),('140-46794',1500),('140-47708',1150),('140-50075P',500),('140-50848',500),('140-50852',0),('140-50854',0),('140-50858',500),('140-50859',0),('140-50865',500),('140-50866',500),('140-7007303',60),('140-7016615',60),('140-7017603',40),('140-7029264',40),('140-7133158',30),('140-ARA20PL21',0),('140-ARA20PL22',0),('140-ARA50PR20',0),('140-ARA50PR21',0),('140-CONE3/4',500),('140-CRPVC1',40),('140-PCGU6ALZB',195),('140-SPANDER7',500),('140-SPANDER8',500),('140-SPANDERM1',500),('140-SPGRGY',500),('140-TGPB2',0),('140-TGPC2',0),('140-UEMT3/4',2337);
/*!40000 ALTER TABLE `materiales_unidades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modelos_equipos`
--

DROP TABLE IF EXISTS `modelos_equipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `modelos_equipos` (
  `codigo_modelo` int(3) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `marca` varchar(30) NOT NULL,
  `modelo` varchar(50) DEFAULT NULL,
  `id_tipo` varchar(15) NOT NULL,
  PRIMARY KEY (`codigo_modelo`),
  KEY `id_tipo` (`id_tipo`),
  CONSTRAINT `modelos_equipos_ibfk_1` FOREIGN KEY (`id_tipo`) REFERENCES `tipos_equipos` (`id_tipo`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modelos_equipos`
--

LOCK TABLES `modelos_equipos` WRITE;
/*!40000 ALTER TABLE `modelos_equipos` DISABLE KEYS */;
INSERT INTO `modelos_equipos` VALUES (001,'LENOVO','LN-V145-14AST-4G','PC'),(002,'LENOVO','LN-V145-14AST-8G','PC'),(003,'CASIO','XJF10X','PROY'),(004,'CISCO','RV320-K9-NA','RT'),(005,'DELL','POWEREDGE-T440','SER'),(006,'DELL','L3-BASIC-X1026P','SW'),(007,'EPSON','IJ-L120','IMP'),(008,'FORZA SMART','SL-1001UL','UPS_TI_1'),(009,'FORZA SMART','SL-401UL','UPS_TI_2'),(010,'GENIUS','SP-HF800A','PAR_TI_2'),(011,'KLIP XTREME','KWS-616','PAR_TI_1'),(012,'LG','GP65NB60','UNI_OP'),(013,'MERAKI','MR20','API'),(014,'MERAKI','MR70','APE'),(015,'SYNOLOGY','DS1618','NAS'),(016,'HP','2LB19A','IMP'),(017,'CASIO','XJF11X','PROY'),(018,'Lenovo','E41-55','PC');
/*!40000 ALTER TABLE `modelos_equipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `nueva_orden`
--

DROP TABLE IF EXISTS `nueva_orden`;
/*!50001 DROP VIEW IF EXISTS `nueva_orden`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `nueva_orden` AS SELECT 
 1 AS `Codigo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `nueva_orden_materiales`
--

DROP TABLE IF EXISTS `nueva_orden_materiales`;
/*!50001 DROP VIEW IF EXISTS `nueva_orden_materiales`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `nueva_orden_materiales` AS SELECT 
 1 AS `Codigo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `nuevo_registro_pedido`
--

DROP TABLE IF EXISTS `nuevo_registro_pedido`;
/*!50001 DROP VIEW IF EXISTS `nuevo_registro_pedido`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `nuevo_registro_pedido` AS SELECT 
 1 AS `Codigo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `obtener_ordenes_enproceso`
--

DROP TABLE IF EXISTS `obtener_ordenes_enproceso`;
/*!50001 DROP VIEW IF EXISTS `obtener_ordenes_enproceso`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `obtener_ordenes_enproceso` AS SELECT 
 1 AS `Numero Orden`,
 1 AS `Descripcion`,
 1 AS `Estado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `obtener_ordenes_pendientes`
--

DROP TABLE IF EXISTS `obtener_ordenes_pendientes`;
/*!50001 DROP VIEW IF EXISTS `obtener_ordenes_pendientes`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `obtener_ordenes_pendientes` AS SELECT 
 1 AS `Numero Orden`,
 1 AS `Descripcion`,
 1 AS `Estado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `obtener_tecnicos`
--

DROP TABLE IF EXISTS `obtener_tecnicos`;
/*!50001 DROP VIEW IF EXISTS `obtener_tecnicos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `obtener_tecnicos` AS SELECT 
 1 AS `nombre`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `ordenes_materiales`
--

DROP TABLE IF EXISTS `ordenes_materiales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ordenes_materiales` (
  `codigo` int(8) unsigned zerofill NOT NULL,
  `descripcion` varchar(150) NOT NULL,
  `fecha` datetime NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordenes_materiales`
--

LOCK TABLES `ordenes_materiales` WRITE;
/*!40000 ALTER TABLE `ordenes_materiales` DISABLE KEYS */;
INSERT INTO `ordenes_materiales` VALUES (00001000,'INGRESO COMPRA DE MATERIALES','2020-01-06 20:48:17'),(00001001,'INGRESO COMPRA DE MATERIALES','2021-10-04 07:32:24'),(00001002,'INGRESO COMPRA DE MATERIALES PARA CARTEL 2020 PROV TORCASA','2021-10-04 08:52:57'),(00001003,'INGRESO COMPRA DE MATERIALES PROYECTO FOD 2020 MATERIALES PROV TORCASA','2021-10-04 08:58:50'),(00001004,'ORDEN DE SALIDA PEDIDOS DE MATERIALES DE LOS TECNICOS POR ERROR DE INGRESO ','2021-10-04 08:59:43'),(00001005,'INGRESO COMPRA DE MATERIALES PROYECTO FOD 2020 PROV TORCASA','2021-10-04 09:08:23'),(00001006,'INGRESO COMPRA DE MATERIALES','2021-10-04 09:09:13'),(00001007,'INGRESO COMPRA DE MATERIALES PROYECTO FOD 2020 TORCASA ','2021-10-04 10:38:40'),(00001008,'INGRESO COMPRA DE MATERIALES','2021-10-04 10:50:33'),(00001009,'INGRESO COMPRA DE MATERIALES','2021-10-04 10:54:35'),(00001010,'INGRESO COMPRA DE MATERIALES','2021-10-04 10:58:15'),(00001011,'INGRESO COMPRA DE MATERIALES','2021-10-04 10:59:39'),(00001012,'INGRESO COMPRA DE MATERIALES','2021-10-04 11:51:17'),(00001013,'INGRESO COMPRA DE MATERIALES','2021-10-04 11:58:45'),(00001014,'INGRESO COMPRA DE MATERIALES','2021-10-04 12:17:33'),(00001015,'INGRESO COMPRA DE MATERIALES','2021-10-04 16:00:34'),(00001016,'INGRESO COMPRA DE MATERIALES','2021-10-04 16:01:56'),(00001017,'INGRESO COMPRA DE MATERIALES','2021-10-05 09:12:15'),(00001018,'INGRESO COMPRA DE MATERIALES','2021-10-05 09:13:07'),(00001019,'INGRESO COMPRA DE MATERIALES','2021-10-05 09:17:21'),(00001020,'INGRESO COMPRA DE MATERIALES','2021-10-05 09:18:46'),(00001021,'INGRESO COMPRA DE MATERIALES','2021-10-05 09:23:25'),(00001022,'INGRESO COMPRA DE MATERIALES','2021-10-05 09:26:57'),(00001023,'INGRESO COMPRA DE MATERIALES','2021-10-05 09:29:02'),(00001024,'INGRESO COMPRA DE MATERIALES','2021-10-05 11:10:39'),(00001025,'ORDEN DE SALIDA PEDIDOS DE MATERIALES DE LOS TECNICOS','2021-10-05 11:21:13'),(00001026,'INGRESO COMPRA DE MATERIALES','2021-10-05 11:22:11'),(00001027,'INGRESO COMPRA DE MATERIALES','2021-10-05 11:24:31'),(00001028,'INGRESO COMPRA DE MATERIALES','2021-10-06 09:33:31'),(00001029,'INGRESO COMPRA DE MATERIALES','2021-10-06 09:44:00'),(00001030,'INGRESO COMPRA DE MATERIALES','2021-10-07 11:27:52'),(00001031,'ORDEN DE SALIDA PEDIDOS DE MATERIALES DE LOS TECNICOS\r\nSemana de 4 al 8 de octubre 2021','2021-10-07 12:21:20'),(00001032,'ORDEN DE SALIDA PEDIDOS DE MATERIALES DE LOS TECNICOS','2021-10-12 15:05:00'),(00001033,'INGRESO COMPRA DE MATERIALES','2021-10-12 15:05:16');
/*!40000 ALTER TABLE `ordenes_materiales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `propuesta_instalaciones`
--

DROP TABLE IF EXISTS `propuesta_instalaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `propuesta_instalaciones` (
  `codigo_institucion` varchar(5) NOT NULL,
  `mes_instalacion` varchar(15) DEFAULT NULL,
  `fecha_instalacion` varchar(30) DEFAULT NULL,
  `semana_instalacion` int(11) DEFAULT NULL,
  `provincia` varchar(15) DEFAULT NULL,
  `canton` varchar(15) DEFAULT NULL,
  `distrito` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`codigo_institucion`),
  CONSTRAINT `codigo_pk` FOREIGN KEY (`codigo_institucion`) REFERENCES `instituciones` (`Codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `propuesta_instalaciones`
--

LOCK TABLES `propuesta_instalaciones` WRITE;
/*!40000 ALTER TABLE `propuesta_instalaciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `propuesta_instalaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `reporte_general`
--

DROP TABLE IF EXISTS `reporte_general`;
/*!50001 DROP VIEW IF EXISTS `reporte_general`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `reporte_general` AS SELECT 
 1 AS `placa`,
 1 AS `serie`,
 1 AS `marca`,
 1 AS `modelo`,
 1 AS `tipo_equipo`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id_rol` varchar(10) NOT NULL,
  `Descripcion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_rol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES ('AADMIN2019','ROL GENERAL'),('AAI2019','ROL pedidos '),('ABI2019','ROL control de inventarios '),('ATI2019','ROL tecnicos');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `seleccionar_materiales`
--

DROP TABLE IF EXISTS `seleccionar_materiales`;
/*!50001 DROP VIEW IF EXISTS `seleccionar_materiales`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `seleccionar_materiales` AS SELECT 
 1 AS `codigo`,
 1 AS `descripcion`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `solicitudes_pedidos_usuarios`
--

DROP TABLE IF EXISTS `solicitudes_pedidos_usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `solicitudes_pedidos_usuarios` (
  `num_pedido` int(11) unsigned zerofill NOT NULL,
  `nom_ubicacion` int(2) unsigned zerofill NOT NULL,
  PRIMARY KEY (`num_pedido`,`nom_ubicacion`),
  KEY `ubicacion_num_idx` (`nom_ubicacion`),
  CONSTRAINT `num_pedido` FOREIGN KEY (`num_pedido`) REFERENCES `equipos_instalacion_instituciones_final` (`id_registro`),
  CONSTRAINT `ubicacion_num` FOREIGN KEY (`nom_ubicacion`) REFERENCES `ubicacion` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitudes_pedidos_usuarios`
--

LOCK TABLES `solicitudes_pedidos_usuarios` WRITE;
/*!40000 ALTER TABLE `solicitudes_pedidos_usuarios` DISABLE KEYS */;
/*!40000 ALTER TABLE `solicitudes_pedidos_usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tecnicos`
--

DROP TABLE IF EXISTS `tecnicos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tecnicos` (
  `idtecnicos` int(2) unsigned zerofill NOT NULL,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`idtecnicos`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tecnicos`
--

LOCK TABLES `tecnicos` WRITE;
/*!40000 ALTER TABLE `tecnicos` DISABLE KEYS */;
INSERT INTO `tecnicos` VALUES (01,'MARYEL'),(02,'ERICK'),(03,'WALTER'),(04,'BRYAN');
/*!40000 ALTER TABLE `tecnicos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_equipos`
--

DROP TABLE IF EXISTS `tipos_equipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipos_equipos` (
  `id_tipo` varchar(15) NOT NULL,
  `tipo_equipo` varchar(30) NOT NULL,
  PRIMARY KEY (`id_tipo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_equipos`
--

LOCK TABLES `tipos_equipos` WRITE;
/*!40000 ALTER TABLE `tipos_equipos` DISABLE KEYS */;
INSERT INTO `tipos_equipos` VALUES ('APE','AP_EXTERNO'),('API','AP_INTERNO'),('IMP','IMPRESORA'),('NAS','NAS'),('PAR_TI_1','PARLANTE_TIPO_1'),('PAR_TI_2','PARLANTE_TIPO_2'),('PC','PORTATIL'),('PROY','PROYECTOR'),('RT','ROUTER'),('SER','SERVIDOR'),('SW','SWITCH'),('UNI_OP','UNIDAD_OPTICA'),('UPS_TI_1','UPS_TIPO1'),('UPS_TI_2','UPS_TIPO_2');
/*!40000 ALTER TABLE `tipos_equipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ubicacion`
--

DROP TABLE IF EXISTS `ubicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ubicacion` (
  `Codigo` int(2) unsigned zerofill NOT NULL,
  `Nombre` varchar(20) NOT NULL,
  `Descripcion` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`Codigo`),
  KEY `index_ubicacion` (`Codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ubicacion`
--

LOCK TABLES `ubicacion` WRITE;
/*!40000 ALTER TABLE `ubicacion` DISABLE KEYS */;
INSERT INTO `ubicacion` VALUES (01,'BODEGA','Equipos en bodega'),(02,'CENTRO DE SOPORTE','Equipo que se encuentra en centro de soporte'),(03,'CENTRO EDUCATIVO','Equipo que se encuentra ubicado en el centro educativo'),(04,'ADMINISTRATIVO','Encargado de realizar pedidos y verificar estados y ordenes'),(05,'CASOS','Area de casos se encarga de solicitar eqquipos');
/*!40000 ALTER TABLE `ubicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `nom_user` varchar(50) NOT NULL,
  `pass_user` blob NOT NULL,
  `rol_user` varchar(10) NOT NULL,
  PRIMARY KEY (`nom_user`),
  KEY `rol_foreignt_idx` (`rol_user`),
  CONSTRAINT `rol_foreignt` FOREIGN KEY (`rol_user`) REFERENCES `roles` (`id_rol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES ('ADMINISTRADOR',_binary '03408560-9B7FDF93-55158E3C-B3F1D457-B9A4BD50-9AB332B4-BEAF59AA-16C1AB50','AADMIN2019'),('ADMINISTRATIVO',_binary '88CA7501-767011F0-C7BDCA34-98E9933E-8B6D5ACB-A0CB4408-10572740-63AA31C7','AAI2019'),('BODEGA',_binary '9B7CD520-8A599AF3-D42E070A-2C4EAA12-4E0F8174-BCDCD450-9221F2AE-2E766FE8','ABI2019'),('cesar.rodriguez',_binary 'F3240065-24C2B827-EF08C7C5-70DAB709-6293210D-77BC757F-7EBC08A6-97ACA46C','AAI2019'),('TECNICO',_binary '0B16D52B-C9E613CC-176786D8-5764559F-BCC102F1-BD0940F0-B23B15CF-8B590895','ATI2019');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios_modalidades`
--

DROP TABLE IF EXISTS `usuarios_modalidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios_modalidades` (
  `id` int(11) NOT NULL,
  `tipo_usu` text,
  `ingreso_usu` text,
  `contrasena` text,
  `modalidad` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios_modalidades`
--

LOCK TABLES `usuarios_modalidades` WRITE;
/*!40000 ALTER TABLE `usuarios_modalidades` DISABLE KEYS */;
INSERT INTO `usuarios_modalidades` VALUES (1,'PREESCOLAR','K','SIN CONTRASENA','MULTIGRADO'),(2,'ESTUDIANTE','Estudiante','SIN CONTRASENA','MULTIGRADO'),(3,'EDUCADOR','Educador','SIN CONTRASENA','MULTIGRADO'),(4,'PROYECTO','Proyecto','SIN CONTRASENA','MULTIGRADO'),(5,'ESTUDIANTE','Estudiante##','SIN CONTRASENA','REM@'),(6,'EDUCADOR','Educador','SIN CONTRASENA','REM@'),(7,'PROYECTO','Proyecto','SIN CONTRASENA','REM@'),(8,'ADMINISTRADOR','Admie21','PriesIe21','MOVILAB_SECUNDARIA'),(9,'ESTUDIANTE','m##-nugg','nuggp','MOVILAB_SECUNDARIA'),(10,'EDUCADOR','Educador','ed##','MOVILAB_SECUNDARIA'),(11,'FACILITADOR','Facilitador','F##p','MOVILAB_SECUNDARIA'),(12,'CAPACITA','Capacita','aprender','MOVILAB_SECUNDARIA'),(13,'PROYECTO','Proyecto','SIN COTRASENA','MOVILAB_SECUNDARIA'),(14,'VISITANTE','Visitante','SIN CONTRASENA','MOVILAB_SECUNDARIA'),(15,'ADMINISTRADOR','Admie21','PriesIe21','MOVILAB_PRIMARIA_INDIGENA'),(16,'PREESCOLAR','K','SIN CONTRASENA','MOVILAB_PRIMARIA_INDIGENA'),(17,'PRIMER Y SEGUNDO CICLO','m##-nugg','nuggp','MOVILAB_PRIMARIA_INDIGENA'),(18,'EDUCADOR','Educador','ed##','MOVILAB_PRIMARIA_INDIGENA'),(19,'FACILITADOR','Facilitador','F##p','MOVILAB_PRIMARIA_INDIGENA'),(20,'CAPACITACION','Capacita','aprender','MOVILAB_PRIMARIA_INDIGENA'),(21,'PROYECTO','Proyecto','SIN CONTRASENA','MOVILAB_PRIMARIA_INDIGENA'),(22,'VISITANTE','Visitante','SIN CONTRASENA','MOVILAB_PRIMARIA_INDIGENA'),(23,'ADMINISTRADOR','AdminSec','P@ssw0rd.Sec','LIE_SECUNDARIA'),(24,'TERCER CICLO','m##-nugg','nuggp','LIE_SECUNDARIA'),(25,'EDUCADOR','ed##-01 al ed##-04','educador','LIE_SECUNDARIA'),(26,'VOCACIONAL','v##-01 al v##-10','SIN CONTRASENA','LIE_SECUNDARIA'),(27,'TECNOLOGICO ESTUDIANTE','t##-01 al  t##-10','01t al 10t','LIE_SECUNDARIA'),(28,'TECNOCLOGICO EDUCADOR','tprof##-01 al tprof##-02','tprof01 y tprof02','LIE_SECUNDARIA'),(29,'ASESOR','asesor','AsPronie','LIE_SECUNDARIA'),(30,'CAPACITACION','c##-aprende','aprende','LIE_SECUNDARIA'),(31,'TALLER','taller##-01 al taller##-05','taller01 al taller05','LIE_SECUNDARIA'),(32,'ESTUDIANTE','estudiante','SIN CONTRASENA','LIE_SECUNDARIA');
/*!40000 ALTER TABLE `usuarios_modalidades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `view_equipos_garantia`
--

DROP TABLE IF EXISTS `view_equipos_garantia`;
/*!50001 DROP VIEW IF EXISTS `view_equipos_garantia`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_equipos_garantia` AS SELECT 
 1 AS `SERIE`,
 1 AS `PLACA`,
 1 AS `DAÑOS`,
 1 AS `ESTADO`,
 1 AS `MARCA`,
 1 AS `MODELO`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_equipos_reparacion`
--

DROP TABLE IF EXISTS `view_equipos_reparacion`;
/*!50001 DROP VIEW IF EXISTS `view_equipos_reparacion`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_equipos_reparacion` AS SELECT 
 1 AS `SERIE`,
 1 AS `PLACA`,
 1 AS `DAÑOS`,
 1 AS `ESTADO`,
 1 AS `MARCA`,
 1 AS `MODELO`,
 1 AS `TIPO_EQUIPO`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_estado_accion`
--

DROP TABLE IF EXISTS `view_estado_accion`;
/*!50001 DROP VIEW IF EXISTS `view_estado_accion`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_estado_accion` AS SELECT 
 1 AS `Accion`,
 1 AS `descripcion`,
 1 AS `Ubicacion`,
 1 AS `Fecha Ingreso`,
 1 AS `Tipo_Orden`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_inventario_equipos`
--

DROP TABLE IF EXISTS `view_inventario_equipos`;
/*!50001 DROP VIEW IF EXISTS `view_inventario_equipos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_inventario_equipos` AS SELECT 
 1 AS `Serie`,
 1 AS `Placa`,
 1 AS `Numero_Estacion`,
 1 AS `Institucion`,
 1 AS `Modalidad`,
 1 AS `Accion`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_lista_materiales`
--

DROP TABLE IF EXISTS `view_lista_materiales`;
/*!50001 DROP VIEW IF EXISTS `view_lista_materiales`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_lista_materiales` AS SELECT 
 1 AS `codigo`,
 1 AS `descripcion`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_siguiente_codigo`
--

DROP TABLE IF EXISTS `view_siguiente_codigo`;
/*!50001 DROP VIEW IF EXISTS `view_siguiente_codigo`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_siguiente_codigo` AS SELECT 
 1 AS `codigo_modelo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `views_tipos_equipos`
--

DROP TABLE IF EXISTS `views_tipos_equipos`;
/*!50001 DROP VIEW IF EXISTS `views_tipos_equipos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `views_tipos_equipos` AS SELECT 
 1 AS `codigo_modelo`,
 1 AS `tipo_equipo`,
 1 AS `modelo`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping routines for database 'acs_sistema'
--
/*!50003 DROP FUNCTION IF EXISTS `obtener_codigo_estado` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `obtener_codigo_estado`(nombre varchar(45)) RETURNS int(11)
    READS SQL DATA
    DETERMINISTIC
BEGIN
	DECLARE codigo_estado int(2);
    SELECT id_estado into codigo_estado FROM estados_equipos WHERE estado = nombre;
RETURN codigo_estado;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `obtener_codigo_material` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `obtener_codigo_material`(nombre varchar(100)) RETURNS varchar(50) CHARSET latin1
    READS SQL DATA
    DETERMINISTIC
BEGIN
	DECLARE codigo_producto VARCHAR(50);
    SELECT codigo into codigo_producto FROM materiales WHERE descripcion = nombre;
RETURN codigo_producto;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `obtener_codigo_tecnico` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `obtener_codigo_tecnico`(nombre_tecni varchar(45)) RETURNS int(11)
    READS SQL DATA
    DETERMINISTIC
BEGIN
	DECLARE codigo_tecnico int(2);
    SELECT idtecnicos into codigo_tecnico FROM tecnicos WHERE nombre = nombre_tecni;
RETURN codigo_tecnico;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `obtener_codigo_ubicacion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `obtener_codigo_ubicacion`(nombre_ubi varchar(20)) RETURNS int(11)
    READS SQL DATA
    DETERMINISTIC
BEGIN
	DECLARE codigo_ubicacion int(2);
    SELECT Codigo into codigo_ubicacion FROM ubicacion WHERE Nombre = nombre_ubi;
RETURN codigo_ubicacion;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `obtener_nombre_institucion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `obtener_nombre_institucion`(codigo_institucion varchar(5)) RETURNS varchar(200) CHARSET latin1
    READS SQL DATA
    DETERMINISTIC
BEGIN
	DECLARE nombre_institucion VARCHAR(200);
    SELECT Centro_educativo into nombre_institucion FROM instituciones WHERE Codigo = codigo_institucion;
RETURN nombre_institucion;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `actualizar_inventarios_materiales` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `actualizar_inventarios_materiales`(in cantidad int(11),in descripcion VARCHAR(100),in orden int(8))
BEGIN
	DECLARE codigo varchar(50);
    SET codigo = obtener_codigo_material(descripcion);
	if (SELECT COUNT(*) FROM acs_sistema.materiales_unidades WHERE codigo_material = codigo) != 0 then
		update materiales_unidades SET cantidad_stock = (cantidad_stock+cantidad) WHERE codigo_material =codigo;
	else 
		insert into acs_sistema.materiales_unidades VALUES (codigo,cantidad);
	end if;
	
    insert into  acs_sistema.lista_inventarios_materiales VALUES (codigo,cantidad,03,orden); 
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `buscar_pedidos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `buscar_pedidos`(in orden int(8), in ubicacion varchar(150))
BEGIN
	SELECT * FROM equipos_instalacion_instituciones_final 
	INNER JOIN solicitudes_pedidos_usuarios on num_pedido = id_registro AND nom_ubicacion = obtener_codigo_ubicacion(ubicacion)
	where id_orden = orden;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `b_salida_materiales` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `b_salida_materiales`(in orden_buscar int(8))
BEGIN
SELECT inven.codigo_orden as codigo,inven.codigo_material,mate.descripcion,inven.cantidad_unidad,tec.nombre as tecnico,
inven.codigo_orden as orden
FROM lista_inventarios_materiales as inven
INNER JOIN tecnicos as tec ON tec.idtecnicos = inven.tecnico
INNER JOIN materiales as mate ON mate.codigo = inven.codigo_material
WHERE inven.codigo_orden = orden_buscar;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ingreso_equipos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ingreso_equipos`(in tipo int,in placa_equi varchar(30),in serie_equi varchar(30),in cartel VARCHAR(30))
BEGIN
	if (SELECT COUNT(*) FROM acs_sistema.equipos WHERE acs_sistema.equipos.placa = placa_equi AND acs_sistema.equipos.serie = serie_equi) = 0 then
		INSERT INTO equipos VALUES(tipo,placa_equi,serie_equi,cartel);
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ingreso_modelo_equipos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ingreso_modelo_equipos`(in codigo int,in marca varchar(30),in modelo varchar(50),in tipo varchar(15))
BEGIN
	if (SELECT COUNT(*) FROM acs_sistema.modelos_equipos WHERE acs_sistema.modelos_equipos.codigo_modelo = codigo) = 0 then
		INSERT INTO acs_sistema.modelos_equipos VALUES(codigo,marca,modelo,tipo);
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `insertar_cambios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_cambios`(in orden int(8),in placa VARCHAR(30),in serie VARCHAR(30),in tipo varchar(20), in fecha VARCHAR(30), in estacion int(11))
BEGIN
	INSERT INTO cambios VALUES(placa,serie,orden,tipo,estacion,fecha);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `insertar_equipos_reparacion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_equipos_reparacion`(in placa_equi varchar(30), in serie_equi varchar(30),in danos varchar(250),in estado_equi varchar(45))
BEGIN
	
if(SELECT COUNT(*) FROM  acs_sistema.equipos_reparacion WHERE placa = placa_equi and serie = serie_equi) = 0 then
		INSERT INTO acs_sistema.equipos_reparacion VALUES (serie_equi,placa_equi,danos,obtener_codigo_estado(estado_equi));
	else 
		UPDATE acs_sistema.equipos_reparacion SET serie = serie_equi,placa = placa_equi,danos = danos,id_estado = obtener_codigo_estado(estado_equi) 
        WHERE serie =  serie_equi AND placa = placa_equi;
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `insertar_factura` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_factura`(in num_fac varchar(45),in detalle varchar(250),in valor double,in fecha_registro varchar(45),in orden int(8), in tipo varchar(20))
BEGIN
	if(tipo = "Facturas Materiales") then
		if(SELECT COUNT(*) FROM acs_sistema.factura_materiales WHERE numero_factura = num_fac) = 0 then
			INSERT INTO acs_sistema.factura_materiales VALUES (num_fac,detalle,valor,fecha_registro,orden);
		end if;
	else 
		if(SELECT COUNT(*) FROM acs_sistema.factura_ordenes WHERE numero_factura = num_fac) = 0 then
			INSERT INTO acs_sistema.factura_ordenes VALUES (num_fac,detalle,valor,fecha_registro,orden);
		end if;
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `insertar_factura_costo_unidad` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_factura_costo_unidad`(in num_fac varchar(45),in detalle varchar(200),in valor double,in codigo_equipo varchar(45),in tipo varchar(20))
BEGIN
	if(tipo = "Facturas Materiales") then
		if(SELECT COUNT(*) FROM acs_sistema.factura_costo_unidad_materiales WHERE id_factura = num_fac and id_material = codigo_equipo) = 0 then
			INSERT INTO acs_sistema.factura_costo_unidad_materiales VALUES (num_fac,codigo_equipo,valor,detalle);
		end if;
    else
		if(SELECT COUNT(*) FROM acs_sistema.factura_costo_unidad_equipos WHERE id_factura = num_fac and id_equipo = codigo_equipo) = 0 then
			INSERT INTO acs_sistema.factura_costo_unidad_equipos VALUES (num_fac,codigo_equipo,valor,detalle);
		end if;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `insertar_orden_preparacion_equipos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_orden_preparacion_equipos`(in Codigo varchar(5), in Modalidad varchar(45),in Condicion varchar(45),in port_docente int(11),in port_preescolar int(11),in port_1_estudiante int(11),in port_2_estudiante int(11),in servidor int(11),in nas int(11),
		in proyector int(11),in impresora int(11),in audifonos int(11),in mouse int(11),in candados int(11),in convertidor int(11),in extensiones int(11),in regletas int(11),in maletin_proyector int(11),in maletin_portatil int(11),in router int(11),in switch24 int(11),in ap_interno int(11),in ap_externo int(11),in parlantes_1 int(11),
        in parlantes_2 int(11),in unidad_optica int(11),in ups_1 int(11),in ups_2 int(11),in cargador_ap int(11),in Patch_blanco int(11),in Patch_verde int(11),in Cable_hdmi int(11),in Cable_vga int(11),in Cable_usb int(11),in Cartucho_tinta int(11),in fecha varchar(30),in orden int(8),in usuario VARCHAR(20),in id_pedido int(11))
BEGIN
		DECLARE codigo_registro int(11);
		if (SELECT COUNT(*) FROM equipos_instalacion_instituciones_final WHERE id_orden = orden AND id_registro = id_pedido) = 0 then
			if(SELECT COUNT(*) FROM acs_sistema.equipos_instalacion_instituciones_final where id_orden = orden) != 2 then
				call p_insertar_acciones(orden,obtener_nombre_institucion(Codigo),NOW(),"SALIDA");
				INSERT INTO equipos_instalacion_instituciones_final VALUES(Codigo,Modalidad,Condicion,port_docente,port_preescolar,port_1_estudiante,port_2_estudiante,servidor,nas,
				proyector,impresora,audifonos,mouse,candados,convertidor,extensiones,regletas,maletin_proyector,maletin_portatil,router,switch24,ap_interno,ap_externo,parlantes_1,
				parlantes_2,unidad_optica,ups_1,ups_2,cargador_ap,Patch_blanco,Patch_verde,Cable_hdmi,Cable_vga,Cable_usb,Cartucho_tinta,id_pedido,fecha,orden);
				INSERT INTO solicitudes_pedidos_usuarios VALUES(id_pedido,obtener_codigo_ubicacion(usuario));
            end if;
            if(SELECT COUNT(*) FROM estado_orden_produccion WHERE id_estado_orden = orden ) =0 then
				INSERT INTO estado_orden_produccion VALUES(orden,"PENDIENTE");
			end if;
        END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `p_Aplicar_Estado_Accion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `p_Aplicar_Estado_Accion`(

	in accion int(8),

    in estado int(2)

)
BEGIN

	UPDATE acs_sistema.estado_accion SET acs_sistema.estado_accion.estado_accion = estado where acs_sistema.estado_accion.accion = accion;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `p_buscar_equipos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `p_buscar_equipos`(

	in comando varchar(50),

    in buscar varchar(20)

)
BEGIN

	case comando

	  when 'Serie' then

		SELECT acs_sistema.equipos.placa,  acs_sistema.equipos.serie, acs_sistema.modelos_equipos.marca,acs_sistema.modelos_equipos.modelo,

		acs_sistema.tipos_equipos.tipo_equipo

		FROM  acs_sistema.equipos

		INNER JOIN acs_sistema.modelos_equipos on acs_sistema.equipos.codigo_modelo = acs_sistema.modelos_equipos.codigo_modelo

		INNER JOIN acs_sistema.tipos_equipos on acs_sistema.tipos_equipos.id_tipo = acs_sistema.modelos_equipos.id_tipo

		WHERE acs_sistema.equipos.serie = buscar;

	  when 'Placa' then 

		SELECT acs_sistema.equipos.placa,  acs_sistema.equipos.serie, acs_sistema.modelos_equipos.marca,acs_sistema.modelos_equipos.modelo,

		acs_sistema.tipos_equipos.tipo_equipo

		FROM  acs_sistema.equipos

		INNER JOIN acs_sistema.modelos_equipos on acs_sistema.equipos.codigo_modelo = acs_sistema.modelos_equipos.codigo_modelo

		INNER JOIN acs_sistema.tipos_equipos on acs_sistema.tipos_equipos.id_tipo = acs_sistema.modelos_equipos.id_tipo

		WHERE acs_sistema.equipos.placa = buscar;

	  end case;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `p_buscar_lista_inventarios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `p_buscar_lista_inventarios`(

	in comando varchar(50),

    in accion_usu varchar(20))
BEGIN

	case accion_usu

	  when 'Serie' then

		SELECT Serie,Placa,Numero_Estacion,Institucion,Modalidad,Accion as Orden, orden.Fecha

		FROM acs_sistema.lista_inventarios
		INNER JOIN  acciones as orden ON orden.Codigo= Accion
        WHERE Serie LIKE concat('%',comando,'%');

	  when 'Placa'then 

		SELECT Serie,Placa,Numero_Estacion,Institucion,Modalidad,Accion as Orden, orden.Fecha

		FROM acs_sistema.lista_inventarios
		INNER JOIN  acciones as orden ON orden.Codigo= Accion
        WHERE Placa LIKE concat('%',comando,'%');

	  when 'Institucion' then

        SELECT Serie,Placa,Numero_Estacion,Institucion,Modalidad,Accion as Orden, orden.Fecha

		FROM acs_sistema.lista_inventarios
		INNER JOIN  acciones as orden ON orden.Codigo= Accion
        WHERE Institucion LIKE concat('%',comando,'%');

      when 'Institucion_Accion' then

        SELECT acs_sistema.acciones.Codigo as Accion,acs_sistema.acciones.Descripcion,acs_sistema.acciones.Fecha

		FROM acs_sistema.acciones

        WHERE acs_sistema.acciones.Descripcion LIKE concat('%',comando,'%');

	  end case;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `p_insertar_acciones` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `p_insertar_acciones`(in accion int(8),in descripcion VARCHAR(150),in fecha datetime,in tipo_orden varchar(45))
BEGIN

	if(SELECT COUNT(*) FROM acs_sistema.acciones WHERE Codigo = accion) = 0 then

		INSERT INTO acs_sistema.acciones VALUES (accion,descripcion,now(),tipo_orden);

        INSERT INTO acs_sistema.estado_accion VALUES(accion,01);
		if (tipo_orden LIKE "SALIDA") THEN
			INSERT INTO acs_sistema.estado_orden_produccion VALUES(accion,"PENDIENTE");
		END IF;
	end if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `p_insertar_equipos_inventarios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `p_insertar_equipos_inventarios`(

	in serie varchar(30),

    in placa varchar(30),

    in accion int(8),

    in institucion varchar(150),

    in modalidad varchar(50),

    in numero_Estacion int(3)

)
BEGIN

	DECLARE valor int(2) default 0;

	SET valor = (SELECT COUNT(*) FROM acs_sistema.lista_inventarios 

    WHERE  acs_sistema.lista_inventarios.Serie = serie AND acs_sistema.lista_inventarios.Placa =placa AND acs_sistema.lista_inventarios.Accion = accion);

	if valor = 0 then

		INSERT INTO acs_sistema.lista_inventarios VALUES (serie,placa,numero_estacion,institucion,modalidad,accion);

    end if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `p_insertar_institucion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `p_insertar_institucion`(in codigo varchar(5),  in centro_educativo varchar(200))
begin

	if (SELECT COUNT(*) FROM acs_sistema.instituciones WHERE acs_sistema.instituciones.Codigo = codigo ) =0 then

		INSERT INTO acs_sistema.instituciones VALUES(codigo,centro_educativo);

	end if;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `P_insertar_lista_materiales` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `P_insertar_lista_materiales`(in cantidad int(11),in descripcion VARCHAR(100),in tecnico VARCHAR(30), in orden int(8) )
BEGIN
	insert into lista_inventarios_materiales VALUES (obtener_codigo_material(descripcion),cantidad,tecnico,orden);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `p_insertar_materiales_inventarios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `p_insertar_materiales_inventarios`(

	in accion int(8),

    in descripcion varchar(30),

    in cantidad int(3)

)
BEGIN

	INSERT INTO acs_sistema.materiales_acciones VALUES (accion,descripcion,cantidad);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `p_insertar_orden_materiales` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `p_insertar_orden_materiales`(in orden int(8),in descripcion VARCHAR(150),in fecha datetime)
BEGIN

	if(SELECT COUNT(*) FROM acs_sistema.ordenes_materiales WHERE codigo = orden) = 0 then
		INSERT INTO acs_sistema.ordenes_materiales VALUES (orden,descripcion,now());
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `registrar_producto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `registrar_producto`(in codigo_pro varchar(50),in descripcion varchar(100))
BEGIN
	if (SELECT COUNT(*) FROM acs_sistema.materiales WHERE codigo = codigo_pro) = 0 then
		insert into materiales VALUES (codigo_pro,descripcion);
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `registro_inventarios_materiales_tecnicos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `registro_inventarios_materiales_tecnicos`(in cantidad int(11),in descripcion VARCHAR(100),in orden int(8),in tecnico varchar(45))
BEGIN
	DECLARE codigo varchar(50);
    SET codigo = obtener_codigo_material(descripcion);
	if (SELECT COUNT(*) FROM acs_sistema.materiales_unidades WHERE codigo_material = codigo) != 0 then
		update materiales_unidades SET cantidad_stock = (cantidad_stock-cantidad) WHERE codigo_material =codigo;
	end if;
	
    insert into  acs_sistema.lista_inventarios_materiales VALUES (codigo,cantidad,obtener_codigo_tecnico(tecnico),orden); 
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Current Database: `acs_sistema`
--

USE `acs_sistema`;

--
-- Final view structure for view `buscar_pedido_equipos`
--

/*!50001 DROP VIEW IF EXISTS `buscar_pedido_equipos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `buscar_pedido_equipos` AS select `equipos_instalacion_instituciones_final`.`Codigo_Institucion` AS `Codigo_Institucion`,`instituciones`.`Centro_educativo` AS `Centro_educativo`,`equipos_instalacion_instituciones_final`.`id_registro` AS `id_registro`,`equipos_instalacion_instituciones_final`.`id_orden` AS `id_orden`,`equipos_instalacion_instituciones_final`.`fecha_registro` AS `fecha_registro` from ((`equipos_instalacion_instituciones_final` join `instituciones` on((`instituciones`.`Codigo` = `equipos_instalacion_instituciones_final`.`Codigo_Institucion`))) join `solicitudes_pedidos_usuarios` on((`solicitudes_pedidos_usuarios`.`num_pedido` = `equipos_instalacion_instituciones_final`.`id_registro`))) where (`solicitudes_pedidos_usuarios`.`nom_ubicacion` = 4) order by `equipos_instalacion_instituciones_final`.`id_orden` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `cantidad_materiales_inventario`
--

/*!50001 DROP VIEW IF EXISTS `cantidad_materiales_inventario`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `cantidad_materiales_inventario` AS select `materiales_unidades`.`codigo_material` AS `codigo_material`,`materiales`.`descripcion` AS `descripcion`,`materiales_unidades`.`cantidad_stock` AS `cantidad_stock` from (`materiales_unidades` join `materiales` on((`materiales_unidades`.`codigo_material` = `materiales`.`codigo`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `cantidad_pendientes`
--

/*!50001 DROP VIEW IF EXISTS `cantidad_pendientes`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `cantidad_pendientes` AS select count(0) AS `Total` from `estado_orden_produccion` where (`estado_orden_produccion`.`estado` = 'PENDIENTE') */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `cantidad_stock_materiales`
--

/*!50001 DROP VIEW IF EXISTS `cantidad_stock_materiales`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `cantidad_stock_materiales` AS select `stock`.`cantidad_stock` AS `cantidad`,`material`.`descripcion` AS `descripcion` from (`materiales` `material` join `materiales_unidades` `stock` on((`stock`.`codigo_material` = `material`.`codigo`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `materiales_en_inventario`
--

/*!50001 DROP VIEW IF EXISTS `materiales_en_inventario`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `materiales_en_inventario` AS select `materiales_unidades`.`codigo_material` AS `codigo_material`,`material`.`descripcion` AS `descripcion`,`materiales_unidades`.`cantidad_stock` AS `cantidad_stock` from (`materiales_unidades` join `materiales` `material` on((`materiales_unidades`.`codigo_material` = `material`.`codigo`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `nueva_orden`
--

/*!50001 DROP VIEW IF EXISTS `nueva_orden`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `nueva_orden` AS select (`acciones`.`Codigo` + 1) AS `Codigo` from `acciones` order by `acciones`.`Codigo` desc limit 1 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `nueva_orden_materiales`
--

/*!50001 DROP VIEW IF EXISTS `nueva_orden_materiales`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `nueva_orden_materiales` AS select (`ordenes_materiales`.`codigo` + 1) AS `Codigo` from `ordenes_materiales` order by `ordenes_materiales`.`codigo` desc limit 1 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `nuevo_registro_pedido`
--

/*!50001 DROP VIEW IF EXISTS `nuevo_registro_pedido`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `nuevo_registro_pedido` AS select (`equipos_instalacion_instituciones_final`.`id_registro` + 1) AS `Codigo` from `equipos_instalacion_instituciones_final` order by `equipos_instalacion_instituciones_final`.`id_registro` desc limit 1 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `obtener_ordenes_enproceso`
--

/*!50001 DROP VIEW IF EXISTS `obtener_ordenes_enproceso`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `obtener_ordenes_enproceso` AS select `estado_orden_produccion`.`id_estado_orden` AS `Numero Orden`,`acciones`.`Descripcion` AS `Descripcion`,`estado_orden_produccion`.`estado` AS `Estado` from (`estado_orden_produccion` join `acciones` on((`acciones`.`Codigo` = `estado_orden_produccion`.`id_estado_orden`))) where (`estado_orden_produccion`.`estado` = 'EN PROCESO') */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `obtener_ordenes_pendientes`
--

/*!50001 DROP VIEW IF EXISTS `obtener_ordenes_pendientes`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `obtener_ordenes_pendientes` AS select `estado_orden_produccion`.`id_estado_orden` AS `Numero Orden`,`acciones`.`Descripcion` AS `Descripcion`,`estado_orden_produccion`.`estado` AS `Estado` from (`estado_orden_produccion` join `acciones` on((`acciones`.`Codigo` = `estado_orden_produccion`.`id_estado_orden`))) where (`estado_orden_produccion`.`estado` = 'PENDIENTE') */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `obtener_tecnicos`
--

/*!50001 DROP VIEW IF EXISTS `obtener_tecnicos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `obtener_tecnicos` AS select `tecnicos`.`nombre` AS `nombre` from `tecnicos` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `reporte_general`
--

/*!50001 DROP VIEW IF EXISTS `reporte_general`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `reporte_general` AS select `equipos`.`placa` AS `placa`,`equipos`.`serie` AS `serie`,`modelos_equipos`.`marca` AS `marca`,`modelos_equipos`.`modelo` AS `modelo`,`tipos_equipos`.`tipo_equipo` AS `tipo_equipo` from ((`equipos` join `modelos_equipos` on((`equipos`.`codigo_modelo` = `modelos_equipos`.`codigo_modelo`))) join `tipos_equipos` on((`tipos_equipos`.`id_tipo` = `modelos_equipos`.`id_tipo`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `seleccionar_materiales`
--

/*!50001 DROP VIEW IF EXISTS `seleccionar_materiales`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `seleccionar_materiales` AS select `materiales`.`codigo` AS `codigo`,`materiales`.`descripcion` AS `descripcion` from `materiales` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_equipos_garantia`
--

/*!50001 DROP VIEW IF EXISTS `view_equipos_garantia`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`userConnect`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `view_equipos_garantia` AS select `equipos_reparacion`.`serie` AS `SERIE`,`equipos_reparacion`.`placa` AS `PLACA`,`equipos_reparacion`.`danos` AS `DAÑOS`,`estados_equipos`.`estado` AS `ESTADO`,`modelos_equipos`.`marca` AS `MARCA`,`modelos_equipos`.`modelo` AS `MODELO` from (((`equipos_reparacion` join `estados_equipos` on((`estados_equipos`.`id_estado` = `equipos_reparacion`.`id_estado`))) join `equipos` on((`equipos`.`placa` = `equipos_reparacion`.`placa`))) join `modelos_equipos` on((`modelos_equipos`.`codigo_modelo` = `equipos`.`codigo_modelo`))) order by `estados_equipos`.`id_estado` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_equipos_reparacion`
--

/*!50001 DROP VIEW IF EXISTS `view_equipos_reparacion`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_equipos_reparacion` AS select `equipos_reparacion`.`serie` AS `SERIE`,`equipos_reparacion`.`placa` AS `PLACA`,`equipos_reparacion`.`danos` AS `DAÑOS`,`estados_equipos`.`estado` AS `ESTADO`,`modelos_equipos`.`marca` AS `MARCA`,`modelos_equipos`.`modelo` AS `MODELO`,`tipos_equipos`.`tipo_equipo` AS `TIPO_EQUIPO` from ((((`equipos_reparacion` join `estados_equipos` on((`estados_equipos`.`id_estado` = `equipos_reparacion`.`id_estado`))) join `equipos` on((`equipos`.`placa` = `equipos_reparacion`.`placa`))) join `modelos_equipos` on((`modelos_equipos`.`codigo_modelo` = `equipos`.`codigo_modelo`))) join `tipos_equipos` on((`tipos_equipos`.`id_tipo` = `modelos_equipos`.`id_tipo`))) order by `estados_equipos`.`id_estado` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_estado_accion`
--

/*!50001 DROP VIEW IF EXISTS `view_estado_accion`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_estado_accion` AS select `estado_accion`.`accion` AS `Accion`,`acciones`.`Descripcion` AS `descripcion`,`ubicacion`.`Nombre` AS `Ubicacion`,`acciones`.`Fecha` AS `Fecha Ingreso`,`acciones`.`tipo_orden` AS `Tipo_Orden` from ((`estado_accion` join `ubicacion` on((`estado_accion`.`estado_accion` = `ubicacion`.`Codigo`))) join `acciones` on((`estado_accion`.`accion` = `acciones`.`Codigo`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_inventario_equipos`
--

/*!50001 DROP VIEW IF EXISTS `view_inventario_equipos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_inventario_equipos` AS select `lista_inventarios`.`Serie` AS `Serie`,`lista_inventarios`.`Placa` AS `Placa`,`lista_inventarios`.`Numero_Estacion` AS `Numero_Estacion`,`lista_inventarios`.`Institucion` AS `Institucion`,`lista_inventarios`.`Modalidad` AS `Modalidad`,`lista_inventarios`.`Accion` AS `Accion` from `lista_inventarios` order by `lista_inventarios`.`Institucion`,`lista_inventarios`.`Numero_Estacion`,`lista_inventarios`.`Modalidad` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_lista_materiales`
--

/*!50001 DROP VIEW IF EXISTS `view_lista_materiales`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_lista_materiales` AS select `materiales`.`codigo` AS `codigo`,`materiales`.`descripcion` AS `descripcion` from `materiales` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_siguiente_codigo`
--

/*!50001 DROP VIEW IF EXISTS `view_siguiente_codigo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_siguiente_codigo` AS select `modelos_equipos`.`codigo_modelo` AS `codigo_modelo` from `modelos_equipos` order by `modelos_equipos`.`codigo_modelo` desc limit 1 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `views_tipos_equipos`
--

/*!50001 DROP VIEW IF EXISTS `views_tipos_equipos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `views_tipos_equipos` AS select `modelos_equipos`.`codigo_modelo` AS `codigo_modelo`,`tipos_equipos`.`tipo_equipo` AS `tipo_equipo`,`modelos_equipos`.`modelo` AS `modelo` from (`modelos_equipos` join `tipos_equipos` on((`tipos_equipos`.`id_tipo` = `modelos_equipos`.`id_tipo`))) order by `modelos_equipos`.`codigo_modelo` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-11-17 10:46:27
commit;