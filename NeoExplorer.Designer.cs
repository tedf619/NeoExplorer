namespace NeoExplorer
{
  partial class NeoExplorer
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      panelTop = new Panel();
      label1 = new Label();
      panelLeft = new Panel();
      listViewObjectsFound = new ListView();
      columnHeaderId = new ColumnHeader();
      columnHeaderName = new ColumnHeader();
      splitter1 = new Splitter();
      panelRight = new Panel();
      labelSentryObject = new Label();
      label9 = new Label();
      labelPotentiallyHazardous = new Label();
      label = new Label();
      labelOrbitingBody = new Label();
      labelRelativeVelocity = new Label();
      label20 = new Label();
      labelEstimatedSize = new Label();
      label10 = new Label();
      labelClosestDistance = new Label();
      label12 = new Label();
      labelClosestDistanceOn = new Label();
      label8 = new Label();
      labelMagnitude = new Label();
      label5 = new Label();
      label4 = new Label();
      labelName = new Label();
      label2 = new Label();
      toolTip = new ToolTip(components);
      panelTop.SuspendLayout();
      panelLeft.SuspendLayout();
      panelRight.SuspendLayout();
      SuspendLayout();
      // 
      // panelTop
      // 
      panelTop.Controls.Add(label1);
      panelTop.Dock = DockStyle.Top;
      panelTop.Location = new Point(0, 0);
      panelTop.Name = "panelTop";
      panelTop.Size = new Size(731, 29);
      panelTop.TabIndex = 5;
      // 
      // label1
      // 
      label1.BackColor = Color.Blue;
      label1.Dock = DockStyle.Fill;
      label1.ForeColor = Color.White;
      label1.Location = new Point(0, 0);
      label1.Name = "label1";
      label1.Size = new Size(731, 29);
      label1.TabIndex = 0;
      label1.Text = "Objects Found";
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // panelLeft
      // 
      panelLeft.Controls.Add(listViewObjectsFound);
      panelLeft.Dock = DockStyle.Left;
      panelLeft.Location = new Point(0, 29);
      panelLeft.Name = "panelLeft";
      panelLeft.Size = new Size(252, 288);
      panelLeft.TabIndex = 6;
      panelLeft.Resize += panelLeft_Resize;
      // 
      // listViewObjectsFound
      // 
      listViewObjectsFound.Columns.AddRange(new ColumnHeader[] { columnHeaderId, columnHeaderName });
      listViewObjectsFound.Dock = DockStyle.Fill;
      listViewObjectsFound.FullRowSelect = true;
      listViewObjectsFound.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      listViewObjectsFound.LabelEdit = true;
      listViewObjectsFound.Location = new Point(0, 0);
      listViewObjectsFound.Name = "listViewObjectsFound";
      listViewObjectsFound.Size = new Size(252, 288);
      listViewObjectsFound.TabIndex = 0;
      listViewObjectsFound.UseCompatibleStateImageBehavior = false;
      listViewObjectsFound.View = View.Details;
      listViewObjectsFound.ItemSelectionChanged += ListViewObjectsFound_ItemSelectionChanged;
      // 
      // columnHeaderId
      // 
      columnHeaderId.Text = "ID";
      columnHeaderId.Width = 70;
      // 
      // columnHeaderName
      // 
      columnHeaderName.Text = "Name";
      columnHeaderName.Width = 136;
      // 
      // splitter1
      // 
      splitter1.Location = new Point(252, 29);
      splitter1.Name = "splitter1";
      splitter1.Size = new Size(3, 288);
      splitter1.TabIndex = 7;
      splitter1.TabStop = false;
      // 
      // panelRight
      // 
      panelRight.BorderStyle = BorderStyle.FixedSingle;
      panelRight.Controls.Add(labelSentryObject);
      panelRight.Controls.Add(label9);
      panelRight.Controls.Add(labelPotentiallyHazardous);
      panelRight.Controls.Add(label);
      panelRight.Controls.Add(labelOrbitingBody);
      panelRight.Controls.Add(labelRelativeVelocity);
      panelRight.Controls.Add(label20);
      panelRight.Controls.Add(labelEstimatedSize);
      panelRight.Controls.Add(label10);
      panelRight.Controls.Add(labelClosestDistance);
      panelRight.Controls.Add(label12);
      panelRight.Controls.Add(labelClosestDistanceOn);
      panelRight.Controls.Add(label8);
      panelRight.Controls.Add(labelMagnitude);
      panelRight.Controls.Add(label5);
      panelRight.Controls.Add(label4);
      panelRight.Controls.Add(labelName);
      panelRight.Controls.Add(label2);
      panelRight.Dock = DockStyle.Fill;
      panelRight.Location = new Point(255, 29);
      panelRight.Name = "panelRight";
      panelRight.Size = new Size(476, 288);
      panelRight.TabIndex = 8;
      // 
      // labelSentryObject
      // 
      labelSentryObject.AutoSize = true;
      labelSentryObject.Location = new Point(162, 227);
      labelSentryObject.Name = "labelSentryObject";
      labelSentryObject.Size = new Size(23, 15);
      labelSentryObject.TabIndex = 25;
      labelSentryObject.Text = "No";
      // 
      // label9
      // 
      label9.AutoSize = true;
      label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      label9.Location = new Point(74, 227);
      label9.Name = "label9";
      label9.Size = new Size(87, 15);
      label9.TabIndex = 24;
      label9.Text = "Sentry Object:";
      // 
      // labelPotentiallyHazardous
      // 
      labelPotentiallyHazardous.AutoSize = true;
      labelPotentiallyHazardous.Location = new Point(162, 204);
      labelPotentiallyHazardous.Name = "labelPotentiallyHazardous";
      labelPotentiallyHazardous.Size = new Size(23, 15);
      labelPotentiallyHazardous.TabIndex = 23;
      labelPotentiallyHazardous.Text = "No";
      // 
      // label
      // 
      label.AutoSize = true;
      label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      label.Location = new Point(31, 204);
      label.Name = "label";
      label.Size = new Size(130, 15);
      label.TabIndex = 22;
      label.Text = "Potentially Hazardous:";
      // 
      // labelOrbitingBody
      // 
      labelOrbitingBody.AutoSize = true;
      labelOrbitingBody.Location = new Point(162, 50);
      labelOrbitingBody.Name = "labelOrbitingBody";
      labelOrbitingBody.Size = new Size(34, 15);
      labelOrbitingBody.TabIndex = 19;
      labelOrbitingBody.Text = "Earth";
      // 
      // labelRelativeVelocity
      // 
      labelRelativeVelocity.AutoSize = true;
      labelRelativeVelocity.Location = new Point(162, 180);
      labelRelativeVelocity.Name = "labelRelativeVelocity";
      labelRelativeVelocity.Size = new Size(70, 15);
      labelRelativeVelocity.TabIndex = 12;
      labelRelativeVelocity.Text = "18.8 km/sec";
      // 
      // label20
      // 
      label20.AutoSize = true;
      label20.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      label20.Location = new Point(58, 180);
      label20.Name = "label20";
      label20.Size = new Size(103, 15);
      label20.TabIndex = 11;
      label20.Text = "Relative Velocity:";
      // 
      // labelEstimatedSize
      // 
      labelEstimatedSize.AutoSize = true;
      labelEstimatedSize.Location = new Point(162, 154);
      labelEstimatedSize.Name = "labelEstimatedSize";
      labelEstimatedSize.Size = new Size(137, 15);
      labelEstimatedSize.TabIndex = 10;
      labelEstimatedSize.Text = "Between 0.34 and .76 km";
      // 
      // label10
      // 
      label10.AutoSize = true;
      label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      label10.Location = new Point(70, 154);
      label10.Name = "label10";
      label10.Size = new Size(91, 15);
      label10.TabIndex = 9;
      label10.Text = "Estimated Size:";
      // 
      // labelClosestDistance
      // 
      labelClosestDistance.AutoSize = true;
      labelClosestDistance.Location = new Point(162, 102);
      labelClosestDistance.Name = "labelClosestDistance";
      labelClosestDistance.Size = new Size(111, 15);
      labelClosestDistance.TabIndex = 8;
      labelClosestDistance.Text = "73.7 (in Lunar units)";
      toolTip.SetToolTip(labelClosestDistance, "A Lunar unit is the average distance between Earth and the Moon");
      // 
      // label12
      // 
      label12.AutoSize = true;
      label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      label12.Location = new Point(61, 102);
      label12.Name = "label12";
      label12.Size = new Size(100, 15);
      label12.TabIndex = 7;
      label12.Text = "Closest Distance:";
      // 
      // labelClosestDistanceOn
      // 
      labelClosestDistanceOn.AutoSize = true;
      labelClosestDistanceOn.Location = new Point(162, 128);
      labelClosestDistanceOn.Name = "labelClosestDistanceOn";
      labelClosestDistanceOn.Size = new Size(95, 15);
      labelClosestDistanceOn.TabIndex = 6;
      labelClosestDistanceOn.Text = "2026-10-01 15:58";
      // 
      // label8
      // 
      label8.AutoSize = true;
      label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      label8.Location = new Point(42, 128);
      label8.Name = "label8";
      label8.Size = new Size(119, 15);
      label8.TabIndex = 5;
      label8.Text = "Closest Distance On:";
      // 
      // labelMagnitude
      // 
      labelMagnitude.AutoSize = true;
      labelMagnitude.Location = new Point(162, 76);
      labelMagnitude.Name = "labelMagnitude";
      labelMagnitude.Size = new Size(28, 15);
      labelMagnitude.TabIndex = 4;
      labelMagnitude.Text = "19.5";
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      label5.Location = new Point(91, 76);
      label5.Name = "label5";
      label5.Size = new Size(70, 15);
      label5.TabIndex = 3;
      label5.Text = "Magnitude:";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      label4.Location = new Point(118, 24);
      label4.Name = "label4";
      label4.Size = new Size(43, 15);
      label4.TabIndex = 2;
      label4.Text = "Name:";
      // 
      // labelName
      // 
      labelName.AutoSize = true;
      labelName.Location = new Point(162, 24);
      labelName.Name = "labelName";
      labelName.Size = new Size(61, 15);
      labelName.TabIndex = 1;
      labelName.Text = "(2008 TX3)";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      label2.Location = new Point(74, 50);
      label2.Name = "label2";
      label2.Size = new Size(87, 15);
      label2.TabIndex = 0;
      label2.Text = "Orbiting Body:";
      // 
      // NeoExplorer
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(panelRight);
      Controls.Add(splitter1);
      Controls.Add(panelLeft);
      Controls.Add(panelTop);
      Name = "NeoExplorer";
      Size = new Size(731, 317);
      panelTop.ResumeLayout(false);
      panelLeft.ResumeLayout(false);
      panelRight.ResumeLayout(false);
      panelRight.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private Panel panelTop;
    private Label label1;
    private Panel panelLeft;
    private ListView listViewObjectsFound;
    private ColumnHeader columnHeaderId;
    private ColumnHeader columnHeaderName;
    private Splitter splitter1;
    private Panel panelRight;
    private Label labelEstimatedSize;
    private Label label10;
    private Label labelClosestDistance;
    private Label label12;
    private Label labelClosestDistanceOn;
    private Label label8;
    private Label labelMagnitude;
    private Label label5;
    private Label label4;
    private Label labelName;
    private Label label2;
    private Label labelOrbitingBody;
    private Label labelRelativeVelocity;
    private Label label20;
    private ToolTip toolTip;
    private Label label9;
    private Label label;
    private Label labelPotentiallyHazardous;
    private Label labelSentryObject;
  }
}
