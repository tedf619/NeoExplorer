# NeoExplorer

A .Net 10 WinForms app that shows **NEOs** (Near-Earth Objects, e.g. asteroids) approaching our planet on a given date.

## Features

- Great project for getting started with asteroid and near-earth object exploration.
- Completely self-contained. No NuGet packages or third-party libraries.
- No API key needed for quick use. Get a free API key from NASA for longer use.
- Shows all detected celestial objects approaching the earth on a given day.
- Uses the online NASA NEO API.

The following figure shows NeoExplorer in action.

<img width="742" height="482" alt="image" src="https://github.com/user-attachments/assets/db850ebf-6270-4193-8b8a-74a01e9895c4" />

*Figure 1* - The app showing celestial objects and their properties. 

## The UI Layout

The user interface uses two layers of docked panels for its layout, as shown in the following figure.

<img width="667" height="482" alt="image" src="https://github.com/user-attachments/assets/572816e9-a53e-4b7a-8a11-0ef11156c779" />

*Figure 2* - The main form hosting the NeoExplorer control.

* Layer 1 - Shown in red, this layer divides the screen vertically, with the middle area filling available space.
* Layer 2 - Shown in blue, this layer is just for the NeoExplorer control, which fills the middle area of layer 1.

To achieve the required layout, the panels in layer 1 must be added in the proper back-to-front order, like this:

  1. PanelTop.
  2. PanelBottom.
  3. PanelMiddle.

As a general rule, components with Dock=Fill must always be added last to their parent container.

The NeoExplorer control is a WinForms UserControl that has its own internal layout, as shown in the next figure.

<img width="629" height="356" alt="image" src="https://github.com/user-attachments/assets/7cce4660-8011-41a5-b9bd-c81f861193ec" />

*Figure 3* - The UI of the NeoExplorer control.

As always, the panel with Dock=Fill must be added last, so the panels must be added in this order:

  1. PanelTop.
  2. PanelLeft.
  3. PanelRight.

## How it Works
The main form of the app is just used to setup the layout and handle user interactions with the UI controls. The start and end dates default to covering yesterday and today. The NASA service rejects requests that cover more than seven days. By clicking the **Search for Objects** button the app queries the NASA online service at ```api.nasa.gov/neo``` to get a list of NEOs in the given period.

By default, all the NEOs whose magnitude (brightness) is below the given value are displayed. Note that counterintuitively, brightness increases with lower values in magnitude. 
<br><br>
You can further filter the results by checking the **Potentially Hazardous** and **Sentry Objects** checkboxes. NASA tags asteroids like this:

1. *Potentially Hazardous*. A NEO that comes within 7.5 million kilometers of Earth's orbit and has an absolute magnitude under 22 (making its diameter at least 140 meters).
2. *Sentry Objects*. A NEO tagged in NASA's Sentry, system, an automated collision-monitoring system. Sentry objects are considered to possibly hit the Earth in the next 100 years.

The following figure shows the sequence diagram of the overall system.

<img width="739" height="536" alt="image" src="https://github.com/user-attachments/assets/2688d43f-4752-4410-9928-023af91dc3f5" />

*Figure 4* - The sequence diagram of the app.

The following listing shows the code for FormMain.

```csharp
public partial class FormMain : Form
{
  public FormMain()
  {
    InitializeComponent();

    dateTimePickerStartDate.Value = DateTime.Now.AddDays(-1);
    dateTimePickerEndDate.Value = DateTime.Now;

    // get the NASA api key from the environment, so we don't expose the key in code
    neoExplorer.ApiKey = Environment.GetEnvironmentVariable("NASA_API_KEY") ?? "DEMO_KEY";

    panelMiddle.Visible = false;  // we'll make it visible after a Search is performed

    ShowStatusBarMessage("Perform a Search to see results");
  }

  async void ButtonSearchForObjects_Click(object sender, EventArgs e)
  {
    DateTime startDate = dateTimePickerStartDate.Value;
    DateTime endDate = dateTimePickerEndDate.Value;

    if (endDate.Subtract(startDate).Days >=7)
    {
      MessageBox.Show("The date range must be less than 7 days.", "Invalid Date Range");
      return;
    }

    neoExplorer.FaintestMagnitude = (float)numericUpDownFaintestMagnitude.Value;
    neoExplorer.IsPotentiallyHazardous = checkBoxPotentiallyHazardous.Checked;
    neoExplorer.IsSentry = checkBoxSentryObjects.Checked;

    UseWaitCursor = true;
    ShowStatusBarMessage("Searching...");

    int objectsFound = await neoExplorer.GetNearEarthObjectsAsync(startDate, endDate);
    panelMiddle.Visible = true;
    
    ShowStatusBarMessage($"Objects found: {objectsFound}");
    UseWaitCursor = false;
  }

  void ShowStatusBarMessage(string message)
  {
    labelStatusMessage.Text = message;
  }
}
```
*Listing 1* - The code for the main form, which hosts NeoExplorer.

The interesting stuff is mostly in NeoExplorer, derived from UserControl. It fills most of FormMain's surface. NeoExplorer handles the download and display of the NEO data. The download of data is achieved with code like this:

```csharp
public partial class NeoExplorer : UserControl
{
  readonly HttpClient http;

  public NeoExplorer()
  {
    //...

    http = new HttpClient();
    http.BaseAddress = new Uri("https://api.nasa.gov/");
  }

  public async Task<int> GetNearEarthObjectsAsync(DateTime startDate, DateTime endDate)
  {
    string startDateIso = startDate.ToString("yyyy-MM-dd");
    string endDateIso = endDate.ToString("yyyy-MM-dd");

    string requestUrl = $"neo/rest/v1/feed?start_date={startDateIso}&end_date={endDateIso}&api_key={ApiKey}";

    using var response = await http.GetAsync(requestUrl);
    response.EnsureSuccessStatusCode();

    await using var stream = await response.Content.ReadAsStreamAsync();
    var data = await JsonSerializer.DeserializeAsync<NeoFeedResponse>(stream);  // deserialize into C# objects

    if (data == null || data.ElementCount == 0) return 0;

    return SetObjectsFound(data.NearEarthObjects);
  }
}
```
*Listing 2* - The code related to the retrieval of NEO data.

The NASA API requires an api key with each request. You can use the default key "DEMO_KEY" for limited use. If you exceed NASA's hourly threshold, you'll start seeing HTTP error "429 (Too Many Requests)". To avoid this problem, go to ```api.nasa.gov``` and get a free personal key. You can use this key in two different ways:

1. By saving the key as a Windows Environment variable. This way you don't have to embed the key in your code. This is the approach I took. I used the variable name "NASA_API_KEY".
2. By embedding the key directly in the source code in the FormMain constructor. Replace the line:

```csharp
  neoExplorer.ApiKey = Environment.GetEnvironmentVariable("NASA_API_KEY") ?? "DEMO_KEY";
```
with the line:
```csharp
  neoExplorer.ApiKey = <your-api-key>;
```

## Handling the NEO Response Data
NASA returns the NEO data in JSON format. I could have consumed this data directly, using System.Text.Json methods to extract the various pieces of NEO data. This works okay for simple JSON responses. For more complex data, it is easier to deserialize the JSON into C# objects, often called *Models* or *DTOs* (Data Transfer Objects). I used Google Gemini to generate the Model classes for me. The prompt was:

```Create C# classes I can use to deserialize the JSON code returned by api.nasa.gov/neo/rest/v1/feed```. 

Gemini produced the following code:

```csharp
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

public class PaginationLinks { ... }

public class ObjectLinks { ... }

public class EstimatedDiameter { ... }

public class DiameterUnit { ... }

public class RelativeVelocity { ... }
```
*Listing 3* - The Model classes used to handle the NASA API's response JSON.

In the interest of brevity, I commented out the lower level classes.
<br>

## Displaying the NEO Data
After downloading and deserializing the data into the various classes shown above, it is displayed in the ListView, which ends up looking something like this:

<img width="233" height="307" alt="image" src="https://github.com/user-attachments/assets/6f0a8a1a-60d3-4cbb-8cda-1da5b5669ae5" />

*Figure 5* - The ListView, showing NEOs grouped by date.

The code to populate the grouped ListView is shown in the following listing.

```csharp
public partial class NeoExplorer : UserControl
{
  int SetObjectsFound(Dictionary<string, List<NearEarthObject>> nearEarthObjects)
  {
    listViewObjectsFound.Items.Clear();

    foreach (string date in nearEarthObjects.Keys)
    {
      ListViewGroup groupDate = new ListViewGroup("DateGroup", date);
      listViewObjectsFound.Groups.Add(groupDate);

      // apply filters

      var filteredNeos = nearEarthObjects[date].Where(neo => neo.AbsoluteMagnitudeH < FaintestMagnitude).ToList();

      if (IsPotentiallyHazardous)
        filteredNeos = filteredNeos.Where(neo => neo.IsPotentiallyHazardousAsteroid).ToList();

      if (IsSentry)
        filteredNeos = filteredNeos.Where(neo => neo.IsSentryObject).ToList();

      // add NearEarthObjects to ListView

      foreach (NearEarthObject neo in filteredNeos)
      {
        var lvi = new ListViewItem(neo.Id, groupDate);
        lvi.SubItems.Add(neo.Name);
        lvi.Tag = neo;
        listViewObjectsFound.Items.Add(lvi);
      }
    }

    return listViewObjectsFound.Items.Count;
  }
  ```
*Listing 4* - Populating the ListView with data grouped by date.

Selecting a NEO in the ListView fires a ListViewObjectsFound_ItemSelectionChanged event that handles the display of relevant NEO properties like this:

```csharp
  void ListViewObjectsFound_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
  {
    if (e.Item == null) return;
    ShowDetails(e.Item);
  }

  void ShowDetails(ListViewItem lvi)
  {
    if (lvi.Tag is not NearEarthObject neo) return;

    labelName.Text = neo.Name;
    labelOrbitingBody.Text = neo.CloseApproachData[0].OrbitingBody;
    labelMagnitude.Text = neo.AbsoluteMagnitudeH.ToString("F1");

    float f = float.Parse(neo.CloseApproachData[0].MissDistance.Lunar);
    labelClosestDistance.Text = $"{f:F1} (in Lunar Units)";
    labelClosestDistanceOn.Text = neo.CloseApproachData[0].CloseApproachDateFull;

    var minKm = neo.EstimatedDiameter.Kilometers.EstimatedDiameterMin;
    var maxKm = neo.EstimatedDiameter.Kilometers.EstimatedDiameterMax;
    labelEstimatedSize.Text = $"{minKm:F2} - {maxKm:F2} km";

    f = float.Parse(neo.CloseApproachData[0].RelativeVelocity.KilometersPerSecond);
    labelRelativeVelocity.Text = $"{f:F1} km/sec";

    labelPotentiallyHazardous.Text = neo.IsPotentiallyHazardousAsteroid ? "Yes" : "No";
    labelPotentiallyHazardous.ForeColor = neo.IsPotentiallyHazardousAsteroid ? Color.Red : Color.Black;

    labelSentryObject.Text = neo.IsSentryObject ? "Yes" : "No";
    labelSentryObject.ForeColor = neo.IsSentryObject ? Color.Red : Color.Black;

    panelRight.Visible = true;
  }
```
*Listing 5* - Showing the details of a selected NEO.

That's basically it! Two main classes: FormMain and NeoExplorer. Pretty straightforward.

## Acknowlegements

Many thanks to Google Gemini for the generation of the Model classes.
