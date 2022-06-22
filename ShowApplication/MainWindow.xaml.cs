using System.Windows;
using System.Windows.Input;
using ShowApplication.ViewModels.Command;

namespace ShowApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>



    public partial class MainWindow : Window
    {
        private ViewModelBase viewModelBase;

        public MainWindow()
        {
            InitializeComponent();

            this.PreviewKeyDown += new KeyEventHandler(KeyHandler);

            viewModelBase = new ViewModelBase();
            this.DataContext = viewModelBase;
        }

        private void KeyHandler(object sender, KeyEventArgs e)
        {
            ICommand command = null;
            if (e.Key == Key.Escape)
                command = new TogleVisibilityCommand();
            else if (e.Key == Key.Enter)
            {
                string processFound = "";
                foreach (string item in SearchBox.AutoSuggestionList)
                {
                    if (item.StartsWith(SearchBox.Text)) { processFound = item; }
                }
                if (string.IsNullOrEmpty(processFound))
                    command = new StartApplicationCommand(); 
                else
                    command = new SetFocusCommand();


                viewModelBase.TogleVisible.Execute(this);
            }
            if (command != null)
            {
                command.Execute(this);
            }
        }

        private void Applicaltion_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
