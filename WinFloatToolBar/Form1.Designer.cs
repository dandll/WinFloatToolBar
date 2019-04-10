namespace WinFloatToolBar
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnGetGuid = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnDataSetNotNull = new System.Windows.Forms.Button();
            this.btnGetDbHelper = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnGetColor = new System.Windows.Forms.Button();
            this.lblColor = new System.Windows.Forms.Label();
            this.pbGetColor = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTo16 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbGetColor)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetGuid
            // 
            this.btnGetGuid.Location = new System.Drawing.Point(0, 0);
            this.btnGetGuid.Name = "btnGetGuid";
            this.btnGetGuid.Size = new System.Drawing.Size(39, 23);
            this.btnGetGuid.TabIndex = 0;
            this.btnGetGuid.Text = "Guid";
            this.btnGetGuid.UseVisualStyleBackColor = true;
            this.btnGetGuid.Click += new System.EventHandler(this.btnGetGuid_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btnDataSetNotNull
            // 
            this.btnDataSetNotNull.Location = new System.Drawing.Point(40, 0);
            this.btnDataSetNotNull.Name = "btnDataSetNotNull";
            this.btnDataSetNotNull.Size = new System.Drawing.Size(68, 23);
            this.btnDataSetNotNull.TabIndex = 1;
            this.btnDataSetNotNull.Text = "DsNotNull";
            this.btnDataSetNotNull.UseVisualStyleBackColor = true;
            this.btnDataSetNotNull.Click += new System.EventHandler(this.btnDataSetNotNull_Click);
            // 
            // btnGetDbHelper
            // 
            this.btnGetDbHelper.Location = new System.Drawing.Point(108, 0);
            this.btnGetDbHelper.Name = "btnGetDbHelper";
            this.btnGetDbHelper.Size = new System.Drawing.Size(62, 23);
            this.btnGetDbHelper.TabIndex = 2;
            this.btnGetDbHelper.Text = "DbHelper";
            this.btnGetDbHelper.UseVisualStyleBackColor = true;
            this.btnGetDbHelper.Click += new System.EventHandler(this.btnGetDbHelper_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(170, 0);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(17, 23);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "↓";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnGetColor
            // 
            this.btnGetColor.Location = new System.Drawing.Point(0, 83);
            this.btnGetColor.Name = "btnGetColor";
            this.btnGetColor.Size = new System.Drawing.Size(45, 23);
            this.btnGetColor.TabIndex = 4;
            this.btnGetColor.Text = "color";
            this.btnGetColor.UseVisualStyleBackColor = true;
            this.btnGetColor.Click += new System.EventHandler(this.btnGetColor_Click);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(51, 88);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(0, 12);
            this.lblColor.TabIndex = 5;
            // 
            // pbGetColor
            // 
            this.pbGetColor.Location = new System.Drawing.Point(0, 0);
            this.pbGetColor.Name = "pbGetColor";
            this.pbGetColor.Size = new System.Drawing.Size(100, 100);
            this.pbGetColor.TabIndex = 6;
            this.pbGetColor.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pbGetColor);
            this.panel1.Location = new System.Drawing.Point(0, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(49, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 2);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnTo16
            // 
            this.btnTo16.Location = new System.Drawing.Point(0, 24);
            this.btnTo16.Name = "btnTo16";
            this.btnTo16.Size = new System.Drawing.Size(51, 23);
            this.btnTo16.TabIndex = 8;
            this.btnTo16.Text = "16进制";
            this.btnTo16.UseVisualStyleBackColor = true;
            this.btnTo16.Click += new System.EventHandler(this.btnTo16_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 330);
            this.ControlBox = false;
            this.Controls.Add(this.btnTo16);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.btnGetColor);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnGetDbHelper);
            this.Controls.Add(this.btnDataSetNotNull);
            this.Controls.Add(this.btnGetGuid);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbGetColor)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetGuid;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnDataSetNotNull;
        private System.Windows.Forms.Button btnGetDbHelper;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnGetColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.PictureBox pbGetColor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTo16;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

