using AvgWords.Core.Repos;
using AvgWords.Core.Repos.Interfaces;
using AvgWords.Core.Services;
using AvgWords.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AvgWords.Core.Startup
{
    public class DependencyInjector
    {
        private string _musicBrainzApiBaseUrl;
        private string _lyricsOvhApiBaseUrl;

        public DependencyInjector(string musicBrainzApiBaseUrl, string lyricsOvhApiBaseUrl)
        {
            _musicBrainzApiBaseUrl = musicBrainzApiBaseUrl;
            _lyricsOvhApiBaseUrl = lyricsOvhApiBaseUrl;
        }

        public void Configure(IServiceCollection services)
        {
            var musicBrainzApiConsumer = new Consumers.MusicBrainz.ApiConsumer(_musicBrainzApiBaseUrl);
            var lyricsOvhApiConsumer = new Consumers.LyricsOvh.ApiConsumer(_lyricsOvhApiBaseUrl);

            services.AddSingleton<Consumers.MusicBrainz.Interfaces.IApiConsumer>(musicBrainzApiConsumer);
            services.AddSingleton<Consumers.LyricsOvh.Interfaces.IApiConsumer>(lyricsOvhApiConsumer);

            services.AddSingleton<IArtistRepo, ArtistRepo>();
            services.AddSingleton<ILyricsRepo, LyricsRepo>();
            services.AddSingleton<IReportService, ReportService>();
        }
    }
}
