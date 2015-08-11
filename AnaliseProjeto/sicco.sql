-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           5.5.28 - MySQL Community Server (GPL)
-- OS do Servidor:               Win32
-- HeidiSQL Versão:              9.1.0.4867
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Copiando estrutura do banco de dados para sicco
CREATE DATABASE IF NOT EXISTS `sicco` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `sicco`;


-- Copiando estrutura para tabela sicco.tb_bem
CREATE TABLE IF NOT EXISTS `tb_bem` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `valor` float DEFAULT NULL,
  `dataCompra` datetime NOT NULL,
  `dataVenda` datetime DEFAULT NULL,
  `idTipoBem` int(11) NOT NULL,
  `idStatus` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_TB_Bem_TB_TipoBem1_idx` (`idTipoBem`),
  KEY `fk_TB_Bem_TB_Status1_idx` (`idStatus`),
  CONSTRAINT `fk_TB_Bem_TB_Status1` FOREIGN KEY (`idStatus`) REFERENCES `tb_status` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_TB_Bem_TB_TipoBem1` FOREIGN KEY (`idTipoBem`) REFERENCES `tb_tipobem` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_cor
CREATE TABLE IF NOT EXISTS `tb_cor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipoCor` varchar(20) NOT NULL COMMENT 'tipo_cor - ex: metalico, fosco, florescente, basico, comum',
  `cor` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_custo
CREATE TABLE IF NOT EXISTS `tb_custo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `valor` float NOT NULL,
  `idPessoa` int(11) NOT NULL,
  `idTipoCusto` int(11) NOT NULL,
  `idBem` int(11) NOT NULL,
  `idEmpresa` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_tb_custos_tb_pessoa1_idx` (`idPessoa`),
  KEY `fk_tb_custos_tb_tipoCusto1_idx` (`idTipoCusto`),
  KEY `fk_tb_custos_TB_Bem1_idx` (`idBem`),
  KEY `fk_Tb_Custo_TB_Empresa1_idx` (`idEmpresa`),
  CONSTRAINT `fk_tb_custos_TB_Bem1` FOREIGN KEY (`idBem`) REFERENCES `tb_bem` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_custos_tb_pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `tb_pessoa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_custos_tb_tipoCusto1` FOREIGN KEY (`idTipoCusto`) REFERENCES `tb_tipocusto` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Tb_Custo_TB_Empresa1` FOREIGN KEY (`idEmpresa`) REFERENCES `tb_empresa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_empresa
CREATE TABLE IF NOT EXISTS `tb_empresa` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeFantasia` varchar(45) DEFAULT NULL,
  `cnpj` varchar(17) DEFAULT NULL,
  `status` varchar(8) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_formapagamento
CREATE TABLE IF NOT EXISTS `tb_formapagamento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `formaPagamento` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_marca
CREATE TABLE IF NOT EXISTS `tb_marca` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `marca` varchar(30) NOT NULL,
  `tipo` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_modelo
CREATE TABLE IF NOT EXISTS `tb_modelo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoiaModelo` varchar(45) NOT NULL,
  `tipoModelo` varchar(25) NOT NULL,
  `descricao` varchar(45) NOT NULL,
  `anoModelo` varchar(9) NOT NULL,
  `idMarca` int(11) NOT NULL,
  `idTipoCompustivel` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_tb_modelo_tb_Marca1_idx` (`idMarca`),
  KEY `fk_TB_Modelo_TB_TipoCombustivel1_idx` (`idTipoCompustivel`),
  CONSTRAINT `fk_tb_modelo_tb_Marca1` FOREIGN KEY (`idMarca`) REFERENCES `tb_marca` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_TB_Modelo_TB_TipoCombustivel1` FOREIGN KEY (`idTipoCompustivel`) REFERENCES `tb_tipocombustivel` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_negociacao
CREATE TABLE IF NOT EXISTS `tb_negociacao` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `valor` double NOT NULL,
  `status` varchar(10) DEFAULT NULL,
  `dataInicio` datetime DEFAULT NULL,
  `dataFim` datetime DEFAULT NULL,
  `validadeProposta` datetime DEFAULT NULL,
  `valorPropostoVendedor` float DEFAULT NULL,
  `valorPropostoCliente` float DEFAULT NULL,
  `observacao` varchar(200) DEFAULT NULL,
  `idTipoNegociacao` int(11) NOT NULL,
  `idBem` int(11) NOT NULL,
  `idPessoaCliente` int(11) NOT NULL,
  `idPessoaVendedor` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_tb_negociacao_TB_TipoNegociacao1_idx` (`idTipoNegociacao`),
  KEY `fk_Tb_Negociacao_TB_Bem1_idx` (`idBem`),
  KEY `fk_TB_Negociacao_TB_Pessoa1_idx` (`idPessoaCliente`),
  KEY `fk_TB_Negociacao_TB_Pessoa2_idx` (`idPessoaVendedor`),
  CONSTRAINT `fk_Tb_Negociacao_TB_Bem1` FOREIGN KEY (`idBem`) REFERENCES `tb_bem` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_TB_Negociacao_TB_Pessoa1` FOREIGN KEY (`idPessoaCliente`) REFERENCES `tb_pessoa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_TB_Negociacao_TB_Pessoa2` FOREIGN KEY (`idPessoaVendedor`) REFERENCES `tb_pessoa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_negociacao_TB_TipoNegociacao1` FOREIGN KEY (`idTipoNegociacao`) REFERENCES `tb_tiponegociacao` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_pagamento
CREATE TABLE IF NOT EXISTS `tb_pagamento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idNegociacao` int(11) NOT NULL,
  `idFormaPagamento` int(11) NOT NULL,
  `valor` float DEFAULT NULL,
  `valorPago` float NOT NULL,
  `juro` float DEFAULT NULL,
  `descricao` varchar(70) DEFAULT NULL,
  `dataPagamento` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_TB_Pagamentos_tb_negociacao1_idx` (`idNegociacao`),
  KEY `fk_TB_Pagamento_TB_FormaPagamento1_idx` (`idFormaPagamento`),
  CONSTRAINT `fk_TB_Pagamentos_tb_negociacao1` FOREIGN KEY (`idNegociacao`) REFERENCES `tb_negociacao` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_TB_Pagamento_TB_FormaPagamento1` FOREIGN KEY (`idFormaPagamento`) REFERENCES `tb_formapagamento` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_pessoa
CREATE TABLE IF NOT EXISTS `tb_pessoa` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `sobreNome` varchar(45) NOT NULL,
  `cpfCnpj` varchar(14) NOT NULL,
  `rg` varchar(25) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `cidade` varchar(45) NOT NULL,
  `estado` varchar(25) NOT NULL,
  `cep` varchar(10) NOT NULL,
  `fone` varchar(12) DEFAULT NULL,
  `celular` varchar(12) DEFAULT NULL,
  `sexo` varchar(1) NOT NULL,
  `nascimento` varchar(10) NOT NULL,
  `endereco` varchar(45) NOT NULL,
  `idEmpresa` int(11) NOT NULL,
  `idTipoPessoa` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `CPF_pessoa_UNIQUE` (`cpfCnpj`),
  KEY `fk_TB_Pessoa_TB_Empresa1_idx` (`idEmpresa`),
  KEY `fk_TB_Pessoa_TB_TipoUsuario1_idx` (`idTipoPessoa`),
  CONSTRAINT `fk_TB_Pessoa_TB_Empresa1` FOREIGN KEY (`idEmpresa`) REFERENCES `tb_empresa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_TB_Pessoa_TB_TipoUsuario1` FOREIGN KEY (`idTipoPessoa`) REFERENCES `tb_tipopessoa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_status
CREATE TABLE IF NOT EXISTS `tb_status` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_tipobem
CREATE TABLE IF NOT EXISTS `tb_tipobem` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipoBem` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_tipocombustivel
CREATE TABLE IF NOT EXISTS `tb_tipocombustivel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipoCombustivel` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_tipocusto
CREATE TABLE IF NOT EXISTS `tb_tipocusto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipoCusto` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_tiponegociacao
CREATE TABLE IF NOT EXISTS `tb_tiponegociacao` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipoNegociacao` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `tipoNegociacao_UNIQUE` (`tipoNegociacao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_tipopessoa
CREATE TABLE IF NOT EXISTS `tb_tipopessoa` (
  `id` int(11) NOT NULL,
  `tipoPessoa` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_usuario
CREATE TABLE IF NOT EXISTS `tb_usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `login` varchar(15) NOT NULL,
  `senha` varchar(45) NOT NULL,
  `TB_Pessoa_id` int(11) NOT NULL,
  `TB_Empresa_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_TB_Usuario_TB_Pessoa1_idx` (`TB_Pessoa_id`),
  KEY `fk_TB_Usuario_TB_Empresa1_idx` (`TB_Empresa_id`),
  CONSTRAINT `fk_TB_Usuario_TB_Empresa1` FOREIGN KEY (`TB_Empresa_id`) REFERENCES `tb_empresa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_TB_Usuario_TB_Pessoa1` FOREIGN KEY (`TB_Pessoa_id`) REFERENCES `tb_pessoa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sicco.tb_veiculo
CREATE TABLE IF NOT EXISTS `tb_veiculo` (
  `id` varchar(45) NOT NULL,
  `placa` varchar(7) NOT NULL,
  `chassi` varchar(45) NOT NULL,
  `idConcessionaria` int(11) NOT NULL,
  `idModelo` int(11) NOT NULL,
  `idCor` int(11) NOT NULL,
  `idBem` int(11) NOT NULL,
  `idEmpresa` int(11) NOT NULL,
  `lote` int(11) DEFAULT NULL COMMENT 'Os lotes dos veiculos iram ser um interiro que pode ser nullo caso o veiculo nao faca parte de um lote.\n',
  PRIMARY KEY (`id`),
  KEY `fk_tb_veiculo_tb_modelo1_idx` (`idModelo`),
  KEY `fk_tb_veiculo_tb_Cor1_idx` (`idCor`),
  KEY `fk_tb_veiculo_TB_Bem1_idx` (`idBem`),
  KEY `fk_TB_Veiculo_TB_Empresa1_idx` (`idEmpresa`),
  CONSTRAINT `fk_tb_veiculo_TB_Bem1` FOREIGN KEY (`idBem`) REFERENCES `tb_bem` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_veiculo_tb_Cor1` FOREIGN KEY (`idCor`) REFERENCES `tb_cor` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_TB_Veiculo_TB_Empresa1` FOREIGN KEY (`idEmpresa`) REFERENCES `tb_empresa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_veiculo_tb_modelo1` FOREIGN KEY (`idModelo`) REFERENCES `tb_modelo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
