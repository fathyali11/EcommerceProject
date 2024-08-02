﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebStore.Models
{
	public class OrderDetail
	{
		public int Id { get; set; }
		[Required]
		public int OrderHeaderId { get; set; }
		[ForeignKey("OrderHeaderId")]
		[ValidateNever]
		public OrderHeader OrderHeader { get; set; }


		[Required]
		public int ProductId { get; set; }
		[ForeignKey("ProductId")]
		[ValidateNever]
		public Product Product { get; set; }

		public int Count { get; set; }
		public double Price { get; set; }
	}
}
