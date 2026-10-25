using System.ComponentModel.DataAnnotations;

namespace Seminar_5.Models
{
    public class Invoice
    {
        [Key]
        public string InvoiceNumber { get; set; }   // 3b) "VEA_XXXXX_XXXXXX"
        public string Title { get; set; }
        public int ClientId { get; set; }            // FK -> Client
        public Client Client { get; set; }
        public double TotalAmount { get; set; }
        public DateTime DueDate { get; set; }

        // One invoice has many payments
        public List<Payment> Payments { get; set; }

        public Invoice() { }

        // Put the values straight into the PROPERTIES (not into extra private fields)
        public Invoice(string invoiceNumber, int clientId, string title, double totalAmount, DateTime dueDate)
        {
            InvoiceNumber = invoiceNumber;
            ClientId = clientId;
            Title = title;
            TotalAmount = totalAmount;
            DueDate = dueDate;
        }
    }
}
