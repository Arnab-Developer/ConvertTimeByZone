using System.Collections.ObjectModel;

namespace ConvertTimeByZone.Core;

public class ConvertTime : IConvertTime
{
    IEnumerable<Zone> IConvertTime.GetAllTimeZones() =>
        TimeZoneInfo.GetSystemTimeZones().Select(timeZone => new Zone(timeZone.Id, timeZone.DisplayName));

    DateTime IConvertTime.GetConvertedDateTime(DateTime dateTimeToBeConverted, TimeZoneInfo sourceTimeZone,
        TimeZoneInfo destinationTimeZone)
    {
        throw new NotImplementedException();
    }
}
