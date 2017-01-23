-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           10.1.17-MariaDB - mariadb.org binary distribution
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Copiando estrutura do banco de dados para caravell
CREATE DATABASE IF NOT EXISTS `caravell` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `caravell`;


-- Copiando estrutura para tabela caravell.enderecos
CREATE TABLE IF NOT EXISTS `enderecos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `logradouro` varchar(255) NOT NULL DEFAULT '0',
  `bairro` varchar(100) NOT NULL DEFAULT '0',
  `cidade` varchar(100) NOT NULL DEFAULT '0',
  `estado` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela caravell.enderecos: ~0 rows (aproximadamente)
DELETE FROM `enderecos`;
/*!40000 ALTER TABLE `enderecos` DISABLE KEYS */;
INSERT INTO `enderecos` (`id`, `logradouro`, `bairro`, `cidade`, `estado`) VALUES
	(2, 'José Alexandre de Farias, 634', 'Bancários', 'João Pessoa', 'PB');
/*!40000 ALTER TABLE `enderecos` ENABLE KEYS */;


-- Copiando estrutura para tabela caravell.itens_mercadoria
CREATE TABLE IF NOT EXISTS `itens_mercadoria` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_mercadoria` int(11) NOT NULL DEFAULT '0',
  `id_medida` int(11) NOT NULL DEFAULT '0',
  `valor_compra` decimal(10,0) NOT NULL DEFAULT '0',
  `margem_lucro` decimal(10,0) NOT NULL DEFAULT '0',
  `data_entrada` datetime DEFAULT NULL,
  `quantidade` decimal(10,0) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `FKitens_mercadoria_mercadorias` (`id_mercadoria`),
  KEY `FKitens_mercadoria_medidas` (`id_medida`),
  CONSTRAINT `FKitens_mercadoria_medidas` FOREIGN KEY (`id_medida`) REFERENCES `medidas` (`id`),
  CONSTRAINT `FKitens_mercadoria_mercadorias` FOREIGN KEY (`id_mercadoria`) REFERENCES `mercadorias` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela caravell.itens_mercadoria: ~0 rows (aproximadamente)
DELETE FROM `itens_mercadoria`;
/*!40000 ALTER TABLE `itens_mercadoria` DISABLE KEYS */;
/*!40000 ALTER TABLE `itens_mercadoria` ENABLE KEYS */;


-- Copiando estrutura para tabela caravell.itens_pedido
CREATE TABLE IF NOT EXISTS `itens_pedido` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_pedido` int(11) NOT NULL DEFAULT '0',
  `id_item_mercadoria` int(11) NOT NULL DEFAULT '0',
  `quantidade` int(11) NOT NULL DEFAULT '0',
  `valor_venda` decimal(10,0) NOT NULL DEFAULT '0',
  `valor_final` decimal(10,0) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `FKitens_pedido_pedido` (`id_pedido`),
  KEY `FKitens_pedido_item_mercadoria` (`id_item_mercadoria`),
  CONSTRAINT `FKitens_pedido_item_mercadoria` FOREIGN KEY (`id_item_mercadoria`) REFERENCES `itens_mercadoria` (`id`),
  CONSTRAINT `FKitens_pedido_pedido` FOREIGN KEY (`id_pedido`) REFERENCES `pedidos` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela caravell.itens_pedido: ~0 rows (aproximadamente)
DELETE FROM `itens_pedido`;
/*!40000 ALTER TABLE `itens_pedido` DISABLE KEYS */;
/*!40000 ALTER TABLE `itens_pedido` ENABLE KEYS */;


-- Copiando estrutura para tabela caravell.medidas
CREATE TABLE IF NOT EXISTS `medidas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL DEFAULT '0',
  `sigla` varchar(5) NOT NULL DEFAULT '0',
  `ativo` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela caravell.medidas: ~4 rows (aproximadamente)
DELETE FROM `medidas`;
/*!40000 ALTER TABLE `medidas` DISABLE KEYS */;
INSERT INTO `medidas` (`id`, `nome`, `sigla`, `ativo`) VALUES
	(1, 'QUILOGRAMA', 'KG', b'1'),
	(2, 'UNIDADE', 'UND', b'1'),
	(3, 'METRO', 'M', b'1'),
	(4, 'GRAMA', 'G', b'1');
/*!40000 ALTER TABLE `medidas` ENABLE KEYS */;


-- Copiando estrutura para tabela caravell.mercadorias
CREATE TABLE IF NOT EXISTS `mercadorias` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL DEFAULT '0',
  `descricao` varchar(255) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela caravell.mercadorias: ~0 rows (aproximadamente)
DELETE FROM `mercadorias`;
/*!40000 ALTER TABLE `mercadorias` DISABLE KEYS */;
/*!40000 ALTER TABLE `mercadorias` ENABLE KEYS */;


-- Copiando estrutura para tabela caravell.pedidos
CREATE TABLE IF NOT EXISTS `pedidos` (
  `id` int(11) NOT NULL,
  `id_pessoa` int(11) NOT NULL,
  `data_pedido` datetime NOT NULL,
  `informacoes_adicionais` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FKpedidos_pessoas` (`id_pessoa`),
  CONSTRAINT `FKpedidos_pessoas` FOREIGN KEY (`id_pessoa`) REFERENCES `pessoas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela caravell.pedidos: ~0 rows (aproximadamente)
DELETE FROM `pedidos`;
/*!40000 ALTER TABLE `pedidos` DISABLE KEYS */;
/*!40000 ALTER TABLE `pedidos` ENABLE KEYS */;


-- Copiando estrutura para tabela caravell.pessoas
CREATE TABLE IF NOT EXISTS `pessoas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_endereco` int(11) DEFAULT '0',
  `ddd1` int(11) DEFAULT '0',
  `telefone1` int(11) DEFAULT '0',
  `ddd2` int(11) DEFAULT '0',
  `telefone2` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `FKpessoas_enderecos` (`id_endereco`),
  CONSTRAINT `FKpessoas_enderecos` FOREIGN KEY (`id_endereco`) REFERENCES `enderecos` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela caravell.pessoas: ~0 rows (aproximadamente)
DELETE FROM `pessoas`;
/*!40000 ALTER TABLE `pessoas` DISABLE KEYS */;
INSERT INTO `pessoas` (`id`, `id_endereco`, `ddd1`, `telefone1`, `ddd2`, `telefone2`) VALUES
	(2, 2, 83, 988588449, 83, 32351812);
/*!40000 ALTER TABLE `pessoas` ENABLE KEYS */;


-- Copiando estrutura para tabela caravell.pessoas_fisicas
CREATE TABLE IF NOT EXISTS `pessoas_fisicas` (
  `id_pessoa` int(11) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `rg` varchar(10) NOT NULL,
  `cpf` varchar(14) NOT NULL,
  `data_nascimento` date NOT NULL,
  `email` varchar(50) NOT NULL,
  PRIMARY KEY (`id_pessoa`),
  CONSTRAINT `FKpessoas_fisicas_pessoas` FOREIGN KEY (`id_pessoa`) REFERENCES `pessoas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela caravell.pessoas_fisicas: ~0 rows (aproximadamente)
DELETE FROM `pessoas_fisicas`;
/*!40000 ALTER TABLE `pessoas_fisicas` DISABLE KEYS */;
INSERT INTO `pessoas_fisicas` (`id_pessoa`, `nome`, `rg`, `cpf`, `data_nascimento`, `email`) VALUES
	(2, 'Daniel Xavier Cardoso', '3063806', '07216791452', '1987-01-17', 'daniellxc@gmail.com');
/*!40000 ALTER TABLE `pessoas_fisicas` ENABLE KEYS */;


-- Copiando estrutura para tabela caravell.pessoas_juridicas
CREATE TABLE IF NOT EXISTS `pessoas_juridicas` (
  `id_pessoa` int(11) NOT NULL,
  `razao_social` varchar(100) NOT NULL,
  `nome_fantasia` varchar(100) NOT NULL,
  `cnpj` varchar(20) NOT NULL,
  `inscricao_municipal` varchar(20) NOT NULL,
  `inscricao_estadual` varchar(20) NOT NULL,
  PRIMARY KEY (`id_pessoa`),
  CONSTRAINT `FKpessoas_juridicas_pessoas` FOREIGN KEY (`id_pessoa`) REFERENCES `pessoas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela caravell.pessoas_juridicas: ~0 rows (aproximadamente)
DELETE FROM `pessoas_juridicas`;
/*!40000 ALTER TABLE `pessoas_juridicas` DISABLE KEYS */;
/*!40000 ALTER TABLE `pessoas_juridicas` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
