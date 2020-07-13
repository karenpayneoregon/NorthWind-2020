SELECT O.OrderID, 
       O.CustomerIdentifier, 
       O.EmployeeID, 
       O.OrderDate, 
       O.RequiredDate, 
       O.ShippedDate, 
       O.ShipVia, 
       S.CompanyName AS Shipper, 
       O.Freight, 
       O.ShipAddress, 
       O.ShipCity, 
       O.ShipRegion, 
       O.ShipPostalCode, 
       O.ShipCountry, 
       S.Phone AS ShipperPhone, 
       CT.ContactTitle AS EmployeeTitle, 
       E.LastName, 
       E.FirstName
FROM Orders AS O
     INNER JOIN Shippers AS S ON O.ShipVia = S.ShipperID
     INNER JOIN Employees AS E ON O.EmployeeID = E.EmployeeID
     INNER JOIN ContactType AS CT ON E.ContactTypeIdentifier = CT.ContactTypeIdentifier;
