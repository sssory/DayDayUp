-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.6.40-log


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema daydaydb
--

CREATE DATABASE IF NOT EXISTS daydaydb;
USE daydaydb;

--
-- Definition of table `menus`
--

DROP TABLE IF EXISTS `menus`;
CREATE TABLE `menus` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Code` varchar(45) NOT NULL,
  `Sort` int(10) unsigned NOT NULL DEFAULT '0',
  `ParentId` int(10) unsigned NOT NULL DEFAULT '0',
  `ShowType` varchar(45) NOT NULL DEFAULT '0' COMMENT 'control选项卡，form弹窗',
  `AutoStart` int(10) unsigned NOT NULL DEFAULT '0' COMMENT '是否开机自启动',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `menus`
--

/*!40000 ALTER TABLE `menus` DISABLE KEYS */;
INSERT INTO `menus` (`Id`,`Name`,`Code`,`Sort`,`ParentId`,`ShowType`,`AutoStart`) VALUES 
 (1,'Base','Base',0,0,'',0),
 (2,'OpenService','Base_OpenService',0,1,'',1),
 (3,'CloseService','Base_CloseService',1,1,'',0),
 (6,'Socket','Socket',1,0,'',0),
 (7,'SocketServer','Socket_Server',0,6,'control',0),
 (8,'SocketClient','Socket_Client',1,6,'control',0),
 (9,'McEthernetClient','Socket_McEthernet',2,6,'control',0),
 (10,'HostLinkCmode','Socket_HostLinkCMode',3,6,'control',0),
 (11,'SerialPort','SerialPort',2,0,'',0),
 (12,'Redis','Redis',3,0,'',0),
 (14,'Tool','Tool',5,0,'',0),
 (15,'MailBy163','Tool_MailBy163',0,14,'form',0),
 (16,'SqlBackUp','Tool_SqlBackUp',1,14,'form',0),
 (17,'SugarHelper','Tool_Sugar',2,14,'form',0),
 (18,'ModbusRTU','SerialPort_ModbusRTU',0,11,'control',0);
/*!40000 ALTER TABLE `menus` ENABLE KEYS */;


--
-- Definition of table `userpower`
--

DROP TABLE IF EXISTS `userpower`;
CREATE TABLE `userpower` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` int(10) unsigned NOT NULL,
  `PowerType` int(10) unsigned NOT NULL COMMENT '0菜单',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `userpower`
--

/*!40000 ALTER TABLE `userpower` DISABLE KEYS */;
/*!40000 ALTER TABLE `userpower` ENABLE KEYS */;


--
-- Definition of table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserName` varchar(45) NOT NULL,
  `UserNumber` varchar(45) NOT NULL,
  `UserPassword` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`Id`,`UserName`,`UserNumber`,`UserPassword`) VALUES 
 (1,'管理员','admin','698d51a19d8a121ce581499d7b701668');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
