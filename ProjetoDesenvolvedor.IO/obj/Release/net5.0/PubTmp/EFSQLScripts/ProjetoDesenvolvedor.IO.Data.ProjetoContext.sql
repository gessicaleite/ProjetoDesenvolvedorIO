CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220601165828_first-migration') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220601165828_first-migration') THEN

    CREATE TABLE `Fornecedores` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Documento` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `Situacao` int NOT NULL,
        `TipoPessoa` int NOT NULL,
        CONSTRAINT `PK_Fornecedores` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220601165828_first-migration') THEN

    CREATE TABLE `Enderecos` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Rua` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Numero` int NOT NULL,
        `Cidade` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Estado` int NOT NULL,
        `IdFornecedor` int NOT NULL,
        CONSTRAINT `PK_Enderecos` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Enderecos_Fornecedores_IdFornecedor` FOREIGN KEY (`IdFornecedor`) REFERENCES `Fornecedores` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220601165828_first-migration') THEN

    CREATE TABLE `Produtos` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Valor` double NOT NULL,
        `Situacao` int NOT NULL,
        `Descricao` longtext CHARACTER SET utf8mb4 NOT NULL,
        `DataCadastro` datetime(6) NOT NULL,
        `Imagem` longtext CHARACTER SET utf8mb4 NULL,
        `IdFornecedor` int NOT NULL,
        CONSTRAINT `PK_Produtos` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Produtos_Fornecedores_IdFornecedor` FOREIGN KEY (`IdFornecedor`) REFERENCES `Fornecedores` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220601165828_first-migration') THEN

    CREATE UNIQUE INDEX `IX_Enderecos_IdFornecedor` ON `Enderecos` (`IdFornecedor`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220601165828_first-migration') THEN

    CREATE UNIQUE INDEX `IX_Fornecedores_Documento` ON `Fornecedores` (`Documento`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220601165828_first-migration') THEN

    CREATE INDEX `IX_Produtos_IdFornecedor` ON `Produtos` (`IdFornecedor`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220601165828_first-migration') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20220601165828_first-migration', '5.0.17');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

