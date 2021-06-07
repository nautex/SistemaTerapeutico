-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.5.8-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para sisdet
CREATE DATABASE IF NOT EXISTS `sisdet` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `sisdet`;

-- Volcando estructura para tabla sisdet.persona
CREATE TABLE IF NOT EXISTS `persona` (
  `IdPersona` int(11) NOT NULL,
  `IdTipoPersona` int(11) DEFAULT NULL,
  `Nombres` varchar(70) NOT NULL,
  `RazonSocial` varchar(200) DEFAULT NULL,
  `FechaIngreso` datetime DEFAULT NULL,
  `IdPaisOrigen` int(11) DEFAULT NULL,
  `IdEstado` int(11) DEFAULT NULL,
  `FechaRegistro` datetime DEFAULT NULL,
  `UsuarioRegistro` varchar(20) DEFAULT NULL,
  `FechaModificacion` datetime DEFAULT NULL,
  `UsuarioModificacion` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`IdPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla sisdet.persona: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `persona` DISABLE KEYS */;
INSERT INTO `persona` (`IdPersona`, `IdTipoPersona`, `Nombres`, `RazonSocial`, `FechaIngreso`, `IdPaisOrigen`, `IdEstado`, `FechaRegistro`, `UsuarioRegistro`, `FechaModificacion`, `UsuarioModificacion`) VALUES
	(1, 0, 'Jorge Sotelo Coa', '', '2021-06-06 00:00:00', 0, 0, '2021-06-06 00:00:00', 'JSOTELO', '2021-06-06 00:00:00', 'JSOTELO');
/*!40000 ALTER TABLE `persona` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
