
using QuestPDF.Drawing;
using QuestPDF.Infrastructure;

namespace QuestPdfAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            ConfigureQuestPDF();

            app.Run();
        }

        private static void ConfigureQuestPDF()
        {
            QuestPDF.Settings.License = LicenseType.Community;

            //FontManager.RegisterFont(File.OpenRead("Resources/Fonts/Cairo.ttf"));
        }
    }
}
