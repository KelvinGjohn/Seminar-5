namespace Seminar_5.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string BankAddress { get; set; }   // 3a) simple 11-digit number

        // One client has many invoices
        public List<Invoice> Invoices { get; set; }

        public Client(string name, string address, string phoneNumber, string bankAddress)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            BankAddress = bankAddress;
        }
    }
}
