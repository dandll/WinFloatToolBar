using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFloatToolBar
{
    public partial class Form1 : Form
    {
        #region 变量
        /// <summary>
        /// 鼠标左键是否按下
        /// </summary>
        private bool mouseLeftDown = false;
        /// <summary>
        /// 鼠标移动位置变量
        /// </summary>
        Point mouseOff;
        /// <summary>
        /// 窗体是否为显示状态
        /// </summary>
        private bool formShow = true;
        /// <summary>
        /// 点击时鼠标在窗体的位置，此元素用来解决窗体左上角直接移动到鼠标位置
        /// </summary>
        Point pointMouseDown = new Point();
        #endregion 变量

        public Form1()
        {
            InitializeComponent();
        }

        #region Form event
        private void Form1_Load(object sender, EventArgs e)
        {
            //重新设置宽高，不然样式会变
            //this.Width = 180;
            this.Height = 23;

            this.AllowDrop = true;//可接受拖拽文件至窗体

            SetLocation();

            #region 绑定相关事件
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].Name.StartsWith("btn"))
                {
                    Button btnNow = this.Controls[i] as Button;
                    if (btnNow != null)
                    {
                        btnNow.MouseDown += new MouseEventHandler(Form1_MouseDown);
                        btnNow.MouseMove += new MouseEventHandler(dgMouseMove);
                        btnNow.MouseUp += new MouseEventHandler(Form1_MouseUp);
                        btnNow.MouseMove += new MouseEventHandler(Form1_MouseMove);
                    }
                }
            }
            #endregion 绑定相关事件
        }
        /// <summary>
        /// 鼠标移动事件代理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgMouseMove(object sender, EventArgs e)
        {
            setFormMove();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLeftDown = true;
                Point formPoint = this.PointToClient(Control.MousePosition);
                pointMouseDown.X = formPoint.X;
                pointMouseDown.Y = formPoint.Y;
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (isMaxScreens)
                {
                    //isMaxScreens = false;
                    //this.Width = 188;
                    //this.Height = 50;
                    //SetLocation();
                    //this.BackgroundImage = null;
                    btnShowAll_Click(null, null);
                }
            }
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            mouseLeftDown = false;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseLeftDown = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMaxScreens)
            {
                Color color = this.bmp.GetPixel(e.X, e.Y);
                lblColor.Text = color.R.ToString("X") + " " + color.G.ToString("X") + " " + color.B.ToString("X");
                pbGetColor.Location = new Point(((-e.X) * 5) + 50, ((-e.Y) * 5) + 50);
                //Graphics g = this.CreateGraphics();
                //Graphics g = panel1.CreateGraphics();
                //Graphics g = pbGetColor.CreateGraphics();
                //g.FillEllipse(Brushes.Black, panel1.Location.X + 50, panel1.Location.Y + 50, 2, 2);
                //g.DrawLine(new Pen(Color.Red, 2), new Point(0, 0), new Point(500, 500));
            }
            setFormMove();
        }
        void setFormMove()
        {
            //if (mouseLeftDown)
            if (MouseButtons.Left == Control.MouseButtons)
            {
                Point mouseSet = Control.MousePosition;
                Point formPoint = this.PointToClient(Control.MousePosition);
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置  
                Location = new Point(mouseSet.X - pointMouseDown.X, mouseSet.Y - pointMouseDown.Y);//设置窗体移动后的位置
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Icon = null;
            notifyIcon1.Dispose();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Color pixelColor = myBitmap.GetPixel(50, 50);
            //Color color = getScreen().GetPixel(e.X, e.Y);
            //lblColor.Text = color.R.ToString("X") + " " + color.G.ToString("X") + " " + color.B.ToString("X");
        }
        #endregion Form event

        #region btn event
        /// <summary>
        /// 获取一个新的guid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetGuid_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Guid.NewGuid().ToString());
        }
        /// <summary>
        /// 获取DataSet判断非空的if语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDataSetNotNull_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();
            string rText = @"if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) 
{
}";
            if (!string.IsNullOrEmpty(clipboardText))
            {
                if (checkDsName(clipboardText)) { Clipboard.SetText(rText.Replace("ds", clipboardText)); }
            }
            else
            {
                Clipboard.SetText(rText);
            }
        }
        /// <summary>
        /// 检测是不是为正确的DataSet名称
        /// </summary>
        /// <param name="dsName"></param>
        /// <returns></returns>
        bool checkDsName(string dsName)
        {
            if (string.IsNullOrEmpty(dsName)) { return false; }
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"^\w*$");
            return r.IsMatch(dsName);
        }
        /// <summary>
        /// 获取DbHelper查询语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetDbHelper_Click(object sender, EventArgs e)
        {
            string rText = @"string sqlStr = """";
string errorMsg = """";
DataSet ds = DBHelper.SqlHelper(sqlStr, Constant.DBMenZhen, ref errorMsg);
if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
{
}";
            Clipboard.SetText(rText);
        }
        #endregion btn event

        #region notifyIcon1 event
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (formShow) { this.Hide(); formShow = false; }
            else { this.Show(); formShow = true; }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (formShow) { this.Hide(); formShow = false; }
            else { this.Show(); formShow = true; }
            if (e.Button == MouseButtons.Middle) { this.Close(); Application.Exit(); }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle) { this.Close(); Application.Exit(); }
        }
        #endregion notifyIcon1 event

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (btnShowAll.Text == "↓")
            {
                isMaxScreens = false;
                btnShowAll.Text = "↑";
                this.Height = 500;
                SetLocation();
            }
            else
            {
                isMaxScreens = false;
                btnShowAll.Text = "↓";
                this.Width = 188;
                this.Height = 23;
                SetLocation();
            }
        }
        /// <summary>
        /// 设置贴靠任务栏的位置
        /// </summary>
        void SetLocation()
        {
            //这个区域不包括任务栏的
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            //这个区域包括任务栏，就是屏幕显示的物理范围
            //Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
            this.Location = new System.Drawing.Point(ScreenArea.Width - this.Width, ScreenArea.Height - this.Height); //指定窗体显示在右下角
        }
        /// <summary>
        /// 最大化
        /// </summary>
        bool isMaxScreens = false;
        Bitmap bmp = null;
        private void btnGetColor_Click(object sender, EventArgs e)
        {
            //this.TopMost = false;
            //this.TopMost = true;
            if (!isMaxScreens)
            {
                isMaxScreens = true;
                this.Width = Screen.AllScreens[0].Bounds.Size.Width;
                this.Height = Screen.AllScreens[0].Bounds.Size.Height;
                this.Location = new Point(0, 0);
                if (bmp != null)
                {
                    bmp.Dispose();
                }
                //bmp = null;
                bmp = getScreen();
                this.BackgroundImage = bmp;
                pbGetColor.Width = this.Width * 5;
                pbGetColor.Height = this.Height * 5;
                pbGetColor.SizeMode = PictureBoxSizeMode.Zoom;

                pbGetColor.Image = bmp;

                //Graphics g = this.CreateGraphics();
                ////Graphics g = panel1.CreateGraphics();
                ////Graphics g = pbGetColor.CreateGraphics();
                //g.FillEllipse(Brushes.Black, panel1.Location.X + 50, panel1.Location.Y + 50, 2, 2);
                //g.DrawLine(new Pen(Color.Red,5), new Point(0, 0), new Point(500, 500));
                //g.dr
            }
            else
            {
                isMaxScreens = false;
                this.Width = 188;
                this.Height = 50;
                SetLocation();
                this.BackgroundImage = null;
            }
        }
        /// <summary>
        /// 屏幕截图函数
        /// </summary>
        /// <returns></returns>
        public static Bitmap getScreen()
        {
            Bitmap baseImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(baseImage);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            g.Dispose();
            return baseImage;
        }
        /// <summary>
        /// 16进制转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTo16_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();
            if (!string.IsNullOrEmpty(clipboardText))
            {
                string[] ctArr = clipboardText.Split(' ');
                string rText = "";
                try
                {
                    foreach (string ctStr in ctArr)
                    {
                        rText += ((byte)int.Parse(ctStr)).ToString("X");
                    }
                    Clipboard.SetText(rText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("转换失败！" + ex.Message);
                    rText = "";
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            //如果拖进来的是文件类型
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];
                //得到拖进来的路径,取第一个文件
                string path = paths[0];
                Clipboard.SetText(path);
                //路径字符串长度不为空
                if (path.Length > 1)
                {
                    //判断是文件夹吗
                    FileInfo fil = new FileInfo(path);
                    if (fil.Attributes == FileAttributes.Directory)//文件夹
                    {
                        //鼠标图标链接
                        e.Effect = DragDropEffects.Link;
                    }
                    else//文件
                    {
                        //鼠标图标链接
                        e.Effect = DragDropEffects.Link;
                    }
                }
                else
                {
                    //鼠标图标禁止
                    e.Effect = DragDropEffects.None;
                }
            }
        }
    }
}
