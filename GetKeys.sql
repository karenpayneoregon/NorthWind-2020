DECLARE @TableName nvarchar(50) = 'Employees'

SELECT obj.name AS fk_name, 
       sch.name AS schema_name, 
       tab1.name AS [table], 
       col1.name AS [column], 
       tab2.name AS referenced_table, 
       col2.name AS referenced_column
FROM sys.foreign_key_columns AS fkc
     INNER JOIN sys.objects AS obj ON obj.object_id = fkc.constraint_object_id
     INNER JOIN sys.tables AS tab1 ON tab1.object_id = fkc.parent_object_id
     INNER JOIN sys.schemas AS sch ON tab1.schema_id = sch.schema_id
     INNER JOIN sys.columns AS col1 ON col1.column_id = fkc.parent_column_id
                                       AND col1.object_id = tab1.object_id
     INNER JOIN sys.tables AS tab2 ON tab2.object_id = fkc.referenced_object_id
     INNER JOIN sys.columns AS col2 ON col2.column_id = fkc.referenced_column_id
                                       AND col2.object_id = tab2.object_id
     INNER JOIN sys.types AS TY ON col1.system_type_id = TY.system_type_id
                                   AND col1.user_type_id = TY.user_type_id
                                   AND tab1.name = @TableName;
SELECT pk.name AS pk_name, 
       SCHEMA_NAME(tab.schema_id) AS schema_name, 
       tab.name AS table_name, 
       ic.index_column_id AS column_id, 
       col.name AS column_name
FROM sys.tables AS tab
     INNER JOIN sys.indexes AS pk ON tab.object_id = pk.object_id
                                     AND pk.is_primary_key = 1
     INNER JOIN sys.index_columns AS ic ON ic.object_id = pk.object_id
                                           AND ic.index_id = pk.index_id
     INNER JOIN sys.columns AS col ON pk.object_id = col.object_id
                                      AND col.column_id = ic.column_id
WHERE tab.name = @TableName
ORDER BY schema_name, 
         pk_name, 
         column_id;