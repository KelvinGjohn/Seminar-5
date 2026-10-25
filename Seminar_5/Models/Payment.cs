using Seminar_5.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seminar_5.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Invoice))]
        public string InvoiceNumber { get; set; }    // FK -> Invoice
        public Invoice Invoice { get; set; }

        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public Payment() { }

        public Payment(string invoiceNumber, double amount, PaymentMethod paymentMethod)
        {
            InvoiceNumber = invoiceNumber;
            Amount = amount;
            PaymentMethod = paymentMethod;
        }
    }
}
