/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 17.06.2017
 * Time: 23:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Poloniex_Analyzer
{
	/// <summary>
	/// Description of MyTabControl.
	/// </summary>
	public partial class MyTabControl : TabControl
	{
		public MyTabControl()
		{
			
			if (!this.DesignMode) this.Multiline = true;
		}
		private const int TCM_ADJUSTRECT = 0x1328;
		
		protected override void WndProc(ref Message m)
		{
		if (m.Msg == TCM_ADJUSTRECT)
            {
                
               RECT rc = (RECT)m.GetLParam(typeof(RECT));
            //Adjust these values to suit, dependant upon Appearance
            rc.Left -= 4;
            rc.Right += 4;
            rc.Top -= 4;
            rc.Bottom += 4;
            Marshal.StructureToPtr(rc, m.LParam, true);
                
  
                
                
                
                
                
                
                //m.Result = (IntPtr)1;
                //return;
            }
            //else
            // call the base class implementation
            base.WndProc(ref m);
		}
		
		
		private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }
	}
}


