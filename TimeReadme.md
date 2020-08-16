# About

These projects show how to use SQL-Server Time(7) with Entity Framework Core 3.7

Note Duration property in Movies could be not nullable or nullable, here it's nullable.

For reference here is a SQL SELECT

```sql
SELECT Id, 
       Duration, 
       FORMAT(Duration, N'hh\:mm') AS [Formatted plain], 
       CONVERT(VARCHAR(10), DATEPART(HOUR, Duration)) + ' hours ' + 
	   CONVERT(VARCHAR(10), DATEPART(MINUTE, Duration)) + ' minutes' AS [Format for app], 
       Title
FROM dbo.Movies  ORDER BY dbo.Movies.Duration DESC
```