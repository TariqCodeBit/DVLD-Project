namespace DVLD_Fill_project.Users
{
    partial class fmChangePassword
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
            this.components = new System.ComponentModel.Container();
            this.ctlrUserCard1 = new DVLD_Fill_project.Users.ctlrUserCard();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.TBCurrentPassword = new System.Windows.Forms.TextBox();
            this.TBNewPassword = new System.Windows.Forms.TextBox();
            this.TBConfirmPassword = new System.Windows.Forms.TextBox();
            this.Busave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlrUserCard1
            // 
            this.ctlrUserCard1.Location = new System.Drawing.Point(2, -1);
            this.ctlrUserCard1.Name = "ctlrUserCard1";
            this.ctlrUserCard1.Size = new System.Drawing.Size(867, 445);
            this.ctlrUserCard1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 495);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 527);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Confirm Password :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Fill_project.Properties.Resources.Nationalpng;
            this.pictureBox1.Location = new System.Drawing.Point(212, 460);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Fill_project.Properties.Resources.Nationalpng;
            this.pictureBox2.Location = new System.Drawing.Point(212, 498);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Fill_project.Properties.Resources.Nationalpng;
            this.pictureBox3.Location = new System.Drawing.Point(212, 527);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // TBCurrentPassword
            // 
            this.TBCurrentPassword.Location = new System.Drawing.Point(261, 460);
            this.TBCurrentPassword.Name = "TBCurrentPassword";
            this.TBCurrentPassword.Size = new System.Drawing.Size(153, 22);
            this.TBCurrentPassword.TabIndex = 7;
            this.TBCurrentPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TBCurrentPassword_Validating);
            // 
            // TBNewPassword
            // 
            this.TBNewPassword.Location = new System.Drawing.Point(261, 498);
            this.TBNewPassword.Name = "TBNewPassword";
            this.TBNewPassword.Size = new System.Drawing.Size(153, 22);
            this.TBNewPassword.TabIndex = 8;
            this.TBNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TBNewPassword_Validating);
            // 
            // TBConfirmPassword
            // 
            this.TBConfirmPassword.Location = new System.Drawing.Point(261, 527);
            this.TBConfirmPassword.Name = "TBConfirmPassword";
            this.TBConfirmPassword.Size = new System.Drawing.Size(153, 22);
            this.TBConfirmPassword.TabIndex = 9;
            this.TBConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TBConfirmPassword_Validating);
            // 
            // Busave
            // 
            this.Busave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Busave.Image = global::DVLD_Fill_project.Properties.Resources.download;
            this.Busave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Busave.Location = new System.Drawing.Point(750, 559);
            this.Busave.Name = "Busave";
            this.Busave.Size = new System.Drawing.Size(105, 47);
            this.Busave.TabIndex = 10;
            this.Busave.Text = "Save";
            this.Busave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Busave.UseVisualStyleBackColor = true;
            this.Busave.Click += new System.EventHandler(this.Busave_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DVLD_Fill_project.Properties.Resources.close;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(622, 559);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 47);
            this.button1.TabIndex = 11;
            this.button1.Text = "Close";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // fmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 618);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Busave);
            this.Controls.Add(this.TBConfirmPassword);
            this.Controls.Add(this.TBNewPassword);
            this.Controls.Add(this.TBCurrentPassword);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlrUserCard1);
            this.Name = "fmChangePassword";
            this.Text = "fmChangePassword";
            this.Load += new System.EventHandler(this.fmChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctlrUserCard ctlrUserCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox TBCurrentPassword;
        private System.Windows.Forms.TextBox TBNewPassword;
        private System.Windows.Forms.TextBox TBConfirmPassword;
        private System.Windows.Forms.Button Busave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}