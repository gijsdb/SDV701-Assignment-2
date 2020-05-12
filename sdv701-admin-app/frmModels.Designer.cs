namespace sdv701_admin_app
{
    partial class frmModels
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
            this.lstCameraModels = new System.Windows.Forms.ListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblModelsFor = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstCameraModels
            // 
            this.lstCameraModels.FormattingEnabled = true;
            this.lstCameraModels.ItemHeight = 25;
            this.lstCameraModels.Items.AddRange(new object[] {
            "Canon 70D   NZD700   DSLR",
            "Canon 600D NZD500   DSLR",
            "Canon Pixa   NZD300   PointNShoot"});
            this.lstCameraModels.Location = new System.Drawing.Point(12, 55);
            this.lstCameraModels.Name = "lstCameraModels";
            this.lstCameraModels.Size = new System.Drawing.Size(539, 529);
            this.lstCameraModels.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(575, 519);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(127, 65);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblModelsFor
            // 
            this.lblModelsFor.AutoSize = true;
            this.lblModelsFor.Location = new System.Drawing.Point(12, 18);
            this.lblModelsFor.Name = "lblModelsFor";
            this.lblModelsFor.Size = new System.Drawing.Size(200, 25);
            this.lblModelsFor.TabIndex = 7;
            this.lblModelsFor.Text = "Camera Models for ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(575, 126);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 33);
            this.comboBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(557, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 65);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add Model";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(557, 189);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 65);
            this.button3.TabIndex = 9;
            this.button3.Text = "Edit selected model";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(557, 272);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 89);
            this.button4.TabIndex = 10;
            this.button4.Text = "Delete selected model";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // frmModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 597);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblModelsFor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lstCameraModels);
            this.Name = "frmModels";
            this.Text = "Camera Models";
            this.Load += new System.EventHandler(this.frmModels_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCameraModels;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblModelsFor;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}