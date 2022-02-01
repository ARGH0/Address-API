namespace Address.Infrastructure.TypeConfigurations
{
	using Address.Domain.Entities;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class AddressTypeConfiguration
	{

		public AddressTypeConfiguration(EntityTypeBuilder<Address> entityTypeBuilder)
		{
			entityTypeBuilder.HasKey(x => x.Id);
			entityTypeBuilder.ToTable("address");

			entityTypeBuilder.Property(x => x.Id).HasColumnName("id").IsRequired();
			entityTypeBuilder.Property(x => x.Street).HasColumnName("street").IsRequired();
			entityTypeBuilder.Property(x => x.HouseNumber).HasColumnName("houseNumber").IsRequired();
			entityTypeBuilder.Property(x => x.PostalCode).HasColumnName("postalCode").IsRequired();
			entityTypeBuilder.Property(x => x.Country).HasColumnName("country").IsRequired();
			entityTypeBuilder.Property(x => x.HouseNumberAddition).HasColumnName("houseNumberAdditions");
			entityTypeBuilder.Property(x => x.Latitude).HasColumnName("latitude");
			entityTypeBuilder.Property(x => x.Longitude).HasColumnName("longitude");



		}
	}
}
