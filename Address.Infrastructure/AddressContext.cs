using Microsoft.EntityFrameworkCore;

namespace Address.Infrastructure
{
	using Address.Domain.Entities;

    public class AddressContext : DbContext, IAddressContext
    {
		public AddressContext(DbContextOptions<AddressContext> options)
			: base(options)
		{

		}

		public DbSet<Address> Address { get; set; }
    }
}
