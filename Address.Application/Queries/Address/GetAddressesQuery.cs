using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Address.Application.QueryResults.Address;
using Address.Infrastructure;
using MediatR;

namespace Address.Application.Queries.Address
{
	public class GetAddressesQuery : IRequest<GetAddressesQueryResult>
	{


	}
}
