using ConvertTimeByZone.Core;
using ConvertTimeByZone.Web.Controllers;
using ConvertTimeByZone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tynamix.ObjectFiller;
using Xunit;

namespace ConvertTimeByZone.Web.Test.Controllers;

public class ConvertTimeByZoneControllerTest
{
    [Fact]
    public void Can_Index_ReturnProperData()
    {
        Mock<IConvertTime> convertTimeMock = new();
        ConvertTimeByZoneController convertTimeByZoneController = new(convertTimeMock.Object);

        string zoneId1 = Randomizer<string>.Create();
        string zoneName1 = Randomizer<string>.Create();

        string zoneId2 = Randomizer<string>.Create();
        string zoneName2 = Randomizer<string>.Create();

        string zoneId3 = Randomizer<string>.Create();
        string zoneName3 = Randomizer<string>.Create();

        IEnumerable<Zone> zones = new List<Zone>()
        {
            new Zone(zoneId1, zoneName1),
            new Zone(zoneId2, zoneName2),
            new Zone(zoneId3, zoneName3)
        };

        convertTimeMock
            .Setup(s => s.GetAllTimeZones())
            .Returns(zones);

        ViewResult? viewResult = convertTimeByZoneController.Index() as ViewResult;

        Assert.NotNull(viewResult);
        Assert.NotNull(viewResult!.Model);

        ConvertTimeByZoneModel? model = viewResult.Model as ConvertTimeByZoneModel;

        Assert.NotNull(model);
        Assert.NotNull(model!.ZoneListItems);
        Assert.Equal(3, model.ZoneListItems!.Count());

        Assert.Equal(zoneId1, model.ZoneListItems!.ElementAt(0).Value);
        Assert.Equal(zoneName1, model.ZoneListItems!.ElementAt(0).Text);

        Assert.Equal(zoneId2, model.ZoneListItems!.ElementAt(1).Value);
        Assert.Equal(zoneName2, model.ZoneListItems!.ElementAt(1).Text);

        Assert.Equal(zoneId3, model.ZoneListItems!.ElementAt(2).Value);
        Assert.Equal(zoneName3, model.ZoneListItems!.ElementAt(2).Text);

        convertTimeMock
            .Verify(v => v.GetAllTimeZones(),
                Times.Once);

        convertTimeMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void Can_Convert_ReturnProperData()
    {
        Mock<IConvertTime> convertTimeMock = new();
        ConvertTimeByZoneController convertTimeByZoneController = new(convertTimeMock.Object);

        string zoneId1 = Randomizer<string>.Create();
        string zoneName1 = Randomizer<string>.Create();

        string zoneId2 = Randomizer<string>.Create();
        string zoneName2 = Randomizer<string>.Create();

        string zoneId3 = Randomizer<string>.Create();
        string zoneName3 = Randomizer<string>.Create();

        IEnumerable<Zone> zones = new List<Zone>()
        {
            new Zone(zoneId1, zoneName1),
            new Zone(zoneId2, zoneName2),
            new Zone(zoneId3, zoneName3)
        };

        convertTimeMock
            .Setup(s => s.GetAllTimeZones())
            .Returns(zones);

        DateTime sourceDateTime = new(2022, 04, 5, 10, 15, 0);
        DateTime destinationDateTime = sourceDateTime.AddHours(-3);

        convertTimeMock
            .Setup(s => s.GetConvertedDateTime(sourceDateTime, "TimeZone1", "TimeZone2"))
            .Returns(destinationDateTime);

        ConvertTimeByZoneModel convertTimeByZoneModel = new()
        {
            DateTimeToBeConverted = sourceDateTime,
            SourceTimeZone = "TimeZone1",
            DestinationTimeZone = "TimeZone2"
        };

        ViewResult? viewResult = convertTimeByZoneController.Convert(convertTimeByZoneModel) as ViewResult;

        Assert.NotNull(viewResult);
        Assert.Equal(destinationDateTime, viewResult!.ViewData["ConvertedTime"]);

        convertTimeMock
            .Verify(v => v.GetAllTimeZones(),
                Times.Never);

        convertTimeMock
            .Verify(v => v.GetConvertedDateTime(sourceDateTime, "TimeZone1", "TimeZone2"),
                Times.Once);

        convertTimeMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void Can_Convert_ThrowException_WithNullDateTimeToBeConverted()
    {
        Mock<IConvertTime> convertTimeMock = new();
        ConvertTimeByZoneController convertTimeByZoneController = new(convertTimeMock.Object);

        string zoneId1 = Randomizer<string>.Create();
        string zoneName1 = Randomizer<string>.Create();

        string zoneId2 = Randomizer<string>.Create();
        string zoneName2 = Randomizer<string>.Create();

        string zoneId3 = Randomizer<string>.Create();
        string zoneName3 = Randomizer<string>.Create();

        IEnumerable<Zone> zones = new List<Zone>()
        {
            new Zone(zoneId1, zoneName1),
            new Zone(zoneId2, zoneName2),
            new Zone(zoneId3, zoneName3)
        };

        convertTimeMock
            .Setup(s => s.GetAllTimeZones())
            .Returns(zones);

        DateTime sourceDateTime = new(2022, 04, 5, 10, 15, 0);
        DateTime destinationDateTime = sourceDateTime.AddHours(-3);

        convertTimeMock
            .Setup(s => s.GetConvertedDateTime(sourceDateTime, "TimeZone1", "TimeZone2"))
            .Returns(destinationDateTime);

        ConvertTimeByZoneModel convertTimeByZoneModel = new()
        {
            DateTimeToBeConverted = null,
            SourceTimeZone = "TimeZone1",
            DestinationTimeZone = "TimeZone2"
        };

        Assert.Throws<ArgumentNullException>(() =>
            convertTimeByZoneController.Convert(convertTimeByZoneModel));

        convertTimeMock
            .Verify(v => v.GetAllTimeZones(),
                Times.Never);

        convertTimeMock
            .Verify(v => v.GetConvertedDateTime(sourceDateTime, "TimeZone1", "TimeZone2"),
                Times.Never);
    }

    [Fact]
    public void Can_Convert_ThrowException_WithNullSourceTimeZone()
    {
        Mock<IConvertTime> convertTimeMock = new();
        ConvertTimeByZoneController convertTimeByZoneController = new(convertTimeMock.Object);

        string zoneId1 = Randomizer<string>.Create();
        string zoneName1 = Randomizer<string>.Create();

        string zoneId2 = Randomizer<string>.Create();
        string zoneName2 = Randomizer<string>.Create();

        string zoneId3 = Randomizer<string>.Create();
        string zoneName3 = Randomizer<string>.Create();

        IEnumerable<Zone> zones = new List<Zone>()
        {
            new Zone(zoneId1, zoneName1),
            new Zone(zoneId2, zoneName2),
            new Zone(zoneId3, zoneName3)
        };

        convertTimeMock
            .Setup(s => s.GetAllTimeZones())
            .Returns(zones);

        DateTime sourceDateTime = new(2022, 04, 5, 10, 15, 0);
        DateTime destinationDateTime = sourceDateTime.AddHours(-3);

        convertTimeMock
            .Setup(s => s.GetConvertedDateTime(sourceDateTime, "TimeZone1", "TimeZone2"))
            .Returns(destinationDateTime);

        ConvertTimeByZoneModel convertTimeByZoneModel = new()
        {
            DateTimeToBeConverted = sourceDateTime,
            SourceTimeZone = null,
            DestinationTimeZone = "TimeZone2"
        };

        Assert.Throws<ArgumentNullException>(() =>
            convertTimeByZoneController.Convert(convertTimeByZoneModel));

        convertTimeMock
            .Verify(v => v.GetAllTimeZones(),
                Times.Never);

        convertTimeMock
            .Verify(v => v.GetConvertedDateTime(sourceDateTime, "TimeZone1", "TimeZone2"),
                Times.Never);
    }

    [Fact]
    public void Can_Convert_ThrowException_WithNullDestinationTimeZone()
    {
        Mock<IConvertTime> convertTimeMock = new();
        ConvertTimeByZoneController convertTimeByZoneController = new(convertTimeMock.Object);

        string zoneId1 = Randomizer<string>.Create();
        string zoneName1 = Randomizer<string>.Create();

        string zoneId2 = Randomizer<string>.Create();
        string zoneName2 = Randomizer<string>.Create();

        string zoneId3 = Randomizer<string>.Create();
        string zoneName3 = Randomizer<string>.Create();

        IEnumerable<Zone> zones = new List<Zone>()
        {
            new Zone(zoneId1, zoneName1),
            new Zone(zoneId2, zoneName2),
            new Zone(zoneId3, zoneName3)
        };

        convertTimeMock
            .Setup(s => s.GetAllTimeZones())
            .Returns(zones);

        DateTime sourceDateTime = new(2022, 04, 5, 10, 15, 0);
        DateTime destinationDateTime = sourceDateTime.AddHours(-3);

        convertTimeMock
            .Setup(s => s.GetConvertedDateTime(sourceDateTime, "TimeZone1", "TimeZone2"))
            .Returns(destinationDateTime);

        ConvertTimeByZoneModel convertTimeByZoneModel = new()
        {
            DateTimeToBeConverted = sourceDateTime,
            SourceTimeZone = "TimeZone1",
            DestinationTimeZone = null
        };

        Assert.Throws<ArgumentNullException>(() =>
            convertTimeByZoneController.Convert(convertTimeByZoneModel));

        convertTimeMock
            .Verify(v => v.GetAllTimeZones(),
                Times.Never);

        convertTimeMock
            .Verify(v => v.GetConvertedDateTime(sourceDateTime, "TimeZone1", "TimeZone2"),
                Times.Never);
    }
}
