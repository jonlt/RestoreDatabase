RESTORE DATABASE [{0}] 
FROM 
 {1} 
WITH FILE = 1, 
MOVE N'{2}' TO N'{3}',  
MOVE N'{2}_log' TO N'{4}',  
NOUNLOAD,  
REPLACE,  
STATS = 5;


