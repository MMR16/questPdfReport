using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestPDFTest
{
    public class TransactionsDocument : IDocument
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
                //    page.Footer().Element(ComposeFooter);
            });
        }

        public void ComposeHeader(IContainer container)
        {
            var HeaderImage = SvgImage.FromFile("Resources/Images/PaymentMethodHeader.svg");

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
                        innerColumn.Item().Text("جدة حي بغداد");
                        innerColumn.Item().Text("شارع ابن تيمية - عمارة 1");
                        innerColumn.Item().Text("");
                        innerColumn.Item().AlignCenter().Text("0115036923");
                        innerColumn.Item().AlignCenter().Text("0553694400256");
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

                column.Item().PaddingVertical(6); //.BorderBottom(1).BorderColor(Colors.Red.Lighten1);
            });
        }


        public void ComposeContent(IContainer container)
        {
            container.ContentFromRightToLeft()
                .Column(column =>
                {
                    column.Item().PaddingBottom(2, Unit.Millimetre).Table(table =>
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
                            header.Cell().Border(1).Padding(5).AlignCenter().Text("رقم الحركة").Bold().DirectionFromRightToLeft();
                            header.Cell().Border(1).Padding(5).AlignCenter().Text("نوع الحركة").Bold().DirectionFromRightToLeft();
                            header.Cell().Border(1).Padding(5).AlignCenter().Text(" اصدرت بواسطة").Bold().DirectionFromRightToLeft();
                            header.Cell().Border(1).Padding(5).AlignCenter().Text("الفرع").Bold().DirectionFromRightToLeft();
                            header.Cell().Border(1).Padding(5).AlignCenter().Text("التاريخ والوقت").Bold().DirectionFromRightToLeft();
                            header.Cell().Border(1).Padding(5).AlignCenter().Text("المبلغ").Bold().DirectionFromRightToLeft();
                            header.Cell().Border(1).Padding(5).AlignCenter().Text("الضريبة").Bold().DirectionFromRightToLeft();
                            header.Cell().Border(1).Padding(5).AlignCenter().Text("الخصم").Bold().DirectionFromRightToLeft();
                            header.Cell().Border(1).Padding(5).AlignCenter().Text("الاجمالي").Bold().DirectionFromRightToLeft();
                        });

                        for (int i = 1; i <= 20; i++)
                        {
                            table.Cell().Border(1).Padding(5).AlignCenter().Text(i.ToString()).DirectionFromRightToLeft();
                            table.Cell().Border(1).Padding(5).AlignCenter().Text("مبيعات").DirectionFromRightToLeft();
                            table.Cell().Border(1).Padding(5).AlignCenter().Text("مصطفى").DirectionFromRightToLeft();
                            table.Cell().Border(1).Padding(5).AlignCenter().Text(i % 2 == 0 ? "جدة" : "الرياض").DirectionFromRightToLeft();
                            table.Cell().Border(1).Padding(5).AlignCenter().Text("16/2/2023  8:11 صباحاً").DirectionFromRightToLeft();
                            table.Cell().Border(1).Padding(5).AlignCenter().Text("3,700.00").DirectionFromRightToLeft();
                            table.Cell().Border(1).Padding(5).AlignCenter().Text("00.00").DirectionFromRightToLeft();
                            table.Cell().Border(1).Padding(5).AlignCenter().Text("00.00").DirectionFromRightToLeft();
                            table.Cell().Border(1).Padding(5).AlignCenter().Text("3,700.00").DirectionFromRightToLeft();
                        }
                    });






                    //column.Item().AlignLeft().Width(130,Unit.Millimetre).PaddingBottom(20, Unit.Millimetre)
                    //.Table(table =>
                    //{
                    //    // Column definitions
                    //    table.ColumnsDefinition(columns =>
                    //    {
                    //        columns.RelativeColumn();
                    //        columns.RelativeColumn();
                    //        columns.RelativeColumn();
                    //        columns.RelativeColumn();
                    //    });

                    //    // Table header (no borders)
                    //    table.Header(header =>
                    //    {
                    //        header.Cell().Element(CellBlueColorStyle).Text("اجمالي المبلغ");
                    //        header.Cell().Element(CellBlueColorStyle).Text("اجمالي الضريبة");
                    //        header.Cell().Element(CellBlueColorStyle).Text("اجمالي الخصم");
                    //        header.Cell().Element(CellBlueColorStyle).Text("الاجمالي الكلي");
                    //    });

                    //    // Table content (no borders)
                    //    table.Cell().PaddingLeft(2).BorderLeft(1, Unit.Point).BorderColor(Colors.Grey.Lighten1).Text("100.00").AlignCenter();
                    //    table.Cell().Element(CellStyle).Text("Row 1, Column 1");
                    //    table.Cell().Element(CellStyle).Text("Row 1, Column 2");
                    //    table.Cell().Element(CellStyle).Text("Row 1, Column 2");
                    //    table.Cell().Element(CellStyle).Text("Row 1, Column 2");
                    //});


                    //IContainer CellStyleTopBottom(IContainer container)
                    //{
                    //    return container.Padding(5)
                    //        .BorderTop(1) // Only top border
                    //        .BorderBottom(1) // Only bottom border
                    //        .BorderLeft(0) // No left border
                    //        .BorderRight(0); // No right border
                    //}



                    column.Item().AlignLeft().Width(130, Unit.Millimetre).PaddingBottom(20, Unit.Millimetre).BorderTop(1)   // Only top border
                   .BorderBottom(0) // Only bottom border
                   .BorderLeft(0)   // No left border
                   .BorderRight(0)  // No right border
                   .Padding(5)   // Optional padding around the table
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

              // Add table content (no borders here)
              table.Cell().Element(ContentCellStyle).Text("1,150.00 ر.س");
              table.Cell().Element(ContentCellStyle).Text("1,150.00 ر.س");
              table.Cell().Element(ContentCellStyle).Text("1,150.00 ر.س");
              table.Cell().Element(ContentCellStyle).Text("1,150.00 ر.س");
          });

    // Create a custom header with borders around the whole header row
    void ComposeHeaderWithBorders(IContainer container)
    {
                container.BorderTop(2).BorderBottom(2)  // Borders on top and bottom
                    .BorderColor(Colors.Black)
                    .Padding(5)  // Optional padding around the table header
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        // Table Header Cells
                        table.Cell().Element(CellStyle).Text("الإجمالي الكلي");
                        table.Cell().Element(CellStyle).Text("إجمالي الخصم");
                        table.Cell().Element(CellStyle).Text("إجمالي الضريبة");
                        table.Cell().Element(CellStyle).Text("إجمالي المبلغ");
                    });
            }

            // Style for header cells
            IContainer CellStyle(IContainer container)
            {
                return container.Padding(5)
                    .AlignCenter(); // Center the text
            }

            // Content cell style without any borders
            IContainer ContentCellStyle(IContainer container)
            {
                return container.Padding(5)
                    .Border(0)  // No borders for content cells
                    .AlignCenter(); // Center the text
            }




        });

        }

        public void ComposeFooter(IContainer container)
        {
            container.ContentFromRightToLeft()
                    .AlignRight()
                    .Text("إجمالي المبلغ: 1,150.00 رس")
                    .Bold()
                    .FontSize(12)
                    .FontColor(Colors.Black)
                    .DirectionFromRightToLeft();
        }
    }
}


