namespace sdv701_admin_app
{
    partial class frmDSLR
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtLensMount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(354, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 25);
            this.label5.TabIndex = 54;
            this.label5.Text = "Lens mount";
            // 
            // txtLensMount
            // 
            this.txtLensMount.Location = new System.Drawing.Point(359, 157);
            this.txtLensMount.Name = "txtLensMount";
            this.txtLensMount.Size = new System.Drawing.Size(191, 31);
            this.txtLensMount.TabIndex = 55;
            // 
            // frmDSLR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.ClientSize = new System.Drawing.Size(1004, 427);
            this.Controls.Add(this.txtLensMount);
            this.Controls.Add(this.label5);
            this.Name = "frmDSLR";
            this.Text = "DSLR";
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtLensMount, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLensMount;
    }
}
