// Title: Building ASP.NET Server Controls
//
// Chapter: 9 - Integrating Client-Side Script
// File: PhoneValidator.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace ControlsBookLib.Ch09
{
	public enum PhoneNumberType
	{
		US = 0,
		Intl = 1
	}

	[ ToolboxData("<{0}:PhoneValidator NumberType=US runat=server></{0}:PhoneValidator>") ]
	public class PhoneValidator : BaseValidator
	{		
		public virtual PhoneNumberType NumberType
		{
			get 
			{
				object numType = ViewState["NumberType"];
				if (numType == null)
					return PhoneNumberType.US;
				else
					return (PhoneNumberType) numType;
			}
			set 
			{ 
				ViewState["NumberType"] = value;
			}       
		}

		const string US_PHONE_REGEX = @"^\(?\d{3}\)?(\s|-)\d{3}\-\d{4}$";
		const string INTL_PHONE_REGEX =@"^\d(\d|-){7,20}$";

		private string PhoneRegex
		{
			get 
			{
				// read only property selects the appropriate
				// regular expression to use for US or
				// international phone based on the NumberType
				// property setting
				if (this.NumberType == PhoneNumberType.Intl)
					  return INTL_PHONE_REGEX;
				  else 
					  return US_PHONE_REGEX;
			}
		}
		
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			base.AddAttributesToRender (writer);

			// BaseValidator has logic to determine uplevel browser
			// client capability
			if (base.RenderUplevel)
			{
				// link into the ClientValidation API of ASP.NET and 
				// reuse its client-side Regex evaluation code
				writer.AddAttribute("evaluationfunction","RegularExpressionValidatorEvaluateIsValid");
				writer.AddAttribute("validationexpression",PhoneRegex);
			}
		}

		protected override bool EvaluateIsValid()
		{
			// BaseValidator provides GetControlValidationValue
			// to make it easy to grab the controls value for you
			string number = base.GetControlValidationValue(
				base.ControlToValidate);
			
			// enforce the rule that we don't evaluate null 
			// or empty values in non-RequiredFieldValidator
			// controls
			if (number.Trim() != "")
			{	
				// use the regular expression engine of ASP.NET
				// to evaluate the phone number according to the
				// selected Phone type regular expression
				Regex expr = new Regex(PhoneRegex);
				MatchCollection matches = expr.Matches(number, 0);
				return (matches != null && matches[0].Value == number);
			}
			else
				return true;
		}
	}
}
