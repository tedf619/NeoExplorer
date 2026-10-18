namespace NeoExplorer;

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
