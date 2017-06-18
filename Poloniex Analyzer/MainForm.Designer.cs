/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 07.06.2017
 * Time: 23:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Poloniex_Analyzer
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.TextBox textBoxTotalProfit;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListView listViewMarkets;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.textBoxTotalProfit = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.listViewMarkets = new System.Windows.Forms.ListView();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.textBoxTotalDiff = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxTotalHeldForSale = new System.Windows.Forms.TextBox();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel1 = new System.Windows.Forms.Panel();
			this.myTabControl1 = new Poloniex_Analyzer.MyTabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.panel1.SuspendLayout();
			this.myTabControl1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader1,
			this.columnHeader2,
			this.columnHeader3,
			this.columnHeader4,
			this.columnHeader5,
			this.columnHeader6,
			this.columnHeader7});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(486, 3);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(801, 559);
			this.listView1.TabIndex = 8;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.VirtualMode = true;
			this.listView1.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ListView1RetrieveVirtualItem);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Timestamp";
			this.columnHeader1.Width = 140;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Type";
			this.columnHeader2.Width = 50;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Amount";
			this.columnHeader3.Width = 120;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Price";
			this.columnHeader4.Width = 120;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Total";
			this.columnHeader5.Width = 120;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Fee[%]";
			this.columnHeader6.Width = 80;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Profit";
			this.columnHeader7.Width = 120;
			// 
			// textBoxTotalProfit
			// 
			this.textBoxTotalProfit.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.textBoxTotalProfit.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxTotalProfit.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textBoxTotalProfit.Location = new System.Drawing.Point(198, 12);
			this.textBoxTotalProfit.Name = "textBoxTotalProfit";
			this.textBoxTotalProfit.ReadOnly = true;
			this.textBoxTotalProfit.Size = new System.Drawing.Size(150, 19);
			this.textBoxTotalProfit.TabIndex = 11;
			this.textBoxTotalProfit.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label4.ForeColor = System.Drawing.Color.LimeGreen;
			this.label4.Location = new System.Drawing.Point(12, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(180, 19);
			this.label4.TabIndex = 12;
			this.label4.Text = "Total profit (TP) =";
			// 
			// listViewMarkets
			// 
			this.listViewMarkets.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.listViewMarkets.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewMarkets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader8,
			this.columnHeader9,
			this.columnHeader10,
			this.columnHeader11});
			this.listViewMarkets.Dock = System.Windows.Forms.DockStyle.Left;
			this.listViewMarkets.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.listViewMarkets.FullRowSelect = true;
			this.listViewMarkets.GridLines = true;
			this.listViewMarkets.Location = new System.Drawing.Point(3, 3);
			this.listViewMarkets.Name = "listViewMarkets";
			this.listViewMarkets.Size = new System.Drawing.Size(480, 559);
			this.listViewMarkets.TabIndex = 13;
			this.listViewMarkets.UseCompatibleStateImageBehavior = false;
			this.listViewMarkets.View = System.Windows.Forms.View.Details;
			this.listViewMarkets.VirtualMode = true;
			this.listViewMarkets.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView2_ColumnClick);
			this.listViewMarkets.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ListView2RetrieveVirtualItem);
			this.listViewMarkets.SelectedIndexChanged += new System.EventHandler(this.ListView2SelectedIndexChanged);
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Pair";
			this.columnHeader8.Width = 100;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Held for sale A";
			this.columnHeader9.Width = 160;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Pair profit";
			this.columnHeader10.Width = 120;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "#Trades";
			this.columnHeader11.Width = 80;
			// 
			// textBoxTotalDiff
			// 
			this.textBoxTotalDiff.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.textBoxTotalDiff.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxTotalDiff.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textBoxTotalDiff.Location = new System.Drawing.Point(959, 12);
			this.textBoxTotalDiff.Name = "textBoxTotalDiff";
			this.textBoxTotalDiff.ReadOnly = true;
			this.textBoxTotalDiff.Size = new System.Drawing.Size(150, 19);
			this.textBoxTotalDiff.TabIndex = 15;
			this.textBoxTotalDiff.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.ForeColor = System.Drawing.Color.LimeGreen;
			this.label1.Location = new System.Drawing.Point(809, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 19);
			this.label1.TabIndex = 16;
			this.label1.Text = "TP minus THFS =";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.ForeColor = System.Drawing.Color.LimeGreen;
			this.label2.Location = new System.Drawing.Point(368, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(261, 19);
			this.label2.TabIndex = 18;
			this.label2.Text = "Total held for sale (THFS) =";
			// 
			// textBoxTotalHeldForSale
			// 
			this.textBoxTotalHeldForSale.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.textBoxTotalHeldForSale.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxTotalHeldForSale.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textBoxTotalHeldForSale.Location = new System.Drawing.Point(635, 12);
			this.textBoxTotalHeldForSale.Name = "textBoxTotalHeldForSale";
			this.textBoxTotalHeldForSale.ReadOnly = true;
			this.textBoxTotalHeldForSale.Size = new System.Drawing.Size(150, 19);
			this.textBoxTotalHeldForSale.TabIndex = 17;
			this.textBoxTotalHeldForSale.TabStop = false;
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(3, 3);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1284, 559);
			this.chart1.TabIndex = 19;
			this.chart1.Text = "chart1";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.textBoxTotalProfit);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBoxTotalDiff);
			this.panel1.Controls.Add(this.textBoxTotalHeldForSale);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 597);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1298, 46);
			this.panel1.TabIndex = 21;
			// 
			// myTabControl1
			// 
			this.myTabControl1.Controls.Add(this.tabPage3);
			this.myTabControl1.Controls.Add(this.tabPage4);
			this.myTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myTabControl1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
			this.myTabControl1.Location = new System.Drawing.Point(0, 0);
			this.myTabControl1.Multiline = true;
			this.myTabControl1.Name = "myTabControl1";
			this.myTabControl1.Padding = new System.Drawing.Point(0, 0);
			this.myTabControl1.SelectedIndex = 0;
			this.myTabControl1.Size = new System.Drawing.Size(1298, 597);
			this.myTabControl1.TabIndex = 22;
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.Black;
			this.tabPage3.Controls.Add(this.listView1);
			this.tabPage3.Controls.Add(this.panel2);
			this.tabPage3.Controls.Add(this.listViewMarkets);
			this.tabPage3.Location = new System.Drawing.Point(4, 28);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(1290, 565);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "Overview";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Black;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(483, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(3, 559);
			this.panel2.TabIndex = 14;
			// 
			// tabPage4
			// 
			this.tabPage4.BackColor = System.Drawing.Color.Black;
			this.tabPage4.Controls.Add(this.chart1);
			this.tabPage4.Location = new System.Drawing.Point(4, 28);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(1290, 565);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Profit chart";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1298, 643);
			this.Controls.Add(this.myTabControl1);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "Poloniex Analyzer";
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.myTabControl1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.TextBox textBoxTotalDiff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTotalHeldForSale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        private Poloniex_Analyzer.MyTabControl myTabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel2;
    }
}
