using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using Quest = QuestPDF.Infrastructure;

namespace QuestPDFTest
{
    internal class AccEntryBalance : IDocument
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
            var rightHeader = "Resources/Images/AccountingReport/rightHeader.png";
            var leftHeader = "Resources/Images/AccountingReport/LeftHeader.png";

            container.Column(column =>
            {
                // First row in the header
                column.Item().ContentFromLeftToRight().Row(row =>
                {
                    row.RelativeItem(1).Column(column =>
                    {
                        column.Item()
                        .Height(22)
                        .Width(60)
                         .Image(leftHeader);
                    });

                    row.RelativeItem(2).Column(column =>
                    {
                        column.Item()
                            .AlignCenter()
                            .AlignMiddle()
                            .Text($" تقرير ارصدة حسابات المصروفات")
                            .ExtraBold()
                            .FontSize(13)
                            .AlignCenter();
                    });

                    row.RelativeItem(6).Column(column =>
                    {
                        column.Item()
                          .Height(30)
                        .Width(370)
                        .Image(rightHeader);
                    });
                });

                column.Item().ContentFromRightToLeft().Row(row =>
                    {
                        //if (_companyInfoDto.CompanyLogo is not null)
                        //{
                        //    row.ConstantItem(50).Image(_companyInfoDto.CompanyLogo); // Placeholder for company logo
                        //}
                        //else
                        //{
                        //    row.ConstantItem(50).Image("Resources/Images/logo.png"); // Placeholder for company logo
                        //}
                          row.ConstantItem(50).Image("Resources/Images/logo.png"); // Placeholder for company logo

                        row.RelativeItem().Column(innerColumn =>
                        {
                            innerColumn.Item().PaddingBottom(3, Unit.Millimetre).PaddingRight(3, Unit.Millimetre).AlignRight()
                                .Text(e =>
                                {
                                    e.Span("Branch").FontSize(9);
                                    e.Span("  ");
                                    e.Span("CompanyName").FontSize(13).SemiBold();
                                });
                            innerColumn.Item().PaddingBottom(3, Unit.Millimetre).PaddingRight(3, Unit.Millimetre).AlignRight().Text($"الرقم الضريبي: {"TaxNumber"}").FontSize(10);
                            innerColumn.Item().PaddingBottom(3, Unit.Millimetre).PaddingRight(3, Unit.Millimetre).AlignRight().Text(e =>
                            {
                                e.Span("AdditionallNumber").FontSize(10); ;
                                e.Span(" : ").FontSize(10); ;
                                e.Span("AdditionallNumberValue").FontSize(10); ;
                            });
                        });

                        row.RelativeItem().AlignCenter().Column(innerColumn =>
                        {
                            innerColumn.Item().PaddingBottom(10).Text(e =>
                            {
                                e.Element().Width(3.5f, Unit.Millimetre).Image("Resources/Images/AccountingReport/Location.png").WithCompressionQuality(ImageCompressionQuality.Best);
                                e.Span(" ");
                                e.Span("FullBranchAddess");
                            });

                            innerColumn.Item().AlignCenter().ContentFromRightToLeft().Text(e =>
                            {
                                e.Element().Width(3.5f, Unit.Millimetre).Image("Resources/Images/AccountingReport/Telephone.png").WithCompressionQuality(ImageCompressionQuality.Best);
                                e.Span(" ");
                                e.Span("PhoneNumber");

                                e.Span("   ");

                                e.Element().AlignMiddle().Width(3.5f, Unit.Millimetre).Image("Resources/Images/AccountingReport/Phone.png").WithCompressionQuality(ImageCompressionQuality.Best);
                                e.Span(" ");
                                e.Span("Telephone");
                            });
                        });

                        row.RelativeItem().AlignCenter().Column(innerColumn =>
                        {
                            innerColumn.Item().PaddingBottom(3, Unit.Millimetre).PaddingRight(3, Unit.Millimetre).AlignRight()
                                .Text(e =>
                                {
                                    e.EmptyLine();
                                    e.Span("تاريخ اصدار التقرير");
                                    e.Span(" / ");
                                    e.Span("ConvertDateTimetoArabic").FontSize(9);
                                    e.Span(" | ").FontSize(9);
                                    e.Span("ArabicTime").FontSize(9);
                                });
                        });

                    });

                column.Item().PaddingVertical(6); 
            });
        }

        public void ComposeContent(IContainer container)
        {
            container.ContentFromRightToLeft()
                .Column(column =>
                {
                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().ColumnSpan(5).Background(Color.FromRGB(245, 245, 245)).Element(CellStyle).BorderColor(Colors.Grey.Lighten1).AlignCenter().Text(e =>
                            {
                                e.Span("عن فترة : ");
                            });

                            header.Cell().ShowEntire().Element(MainHeaderlStyle).BorderRight(1).Element(CellStyle).Text("المصروف").Bold();
                            header.Cell().ShowEntire().Element(MainHeaderlStyle).Element(CellStyle).BorderLeft(0).BorderRight(0).Text("رصيد افتتاحي").Bold();
                            header.Cell().ShowEntire().Element(MainHeaderlStyle).Element(CellStyle).Text("رصيد مدفوع").Bold();
                            header.Cell().ShowEntire().Element(MainHeaderlStyle).Element(CellStyle).Text("رصيد مستحق").Bold();
                            header.Cell().ShowEntire().Element(MainHeaderlStyle).BorderLeft(1).Element(CellStyle).Text("اجمالي الرصيد").Bold();

                          //  foreach (var item in _model.Data)
                          //  {
                                table.Cell().ShowEntire().Element(MainContentlStyle).BorderRight(1).Background(Color.FromRGB(245, 245, 245)).Element(CellStyle).Text($"1");

                                table.Cell().ShowEntire().Element(MainContentlStyle).Element(CellStyle).Text($"1000");
                                table.Cell().ShowEntire().Element(MainContentlStyle).Element(CellStyle).Text($"2000");
                                table.Cell().ShowEntire().Element(MainContentlStyle).Element(CellStyle).Text($"3000");
                                table.Cell().ShowEntire().Element(MainContentlStyle).Element(CellStyle).Text($"5000");
                         //   }

                            column.Item().AlignLeft().PaddingBottom(7, Unit.Millimetre)
                             .Width(195.5f, Unit.Millimetre)
                             .LineHorizontal(.5f, Unit.Millimetre)
                             .LineColor(Colors.Grey.Lighten1);                                  //table footer line

                            column.Item().AlignLeft()                                           //total table blue line
                           .Width(158, Unit.Millimetre)
                           .LineHorizontal(.5f, Unit.Millimetre)
                           .LineColor(Colors.Blue.Darken1);


                            column.Item().AlignLeft().Width(160, Unit.Millimetre)
                           .Padding(5)
                           .Table(table =>
                           {
                               // Define columns
                               table.ColumnsDefinition(columns =>
                               {
                                   columns.RelativeColumn();
                                   columns.RelativeColumn();
                                   columns.RelativeColumn();
                                   columns.RelativeColumn();
                               });

                               table.Header(header =>
                               {
                                   // Table Header Cells
                                   header.Cell().ShowEntire().BorderBottom(1).BorderColor(Colors.Black).Element(CellStyle).Text("الرصيد الافتتاحي").SemiBold();
                                   header.Cell().ShowEntire().BorderBottom(1).BorderColor(Colors.Black).Element(CellStyle).Text("إجمالي الرصيد المدفوع").SemiBold();
                                   header.Cell().ShowEntire().BorderBottom(1).BorderColor(Colors.Black).Element(CellStyle).Text("إجمالي الرصيد المستحق").SemiBold();
                                   header.Cell().ShowEntire().BorderBottom(1).BorderColor(Colors.Black).Element(CellStyle).Text("إجمالي الأرصدة").SemiBold();
                               });

                               // Add table content (no borders here)
                               table.Cell().PaddingTop(5).ShowEntire().Element(CellStyle).Text(e =>
                               {
                                   e.Span($"1000").SemiBold();
                                   e.Span(" ");
                                   e.Span("ر.س").SemiBold(); ;
                               });
                               table.Cell().PaddingTop(5).ShowEntire().Element(CellStyle).Text(e =>
                               {
                                   e.Span($"2000").SemiBold(); 
                                   e.Span(" ");
                                   e.Span("ر.س").SemiBold(); ;
                               });

                               table.Cell().PaddingTop(5).ShowEntire().Element(CellStyle).Text(e =>
                               {
                                   e.Span($"3000").SemiBold(); 
                                   e.Span(" ");
                                   e.Span("ر.س").SemiBold(); ;
                               });


                               table.Cell().PaddingTop(5).ShowEntire().Element(CellStyle).Text(e =>
                               {
                                   e.Span($"5000").SemiBold(); 
                                   e.Span(" ");
                                   e.Span("ر.س").SemiBold(); ;
                               });
                           });


                            // Style for header cells
                            IContainer CellStyle(IContainer container)
                            {
                                return container.Padding(5)
                                    .AlignCenter();
                            }

                            // Main Table Header
                            IContainer MainHeaderlStyle(IContainer container)
                            {
                                return container
                                .Background(Color.FromRGB(245, 245, 245))
                                .BorderColor(Colors.Grey.Lighten1)
                                .BorderTop(1)
                                .BorderBottom(1);
                            }
                            // Main Table Content Header
                            IContainer MainContentlStyle(IContainer container)
                            {
                                return container
                                .BorderLeft(1).BorderColor(Colors.Grey.Lighten1);
                            }
                        });
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
