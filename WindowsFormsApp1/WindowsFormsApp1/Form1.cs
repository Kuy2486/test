using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")] // この行を追加
        private static extern bool AllocConsole();

        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MOVE = 0xF010;
        const int SC_SIZE = 0xF000;

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        extern static int SendMessageGetTextLength(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, int lParam);

        [DllImport("User32.dll")]
        public static extern bool SetCapture(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {
            InitializeComponent();
            AllocConsole();

            this.KeyPreview = true;

            this.KeyDown += Form1_KeyDown;
            this.KeyPress += Form1_KeyPress;
            this.KeyUp += Form1_KeyUp;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Form1_KeyUp");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Form1_KeyPress");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Form1_KeyDown");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            SetCapture(panel1.Handle);
            ReleaseCapture();
            SendMessage(panel1.Handle, WM_SYSCOMMAND, SC_MOVE | 2, 0);
        }

        //へんしゅうテスト
        
    }
}
