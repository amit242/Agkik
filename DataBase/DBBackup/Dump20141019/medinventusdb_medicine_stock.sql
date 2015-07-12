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
-- Table structure for table `medicine_stock`
--

DROP TABLE IF EXISTS `medicine_stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `medicine_stock` (
  `idMedicine_Stock` int(11) NOT NULL AUTO_INCREMENT,
  `Medicine_Vendor_idMedicine_Vendor` int(11) NOT NULL,
  `Rate` float NOT NULL,
  `ExciseDuty` decimal(10,0) DEFAULT NULL,
  `TaxOnMRP` decimal(10,0) DEFAULT NULL,
  `TaxOnExciseDuty` decimal(10,0) DEFAULT NULL,
  `VendorDiscount` decimal(10,0) DEFAULT NULL,
  `CustomerDiscount` decimal(10,0) DEFAULT NULL,
  `Quantity` int(11) NOT NULL,
  `InventoryEntryDate` date NOT NULL,
  `SoldQuantity` float DEFAULT NULL,
  `Item_idItem` int(11) NOT NULL,
  PRIMARY KEY (`idMedicine_Stock`),
  UNIQUE KEY `idMedicine_Stock_UNIQUE` (`idMedicine_Stock`),
  KEY `fk_Medicine_Stock_Medicine_Vendor1_idx` (`Medicine_Vendor_idMedicine_Vendor`),
  KEY `fk_Medicine_Stock_Item1_idx` (`Item_idItem`),
  CONSTRAINT `fk_Medicine_Stock_Item1` FOREIGN KEY (`Item_idItem`) REFERENCES `item` (`idItem`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Medicine_Stock_Medicine_Vendor1` FOREIGN KEY (`Medicine_Vendor_idMedicine_Vendor`) REFERENCES `medicine_vendor` (`idMedicine_Vendor`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicine_stock`
--

LOCK TABLES `medicine_stock` WRITE;
/*!40000 ALTER TABLE `medicine_stock` DISABLE KEYS */;
/*!40000 ALTER TABLE `medicine_stock` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-10-19 13:25:23
