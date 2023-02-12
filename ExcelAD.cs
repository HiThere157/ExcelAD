using ExcelDna.Integration;
using ExcelDna.IntelliSense;

namespace ExcelAD
{
    public class ExcelAD_AddIn : IExcelAddIn
    {
        public void AutoOpen()
        {
            IntelliSenseServer.Install();
        }

        public void AutoClose()
        {
            IntelliSenseServer.Uninstall();
        }
    }
}