-- Vérifie si la table MeasureEntity n'existe pas, puis la crée
CREATE TABLE IF NOT EXISTS ThresholdEntity (
    Id INTEGER PRIMARY KEY,   
    IndicatorId INTEGER,      
    SourceId INTEGER,         
    MinValue INTEGER,         
    MaxValue INTEGER,         
    FOREIGN KEY (IndicatorId) REFERENCES IndicatorEntity(Id),
    FOREIGN KEY (SourceId) REFERENCES SourceEntity(Id) 
);