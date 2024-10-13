using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Quest = QuestPDF.Infrastructure;

namespace QuestPDFTest
{
    class PaymentReport : IDocument
    {

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public void Compose(IDocumentContainer container)
        {
            var textStyle = TextStyle.Default.SemiBold().FontFamily("Almarai").Medium();

            container
                .Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(20);
                    page.DefaultTextStyle(textStyle);
                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                   // page.Footer().Element(ComposeFooter);
                });
        }

        public void ComposeHeader(IContainer container)
        {
        
            container.Column(column =>
            {
                // Second row in the header
                column.Item().Row(row =>
                {
                   

                    row.RelativeItem().AlignCenter().Column(innerColumn =>
                    {
                        innerColumn.Item().PaddingBottom(3, Quest.Unit.Millimetre).Text(e =>
                        {
                            e.Span("من تاريخ");
                            e.Span("   :   ");
                            e.Span("  66-44-1998 ");

                        });
                        innerColumn.Item().Text(e =>
                        {
                            e.Span("الى تاريخ");
                            e.Span("   :   ");
                            e.Span("  66-44-1998 ");

                        });
                    });

                    row.RelativeItem().Column(innerColumn =>
                    {
                        innerColumn.Item().PaddingBottom(3, Quest.Unit.Millimetre)
                        .PaddingRight(3, Quest.Unit.Millimetre)
                        .AlignRight().Text("تقرير العهد").FontSize(13).SemiBold();

                        innerColumn.Item().PaddingBottom(3, Quest.Unit.Millimetre)
                       .PaddingRight(3, Quest.Unit.Millimetre)
                       .AlignRight().Text("اسم طريقة الدفع").FontSize(13);
                    });

                    row.ConstantItem(50).Image("Resources/Images/logo.png"); // Placeholder for company logo
                });

                column.Item().PaddingVertical(6);
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(10).Column(column =>
            {


                column.Item().ContentFromRightToLeft().Border(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);

                    });

                    table.Header(header =>
                    {
                        header.Cell().PaddingBottom(5, Quest.Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("التاريخ").AlignCenter().Bold();
                        header.Cell().PaddingBottom(5, Quest.Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("الرقم").AlignCenter().Bold();
                        header.Cell().PaddingBottom(5, Quest.Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("النوع").AlignCenter().Bold();
                        header.Cell().PaddingBottom(5, Quest.Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("الكمية الاجمالية").AlignCenter().Bold();
                        header.Cell().PaddingBottom(5, Quest.Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("المتراكمة").AlignCenter().Bold();
                    });

                    for (int i = 0; i < 10; i++)
                    {
                        table.Cell().BorderLeft(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1)
                        .PaddingBottom(10, Quest.Unit.Millimetre).AlignCenter().Text("11-5-2011");
                        ;
                        table.Cell().BorderLeft(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Text("10").AlignCenter();
                        table.Cell().BorderLeft(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).AlignCenter().Text("Expense ");
                        table.Cell().BorderLeft(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).AlignCenter().Text("88554 ");
                        table.Cell().BorderLeft(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).AlignCenter().Text("0 ");

                    }
                });

            });
        }

        void ComposeFooter(IContainer container)
        {
            var footerImage = SvgImage.FromFile("Resources/Images/footer.svg");

            container.Column(column =>
            {
                column.Item().PaddingTop(.5f, Quest.Unit.Centimetre).Svg(footerImage);
            });
        }

    }
}
