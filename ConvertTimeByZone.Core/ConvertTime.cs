namespace ConvertTimeByZone.Core;

public class ConvertTime : IConvertTime
{
    IEnumerable<Zone> IConvertTime.GetAllTimeZones() =>
        TimeZoneInfo
            .GetSystemTimeZones()
            .Select(timeZone => new Zone(timeZone.Id, timeZone.DisplayName));

    DateTime IConvertTime.GetConvertedDateTime(
        DateTime dateTimeToBeConverted,
        string sourceTimeZoneId,
        string destinationTimeZoneId)
    {
        TimeZoneInfo sourceTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sourceTimeZoneId);
        TimeZoneInfo destinationTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZoneId);

        DateTime convertedDateTime = TimeZoneInfo.ConvertTime(
            dateTimeToBeConverted,
            sourceTimeZoneInfo,
            destinationTimeZoneInfo);

        return convertedDateTime;
    }
}
