using AvgWords.Core.Services.Interfaces;
using AvgWords.Mapping;
using AvgWords.SDK.Models;
using Microsoft.AspNetCore.Mvc;

namespace IssNow.Api.Controllers
{
    [ApiController]
    [Route("api/artist")]
    public class ArtistController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ArtistController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{artist}")]
        public ActionResult<AvgWordsReport> Get(string artist)
        {
            var report = _reportService.GetAvgWordsReport(artist);
            var reportMapped = AvgWordsReportMapper.DomainToSDK(report);

            return reportMapped;
        }
    }
}
