namespace SampleWpf
{
    public partial class MainWindow
    {
        public class CustomerTransaction
        {
             

            public string Branch { get; set; }
            public string TranDate { get; set; }
            public string CheckNo { get; set; }
            public double CheckAmount { get; set; }
            public double GeneratedLoyaltyAmount { get; set; }
            public double UsedLoyaltyAmount { get; set; }

            public override string ToString()
            {
                return $"CheckNo {CheckNo}, Branch {Branch} , Amount {CheckAmount}, Date {TranDate}";
            }
        }
    }
}
