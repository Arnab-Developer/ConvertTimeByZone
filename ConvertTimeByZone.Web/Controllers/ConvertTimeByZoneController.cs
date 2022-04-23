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
        IEnumerable<Zone> zones = _convertTime.GetAllTimeZones();
        IEnumerable<SelectListItem> zoneListItems = zones.Select(zone => new SelectListItem(zone.Name, zone.Id));
        ConvertTimeByZoneModel model = new(zoneListItems);
        return View(model);
    }

    [HttpPost]
    public IActionResult Convert(DateTime dateTimeToBeConverted, TimeZoneInfo sourceTimeZone,
        TimeZoneInfo destinationTimeZone)
    {
        return View();
    }
}
