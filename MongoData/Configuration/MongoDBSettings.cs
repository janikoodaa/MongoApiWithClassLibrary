using System;
namespace MongoDataLibrary.Configuration;

/// <summary>
/// Object used to get settings for MongoDB connection.
/// Properties are fetched from appsettings.json using MongoDBSection name
/// and then injected to MongoDataService.
/// </summary>
public class MongoDBSettings
{
    public const string MongoDBSection = "MongoDB";

    public string MongoDBUri { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string PlanetCollection { get; set; } = string.Empty;
}

