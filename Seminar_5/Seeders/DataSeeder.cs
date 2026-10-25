using Bogus;
using Seminar_5.Enums;
using Seminar_5.Models;

namespace Seminar_5.Seeders
{
    internal class DataSeeder
    {
        public void SeedDatabase()
        {
            AppDbContext db = new AppDbContext();

            // If there is already data, do not add it again
            if (db.Clients.Any())
            {
                return;
            }

            Faker faker = new Faker();

            // ---------- 30 CLIENTS ----------
            var clientFaker = new Faker<Client>()
                .CustomInstantiator(f => new Client(
                    faker.Company.CompanyName(),
                    faker.Address.FullAddress(),
                    faker.Phone.PhoneNumber("2#######"),
                    faker.Random.ReplaceNumbers("###########")   // 11 digits
                ));
            var clients = clientFaker.Generate(30);
            db.Clients.AddRange(clients);
            db.SaveChanges();   // after saving, every client has an Id

            // ---------- 200 INVOICES ----------
            var invoiceFaker = new Faker<Invoice>()
                .CustomInstantiator(f => new Invoice(
                    MakeUniqueInvoiceNumber(faker),
                    faker.PickRandom(clients).Id,
                    faker.Hacker.Phrase(),
                    Math.Round(faker.Random.Double(50, 5000), 2),
                    faker.Date.Between(
                        new DateTime(2024, 1, 1),
                        new DateTime(2027, 6, 1)
                    )
                ));
            var invoices = invoiceFaker.Generate(200);
            db.Invoices.AddRange(invoices);
            db.SaveChanges();

            // ---------- 400 PAYMENTS ----------
            var paymentFaker = new Faker<Payment>()
                .CustomInstantiator(f =>
                {
                    Invoice invoice = faker.PickRandom(invoices);
                    return new Payment(
                        invoice.InvoiceNumber,
                        Math.Round(faker.Random.Double(10, invoice.TotalAmount / 2), 2),
                        faker.Random.Enum<PaymentMethod>()
                    );
                });
            var payments = paymentFaker.Generate(400);
            db.Payments.AddRange(payments);
            db.SaveChanges();
        }

        // InvoiceNumber is the primary key, so it must be UNIQUE.
        // We remember every number we made and try again if it already exists.
        // # = random digit  ->  e.g. VEA_48213_903417
        private List<string> usedNumbers = new List<string>();

        private string MakeUniqueInvoiceNumber(Faker faker)
        {
            string number = faker.Random.ReplaceNumbers("VEA_#####_######");

            while (usedNumbers.Contains(number))
            {
                number = faker.Random.ReplaceNumbers("VEA_#####_######");
            }

            usedNumbers.Add(number);
            return number;
        }
    }
}
