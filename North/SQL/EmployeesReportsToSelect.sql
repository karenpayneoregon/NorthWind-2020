
SELECT Employees.FirstName, 
       Employees.LastName, 
       manager.FirstName + ' ' + manager.LastName AS Manager
FROM Employees
     LEFT OUTER JOIN Employees AS manager ON Employees.ReportsTo = manager.EmployeeID
WHERE Employees.ReportsTo IS NOT NULL;