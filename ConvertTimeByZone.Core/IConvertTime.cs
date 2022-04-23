namespace ConvertTimeByZone.Core;

public interface IConvertTime
{
    public IEnumerable<string> GetAllTimeZones();

    public DateTime GetConvertedDateTime(DateTime dateTimeToBeConverted, TimeZoneInfo sourceTimeZone,
        TimeZoneInfo destinationTimeZone);
}
