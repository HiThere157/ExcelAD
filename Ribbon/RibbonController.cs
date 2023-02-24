using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ExcelDna.Integration.CustomUI;
using ExcelAD.WPF.SearchWindow;

namespace ExcelAD.Ribbon
{
    [ComVisible(true)]
    public class RibbonController : ExcelRibbon
    {
        public void OnLogonPressed(IRibbonControl control)
        {
            try
            {
                SearchWindow win1 = new SearchWindow();
                win1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred in ExcelAD.Ribbon.OnLogonPressed: " + ex.Message);
                MessageBox.Show("An Error occurred in ExcelAD.Ribbon.OnLogonPressed: " + ex.StackTrace);
            }
        }
    }
}
