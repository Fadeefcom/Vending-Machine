namespace VendingMachine.Models
{
    public class CoinTypeViewModel
    {
        public int Value { get; set; }

        public string ValueString
        {
            get
            {
                return Value.ToString();
            }
        }

        public string Name { get; set; }

        public bool Disabled { get; set; }

        public int Id { get; set; }

        public CoinTypeViewModel()
        {
            Value = 0;
            Name = string.Empty;
            Disabled = true;
        }
    }
}
