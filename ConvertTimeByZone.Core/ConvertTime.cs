using System.Collections.ObjectModel;

namespace ConvertTimeByZone.Core;

public class ConvertTime : IConvertTime
{
    IEnumerable<string> IConvertTime.GetAllTimeZones() =>
        TimeZoneInfo.GetSystemTimeZones().Select(timeZone => timeZone.DisplayName);

    DateTime IConvertTime.GetConvertedDateTime(DateTime dateTimeToBeConverted, TimeZoneInfo sourceTimeZone,
        TimeZoneInfo destinationTimeZone)
    {
        throw new NotImplementedException();
    }
}
