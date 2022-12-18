using HackatonApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackatonApi.Core.DbOperations;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Company> Companies { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Order> Orders { get; set; }

    int SaveChanges();
}