using ExcelDna.Integration;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;
using System;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExcelAD.WPF.SearchWindow
{
    /// <summary>
    /// Interaction logic for ClassSelectPage.xaml
    /// </summary>
    public partial class ClassSelectPage : Page, INotifyPropertyChanged
    {
        private ReadOnlyActiveDirectorySchemaClassCollection _schemas;
        public ReadOnlyActiveDirectorySchemaClassCollection Schemas
        {
            get { return _schemas; }
            set
            {
                if (!Equals(_schemas, value))
                {
                    _schemas = value;
                    OnPropertyChanged();
                }
            }
        }

        public ClassSelectPage()
        {
            InitializeComponent();
            DataContext = this;

            Schemas = _getSchemas("Alcon.net");
        }
        private ReadOnlyActiveDirectorySchemaClassCollection _getSchemas(string domain)
        {
            DirectoryEntry directoryEntry = null;
            try
            {
                directoryEntry = new DirectoryEntry($"LDAP://{domain}", null, null, AuthenticationTypes.Secure | AuthenticationTypes.Sealing);
                ActiveDirectorySchema currentSchema = ActiveDirectorySchema.GetCurrentSchema();
                return currentSchema.FindAllClasses();
            }
            finally
            {
                directoryEntry.Close();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
