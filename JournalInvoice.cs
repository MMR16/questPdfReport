
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestPDFTest
{
    public class JournalInvovice
    {
        public int Number { get; set; }
        public string Adress { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string branch { get; set; }
        public string FirstPhoneNum { get; set; }
        public string SecondPhoneNum { get; set; }
        public DateOnly CreatedDate { get; set; }
        public string IsPaid { get; set; }
        public string PaymentMethod { get; set; }
        public DateOnly PaymentDate { get; set; }
        public string Reciever { get; set; }
        public string Supplier { get; set; }
        public string InvoiceNumber { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public List<JournalDetailInvoice> JournalDetails { get; set; }
        public List<JournalFileInvoice> Files { get; set; }

    }

    public class JournalDetailInvoice
    {
        public string ExpenseName { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public string TaxPercentage { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int ExpenseNumber { get; set; }
    }

    public class JournalFileInvoice
    {
        public string URL { get; set; }
        public string Name { get; set; }
    }
}
