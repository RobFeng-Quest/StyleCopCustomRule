namespace SOEP.StyleCopRules
{
    partial class MethodShouldNotHaveTooManyLinesSettingsPage
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMaxMethodLineCount = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxMethodLineCount)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudMaxMethodLineCount, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(343, 160);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Maximum Method Line Count:";
            // 
            // nudMaxMethodLineCount
            // 
            this.nudMaxMethodLineCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudMaxMethodLineCount.Location = new System.Drawing.Point(224, 3);
            this.nudMaxMethodLineCount.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudMaxMethodLineCount.Name = "nudMaxMethodLineCount";
            this.nudMaxMethodLineCount.Size = new System.Drawing.Size(116, 25);
            this.nudMaxMethodLineCount.TabIndex = 1;
            this.nudMaxMethodLineCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMaxMethodLineCount.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudMaxMethodLineCount.ValueChanged += new System.EventHandler(this.nudMaxMethodLineCount_ValueChanged);
            // 
            // MethodShouldNotHaveTooManyLinesSettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MethodShouldNotHaveTooManyLinesSettingsPage";
            this.Size = new System.Drawing.Size(343, 160);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxMethodLineCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMaxMethodLineCount;
    }
}
