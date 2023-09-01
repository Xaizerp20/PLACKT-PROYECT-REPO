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
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(200) DEFAULT NULL,
  `creation_date` datetime NOT NULL,
  `contact` varchar(45) DEFAULT NULL,
  `Location` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (1,'Ternura','2023-06-12 14:47:54','809-111-2222','Sto Dgo'),(2,'Hi Five','2023-06-12 17:08:21','809-121-3333','Santiago'),(3,'Amor','2023-06-12 19:59:50','8096667777','Bani');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `issues`
--

DROP TABLE IF EXISTS `issues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `issues` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Issue_Type` varchar(45) NOT NULL,
  `Open_Date` datetime DEFAULT CURRENT_TIMESTAMP,
  `Status` varchar(10) NOT NULL DEFAULT 'PENDING',
  `Resolve_Date` datetime DEFAULT NULL,
  `Description` longtext,
  `vehicle_Id` int DEFAULT NULL,
  `client_DNI` varchar(45) DEFAULT NULL,
  `client_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_issues_vehicles_idx` (`vehicle_Id`),
  KEY `fk_client_issues_idx` (`client_id`),
  CONSTRAINT `fk_client_issues` FOREIGN KEY (`client_id`) REFERENCES `client` (`id`),
  CONSTRAINT `fk_issues_vehicles` FOREIGN KEY (`vehicle_Id`) REFERENCES `vehicles` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `issues`
--

LOCK TABLES `issues` WRITE;
/*!40000 ALTER TABLE `issues` DISABLE KEYS */;
INSERT INTO `issues` VALUES (1,'Robo','2023-05-30 02:08:05','RESOLVED','2023-05-30 17:38:54','EL CLIENTE SE LLEVO EL MOUSE DE LA HABITACION',1,NULL,1),(2,'Robo','2023-05-30 02:20:15','RESOLVED','2023-05-30 18:42:08','EL CLIENTE SE LLEVO EL MOUSE DE LA HABITACION',1,NULL,1),(3,'Perdida','2023-05-30 16:11:42','RESOLVED','2023-05-30 18:43:07','El cliente dejo su celular en la habitacion ',2,NULL,1),(4,'Daños','2023-05-30 18:43:39','RESOLVED','2023-05-30 18:44:05','el cliente dano una mesa',4,NULL,1),(5,'Robo','2023-05-30 18:44:35','RESOLVED','2023-05-30 18:44:47','el cliente se robo una silla ',2,NULL,1),(6,'Robo','2023-05-30 19:03:23','RESOLVED','2023-05-30 19:03:28','El cliente se robo una mesa',10,NULL,1),(7,'Perdida','2023-05-30 19:58:49','RESOLVED','2023-05-30 20:01:05',NULL,5,NULL,1),(8,'Otros','2023-05-30 20:00:43','RESOLVED','2023-05-30 20:00:57',NULL,2,NULL,1),(9,'Perdida','2023-05-30 20:13:11','RESOLVED','2023-06-01 18:58:30',NULL,4,NULL,1),(10,'Daños','2023-06-01 12:38:15','PENDING',NULL,NULL,3,NULL,1),(11,'Otros','2023-06-01 12:39:05','RESOLVED','2023-06-14 14:17:57',NULL,2,NULL,1),(12,'Daños','2023-06-01 12:48:58','RESOLVED','2023-06-14 14:17:50',NULL,3,NULL,1),(13,'Perdida','2023-06-01 12:54:42','RESOLVED','2023-06-01 20:21:04',NULL,4,NULL,1),(14,'Otros','2023-06-01 12:55:07','RESOLVED','2023-06-14 14:17:48',NULL,6,NULL,1),(15,'Daños','2023-06-01 13:00:46','RESOLVED','2023-06-14 14:17:47',NULL,6,NULL,1),(16,'Perdida','2023-06-01 13:05:28','RESOLVED','2023-06-14 14:17:45',NULL,4,NULL,1),(17,'Robo','2023-06-01 18:46:32','RESOLVED','2023-06-14 14:17:44',NULL,5,NULL,1),(18,'Perdida','2023-06-05 20:00:08','RESOLVED','2023-06-05 20:12:12',NULL,2,NULL,1),(19,'Perdida','2023-06-05 20:05:14','RESOLVED','2023-06-05 20:11:41',NULL,1,NULL,1),(20,'Daños','2023-06-05 20:05:31','RESOLVED','2023-06-05 20:10:56',NULL,1,NULL,1),(21,'Perdida','2023-06-05 20:06:09','RESOLVED','2023-06-05 20:10:44',NULL,2,NULL,1),(22,'Daños','2023-06-05 20:09:13','RESOLVED','2023-06-05 20:09:20','ROBO DE DETERGENTE\n',4,NULL,1),(23,'Daños','2023-06-05 20:12:42','RESOLVED','2023-06-05 20:14:48',NULL,2,NULL,1),(24,'Daños','2023-06-05 20:12:53','RESOLVED','2023-06-05 20:12:59',NULL,4,NULL,1),(25,'Perdida','2023-06-05 20:14:42','RESOLVED','2023-06-05 21:03:04',NULL,3,NULL,1),(26,'Robo','2023-06-06 15:44:42','RESOLVED','2023-06-14 14:16:46','nose',6,NULL,1),(27,'Robo','2023-06-06 15:46:45','RESOLVED','2023-06-14 14:16:43','csdf',3,NULL,1),(28,'Perdida','2023-06-06 16:19:07','RESOLVED','2023-06-14 14:16:36','xfdfd',47,NULL,1),(29,'Perdida','2023-06-06 16:21:52','RESOLVED','2023-06-06 17:25:06','sabra dios\n',48,NULL,1),(30,'Robo','2023-06-06 16:34:01','RESOLVED','2023-06-06 16:38:33','aja',49,NULL,1),(31,'Perdida','2023-06-06 16:35:14','RESOLVED','2023-06-06 16:38:31','rgfdgfdg',51,NULL,1),(32,'Daños','2023-06-06 16:35:54','RESOLVED','2023-06-06 16:38:29','ghgfhgfh',52,NULL,1),(33,'Perdida','2023-06-06 16:36:26','RESOLVED','2023-06-06 16:38:25','deewrewr',54,NULL,1),(34,'Perdida','2023-06-06 18:26:59','RESOLVED','2023-06-14 14:16:30','azaasas',57,NULL,1),(35,'Perdida','2023-06-06 18:39:58','RESOLVED','2023-06-14 14:16:27','dasdsac',59,NULL,1),(36,'Robo','2023-06-06 18:44:53','PENDING',NULL,'asa',3,NULL,2),(37,'Robo','2023-06-14 16:06:55','RESOLVED','2023-06-14 16:08:03','sdsdasd',71,NULL,1),(38,'Robo','2023-06-14 16:07:53','RESOLVED','2023-06-14 16:08:00',NULL,71,NULL,1),(39,'Perdida','2023-06-14 19:22:41','PENDING',NULL,'sdsadsacs',72,NULL,1);
/*!40000 ALTER TABLE `issues` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `registerarrivals`
--

DROP TABLE IF EXISTS `registerarrivals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `registerarrivals` (
  `id` int NOT NULL AUTO_INCREMENT,
  `room` int DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `id_vehicle` int NOT NULL,
  `exit_time` datetime DEFAULT NULL,
  `client_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_arrivals_vehicles_idx` (`id_vehicle`),
  KEY `fk_client_arrivals_idx` (`client_id`),
  CONSTRAINT `fk_arrivals_vehicles` FOREIGN KEY (`id_vehicle`) REFERENCES `vehicles` (`id`),
  CONSTRAINT `fk_client_arrivals` FOREIGN KEY (`client_id`) REFERENCES `client` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=108 DEFAULT CHARSET=armscii8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registerarrivals`
--

LOCK TABLES `registerarrivals` WRITE;
/*!40000 ALTER TABLE `registerarrivals` DISABLE KEYS */;
INSERT INTO `registerarrivals` VALUES (1,1,'2023-05-27 16:37:15',3,NULL,1),(2,2,'2023-05-27 16:40:10',1,NULL,2),(3,2,'2023-05-27 16:40:14',1,NULL,1),(4,3,'2023-05-27 16:56:58',1,NULL,2),(5,3,'2023-05-27 16:57:56',1,NULL,1),(6,2,'2023-05-27 16:59:04',1,NULL,2),(7,1,'2023-05-27 16:59:53',1,NULL,1),(8,2,'2023-05-27 17:00:44',1,NULL,1),(9,2,'2023-05-27 17:06:45',1,NULL,1),(10,3,'2023-05-27 17:07:45',1,NULL,1),(11,3,'2023-05-29 22:10:00',1,NULL,1),(12,1,'2023-05-29 22:26:29',2,NULL,1),(13,3,'2023-05-29 22:29:35',8,NULL,1),(14,4,'2023-05-29 22:30:07',1,NULL,1),(15,4,'2023-05-29 22:34:03',4,NULL,1),(16,3,'2023-05-29 22:43:01',12,NULL,1),(17,4,'2023-05-29 22:48:14',16,NULL,1),(18,4,'2023-05-29 22:50:59',4,NULL,1),(19,6,'2023-05-29 22:51:47',2,NULL,1),(20,5,'2023-05-29 23:19:34',5,NULL,1),(21,7,'2023-05-30 00:11:11',1,NULL,1),(22,4,'2023-05-30 00:11:32',17,NULL,1),(23,2,'2023-05-30 00:13:41',2,NULL,1),(24,4,'2023-05-30 00:19:12',5,NULL,1),(25,3,'2023-05-30 00:29:43',1,NULL,1),(26,3,'2023-05-30 00:30:03',2,NULL,1),(27,5,'2023-05-30 00:31:21',18,NULL,1),(28,0,'2023-05-30 13:46:21',19,NULL,1),(29,0,'2023-05-30 14:15:47',25,NULL,1),(30,4,'2023-05-30 19:57:12',4,NULL,1),(31,6,'2023-05-30 19:57:43',4,NULL,1),(32,3,'2023-05-30 20:32:44',4,NULL,1),(33,4,'2023-05-30 20:34:42',4,NULL,1),(34,2,'2023-05-30 20:35:14',4,NULL,1),(35,3,'2023-05-30 20:36:07',4,NULL,1),(36,3,'2023-05-30 20:42:11',4,NULL,1),(37,2,'2023-05-30 20:45:10',4,NULL,1),(38,3,'2023-05-30 21:02:24',3,NULL,1),(39,1,'2023-06-01 17:05:31',1,NULL,1),(40,2,'2023-06-01 17:22:59',4,NULL,1),(41,3,'2023-06-01 17:44:52',10,NULL,1),(42,3,'2023-06-01 18:16:24',4,NULL,1),(43,3,'2023-06-01 18:20:54',4,NULL,1),(44,3,'2023-06-01 18:22:03',4,NULL,1),(45,3,'2023-06-01 18:22:21',4,NULL,1),(46,5,'2023-06-01 18:36:14',9,NULL,1),(47,4,'2023-06-01 18:51:27',4,NULL,1),(48,6,'2023-06-06 12:11:08',26,'2023-06-06 15:05:11',1),(49,2,'2023-06-06 12:42:56',27,'2023-06-06 15:18:43',1),(50,0,'2023-06-06 13:28:16',28,'2023-06-06 15:19:44',1),(51,0,'2023-06-06 13:28:33',29,'2023-06-06 15:19:48',1),(52,0,'2023-06-06 13:47:26',30,'2023-06-06 15:19:48',1),(53,2,'2023-06-06 14:18:39',31,'2023-06-06 15:19:19',1),(54,3,'2023-06-06 14:19:44',32,'2023-06-06 15:19:49',1),(55,2,'2023-06-06 14:33:06',33,'2023-06-06 15:19:50',1),(56,3,'2023-06-06 14:35:04',34,'2023-06-06 15:19:51',1),(57,3,'2023-06-06 14:35:49',35,'2023-06-06 14:58:47',1),(58,2,'2023-06-06 15:20:40',36,'2023-06-06 15:20:47',1),(59,2,'2023-06-06 15:22:35',37,'2023-06-06 15:22:42',1),(60,3,'2023-06-06 15:23:26',38,'2023-06-06 15:38:11',1),(61,1,'2023-06-06 15:40:51',39,'2023-06-06 15:42:10',1),(62,3,'2023-06-06 15:42:17',40,'2023-06-06 15:44:10',1),(63,2,'2023-06-06 15:44:16',41,'2023-06-06 15:46:06',1),(64,1,'2023-06-06 15:46:22',42,'2023-06-06 15:46:50',1),(65,2,'2023-06-06 15:59:34',43,'2023-06-06 16:00:27',1),(66,2,'2023-06-06 16:03:19',44,'2023-06-06 16:04:20',1),(67,2,'2023-06-06 16:06:14',45,'2023-06-06 16:10:06',1),(68,2,'2023-06-06 16:10:30',46,'2023-06-06 16:21:20',1),(69,3,'2023-06-06 16:15:38',47,'2023-06-06 16:19:11',1),(70,2,'2023-06-06 16:21:13',48,'2023-06-06 16:21:56',1),(71,2,'2023-06-06 16:33:17',49,'2023-06-06 16:34:04',1),(72,1,'2023-06-06 16:34:51',50,'2023-06-06 16:34:59',1),(73,2,'2023-06-06 16:35:05',51,'2023-06-06 16:35:16',1),(74,1,'2023-06-06 16:35:36',52,'2023-06-06 16:35:57',1),(75,4,'2023-06-06 16:35:43',53,'2023-06-06 16:36:01',1),(76,3,'2023-06-06 16:36:16',54,'2023-06-06 16:36:29',1),(77,2,'2023-06-06 16:42:01',55,'2023-06-06 17:13:51',1),(78,0,'2023-06-06 17:13:55',56,'2023-06-06 18:26:51',1),(79,2,'2023-06-06 18:26:46',57,'2023-06-06 18:27:01',1),(80,1,'2023-06-06 18:28:37',58,'2023-06-06 18:28:45',1),(81,5,'2023-06-06 18:39:51',59,'2023-06-06 18:40:00',1),(82,3,'2023-06-06 21:35:28',60,NULL,1),(85,1,'2023-06-12 18:03:57',64,NULL,2),(86,1,'2023-06-12 18:05:20',65,NULL,2),(87,2,'2023-06-12 18:10:16',66,NULL,1),(88,1,'2023-06-13 16:11:54',67,NULL,1),(89,2,'2023-06-13 18:10:53',68,'2023-06-13 18:18:52',1),(90,2,'2023-06-13 18:27:50',69,'2023-06-13 18:28:37',2),(91,2,'2023-06-14 15:52:26',70,'2023-06-14 15:53:00',1),(92,1,'2023-06-14 15:56:35',70,'2023-06-14 15:56:45',1),(93,0,'2023-06-14 15:59:21',71,'2023-06-14 15:59:31',1),(94,3,'2023-06-14 16:00:13',71,'2023-06-14 16:00:22',1),(95,0,'2023-06-14 16:06:48',71,'2023-06-14 16:06:58',1),(96,1,'2023-06-14 18:56:52',71,'2023-06-14 19:16:44',1),(98,3,'2023-06-14 19:08:28',72,'2023-06-14 19:22:42',1),(100,0,'2023-06-14 19:22:34',73,NULL,1),(106,0,'2023-06-14 19:43:44',71,'2023-06-14 19:44:13',1),(107,0,'2023-06-14 19:44:19',71,'2023-06-14 19:44:23',1);
/*!40000 ALTER TABLE `registerarrivals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shifts`
--

DROP TABLE IF EXISTS `shifts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shifts` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Shift_Start` time NOT NULL,
  `Shift_End` time NOT NULL,
  `daytime` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shifts`
--

LOCK TABLES `shifts` WRITE;
/*!40000 ALTER TABLE `shifts` DISABLE KEYS */;
INSERT INTO `shifts` VALUES (1,'00:45:00','15:46:00','Matutino'),(2,'02:45:00','21:45:00','Tarde'),(3,'00:45:00','14:25:00','Noche'),(4,'00:45:00','14:21:00','Noche'),(5,'00:45:00','04:45:00','Noche'),(6,'00:45:00','00:45:00','Tarde'),(7,'00:45:00','00:45:00','Matutino'),(8,'00:45:00','00:45:00','Tarde');
/*!40000 ALTER TABLE `shifts` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `vehicles`
--

DROP TABLE IF EXISTS `vehicles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vehicles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `NumberPlate` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Pending_Issues` int NOT NULL DEFAULT '0',
  `Resolved_Issues` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `NumberPlate_UNIQUE` (`NumberPlate`)
) ENGINE=InnoDB AUTO_INCREMENT=74 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehicles`
--

LOCK TABLES `vehicles` WRITE;
/*!40000 ALTER TABLE `vehicles` DISABLE KEYS */;
INSERT INTO `vehicles` VALUES (1,'4545454',0,0),(2,'V425737',0,0),(3,'Q969253',0,0),(4,'X584178',0,0),(5,'F376118',0,0),(6,'F888634',0,0),(7,'V498996',0,0),(8,'Z483218',0,0),(9,'L690179',0,0),(10,'E784451',0,0),(11,'I312960',0,0),(12,'P066185',0,0),(13,'N440872',0,0),(14,'Q780918',0,0),(15,'B869601',0,0),(16,'F494153',0,0),(17,'V562511',0,0),(18,'K240335',0,0),(19,'D536972',0,0),(20,'X689642',0,0),(21,'X253236',0,0),(22,'X17823',0,0),(24,'X17863',0,0),(25,'X589693',0,0),(26,'F78',0,0),(27,'F76',0,0),(28,'45455424012234534564534',0,0),(29,'ddd4464324504040/44',0,0),(30,'A54512SDS',0,0),(31,'dgdgfbbdfbfvdfsgsdfgsdfdzfsf',0,0),(32,'dssfsdfdsfsdf',0,0),(33,'adsdsadasdas',0,0),(34,'sfsffdsfdsfsd',0,0),(35,'dfggfsgsdgs',0,0),(36,'45424242',0,0),(37,'ewrfesfsefsfsd',0,0),(38,'fxvxvxvdvd',0,0),(39,'dasdsadacascscs',0,0),(40,'aszcscsacasc',0,0),(41,'fdgdfgdfgdfg',0,0),(42,'sadasdasdasdasd',0,0),(43,'sfdsfsdfsdfsd',0,0),(44,'dsadadascsascsac',0,0),(45,'aSasXXxXddsfc',0,0),(46,'ASssaXAAdcsfef',0,0),(47,'axaxxXX',0,0),(48,'sdsjdfasjfasnlfnlkasf',0,0),(49,'1234',0,0),(50,'ffdfdsdvdfg',0,0),(51,'dfdgfdgdfg',0,0),(52,'dfdfdsfdsfdsfff',0,0),(53,'hhjuiuyiuyjyyh',0,0),(54,'sfdsfsdfsdf',0,0),(55,'ssdsdasd',0,0),(56,'sxs',0,0),(57,'aZasaZAz',0,0),(58,'sdsadsadas',0,0),(59,'sdasdascsacsavsdf',0,0),(60,'Shsjdjej',0,0),(61,'452567',0,0),(62,'effcce',0,0),(63,'asasaxcsdwq',0,0),(64,'xvvdvdvd',0,0),(65,'wssas',0,0),(66,'124224543',0,0),(67,'ssdsadascs',0,0),(68,'asaxaxasad',0,0),(69,'ssfdsfdscaa',0,0),(70,'vehiculotest',0,0),(71,'vehicleTest',0,0),(72,'sdsdsdascsac',0,0),(73,'dsdascccss',0,0);
/*!40000 ALTER TABLE `vehicles` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-14 19:59:13
