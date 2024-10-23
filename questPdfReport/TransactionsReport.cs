using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuestPDFTest
{
    public class TransactionsReport : IDocument
    {
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(20);
                page.PageColor(Colors.White);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
            });
        }

        public void ComposeHeader(IContainer container)
        {
            var HeaderImage = SvgImage.FromFile("Resources/Images/AccountingReport/TransactionsHeeader.svg");

            container.ContentFromRightToLeft().Column(column =>
            {
                column.Item().Row(row =>
                {
                    row.AutoItem().Column(column =>
                    {
                        column.Item()
                        .Height(20, Unit.Millimetre)
                        .Width(279, Unit.Millimetre)
                        .Svg(HeaderImage);
                    });
                });

                // Second row in the header
                column.Item().ContentFromRightToLeft().Row(row =>
                {
                    row.ConstantItem(50).Image("Resources/Images/logo.png"); // Placeholder for company logo
                    row.RelativeItem().Column(innerColumn =>
                    {
                        innerColumn.Item().PaddingBottom(3, Unit.Millimetre).PaddingRight(3, Unit.Millimetre).AlignRight()
                            .Text(e =>
                            {
                                e.Span("شركة الشرق الأوسط المتقدم").FontSize(13).SemiBold();
                                e.Span("  ");
                                e.Span("فرع جدة").FontSize(9);
                            });
                        innerColumn.Item().PaddingBottom(3, Unit.Millimetre).PaddingRight(3, Unit.Millimetre).AlignRight().Text("الرقم الضريبي: 310098765678654").FontSize(10);
                        innerColumn.Item().PaddingBottom(3, Unit.Millimetre).PaddingRight(3, Unit.Millimetre).AlignRight().Text("رقم السجل التجاري: 310098765678654").FontSize(10);
                    });

                    row.RelativeItem().AlignCenter().Column(innerColumn =>
                    {
                        innerColumn.Item().Text(e =>
                        {
                            e.Element().Width(3.5f, Unit.Millimetre).Image("Resources/Images/AccountingReport/Location.png").WithCompressionQuality(ImageCompressionQuality.Best);
                            e.Span(" ");
                            e.Span("جدة حي بغداد");
                        });
                        innerColumn.Item().Text("شارع ابن تيمية - عمارة 1");
                        innerColumn.Item().Text("");
                        innerColumn.Item().AlignCenter().ContentFromRightToLeft().Text(e =>
                        {
                            e.Element().Width(3.5f, Unit.Millimetre).Image("Resources/Images/AccountingReport/Telephone.png").WithCompressionQuality(ImageCompressionQuality.Best);
                            e.Span(" ");
                            e.Span("0115036923");

                            e.Span("   ");

                            e.Element().AlignMiddle().Width(3.5f, Unit.Millimetre).Image("Resources/Images/AccountingReport/Phone.png").WithCompressionQuality(ImageCompressionQuality.Best);
                            e.Span(" ");
                            e.Span("0553694400256");
                        });
                    });

                    row.RelativeItem().AlignCenter().Column(innerColumn =>
                    {
                        innerColumn.Item().PaddingBottom(3, Unit.Millimetre).PaddingRight(3, Unit.Millimetre).AlignRight()
                            .Text(e =>
                            {
                                e.Span("تاريخ اصدار التقرير").SemiBold();
                                e.Span(" / ");
                                e.Span($"{DateTime.UtcNow.ToShortDateString()}").FontSize(9);
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
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().ColumnSpan(9).Background(Color.FromRGB(245, 245, 245)).Element(CellStyle).BorderColor(Colors.Grey.Lighten1).AlignCenter().Text(e =>
                            {
                                e.Span("عن فترة ");
                                e.Span("11-2-2024 ");
                                e.Span(" - ");
                                e.Span("11-10-2024 ");
                            });

                            header.Cell().Element(MainHeaderlStyle).BorderRight(1).Element(CellStyle).Text("رقم الحركة").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).BorderLeft(0).BorderRight(0).Text("نوع الحركة").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).Text(" اصدرت بواسطة").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).Text("الفرع").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).Text("التاريخ والوقت").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).Text("المبلغ").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).Text("الضريبة").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).Text("الخصم").Bold();
                            header.Cell().Element(MainHeaderlStyle).BorderLeft(1).Element(CellStyle).Text("الاجمالي").Bold();

                            for (int i = 1; i <= 11; i++)
                            {
                                table.Cell().Element(MainContentlStyle).BorderRight(1).Background(Color.FromRGB(245, 245, 245)).Element(CellStyle).Text(i.ToString());
                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("مبيعات");
                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("مصطفى");
                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text(i % 2 == 0 ? "جدة" : "الرياض");
                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("16/2/2023  8:11 صباحاً");
                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("3,700.00");
                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("00.00");
                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("00.00");
                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("3,700.00");
                            }


                            column.Item().AlignLeft().PaddingBottom(7, Unit.Millimetre)
                             .Width(282.5f, Unit.Millimetre)
                             .LineHorizontal(.5f, Unit.Millimetre)
                             .LineColor(Colors.Grey.Lighten1);

                            column.Item().AlignLeft()
                           .Width(128, Unit.Millimetre)
                           .LineHorizontal(.5f, Unit.Millimetre)
                           .LineColor(Colors.Blue.Darken1);


                            column.Item().AlignLeft().Width(130, Unit.Millimetre)
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
                                      header.Cell().BorderBottom(1).BorderColor(Colors.Black).Element(CellStyle).Text("الإجمالي الكلي");
                                      header.Cell().BorderBottom(1).BorderColor(Colors.Black).Element(CellStyle).Text("إجمالي الخصم");
                                      header.Cell().BorderBottom(1).BorderColor(Colors.Black).Element(CellStyle).Text("إجمالي الضريبة");
                                      header.Cell().BorderBottom(1).BorderColor(Colors.Black).Element(CellStyle).Text("إجمالي المبلغ");
                                  });

                                  // Add table content (no borders here)
                                  table.Cell().Element(CellStyle).Text("1,150.00 ر.س");
                                  table.Cell().Element(CellStyle).Text("1,150.00 ر.س");
                                  table.Cell().Element(CellStyle).Text("1,150.00 ر.س");
                                  table.Cell().Element(CellStyle).Text("1,150.00 ر.س");
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

        public void ComposeFooter(IContainer container)
        {
            container.AlignCenter().Text(text =>
            {
                text.DefaultTextStyle(x => x.FontSize(8));

                text.CurrentPageNumber();
                text.Span(" / ");
                text.TotalPages();
            });
        }
    }
}
