using Microsoft.Extensions.Logging;

namespace MobileApp
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
                    fonts.AddFont("Trebuchet-MS.ttf", "Trebuchet");
                    fonts.AddFont("Trebuchet-MS-Bold.ttf", "TrebuchetBold");
                    fonts.AddFont("Trebuchet-MS-Italic.ttf", "TrebuchetItalic");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
