using HarleyFeedingTracker.Data;
using HarleyFeedingTracker.Services;
using Microsoft.Extensions.Logging;

namespace HarleyFeedingTracker
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
            builder.Services.AddSingleton<IRestService, RestService>();
            builder.Services.AddSingleton<IHarleyServices, HarleyServices>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<FeedingPage>();

            builder.Services.AddSingleton<FeedingDatabase>();

            return builder.Build();
        }
    }
}
