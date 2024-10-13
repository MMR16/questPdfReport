// See https://aka.ms/new-console-template for more information
using QuestPDF.Companion;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using QuestPDFTest;
using System.Reflection;
using System.Runtime.CompilerServices;

internal class Program
{

    private static SvgImage Header1Image { get; } = SvgImage.FromFile("Resources/Images/Header1.svg");
    private static SvgImage Header2Image { get; } = SvgImage.FromFile("Resources/Images/Header2.svg");
    private static SvgImage TwitterLogo { get; } = SvgImage.FromFile("Resources/Images/TwitterLogo.svg");
    private static SvgImage InstagramLogo { get; } = SvgImage.FromFile("Resources/Images/InstagramLogo.svg");
    private static SvgImage SnapchatLogo { get; } = SvgImage.FromFile("Resources/Images/SnapchatLogo.svg");
    private static SvgImage TelephoneImage { get; } = SvgImage.FromFile("Resources/Images/Telephone.svg");
    private static SvgImage PhoneImage { get; } = SvgImage.FromFile("Resources/Images/Phone.svg");
    private static SvgImage Location { get; } = SvgImage.FromFile("Resources/Images/Location.svg");

    private static void Main(string[] args)
    {


      //  var document = new PaymentReport();

        // var document = new JournalPaymenmtDetails();

      //  document.ShowInPreviewer();
       // document.GeneratePdf("report.pdf");

        QuestPDF.Settings.License = LicenseType.Community;
        var document = new UnpaidJournalReport();
        document.ShowInCompanion(12500);
       // var document = new UnpaidJournalReport();
       // var document = new JournalPaymenmtDetails();
      //  document.ShowInPreviewer();
      //  document.GeneratePdf("report.pdf");
        var Model = new JournalInvovice
        {
            Adress = "adress",
            branch = "Branch",
            CompanyName = "Company Name",
            CreatedDate = DateOnly.FromDateTime(DateTime.Now),
            Description = "Description kfdnasklfn sdfna ngkdsm klm",
            FirstPhoneNum = "5415154121",
            SecondPhoneNum = "42121515212541",
            InvoiceNumber = "1024",
            IsPaid = "paid",
            Number = 10,
            PaymentDate = DateOnly.FromDateTime(DateTime.Now),
            PaymentMethod = "Bank",
            Reciever = "MMR",
            Supplier = "Ali",
            TaxAmount = 10,
            TaxNumber = "vat 12152",
            Total = 100,
            TotalAmount = 110,
            Files = new List<JournalFileInvoice>  {
                new JournalFileInvoice{ Name="file name",URL="new url"}
            },
            JournalDetails = new List<JournalDetailInvoice>
            {
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
                new JournalDetailInvoice { Description="Journal details descriptin",ExpenseName="Expense",ExpenseNumber=10,Amount=100,TaxAmount = 10,TotalAmount=110,TaxPercentage = "10%" },
            }
        };

        Console.WriteLine("Hello, World!");
        //ConfigureQuestPDF();
        //var document = Document.Create(container =>
        //{

        //    container.Page(page =>
        //            {

        //                page.MarginVertical(10);
        //                page.MarginHorizontal(4);
        //                page.PageColor(Colors.White);
        //                // page.ContinuousSize(50.8f, Unit.Millimetre);

        //                page.PageColor(Colors.White);
        //                page.DefaultTextStyle(x => x.FontSize(11));
        //                page.ContentFromRightToLeft();
        //                page.Header().Element(ComposeHeader);
        //                page.Content().Element(ComposeContent);
        //            });
        //});
        //document.ShowInPreviewer();
        //void ConfigureQuestPDF()
        //{
        //    QuestPDF.Settings.License = LicenseType.Community;

        //    FontManager.RegisterFont(File.OpenRead("Fonts/Almarai-Regular.ttf"));
        //    FontManager.RegisterFont(File.OpenRead("Fonts/LibreBarcode39Extended-Regular.ttf"));
        //    FontManager.RegisterFont(File.OpenRead("Fonts/LibreBarcode128-Regular.ttf"));
        //}

        //void ComposeHeader(IContainer container)
        //{
        //    container.Row(row =>
        //    {
        //        row.Spacing(1);

        //        row.RelativeItem().Column(column =>
        //        {
        //            column
        //            .Item()
        //            .Height(10)
        //            .Svg(Header1Image);
        //        });

        //        row.RelativeItem().Column(column =>
        //        {
        //            column
        //                .Item().PaddingLeft(20).AlignLeft().Text("سند مصروف").FontSize(12).ExtraBold();
        //        });
        //        row.AutoItem().Column(column =>
        //        {
        //            column.Item()
        //            .Height(10)
        //            .Svg(Header2Image);
        //        });
        //    });
        //}
        //void HorizontalLine(IContainer container)
        //{
        //    container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingBottom(5);
        //}

        //void ComposeContent(IContainer container)
        //{


        //    //container.Row(row =>
        //    //{
        //    //    row.RelativeItem().Column(column =>
        //    //    {
        //    //        column
        //    //        .Item()
        //    //        .Height(10)
        //    //        .Text("dddddddddddd");
        //    //    });
        //    //});
        //    container.PaddingTop(20).PaddingRight(10).PaddingLeft(10).Column(column =>
        //  {
        //      column.Spacing(10);



        //      column.Item().AlignRight().PaddingRight(50).Text(Model.CompanyName)
        //            .FontSize(12).ExtraBold();

        //      column.Item().ShowIf(Model.SecondPhoneNum != null).Row(row =>
        //      {
        //          row.ConstantItem(10).Svg(TelephoneImage);
        //          row.RelativeItem().PaddingRight(5);
        //      });

        //      column.Item().AlignRight().Text(text =>
        //      {
        //          text.Span("الرقم الضريبي / ").Medium();
        //          text.Span(Model.TaxNumber).Light();
        //      });

        //      column.Item().AlignRight().ShowIf(Model.TaxAmount != null).Text(text =>
        //      {
        //          text.Span("رقم السجل التجاري / ").Medium();
        //          text.Span(Model.Number.ToString()).Light();
        //      });

        //      column.Item().Row(row =>
        //      {
        //          row.RelativeItem().Text("أصدرت بواسطة");

        //          row.RelativeItem().AlignLeft().Text(Model.Reciever);
        //      });

        //      column.Item().Row(row =>
        //      {
        //          row.RelativeItem().Text("رقم الكاشير");

        //          row.RelativeItem().AlignLeft().Width(30).Border(1).Column(column =>
        //          {
        //              column.Item().AlignCenter().AlignMiddle().Text(Model.InvoiceNumber.ToString());
        //          });
        //      });

        //      //column.Item().Row(row =>
        //      //{
        //      //    if (Model.Adress != null)
        //      //    {
        //      //        row.ConstantItem(10).Svg(Location);

        //      //        row.AutoItem().PaddingRight(5).Column(column =>
        //      //        {
        //      //            column.Item().Text(Model.Adress);
        //      //            //  column.Item().Text(Model.Branch.Address2);
        //      //        });
        //      //    }

        //      //    row.RelativeItem().AlignLeft().Width(80).Column(column =>
        //      //    {
        //      //        column.Spacing(5);
        //      //        column.Item().ShowIf(Model.FirstPhoneNum != null).Row(row =>
        //      //        {
        //      //            row.ConstantItem(10).Svg(PhoneImage);
        //      //            row.RelativeItem().PaddingRight(5).Text(Model.FirstPhoneNum);
        //      //        });

        //      //        column.Item().ShowIf(Model.SecondPhoneNum != null).Row(row =>
        //      //        {
        //      //            row.ConstantItem(10).Svg(TelephoneImage);
        //      //            row.RelativeItem().PaddingRight(5).Text(Model.SecondPhoneNum);
        //      //        });

        //      //    });
        //      //});

        //      column.Item().Element(HorizontalLine);


        //      //column.Item().Row(row =>
        //      //{
        //      //    row.AutoItem().Column(column =>
        //      //    {
        //      //        column.Spacing(6);
        //      //        column.Item().Text(text =>
        //      //        {
        //      //            text.Span("تاريخ الإصدار / ");
        //      //            text.Span(Model.CreatedDate.ToShortDateString()).Light();
        //      //        });

        //      //        column.Item().Text(text =>
        //      //        {
        //      //            text.Span("وقت الإصدار / ");
        //      //            text.Span(Model.CreatedDate.ToString()).Light();
        //      //        });
        //      //    });


        //      //    row.RelativeItem().AlignLeft().Column(column =>
        //      //    {
        //      //        column.Spacing(6);
        //      //        column.Item().Text("رقم الفاتورة");
        //      //        column.Item().AlignCenter().Text(Model.Number.ToString()).FontSize(14).ExtraBold();
        //      //    });
        //      //});

        //      //column.Item().Element(HorizontalLine);

        //      //column.Item().PaddingRight(10).Text(Model.CompanyName).FontSize(16).Bold();

        //      //column.Item().Element(HorizontalLine);

        //      //column.Item().Element(ComposeTable);

        //      //column.Item().Element(HorizontalLine);

        //      //column.Item().Element(ComposeTotals);

        //      //column.Item().Element(ComposePayment);




        //      column.Item().Element(HorizontalLine);

        //      //column.Item().ShowIf(Model.Barcode != null).AlignCenter().Row(row =>
        //      //{
        //      //    row.ConstantItem(100).Image(Model.Barcode!);
        //      //});

        //      //column.Item().ShowIf(Model.Company.ReportNotes != null).Element(ComposeComments);
        //      //column.Item().Element(ComposeSocials);

        //      column.Item().PaddingTop(5).Row(row =>
        //      {
        //          row.AutoItem().Text("نسخة 1");
        //          row.RelativeItem().AlignCenter().Text("شكرا لزيارتكم").SemiBold();
        //      });
        //  });
        //}


    }
}


public class PrintProductsBarcodes
{
    public string CompanyName { get; set; }
    public string Name { get; set; }
    public string Barcode { get; set; }
    public decimal Price { get; set; }
    public string CurrencyCode { get; set; }
}