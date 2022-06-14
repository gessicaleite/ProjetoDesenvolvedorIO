CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Fornecedores` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Documento` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Situacao` int NOT NULL,
    `TipoPessoa` int NOT NULL,
    CONSTRAINT `PK_Fornecedores` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

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

CREATE UNIQUE INDEX `IX_Enderecos_IdFornecedor` ON `Enderecos` (`IdFornecedor`);

CREATE UNIQUE INDEX `IX_Fornecedores_Documento` ON `Fornecedores` (`Documento`);

CREATE INDEX `IX_Produtos_IdFornecedor` ON `Produtos` (`IdFornecedor`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220601165828_first-migration', '5.0.17');

COMMIT;

