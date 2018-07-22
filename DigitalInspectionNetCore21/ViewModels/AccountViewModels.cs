﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DigitalInspectionNetCore21.ViewModels.Base;

namespace DigitalInspectionNetCore21.ViewModels
{
	public class LoginViewModel: BaseViewModel
	{
		[Required(ErrorMessage = "Username is required")]
		[DisplayName("Username *")]
		public string Username { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Password is required")]
		[DisplayName("Password *")]
		public string Password { get; set; }
	}
}
