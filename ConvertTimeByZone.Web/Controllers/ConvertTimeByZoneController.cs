using ConvertTimeByZone.Core;
using ConvertTimeByZone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConvertTimeByZone.Web.Controllers;

public class ConvertTimeByZoneController : Controller
{
    private readonly IConvertTime _convertTime;

    public ConvertTimeByZoneController(IConvertTime convertTime)
    {
        ArgumentNullException.ThrowIfNull(convertTime, nameof(convertTime));

        _convertTime = convertTime;
    }

    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<string> zoneNames = _convertTime.GetAllTimeZones();
        IEnumerable<SelectListItem> selectListItems = zoneNames.Select(zoneName => new SelectListItem(zoneName, zoneName));
        ConvertTimeByZoneModel model = new(selectListItems);
        return View(model);
    }

    [HttpPost]
    public IActionResult Convert(DateTime dateTimeToBeConverted, TimeZoneInfo sourceTimeZone,
        TimeZoneInfo destinationTimeZone)
    {
        return View();
    }
}
