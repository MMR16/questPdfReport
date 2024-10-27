using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace Kosoor.Reports.Components
{
    public class LandscapeFooterComponent : IComponent
    {
        public void Compose(IContainer container)
        {
            container.AlignCenter().Text(text =>
            {
                text.DefaultTextStyle(x => x.FontSize(9));
                text.CurrentPageNumber();
                text.Span(" / ");
                text.TotalPages();
            });
        }
    }
}
