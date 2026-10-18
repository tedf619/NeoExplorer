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

The start and end dates default to covering yesterday and today. The NASA service rejects requests that cover more than seven days. By clicking the **Search for Objects** button the app queries the NASA online service at ```api.nasa.gov//neo``` to get a list of NEOs in the given period.

By default, all the NEOs whose magnitude (brightness) is below the given value are displayed. Note that counterintuitively, brightness increases with lower values in magnitude. 
You can further filter the results by checking the **Potentially Hazardous** and **Sentry Objects** checkboxes. NASA tags asteroids like this:

1. *Potentially Hazardous*. A NEO that comes within 7.5 million kilometers of Earth's orbit and has an absolute magnitude under 22 (making its diameter at least 140 meters).
2. *Sentry Objects*. A NEO tagged in NASA's Sentry, system, an automated collision-monitoring system. Sentry objects are considered to possibly hit the Earth in the next 100 years.

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
The main form of the app is just used to setup the layout and handle user interactions with the UI controls. The interesting stuff is mostly in NeoExplorer, derived from UserControl. NeoExplorer handles the download and display of the NEO data. The download of data is achieved with code like this:

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
*Listing 1* - The code related to the retrieval of NEO data.

Once the data downloaded, it is displayed in the ListView, which ends up looking something like this:


<img width="233" height="307" alt="image" src="https://github.com/user-attachments/assets/6f0a8a1a-60d3-4cbb-8cda-1da5b5669ae5" />

*Figure 4* - The ListView, showing NEOs grouped by date.

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
*Listing 2* - Populating the ListView with data grouped by date.

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
*Listing 3* - Showing the details of a selected NEO.

## The Main Form

The main form is pretty simple. Essentially it hosts the docked panels on which the various controls are placed. It also handles the events from the controls, delegating them to NeoExplorer. The following listing shows the code.

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
    panelMiddle.Visible = true;  // to show the ListView of NEOs found
    
    ShowStatusBarMessage($"Objects found: {objectsFound}");
    UseWaitCursor = false;
  }

  void ShowStatusBarMessage(string message)
  {
    labelStatusMessage.Text = message;
  }
}
```
*Listing 4* - Showing main form code.

## Acknowlegements

Many thanks to Google Gemini.
