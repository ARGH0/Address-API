using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Address.Application.Queries.Address;
using Address.Application.QueryResults.Address;
using Address.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Address.Application.QueryHandler
{
	public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQuery, GetAddressesQueryResult>
	{
		#region Private declarations

		private readonly IAddressContext _context;

		#endregion

		#region Constructors

		public GetAddressesQueryHandler(IAddressContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		#endregion

		#region Public Methods

		public async Task<GetAddressesQueryResult> Handle(GetAddressesQuery query, CancellationToken cancellationToken)
		{
			List<AddressQueryResult> addressList = await _context.Address.
				Select(address => new AddressQueryResult
				{
					Street = address.Street,
					City = address.City,
					PostalCode = address.PostalCode,
					Country = address.Country,
					HouseNumber = address.HouseNumber,
					HouseNumberAddition = address.HouseNumberAddition,
					Latitude = address.Latitude,
					Longitude = address.Longitude,
				})
				.ToListAsync();

			if (addressList == null)
				return null;

			GetAddressesQueryResult result = new GetAddressesQueryResult() { addressess = addressList };

			return result;
		}			
	}
}

#endregion
