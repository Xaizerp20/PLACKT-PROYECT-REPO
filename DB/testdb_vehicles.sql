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

-- Dump completed on 2023-06-14 20:12:10
