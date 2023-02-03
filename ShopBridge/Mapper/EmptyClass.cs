using System;
using AutoMapper;
using ShopBridge.Dal.Entities;
using ShopBridge.Dto;

namespace ShopBridge.Mapper
{
	public class InventoryProfile: Profile
	{
		public InventoryProfile()
		{
            CreateMap<Inventory, InventoryDto>();
			CreateMap<InventoryDto, Inventory>();
        }
	}
}

