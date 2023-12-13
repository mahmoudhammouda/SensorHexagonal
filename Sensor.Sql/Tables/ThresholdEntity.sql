-- Création de la table ThresholdEntity
CREATE TABLE ThresholdEntity (
    Id INTEGER PRIMARY KEY,   
    IndicatorId INTEGER,     
    SourceId INTEGER,         
    MinValue INTEGER,         
    MaxValue INTEGER,         
    FOREIGN KEY (IndicatorId) REFERENCES IndicatorEntity(Id),
    FOREIGN KEY (SourceId) REFERENCES SourceEntity(Id) 
);