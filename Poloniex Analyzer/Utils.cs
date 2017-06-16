/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 07.06.2017
 * Time: 23:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;

namespace Poloniex_Analyzer
{
	/// <summary>
	/// Description of Utils.
	/// </summary>
	public class Utils
	{
		
		public static double ParseDouble(string s)
		{
			CultureInfo usCulture = new CultureInfo("en-US");
			NumberFormatInfo dbNumberFormat = usCulture.NumberFormat;
			return double.Parse(s, dbNumberFormat);
		}

		
		
		public Utils()
		{
		}
	}
}
