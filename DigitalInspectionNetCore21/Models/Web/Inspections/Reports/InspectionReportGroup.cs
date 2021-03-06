﻿using System.Collections.Generic;
using System.Linq;

namespace DigitalInspectionNetCore21.Models.Web.Inspections.Reports
{
	public class InspectionReportGroup
	{
		public string Name { get; set; }

		public Condition Condition { get; set; }

		public IEnumerable<InspectionReportItem> Items { get; set; }

		public InspectionReportGroup(IGrouping<string, Models.Inspections.InspectionItem> ig, string baseUrl)
		{
			var items = ig.OrderBy(ii => ii.Condition.Value).ToList();

			Name = ig.Key;
			Condition = (Condition) items.First().Condition.Value;
			Items = items.Select(ii => new InspectionReportItem(ii, baseUrl));
		}
	}
}
