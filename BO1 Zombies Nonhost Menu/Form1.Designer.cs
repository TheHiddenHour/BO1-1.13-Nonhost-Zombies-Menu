namespace BO1_Zombies_Nonhost_Menu
{
    partial class mainform
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
            this.title_photo = new System.Windows.Forms.PictureBox();
            this.connect_button = new System.Windows.Forms.Button();
            this.attach_button = new System.Windows.Forms.Button();
            this.ccapi_radiobutton = new System.Windows.Forms.RadioButton();
            this.tmapi_radiobutton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.startmenu_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.title_photo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // title_photo
            // 
            this.title_photo.Image = global::BO1_Zombies_Nonhost_Menu.Properties.Resources.title;
            this.title_photo.Location = new System.Drawing.Point(12, 12);
            this.title_photo.Name = "title_photo";
            this.title_photo.Size = new System.Drawing.Size(230, 50);
            this.title_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.title_photo.TabIndex = 0;
            this.title_photo.TabStop = false;
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(3, 26);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(224, 23);
            this.connect_button.TabIndex = 1;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // attach_button
            // 
            this.attach_button.Enabled = false;
            this.attach_button.Location = new System.Drawing.Point(3, 55);
            this.attach_button.Name = "attach_button";
            this.attach_button.Size = new System.Drawing.Size(224, 23);
            this.attach_button.TabIndex = 2;
            this.attach_button.Text = "Attach";
            this.attach_button.UseVisualStyleBackColor = true;
            this.attach_button.Click += new System.EventHandler(this.attach_button_Click);
            // 
            // ccapi_radiobutton
            // 
            this.ccapi_radiobutton.AutoSize = true;
            this.ccapi_radiobutton.Checked = true;
            this.ccapi_radiobutton.Location = new System.Drawing.Point(3, 3);
            this.ccapi_radiobutton.Name = "ccapi_radiobutton";
            this.ccapi_radiobutton.Size = new System.Drawing.Size(56, 17);
            this.ccapi_radiobutton.TabIndex = 3;
            this.ccapi_radiobutton.TabStop = true;
            this.ccapi_radiobutton.Text = "CCAPI";
            this.ccapi_radiobutton.UseVisualStyleBackColor = true;
            this.ccapi_radiobutton.CheckedChanged += new System.EventHandler(this.ccapi_radiobutton_CheckedChanged);
            // 
            // tmapi_radiobutton
            // 
            this.tmapi_radiobutton.AutoSize = true;
            this.tmapi_radiobutton.Location = new System.Drawing.Point(169, 3);
            this.tmapi_radiobutton.Name = "tmapi_radiobutton";
            this.tmapi_radiobutton.Size = new System.Drawing.Size(58, 17);
            this.tmapi_radiobutton.TabIndex = 4;
            this.tmapi_radiobutton.Text = "TMAPI";
            this.tmapi_radiobutton.UseVisualStyleBackColor = true;
            this.tmapi_radiobutton.CheckedChanged += new System.EventHandler(this.tmapi_radiobutton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ccapi_radiobutton);
            this.panel1.Controls.Add(this.attach_button);
            this.panel1.Controls.Add(this.tmapi_radiobutton);
            this.panel1.Controls.Add(this.connect_button);
            this.panel1.Location = new System.Drawing.Point(12, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 85);
            this.panel1.TabIndex = 5;
            // 
            // startmenu_button
            // 
            this.startmenu_button.Enabled = false;
            this.startmenu_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startmenu_button.Location = new System.Drawing.Point(12, 159);
            this.startmenu_button.Name = "startmenu_button";
            this.startmenu_button.Size = new System.Drawing.Size(230, 50);
            this.startmenu_button.TabIndex = 6;
            this.startmenu_button.Text = "Start Menu";
            this.startmenu_button.UseVisualStyleBackColor = true;
            this.startmenu_button.Click += new System.EventHandler(this.startmenu_button_Click);
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 221);
            this.Controls.Add(this.startmenu_button);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.title_photo);
            this.Name = "mainform";
            this.Text = "FPS Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainform_FormClosed);
            this.Load += new System.EventHandler(this.mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.title_photo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox title_photo;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Button attach_button;
        private System.Windows.Forms.RadioButton ccapi_radiobutton;
        private System.Windows.Forms.RadioButton tmapi_radiobutton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button startmenu_button;
    }
}

