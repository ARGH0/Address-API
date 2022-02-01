using Microsoft.EntityFrameworkCore;

namespace Address.Infrastructure
{
	using Address.Domain.Entities;

    public interface IAddressContext
    {
		public DbSet<Address> Address { get; set; }

    }
}
