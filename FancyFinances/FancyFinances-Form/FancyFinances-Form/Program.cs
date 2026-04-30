using FancyFinances_Form;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic.Logging;

namespace FancyFinances_Form
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            // Load json file
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Register DbContext with connection string from configuration
            builder.Services.AddDbContextFactory<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Register forms
            builder.Services.AddScoped<frmLogin>();
            builder.Services.AddScoped<frmFinance>();
            builder.Services.AddScoped<frmSavings>();
            builder.Services.AddScoped<frmCreateAcc>();

            ApplicationConfiguration.Initialize();
            //frmLogin is the first form to be shown
            Application.Run(builder.Build().Services.GetRequiredService<frmLogin>());

        }
    }
}