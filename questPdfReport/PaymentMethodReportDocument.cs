using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using Unit = QuestPDF.Infrastructure.Unit;
using Kosoor.Reports.Components;

namespace QuestPDFTest
{
    public class PaymentMethodReportDocument : IDocument
    {
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(20);
                page.PageColor(Colors.White);

                page.Header().Component(new LandscapeHeaderComponent(DateTime.Now));
                page.Content().Element(ComposeContent);
                page.Footer().Component(new LandscapeFooterComponent());
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
                        });

                        table.Header(header =>
                        {
                            header.Cell().ColumnSpan(8).Background(Color.FromRGB(245, 245, 245)).Element(CellStyle).BorderColor(Colors.Grey.Lighten1).AlignCenter().Text(e =>
                            {
                                e.Span("_model.FilterRange");
                            });

                            header.Cell().Element(MainHeaderlStyle).BorderRight(1).Element(CellStyle).Text("رقم الحركة").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).BorderLeft(0).BorderRight(0).Text("نوع الحركة").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).Text(" اصدرت بواسطة").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).Text("الفرع").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).Text("التاريخ والوقت").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).Text("نقد").Bold();
                            header.Cell().Element(MainHeaderlStyle).Element(CellStyle).Text("شبكة").Bold();
                            header.Cell().Element(MainHeaderlStyle).BorderLeft(1).Element(CellStyle).Text("الاجمالي").Bold();

                            for (int i = 0; i < 4; i++)
                            {
                                table.Cell().Element(MainContentlStyle).BorderRight(1).Background(Color.FromRGB(245, 245, 245)).Element(CellStyle).Text("{item.Number}");

                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("مبيعات");


                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("{item.CreatedBy}");
                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("{item.BranchName}");
                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text(e =>
                                {
                                    e.Span("item.CreatedAt.ConvertDateTimetoArabic().Date");
                                    e.EmptyLine();
                                    e.Span("item.CreatedAt.ConvertDateTimetoArabic().ArabicTime");
                                });

                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("{Math.Round(item.Cash, 3)}");
                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("{Math.Round(item.Credit, 3)}");
                                table.Cell().Element(MainContentlStyle).Element(CellStyle).Text("{Math.Round(item.Total, 3)}");
                            }

                            column.Item().AlignLeft().PaddingBottom(7, Unit.Millimetre)
                             .Width(282.5f, Unit.Millimetre)
                             .LineHorizontal(.5f, Unit.Millimetre)
                             .LineColor(Colors.Grey.Lighten1);

                            column.Item().AlignLeft()
                           .Width(83, Unit.Millimetre)
                           .LineHorizontal(.5f, Unit.Millimetre)
                           .LineColor(Colors.Blue.Darken1);


                            column.Item().AlignLeft().Width(85, Unit.Millimetre)
                           .Padding(5)
                           .Table(table =>
                           {
                               // Define columns
                               table.ColumnsDefinition(columns =>
                               {
                                   columns.RelativeColumn();
                                   columns.RelativeColumn();
                                   columns.RelativeColumn();
                               });

                               table.Header(header =>
                               {
                                   // Table Header Cells
                                   header.Cell().BorderBottom(1).BorderColor(Colors.Black).Element(CellStyle).Text("إجمالي النقد");
                                   header.Cell().BorderBottom(1).BorderColor(Colors.Black).Element(CellStyle).Text("إجمالي البنك");
                                   header.Cell().BorderBottom(1).BorderColor(Colors.Black).Element(CellStyle).Text("الإجمالي الكلي");
                               });

                               // Add table content (no borders here)
                               table.Cell().Element(CellStyle).Text(e =>
                               {
                                   e.Span("{Math.Round(_model.Totals.Cash, 3)} ");
                                   e.Span("ر.س");
                               });
                               table.Cell().Element(CellStyle).Text(e =>
                               {
                                   e.Span("{Math.Round(_model.Totals.Credit, 3)} ");
                                   e.Span("ر.س");
                               });

                               table.Cell().Element(CellStyle).Text(e =>
                               {
                                   e.Span("{Math.Round(_model.Totals.Total, 3)} ");
                                   e.Span("ر.س");
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

    }
}
