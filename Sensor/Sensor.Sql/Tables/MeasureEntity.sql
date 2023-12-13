-- Création de la table MeasureEntity
CREATE TABLE MeasureEntity (
    Id INTEGER PRIMARY KEY,   -- Clé primaire, auto-incrémentée
    IndicatorId INTEGER,      -- Clé étrangère vers IndicatorEntity
    SourceId INTEGER,         -- Clé étrangère vers SourceEntity
    Value TEXT,               -- Valeur de la mesure
    Unity TEXT,               -- Unité de mesure
    ObservationTime TEXT,     -- Temps d'observation
    FOREIGN KEY (IndicatorId) REFERENCES IndicatorEntity(Id),
    FOREIGN KEY (SourceId) REFERENCES SourceEntity(Id)
);