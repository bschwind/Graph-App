namespace GraphApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.graphAppGUI1 = new GraphApp.src.gui.GraphAppGUI();
            this.SuspendLayout();
            // 
            // graphAppGUI1
            // 
            this.graphAppGUI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphAppGUI1.Location = new System.Drawing.Point(0, 0);
            this.graphAppGUI1.Name = "graphAppGUI1";
            this.graphAppGUI1.Size = new System.Drawing.Size(953, 529);
            this.graphAppGUI1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 529);
            this.Controls.Add(this.graphAppGUI1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Graph App";
            this.ResumeLayout(false);

        }

        #endregion

        private src.gui.GraphAppGUI graphAppGUI1;
    }
}

