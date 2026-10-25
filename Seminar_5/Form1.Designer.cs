namespace Seminar_5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnInvoices = new Button();
            btnClients = new Button();
            btnPayments = new Button();
            groupBoxSearch = new GroupBox();
            dataGridView = new DataGridView();
            btnInvoiceClientInfo = new Button();
            btnNotPaidInvoices = new Button();
            btnClientFinancialStatistics = new Button();
            btnOverdueInvoices = new Button();
            btnTop3Clients = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            //
            // btnInvoices
            //
            btnInvoices.Location = new Point(110, 10);
            btnInvoices.Name = "btnInvoices";
            btnInvoices.Size = new Size(75, 25);
            btnInvoices.Text = "Invoices";
            btnInvoices.Click += btnInvoices_Click;
            //
            // btnClients
            //
            btnClients.Location = new Point(195, 10);
            btnClients.Name = "btnClients";
            btnClients.Size = new Size(75, 25);
            btnClients.Text = "Clients";
            btnClients.Click += btnClients_Click;
            //
            // btnPayments
            //
            btnPayments.Location = new Point(280, 10);
            btnPayments.Name = "btnPayments";
            btnPayments.Size = new Size(75, 25);
            btnPayments.Text = "Payments";
            btnPayments.Click += btnPayments_Click;
            //
            // groupBoxSearch
            //
            groupBoxSearch.Location = new Point(110, 40);
            groupBoxSearch.Name = "groupBoxSearch";
            groupBoxSearch.Size = new Size(760, 85);
            groupBoxSearch.Text = "Search";
            //
            // dataGridView
            //
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Location = new Point(110, 135);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new Size(760, 320);
            //
            // btnInvoiceClientInfo
            //
            btnInvoiceClientInfo.Location = new Point(12, 135);
            btnInvoiceClientInfo.Name = "btnInvoiceClientInfo";
            btnInvoiceClientInfo.Size = new Size(85, 40);
            btnInvoiceClientInfo.Text = "Invoice Client Info";
            btnInvoiceClientInfo.Click += btnInvoiceClientInfo_Click;
            //
            // btnNotPaidInvoices
            //
            btnNotPaidInvoices.Location = new Point(12, 185);
            btnNotPaidInvoices.Name = "btnNotPaidInvoices";
            btnNotPaidInvoices.Size = new Size(85, 40);
            btnNotPaidInvoices.Text = "Not Paid Invoices";
            btnNotPaidInvoices.Click += btnNotPaidInvoices_Click;
            //
            // btnClientFinancialStatistics
            //
            btnClientFinancialStatistics.Location = new Point(12, 235);
            btnClientFinancialStatistics.Name = "btnClientFinancialStatistics";
            btnClientFinancialStatistics.Size = new Size(85, 50);
            btnClientFinancialStatistics.Text = "Client Financial Statistics";
            btnClientFinancialStatistics.Click += btnClientFinancialStatistics_Click;
            //
            // btnOverdueInvoices
            //
            btnOverdueInvoices.Location = new Point(12, 295);
            btnOverdueInvoices.Name = "btnOverdueInvoices";
            btnOverdueInvoices.Size = new Size(85, 40);
            btnOverdueInvoices.Text = "Overdue Invoices";
            btnOverdueInvoices.Click += btnOverdueInvoices_Click;
            //
            // btnTop3Clients
            //
            btnTop3Clients.Location = new Point(12, 345);
            btnTop3Clients.Name = "btnTop3Clients";
            btnTop3Clients.Size = new Size(85, 40);
            btnTop3Clients.Text = "Top 3 Clients";
            btnTop3Clients.Click += btnTop3Clients_Click;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 471);
            Controls.Add(btnInvoices);
            Controls.Add(btnClients);
            Controls.Add(btnPayments);
            Controls.Add(groupBoxSearch);
            Controls.Add(dataGridView);
            Controls.Add(btnInvoiceClientInfo);
            Controls.Add(btnNotPaidInvoices);
            Controls.Add(btnClientFinancialStatistics);
            Controls.Add(btnOverdueInvoices);
            Controls.Add(btnTop3Clients);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnInvoices;
        private Button btnClients;
        private Button btnPayments;
        private GroupBox groupBoxSearch;
        private DataGridView dataGridView;
        private Button btnInvoiceClientInfo;
        private Button btnNotPaidInvoices;
        private Button btnClientFinancialStatistics;
        private Button btnOverdueInvoices;
        private Button btnTop3Clients;
    }
}
