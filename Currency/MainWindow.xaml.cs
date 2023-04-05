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
using System.Xml;

namespace Currency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataUpload_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
            XmlElement rooteleman = xmldoc.DocumentElement;
            XmlNodeList liste = rooteleman.GetElementsByTagName("Currency");
            List<CurrencyModel> dlist = new List<CurrencyModel>();
            foreach (var item in liste)
            {
                CurrencyModel currencyObj = new CurrencyModel();
                XmlElement currency = (XmlElement)item;
                currencyObj.Name = currency.GetElementsByTagName("Isim").Item(0).InnerText;
                string unit = currency.GetElementsByTagName("Unit").Item(0).InnerText;
                string forexBuying = currency.GetElementsByTagName("ForexBuying").Item(0).InnerText;
                string forexSelling = currency.GetElementsByTagName("ForexSelling").Item(0).InnerText;
                string banknoteBuying = currency.GetElementsByTagName("BanknoteBuying").Item(0).InnerText;
                string banknoteSelling = currency.GetElementsByTagName("BanknoteSelling").Item(0).InnerText;

                if (!string.IsNullOrEmpty(unit))
                    currencyObj.Unit = Convert.ToInt32(unit);
                if (!string.IsNullOrEmpty(forexBuying))
                    currencyObj.ForexBuying = Convert.ToDecimal(forexBuying);
                if (!string.IsNullOrEmpty(forexSelling))
                    currencyObj.ForexSelling = Convert.ToDecimal(forexSelling);
                if (!string.IsNullOrEmpty(banknoteBuying))
                    currencyObj.BanknoteBuying = Convert.ToDecimal(banknoteBuying);
                if (!string.IsNullOrEmpty(banknoteSelling))
                    currencyObj.BanknoteSelling = Convert.ToDecimal(banknoteSelling);

                dlist.Add(currencyObj);

            }

            dataGridCurrency.ItemsSource = dlist;
        }
    }
}
