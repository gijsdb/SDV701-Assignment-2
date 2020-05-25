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
            this.btnExit = new System.Windows.Forms.Button();
            this.lblModelsFor = new System.Windows.Forms.Label();
            this.cbAddItemType = new System.Windows.Forms.ComboBox();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.btnEditModel = new System.Windows.Forms.Button();
            this.btnDeleteModel = new System.Windows.Forms.Button();
            this.lstCameraModels = new System.Windows.Forms.ListView();
            this.colModelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colModelType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colModelPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
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
            // cbAddItemType
            // 
            this.cbAddItemType.FormattingEnabled = true;
            this.cbAddItemType.Items.AddRange(new object[] {
            "DSLR",
            "PointNShoot"});
            this.cbAddItemType.Location = new System.Drawing.Point(575, 126);
            this.cbAddItemType.Name = "cbAddItemType";
            this.cbAddItemType.Size = new System.Drawing.Size(121, 33);
            this.cbAddItemType.TabIndex = 8;
            this.cbAddItemType.Text = "DSLR";
            // 
            // btnAddModel
            // 
            this.btnAddModel.Location = new System.Drawing.Point(557, 55);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(163, 65);
            this.btnAddModel.TabIndex = 6;
            this.btnAddModel.Text = "Add Model";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // btnEditModel
            // 
            this.btnEditModel.Location = new System.Drawing.Point(557, 189);
            this.btnEditModel.Name = "btnEditModel";
            this.btnEditModel.Size = new System.Drawing.Size(163, 65);
            this.btnEditModel.TabIndex = 9;
            this.btnEditModel.Text = "Edit selected model";
            this.btnEditModel.UseVisualStyleBackColor = true;
            this.btnEditModel.Click += new System.EventHandler(this.btnEditModel_Click);
            // 
            // btnDeleteModel
            // 
            this.btnDeleteModel.Location = new System.Drawing.Point(557, 272);
            this.btnDeleteModel.Name = "btnDeleteModel";
            this.btnDeleteModel.Size = new System.Drawing.Size(163, 89);
            this.btnDeleteModel.TabIndex = 10;
            this.btnDeleteModel.Text = "Delete selected model";
            this.btnDeleteModel.UseVisualStyleBackColor = true;
            this.btnDeleteModel.Click += new System.EventHandler(this.btnDeleteModel_Click);
            // 
            // lstCameraModels
            // 
            this.lstCameraModels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colModelName,
            this.colModelType,
            this.colModelPrice});
            this.lstCameraModels.FullRowSelect = true;
            this.lstCameraModels.GridLines = true;
            this.lstCameraModels.HideSelection = false;
            this.lstCameraModels.Location = new System.Drawing.Point(17, 83);
            this.lstCameraModels.MultiSelect = false;
            this.lstCameraModels.Name = "lstCameraModels";
            this.lstCameraModels.Size = new System.Drawing.Size(534, 501);
            this.lstCameraModels.TabIndex = 11;
            this.lstCameraModels.UseCompatibleStateImageBehavior = false;
            this.lstCameraModels.View = System.Windows.Forms.View.Details;
            this.lstCameraModels.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(lstCameraModels_ColumnClick);
            // 
            // colModelName
            // 
            this.colModelName.Text = "Model Name";
            this.colModelName.Width = 148;
            // 
            // colModelType
            // 
            this.colModelType.Tag = "";
            this.colModelType.Text = "Model Type";
            this.colModelType.Width = 199;
            // 
            // colModelPrice
            // 
            this.colModelPrice.Text = "Model Price";
            this.colModelPrice.Width = 150;
            // 
            // frmModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 597);
            this.Controls.Add(this.lstCameraModels);
            this.Controls.Add(this.btnDeleteModel);
            this.Controls.Add(this.btnEditModel);
            this.Controls.Add(this.cbAddItemType);
            this.Controls.Add(this.lblModelsFor);
            this.Controls.Add(this.btnAddModel);
            this.Controls.Add(this.btnExit);
            this.Name = "frmModels";
            this.Text = "Camera Models";
            this.Load += new System.EventHandler(this.frmModels_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblModelsFor;
        private System.Windows.Forms.ComboBox cbAddItemType;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.Button btnEditModel;
        private System.Windows.Forms.Button btnDeleteModel;
        private System.Windows.Forms.ListView lstCameraModels;
        private System.Windows.Forms.ColumnHeader colModelName;
        private System.Windows.Forms.ColumnHeader colModelType;
        private System.Windows.Forms.ColumnHeader colModelPrice;
    }
}