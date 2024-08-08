using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestPDFTest
{

    public class ReportDocument : IDocument
    {
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
      // public DocumentSettings GetSettings() => new DocumentSettings { Size = PageSizes.A4, Margin = 20 };

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(20);

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().Element(ComposeFooter);
                });
        }

        void ComposeHeader(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Row(row =>
                {
                    row.RelativeItem().Column(column =>
                    {
                        column.Item().Text("سند مصروف").FontSize(20).SemiBold();
                        column.Item().Row(innerRow =>
                        {
                            innerRow.RelativeItem().Text("رقم السند").Bold();
                            innerRow.RelativeItem().Text("24").AlignRight();
                        });
                        column.Item().Row(innerRow =>
                        {
                            innerRow.RelativeItem().Text("تاريخ الاصدار").Bold();
                            innerRow.RelativeItem().Text("20 / 09 / 2022").AlignRight();
                        });
                    });

                    row.RelativeItem().Column(column =>
                    {
                        column.Item().AlignRight().Text("شركة الشرق الأوسط المتقدم").FontSize(16).SemiBold();
                        column.Item().AlignRight().Text("الرقم الضريبي: 310098765678654").FontSize(10);
                        column.Item().AlignRight().Text("العنوان: جدة - حي الحمدانية").FontSize(10);
                    });

                    //row.ConstantItem(50).Image("logo.png"); // Placeholder for company logo
                });

                column.Item().PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten1);
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(10).Column(column =>
            {
                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(3);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Text("المصروف").AlignCenter().Bold();
                        header.Cell().Text("الوصف").AlignCenter().Bold();
                        header.Cell().Text("المبلغ").AlignCenter().Bold();
                        header.Cell().Text("نسبة الضريبة").AlignCenter().Bold();
                        header.Cell().Text("قيمة الضريبة").AlignCenter().Bold();
                    });

                    for (int i = 0; i < 5; i++)
                    {
                        table.Cell().Text("مصاريف الكهرباء").AlignCenter();
                        table.Cell().Text("فاتورة كهرباء شهر أكتوبر لفرع الحمدانية").AlignCenter();
                        table.Cell().Text("100.00 ر.س").AlignCenter();
                        table.Cell().Text("15%").AlignCenter();
                        table.Cell().Text("150.00 ر.س").AlignCenter();
                    }

                    table.Footer(footer =>
                    {
                        footer.Cell().Element(CellStyle).Text("إجمالي مبلغ المصروف");
                        footer.Cell().Element(CellStyle).Text("إجمالي ضريبة القيمة المضافة");
                        footer.Cell().Element(CellStyle).Text("الإجمالي الكلي");
                        footer.Cell().ColumnSpan(2).Element(CellStyle).Text("1,150.00 ر.س").AlignCenter().Bold();
                    });
                });
            });
        }

        void ComposeFooter(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Text("ملاحظة: هذه فاتورة تجريبية لاستخدام QuestPDF").FontSize(10);
                row.ConstantItem(100).Height(50).Placeholder();
            });
        }

        IContainer CellStyle(IContainer container)
        {
            return container.Border(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignCenter().AlignMiddle();
        }
    }
}

