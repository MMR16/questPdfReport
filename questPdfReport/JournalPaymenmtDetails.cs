using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Quest = QuestPDF.Infrastructure;



namespace QuestPDFTest
{
    public class JournalPaymenmtDetails : IDocument
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
                column.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).PaddingBottom(0.6f, Quest.Unit.Inch).Row(row =>
                {
                    row.RelativeItem().Column(innerColumn =>
                    {
                        innerColumn.Item().PaddingBottom(3).MaxWidth(3, Quest.Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().Text("رقم السند").AlignCenter();
                        });
                        innerColumn.Item().PaddingBottom(4).MaxWidth(3, Quest.Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().Border(1f, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten2).Text("24").AlignCenter();
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
                column.Item().Row(e => e.RelativeItem().PaddingBottom(1, Quest.Unit.Inch));
                column.Item().PaddingVertical(6);
            });
        }

        void ComposeContent(IContainer container)
        {
            var backgroundColor = Colors.Grey.Lighten5;
            container.ContentFromRightToLeft().PaddingLeft(1,Quest.Unit.Centimetre).PaddingRight(.4f, Quest.Unit.Centimetre).PaddingVertical(10).Column(column =>
            {
                column.Item().Row(row =>
                {
                    row.RelativeItem(1).ScaleToFit().Column(column =>
                    {
                        column.Item().Padding(.5f, Quest.Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().PaddingRight(5, Quest.Unit.Millimetre).AlignRight().Text(" صرفنا الى").Bold().Justify();
                        });
                    });

                    row.RelativeItem(4).Background(backgroundColor).Border(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Column(column =>
                    {
                        column.Item().Padding(.5f, Quest.Unit.Centimetre).Text("Lorem Ipsum is simplym passage.");
                    });
                });

                column.Item().Padding(10); //seperate x


                column.Item().Row(row =>
                {
                    row.RelativeItem(1).ScaleToFit().Column(column =>
                    {
                        column.Item().Padding(.5f, Quest.Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().PaddingRight(5, Quest.Unit.Millimetre).AlignRight().Text(" مبلغ وقدره").Bold().Justify();
                        });
                    });

                    row.RelativeItem(1).Border(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Column(column =>
                    {
                        column.Item().Background(backgroundColor).Padding(.5f, Quest.Unit.Centimetre).Text(e =>
                        {
                            e.Span("1000.00").SemiBold().LetterSpacing(.1f);
                            e.Span(" ");
                            e.Span("ر.س");
                        });
                    });

                    row.RelativeItem(.2f);

                    row.RelativeItem(3).Background(backgroundColor).Border(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Column(column =>
                    {
                        column.Item().Padding(.5f, Quest.Unit.Centimetre).Text(e =>
                        {
                            e.Span("خمسمائة ريال سعودي").Bold().WordSpacing(.2f);
                            e.Span("        ");
                            e.Span("فقط").WordSpacing(7);
                        });
                    });
                });

                column.Item().Padding(10); //seperate x


                column.Item().Row(row =>
                {
                    row.RelativeItem(1).ScaleToFit().Column(column =>
                    {
                        column.Item().Padding(.5f, Quest.Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().PaddingRight(5, Quest.Unit.Millimetre).AlignRight().Text(" بتاريخ").Bold().Justify();
                        });
                    });

                    row.RelativeItem(2f).Border(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Column(column =>
                    {
                        column.Item().Background(backgroundColor).Padding(.5f, Quest.Unit.Centimetre).Text("2022 / 9 / 20 ");
                    });

                    row.RelativeItem(.2f);  //space 
                    row.RelativeItem(1f).ScaleToFit().Column(column =>
                    {
                        column.Item().Padding(.5f, Quest.Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().PaddingRight(5, Quest.Unit.Millimetre).AlignRight().Text(" عن طريق").Bold();
                        });
                    });
                    row.RelativeItem(1).Background(backgroundColor).Border(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Column(column =>
                    {
                        column.Item().Padding(.5f, Quest.Unit.Centimetre).Text(" البنك ").AlignCenter();
                    });
                });

                column.Item().Padding(10); //seperate x


                column.Item().Row(row =>
                {
                    row.RelativeItem(1).ScaleToFit().Column(column =>
                    {
                        column.Item().Padding(.5f, Quest.Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().PaddingRight(5, Quest.Unit.Millimetre).AlignRight().Text(" ذلك مقابل").Bold().Justify();
                        });
                    });

                    row.RelativeItem(4).Border(1, Quest.Unit.Point).BorderColor(Colors.Grey.Lighten1).Column(column =>
                    {
                        column.Item().Background(backgroundColor).Padding(.5f, Quest.Unit.Centimetre).Text("What is Lorem Ipsum?\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an k. It has survived not only five centuries");
                    });
                });

                column.Item().Padding(30); //seperate x

                column.Item().Row(row =>
                {
                    row.RelativeItem(1).Column(column =>
                    {
                        column.Item().Padding(.5f, Quest.Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().PaddingRight(5, Quest.Unit.Millimetre).AlignCenter().Text(" المستلم ").Bold().Justify();
                        });
                    });
                    row.RelativeItem(1.5f);

                    row.RelativeItem(1).ScaleToFit().Column(column =>
                    {
                        column.Item().Padding(.5f, Quest.Unit.Centimetre).Row(innerRow =>
                        {
                            innerRow.RelativeItem().PaddingRight(5, Quest.Unit.Millimetre).AlignCenter().Text(e =>
                            {
                                e.Span(" أمين الصندوق").Bold();
                                e.EmptyLine();
                                e.EmptyLine();
                                e.Span(" مصطفى محمود");

                            });
                        });
                    });
                    row.RelativeItem(.5f);
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
