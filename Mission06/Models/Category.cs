﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Mission06.Models
{
	public class Category
	{
		[Key]
		[Required]
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}

