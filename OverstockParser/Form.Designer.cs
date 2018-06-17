namespace OverstockParser
{
    partial class ExcelParser
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Info = new System.Windows.Forms.Label();
            this.dropPanel = new System.Windows.Forms.Panel();
            this.SaveLocationLabel = new System.Windows.Forms.Label();
            this.OpenSaveDialogButton = new System.Windows.Forms.Button();
            this.OrdersLabel = new System.Windows.Forms.Label();
            this.TrackingNumbersLabel = new System.Windows.Forms.Label();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SaveLabel = new System.Windows.Forms.Label();
            this.dropPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Location = new System.Drawing.Point(244, 139);
            this.Info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(166, 20);
            this.Info.TabIndex = 0;
            this.Info.Text = "Drag Excel Files Here!";
            // 
            // dropPanel
            // 
            this.dropPanel.AllowDrop = true;
            this.dropPanel.BackColor = System.Drawing.Color.Transparent;
            this.dropPanel.Controls.Add(this.SaveLabel);
            this.dropPanel.Controls.Add(this.SaveLocationLabel);
            this.dropPanel.Controls.Add(this.OpenSaveDialogButton);
            this.dropPanel.Controls.Add(this.Info);
            this.dropPanel.Controls.Add(this.OrdersLabel);
            this.dropPanel.Controls.Add(this.TrackingNumbersLabel);
            this.dropPanel.Location = new System.Drawing.Point(13, 14);
            this.dropPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dropPanel.Name = "dropPanel";
            this.dropPanel.Size = new System.Drawing.Size(684, 369);
            this.dropPanel.TabIndex = 1;
            this.dropPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropPanel_DragDrop);
            this.dropPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.dropPanel_DragEnter);
            this.dropPanel.DragLeave += new System.EventHandler(this.dropPanel_DragLeave);
            // 
            // SaveLocationLabel
            // 
            this.SaveLocationLabel.AutoSize = true;
            this.SaveLocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationLabel.Location = new System.Drawing.Point(3, 302);
            this.SaveLocationLabel.Name = "SaveLocationLabel";
            this.SaveLocationLabel.Size = new System.Drawing.Size(103, 20);
            this.SaveLocationLabel.TabIndex = 4;
            this.SaveLocationLabel.Text = "saveLocation";
            // 
            // OpenSaveDialogButton
            // 
            this.OpenSaveDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenSaveDialogButton.Location = new System.Drawing.Point(488, 327);
            this.OpenSaveDialogButton.Name = "OpenSaveDialogButton";
            this.OpenSaveDialogButton.Size = new System.Drawing.Size(193, 39);
            this.OpenSaveDialogButton.TabIndex = 3;
            this.OpenSaveDialogButton.Text = "Change Save Location";
            this.OpenSaveDialogButton.UseVisualStyleBackColor = true;
            this.OpenSaveDialogButton.Click += new System.EventHandler(this.OpenSaveDialogButton_Click);
            // 
            // OrdersLabel
            // 
            this.OrdersLabel.AutoSize = true;
            this.OrdersLabel.Location = new System.Drawing.Point(244, 169);
            this.OrdersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OrdersLabel.Name = "OrdersLabel";
            this.OrdersLabel.Size = new System.Drawing.Size(100, 20);
            this.OrdersLabel.TabIndex = 2;
            this.OrdersLabel.Text = "✘ Orders File";
            // 
            // TrackingNumbersLabel
            // 
            this.TrackingNumbersLabel.AutoSize = true;
            this.TrackingNumbersLabel.Location = new System.Drawing.Point(244, 200);
            this.TrackingNumbersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TrackingNumbersLabel.Name = "TrackingNumbersLabel";
            this.TrackingNumbersLabel.Size = new System.Drawing.Size(180, 20);
            this.TrackingNumbersLabel.TabIndex = 1;
            this.TrackingNumbersLabel.Text = "✘ Tracking Numbers File";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "csv";
            this.SaveFileDialog.FileName = "upload.csv";
            // 
            // SaveLabel
            // 
            this.SaveLabel.AutoSize = true;
            this.SaveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLabel.Location = new System.Drawing.Point(3, 277);
            this.SaveLabel.Name = "SaveLabel";
            this.SaveLabel.Size = new System.Drawing.Size(143, 20);
            this.SaveLabel.TabIndex = 5;
            this.SaveLabel.Text = "File Save Location:";
            // 
            // ExcelParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(710, 405);
            this.Controls.Add(this.dropPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ExcelParser";
            this.Text = "Overstock Parser";
            this.dropPanel.ResumeLayout(false);
            this.dropPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Panel dropPanel;
        private System.Windows.Forms.Label OrdersLabel;
        private System.Windows.Forms.Label TrackingNumbersLabel;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.Button OpenSaveDialogButton;
        private System.Windows.Forms.Label SaveLocationLabel;
        private System.Windows.Forms.Label SaveLabel;
    }
}

