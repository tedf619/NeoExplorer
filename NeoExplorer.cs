using System.ComponentModel;
using System.Data;
using System.Text.Json;

namespace NeoExplorer;

public partial class NeoExplorer : UserControl
{
  readonly HttpClient http;

  [DefaultValue("")]
  public string ApiKey { get; set; } = "DEMO_KEY";

  [DefaultValue(15)]
  public float FaintestMagnitude { get; set; } = 15;

  [DefaultValue(false)] 
  public bool IsPotentiallyHazardous { get; set; } = false;

  [DefaultValue(false)]
  public bool IsSentry { get; set; } = false;

  public NeoExplorer()
  {
    InitializeComponent();

    http = new HttpClient();
    http.BaseAddress = new Uri("https://api.nasa.gov/");

    columnHeaderName.Width = -2; // autosize last column
  }

  public async Task<int> GetNearEarthObjectsAsync(DateTime startDate, DateTime endDate)
  {
    string startDateIso = startDate.ToString("yyyy-MM-dd");
    string endDateIso = endDate.ToString("yyyy-MM-dd");

    string requestUrl = $"neo/rest/v1/feed?start_date={startDateIso}&end_date={endDateIso}&api_key={ApiKey}";

    try
    {
      using var response = await http.GetAsync(requestUrl);
      response.EnsureSuccessStatusCode();

      await using var stream = await response.Content.ReadAsStreamAsync();
      var data = await JsonSerializer.DeserializeAsync<NeoFeedResponse>(stream);

      if (data == null || data.ElementCount == 0) return 0;

      return SetObjectsFound(data.NearEarthObjects);
    }
    catch (Exception ex)
    {
      throw new Exception($"Failed to fetch data: {ex.Message})");
    }
  }

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

    panelRight.Visible = false;  // we'll make it visible when user selects an item in the ListView
    return listViewObjectsFound.Items.Count;
  }

  void panelLeft_Resize(object sender, EventArgs e)
  {
    columnHeaderName.Width = -2; // autosize last column
  }

  void lLstViewObjectsFound_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
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
}
