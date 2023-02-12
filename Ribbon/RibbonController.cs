using ExcelDna.Integration.CustomUI;
using System.Runtime.InteropServices;

namespace ExcelAD.Ribbon
{
    [ComVisible(true)]
    public class RibbonController : ExcelRibbon
    {
        public void OnLogonPressed(IRibbonControl control)
        {
            MessageBox.Show("Hello from control " + control.Id);
        }
    }
}
