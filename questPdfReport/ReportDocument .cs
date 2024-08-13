using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;

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
                        column.Item().MaxWidth(3, Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().Text("رقم السند").Bold().AlignCenter();
                        });
                        column.Item().MaxWidth(3, Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().Border(1f, Unit.Point).Text("24").AlignCenter();
                        });
                        column.Item().Row(innerRow =>
                        {
                            innerRow.RelativeItem().Text("تاريخ الاصدار").Bold();
                        });
                        column.Item().Row(innerRow =>
                        {
                            innerRow.RelativeItem().Text("20 / 09 / 2022");
                        });
                    });

                    row.RelativeItem().Column(column =>
                    {
                        column.Item().Text("جدة حي بغداد");
                        column.Item().Text("شارع ابن تيمية - عمارة 1");
                        column.Item().Text("");
                        column.Item().Text("0115036923");
                        column.Item().Text("0553694400256");

                    });

                    row.RelativeItem().Column(column =>
                    {
                        column.Item().AlignRight().Text("شركة الشرق الأوسط المتقدم").FontSize(16).SemiBold();
                        column.Item().AlignRight().Text("الرقم الضريبي: 310098765678654").FontSize(10);
                        column.Item().AlignRight().Text("الفرع / فرع جدة").FontSize(10);
                    });
                    row.ConstantItem(50).Image("Resources/Images/0.jpg"); // Placeholder for company logo
                });

                column.Item().PaddingVertical(6);//.BorderBottom(1).BorderColor(Colors.Red.Lighten1);
            });
        }
        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(10).Column(column =>
            {
                column.Item().Row(row =>
                {
                    row.RelativeItem().Border(1, Unit.Point).BorderColor(Colors.Grey.Lighten1).Column(column =>
                    {
                        column.Item().Row(innerRow =>
                        {
                            innerRow.RelativeItem().MinHeight(1, Unit.Centimetre).AlignRight().Text("مدفوع");
                            innerRow.ConstantItem(3, Unit.Centimetre).AlignRight().Border(1, Unit.Point).Text("حالة الدفع").Bold();
                        });

                        column.Item().Row(innerRow =>
                        {
                            innerRow.RelativeItem().MinHeight(1, Unit.Centimetre).AlignRight().Text("بنك");
                            innerRow.ConstantItem(3, Unit.Centimetre).AlignRight().Border(1, Unit.Point).Text("طريقة الدفع").Bold();
                        });
                        column.Item().Row(innerRow =>
                        {
                            innerRow.RelativeItem().MinHeight(1, Unit.Centimetre).AlignRight().Text("10/20/3025");
                            innerRow.ConstantItem(3, Unit.Centimetre).AlignRight().Border(1, Unit.Point).Text("تاريخ الدفع").Bold();
                        });
                        column.Item().Row(innerRow =>
                        {
                            innerRow.RelativeItem().MinHeight(1, Unit.Centimetre).AlignRight().Text("مورد مبيعات نيو تايم");
                            innerRow.ConstantItem(3, Unit.Centimetre).AlignRight().Border(1, Unit.Point).Text("المستلم").Bold();
                        });
                    });
                    row.ConstantItem(1, Unit.Centimetre); // seperate y

                    row.RelativeItem().Border(1, Unit.Point).BorderColor(Colors.Grey.Lighten1).Column(column =>
                    {
                        column.Item().Row(innerRow =>
                        {
                            innerRow.RelativeItem().MinHeight(1, Unit.Centimetre).AlignRight().Text("مورد مبيعات نيو تايم");
                            innerRow.ConstantItem(3, Unit.Centimetre).AlignRight().Border(1, Unit.Point).Text("المورد").Bold();
                        });

                        column.Item().Row(innerRow =>
                        {
                            innerRow.RelativeItem().MinHeight(1, Unit.Centimetre).AlignRight().Text("5156121");
                            innerRow.ConstantItem(3, Unit.Centimetre).AlignRight().Border(1, Unit.Point).Text("فاتورة رقم").Bold();
                        });
                        column.Item().AlignRight().Text("تيشرتات وملابس وأجهزة ");
                    });
                });

                column.Item().Padding(20); //seperate x


                column.Item().ContentFromRightToLeft().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                        });

                        table.Header(header =>
                        {
                            header.Cell().PaddingBottom(5, Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("المصروف").AlignCenter().Bold();
                            header.Cell().PaddingBottom(5, Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("الوصف").AlignCenter().Bold();
                            header.Cell().PaddingBottom(5, Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("المبلغ").AlignCenter().Bold();
                            header.Cell().PaddingBottom(5, Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("نسبة الضريبة").AlignCenter().Bold();
                            header.Cell().PaddingBottom(5, Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("قيمة الضريبة").AlignCenter().Bold();
                            header.Cell().PaddingBottom(5, Unit.Millimetre).Background(Colors.Grey.Lighten4).Text("الاجمالي").AlignCenter().Bold();
                        });

                        for (int i = 0; i < 12; i++)
                        {
                            table.Cell().BorderLeft(1, Unit.Point).BorderColor(Colors.Grey.Lighten1).PaddingBottom(10, Unit.Millimetre).Text("مصاريف الكهرباء").AlignCenter();
                            table.Cell().BorderLeft(1, Unit.Point).BorderColor(Colors.Grey.Lighten1).Text("فاتورة كهرباء شهر أكتوبر لفرع الحمدانية").AlignCenter();
                            table.Cell().BorderLeft(1, Unit.Point).BorderColor(Colors.Grey.Lighten1).Text("100.00 ر.س").AlignCenter();
                            table.Cell().BorderLeft(1, Unit.Point).BorderColor(Colors.Grey.Lighten1).Text("15%").AlignCenter();
                            table.Cell().BorderLeft(1, Unit.Point).BorderColor(Colors.Grey.Lighten1).Text("150.00 ر.س").AlignCenter();
                            table.Cell().BorderLeft(1, Unit.Point).BorderColor(Colors.Grey.Lighten1).Text("165.00 ر.س").AlignCenter().Bold();
                        }
                        //table.Cell().Padding(1, Unit.Centimetre);
                        //table.Footer(footer =>
                        //{
                        //    footer.Cell().Element(CellStyle).Text("إجمالي مبلغ المصروف");
                        //    footer.Cell().Element(CellStyle).Text("إجمالي ضريبة القيمة المضافة");
                        //    footer.Cell().Element(CellStyle).Text("الإجمالي الكلي");
                        //    footer.Cell().ColumnSpan(2).Element(CellStyle).Text("1,150.00 ر.س").AlignCenter().Bold();
                        //});
                    });

                column.Item().Padding(20); //seperate x





                column.Item().Row(row =>
                {
               
                    row.ConstantItem(1, Unit.Centimetre); // seperate y

                    row.RelativeItem().Border(1, Unit.Point).BorderColor(Colors.Grey.Lighten1).Column(column =>
                    {
                        column.Item().Row(innerRow =>
                        {
                            innerRow.RelativeItem().MinHeight(1, Unit.Centimetre).AlignRight().Text("مورد مبيعات نيو تايم");
                            innerRow.ConstantItem(3, Unit.Centimetre).AlignRight().Border(1, Unit.Point).Text("المورد").Bold();
                        });

                        column.Item().Row(innerRow =>
                        {
                            innerRow.RelativeItem().MinHeight(1, Unit.Centimetre).AlignRight().Text("5156121");
                            innerRow.ConstantItem(3, Unit.Centimetre).AlignRight().Border(1, Unit.Point).Text("فاتورة رقم").Bold();
                        });
                        column.Item().AlignRight().Text("تيشرتات وملابس وأجهزة ");
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

