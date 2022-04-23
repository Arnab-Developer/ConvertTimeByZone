using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ConvertTimeByZone.Web.Models;

public class ConvertTimeByZoneModel
{
    public IEnumerable<SelectListItem>? ZoneListItems { get; init; }

    [Display(Name = "Date time to be converted")]
    [Required]
    public DateTime? DateTimeToBeConverted { get; set; }

    [Display(Name = "Source time zone")]
    [Required]
    public string? SourceTimeZone { get; set; }

    [Display(Name = "Destination time zone")]
    [Required]
    public string? DestinationTimeZone { get; set; }
}