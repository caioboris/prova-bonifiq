﻿namespace ProvaPub.Models
{
	public class Customer : BaseModel
	{
		
		public ICollection<Order> Orders { get; set; }
	}
}
