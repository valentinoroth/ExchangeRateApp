using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExchangeRateApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccountList AccountList = new AccountList();

        public MainWindow()
        {
            InitializeComponent();
            AccountList.Accounts.Add(new Account() { Currency = Currency.CHF, Amount = 2500 });
            AccountList.Accounts.Add(new Account() { Currency = Currency.EUR, Amount = 950 });
            AccountList.Accounts.Add(new Account() { Currency = Currency.GBP, Amount = 300 });
            AccountList.Accounts.Add(new Account() { Currency = Currency.USD, Amount = 1200 });  
            DataContext = AccountList;


        }

        private async void Calculate()
        {
            var total = await AccountList.GetTotal();
            double sommeTotal = .0;
            foreach (var c in AccountList.Accounts)
            {
                sommeTotal += c.Value;
            }
            TotalLabel.Content = $"{sommeTotal:0.00}";
            AccountsDataGrid.Items.Refresh();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void CurrencyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Calculate();
        }
    }
}
