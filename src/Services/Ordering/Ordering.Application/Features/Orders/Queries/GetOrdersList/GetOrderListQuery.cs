using System;
using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
	public class GetOrderListQuery : IRequest<List<OrderVm>>
	{
		public string UserName { get; set; }

		public GetOrderListQuery(string username)
		{
			UserName = username ?? throw new ArgumentNullException(nameof(username));
		}
	}
}

