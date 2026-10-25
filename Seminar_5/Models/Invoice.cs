using System.ComponentModel.DataAnnotations;

namespace Seminar_5.Models
{
    public class Invoice
    {
        [Key]
        public string InvoiceNumber { get; set; }   // 3b) "VEA_XXXXX_XXXXXX"

        public int ClientId { get; set; }            // FK -> Client
        public Client Client { get; set; }

        public string Title { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DueDate { get; set; }

        // One invoice has many payments
        public List<Payment> Payments { get; set; }

        public Invoice(string invoiceNumber, int clientId, string title, decimal totalAmount, DateTime dueDate)
        {
            InvoiceNumber = invoiceNumber;
            ClientId = clientId;
            Title = title;
            TotalAmount = totalAmount;
            DueDate = dueDate;
        }
    }
}
