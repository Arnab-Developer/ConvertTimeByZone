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
        ConvertTimeByZoneModel model = GetInitModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Convert(ConvertTimeByZoneModel convertTimeByZoneModel)
    {
        if (!ModelState.IsValid)
        {
            ConvertTimeByZoneModel model = GetInitModel();
            return View(nameof(Index), model);
        }
        if (!convertTimeByZoneModel.DateTimeToBeConverted.HasValue)
        {
            throw new ArgumentNullException(
                "Argument is null",
                nameof(convertTimeByZoneModel.DateTimeToBeConverted));
        }
        if (string.IsNullOrWhiteSpace(convertTimeByZoneModel.SourceTimeZone))
        {
            throw new ArgumentNullException(
                "Argument is null",
                nameof(convertTimeByZoneModel.SourceTimeZone));
        }
        if (string.IsNullOrWhiteSpace(convertTimeByZoneModel.DestinationTimeZone))
        {
            throw new ArgumentNullException(
                "Argument is null",
                nameof(convertTimeByZoneModel.DestinationTimeZone));
        }

        DateTime convertedDateTime = _convertTime.GetConvertedDateTime(
            convertTimeByZoneModel.DateTimeToBeConverted.Value,
            convertTimeByZoneModel.SourceTimeZone,
            convertTimeByZoneModel.DestinationTimeZone);

        ViewData["ConvertedTime"] = convertedDateTime;

        return View();
    }

    private ConvertTimeByZoneModel GetInitModel()
    {
        IEnumerable<Zone> zones = _convertTime.GetAllTimeZones();
        IEnumerable<SelectListItem> zoneListItems = zones.Select(zone => new SelectListItem(zone.Name, zone.Id));
        ConvertTimeByZoneModel model = new() { ZoneListItems = zoneListItems };
        return model;
    }
}
