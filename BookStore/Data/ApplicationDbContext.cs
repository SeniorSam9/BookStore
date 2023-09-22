using Microsoft.EntityFrameworkCore;
// this file is the gateway between the this project and the database
namespace BookStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        // what ever configuration we do in the app db context
        // we will pass them to the DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base (dbContextOptions)
        {

        }
        // 
    }
}
