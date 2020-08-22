using AvgWords.Domain.Models;

namespace AvgWords.Core.Services.Interfaces
{
    public interface IReportService
    {
        AvgWordsReport GetAvgWordsReport(string artist);
    }
}
