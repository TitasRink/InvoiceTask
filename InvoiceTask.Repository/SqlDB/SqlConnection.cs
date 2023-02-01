using InvoiceTask.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceTask.Repository.SqlDB;

public class SqlConnection : DbContext
{
    public DbSet<OrdersModel> orders { get; set; }
    public DbSet<CustomerModel> customers { get; set; }
    public DbSet<OrderLineModel> orderLines { get; set; }
    public DbSet<ProductModel> products { get; set; }
    public DbSet<SupplierModel> suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = (localdb)\\ProjectModels; Initial Catalog = InvoiceDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
    }
}
