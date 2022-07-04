using Casting;

namespace Services
{
    public interface IServiceFactory
    {
        IAudioService GetAudioService();
        IKeyboardService GetKeyboardService();
        IMouseService GetMouseService();
        ISettingsService GetSettingsService();
        IVideoService GetVideoService();
    }
}