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

        void MainFormLoad(object sender, EventArgs e)
        {
            history = new TradeHistory();
            PopulateMarketsListView();

            double tp = GetTotalProfit();
            double thfs = GetTotalHeldForSale();
            textBoxTotalProfit.Text = tp.ToString("0.00000000").PadLeft(16);
            textBoxTotalHeldForSale.Text = thfs.ToString("0.00000000").PadLeft(16);
            textBoxTotalDiff.Text = (tp - thfs).ToString("0.00000000").PadLeft(16);
            
             
            if (history.History.Count > 0)
            {
            	DateTime d = history.History[history.History.Count-1].Date;
            	TimeSpan t = (TimeSpan)(DateTime.Now - d);
            	
            	this.Text += " (" + history.History.Count.ToString() + " trades in last " + ((int)t.TotalDays).ToString() + " days)";
            }
        }

        // scans history for all pairs available
        // only prepares the Pair value, the rest of the values are added in PopulateMarkets()
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

        // folowup for GetMarkets()
        void PopulateMarkets()
        {
            foreach (Market m in markets)
            {
                List<TradeRecord> trades = GetTradesByMarket(m.Pair);
                m.AmountHeld1 = WaitingForSell1(trades);
                m.AmountHeld2 = WaitingForSell2(trades);
                m.PairProfit = SkipLatestBuysProfit(trades);
                m.NumberTrades = trades.Count;
                if (trades.Count > 0)
                	m.LastTradeTimestamp = trades[0].Date;
                else
                	m.LastTradeTimestamp = new DateTime(0);
            }
        }

        // fills market list view with data
        void PopulateMarketsListView()
        {
            markets = GetMarkets();
            PopulateMarkets();
            listViewMarkets.VirtualListSize = markets.Count;
        }

        // extracts markets from history by trading pair
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

        // sums up the profit
        double GetTotalProfit()
        {
            double result = 0;
            foreach(Market m in markets)
            {
                result += m.PairProfit;
            }
            return result;
        }

        // sums up the amount held in altcoins
        double GetTotalHeldForSale()
        {
            double result = 0;
            foreach (Market m in markets)
            {
                result += m.AmountHeld2;
            }
            return result;
        }

        // reacts on market selection change
        void ListView2SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewMarkets.SelectedIndices.Count > 0)
            {
                trades = GetTradesByMarket(markets[listViewMarkets.SelectedIndices[0]].Pair);
                listView1.VirtualListSize = trades.Count;
                listView1.Refresh();

                columnHeader3.Text = "Amount[" + markets[listViewMarkets.SelectedIndices[0]].FirstCurrency + "]";
                columnHeader4.Text = "Price[" + markets[listViewMarkets.SelectedIndices[0]].SecondCurrency + "]";
                columnHeader5.Text = "Total[" + markets[listViewMarkets.SelectedIndices[0]].SecondCurrency + "]";
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Loading market: " + markets[listViewMarkets.SelectedIndices[0]].Pair + " (" + trades.Count.ToString() + " trades)");
            }

        }
       
        // sums up amount for sale in altcoin value
        double WaitingForSell1(List<TradeRecord> trades)
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

        // sums up amount for sale in basecoin value
        double WaitingForSell2(List<TradeRecord> trades)
        {
            double amount = 0;
            for (int i = 0; i < trades.Count; i++)
            {
                if (trades[i].Type == "Buy")
                {
                    amount += trades[i].Total;
                }
                else
                    break;
            }
            return amount;
        }


        //  calculates profit over all trades except latest buy orders
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


        // calculates profit over all trades since index 0 up to index n
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

        // gets visuals for trades list view
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

        // gets visuals for markets list view
        void ListView2RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = markets[e.ItemIndex].FirstCurrency.PadRight(5) + "/" + markets[e.ItemIndex].SecondCurrency.PadLeft(5);
			lvi.UseItemStyleForSubItems = false;

            ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
            if (ShowFirstCurrency)
                lvsi.Text = markets[e.ItemIndex].AmountHeld1.ToString("0.00000000").PadLeft(16) + " " + markets[e.ItemIndex].FirstCurrency;
            else
                lvsi.Text = markets[e.ItemIndex].AmountHeld2.ToString("0.00000000").PadLeft(16) + " " + markets[e.ItemIndex].SecondCurrency;
            lvi.SubItems.Add(lvsi);

            lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Text = markets[e.ItemIndex].PairProfit.ToString("0.00000000").PadLeft(16);
            lvi.SubItems.Add(lvsi);

            lvsi = new ListViewItem.ListViewSubItem();
            if (ShowNumOfTrades)
            	lvsi.Text = markets[e.ItemIndex].NumberTrades.ToString().PadLeft(8);
            else
            {
            	TimeSpan t = (TimeSpan)(DateTime.Now - markets[e.ItemIndex].LastTradeTimestamp);
            	if (t.TotalSeconds < 60)
            		lvsi.Text = t.TotalSeconds.ToString("0.00") + " sec";
            	else if (t.TotalMinutes < 60)
            		lvsi.Text = t.TotalMinutes.ToString("0.00") + " min";
            	else if (t.TotalHours < 24)
            		lvsi.Text = t.TotalHours.ToString("0.00") + " hrs";
            	else
            		lvsi.Text = t.TotalDays.ToString("0.00") + " days";
            	
            }
            lvi.SubItems.Add(lvsi);


            if (markets[e.ItemIndex].AmountHeld1 > 0)
            {
                lvi.ForeColor = Color.Red;
                foreach (ListViewItem.ListViewSubItem si in lvi.SubItems) si.ForeColor = Color.Red;
            }

            e.Item = lvi;
		}


        // selets between altcoin and basecoin representation in market view column showing held for sale amount
        private bool ShowFirstCurrency = true;
        private bool ShowNumOfTrades = true;
        
        // GUI reaction for currency switching
        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 1)
            {
                ShowFirstCurrency = !ShowFirstCurrency;
                columnHeader9.Text = ShowFirstCurrency? "Held for sale A" : "Held for sale B";
                listViewMarkets.Refresh();
            }
            
            if (e.Column == 3)
            {
            	ShowNumOfTrades = !ShowNumOfTrades;
            	columnHeader11.Text = ShowNumOfTrades? "# Trades" : "Last trade";
            	listViewMarkets.Refresh();
            }
        }
        
        
    }
}
