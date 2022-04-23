using Xunit;

namespace ConvertTimeByZone.Core.Test;

public class ConvertTimeTest
{
    [Fact]
    public void Can_GetAllTimeZones_ReturnProperData()
    {
        IConvertTime convertTime = new ConvertTime();
        IEnumerable<Zone> zones = convertTime.GetAllTimeZones();

        Assert.NotNull(zones);
        Assert.Equal(141, zones.Count());
    }

    [Fact]
    public void Can_GetConvertedDateTime_ReturnProperData()
    {
        DateTime actualDateTime = new(2022, 04, 5, 10, 15, 0, DateTimeKind.Unspecified);
        DateTime expectedDateTime = new(2022, 04, 6, 1, 15, 0, DateTimeKind.Unspecified);

        string sourceTimeZoneId = "Pacific Standard Time";
        string destinationTimeZoneId = "China Standard Time";

        IConvertTime convertTime = new ConvertTime();

        DateTime convertedDateTime = convertTime.GetConvertedDateTime(
            actualDateTime,
            sourceTimeZoneId,
            destinationTimeZoneId);

        Assert.Equal(expectedDateTime, convertedDateTime);
    }

    [Fact]
    public void Can_GetConvertedDateTime_ThrowException_WithInvalidSourceTimeZoneId()
    {
        DateTime actualDateTime = new(2022, 04, 5, 10, 15, 0, DateTimeKind.Unspecified);
        DateTime expectedDateTime = new(2022, 04, 6, 1, 15, 0, DateTimeKind.Unspecified);

        string sourceTimeZoneId = "";
        string destinationTimeZoneId = "China Standard Time";

        IConvertTime convertTime = new ConvertTime();

        Assert.Throws<TimeZoneNotFoundException>(() =>
        {
            DateTime convertedDateTime = convertTime.GetConvertedDateTime(
                actualDateTime,
                sourceTimeZoneId,
                destinationTimeZoneId);
        });
    }

    [Fact]
    public void Can_GetConvertedDateTime_ThrowException_WithInvalidDestinationTimeZoneId()
    {
        DateTime actualDateTime = new(2022, 04, 5, 10, 15, 0, DateTimeKind.Unspecified);
        DateTime expectedDateTime = new(2022, 04, 6, 1, 15, 0, DateTimeKind.Unspecified);

        string sourceTimeZoneId = "Pacific Standard Time";
        string destinationTimeZoneId = "";

        IConvertTime convertTime = new ConvertTime();

        Assert.Throws<TimeZoneNotFoundException>(() =>
        {
            DateTime convertedDateTime = convertTime.GetConvertedDateTime(
                actualDateTime,
                sourceTimeZoneId,
                destinationTimeZoneId);
        });
    }
}