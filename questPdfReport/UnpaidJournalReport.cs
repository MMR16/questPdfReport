using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Quest = QuestPDF.Infrastructure;

namespace QuestPDFTest
{
    public class UnpaidJournalReport : IDocument
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
                    page.Footer().Element(ComposeFooter);
                });
        }

        public void ComposeHeader(IContainer container)
        {
            var Header2Image = SvgImage.FromFile("Resources/Images/Header2.svg");
            var Header1Image = SvgImage.FromFile("Resources/Images/Header1.svg");
            var Location = SvgImage.FromFile("Resources/Images/Location.svg");
            container.Column(column =>
            {
                // First row in the header
                column.Item().PaddingBottom(0.8f, Quest.Unit.Centimetre).ContentFromRightToLeft().Row(row =>
                {
                    row.RelativeItem(4).Column(column =>
                    {
                        column.Item()
                              .Height(15)
                              .Svg(Header1Image);
                    });

                    row.RelativeItem(1.5f).Column(column =>
                    {
                        column.Item().Text("سند مصروف").FontSize(20).SemiBold();
                    });

                    row.AutoItem().Column(column =>
                    {
                        column.Item()
                        .Height(15)
                        .Svg(Header2Image);
                    });
                });

                // Second row in the header
                column.Item().Row(row =>
                {
                    row.RelativeItem().Column(innerColumn =>
                    {
                        innerColumn.Item().PaddingBottom(3).MaxWidth(3, Quest.Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().Text("رقم السند").Bold().AlignCenter();
                        });
                        innerColumn.Item().PaddingBottom(4).MaxWidth(3, Quest.Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().Border(1f, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten2).Text("24").AlignCenter();
                        });
                        innerColumn.Item().PaddingBottom(3).Row(innerRow =>
                        {
                            innerRow.RelativeItem().Text(e =>
                            {
                                e.Span("تاريخ السند :").FontSize(10).SemiBold();
                                e.Span("12/3/1997").FontSize(10);
                            });
                        });
                    });

                    row.RelativeItem().AlignCenter().Column(innerColumn =>
                    {
                        innerColumn.Item().Text("جدة حي بغداد");
                        innerColumn.Item().Text("شارع ابن تيمية - عمارة 1");
                        innerColumn.Item().Text("");
                        innerColumn.Item().AlignCenter().Text("0115036923");
                        innerColumn.Item().AlignCenter().Text("0553694400256");
                    });

                    row.RelativeItem().Column(innerColumn =>
                    {
                        innerColumn.Item().PaddingBottom(3, Quest.Unit.Millimetre).PaddingRight(3, Quest.Unit.Millimetre).AlignRight().Text("شركة الشرق الأوسط المتقدم").FontSize(13).SemiBold();
                        innerColumn.Item().PaddingBottom(3, Quest.Unit.Millimetre).PaddingRight(3, Quest.Unit.Millimetre).AlignRight().Text("الرقم الضريبي: 310098765678654").FontSize(10);
                        innerColumn.Item().PaddingRight(3, Quest.Unit.Millimetre).AlignRight().Text("الفرع / فرع جدة").FontSize(10);
                    });

                    row.ConstantItem(50).Image("Resources/Images/logo.png"); // Placeholder for company logo
                });

                column.Item().PaddingVertical(6); //.BorderBottom(1).BorderColor(Colors.Red.Lighten1);
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(10).Column(column =>
            {
                column.Item().Row(row =>
                {
                    row.RelativeItem().ScaleToFit().Border(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Column(column =>
                    {
                        column.Item().PaddingTop(10).Row(innerRow =>
                        {
                            innerRow.RelativeItem().MinHeight(1, Quest.Unit.Centimetre).AlignRight().Text(" غير مدفوع");
                            innerRow.ConstantItem(2.5f, Quest.Unit.Centimetre).AlignRight().PaddingRight(10).Text(": حالة الدفع").Bold();
                        });
                    });

                    row.ConstantItem(1, Quest.Unit.Centimetre); // seperate y

                    //row.RelativeItem().Border(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Column(column =>
                    //{
                    //    column.Item().Row(innerRow =>
                    //    {
                    //        innerRow.RelativeItem().MinHeight(1, Quest.Unit.Centimetre).AlignRight().Text("مورد مبيعات نيو تايم");
                    //        innerRow.ConstantItem(3, Quest.Unit.Centimetre).AlignRight().Border(1, Quest.Unit.Point).Text("المورد").Bold();
                    //    });

                    //    column.Item().Row(innerRow =>
                    //    {
                    //        innerRow.RelativeItem().MinHeight(1, Quest.Unit.Centimetre).AlignRight().Text("5156121");
                    //        innerRow.ConstantItem(3, Quest.Unit.Centimetre).AlignRight().Border(1, Quest.Unit.Point).Text("فاتورة رقم").Bold();
                    //    });
                    //    column.Item().AlignRight().Text("تيشرتات وملابس وأجهزة ");
                    //});


                    //description of journal
                    row.RelativeItem().ScaleToFit().ContentFromRightToLeft()

                    .Border(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Column(column =>
                    {
                        column.Item().Padding(5, Quest.Unit.Millimetre).Text("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It haspsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passage.");
                    });
                });

                column.Item().Padding(20); //seperate x


                column.Item().ContentFromRightToLeft().Border(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(3);
                        columns.RelativeColumn(2);
                       
                    });

                    table.Header(header =>
                    {
                        header.Cell().PaddingBottom(5, Quest.Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("المصروف").AlignCenter().Bold();
                        header.Cell().PaddingBottom(5, Quest.Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("الوصف").AlignCenter().Bold();
                        header.Cell().PaddingBottom(5, Quest.Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("المبلغ").AlignCenter().Bold();
                    });

                    for (int i = 0; i < 10; i++)
                    {
                        table.Cell().BorderLeft(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).PaddingBottom(10, Quest.Unit.Millimetre).AlignCenter().Text(e =>
                        {
                            e.Span("مصاريف الكهرباء");
                            e.EmptyLine();
                            e.Span("545415641").FontColor(Colors.Grey.Medium);
                        });
                        ;
                        table.Cell().BorderLeft(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Text("فاتورة كهرباء شهر أكتوبر لفرع الحمدانية").AlignCenter();
                        table.Cell().BorderLeft(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).AlignCenter().Text(e =>
                        {
                            e.Span("165.00");
                            e.Span(" ر.س ").FontColor(Colors.Grey.Darken1).FontSize(8);
                        });

                    }
                });

                column.Item().Padding(20); //seperate x





                column.Item().MaxWidth(12, Quest.Unit.Centimetre).Row(row =>
                {

                    row.ConstantItem(1, Quest.Unit.Centimetre); // seperate y

                    row.RelativeItem().Column(column =>
                    {
                        column.Item().PaddingTop(1,Quest.Unit.Inch).BorderTop(2.2f, Quest.Unit.Point).BorderColor(Colors.Black).AlignCenter().Row(innerRow =>
                        {
                            innerRow.RelativeItem(1).PaddingTop(1,Quest.Unit.Centimetre).MinHeight(1, Quest.Unit.Centimetre).ContentFromRightToLeft().AlignRight().Text(e =>
                            {

                                e.Span(" 4500.00 ").Bold();
                                e.Span(" ر.س ").FontSize(8).Bold(); 
                            });
                            innerRow.Spacing(1.5f,Quest.Unit.Inch);
                            innerRow.RelativeItem(2).PaddingTop(1, Quest.Unit.Centimetre).Text("اجمالي مبلغ المصروف").SemiBold();
                        });
                    });
                });

            });
        }

        void ComposeFooter(IContainer container)
        {
            container.Row(row =>
            {
                var footerImage = SvgImage.FromFile("Resources/Images/footer.svg");
                row.RelativeItem().Svg(footerImage);
            });
        }

    }
}
