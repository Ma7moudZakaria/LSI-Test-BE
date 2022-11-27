using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using Ganss.Excel;
using LSIDomain.Features.CQRS.Commands;
using LSIDomain.Features.CQRS.Queries;
using LSIDomain.Features.DTO.Queries;
using LSIEntities.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoreLinq;

namespace LSITest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]"), Produces(typeof(bool))]
        public async Task<IActionResult> DatabaseEnsureCreated(CancellationToken token)
        {
            return Ok(await _mediator.Send(new DatabaseEnsureCreatedCommand(), token));
        }

        [HttpGet("[action]"), Produces(typeof(ReportDTO))]
        public async Task<IActionResult> GetReports(CancellationToken token)
        {
            return Ok(await _mediator.Send(new GetReportsQuery(), token)); 
        }

        [HttpGet("[action]"), Produces(typeof(FileStreamResult))]
        public async Task<IActionResult> GetFilteredReports([FromHeader] DateTime? dateOfReport, [FromHeader] string? premiseName, CancellationToken token)
        {
            var result = await _mediator.Send(new GetReportsQuery() { PremiseName = premiseName, DateOfReport = dateOfReport }, token);

            ExcelMapper excelMapper = new ExcelMapper();

            excelMapper.Save(Path.Combine(@"D:\Reports.xlsx"), result, "Report", true);

            return Ok();
        }
    }
}