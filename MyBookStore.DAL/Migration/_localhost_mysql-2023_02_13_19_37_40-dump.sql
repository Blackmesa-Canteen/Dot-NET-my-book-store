-- MySQL dump 10.13  Distrib 8.0.31, for macos10.15 (x86_64)
--
-- Host: 127.0.0.1    Database: my_book_store
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Book`
--

DROP TABLE IF EXISTS `Book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Book` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BookId` char(37) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CoverImgUrl` varchar(255) DEFAULT NULL,
  `UserId` varchar(255) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `UpdateDate` datetime DEFAULT NULL,
  `IsRemoved` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Book_pk2` (`BookId`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Book`
--

LOCK TABLES `Book` WRITE;
/*!40000 ALTER TABLE `Book` DISABLE KEYS */;
INSERT INTO `Book` (`Id`, `BookId`, `Name`, `Description`, `CoverImgUrl`, `UserId`, `CreateDate`, `UpdateDate`, `IsRemoved`) VALUES (10,'9b0896fa-3880-4c2e-bfd6-925c87f22878','CQRS for Dummies','CQRS for Dummies',NULL,NULL,'2023-02-13 15:39:05','2023-02-13 15:39:06',_binary '\0'),(11,'0550818d-36ad-4a8d-9c3a-a715bf15de76','Visual Studio Tips','Visual Studio Tips',NULL,NULL,'2023-02-13 15:39:36','2023-02-13 15:39:37',_binary '\0'),(12,'8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1','NHibernate Cookbook','NHibernate Cookbook',NULL,NULL,'2023-02-13 15:40:01','2023-02-13 15:40:02',_binary '\0');
/*!40000 ALTER TABLE `Book` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `User`
--

DROP TABLE IF EXISTS `User`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `User` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Role` int NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `UpdateDate` datetime DEFAULT NULL,
  `IsRemoved` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `User_pk2` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `User`
--

LOCK TABLES `User` WRITE;
/*!40000 ALTER TABLE `User` DISABLE KEYS */;
INSERT INTO `User` (`Id`, `UserId`, `Name`, `Password`, `Role`, `CreateDate`, `UpdateDate`, `IsRemoved`) VALUES (1,'demo@996workers.icu','demo','jVI1KcvlMzIpFb3uJnT5+w==.5UdMqav4hxxGNpK7y3eT+aY4YoZZkLAMxN6divqZY/Y=',1,'2023-02-13 15:38:22','2023-02-13 15:38:24',_binary '\0'),(6,'demo2','demo2','QSWoYaOkUaRr8A1llHgLMw==.fVUu/Ye2DjALOZSxX0mekDLcTDqBr5D+i35xqNltEzE=',1,'2023-02-13 17:00:41',NULL,_binary '\0'),(7,'demo3','demo3','dS0qrCIyoDtxhije9Gk5CA==.R4GZMXXGt2Y6rYiWwyQSQUgq7pDqyj3Wo9Vsvsi0bu0=',1,'2023-02-13 17:01:44',NULL,_binary '\0');
/*!40000 ALTER TABLE `User` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-02-13 19:37:40
