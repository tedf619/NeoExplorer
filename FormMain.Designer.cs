namespace NeoExplorer
{
  partial class FormMain
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      panelTop = new Panel();
      checkBoxSentryObjects = new CheckBox();
      checkBoxPotentiallyHazardous = new CheckBox();
      numericUpDownFaintestMagnitude = new NumericUpDown();
      label3 = new Label();
      dateTimePickerEndDate = new DateTimePicker();
      label1 = new Label();
      buttonSearchForObjects = new Button();
      dateTimePickerStartDate = new DateTimePicker();
      label2 = new Label();
      panelBottom = new Panel();
      labelStatusMessage = new Label();
      label4 = new Label();
      panelMiddle = new Panel();
      neoExplorer = new NeoExplorer();
      splitter1 = new Splitter();
      toolTip = new ToolTip(components);
      panelTop.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)numericUpDownFaintestMagnitude).BeginInit();
      panelBottom.SuspendLayout();
      panelMiddle.SuspendLayout();
      SuspendLayout();
      // 
      // panelTop
      // 
      panelTop.BackColor = Color.WhiteSmoke;
      panelTop.Controls.Add(checkBoxSentryObjects);
      panelTop.Controls.Add(checkBoxPotentiallyHazardous);
      panelTop.Controls.Add(numericUpDownFaintestMagnitude);
      panelTop.Controls.Add(label3);
      panelTop.Controls.Add(dateTimePickerEndDate);
      panelTop.Controls.Add(label1);
      panelTop.Controls.Add(buttonSearchForObjects);
      panelTop.Controls.Add(dateTimePickerStartDate);
      panelTop.Controls.Add(label2);
      panelTop.Dock = DockStyle.Top;
      panelTop.Location = new Point(0, 0);
      panelTop.Name = "panelTop";
      panelTop.Size = new Size(740, 73);
      panelTop.TabIndex = 0;
      // 
      // checkBoxSentryObjects
      // 
      checkBoxSentryObjects.AutoSize = true;
      checkBoxSentryObjects.CheckAlign = ContentAlignment.MiddleRight;
      checkBoxSentryObjects.Location = new Point(435, 41);
      checkBoxSentryObjects.Name = "checkBoxSentryObjects";
      checkBoxSentryObjects.Size = new Size(102, 19);
      checkBoxSentryObjects.TabIndex = 8;
      checkBoxSentryObjects.Text = "Sentry Objects";
      toolTip.SetToolTip(checkBoxSentryObjects, "Objects flagged by Sentry, a NASA automated collision monitoring system.");
      checkBoxSentryObjects.UseVisualStyleBackColor = true;
      // 
      // checkBoxPotentiallyHazardous
      // 
      checkBoxPotentiallyHazardous.AutoSize = true;
      checkBoxPotentiallyHazardous.CheckAlign = ContentAlignment.MiddleRight;
      checkBoxPotentiallyHazardous.Location = new Point(396, 16);
      checkBoxPotentiallyHazardous.Name = "checkBoxPotentiallyHazardous";
      checkBoxPotentiallyHazardous.Size = new Size(141, 19);
      checkBoxPotentiallyHazardous.TabIndex = 7;
      checkBoxPotentiallyHazardous.Text = "Potentially Hazardous";
      toolTip.SetToolTip(checkBoxPotentiallyHazardous, "Objects flagged for their large size or their calculated closest approach distance");
      checkBoxPotentiallyHazardous.UseVisualStyleBackColor = true;
      // 
      // numericUpDownFaintestMagnitude
      // 
      numericUpDownFaintestMagnitude.Location = new Point(307, 14);
      numericUpDownFaintestMagnitude.Maximum = new decimal(new int[] { 34, 0, 0, 0 });
      numericUpDownFaintestMagnitude.Minimum = new decimal(new int[] { 9, 0, 0, 0 });
      numericUpDownFaintestMagnitude.Name = "numericUpDownFaintestMagnitude";
      numericUpDownFaintestMagnitude.Size = new Size(48, 23);
      numericUpDownFaintestMagnitude.TabIndex = 6;
      toolTip.SetToolTip(numericUpDownFaintestMagnitude, "Lower values are brighter");
      numericUpDownFaintestMagnitude.Value = new decimal(new int[] { 25, 0, 0, 0 });
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(195, 16);
      label3.Name = "label3";
      label3.Size = new Size(109, 15);
      label3.TabIndex = 5;
      label3.Text = "Faintest Magnitude";
      // 
      // dateTimePickerEndDate
      // 
      dateTimePickerEndDate.CustomFormat = "yyy-MM-dd";
      dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
      dateTimePickerEndDate.Location = new Point(66, 41);
      dateTimePickerEndDate.Name = "dateTimePickerEndDate";
      dateTimePickerEndDate.Size = new Size(99, 23);
      dateTimePickerEndDate.TabIndex = 4;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(10, 45);
      label1.Name = "label1";
      label1.Size = new Size(54, 15);
      label1.TabIndex = 3;
      label1.Text = "End Date";
      // 
      // buttonSearchForObjects
      // 
      buttonSearchForObjects.Location = new Point(579, 20);
      buttonSearchForObjects.Name = "buttonSearchForObjects";
      buttonSearchForObjects.Size = new Size(130, 23);
      buttonSearchForObjects.TabIndex = 2;
      buttonSearchForObjects.Text = "Search for Objects";
      buttonSearchForObjects.UseVisualStyleBackColor = true;
      buttonSearchForObjects.Click += ButtonSearchForObjects_Click;
      // 
      // dateTimePickerStartDate
      // 
      dateTimePickerStartDate.CustomFormat = "yyy-MM-dd";
      dateTimePickerStartDate.Format = DateTimePickerFormat.Custom;
      dateTimePickerStartDate.Location = new Point(66, 12);
      dateTimePickerStartDate.Name = "dateTimePickerStartDate";
      dateTimePickerStartDate.Size = new Size(97, 23);
      dateTimePickerStartDate.TabIndex = 1;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(6, 16);
      label2.Name = "label2";
      label2.Size = new Size(58, 15);
      label2.TabIndex = 0;
      label2.Text = "Start Date";
      // 
      // panelBottom
      // 
      panelBottom.BorderStyle = BorderStyle.FixedSingle;
      panelBottom.Controls.Add(labelStatusMessage);
      panelBottom.Controls.Add(label4);
      panelBottom.Dock = DockStyle.Bottom;
      panelBottom.Location = new Point(0, 427);
      panelBottom.Name = "panelBottom";
      panelBottom.Size = new Size(740, 23);
      panelBottom.TabIndex = 1;
      // 
      // labelStatusMessage
      // 
      labelStatusMessage.BackColor = Color.WhiteSmoke;
      labelStatusMessage.Dock = DockStyle.Fill;
      labelStatusMessage.Location = new Point(0, 0);
      labelStatusMessage.Name = "labelStatusMessage";
      labelStatusMessage.Size = new Size(593, 21);
      labelStatusMessage.TabIndex = 0;
      labelStatusMessage.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label4
      // 
      label4.Dock = DockStyle.Right;
      label4.ForeColor = Color.Gray;
      label4.Location = new Point(593, 0);
      label4.Name = "label4";
      label4.Size = new Size(145, 21);
      label4.TabIndex = 1;
      label4.Text = "Data provided by NASA";
      label4.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // panelMiddle
      // 
      panelMiddle.Controls.Add(neoExplorer);
      panelMiddle.Controls.Add(splitter1);
      panelMiddle.Dock = DockStyle.Fill;
      panelMiddle.Location = new Point(0, 73);
      panelMiddle.Name = "panelMiddle";
      panelMiddle.Size = new Size(740, 354);
      panelMiddle.TabIndex = 2;
      // 
      // neoExplorer
      // 
      neoExplorer.ApiKey = "DEMO_KEY";
      neoExplorer.Dock = DockStyle.Fill;
      neoExplorer.FaintestMagnitude = 15F;
      neoExplorer.Location = new Point(3, 0);
      neoExplorer.Name = "neoExplorer";
      neoExplorer.Size = new Size(737, 354);
      neoExplorer.TabIndex = 7;
      // 
      // splitter1
      // 
      splitter1.Location = new Point(0, 0);
      splitter1.Name = "splitter1";
      splitter1.Size = new Size(3, 354);
      splitter1.TabIndex = 6;
      splitter1.TabStop = false;
      // 
      // FormMain
      // 
      AcceptButton = buttonSearchForObjects;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(740, 450);
      Controls.Add(panelMiddle);
      Controls.Add(panelBottom);
      Controls.Add(panelTop);
      Name = "FormMain";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Near Earth Object Explorer";
      panelTop.ResumeLayout(false);
      panelTop.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)numericUpDownFaintestMagnitude).EndInit();
      panelBottom.ResumeLayout(false);
      panelMiddle.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private Panel panelTop;
    private Panel panelBottom;
    private Panel panelMiddle;
    private Splitter splitter1;
    private Button buttonSearchForObjects;
    private DateTimePicker dateTimePickerStartDate;
    private Label label2;
    private Label labelStatusMessage;
    private NeoExplorer neoExplorer;
    private DateTimePicker dateTimePickerEndDate;
    private Label label1;
    private NumericUpDown numericUpDownFaintestMagnitude;
    private Label label3;
    private ToolTip toolTip;
    private CheckBox checkBoxSentryObjects;
    private CheckBox checkBoxPotentiallyHazardous;
    private Label label4;
  }
}
