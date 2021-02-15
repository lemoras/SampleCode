# ************************************************************
# Sequel Pro SQL dump
# Version 4541
#
# http://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: 192.168.2.10 (MySQL 5.5.5-10.2.32-MariaDB-1:10.2.32+maria~bionic)
# Database: company_db
# Generation Time: 2020-05-30 09:15:42 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table Branch
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Branch`;

CREATE TABLE `Branch` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyId` int(11) NOT NULL,
  `Name` varchar(250) CHARACTER SET utf8 NOT NULL,
  `CityId` int(11) DEFAULT NULL,
  `DistrictId` int(11) DEFAULT NULL,
  `Adress` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `Order` int(11) DEFAULT NULL,
  `Active` bit(1) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `ModifiedBy` int(11) DEFAULT NULL,
  `DeletedDate` datetime DEFAULT NULL,
  `DeletedBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

LOCK TABLES `Branch` WRITE;
/*!40000 ALTER TABLE `Branch` DISABLE KEYS */;

INSERT INTO `Branch` (`Id`, `CompanyId`, `Name`, `CityId`, `DistrictId`, `Adress`, `Order`, `Active`, `CreatedDate`, `CreatedBy`, `ModifiedDate`, `ModifiedBy`, `DeletedDate`, `DeletedBy`)
VALUES
	(1,1,'OsmanEmre Company Merkez Sube',0,0,NULL,1,b'1','2020-05-16 06:23:57',1,NULL,NULL,NULL,NULL),
	(2,2,'Berkay Akyil Company Merkez Sube',0,0,NULL,1,b'1','2020-05-16 21:39:18',1,NULL,NULL,NULL,NULL);

/*!40000 ALTER TABLE `Branch` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table BranchImage
# ------------------------------------------------------------

DROP TABLE IF EXISTS `BranchImage`;

CREATE TABLE `BranchImage` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `BranchId` int(11) NOT NULL,
  `Url` varchar(455) CHARACTER SET utf8 NOT NULL,
  `Order` int(11) DEFAULT NULL,
  `Active` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



# Dump of table Company
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Company`;

CREATE TABLE `Company` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(250) CHARACTER SET utf8 NOT NULL,
  `Logo` varchar(455) CHARACTER SET utf8 DEFAULT NULL,
  `TradeRegisterNo` varchar(55) CHARACTER SET utf8 DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `DeletedDate` datetime DEFAULT NULL,
  `DeletedBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

LOCK TABLES `Company` WRITE;
/*!40000 ALTER TABLE `Company` DISABLE KEYS */;

INSERT INTO `Company` (`Id`, `Name`, `Logo`, `TradeRegisterNo`, `CreatedDate`, `CreatedBy`, `DeletedDate`, `DeletedBy`)
VALUES
	(1,'OsmanEmre Company','wwww.image.com/barber','AA1234567','2020-05-16 06:23:57',0,NULL,NULL),
	(2,'Berkay Akyil Company','wwww.image.com/barberayt','AA12345678','2020-05-16 21:39:16',0,NULL,NULL);

/*!40000 ALTER TABLE `Company` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table Staff
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Staff`;

CREATE TABLE `Staff` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `BranchId` int(11) NOT NULL,
  `Name` varchar(250) CHARACTER SET utf8 NOT NULL,
  `Surname` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `PhotoUrl` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

LOCK TABLES `Staff` WRITE;
/*!40000 ALTER TABLE `Staff` DISABLE KEYS */;

INSERT INTO `Staff` (`Id`, `UserId`, `BranchId`, `Name`, `Surname`, `PhotoUrl`)
VALUES
	(1,1,1,'Hidir','Kitir','wwww.image.com/barber'),
	(2,1,2,'Berkay','Akyil','wwww.image.com/berkay');

/*!40000 ALTER TABLE `Staff` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table StaffWorkingHours
# ------------------------------------------------------------

DROP TABLE IF EXISTS `StaffWorkingHours`;

CREATE TABLE `StaffWorkingHours` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `StaffId` int(11) NOT NULL,
  `Week` int(11) DEFAULT NULL,
  `WorkHours` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

LOCK TABLES `StaffWorkingHours` WRITE;
/*!40000 ALTER TABLE `StaffWorkingHours` DISABLE KEYS */;

INSERT INTO `StaffWorkingHours` (`Id`, `StaffId`, `Week`, `WorkHours`)
VALUES
	(1,1,52,'11111111111,21111111111,31111111111,41111111111,51111111111,61111111111'),
	(2,2,52,'11111111111,21111111111,31111111111,41111111111,51111111111,61111111111');

/*!40000 ALTER TABLE `StaffWorkingHours` ENABLE KEYS */;
UNLOCK TABLES;