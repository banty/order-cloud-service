using System;
using AutoMapper;
using EasyOrder.Application.Commands;
using EasyOrder.Domain.Model;

namespace EasyOrder.Application.Profiles
{
	public class OrderProfiles:Profile
	{
		public OrderProfiles()
		{
			CreateMap<Order, OrderDto>();
		}
	}
}

