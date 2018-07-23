﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DigitalInspectionNetCore21.Models.Inspections.Joins;
using DigitalInspectionNetCore21.Models.Orders;

namespace DigitalInspectionNetCore21.Models.Inspections
{
	public class CannedResponse
	{
		[Required]
		public Guid Id { get; set; } = Guid.NewGuid();

		// Foreign key - Nullable allows individual deletion of response
		public Guid? ChecklistItemId { get; set; }

		// Navigation properties for model binding
		public virtual ChecklistItem ChecklistItem { get; set; }

		public virtual IList<InspectionItemCannedResponse> InspectionItemCannedResponses { get; set; } = new List<InspectionItemCannedResponse>();

		[Required(ErrorMessage = "Canned response is required")]
		[DisplayName("Canned Response *")]
		public string Response { get; set; }

		[DisplayName("URL")]
		public string Url { get; set; } = String.Empty;

		[DisplayName("Description")]
		public string Description { get; set; } = String.Empty;

		[DisplayName("Levels of Concern *")]
		[Required(ErrorMessage = "One or more levels of concern are required")]
		public IList<RecommendedServiceSeverity> LevelsOfConcern { get; set; } = new List<RecommendedServiceSeverity>();

		// FIXME DJC This should no longer be necessary because of the ValueConverter I've added in ApplicationDbContext. Verify
		// Trick to force DB to hold onto enum values
		public string LevelsOfConcernInDb
		{
			get => string.Join(",", LevelsOfConcern);
			set {
				if (string.IsNullOrEmpty(value))
				{
					LevelsOfConcern = new List<RecommendedServiceSeverity>();
				}
				else
				{
					IList<string> stringList = value.Split(',').ToList();
					LevelsOfConcern = (IList<RecommendedServiceSeverity>) stringList.Select(s => (RecommendedServiceSeverity) Enum.Parse(typeof(RecommendedServiceSeverity), s)).ToList();
				}
			}
		}
	}
}