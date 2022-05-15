using System.Collections.Generic;

namespace SampleWpf
{
    public partial class MainWindow
    {
        public class CustomerInfo
        {
            public int customerID { get; set; }
            public string phoneNo { get; set; }
            public string customerName { get; set; }
            public double totalWalletAmount { get; set; }
            public override string ToString()
            {
                return base.ToString();
            }
            public List<CustomerTransaction> customerTransactions { get; set; }
        }
    }
}
