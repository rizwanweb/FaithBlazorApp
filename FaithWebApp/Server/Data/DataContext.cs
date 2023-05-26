using FaithWebApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FaithWebApp.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{            
        }

		public DbSet<Party> Clients { get; set; }
		public DbSet<City> Cities { get; set; }
    }
}
