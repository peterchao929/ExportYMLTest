using ExportYMLTest.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExportYMLTest.Controllers;

/// <summary>
/// yml檔案匯出測試
/// </summary>
[Route("[controller]/[action]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public sealed class ExportTestController : ControllerBase
{
    private readonly IExportTestService _exportTestService;

    public ExportTestController(IExportTestService exportTestService)
    {
        _exportTestService = exportTestService;
    }

    [HttpGet]
    public void Export()
    {
        _exportTestService.ExportByCamelCase();
        _exportTestService.ExportByPascalCase();
        _exportTestService.ExportByUnderscored();
        _exportTestService.ExportByOriginList();
    }
}
