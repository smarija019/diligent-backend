-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Apr 30, 2020 at 09:30 AM
-- Server version: 5.7.26
-- PHP Version: 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `diligent_db_new`
--

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4,
  `ClaimValue` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('1', 'admin', 'admin', NULL),
('2', 'customer', 'customer', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4,
  `ClaimValue` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4,
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('35815547-7e14-415c-bf4d-efec98ef10c3', '1'),
('b36710b5-e2a6-4f84-a5c0-b2ededd80168', '1'),
('538b90f7-7df0-4614-a265-a3e9caaf29ca', '2'),
('547540e7-4b03-4b58-b811-135ba824527c', '2'),
('a8f31be3-0873-4191-a002-9d76ec2c4d9b', '2'),
('b7030e53-f87d-4359-864b-c4da7cf2ae21', '2'),
('c14780d7-5b07-4bc1-bd17-df64573af61d', '2');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4,
  `SecurityStamp` longtext CHARACTER SET utf8mb4,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4,
  `PhoneNumber` longtext CHARACTER SET utf8mb4,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `Role` longtext CHARACTER SET utf8mb4,
  `FirstName` longtext CHARACTER SET utf8mb4,
  `LastName` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`, `Role`, `FirstName`, `LastName`) VALUES
('35815547-7e14-415c-bf4d-efec98ef10c3', 'p.marko', 'P.MARKO', 'p.marko', 'P.MARKO', 0, 'AQAAAAEAACcQAAAAECDcDcrWOXZ60t7Fiw12qEDss2Qfq0x5An6bgyVSAGHzxHZZYYT7FZeWaUNUio9hrQ==', 'DKVFJQLK73JX52K6EVCOFI3ZG2NCR73K', 'e8628664-1db9-4eb2-91d6-3633623cc321', NULL, 0, 0, NULL, 1, 0, 'admin', 'Marko', 'Pantic'),
('538b90f7-7df0-4614-a265-a3e9caaf29ca', 'nevena@gmail.com', 'NEVENA@GMAIL.COM', 'nevena@gmail.com', 'NEVENA@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEE9sT3tmfw/UxiGhr8omKnT6osW0RTKkpp2Jy7wlHrkt6knKNWzJaNIkH6eVk2916A==', 'Q6QDZOEGFJKYHEFKNCY3UDGJQAAE7SGB', '2697f165-c04b-46a4-92c4-c1c57a00ea91', NULL, 0, 0, NULL, 1, 0, 'customer', 'Nevena', 'Nikic'),
('547540e7-4b03-4b58-b811-135ba824527c', 'pera@gmail.com', 'PERA@GMAIL.COM', 'pera@gmail.com', 'PERA@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEH+MRVIRFxA68zew9tGCtrC2J6ixtH/VfN8+ykmxDkgi7aAYMIdF3ecc0Ze7blqmaA==', '376L2SMHAJ5IFGH3NWV4QXK3G6HCV35H', '8a7d4195-9083-4da2-9feb-d46e09bd9c72', NULL, 0, 0, NULL, 1, 0, 'customer', 'Pera', 'Peric'),
('a8f31be3-0873-4191-a002-9d76ec2c4d9b', 'filip@gmail.com', 'FILIP@GMAIL.COM', 'filip@gmail.com', 'FILIP@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEMOny5ahVkpN6Sbem5+W/8jv149L41nOTDhV+AM5HW5vZ/NoL+pvIBKLOq/RKXaqLw==', '5RLCAX74WPYR52YS57AE2KCYMW7A3ZVL', '8b0fab72-4782-4a8c-aee6-bf36967549d2', NULL, 0, 0, NULL, 1, 0, 'customer', 'Filip', 'Filipovic'),
('b36710b5-e2a6-4f84-a5c0-b2ededd80168', 'smarija@gmail.com', 'SMARIJA@GMAIL.COM', 'smarija@gmail.com', 'SMARIJA@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEMJ467593qKEmh5PmG6VGFmNhSOHQ0ZOE19G8ZtEHKcGXbEEP1QwD4E6gEe9jTzLNQ==', '6E537EIPV7MAPM4JFB7V33QCKO4BRSPC', 'c00b66a6-b8c7-40b4-accb-5c10670a25cb', NULL, 0, 0, NULL, 1, 0, 'admin', 'Marija', 'Stojanovic'),
('b7030e53-f87d-4359-864b-c4da7cf2ae21', 'fbiljana@gmail.com', 'FBILJANA@GMAIL.COM', 'fbiljana@gmail.com', 'FBILJANA@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEHKAcqP8L1+s30vJ0tmS4loLSD8AzEjwdEIuh5p36Op0jsbZ/R3Hc17giJAyPFsrrw==', 'ZPHVMDR6ZY475A4KMWFQHSVI5KGC66DG', '0a430e38-672e-43f5-adfe-3297fce608d9', NULL, 0, 0, NULL, 1, 0, 'customer', 'Biljana', 'Filipovic'),
('c14780d7-5b07-4bc1-bd17-df64573af61d', 'lazar@open.com', 'LAZAR@OPEN.COM', 'lazar@open.com', 'LAZAR@OPEN.COM', 0, 'AQAAAAEAACcQAAAAEL2ggJ3NqvZzK8jL6ey7UEGKY0i/4K2k2TE3IswEDz5AKIsmKSX87ML8iLgx/HR+Wg==', '5H2UQO5PQYTFXOV7AZPWXCTTDWRNZCW3', '319efbdc-65bc-4163-8552-d6650d8cea8a', NULL, 0, 0, NULL, 1, 0, 'customer', 'Lazar', 'Lazic');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE IF NOT EXISTS `aspnetusertokens` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `companies`
--

DROP TABLE IF EXISTS `companies`;
CREATE TABLE IF NOT EXISTS `companies` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `address` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `companies`
--

INSERT INTO `companies` (`id`, `name`, `address`) VALUES
(1, 'Delta', 'Adresa 1'),
(2, 'COmpany', 'Adresa 2'),
(4, 'LawCompany', 'adresa 4'),
(5, 'Sigma', 'adresa 5'),
(6, 'NovaCO', 'Adresa 6'),
(7, 'CityCom', 'BB ulica 5'),
(8, 'NIcom', 'Kralja Milana 5');

-- --------------------------------------------------------

--
-- Table structure for table `contacts`
--

DROP TABLE IF EXISTS `contacts`;
CREATE TABLE IF NOT EXISTS `contacts` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `tel1` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `tel2` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `address` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `email` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `flag` int(1) DEFAULT NULL,
  `profession` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `company` int(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `contacts`
--

INSERT INTO `contacts` (`id`, `name`, `tel1`, `tel2`, `address`, `email`, `flag`, `profession`, `company`) VALUES
(2, 'Marija Petrovic', '777', '', 'Veljka Vlahovica D3', 'maki@open.com', 1, 'lawyer', 6),
(4, 'Janko Jankovic', 'tel33', 'tel33', 'Laze Kostica 55', 'kontakt33@open.com', 2, 'lawyer', 2),
(5, 'Stefan Stefanovic', 'tel5', 'tel5', 'Trg Kralja Milana', 'kontakt5@open.com', 2, 'lawyer', 6),
(6, 'Mirko Vasic', 'tel6', 'tel66', 'Naselje Rastoka', 'mirko@open.com', 1, 'judge', 2),
(7, 'Mila Lovrov', '234234', '4534534', 'Dobropoljska 4', 'mila@open.com', 1, 'judge', 4);

-- --------------------------------------------------------

--
-- Table structure for table `lawsuits`
--

DROP TABLE IF EXISTS `lawsuits`;
CREATE TABLE IF NOT EXISTS `lawsuits` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `date` datetime(6) NOT NULL,
  `location` int(10) NOT NULL,
  `judge` int(10) NOT NULL,
  `inst_type` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `procedure_id` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `courtroom` int(10) NOT NULL,
  `plaintiff` int(10) NOT NULL,
  `defendant` int(10) NOT NULL,
  `note` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `procedure_type` int(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `lawsuits`
--

INSERT INTO `lawsuits` (`id`, `date`, `location`, `judge`, `inst_type`, `procedure_id`, `courtroom`, `plaintiff`, `defendant`, `note`, `procedure_type`) VALUES
(7, '2021-07-07 11:30:10.000000', 4, 7, 'Osnovni sud', '7B1.1244/22', 211, 7, 7, 'jednom je vec odlozeno sudjenje', 34),
(13, '2020-04-09 11:30:10.000000', 4, 6, 'Visi sud', '1FD.1244/22', 9, 2, 2, 'beleska o postupku', 27),
(14, '2020-08-15 10:30:10.000000', 5, 6, 'Osnovni sud', '6G1.1244/20', 15, 5, 7, 'Odlagana 2 puta', 38),
(15, '2020-04-07 10:30:10.000000', 4, 2, 'Visi sud', '1MS.1244/30', 3, 6, 7, 'Podneta zalba', 34),
(16, '2020-04-19 12:30:10.000000', 6, 6, 'Visi sud', '1FD.1244/777', 3, 4, 5, 'Odlozena', 3),
(17, '2020-08-21 13:30:10.000000', 10, 5, 'Osnovni sud', '1FDGe.1244/22', 9, 2, 4, 'U toku prikupljanje dokaza', 38),
(18, '2020-06-05 11:30:10.000000', 4, 0, 'Osnovni sud', '155.1244/22', 12, 5, 7, 'Odlozena', 39);

-- --------------------------------------------------------

--
-- Table structure for table `lawyers`
--

DROP TABLE IF EXISTS `lawyers`;
CREATE TABLE IF NOT EXISTS `lawyers` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `lawsuit_id` int(10) NOT NULL,
  `user_id` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `lawyers`
--

INSERT INTO `lawyers` (`id`, `lawsuit_id`, `user_id`) VALUES
(1, 7, '35815547-7e14-415c-bf4d-efec98ef10c3'),
(2, 13, '35815547-7e14-415c-bf4d-efec98ef10c3'),
(5, 0, '35815547-7e14-415c-bf4d-efec98ef10c3'),
(8, 15, 'b7030e53-f87d-4359-864b-c4da7cf2ae21'),
(12, 14, '538b90f7-7df0-4614-a265-a3e9caaf29ca'),
(13, 14, 'c14780d7-5b07-4bc1-bd17-df64573af61d'),
(14, 14, 'b36710b5-e2a6-4f84-a5c0-b2ededd80168'),
(16, 13, '538b90f7-7df0-4614-a265-a3e9caaf29ca'),
(17, 14, 'a8f31be3-0873-4191-a002-9d76ec2c4d9b');

-- --------------------------------------------------------

--
-- Table structure for table `locations`
--

DROP TABLE IF EXISTS `locations`;
CREATE TABLE IF NOT EXISTS `locations` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `location` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `locations`
--

INSERT INTO `locations` (`id`, `location`) VALUES
(3, 'Kraljevo'),
(4, 'Negotin'),
(5, 'Zaječar'),
(6, 'Niš'),
(7, 'Beograd'),
(9, 'Bor'),
(10, 'Novi Sad'),
(11, 'Valjevo'),
(12, 'Zrenjanin');

-- --------------------------------------------------------

--
-- Table structure for table `types`
--

DROP TABLE IF EXISTS `types`;
CREATE TABLE IF NOT EXISTS `types` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `type` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `types`
--

INSERT INTO `types` (`id`, `type`) VALUES
(27, 'Parnicni postupak'),
(28, 'Krivicni postupak'),
(30, 'Tuzba'),
(31, 'Zalba'),
(34, 'Razvod'),
(36, 'Parnica tip2'),
(38, 'Krivicni postupak 44tip'),
(39, 'Parnica tip 55');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(95) COLLATE utf8_unicode_ci NOT NULL,
  `ProductVersion` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20200417091832_initial', '3.1.3'),
('20200417112709_new', '3.1.3'),
('20200417113427_new2', '3.1.3'),
('20200418081321_userRegistration', '3.1.3');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
