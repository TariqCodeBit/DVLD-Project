namespace DVLD_Fill_project.People.Controls
{
    partial class ctrlShowPerosnCardWithFilter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlShowPerosnCardWithFilter));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BUadd = new System.Windows.Forms.Button();
            this.Bufind = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlShowPersonCard1 = new DVLD_Fill_project.People.Controls.ctrlShowPersonCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BUadd);
            this.groupBox1.Controls.Add(this.Bufind);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(19, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(856, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // BUadd
            // 
            this.BUadd.Image = global::DVLD_Fill_project.Properties.Resources.add_user;
            this.BUadd.Location = new System.Drawing.Point(562, 34);
            this.BUadd.Name = "BUadd";
            this.BUadd.Size = new System.Drawing.Size(37, 37);
            this.BUadd.TabIndex = 4;
            this.BUadd.UseVisualStyleBackColor = true;
            this.BUadd.Click += new System.EventHandler(this.BUadd_Click);
            // 
            // Bufind
            // 
            this.Bufind.Image = ((System.Drawing.Image)(resources.GetObject("Bufind.Image")));
            this.Bufind.Location = new System.Drawing.Point(513, 32);
            this.Bufind.Name = "Bufind";
            this.Bufind.Size = new System.Drawing.Size(43, 39);
            this.Bufind.TabIndex = 3;
            this.Bufind.UseVisualStyleBackColor = true;
            this.Bufind.Click += new System.EventHandler(this.Bufind_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(303, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 22);
            this.textBox1.TabIndex = 2;
          //  this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.comboBox1.Location = new System.Drawing.Point(93, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(188, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find by :";
            // 
            // ctrlShowPersonCard1
            // 
            this.ctrlShowPersonCard1.Location = new System.Drawing.Point(19, 133);
            this.ctrlShowPersonCard1.Name = "ctrlShowPersonCard1";
            this.ctrlShowPersonCard1.Size = new System.Drawing.Size(867, 327);
            this.ctrlShowPersonCard1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlShowPerosnCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlShowPersonCard1);
            this.Name = "ctrlShowPerosnCardWithFilter";
            this.Size = new System.Drawing.Size(892, 460);
            this.Load += new System.EventHandler(this.ctrlShowPerosnCardWithFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowPersonCard ctrlShowPersonCard1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Bufind;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BUadd;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
