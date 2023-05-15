using AntBlazorPro.Services;
using AntDesign.ProLayout;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;

namespace PhotinoBlazor
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

            appBuilder.Services
                .AddLogging()
                .AddAntDesign();

            appBuilder.Services.AddScoped<IChartService, ChartService>();
            appBuilder.Services.AddScoped<IProjectService, ProjectService>();
            appBuilder.Services.AddScoped<IUserService, UserService>();
            appBuilder.Services.AddScoped<IAccountService, AccountService>();
            appBuilder.Services.AddScoped<IProfileService, ProfileService>();

            // register root component and selector
            appBuilder.RootComponents.Add<App>("app");

            var app = appBuilder.Build();

            // customize window
            app.MainWindow
                //需要有favicon.ico
                //.SetIconFile("favicon.ico")
                .SetTitle("Photino Blazor Sample");

            AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            {
                app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
            };

            app.Run();

        }
    }
}