SELECT C.ContactId, 
       C.FirstName, 
       C.LastName, 
       PT.PhoneTypeDescription, 
       CD.PhoneNumber, 
       CD.PhoneTypeIdentifier
FROM Contacts AS C
     INNER JOIN ContactDevices AS CD ON C.ContactId = CD.ContactId
     INNER JOIN PhoneType AS PT ON CD.PhoneTypeIdentifier = PT.PhoneTypeIdenitfier
WHERE C.ContactId = 1 AND CD.PhoneTypeIdentifier IN (1,3);