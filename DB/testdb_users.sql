-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: testdb
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Password` varchar(300) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Role` varchar(20) NOT NULL,
  `User_State` tinyint(1) NOT NULL DEFAULT '1',
  `client_id` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Name_UNIQUE` (`Name`),
  UNIQUE KEY `Email_UNIQUE` (`Email`),
  KEY `fk_client_users_idx` (`client_id`),
  CONSTRAINT `fk_client_users` FOREIGN KEY (`client_id`) REFERENCES `client` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Xavier','$2a$11$KHhOMt74QRRliVmrxqlTe.COjF0bggErcS/ziYQafBd9hDkBgdl46','xavier.jimenez@manicatogroup.com','Administrator',1,1),(2,'Billys','$2a$11$0MsEG8zE9/IUrYMPR9ZZvurRkO.vJNSnIEUI5ZqaoIdXeJROZxv9.','Billy2@gmail.com','User',1,1),(3,'David','$2a$11$8wo7ZUezZGnCXX3fYshWyu4.ejNvWoMvBMAaUj240rN5s.sIl/VaW','David@gmail.com','Manager',1,1),(4,'carlos','$2a$11$7QLCN.VPquirhAUQp6vtK.sHtv2IwW4nhhXiXd32D6apeENIWmVDC','carlos@manicatrogroup.com','Administrator',1,1),(5,'Erick','$2a$11$Ni91LqwxtKEgB/baQkIjLOsV2HwuetJcRVbokFVpijHT5wZ.So7Tq','ErickJhonatan@gmail.com','Administrator',1,1),(6,'Bryan','$2a$11$75933EOxIQOeCDbulYVPCOpFkZgqQ3IZHopCEpupB4Rlb58RipEF.','Bryan@gmail.com','User',1,1),(7,'Diana','$2a$11$mTUwz8jYhD16ZXzGZPVonuIiq9sUWOxqRB79jV2GrOudJw9V.AKja','Diana@gmail.com','Administrator',1,1),(8,'Alan','$2a$11$Z7iscocyhgGbekbW4I8sae7MWurQ7oM9lQleiqUxByjAgNPWeWtIG','Alan@gmail.com','User',1,1),(9,'Brand','$2a$11$hzIrbDPQNAB5lpDOkqaM0O260YsjB80LVY14KglkYlU2i2uX13N1W','Brand@gmail.com','Manager',1,1),(10,'Nick','$2a$11$arLGP43rgVHCPz34hY/WfeR1spwRJWj8pPXXMJrFH9urIYjA222B6','Nick@gmail.com','User',1,1),(11,'Juan','$2a$11$pDMRxVfHL913d0o1RXT9NugXPJWym7/0tejIUpZxHHU.AbGoLL0Aq','Juan@gmail.com','Manager',1,2);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-14 20:12:10
