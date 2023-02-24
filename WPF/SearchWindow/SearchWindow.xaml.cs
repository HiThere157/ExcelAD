using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExcelAD.WPF.SearchWindow
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window, INotifyPropertyChanged
    {
        private Page[] _pages;
        public Page[] Pages
        {
            get { return _pages; }
            set
            {
                if (!Equals(_pages, value))
                {
                    _pages = value;
                    OnPropertyChanged();
                }
            }
        }

        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (!Equals(_currentPage, value))
                {
                    _currentPage = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _selectedIndex = 0;

        public ICommand Forward { get; }
        public ICommand Back { get; }

        public SearchWindow()
        {
            InitializeComponent();
            DataContext = this;

            Pages = new Page[]
            {
                new ClassSelectPage(),
                new FilterConfigPage(),
            };
            CurrentPage = Pages[_selectedIndex];

            Forward = new RelayCommand(_doForward, _canForward);
            Back = new RelayCommand(_doBack, _canBack);
        }

        private bool _canForward()
        {
            return _selectedIndex < _pages.Length - 1;
        }
        private void _doForward()
        {
            _selectedIndex += 1;
            CurrentPage = _pages[_selectedIndex];
        }

        private bool _canBack()
        {
            return _selectedIndex > 0;
        }
        private void _doBack()
        {
            _selectedIndex -= 1;
            CurrentPage = _pages[_selectedIndex];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
