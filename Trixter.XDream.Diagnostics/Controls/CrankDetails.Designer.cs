namespace Trixter.XDream.Diagnostics.Controls
{
    partial class CrankDetails
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
            this.components = new System.ComponentModel.Container();
            this.gbCrankDetails = new System.Windows.Forms.GroupBox();
            this.pnlLabels = new System.Windows.Forms.Panel();
            this.gbLegend = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lbCurrent = new System.Windows.Forms.Label();
            this.lbCurrentColor = new System.Windows.Forms.Label();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.lbUnreported = new System.Windows.Forms.Label();
            this.lbVisited = new System.Windows.Forms.Label();
            this.lbReportedColor = new System.Windows.Forms.Label();
            this.lbUnreportedColor = new System.Windows.Forms.Label();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.lbCrankSpeed = new System.Windows.Forms.Label();
            this.lbCrankSpeedValue = new System.Windows.Forms.Label();
            this.lbCrankPositionValue = new System.Windows.Forms.Label();
            this.lbCrankPos = new System.Windows.Forms.Label();
            this.pnlCrankDetails = new System.Windows.Forms.Panel();
            this.gbCrankDetails.SuspendLayout();
            this.pnlLabels.SuspendLayout();
            this.gbLegend.SuspendLayout();
            this.pnlCrankDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCrankDetails
            // 
            this.gbCrankDetails.Controls.Add(this.pnlLabels);
            this.gbCrankDetails.Controls.Add(this.gbLegend);
            this.gbCrankDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCrankDetails.Location = new System.Drawing.Point(0, 0);
            this.gbCrankDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCrankDetails.Name = "gbCrankDetails";
            this.gbCrankDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCrankDetails.Size = new System.Drawing.Size(601, 514);
            this.gbCrankDetails.TabIndex = 0;
            this.gbCrankDetails.TabStop = false;
            this.gbCrankDetails.Text = "Crank Diagnostics";
            // 
            // pnlLabels
            // 
            this.pnlLabels.Controls.Add(this.pnlCrankDetails);
            this.pnlLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLabels.Location = new System.Drawing.Point(3, 17);
            this.pnlLabels.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlLabels.Name = "pnlLabels";
            this.pnlLabels.Size = new System.Drawing.Size(595, 429);
            this.pnlLabels.TabIndex = 1;
            // 
            // gbLegend
            // 
            this.gbLegend.Controls.Add(this.btnReset);
            this.gbLegend.Controls.Add(this.lbCurrent);
            this.gbLegend.Controls.Add(this.lbCurrentColor);
            this.gbLegend.Controls.Add(this.btnPauseResume);
            this.gbLegend.Controls.Add(this.lbUnreported);
            this.gbLegend.Controls.Add(this.lbVisited);
            this.gbLegend.Controls.Add(this.lbReportedColor);
            this.gbLegend.Controls.Add(this.lbUnreportedColor);
            this.gbLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbLegend.Location = new System.Drawing.Point(3, 446);
            this.gbLegend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbLegend.Name = "gbLegend";
            this.gbLegend.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbLegend.Size = new System.Drawing.Size(595, 66);
            this.gbLegend.TabIndex = 0;
            this.gbLegend.TabStop = false;
            this.gbLegend.Text = "Legend";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(502, 25);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 28);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lbCurrent
            // 
            this.lbCurrent.AutoSize = true;
            this.lbCurrent.Location = new System.Drawing.Point(254, 32);
            this.lbCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCurrent.Name = "lbCurrent";
            this.lbCurrent.Size = new System.Drawing.Size(148, 16);
            this.lbCurrent.TabIndex = 3;
            this.lbCurrent.Text = "Reported within 1000ms";
            // 
            // lbCurrentColor
            // 
            this.lbCurrentColor.BackColor = System.Drawing.Color.DodgerBlue;
            this.lbCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCurrentColor.Location = new System.Drawing.Point(229, 30);
            this.lbCurrentColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCurrentColor.Name = "lbCurrentColor";
            this.lbCurrentColor.Size = new System.Drawing.Size(20, 18);
            this.lbCurrentColor.TabIndex = 2;
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPauseResume.Location = new System.Drawing.Point(415, 23);
            this.btnPauseResume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(85, 28);
            this.btnPauseResume.TabIndex = 6;
            this.btnPauseResume.Text = "Pause";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // lbUnreported
            // 
            this.lbUnreported.AutoSize = true;
            this.lbUnreported.Location = new System.Drawing.Point(43, 32);
            this.lbUnreported.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUnreported.Name = "lbUnreported";
            this.lbUnreported.Size = new System.Drawing.Size(75, 16);
            this.lbUnreported.TabIndex = 5;
            this.lbUnreported.Text = "Unreported";
            // 
            // lbVisited
            // 
            this.lbVisited.AutoSize = true;
            this.lbVisited.Location = new System.Drawing.Point(153, 32);
            this.lbVisited.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVisited.Name = "lbVisited";
            this.lbVisited.Size = new System.Drawing.Size(64, 16);
            this.lbVisited.TabIndex = 4;
            this.lbVisited.Text = "Reported";
            // 
            // lbReportedColor
            // 
            this.lbReportedColor.BackColor = System.Drawing.Color.Black;
            this.lbReportedColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbReportedColor.Location = new System.Drawing.Point(130, 30);
            this.lbReportedColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbReportedColor.Name = "lbReportedColor";
            this.lbReportedColor.Size = new System.Drawing.Size(20, 18);
            this.lbReportedColor.TabIndex = 1;
            // 
            // lbUnreportedColor
            // 
            this.lbUnreportedColor.BackColor = System.Drawing.Color.Red;
            this.lbUnreportedColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbUnreportedColor.Location = new System.Drawing.Point(18, 30);
            this.lbUnreportedColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUnreportedColor.Name = "lbUnreportedColor";
            this.lbUnreportedColor.Size = new System.Drawing.Size(20, 18);
            this.lbUnreportedColor.TabIndex = 0;
            // 
            // lbCrankSpeed
            // 
            this.lbCrankSpeed.AutoSize = true;
            this.lbCrankSpeed.Location = new System.Drawing.Point(28, 51);
            this.lbCrankSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankSpeed.Name = "lbCrankSpeed";
            this.lbCrankSpeed.Size = new System.Drawing.Size(37, 16);
            this.lbCrankSpeed.TabIndex = 32;
            this.lbCrankSpeed.Text = "RPM";
            this.lbCrankSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCrankSpeedValue
            // 
            this.lbCrankSpeedValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankSpeedValue.Location = new System.Drawing.Point(71, 44);
            this.lbCrankSpeedValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankSpeedValue.Name = "lbCrankSpeedValue";
            this.lbCrankSpeedValue.Size = new System.Drawing.Size(41, 29);
            this.lbCrankSpeedValue.TabIndex = 31;
            this.lbCrankSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCrankPositionValue
            // 
            this.lbCrankPositionValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankPositionValue.Location = new System.Drawing.Point(71, 8);
            this.lbCrankPositionValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankPositionValue.Name = "lbCrankPositionValue";
            this.lbCrankPositionValue.Size = new System.Drawing.Size(41, 29);
            this.lbCrankPositionValue.TabIndex = 30;
            this.lbCrankPositionValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCrankPos
            // 
            this.lbCrankPos.AutoSize = true;
            this.lbCrankPos.Location = new System.Drawing.Point(10, 14);
            this.lbCrankPos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankPos.Name = "lbCrankPos";
            this.lbCrankPos.Size = new System.Drawing.Size(55, 16);
            this.lbCrankPos.TabIndex = 29;
            this.lbCrankPos.Text = "Position";
            this.lbCrankPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlCrankDetails
            // 
            this.pnlCrankDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCrankDetails.Controls.Add(this.lbCrankPositionValue);
            this.pnlCrankDetails.Controls.Add(this.lbCrankSpeed);
            this.pnlCrankDetails.Controls.Add(this.lbCrankPos);
            this.pnlCrankDetails.Controls.Add(this.lbCrankSpeedValue);
            this.pnlCrankDetails.Location = new System.Drawing.Point(462, 338);
            this.pnlCrankDetails.Name = "pnlCrankDetails";
            this.pnlCrankDetails.Size = new System.Drawing.Size(125, 84);
            this.pnlCrankDetails.TabIndex = 33;
            // 
            // CrankDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCrankDetails);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CrankDetails";
            this.Size = new System.Drawing.Size(601, 514);
            this.gbCrankDetails.ResumeLayout(false);
            this.pnlLabels.ResumeLayout(false);
            this.gbLegend.ResumeLayout(false);
            this.gbLegend.PerformLayout();
            this.pnlCrankDetails.ResumeLayout(false);
            this.pnlCrankDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCrankDetails;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.GroupBox gbLegend;
        private System.Windows.Forms.Label lbUnreported;
        private System.Windows.Forms.Label lbVisited;
        private System.Windows.Forms.Label lbCurrent;
        private System.Windows.Forms.Label lbCurrentColor;
        private System.Windows.Forms.Label lbReportedColor;
        private System.Windows.Forms.Label lbUnreportedColor;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.Panel pnlLabels;
        private System.Windows.Forms.Label lbCrankSpeed;
        private System.Windows.Forms.Label lbCrankSpeedValue;
        private System.Windows.Forms.Label lbCrankPositionValue;
        private System.Windows.Forms.Label lbCrankPos;
        private System.Windows.Forms.Panel pnlCrankDetails;
    }
}
