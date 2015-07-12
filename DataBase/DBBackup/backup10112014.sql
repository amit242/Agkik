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
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `address` (
  `idAddress` int(11) NOT NULL AUTO_INCREMENT,
  `AddressLine1` varchar(60) NOT NULL,
  `AddressLine2` varchar(60) DEFAULT NULL,
  `City` varchar(20) NOT NULL,
  `State` varchar(20) NOT NULL,
  `Country` varchar(20) NOT NULL,
  `Zip` int(11) NOT NULL,
  PRIMARY KEY (`idAddress`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES (1,'a',NULL,'Kolkata','WB','India',700001),(2,'b',NULL,'Kolkata','WB','India',700002),(3,'c',NULL,'Kolkata','WB','India',700003),(4,'d',NULL,'Siliguri','WB','India',123456),(5,'e',NULL,'Bangalore','Karnataka','India',560001),(6,'f',NULL,'Bardwan','WB','India',123457),(7,'g',NULL,'Katwa','WB','India',123458);
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customers` (
  `idCustomers` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `AlternateEmail` varchar(50) DEFAULT NULL,
  `Address_idAddress` int(11) DEFAULT NULL,
  `AltAddress_idAddress` int(11) DEFAULT NULL,
  `PhoneNo` varchar(10) DEFAULT NULL,
  `MobileNo` varchar(10) DEFAULT NULL,
  `IsRegular` binary(1) NOT NULL,
  `RegistrationDate` datetime NOT NULL,
  PRIMARY KEY (`idCustomers`),
  KEY `fk_Customers_Address_idx` (`Address_idAddress`),
  KEY `fk_Customers_AltAddress_idx` (`AltAddress_idAddress`),
  CONSTRAINT `fk_Customers_Address` FOREIGN KEY (`Address_idAddress`) REFERENCES `address` (`idAddress`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Customers_AltAddress` FOREIGN KEY (`AltAddress_idAddress`) REFERENCES `address` (`idAddress`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice`
--

DROP TABLE IF EXISTS `invoice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `invoice` (
  `idInvoice` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`idInvoice`),
  UNIQUE KEY `idInvoice_UNIQUE` (`idInvoice`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice`
--

LOCK TABLES `invoice` WRITE;
/*!40000 ALTER TABLE `invoice` DISABLE KEYS */;
/*!40000 ALTER TABLE `invoice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoicelines`
--

DROP TABLE IF EXISTS `invoicelines`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `invoicelines` (
  `idInvoiceLines` int(11) NOT NULL AUTO_INCREMENT,
  `Invoice_idInvoice` int(11) NOT NULL,
  `Item_idItem` int(11) NOT NULL,
  PRIMARY KEY (`idInvoiceLines`),
  UNIQUE KEY `idInvoiceLines_UNIQUE` (`idInvoiceLines`),
  KEY `fk_InvoiceLines_Invoice1_idx` (`Invoice_idInvoice`),
  KEY `fk_InvoiceLines_Item1_idx` (`Item_idItem`),
  CONSTRAINT `fk_InvoiceLines_Invoice1` FOREIGN KEY (`Invoice_idInvoice`) REFERENCES `invoice` (`idInvoice`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_InvoiceLines_Item1` FOREIGN KEY (`Item_idItem`) REFERENCES `item` (`idItem`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoicelines`
--

LOCK TABLES `invoicelines` WRITE;
/*!40000 ALTER TABLE `invoicelines` DISABLE KEYS */;
/*!40000 ALTER TABLE `invoicelines` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `item` (
  `idItem` int(11) NOT NULL AUTO_INCREMENT,
  `ItemSKU` varchar(10) NOT NULL,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`idItem`),
  UNIQUE KEY `idItem_UNIQUE` (`idItem`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
/*!40000 ALTER TABLE `item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicine`
--

DROP TABLE IF EXISTS `medicine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `medicine` (
  `idMedicine` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `GenericName` varchar(200) NOT NULL,
  `IsRetail` tinyint(1) DEFAULT NULL,
  `IsH1` tinyint(1) DEFAULT NULL,
  `UOM_idUOM` int(11) NOT NULL,
  `QuantityAlert` int(11) NOT NULL,
  PRIMARY KEY (`idMedicine`),
  UNIQUE KEY `idMedicine_UNIQUE` (`idMedicine`),
  KEY `medName` (`Name`),
  KEY `medGenName` (`GenericName`),
  KEY `fk_Medicine_UOM1_idx` (`UOM_idUOM`),
  CONSTRAINT `fk_Medicine_UOM1` FOREIGN KEY (`UOM_idUOM`) REFERENCES `uom` (`idUOM`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicine`
--

LOCK TABLES `medicine` WRITE;
/*!40000 ALTER TABLE `medicine` DISABLE KEYS */;
/*!40000 ALTER TABLE `medicine` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `repeatorder`
--

DROP TABLE IF EXISTS `repeatorder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `repeatorder` (
  `idRepeatOrder` int(11) NOT NULL AUTO_INCREMENT,
  `Customers_idCustomers` int(11) NOT NULL,
  `DoctorsName` varchar(60) DEFAULT NULL,
  `RepeatOrdercol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idRepeatOrder`),
  UNIQUE KEY `idRepeatOrder_UNIQUE` (`idRepeatOrder`),
  KEY `fk_RepeatOrder_Customers1_idx` (`Customers_idCustomers`),
  CONSTRAINT `fk_RepeatOrder_Customers1` FOREIGN KEY (`Customers_idCustomers`) REFERENCES `customers` (`idCustomers`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `repeatorder`
--

LOCK TABLES `repeatorder` WRITE;
/*!40000 ALTER TABLE `repeatorder` DISABLE KEYS */;
/*!40000 ALTER TABLE `repeatorder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles` (
  `idRoles` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idRoles`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Admin'),(2,'Manager'),(3,'Salesman'),(4,'Other');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `uom`
--

DROP TABLE IF EXISTS `uom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `uom` (
  `idUOM` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `UOMConversionFactor` int(11) NOT NULL,
  PRIMARY KEY (`idUOM`),
  UNIQUE KEY `idUOM_UNIQUE` (`idUOM`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `uom`
--

LOCK TABLES `uom` WRITE;
/*!40000 ALTER TABLE `uom` DISABLE KEYS */;
/*!40000 ALTER TABLE `uom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `idUsers` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(45) NOT NULL,
  `Password` varchar(45) NOT NULL,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `AlternateEmail` varchar(50) DEFAULT NULL,
  `Address_idAddress` int(11) DEFAULT NULL,
  `AltAddress_idAddress` int(11) DEFAULT NULL,
  `PhoneNo` varchar(10) DEFAULT NULL,
  `MobileNo` varchar(10) DEFAULT NULL,
  `RegistrationDate` datetime NOT NULL,
  `LastLoggedInDate` datetime NOT NULL,
  `Roles_idRoles` int(11) NOT NULL,
  PRIMARY KEY (`idUsers`),
  UNIQUE KEY `UserName_UNIQUE` (`UserName`),
  UNIQUE KEY `Email_UNIQUE` (`Email`),
  KEY `fk_Users_Address_idx` (`Address_idAddress`),
  KEY `fk_Users_Address1_idx` (`AltAddress_idAddress`),
  KEY `fk_Users_Roles1_idx` (`Roles_idRoles`),
  CONSTRAINT `fk_Users_Address` FOREIGN KEY (`Address_idAddress`) REFERENCES `address` (`idAddress`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Users_AltAddress` FOREIGN KEY (`AltAddress_idAddress`) REFERENCES `address` (`idAddress`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Users_Roles1` FOREIGN KEY (`Roles_idRoles`) REFERENCES `roles` (`idRoles`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','admin','gandalf','',NULL,NULL,NULL,NULL,NULL,NULL,'2014-10-03 00:00:00','2014-10-03 00:00:00',1),(2,'manager','manager','Legolas','Elf',NULL,NULL,NULL,NULL,NULL,NULL,'2014-10-03 00:00:00','2014-10-03 00:00:00',2);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendors`
--

DROP TABLE IF EXISTS `vendors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vendors` (
  `idVendors` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `VendorCompany` varchar(45) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `AlternateEmail` varchar(50) DEFAULT NULL,
  `PhoneNo` varchar(10) DEFAULT NULL,
  `MobileNo` varchar(10) DEFAULT NULL,
  `Address_idAddress` int(11) DEFAULT NULL,
  `AltAddress_idAddress` int(11) DEFAULT NULL,
  `RegistrationDate` datetime NOT NULL,
  PRIMARY KEY (`idVendors`),
  KEY `fk_Vendors_Address_idx` (`Address_idAddress`),
  KEY `fk_Vendors_AltAddress_idx` (`AltAddress_idAddress`),
  CONSTRAINT `fk_Vendors_Address` FOREIGN KEY (`Address_idAddress`) REFERENCES `address` (`idAddress`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Vendors_AltAddress` FOREIGN KEY (`AltAddress_idAddress`) REFERENCES `address` (`idAddress`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendors`
--

LOCK TABLES `vendors` WRITE;
/*!40000 ALTER TABLE `vendors` DISABLE KEYS */;
/*!40000 ALTER TABLE `vendors` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-10-11 17:40:20
