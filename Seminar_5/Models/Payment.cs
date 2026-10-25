namespace Seminar_5.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public string InvoiceNumber { get; set; }    // FK -> Invoice
        public Invoice Invoice { get; set; }

        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public Payment(string invoiceNumber, decimal amount, PaymentMethod paymentMethod)
        {
            InvoiceNumber = invoiceNumber;
            Amount = amount;
            PaymentMethod = paymentMethod;
        }
    }
}
