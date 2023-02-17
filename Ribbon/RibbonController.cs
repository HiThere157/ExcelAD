using ExcelDna.Integration.CustomUI;
using System.Runtime.InteropServices;
using ExcelAD.WPF;

namespace ExcelAD.Ribbon
{
    [ComVisible(true)]
    public class RibbonController : ExcelRibbon
    {
        public void OnLogonPressed(IRibbonControl control)
        {
            MessageBox.Show("yo");
            try
            {
                Window1 win1 = new Window1();
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
