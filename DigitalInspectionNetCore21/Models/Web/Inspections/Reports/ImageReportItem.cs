﻿using DigitalInspectionNetCore21.Models.Inspections;

namespace DigitalInspectionNetCore21.Models.Web.Inspections.Reports
{
	public class ImageReportItem
	{
		private static readonly string IMAGE_PATH_PREFIX = "Uploads/Inspections";

		public string title { get; set; }

		public string altText { get; set; }

		public string url { get; set; }

		public string extUrl { get; set; }

		public ImageReportItem(
			string baseUrl,
			Models.Inspections.InspectionItem ii,
			Models.Inspections.InspectionImage image)
		{
			title = ii.ChecklistItem.Name;
			altText = ii.ChecklistItem.Name;
			url = $"{baseUrl}/{IMAGE_PATH_PREFIX}/{ii.Inspection.WorkOrderId}/{ii.Id}/{image.Title}";
			extUrl = $"{baseUrl}/{IMAGE_PATH_PREFIX}/{ii.Inspection.WorkOrderId}/{ii.Id}/{image.Title}";
		}
	}
}
