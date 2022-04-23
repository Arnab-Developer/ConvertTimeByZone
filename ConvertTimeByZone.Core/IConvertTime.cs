namespace ConvertTimeByZone.Core;

public interface IConvertTime
{
    public IEnumerable<Zone> GetAllTimeZones();

    public DateTime GetConvertedDateTime(
        DateTime dateTimeToBeConverted,
        string sourceTimeZoneId,
        string destinationTimeZoneId);
}
