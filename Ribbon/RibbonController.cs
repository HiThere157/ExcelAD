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
            Window1 win1 = new Window1();
            win1.Show();
        }
    }
}
