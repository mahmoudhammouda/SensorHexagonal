-- Création de la table IndicatorEntity
CREATE TABLE IndicatorEntity (
    Id INTEGER PRIMARY KEY,   -- Clé primaire, auto-incrémentée
    Name TEXT NOT NULL,       -- Nom de l'indicateur
    Description TEXT,         -- Description
    Category TEXT,            -- Catégorie
    Type TEXT                 -- Type
);