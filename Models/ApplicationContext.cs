using Microsoft.EntityFrameworkCore;

namespace ReactService.Models
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Article> Articles { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}
