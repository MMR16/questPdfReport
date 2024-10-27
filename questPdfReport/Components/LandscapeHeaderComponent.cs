using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using Unit = QuestPDF.Infrastructure.Unit;

namespace Kosoor.Reports.Components
{
    public class LandscapeHeaderComponent : IComponent
    {

        private readonly DateTime? _reportDate;

        public LandscapeHeaderComponent(DateTime? reportDate)
        {
            _reportDate = reportDate ?? DateTime.UtcNow.AddHours(3);
        }

        public void Compose(IContainer container)
        {

            container.ContentFromRightToLeft().Column(column =>
            {
                //column.Item().Row(row =>
                //{
                //    row.AutoItem().Column(column =>
                //    {
                //        column.Item()
                //        .Height(20, Unit.Millimetre)
                //        .Width(279, Unit.Millimetre)
                //        .Svg(HeaderImage);
                //    });
                //});
                column.Item().ContentFromLeftToRight().Element(ComposeHeader);
                column.Item().ContentFromRightToLeft().Row(row =>
                {

                    row.ConstantItem(50).Image("Resources/Images/logo.png"); // Placeholder for company logo

                    row.RelativeItem().Column(innerColumn =>
                    {
                        innerColumn.Item().PaddingBottom(3, Unit.Millimetre).PaddingRight(3, Unit.Millimetre).AlignRight()
                            .Text(e =>
                            {
                                e.Span("_companyInfoDto.CompanyName").FontSize(13).SemiBold();
                                e.Span("  ");
                                e.Span("_companyInfoDto.Branch").FontSize(9);
                            });
                        innerColumn.Item().PaddingBottom(3, Unit.Millimetre).PaddingRight(3, Unit.Millimetre).AlignRight().Text("الرقم الضريبي: {_companyInfoDto.TaxNumber}").FontSize(10);
                        innerColumn.Item().PaddingBottom(3, Unit.Millimetre).PaddingRight(3, Unit.Millimetre).AlignRight().Text(e =>
                        {
                            e.Span("_companyInfoDto.AdditionallNumber").FontSize(10); ;
                            e.Span(" : ").FontSize(10); ;
                            e.Span("_companyInfoDto.AdditionallNumberValue").FontSize(10); ;
                        });
                    });


                    row.RelativeItem().AlignCenter().Column(innerColumn =>
                    {
                        innerColumn.Item().PaddingBottom(3, Unit.Millimetre).PaddingRight(3, Unit.Millimetre).AlignRight()
                            .Text(e =>
                            {
                                e.Span("تاريخ اصدار التقرير").SemiBold();
                                e.Span(" / ");
                                e.Span("_reportDate!.Value.ConvertDateTimetoArabic().Date").FontSize(9);
                                e.Span(" | ").FontSize(9);
                                e.Span("_reportDate!.Value.ConvertDateTimetoArabic().ArabicTime").FontSize(9);
                            });
                    });

                });

                column.Item().PaddingVertical(6);
            });
        }



        private void ComposeHeader(IContainer container)
        {
           // var rightHeader = SvgImage.FromFile("Resources/Images/rightHeader.svg");
            var rightHeader ="Resources/Images/rightHeader.png";
            var leftHeader = "Resources/Images/LeftHeader.png";

            container.Row(row =>
            {
              //  row.Spacing(1);

                // First SVG with 1 part of the total width (leftHeader)
                row.RelativeItem(.5f).Column(column =>
                {
                    column.Item()
                    .Height(32)
                    .Width(60)
                     .Image(leftHeader);
                });

                // Text with 2 parts of the total width
                row.RelativeItem(1).Column(column =>
                {
                    column.Item()
                        .AlignLeft()
                        .AlignMiddle()
                        .Text("فاتورة ضريبية مبسطة")
                        .ExtraBold()
                        .FontSize(13)
                        .AlignCenter();
                });

                // Second SVG with 5 parts of the total width (rightHeader)
                row.RelativeItem(5).Column(column =>
                {
                    column.Item()
                    .Image(rightHeader);
                   
                        // .Width(570, Unit.Point)
                       
                });
            });
        }





        //private void ComposeHeader(IContainer container)
        //{
        //    var rightHeader = SvgImage.FromFile("Resources/Images/rightHeader.svg");

        //    var lefrHeader = SvgImage.FromFile("Resources/Images/LeftHeader.svg"); // var HeaderImage = SvgImage.FromFile("Resources/Images/AccountingReport/TransactionsHeeader.svg");

        //    container.Row(row =>
        //    {
        //        row.Spacing(1);

        //        row.RelativeItem(1).Column(column =>
        //        {
        //            column
        //            .Item()
        //            .Height(10)
        //            .Svg(lefrHeader);
        //        });

        //        row.RelativeItem(2).Column(column =>
        //        {
        //            column
        //                .Item().AlignMiddle().Text("فاتورة ضريبية مبسطة")
        //                .FontSize(10).Medium();
        //        });
        //        row.RelativeItem(10).Column(column =>
        //        {
        //            column.Item()
        //            .AspectRatio(100, AspectRatioOption.FitWidth)
        //            .MaxHeight(10)

        //            .Svg(rightHeader);
        //        });
        //    });
        //}
    }
}
