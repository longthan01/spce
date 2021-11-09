using Microsoft.EntityFrameworkCore;

namespace SomeApp.Implementations.DbContext
{
	public class InMemoryDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
			: base(options)
		{
		}

		public DbSet<Account> Accounts { get; set; }
	}
}