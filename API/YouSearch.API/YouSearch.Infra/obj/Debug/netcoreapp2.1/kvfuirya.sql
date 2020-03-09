  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
__EFMigrationsHistory' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

CREATE TABLE `PageInfo` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `totalResults` int NOT NULL,
    `resultsPerPage` int NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Thumbnail` (
    `Height` bigint NULL,
    `Url` text NULL,
    `Width` bigint NULL,
    `ETag` text NULL,
    `Id` int NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `ThumbnailDetails` (
    `Default__Id` int NULL,
    `HighId` int NULL,
    `MaxresId` int NULL,
    `MediumId` int NULL,
    `StandardId` int NULL,
    `ETag` text NULL,
    `Id` int NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ThumbnailDetails_Thumbnail_Default__Id` FOREIGN KEY (`Default__Id`) REFERENCES `Thumbnail` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_ThumbnailDetails_Thumbnail_HighId` FOREIGN KEY (`HighId`) REFERENCES `Thumbnail` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_ThumbnailDetails_Thumbnail_MaxresId` FOREIGN KEY (`MaxresId`) REFERENCES `Thumbnail` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_ThumbnailDetails_Thumbnail_MediumId` FOREIGN KEY (`MediumId`) REFERENCES `Thumbnail` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_ThumbnailDetails_Thumbnail_StandardId` FOREIGN KEY (`StandardId`) REFERENCES `Thumbnail` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `SearchResultSnippet` (
    `ChannelId` text NULL,
    `ChannelTitle` text NULL,
    `Description` text NULL,
    `LiveBroadcastContent` text NULL,
    `PublishedAtRaw` text NULL,
    `PublishedAt` datetime NULL,
    `ThumbnailsId` int NULL,
    `Title` text NULL,
    `ETag` text NULL,
    `Id` int NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_SearchResultSnippet_ThumbnailDetails_ThumbnailsId` FOREIGN KEY (`ThumbnailsId`) REFERENCES `ThumbnailDetails` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `SearchResponse` (
    `Kind` text NULL,
    `ETag` text NULL,
    `SnippetId` int NULL,
    `Id` int NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_SearchResponse_SearchResultSnippet_SnippetId` FOREIGN KEY (`SnippetId`) REFERENCES `SearchResultSnippet` (`Id`) ON DELETE RESTRICT
);

CREATE INDEX `IX_SearchResponse_SnippetId` ON `SearchResponse` (`SnippetId`);

CREATE INDEX `IX_SearchResultSnippet_ThumbnailsId` ON `SearchResultSnippet` (`ThumbnailsId`);

CREATE INDEX `IX_ThumbnailDetails_Default__Id` ON `ThumbnailDetails` (`Default__Id`);

CREATE INDEX `IX_ThumbnailDetails_HighId` ON `ThumbnailDetails` (`HighId`);

CREATE INDEX `IX_ThumbnailDetails_MaxresId` ON `ThumbnailDetails` (`MaxresId`);

CREATE INDEX `IX_ThumbnailDetails_MediumId` ON `ThumbnailDetails` (`MediumId`);

CREATE INDEX `IX_ThumbnailDetails_StandardId` ON `ThumbnailDetails` (`StandardId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200309221725_inicial', '2.1.3-rtm-32065');

