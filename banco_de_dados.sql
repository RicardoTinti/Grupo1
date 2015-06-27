CREATE TABLE `corredor` (
  `idCorredor` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `data_nascimento` datetime DEFAULT NULL,
  `cidade` varchar(45) DEFAULT NULL,
  `estado` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idCorredor`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

CREATE TABLE `corrida` (
  `idCorrida` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `descricao` varchar(200) DEFAULT NULL,
  `data_corrida` datetime DEFAULT NULL,
  `cidade` varchar(45) DEFAULT NULL,
  `estado` varchar(45) DEFAULT NULL,
  `valor` double DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idCorrida`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

CREATE TABLE `inscricao` (
  `Corredor_idCorredor` int(11) NOT NULL,
  `Corrida_idCorrida` int(11) NOT NULL,
  `idInscricao` int(11) NOT NULL AUTO_INCREMENT,
  `status_pagamento` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Corredor_idCorredor`,`Corrida_idCorrida`,`idInscricao`),
  UNIQUE KEY `idInscricao_UNIQUE` (`idInscricao`),
  KEY `fk_Corredor_has_Corrida_Corredor` (`Corredor_idCorredor`),
  KEY `fk_Corredor_has_Corrida_Corrida1` (`Corrida_idCorrida`),
  CONSTRAINT `fk_Corredor_has_Corrida_Corredor` FOREIGN KEY (`Corredor_idCorredor`) REFERENCES `corredor` (`idCorredor`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Corredor_has_Corrida_Corrida1` FOREIGN KEY (`Corrida_idCorrida`) REFERENCES `corrida` (`idCorrida`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;




----------------Insercao de Dados
INSERT INTO `webservice`.`corredor`
(`nome`,`data_nascimento`,`cidade`,`estado`,`status`)
VALUES
('Maria', '1990-06-12 02:04:18', 'Florianópolis', 'SC','Ativo');

INSERT INTO `webservice`.`corredor`
(`nome`,`data_nascimento`,`cidade`,`estado`,`status`)
VALUES
('João', '1990-06-01 02:04:18', 'Florianópolis', 'SC','Ativo');

INSERT INTO `webservice`.`corredor`
(`nome`,`data_nascimento`,`cidade`,`estado`,`status`)
VALUES
('José', '1990-03-12 02:04:18', 'São José', 'SC','Ativo');


INSERT INTO `webservice`.`corrida`
(`nome`,`descricao`,`data_corrida`,`cidade`,`estado`,`valor`,`status`)
VALUES
('Corrida da Paz','Corrida na Beira-Mar', '2015-07-01 07:00:00', 'Florianópolis', 'SC', 120, 'Agendada');

INSERT INTO `webservice`.`corrida`
(`nome`,`descricao`,`data_corrida`,`cidade`,`estado`,`valor`,`status`)
VALUES
('Corrida Outubro Rosa','Corrida Atravessando a Ponte', '2015-10-01 07:00:00', 'Florianópolis', 'SC', 90, 'Agendada');

INSERT INTO `webservice`.`corrida`
(`nome`,`descricao`,`data_corrida`,`cidade`,`estado`,`valor`,`status`)
VALUES
('Corrida Oktober','Corrida de Alemão', '2015-10-15 07:00:00', 'Florianópolis', 'SC', 90, 'Agendada');


INSERT INTO `webservice`.`inscricao`
(`Corredor_idCorredor`,`Corrida_idCorrida`,`status_pagamento`)
VALUES
(1,1,'Pago');

INSERT INTO `webservice`.`inscricao`
(`Corredor_idCorredor`,`Corrida_idCorrida`,`status_pagamento`)
VALUES
(2,1,'Pago');

INSERT INTO `webservice`.`inscricao`
(`Corredor_idCorredor`,`Corrida_idCorrida`,`status_pagamento`)
VALUES
(1,2,'Pago');



