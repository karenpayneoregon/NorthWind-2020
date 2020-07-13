SELECT C.CustomerIdentifier, 
       C.CompanyName, 
       C.ContactId, 
       C.Street, 
       C.City, 
       C.Region, 
       C.PostalCode, 
       C.CountryIdentifier, 
       C.Phone, 
       C.Fax, 
       C.ContactTypeIdentifier, 
       C.ModifiedDate, 
       Countries.[Name] AS country, 
       Contacts.FirstName, 
       Contacts.LastName, 
       CT.ContactTitle, 
       ContactDevices.PhoneNumber, 
       ContactDevices.PhoneTypeIdentifier
FROM Customers AS C
     INNER JOIN Contacts ON C.ContactId = Contacts.ContactId
     INNER JOIN Countries ON C.CountryIdentifier = Countries.CountryIdentifier
     INNER JOIN ContactType AS CT ON C.ContactTypeIdentifier = CT.ContactTypeIdentifier
                                     AND Contacts.ContactTypeIdentifier = CT.ContactTypeIdentifier
     INNER JOIN ContactDevices ON Contacts.ContactId = ContactDevices.ContactId
WHERE ContactDevices.PhoneTypeIdentifier = 3;