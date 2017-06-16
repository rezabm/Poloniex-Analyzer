/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 07.06.2017
 * Time: 23:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Poloniex_Analyzer
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        TradeHistory history;
        List<Market> markets;
        List<TradeRecord> trades;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public MainForm()
        {
            InitializeComponent();
            AllocConsole();
        }

        List<Market> GetMarkets()
        {
            List<string> uniqueMarkets = new List<string>();
            List<Market> markets = new List<Market>();

            foreach (TradeRecord t in history.History)
            {
                if (!uniqueMarkets.Contains(t.Market))
                {
                    uniqueMarkets.Add(t.Market);
                    markets.Add(new Market(t.Market));
                }
            }
            return markets;
        }

        List<TradeRecord> GetTradesByMarket(string pair)
        {
            List<TradeRecord> trades = new List<TradeRecord>();
            foreach (TradeRecord t in history.History)
            {
                if (t.Market == pair)
                {
                    trades.Add(t);
                }
            }
            return trades;
        }

        void MainFormLoad(object sender, EventArgs e)
        {
            history = new TradeHistory();
            PopulateMarketsListView();
            textBox5.Text = CalcCurrentProfitOptimistic().ToString();
            textBox2.Text = CalcCurrentProfitScary().ToString();

        }


        void PopulateMarketsListView()
        {
            markets = GetMarkets();
            PopulateMarkets();
            listView2.VirtualListSize = markets.Count;
        }





        void ListView2SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView2.SelectedIndices.Count > 0)
            {
                trades = GetTradesByMarket(markets[listView2.SelectedIndices[0]].Pair);
                listView1.VirtualListSize = trades.Count;
                listView1.Refresh();


                columnHeader3.Text = "Amount[" + markets[listView2.SelectedIndices[0]].FirstCurrency + "]";
                columnHeader4.Text = "Price[" + markets[listView2.SelectedIndices[0]].SecondCurrency + "]";
                columnHeader5.Text = "Total[" + markets[listView2.SelectedIndices[0]].SecondCurrency + "]";
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Loading market: " + markets[listView2.SelectedIndices[0]].Pair + " (" + trades.Count.ToString() + " trades)");
            }

        }



        double CalcCurrentProfitScary()
        {
            double profit = 0;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*****");
            Console.WriteLine("Calculating current profit (including latest buys):");
            foreach (Market m in markets)
            {
                Console.Write("Market (" + m.Pair + ") = ");
                List<TradeRecord> trades = GetTradesByMarket(m.Pair);
                double p = CalcProfitUponTrades(trades, 0);
                Console.WriteLine(p.ToString());
                profit += p;
            }
            Console.WriteLine("Total = " + profit.ToString());
            Console.WriteLine("*****");
            return profit;
        }

        double CalcCurrentProfitOptimistic()
        {
            double profit = 0;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("*****");
            Console.WriteLine("Calculating current profit:");
            foreach (Market m in markets)
            {
                Console.Write("Market (" + m.Pair + ") = ");
                List<TradeRecord> trades = GetTradesByMarket(m.Pair);
                double p = SkipLatestBuysProfit(trades);
                Console.WriteLine(p.ToString());
                profit += p;
            }
            Console.WriteLine("Total = " + profit.ToString());
            Console.WriteLine("*****");
            return profit;
        }

        double WaitingForSell(List<TradeRecord> trades)
        {
            double amount = 0;
            for (int i = 0; i < trades.Count; i++)
            {
                if (trades[i].Type == "Buy")
                {
                    amount += trades[i].Amount;
                }
                else
                    break;
            }
            return amount;
        }

        void PopulateMarkets()
        {
            foreach (Market m in markets)
            {
                List<TradeRecord> trades = GetTradesByMarket(m.Pair);
                m.AmountHeld = WaitingForSell(trades);
                m.PairProfit = SkipLatestBuysProfit(trades);
                m.NumberTrades = trades.Count;
            }
        }
        double SkipLatestBuysProfit(List<TradeRecord> trades)
        {
            for (int i = 0; i < trades.Count; i++)
            {
                if (trades[i].Type == "Sell")
                {
                    double profit = CalcProfitUponTrades(trades, i);

                    return profit;
                }
            }
            return CalcProfitUponTrades(trades, 0);
        }


        double CalcProfitUponTrades(List<TradeRecord> trades, int n)
        {

            if (trades == null)
                throw new ArgumentNullException();

            if (trades.Count == 0)
                return 0;

            double profit = 0;
            for (int i = 0; i < trades.Count - n; i++)
            {
                TradeRecord t = trades[trades.Count - 1 - i];
                if (t.Type == "Buy")
                {
                    profit -= t.Total;
                }
                else
                {
                    profit += t.Total * (1.0 - t.Fee / 100);
                }
            }

            return profit;
        }

        void ListView1RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            try
            {
                TradeRecord t = trades[e.ItemIndex];
                ListViewItem lvi = new ListViewItem();
                lvi.Text = t.Date.ToString("dd.MM.yyyy hh:mm:ss");
                lvi.UseItemStyleForSubItems = false;


                ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = t.Type;
                if (t.Type == "Sell")
                    lvsi.ForeColor = Color.Red;
                else
                    lvsi.ForeColor = Color.Green;
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = t.Amount.ToString("0.00000000").PadLeft(16);
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = t.Price.ToString("0.00000000").PadLeft(16);
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = t.Total.ToString("0.00000000").PadLeft(16);
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = t.Fee.ToString("0.0000").PadLeft(8);
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = CalcProfitUponTrades(trades, e.ItemIndex).ToString("0.00000000").PadLeft(16);
                lvi.SubItems.Add(lvsi);

                e.Item = lvi;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ListView1RetrieveVirtualItem(): " + ex.Message);
            }
        }

        void ListView2RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = markets[e.ItemIndex].FirstCurrency.PadRight(5) + "/" + markets[e.ItemIndex].SecondCurrency.PadLeft(5);
			lvi.UseItemStyleForSubItems = false;

            ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Text = markets[e.ItemIndex].AmountHeld.ToString("0.00000000").PadLeft(16);
            lvi.SubItems.Add(lvsi);

            lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Text = markets[e.ItemIndex].PairProfit.ToString("0.00000000").PadLeft(16);
            lvi.SubItems.Add(lvsi);

            lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Text = markets[e.ItemIndex].NumberTrades.ToString().PadLeft(8);
            lvi.SubItems.Add(lvsi);

            if (markets[e.ItemIndex].AmountHeld > 0)
            {
                lvi.ForeColor = Color.Red;
            }

            e.Item = lvi;
		}

	}
}
