using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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

namespace SampleWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string URL = "https://froyokuwait.com/FroyoAPI/api/CustomerLoyaltyHistory?PhoneNo=69089528";
        public MainWindow()
        {
            InitializeComponent();

            var apiString = LoadAPiData();
            var dt = JsonConvert.DeserializeObject<List<CustomerInfo>>(apiString).FirstOrDefault();
            FillCustomerInfo(dt);
            var result = TransformToDatattable(dt);
            dgTranHistory.ItemsSource = result;
        }

        private ObservableCollection<CustomerTransaction> TransformToDatattable(CustomerInfo dt)
        {
            var customerInfos = new ObservableCollection<CustomerTransaction>();
            foreach (var row in dt.customerTransactions)
            {
                var obj = new CustomerTransaction()
                {
                    Branch = row.CheckNo,
                    CheckAmount = row.CheckAmount,
                    CheckNo = row.CheckNo,
                    GeneratedLoyaltyAmount = row.GeneratedLoyaltyAmount,
                    TranDate = row.TranDate,
                    UsedLoyaltyAmount = row.UsedLoyaltyAmount

                };
                customerInfos.Add(obj);
            }
            return customerInfos;
        }

        private void FillCustomerInfo(CustomerInfo dt)
        {
            txtBalance.Text = dt.totalWalletAmount.ToString();
            txtName.Text = dt.customerName;
            txtPhone.Text = dt.phoneNo;

        }

        private string LoadAPiData()
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            request.ContentType = "application/json";
            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    return responseReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.WriteLine(e.Message);
            }
            return "";
        }
    }
}
