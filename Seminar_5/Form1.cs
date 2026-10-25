using Seminar_5.Models;
using Seminar_5.Seeders;

namespace Seminar_5
{
    public partial class Form1 : Form
    {
        // Search controls for the Invoices table
        ComboBox cmbInvoiceNr;
        TextBox txtMinAmount;
        TextBox txtMaxAmount;
        DateTimePicker dtpMinDate;
        DateTimePicker dtpMaxDate;

        // Search controls for the Clients table
        TextBox txtClientName;

        // Search controls for the Payments table
        ComboBox cmbPaymentInvoiceNr;
        ComboBox cmbPaymentMethod;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 4) Create the database (if it does not exist yet)
            AppDbContext db = new AppDbContext();
            db.Database.EnsureCreated();

            // 5) Fill it with fake data
            DataSeeder seeder = new DataSeeder();
            seeder.SeedDatabase();

            // Show invoices when the app starts
            btnInvoices_Click(null, null);
        }

        // =====================================================
        // 7) Three buttons that show the tables
        // =====================================================

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            AppDbContext db = new AppDbContext();

            // 7a) Put the search controls for invoices in the GroupBox
            groupBoxSearch.Controls.Clear();

            AddLabel("INV Nr", 10, 25);
            cmbInvoiceNr = new ComboBox();
            cmbInvoiceNr.Location = new Point(10, 45);
            cmbInvoiceNr.Width = 180;
            cmbInvoiceNr.Items.AddRange(db.Invoices.Select(i => i.InvoiceNumber).ToArray());
            cmbInvoiceNr.TextChanged += FilterInvoices;
            groupBoxSearch.Controls.Add(cmbInvoiceNr);

            AddLabel("Total Amount  Min  -  Max", 210, 25);
            txtMinAmount = new TextBox();
            txtMinAmount.Location = new Point(210, 45);
            txtMinAmount.Width = 70;
            txtMinAmount.TextChanged += FilterInvoices;
            groupBoxSearch.Controls.Add(txtMinAmount);

            txtMaxAmount = new TextBox();
            txtMaxAmount.Location = new Point(290, 45);
            txtMaxAmount.Width = 70;
            txtMaxAmount.TextChanged += FilterInvoices;
            groupBoxSearch.Controls.Add(txtMaxAmount);

            AddLabel("Due Date Min", 390, 20);
            dtpMinDate = new DateTimePicker();
            dtpMinDate.Location = new Point(480, 17);
            dtpMinDate.Width = 220;
            dtpMinDate.Value = new DateTime(2024, 1, 1);
            dtpMinDate.ValueChanged += FilterInvoices;
            groupBoxSearch.Controls.Add(dtpMinDate);

            AddLabel("Due Date Max", 390, 52);
            dtpMaxDate = new DateTimePicker();
            dtpMaxDate.Location = new Point(480, 49);
            dtpMaxDate.Width = 220;
            dtpMaxDate.Value = new DateTime(2027, 12, 31);
            dtpMaxDate.ValueChanged += FilterInvoices;
            groupBoxSearch.Controls.Add(dtpMaxDate);

            FilterInvoices(null, null);
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            groupBoxSearch.Controls.Clear();

            AddLabel("Name", 10, 25);
            txtClientName = new TextBox();
            txtClientName.Location = new Point(10, 45);
            txtClientName.Width = 200;
            txtClientName.TextChanged += FilterClients;
            groupBoxSearch.Controls.Add(txtClientName);

            FilterClients(null, null);
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            AppDbContext db = new AppDbContext();

            groupBoxSearch.Controls.Clear();

            AddLabel("INV Nr", 10, 25);
            cmbPaymentInvoiceNr = new ComboBox();
            cmbPaymentInvoiceNr.Location = new Point(10, 45);
            cmbPaymentInvoiceNr.Width = 180;
            cmbPaymentInvoiceNr.Items.AddRange(db.Invoices.Select(i => i.InvoiceNumber).ToArray());
            cmbPaymentInvoiceNr.TextChanged += FilterPayments;
            groupBoxSearch.Controls.Add(cmbPaymentInvoiceNr);

            AddLabel("Payment Method", 210, 25);
            cmbPaymentMethod = new ComboBox();
            cmbPaymentMethod.Location = new Point(210, 45);
            cmbPaymentMethod.Width = 150;
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Items.Add("All");
            cmbPaymentMethod.Items.AddRange(Enum.GetNames(typeof(PaymentMethod)));
            cmbPaymentMethod.SelectedIndex = 0;
            cmbPaymentMethod.SelectedIndexChanged += FilterPayments;
            groupBoxSearch.Controls.Add(cmbPaymentMethod);

            FilterPayments(null, null);
        }

        // Small helper: adds a label to the Search GroupBox
        private void AddLabel(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.AutoSize = true;
            groupBoxSearch.Controls.Add(label);
        }

        // =====================================================
        // 7b) Dynamic filtering - runs every time a search box changes
        // =====================================================

        private void FilterInvoices(object sender, EventArgs e)
        {
            AppDbContext db = new AppDbContext();
            var invoices = db.Invoices.ToList();

            // Invoice number
            if (cmbInvoiceNr.Text != "")
            {
                invoices = invoices.Where(i => i.InvoiceNumber.Contains(cmbInvoiceNr.Text)).ToList();
            }

            // Min amount (only if the text is a number)
            if (decimal.TryParse(txtMinAmount.Text, out decimal min))
            {
                invoices = invoices.Where(i => i.TotalAmount >= min).ToList();
            }

            // Max amount
            if (decimal.TryParse(txtMaxAmount.Text, out decimal max))
            {
                invoices = invoices.Where(i => i.TotalAmount <= max).ToList();
            }

            // Due date between Min and Max
            invoices = invoices
                .Where(i => i.DueDate.Date >= dtpMinDate.Value.Date && i.DueDate.Date <= dtpMaxDate.Value.Date)
                .ToList();

            dataGridView.DataSource = invoices
                .Select(i => new { i.InvoiceNumber, i.Title, i.TotalAmount, i.DueDate, i.ClientId })
                .ToList();
        }

        private void FilterClients(object sender, EventArgs e)
        {
            AppDbContext db = new AppDbContext();
            var clients = db.Clients.ToList();

            if (txtClientName.Text != "")
            {
                clients = clients
                    .Where(c => c.Name.ToLower().Contains(txtClientName.Text.ToLower()))
                    .ToList();
            }

            dataGridView.DataSource = clients
                .Select(c => new { c.Id, c.Name, c.Address, c.PhoneNumber, c.BankAddress })
                .ToList();
        }

        private void FilterPayments(object sender, EventArgs e)
        {
            AppDbContext db = new AppDbContext();
            var payments = db.Payments.ToList();

            if (cmbPaymentInvoiceNr.Text != "")
            {
                payments = payments.Where(p => p.InvoiceNumber.Contains(cmbPaymentInvoiceNr.Text)).ToList();
            }

            if (cmbPaymentMethod.Text != "All")
            {
                payments = payments.Where(p => p.PaymentMethod.ToString() == cmbPaymentMethod.Text).ToList();
            }

            dataGridView.DataSource = payments
                .Select(p => new { p.Id, p.InvoiceNumber, p.Amount, p.PaymentMethod })
                .ToList();
        }

        // =====================================================
        // 8) LINQ query buttons
        // =====================================================

        private void btnInvoiceClientInfo_Click(object sender, EventArgs e)
        {
        }

        private void btnNotPaidInvoices_Click(object sender, EventArgs e)
        {
        }

        private void btnClientFinancialStatistics_Click(object sender, EventArgs e)
        {
        }

        private void btnOverdueInvoices_Click(object sender, EventArgs e)
        {
        }

        private void btnTop3Clients_Click(object sender, EventArgs e)
        {
        }
    }
}
