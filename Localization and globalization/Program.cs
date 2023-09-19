
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace Localizationandglobalization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //بحدد بيها فين مكان الريسورسيس فايل اللي هيكون فيه المرادفات بتاعت الكلمات اللي بستخدمها مثلا كلمه ويلكام بالانجليزي هتكون بتساوي مرحبا بالعربي
            //فلازم اعرف الابكيشن لما اليوزر يستخدم الانجليزي يبقي يستخدم ويلكام لو مستخدم عربي يبقي يستخدم مرحبا 
            // فلازم اعرفه مكان الفولدر اللي هتكون فيه الفايلات اللي هو بيقري منها القيم دي
            builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources"); //  Resources >> the name of folder


            builder.Services.Configure<RequestLocalizationOptions>(opt =>
            {
                var supportedCultures = new[]
                {
                     new CultureInfo("en"),
                     new CultureInfo("ar"),
                     new CultureInfo("de"),
                     new CultureInfo("fr")
                };

                opt.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
                opt.SupportedCultures = supportedCultures;
                opt.SupportedUICultures = supportedCultures;
            }
            );

           


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
            //step 3
            app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}