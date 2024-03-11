-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	8.1.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `propietarios`
--

DROP TABLE IF EXISTS `propietarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `propietarios` (
  `DNI` varchar(9) NOT NULL,
  `Nombre` varchar(45) DEFAULT NULL,
  `Apellidos` varchar(80) DEFAULT NULL,
  `DireccionResidencia` varchar(60) DEFAULT NULL,
  `Localidad` varchar(45) DEFAULT NULL,
  `CP` int DEFAULT NULL,
  `Provincia` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`DNI`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `propietarios`
--

LOCK TABLES `propietarios` WRITE;
/*!40000 ALTER TABLE `propietarios` DISABLE KEYS */;
INSERT INTO `propietarios` VALUES ('15896120S','Carlos','García Pérez','Calle Mayor 1','Murcia',28001,'Islas Baleares'),('16960561Q','Juan','Pérez Jiménez','Calle de Alcalá 21','Palma',48001,'Las Palmas'),('17491004X','Pablo','González Rodríguez','Paseo de la Castellana 30','Bilbao',41001,'Islas Baleares'),('18241463W','Pablo','Pérez Jiménez','Gran Vía 56','Murcia',35001,'Valencia'),('18295434S','Juan','Sánchez Díaz','Ronda de Toledo 5','Zaragoza',50001,'Málaga'),('20675857F','Pablo','Díaz Morales','Calle del Prado 8','Murcia',46001,'Barcelona'),('20693441L','Ana','Pérez Jiménez','Ronda de Toledo 5','Madrid',30001,'Murcia'),('21621402E','Juan','Martínez Sánchez','Paseo de la Castellana 30','Murcia',35001,'Sevilla'),('26974449A','Luis','Gómez Ruiz','Avenida Libertad 23','Madrid',29001,'Barcelona'),('33106071D','Pablo','Fernández Gómez','Ronda de Toledo 5','Las Palmas',30001,'Málaga'),('38016301S','Pablo','Pérez Jiménez','Calle Nueva 12','Valencia',35001,'Valencia'),('39308607C','Carmen','Martínez Sánchez','Avenida Libertad 23','Palma',8001,'Islas Baleares'),('40698153K','Luis','Gómez Ruiz','Calle Nueva 12','Sevilla',28001,'Valencia'),('45777975V','Ana','López Martínez','Calle del Prado 8','Barcelona',8001,'Vizcaya'),('45802304N','Elena','Pérez Jiménez','Calle del Prado 8','Palma',41001,'Madrid'),('48571473G','Luis','Díaz Morales','Calle de Alcalá 21','Bilbao',35001,'Barcelona'),('50455148W','Pablo','Sánchez Díaz','Calle Nueva 12','Las Palmas',7001,'Sevilla'),('57699174V','Juan','Fernández Gómez','Gran Vía 56','Bilbao',28001,'Vizcaya'),('58873973E','María','Martínez Sánchez','Plaza del Sol 45','Sevilla',8001,'Las Palmas'),('59981949L','María','Pérez Jiménez','Gran Vía 56','Madrid',35001,'Vizcaya'),('60274601L','José','González Rodríguez','Calle de Alcalá 21','Palma',8001,'Barcelona'),('61091550P','Ana','Gómez Ruiz','Calle Mayor 1','Murcia',35001,'Valencia'),('62195011K','Juan','García Pérez','Calle de Alcalá 21','Málaga',30001,'Vizcaya'),('63352629A','Luis','Martínez Sánchez','Calle Nueva 12','Zaragoza',48001,'Vizcaya'),('64913720S','José','Pérez Jiménez','Calle Mayor 1','Zaragoza',29001,'Valencia'),('65352265L','Pablo','Ruiz López','Gran Vía 56','Málaga',8001,'Madrid'),('66468536P','Carlos','Díaz Morales','Gran Vía 56','Las Palmas',7001,'Barcelona'),('68459508P','Ana','Sánchez Díaz','Plaza del Sol 45','Bilbao',7001,'Zaragoza'),('69356633H','Luis','Martínez Sánchez','Calle Nueva 12','Palma',8001,'Madrid'),('70667279D','Luis','Díaz Morales','Gran Vía 56','Sevilla',41001,'Murcia'),('72173260L','María','Fernández Gómez','Calle Mayor 1','Málaga',41001,'Vizcaya'),('72905407F','José','García Pérez','Calle de Alcalá 21','Bilbao',29001,'Madrid'),('73301212M','Elena','Martínez Sánchez','Ronda de Toledo 5','Sevilla',48001,'Vizcaya'),('74315379X','Sofía','García Pérez','Calle Mayor 1','Palma',8001,'Vizcaya'),('74333529J','Sofía','Ruiz López','Gran Vía 56','Murcia',35001,'Murcia'),('76529173P','Juan','Ruiz López','Ronda de Toledo 5','Barcelona',8001,'Madrid'),('79229756T','José','Gómez Ruiz','Gran Vía 56','Málaga',50001,'Barcelona'),('79544193G','Ana','Gómez Ruiz','Plaza del Sol 45','Bilbao',7001,'Barcelona'),('81010136L','José','Díaz Morales','Avenida de la Paz 16','Madrid',35001,'Zaragoza'),('81540111M','María','Sánchez Díaz','Paseo de la Castellana 30','Barcelona',28001,'Zaragoza'),('81660583A','José','López Martínez','Calle del Prado 8','Valencia',28001,'Las Palmas'),('82186988F','José','González Rodríguez','Ronda de Toledo 5','Barcelona',50001,'Murcia'),('86528654D','Carmen','Ruiz López','Calle del Prado 8','Murcia',29001,'Las Palmas'),('87124927F','Carlos','Ruiz López','Calle Mayor 1','Murcia',48001,'Valencia'),('88401538A','Carmen','Martínez Sánchez','Paseo de la Castellana 30','Barcelona',46001,'Las Palmas'),('88806930C','José','Pérez Jiménez','Avenida Libertad 23','Sevilla',46001,'Málaga'),('90284727K','Pablo','Díaz Morales','Plaza del Sol 45','Valencia',35001,'Zaragoza'),('91134634D','Carmen','Martínez Sánchez','Ronda de Toledo 5','Valencia',35001,'Las Palmas'),('91787834D','Elena','Pérez Jiménez','Calle Nueva 12','Sevilla',41001,'Málaga'),('93599049C','Elena','García Pérez','Avenida Libertad 23','Bilbao',29001,'Murcia'),('95205529L','Ana','González Rodríguez','Avenida de la Paz 16','Zaragoza',8001,'Zaragoza'),('95260305D','Carlos','García Pérez','Ronda de Toledo 5','Sevilla',8001,'Sevilla'),('96020403A','Carlos','Fernández Gómez','Avenida de la Paz 16','Valencia',29001,'Madrid'),('96477597A','Carmen','Sánchez Díaz','Ronda de Toledo 5','Madrid',41001,'Vizcaya'),('98912012Y','Ana','Martínez Sánchez','Gran Vía 56','Las Palmas',35001,'Málaga');
/*!40000 ALTER TABLE `propietarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-22 14:31:38
