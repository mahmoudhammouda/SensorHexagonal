-- Vérifie si la table IndicatorEntity n'existe pas, puis la crée
CREATE TABLE IF NOT EXISTS IndicatorEntity (
    Id INTEGER PRIMARY KEY,   -- Clé primaire, auto-incrémentée
    Name TEXT NOT NULL,       -- Nom de l'indicateur
    Description TEXT,         -- Description
    Category TEXT,            -- Catégorie
    Type TEXT                 -- Type
);

-- Vérifie si la table SourceEntity n'existe pas, puis la crée
CREATE TABLE IF NOT EXISTS SourceEntity (
    Id INTEGER PRIMARY KEY,   -- Clé primaire, auto-incrémentée
    Name TEXT NOT NULL,       -- Nom de la source
    SourceType TEXT           -- Type de la source
);

-- Vérifie si la table MeasureEntity n'existe pas, puis la crée
CREATE TABLE IF NOT EXISTS MeasureEntity (
    Id INTEGER PRIMARY KEY,   -- Clé primaire, auto-incrémentée
    IndicatorId INTEGER,      -- Clé étrangère vers IndicatorEntity
    SourceId INTEGER,         -- Clé étrangère vers SourceEntity
    Value TEXT,               -- Valeur de la mesure
    Unity TEXT,               -- Unité de mesure
    ObservationTime TEXT,     -- Temps d'observation
    FOREIGN KEY (IndicatorId) REFERENCES IndicatorEntity(Id),
    FOREIGN KEY (SourceId) REFERENCES SourceEntity(Id) 
);