-- Vérifie si la table MeasureEntity n'existe pas, puis la crée
CREATE TABLE IF NOT EXISTS ThresholdEntity (
    Id INTEGER PRIMARY KEY,   -- Clé primaire, auto-incrémentée
    IndicatorId INTEGER,      -- Clé étrangère vers IndicatorEntity
    SourceId INTEGER,         -- Clé étrangère vers SourceEntity
    MinValue INTEGER,         -- Valeur min de la limite
    MaxValue INTEGER,         -- Valeur max de la limite
    FOREIGN KEY (IndicatorId) REFERENCES IndicatorEntity(Id),
    FOREIGN KEY (SourceId) REFERENCES SourceEntity(Id) 
);