namespace BLETest1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.sp1 = new System.Windows.Forms.SplitContainer();
            this.tab_Root = new System.Windows.Forms.TabControl();
            this.tabPage_LoopRead = new System.Windows.Forms.TabPage();
            this.uc_ConnDisConnTest1 = new BLETest1.UserControls.uc_ConnDisConnTest();
            this.tabPage_SleepWakeup = new System.Windows.Forms.TabPage();
            this.uc_SleepLoopTest1 = new BLETest1.UserControls.uc_SleepLoopTest();
            this.tabPage_Debug = new System.Windows.Forms.TabPage();
            this.uc_DebugTest1 = new BLETest1.UserControls.uc_DebugTest();
            this.listboxMessage = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.sp1)).BeginInit();
            this.sp1.Panel1.SuspendLayout();
            this.sp1.Panel2.SuspendLayout();
            this.sp1.SuspendLayout();
            this.tab_Root.SuspendLayout();
            this.tabPage_LoopRead.SuspendLayout();
            this.tabPage_SleepWakeup.SuspendLayout();
            this.tabPage_Debug.SuspendLayout();
            this.SuspendLayout();
            // 
            // sp1
            // 
            this.sp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sp1.Location = new System.Drawing.Point(0, 0);
            this.sp1.Margin = new System.Windows.Forms.Padding(4);
            this.sp1.Name = "sp1";
            // 
            // sp1.Panel1
            // 
            this.sp1.Panel1.Controls.Add(this.tab_Root);
            // 
            // sp1.Panel2
            // 
            this.sp1.Panel2.Controls.Add(this.listboxMessage);
            this.sp1.Size = new System.Drawing.Size(1283, 771);
            this.sp1.SplitterDistance = 589;
            this.sp1.SplitterWidth = 5;
            this.sp1.TabIndex = 20;
            // 
            // tab_Root
            // 
            this.tab_Root.Controls.Add(this.tabPage_LoopRead);
            this.tab_Root.Controls.Add(this.tabPage_SleepWakeup);
            this.tab_Root.Controls.Add(this.tabPage_Debug);
            this.tab_Root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Root.ItemSize = new System.Drawing.Size(100, 30);
            this.tab_Root.Location = new System.Drawing.Point(0, 0);
            this.tab_Root.Name = "tab_Root";
            this.tab_Root.SelectedIndex = 0;
            this.tab_Root.Size = new System.Drawing.Size(589, 771);
            this.tab_Root.TabIndex = 28;
            // 
            // tabPage_LoopRead
            // 
            this.tabPage_LoopRead.Controls.Add(this.uc_ConnDisConnTest1);
            this.tabPage_LoopRead.Location = new System.Drawing.Point(4, 34);
            this.tabPage_LoopRead.Name = "tabPage_LoopRead";
            this.tabPage_LoopRead.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_LoopRead.Size = new System.Drawing.Size(581, 733);
            this.tabPage_LoopRead.TabIndex = 1;
            this.tabPage_LoopRead.Text = "循环读测试";
            this.tabPage_LoopRead.UseVisualStyleBackColor = true;
            // 
            // uc_ConnDisConnTest1
            // 
            this.uc_ConnDisConnTest1.AutoSize = true;
            this.uc_ConnDisConnTest1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_ConnDisConnTest1.Location = new System.Drawing.Point(3, 3);
            this.uc_ConnDisConnTest1.Name = "uc_ConnDisConnTest1";
            this.uc_ConnDisConnTest1.Size = new System.Drawing.Size(575, 727);
            this.uc_ConnDisConnTest1.TabIndex = 0;
            // 
            // tabPage_SleepWakeup
            // 
            this.tabPage_SleepWakeup.Controls.Add(this.uc_SleepLoopTest1);
            this.tabPage_SleepWakeup.Location = new System.Drawing.Point(4, 25);
            this.tabPage_SleepWakeup.Name = "tabPage_SleepWakeup";
            this.tabPage_SleepWakeup.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SleepWakeup.Size = new System.Drawing.Size(192, 71);
            this.tabPage_SleepWakeup.TabIndex = 2;
            this.tabPage_SleepWakeup.Text = "循环休眠唤醒测试";
            this.tabPage_SleepWakeup.UseVisualStyleBackColor = true;
            // 
            // uc_SleepLoopTest1
            // 
            this.uc_SleepLoopTest1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_SleepLoopTest1.Location = new System.Drawing.Point(3, 3);
            this.uc_SleepLoopTest1.Name = "uc_SleepLoopTest1";
            this.uc_SleepLoopTest1.Size = new System.Drawing.Size(186, 65);
            this.uc_SleepLoopTest1.TabIndex = 0;
            // 
            // tabPage_Debug
            // 
            this.tabPage_Debug.Controls.Add(this.uc_DebugTest1);
            this.tabPage_Debug.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Debug.Name = "tabPage_Debug";
            this.tabPage_Debug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Debug.Size = new System.Drawing.Size(192, 71);
            this.tabPage_Debug.TabIndex = 0;
            this.tabPage_Debug.Text = "调试";
            this.tabPage_Debug.UseVisualStyleBackColor = true;
            // 
            // uc_DebugTest1
            // 
            this.uc_DebugTest1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_DebugTest1.Location = new System.Drawing.Point(3, 3);
            this.uc_DebugTest1.Name = "uc_DebugTest1";
            this.uc_DebugTest1.Size = new System.Drawing.Size(186, 65);
            this.uc_DebugTest1.TabIndex = 0;
            // 
            // listboxMessage
            // 
            this.listboxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listboxMessage.FormattingEnabled = true;
            this.listboxMessage.ItemHeight = 17;
            this.listboxMessage.Items.AddRange(new object[] {
            "右键菜单可复制MAC"});
            this.listboxMessage.Location = new System.Drawing.Point(0, 0);
            this.listboxMessage.Margin = new System.Windows.Forms.Padding(4);
            this.listboxMessage.Name = "listboxMessage";
            this.listboxMessage.Size = new System.Drawing.Size(689, 771);
            this.listboxMessage.TabIndex = 15;
            this.listboxMessage.DoubleClick += new System.EventHandler(this.listboxMessage_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1283, 771);
            this.Controls.Add(this.sp1);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "ESP32-PICO-D4 BLE蓝牙测试V1.0.2";
            this.sp1.Panel1.ResumeLayout(false);
            this.sp1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp1)).EndInit();
            this.sp1.ResumeLayout(false);
            this.tab_Root.ResumeLayout(false);
            this.tabPage_LoopRead.ResumeLayout(false);
            this.tabPage_LoopRead.PerformLayout();
            this.tabPage_SleepWakeup.ResumeLayout(false);
            this.tabPage_Debug.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listboxMessage;
        private System.Windows.Forms.SplitContainer sp1;
        private System.Windows.Forms.TabControl tab_Root;
        private System.Windows.Forms.TabPage tabPage_Debug;
        private System.Windows.Forms.TabPage tabPage_LoopRead;
        private UserControls.uc_ConnDisConnTest uc_ConnDisConnTest1;
        private UserControls.uc_DebugTest uc_DebugTest1;
        private System.Windows.Forms.TabPage tabPage_SleepWakeup;
        private UserControls.uc_SleepLoopTest uc_SleepLoopTest1;
    }
}

