using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDataLibrary.Models;
using MongoDataLibrary.Configuration;

namespace MongoDataLibrary.Services;

/// <summary>
/// Implements IMongoDataService and exposes methods to operate with MongoDB. Gets MongoDBOptions object through dependency injection and connects to MongoDB.
/// </summary>
public class MongoDataService : IMongoDataService
{
    private readonly IOptions<MongoDBSettings> _settings;

    public MongoDataService(IOptions<MongoDBSettings> settings)
    {
        _settings = settings;
    }

    private IMongoCollection<T> ConnectToMongo<T>(in string collection)
    {
        var client = new MongoClient(_settings.Value.MongoDBUri);
        var db = client.GetDatabase(_settings.Value.DatabaseName);
        return db.GetCollection<T>(collection);
    }

    /// <summary>
    /// Get all planets ordered by orderFromSun property (asc).
    /// </summary>
    /// <returns>List of Planets</returns>
    public List<Planet> GetPlanets()
    {
        var planets = ConnectToMongo<Planet>(_settings.Value.PlanetCollection);
        var result = planets.AsQueryable().OrderBy(p => p.OrderFromSun).ToList();

        return result;
    }
}

