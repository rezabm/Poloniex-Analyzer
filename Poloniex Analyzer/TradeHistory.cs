/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 07.06.2017
 * Time: 23:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;


namespace Poloniex_Analyzer
{
	/// <summary>
	/// Description of TradeHistory.
	/// </summary>
	public class TradeHistory
	{
		public List<TradeRecord> History;
		
		public TradeHistory()
		{
			History = new List<TradeRecord>();
			if (File.Exists("tradeHistory.csv"))
			{
				string line;
				StreamReader file = new StreamReader("tradeHistory.csv");
				while((line = file.ReadLine()) != null)
				{
					try
					{
						// add only valid lines
						TradeRecord trade = new TradeRecord(line);
						History.Add(trade);
					}
					catch (Exception e)
					{
						if (History.Count == 0)
						{
							Console.ForegroundColor = ConsoleColor.DarkCyan;
							Console.WriteLine("CSV header: " + line);
						}
					}
				}
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.WriteLine("Loaded " + History.Count.ToString() + " lines.");
				file.Close();
			}
		}
	}
}
