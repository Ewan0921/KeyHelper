using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Threading.Thread;

namespace KeyHelper
{
    public partial class Form1 : Form
    {
        KeyboardHook k_hook;
        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;

            k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//监听按键事件 
            k_hook.Start();//安装键盘钩子

            //设置开机自启
            //BootUp();

        }



        /// <summary>
        /// 开机自启
        /// </summary>
        private void BootUp()
        {
            RegistryKey r_local = Registry.LocalMachine;//registrykey r_local = registry.currentuser;
            RegistryKey r_run = r_local.CreateSubKey(@"software\microsoft\windows\currentversion\run");
            r_run.SetValue("KeyHelper", Application.ExecutablePath);
            r_run.Close();
            r_local.Close();
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            //组合按键
            //if (e.KeyValue == (int)Keys.Q && (int)Control.ModifierKeys == (int)Keys.Control)
            //{
            //    try
            //    {
            //        keybd_event((byte)Keys.LControlKey, 0, 0, 0);
            //        keybd_event((byte)Keys.LWin, 0, 0, 0);
            //        keybd_event((byte)Keys.Right, 0, 0, 0);

            //        keybd_event((byte)Keys.LControlKey, 0,2, 0);
            //        keybd_event((byte)Keys.LWin, 0, 2, 0);
            //        keybd_event((byte)Keys.Right, 0, 2, 0);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}


            //多桌面切换
            //if (e.KeyValue == (int)Keys.F2)
            //{
            //    try
            //    {
            //        keybd_event((byte)Keys.LControlKey, 0, 0, 0);
            //        keybd_event((byte)Keys.LWin, 0, 0, 0);
            //        keybd_event((byte)Keys.Left, 0, 0, 0);

            //        keybd_event((byte)Keys.LControlKey, 0, 2, 0);
            //        keybd_event((byte)Keys.LWin, 0, 2, 0);
            //        keybd_event((byte)Keys.Left, 0, 2, 0);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}


            //当前页隐藏
            if (e.KeyValue == (int)Keys.F2)
            {
                try
                {
                    Process[] runningProcs = Process.GetProcesses();

                    foreach (var item in runningProcs)
                    {
                        if (ConfigHelper.GetProcesses().Any(x => item.ProcessName.ToUpper().Contains(x.ToUpper())))
                        {
                            item.Kill();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }



        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags">0按下  2抬起</param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);


        [DllImport("user32")]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);



        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int msg, uint wParam, uint lParam);

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT
    {
        [FieldOffset(0)]
        public int type;

        [FieldOffset(4)]
        public KEYBDINPUT ki;

        [FieldOffset(4)]
        public MOUSEINPUT mi;

        [FieldOffset(4)]
        public HARDWAREINPUT hi;
    }

    public struct MOUSEINPUT
    {
        public int dx;

        public int dy;

        public int mouseData;

        public int dwFlags;

        public int time;

        public IntPtr dwExtraInfo;
    }

    public struct KEYBDINPUT
    {
        public short wVk;

        public short wScan;

        public int dwFlags;

        public int time;

        public IntPtr dwExtraInfo;
    }

    public struct HARDWAREINPUT
    {
        public int uMsg;

        public short wParamL;

        public short wParamH;
    }

}

