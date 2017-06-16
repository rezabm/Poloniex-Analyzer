/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 16.06.2017
 * Time: 0:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Poloniex_Analyzer
{
	/// <summary>
	/// Description of Market.
	/// </summary>
	public class Market
	{
		public string Pair;
        public string FirstCurrency
		{
			get { int i = Pair.IndexOf("/"); return Pair.Substring(0, i); }
		}
		
		public string SecondCurrency
		{
			get { int i = Pair.IndexOf("/"); return Pair.Substring(i+1); }
		}
			
		public Market(string pair)
		{		
			Pair = pair;
		}

        public double PairProfit;

        public double AmountHeld;

        public long NumberTrades;
	}
}
