# Configure models

Allows configuration for an entity type to be factored into a separate class, rather than in-line in OnModelCreating(ModelBuilder). Implement this interface, applying configuration for the entity in the Configure(EntityTypeBuilder<TEntity>) method, and then apply the configuration to the model using ApplyConfiguration<TEntity>(IEntityTypeConfiguration<TEntity>) in OnModelCreating(ModelBuilder).

[Microsoft documentation](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.ientitytypeconfiguration-1?view=efcore-3.1)

https://stackoverflow.com/questions/26957519/ef-core-mapping-entitytypeconfiguration
https://github.com/SeanLeitzinger/Entity-Framework-Core-Examples/blob/master/EFExamples.Data/Configuration/CompanyConfiguration.cs
