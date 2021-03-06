﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalInspectionNetCore21.Models.Inspections
{
	//http://cpratt.co/file-uploads-in-asp-net-mvc-with-view-models/
	public class Image
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public string Title { get; set; }

		[DataType(DataType.ImageUrl)]
		public string ImageUrl { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime CreatedDate
		{
			get => createdDate ?? DateTime.UtcNow;
			set => createdDate = value;
		}

		private DateTime? createdDate;
	}
}
