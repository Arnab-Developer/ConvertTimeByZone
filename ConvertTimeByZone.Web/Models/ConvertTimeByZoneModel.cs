using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConvertTimeByZone.Web.Models;

public record ConvertTimeByZoneModel(IEnumerable<SelectListItem> ZoneNames);