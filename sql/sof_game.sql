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


-- Dumping database structure for sof_game
CREATE DATABASE IF NOT EXISTS `sof_game` /*!40100 DEFAULT CHARACTER SET utf8mb3 */;
USE `sof_game`;

-- Dumping structure for table sof_game.inventory
CREATE TABLE IF NOT EXISTS `inventory` (
  `id` int(11) NOT NULL DEFAULT 0,
  `player_id` int(11) NOT NULL DEFAULT 0,
  `inventory_type` enum('Item','Orb','Pet') DEFAULT NULL,
  `item_id` bigint(20) NOT NULL DEFAULT 0,
  `quanty` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Data exporting was unselected.

-- Dumping structure for table sof_game.player
CREATE TABLE IF NOT EXISTS `player` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account_id` int(11) NOT NULL,
  `account_name` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `index` int(11) NOT NULL,
  `level` int(11) NOT NULL DEFAULT 1,
  `exp` bigint(20) NOT NULL DEFAULT 0,
  `online` tinyint(1) NOT NULL DEFAULT 0,
  `job` int(11) DEFAULT NULL,
  `job_level` int(11) NOT NULL DEFAULT 0,
  `map_id` int(11) NOT NULL DEFAULT 0,
  `x` float NOT NULL DEFAULT 0,
  `y` float NOT NULL DEFAULT 0,
  `z` float NOT NULL DEFAULT 0,
  `money` bigint(20) NOT NULL DEFAULT 0,
  `force` int(11) DEFAULT NULL,
  `hair_color` varchar(6) DEFAULT NULL,
  `face` int(11) DEFAULT NULL,
  `voice` int(11) DEFAULT NULL,
  `gender` int(11) DEFAULT NULL,
  `title` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE KEY `name_unique` (`name`) USING BTREE,
  KEY `account_id` (`account_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3 ROW_FORMAT=DYNAMIC COMMENT='player data';

-- Data exporting was unselected.

-- Dumping structure for table sof_game.player_setting
CREATE TABLE IF NOT EXISTS `player_setting` (
  `player_id` int(11) NOT NULL,
  `partyable` int(1) NOT NULL,
  `tradeable` int(1) NOT NULL,
  `costume_type` int(1) NOT NULL,
  `weapon_switch` int(1) NOT NULL,
  `pet_exp` int(1) NOT NULL,
  `fame_switch` int(1) NOT NULL,
  `hair_switch` int(1) NOT NULL,
  `confestion_switch` int(1) NOT NULL,
  `search_switch` int(1) NOT NULL,
  `vegetable_weapon_switch` int(1) NOT NULL,
  `honor_rank_effect` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COMMENT='player setting data';

-- Data exporting was unselected.

-- Dumping structure for table sof_game.player_stats
CREATE TABLE IF NOT EXISTS `player_stats` (
  `player_id` int(11) NOT NULL DEFAULT 0,
  `accuracy` int(11) NOT NULL DEFAULT 0,
  `attack` int(11) NOT NULL DEFAULT 0,
  `defense` int(11) NOT NULL DEFAULT 0,
  `dodge` int(11) NOT NULL DEFAULT 0,
  `hp` int(11) NOT NULL DEFAULT 0,
  `hp_base` int(11) NOT NULL DEFAULT 0,
  `mp` int(11) NOT NULL DEFAULT 0,
  `mp_base` int(11) NOT NULL DEFAULT 0,
  `sp` int(11) NOT NULL DEFAULT 0,
  `sp_base` int(11) NOT NULL DEFAULT 0,
  `natural_mp_regen` int(11) NOT NULL DEFAULT 0,
  `skill_attack` int(11) NOT NULL DEFAULT 0,
  `skill_defense` int(11) NOT NULL DEFAULT 0,
  `dexterity` int(11) NOT NULL DEFAULT 0,
  `spirit` int(11) NOT NULL DEFAULT 0,
  `stamina` int(11) NOT NULL DEFAULT 0,
  `strength` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Data exporting was unselected.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
