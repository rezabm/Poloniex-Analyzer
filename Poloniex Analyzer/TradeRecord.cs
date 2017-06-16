/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 07.06.2017
 * Time: 23:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Poloniex_Analyzer
{
	/// <summary>
	/// Description of TradeRecord.
	/// </summary>
	public class TradeRecord
	{
		public DateTime Date;
		public string Market;
		public string Category;
		public string Type;
		public double Price;
		public double Amount;
		public double Total;
		public double Fee;
		public long Order_Number;
		public double Base_Total_Less_Fee;
		public double Quote_Total_Less_Fee;
				
		public TradeRecord(string fromString)
		{
			string[] s = fromString.Split(',');
			Date = DateTime.Parse(s[0]);
			Market = s[1];
			Category = s[2];
			Type = s[3];
			Price = Utils.ParseDouble(s[4]);
			Amount = Utils.ParseDouble(s[5]);
			Total = Utils.ParseDouble(s[6]);
			Fee = Utils.ParseDouble(s[7].Replace("%", ""));
			Order_Number = long.Parse(s[8]);
			Base_Total_Less_Fee = Utils.ParseDouble(s[9]);
			Quote_Total_Less_Fee = Utils.ParseDouble(s[10]);
		}
	}
}
