using Lib.Main.Core.Interfaces;
using Lib.Main.Infrastructure.Repositories;
using Lib.Main.Services.Services;
using Microsoft.Extensions.Logging;

namespace UI.Maui.Learn
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IUserRepository, UserJsonRepository>();
            builder.Services.AddSingleton<UserService>();


            return builder.Build();
        }
    }
}
