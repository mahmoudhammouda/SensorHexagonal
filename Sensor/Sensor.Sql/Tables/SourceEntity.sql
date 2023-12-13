-- Création de la table SourceEntity
CREATE TABLE SourceEntity (
    Id INTEGER PRIMARY KEY,   -- Clé primaire, auto-incrémentée
    Name TEXT NOT NULL,       -- Nom de la source
    SourceType TEXT           -- Type de la source
);