SELECT P.ProductID, 
       P.ProductName, 
       P.SupplierID, 
       S.CompanyName, 
       P.CategoryID, 
       C.CategoryName, 
       P.QuantityPerUnit, 
       P.UnitPrice, 
       P.UnitsInStock, 
       P.UnitsOnOrder, 
       P.ReorderLevel, 
       P.Discontinued, 
       P.DiscontinuedDate
FROM Products AS P
     INNER JOIN Suppliers AS S ON P.SupplierID = S.SupplierID
     INNER JOIN Categories AS C ON P.CategoryID = C.CategoryID
ORDER BY P.CategoryID, 
         P.ProductName;