using System;
using MongoDataLibrary.Models;

namespace MongoDataLibrary.Services;

/// <summary>
/// Interface used to abstract data access. Implementation of this interface will be registered for dependency injection.
/// </summary>
public interface IMongoDataService
{
    public List<Planet> GetPlanets();
}

