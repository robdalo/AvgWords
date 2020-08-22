using AvgWords.Core.Services.Interfaces;
using AvgWords.Mapping;
using AvgWords.SDK.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {
                var report = _reportService.GetAvgWordsReport(artist);

                if (!string.IsNullOrEmpty(report.ErrorMessage))
                    return new AvgWordsReport { ErrorMessage = report.ErrorMessage };
                
                return AvgWordsReportMapper.DomainToSDK(report);
            }
            catch (Exception)
            {
                return new AvgWordsReport { ErrorMessage = "Error occurred when retrieving artist" };
            }
        }
    }
}
