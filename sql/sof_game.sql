-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.6.9-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for rxjh_game
CREATE DATABASE IF NOT EXISTS `rxjh_game` /*!40100 DEFAULT CHARACTER SET utf8mb3 */;
USE `rxjh_game`;

-- Dumping structure for table rxjh_game.player
CREATE TABLE IF NOT EXISTS `player` (
  `id` int(11) NOT NULL,
  `account_id` int(11) NOT NULL,
  `account_name` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `index` int(11) NOT NULL,
  `level` int(11) NOT NULL,
  `exp` bigint(20) NOT NULL DEFAULT 0,
  `online` tinyint(1) NOT NULL DEFAULT 0,
  `job` int(11) DEFAULT NULL,
  `job_level` int(11) NOT NULL DEFAULT 0,
  `x` float NOT NULL,
  `y` float NOT NULL,
  `z` float NOT NULL,
  `money` bigint(20) NOT NULL DEFAULT 0,
  `title` int(2) DEFAULT NULL,
  `hp` int(11) DEFAULT NULL,
  `mp` int(11) DEFAULT NULL,
  `sp` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `name_unique` (`name`) USING BTREE,
  KEY `account_id` (`account_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 ROW_FORMAT=DYNAMIC;

-- Dumping data for table rxjh_game.player: ~0 rows (approximately)
/*!40000 ALTER TABLE `player` DISABLE KEYS */;
/*!40000 ALTER TABLE `player` ENABLE KEYS */;

-- Dumping structure for table rxjh_game.player_data
CREATE TABLE IF NOT EXISTS `player_data` (
  `player_id` int(11) NOT NULL,
  `force` int(2) NOT NULL,
  `hair_style` int(2) NOT NULL,
  `hair_color` int(2) NOT NULL,
  `face` int(2) NOT NULL,
  `voice` int(2) NOT NULL,
  `gender` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Dumping data for table rxjh_game.player_data: ~0 rows (approximately)
/*!40000 ALTER TABLE `player_data` DISABLE KEYS */;
/*!40000 ALTER TABLE `player_data` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
