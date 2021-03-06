﻿using System;
using System.Collections.Generic;
using System.Linq;
using DigitalInspectionNetCore21.Models.Inspections;

namespace DigitalInspectionNetCore21.Models.Web.Inspections.Reports
{
	public class InspectionReportItem
	{
		public Guid InspectionItemId { get; set; }

		public Condition Condition { get; set; }

		public string Note { get; set; }

		public string Name { get; set; }

		public IEnumerable<CannedResponseReportItem> CannedResponses { get; set; }

		public IEnumerable<MeasurementReportItem> Measurements { get; set; }

		public IEnumerable<ImageReportItem> Images { get; set; }

		public bool IsCustomerConcern { get; set; }

		public InspectionReportItem(Models.Inspections.InspectionItem ii, string baseUrl)
		{
			InspectionItemId = ii.Id;
			Condition = (Condition) ii.Condition.Value; 
			Note = ii.Note;
			Name = ii.ChecklistItem.Name;
			IsCustomerConcern = ii.IsCustomerConcern;

			CannedResponses = ii.InspectionItemCannedResponses
				.Select(joinItem => joinItem.CannedResponse)
				.Select(cr => new CannedResponseReportItem(cr.Response, cr.Description, cr.Url))
				.OrderBy(cri => cri.Response)
				.ToList();

			Measurements = ii.InspectionMeasurements
				.OrderBy(im => im.Measurement.Label)
				.Select(im => new MeasurementReportItem(im.Value, im.Measurement.Label, im.Measurement.Unit))
				.ToList();

			Images = ii.InspectionImages
				.Where(image => image.IsVisibleToCustomer)
				.OrderBy(image => image.CreatedDate)
				.Select(image => new ImageReportItem(baseUrl, ii, image))
				.ToList();
		}
	}
}
