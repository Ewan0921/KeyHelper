﻿namespace KeyHelper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipText = "最小化托盘";
            notifyIcon1.BalloonTipTitle = "提示";
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 302);
            Name = "Form1";
            ShowInTaskbar = false;
            Text = "fish";
            WindowState = FormWindowState.Minimized;
            Load += Form1_Load;
            SizeChanged += Form1_SizeChanged;
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon1;
    }
}