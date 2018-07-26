namespace JoesECommerce.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CommerceDbContext : DbContext
    {
        // Your context has been configured to use a 'CommerceDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'JoesECommerce.Models.CommerceDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CommerceDbContext' 
        // connection string in the application configuration file.
        public CommerceDbContext()
            : base("name=CommerceDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}