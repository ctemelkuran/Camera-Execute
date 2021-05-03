namespace Camera_Execute
{
    partial class ChangeCameraForm
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
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeCameraForm));
            this.CamProp = new System.Windows.Forms.Label();
            this.X = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.Y = new System.Windows.Forms.Label();
            this.Z = new System.Windows.Forms.Label();
            this.EyePos = new System.Windows.Forms.Label();
            this.UpDir = new System.Windows.Forms.Label();
            this.ForDir = new System.Windows.Forms.Label();
            this.tbxEyeX = new System.Windows.Forms.TextBox();
            this.tbxEyeY = new System.Windows.Forms.TextBox();
            this.tbxEyeZ = new System.Windows.Forms.TextBox();
            this.tbxUpX = new System.Windows.Forms.TextBox();
            this.tbxUpY = new System.Windows.Forms.TextBox();
            this.tbxUpZ = new System.Windows.Forms.TextBox();
            this.tbxFwdZ = new System.Windows.Forms.TextBox();
            this.tbxFwdY = new System.Windows.Forms.TextBox();
            this.tbxFwdX = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CamProp
            // 
            this.CamProp.AutoSize = true;
            this.CamProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CamProp.Location = new System.Drawing.Point(12, 9);
            this.CamProp.Name = "CamProp";
            this.CamProp.Size = new System.Drawing.Size(111, 17);
            this.CamProp.TabIndex = 0;
            this.CamProp.Text = "Camera Execute";
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X.Location = new System.Drawing.Point(184, 35);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(15, 15);
            this.X.TabIndex = 0;
            this.X.Text = "X";
            // 
            // btnSubmit
            // 
            this.btnSubmit.AutoSize = true;
            this.btnSubmit.Location = new System.Drawing.Point(225, 167);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(49, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // Y
            // 
            this.Y.AutoSize = true;
            this.Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y.Location = new System.Drawing.Point(278, 35);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(14, 15);
            this.Y.TabIndex = 3;
            this.Y.Text = "Y";
            // 
            // Z
            // 
            this.Z.AutoSize = true;
            this.Z.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z.Location = new System.Drawing.Point(358, 35);
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(14, 15);
            this.Z.TabIndex = 4;
            this.Z.Text = "Z";
            // 
            // EyePos
            // 
            this.EyePos.AutoSize = true;
            this.EyePos.Location = new System.Drawing.Point(15, 61);
            this.EyePos.Name = "EyePos";
            this.EyePos.Size = new System.Drawing.Size(65, 13);
            this.EyePos.TabIndex = 5;
            this.EyePos.Text = "Eye Position";
            // 
            // UpDir
            // 
            this.UpDir.AutoSize = true;
            this.UpDir.Location = new System.Drawing.Point(15, 87);
            this.UpDir.Name = "UpDir";
            this.UpDir.Size = new System.Drawing.Size(66, 13);
            this.UpDir.TabIndex = 6;
            this.UpDir.Text = "Up Direction";
            // 
            // ForDir
            // 
            this.ForDir.AutoSize = true;
            this.ForDir.Location = new System.Drawing.Point(15, 115);
            this.ForDir.Name = "ForDir";
            this.ForDir.Size = new System.Drawing.Size(90, 13);
            this.ForDir.TabIndex = 7;
            this.ForDir.Text = "Forward Direction";
            // 
            // tbxEyeX
            // 
            this.tbxEyeX.Location = new System.Drawing.Point(154, 58);
            this.tbxEyeX.Name = "tbxEyeX";
            this.tbxEyeX.Size = new System.Drawing.Size(71, 20);
            this.tbxEyeX.TabIndex = 8;
            // 
            // tbxEyeY
            // 
            this.tbxEyeY.Location = new System.Drawing.Point(246, 58);
            this.tbxEyeY.Name = "tbxEyeY";
            this.tbxEyeY.Size = new System.Drawing.Size(69, 20);
            this.tbxEyeY.TabIndex = 9;
            // 
            // tbxEyeZ
            // 
            this.tbxEyeZ.Location = new System.Drawing.Point(337, 58);
            this.tbxEyeZ.Name = "tbxEyeZ";
            this.tbxEyeZ.Size = new System.Drawing.Size(69, 20);
            this.tbxEyeZ.TabIndex = 10;
            // 
            // tbxUpX
            // 
            this.tbxUpX.Location = new System.Drawing.Point(154, 87);
            this.tbxUpX.Name = "tbxUpX";
            this.tbxUpX.Size = new System.Drawing.Size(71, 20);
            this.tbxUpX.TabIndex = 11;
            // 
            // tbxUpY
            // 
            this.tbxUpY.Location = new System.Drawing.Point(246, 87);
            this.tbxUpY.Name = "tbxUpY";
            this.tbxUpY.Size = new System.Drawing.Size(69, 20);
            this.tbxUpY.TabIndex = 12;
            // 
            // tbxUpZ
            // 
            this.tbxUpZ.Location = new System.Drawing.Point(337, 87);
            this.tbxUpZ.Name = "tbxUpZ";
            this.tbxUpZ.Size = new System.Drawing.Size(69, 20);
            this.tbxUpZ.TabIndex = 13;
            // 
            // tbxFwdZ
            // 
            this.tbxFwdZ.Location = new System.Drawing.Point(337, 113);
            this.tbxFwdZ.Name = "tbxFwdZ";
            this.tbxFwdZ.Size = new System.Drawing.Size(69, 20);
            this.tbxFwdZ.TabIndex = 16;
            // 
            // tbxFwdY
            // 
            this.tbxFwdY.Location = new System.Drawing.Point(246, 113);
            this.tbxFwdY.Name = "tbxFwdY";
            this.tbxFwdY.Size = new System.Drawing.Size(69, 20);
            this.tbxFwdY.TabIndex = 15;
            // 
            // tbxFwdX
            // 
            this.tbxFwdX.Location = new System.Drawing.Point(154, 113);
            this.tbxFwdX.Name = "tbxFwdX";
            this.tbxFwdX.Size = new System.Drawing.Size(71, 20);
            this.tbxFwdX.TabIndex = 14;
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Location = new System.Drawing.Point(154, 167);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(52, 23);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ChangeCameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(418, 202);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbxFwdZ);
            this.Controls.Add(this.tbxFwdY);
            this.Controls.Add(this.tbxFwdX);
            this.Controls.Add(this.tbxUpZ);
            this.Controls.Add(this.tbxUpY);
            this.Controls.Add(this.tbxUpX);
            this.Controls.Add(this.tbxEyeZ);
            this.Controls.Add(this.tbxEyeY);
            this.Controls.Add(this.tbxEyeX);
            this.Controls.Add(this.ForDir);
            this.Controls.Add(this.UpDir);
            this.Controls.Add(this.EyePos);
            this.Controls.Add(this.Z);
            this.Controls.Add(this.Y);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.X);
            this.Controls.Add(this.CamProp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeCameraForm";
            this.Text = "Change Camera";
            this.Load += new System.EventHandler(this.btnSubmit_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CamProp;
        private System.Windows.Forms.Label X;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label Y;
        private System.Windows.Forms.Label Z;
        private System.Windows.Forms.Label EyePos;
        private System.Windows.Forms.Label UpDir;
        private System.Windows.Forms.Label ForDir;
        private System.Windows.Forms.TextBox tbxEyeX;
        private System.Windows.Forms.TextBox tbxEyeY;
        private System.Windows.Forms.TextBox tbxEyeZ;
        private System.Windows.Forms.TextBox tbxUpX;
        private System.Windows.Forms.TextBox tbxUpY;
        private System.Windows.Forms.TextBox tbxUpZ;
        private System.Windows.Forms.TextBox tbxFwdZ;
        private System.Windows.Forms.TextBox tbxFwdY;
        private System.Windows.Forms.TextBox tbxFwdX;
        private System.Windows.Forms.Button btnUpdate;
    }
}