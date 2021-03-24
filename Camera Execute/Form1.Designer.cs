namespace Camera_Execute
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
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CamProp = new System.Windows.Forms.Label();
            this.X = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.Y = new System.Windows.Forms.Label();
            this.Z = new System.Windows.Forms.Label();
            this.EyePos = new System.Windows.Forms.Label();
            this.UpDir = new System.Windows.Forms.Label();
            this.ForDir = new System.Windows.Forms.Label();
            this.eyeX = new System.Windows.Forms.TextBox();
            this.eyeY = new System.Windows.Forms.TextBox();
            this.eyeZ = new System.Windows.Forms.TextBox();
            this.upX = new System.Windows.Forms.TextBox();
            this.upY = new System.Windows.Forms.TextBox();
            this.upZ = new System.Windows.Forms.TextBox();
            this.fwdZ = new System.Windows.Forms.TextBox();
            this.fwdY = new System.Windows.Forms.TextBox();
            this.fwdX = new System.Windows.Forms.TextBox();
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
            // eyeX
            // 
            this.eyeX.Location = new System.Drawing.Point(154, 58);
            this.eyeX.Name = "eyeX";
            this.eyeX.Size = new System.Drawing.Size(71, 20);
            this.eyeX.TabIndex = 8;
            
            // 
            // eyeY
            // 
            this.eyeY.Location = new System.Drawing.Point(246, 58);
            this.eyeY.Name = "eyeY";
            this.eyeY.Size = new System.Drawing.Size(69, 20);
            this.eyeY.TabIndex = 9;
            // 
            // eyeZ
            // 
            this.eyeZ.Location = new System.Drawing.Point(337, 58);
            this.eyeZ.Name = "eyeZ";
            this.eyeZ.Size = new System.Drawing.Size(69, 20);
            this.eyeZ.TabIndex = 10;
            // 
            // upX
            // 
            this.upX.Location = new System.Drawing.Point(154, 87);
            this.upX.Name = "upX";
            this.upX.Size = new System.Drawing.Size(71, 20);
            this.upX.TabIndex = 11;
            // 
            // upY
            // 
            this.upY.Location = new System.Drawing.Point(246, 87);
            this.upY.Name = "upY";
            this.upY.Size = new System.Drawing.Size(69, 20);
            this.upY.TabIndex = 12;
            // 
            // upZ
            // 
            this.upZ.Location = new System.Drawing.Point(337, 87);
            this.upZ.Name = "upZ";
            this.upZ.Size = new System.Drawing.Size(69, 20);
            this.upZ.TabIndex = 13;
            // 
            // fwdZ
            // 
            this.fwdZ.Location = new System.Drawing.Point(337, 113);
            this.fwdZ.Name = "fwdZ";
            this.fwdZ.Size = new System.Drawing.Size(69, 20);
            this.fwdZ.TabIndex = 16;
            // 
            // fwdY
            // 
            this.fwdY.Location = new System.Drawing.Point(246, 113);
            this.fwdY.Name = "fwdY";
            this.fwdY.Size = new System.Drawing.Size(69, 20);
            this.fwdY.TabIndex = 15;
            // 
            // fwdX
            // 
            this.fwdX.Location = new System.Drawing.Point(154, 113);
            this.fwdX.Name = "fwdX";
            this.fwdX.Size = new System.Drawing.Size(71, 20);
            this.fwdX.TabIndex = 14;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(418, 202);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.fwdZ);
            this.Controls.Add(this.fwdY);
            this.Controls.Add(this.fwdX);
            this.Controls.Add(this.upZ);
            this.Controls.Add(this.upY);
            this.Controls.Add(this.upX);
            this.Controls.Add(this.eyeZ);
            this.Controls.Add(this.eyeY);
            this.Controls.Add(this.eyeX);
            this.Controls.Add(this.ForDir);
            this.Controls.Add(this.UpDir);
            this.Controls.Add(this.EyePos);
            this.Controls.Add(this.Z);
            this.Controls.Add(this.Y);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.X);
            this.Controls.Add(this.CamProp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
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
        private System.Windows.Forms.TextBox eyeX;
        private System.Windows.Forms.TextBox eyeY;
        private System.Windows.Forms.TextBox eyeZ;
        private System.Windows.Forms.TextBox upX;
        private System.Windows.Forms.TextBox upY;
        private System.Windows.Forms.TextBox upZ;
        private System.Windows.Forms.TextBox fwdZ;
        private System.Windows.Forms.TextBox fwdY;
        private System.Windows.Forms.TextBox fwdX;
        private System.Windows.Forms.Button btnUpdate;
    }
}