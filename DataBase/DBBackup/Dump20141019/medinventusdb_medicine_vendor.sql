CREATE DATABASE  IF NOT EXISTS `medinventusdb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `medinventusdb`;
-- MySQL dump 10.13  Distrib 5.6.17, for Win32 (x86)
--
-- Host: localhost    Database: medinventusdb
-- ------------------------------------------------------
-- Server version	5.1.72-community

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `medicine_vendor`
--

DROP TABLE IF EXISTS `medicine_vendor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `medicine_vendor` (
  `idMedicine_Vendor` int(11) NOT NULL AUTO_INCREMENT,
  `Vendors_idVendors` int(11) NOT NULL,
  `Medicine_idMedicine` int(11) NOT NULL,
  `BatchNo` varchar(100) NOT NULL,
  `ExpiryDate` date NOT NULL,
  `MRP` float NOT NULL,
  `ExpiryDateAlert` date NOT NULL,
  PRIMARY KEY (`idMedicine_Vendor`),
  UNIQUE KEY `idMedicine_Vendor_UNIQUE` (`idMedicine_Vendor`),
  KEY `fk_Medicine_Vendor_Vendors1_idx` (`Vendors_idVendors`),
  KEY `fk_Medicine_Vendor_Medicine1_idx` (`Medicine_idMedicine`),
  KEY `medExpiryDate` (`ExpiryDate`),
  CONSTRAINT `fk_Medicine_Vendor_Medicine1` FOREIGN KEY (`Medicine_idMedicine`) REFERENCES `medicine` (`idMedicine`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Medicine_Vendor_Vendors1` FOREIGN KEY (`Vendors_idVendors`) REFERENCES `vendors` (`idVendors`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicine_vendor`
--

LOCK TABLES `medicine_vendor` WRITE;
/*!40000 ALTER TABLE `medicine_vendor` DISABLE KEYS */;
/*!40000 ALTER TABLE `medicine_vendor` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-10-19 13:25:25
