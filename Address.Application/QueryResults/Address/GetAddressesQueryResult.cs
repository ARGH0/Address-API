using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Address.Application.QueryResults.Address
{
	public class GetAddressesQueryResult
	{
		public IReadOnlyCollection<AddressQueryResult> addressess { get; set; }
	}
}
