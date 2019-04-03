namespace TipCalculator
{
    public class Tip
    {
        public Tip()
        {
            BillAmount = string.Empty;
            TipAmount = string.Empty;
            TotalAmount = string.Empty;
        }
        public void CalculateTip(string amount, double percentage)
        {
            double billAmount = 0.0;
            double tipAmount = 0.0;
            double totalAmount = 0.0;
            if (double.TryParse(amount.Substring(1), out billAmount))
            {
                tipAmount = billAmount * percentage;
                totalAmount = billAmount + tipAmount;
            }
            BillAmount = string.Format("{0:C}", billAmount);
            TipAmount = string.Format("{0:C}", tipAmount);
            TotalAmount = string.Format("{0:C}", totalAmount);
        }
        public string BillAmount { get; set; }
        public string TipAmount { get; set; }
        public string TotalAmount { get; set; }
    }
}
