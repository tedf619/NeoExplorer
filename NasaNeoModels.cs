using System.Text.Json.Serialization;

namespace NeoExplorer;

/// <summary>
/// Represents the root response object for the /neo/rest/v1/feed endpoint.
/// </summary>
public class NeoFeedResponse
{
  [JsonPropertyName("links")]
  public PaginationLinks Links { get; set; } = new();

  [JsonPropertyName("element_count")]
  public int ElementCount { get; set; }

  /// <summary>
  /// Keyed by date string (e.g., "2026-06-01"), containing a list of Near Earth Objects for that day.
  /// </summary>
  [JsonPropertyName("near_earth_objects")]
  public Dictionary<string, List<NearEarthObject>> NearEarthObjects { get; set; } = new();
}

public class PaginationLinks
{
  [JsonPropertyName("next")]
  public string Next { get; set; } = string.Empty;

  [JsonPropertyName("previous")]
  public string Previous { get; set; } = string.Empty;

  [JsonPropertyName("self")]
  public string Self { get; set; } = string.Empty;
}

/// <summary>
/// Represents an individual Near Earth Object (Asteroid).
/// </summary>
public class NearEarthObject
{
  [JsonPropertyName("links")]
  public ObjectLinks Links { get; set; } = new();

  [JsonPropertyName("id")]
  public string Id { get; set; } = string.Empty;

  [JsonPropertyName("neo_reference_id")]
  public string NeoReferenceId { get; set; } = string.Empty;

  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

  [JsonPropertyName("nasa_jpl_url")]
  public string NasaJplUrl { get; set; } = string.Empty;

  [JsonPropertyName("absolute_magnitude_h")]
  public double AbsoluteMagnitudeH { get; set; }

  [JsonPropertyName("estimated_diameter")]
  public EstimatedDiameter EstimatedDiameter { get; set; } = new();

  [JsonPropertyName("is_potentially_hazardous_asteroid")]
  public bool IsPotentiallyHazardousAsteroid { get; set; }

  [JsonPropertyName("close_approach_data")]
  public List<CloseApproachData> CloseApproachData { get; set; } = new();

  [JsonPropertyName("is_sentry_object")]
  public bool IsSentryObject { get; set; }
}

public class ObjectLinks
{
  [JsonPropertyName("self")]
  public string Self { get; set; } = string.Empty;
}

public class EstimatedDiameter
{
  [JsonPropertyName("kilometers")]
  public DiameterUnit Kilometers { get; set; } = new();

  [JsonPropertyName("meters")]
  public DiameterUnit Meters { get; set; } = new();

  [JsonPropertyName("miles")]
  public DiameterUnit Miles { get; set; } = new();

  [JsonPropertyName("feet")]
  public DiameterUnit Feet { get; set; } = new();
}

public class DiameterUnit
{
  [JsonPropertyName("estimated_diameter_min")]
  public double EstimatedDiameterMin { get; set; }

  [JsonPropertyName("estimated_diameter_max")]
  public double EstimatedDiameterMax { get; set; }
}

public class CloseApproachData
{
  [JsonPropertyName("close_approach_date")]
  public string CloseApproachDate { get; set; } = string.Empty;

  [JsonPropertyName("close_approach_date_full")]
  public string CloseApproachDateFull { get; set; } = string.Empty;

  [JsonPropertyName("epoch_date_close_approach")]
  public long EpochDateCloseApproach { get; set; }

  [JsonPropertyName("relative_velocity")]
  public RelativeVelocity RelativeVelocity { get; set; } = new();

  [JsonPropertyName("miss_distance")]
  public MissDistance MissDistance { get; set; } = new();

  [JsonPropertyName("orbiting_body")]
  public string OrbitingBody { get; set; } = string.Empty;
}

public class RelativeVelocity
{
  [JsonPropertyName("kilometers_per_second")]
  public string KilometersPerSecond { get; set; } = string.Empty;

  [JsonPropertyName("kilometers_per_hour")]
  public string KilometersPerHour { get; set; } = string.Empty;

  [JsonPropertyName("miles_per_hour")]
  public string MilesPerHour { get; set; } = string.Empty;
}

public class MissDistance
{
  [JsonPropertyName("astronomical")]
  public string Astronomical { get; set; } = string.Empty;

  [JsonPropertyName("lunar")]
  public string Lunar { get; set; } = string.Empty;

  [JsonPropertyName("kilometers")]
  public string Kilometers { get; set; } = string.Empty;

  [JsonPropertyName("miles")]
  public string Miles { get; set; } = string.Empty;
}
