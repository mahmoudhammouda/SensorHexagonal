-- Création de la table MeasureEntity
CREATE TABLE MeasureEntity (
    Id INTEGER PRIMARY KEY,   
    IndicatorId INTEGER,      
    SourceId INTEGER,         
    Value TEXT,               
    Unity TEXT,               
    ObservationTime TEXT,     
    FOREIGN KEY (IndicatorId) REFERENCES IndicatorEntity(Id),
    FOREIGN KEY (SourceId) REFERENCES SourceEntity(Id)
);