namespace sdv701_admin_app
{
    partial class frmBrands
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
            this.lstCameraBrands = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnViewOrders = new System.Windows.Forms.Button();
            this.btnViewModels = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstCameraBrands
            // 
            this.lstCameraBrands.FormattingEnabled = true;
            this.lstCameraBrands.ItemHeight = 25;
            this.lstCameraBrands.Location = new System.Drawing.Point(12, 58);
            this.lstCameraBrands.Name = "lstCameraBrands";
            this.lstCameraBrands.Size = new System.Drawing.Size(242, 529);
            this.lstCameraBrands.TabIndex = 0;
            this.lstCameraBrands.DoubleClick += new System.EventHandler(this.lstCameraBrands_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Camera Brands";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(281, 534);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 53);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnViewOrders
            // 
            this.btnViewOrders.Location = new System.Drawing.Point(281, 450);
            this.btnViewOrders.Name = "btnViewOrders";
            this.btnViewOrders.Size = new System.Drawing.Size(113, 65);
            this.btnViewOrders.TabIndex = 4;
            this.btnViewOrders.Text = "View orders";
            this.btnViewOrders.UseVisualStyleBackColor = true;
            // 
            // btnViewModels
            // 
            this.btnViewModels.Location = new System.Drawing.Point(281, 362);
            this.btnViewModels.Name = "btnViewModels";
            this.btnViewModels.Size = new System.Drawing.Size(113, 65);
            this.btnViewModels.TabIndex = 5;
            this.btnViewModels.Text = "View models";
            this.btnViewModels.UseVisualStyleBackColor = true;
            this.btnViewModels.Click += new System.EventHandler(this.btnViewModels_Click);
            // 
            // frmBrands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 599);
            this.Controls.Add(this.btnViewModels);
            this.Controls.Add(this.btnViewOrders);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstCameraBrands);
            this.Name = "frmBrands";
            this.Text = "CameraCo NZ";
            this.Load += new System.EventHandler(this.frmBrands_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCameraBrands;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnViewOrders;
        private System.Windows.Forms.Button btnViewModels;
    }
}

