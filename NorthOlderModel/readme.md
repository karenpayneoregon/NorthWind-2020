# Working with comments attached to properties

This code sample is raw, shows how to use comments for DataGridView column headers. The database used is not broken apart as much as all the other projects in this solution.

Focus is on RelationalEntityTypeExtensions.[GetComment](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.relationalentitytypeextensions.getcomment?view=efcore-3.1)(IEntityType) Method

```csharp
IEntityType entityType = context.Model.FindEntityType(typeof(Customers));
modelCommentList = entityType.GetProperties().Select(property => new ModelComment
{
    Name = property.Name,
    Comment = property.GetComment()
}).ToList();
```