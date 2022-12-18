using HackatonApi.Core.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DBOperations;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {

            context.SaveChanges();
        }
    }
}