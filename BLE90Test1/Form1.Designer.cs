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
            btnWriteStr = new Button();
            tbCode = new TextBox();
            label1 = new Label();
            btnServes = new Button();
            btnFeatures = new Button();
            btn_OptAndConn = new Button();
            btnRead = new Button();
            btnWriteHex = new Button();
            tbReadWriteInfo = new TextBox();
            listboxBleDevice = new ListBox();
            btnSearch = new Button();
            btnClearLog = new Button();
            cmbServer = new ComboBox();
            cmbFeatures = new ComboBox();
            listboxMessage = new ListBox();
            btn_DisConn = new Button();
            label2 = new Label();
            label3 = new Label();
            txt_Read = new TextBox();
            sp1 = new SplitContainer();
            btn_CLoseBL = new Button();
            txt_SelectedBL = new TextBox();
            lab_Selected = new Label();
            btn_CRC16HL = new Button();
            btn_CRC16 = new Button();
            btn_OpenBL = new Button();
            ((System.ComponentModel.ISupportInitialize)sp1).BeginInit();
            sp1.Panel1.SuspendLayout();
            sp1.Panel2.SuspendLayout();
            sp1.SuspendLayout();
            SuspendLayout();
            // 
            // btnWriteStr
            // 
            btnWriteStr.Enabled = false;
            btnWriteStr.Location = new Point(447, 732);
            btnWriteStr.Margin = new Padding(4, 5, 4, 5);
            btnWriteStr.Name = "btnWriteStr";
            btnWriteStr.Size = new Size(132, 40);
            btnWriteStr.TabIndex = 0;
            btnWriteStr.Text = "写字符串";
            btnWriteStr.UseVisualStyleBackColor = true;
            btnWriteStr.Click += btnWriteStr_Click;
            // 
            // tbCode
            // 
            tbCode.Location = new Point(104, 732);
            tbCode.Margin = new Padding(4, 5, 4, 5);
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(332, 27);
            tbCode.TabIndex = 2;
            tbCode.Text = "Test1234";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 747);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 3;
            label1.Text = "字符串";
            // 
            // btnServes
            // 
            btnServes.Location = new Point(18, 562);
            btnServes.Margin = new Padding(4, 5, 4, 5);
            btnServes.Name = "btnServes";
            btnServes.Size = new Size(132, 40);
            btnServes.TabIndex = 4;
            btnServes.Text = "服务";
            btnServes.UseVisualStyleBackColor = true;
            btnServes.Click += BtnServes_Click;
            // 
            // btnFeatures
            // 
            btnFeatures.Enabled = false;
            btnFeatures.Location = new Point(18, 612);
            btnFeatures.Margin = new Padding(4, 5, 4, 5);
            btnFeatures.Name = "btnFeatures";
            btnFeatures.Size = new Size(132, 40);
            btnFeatures.TabIndex = 5;
            btnFeatures.Text = "特征";
            btnFeatures.UseVisualStyleBackColor = true;
            btnFeatures.Click += BtnFeatures_Click;
            // 
            // btn_OptAndConn
            // 
            btn_OptAndConn.Enabled = false;
            btn_OptAndConn.Location = new Point(18, 662);
            btn_OptAndConn.Margin = new Padding(4, 5, 4, 5);
            btn_OptAndConn.Name = "btn_OptAndConn";
            btn_OptAndConn.Size = new Size(132, 40);
            btn_OptAndConn.TabIndex = 6;
            btn_OptAndConn.Text = "连接";
            btn_OptAndConn.UseVisualStyleBackColor = true;
            btn_OptAndConn.Click += btn_OptAndConn_Click;
            // 
            // btnRead
            // 
            btnRead.Enabled = false;
            btnRead.Location = new Point(447, 882);
            btnRead.Margin = new Padding(4, 5, 4, 5);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(132, 40);
            btnRead.TabIndex = 7;
            btnRead.Text = "读";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += BtnRead_Click;
            // 
            // btnWriteHex
            // 
            btnWriteHex.Enabled = false;
            btnWriteHex.Location = new Point(447, 782);
            btnWriteHex.Margin = new Padding(4, 5, 4, 5);
            btnWriteHex.Name = "btnWriteHex";
            btnWriteHex.Size = new Size(132, 40);
            btnWriteHex.TabIndex = 8;
            btnWriteHex.Text = "写Hex";
            btnWriteHex.UseVisualStyleBackColor = true;
            btnWriteHex.Click += BtnWriteHex_Click;
            // 
            // tbReadWriteInfo
            // 
            tbReadWriteInfo.Location = new Point(104, 777);
            tbReadWriteInfo.Margin = new Padding(4, 5, 4, 5);
            tbReadWriteInfo.Name = "tbReadWriteInfo";
            tbReadWriteInfo.Size = new Size(332, 27);
            tbReadWriteInfo.TabIndex = 9;
            tbReadWriteInfo.Text = "01 03 00 00 00 01 0A 84";
            // 
            // listboxBleDevice
            // 
            listboxBleDevice.FormattingEnabled = true;
            listboxBleDevice.Location = new Point(26, 68);
            listboxBleDevice.Margin = new Padding(4, 5, 4, 5);
            listboxBleDevice.Name = "listboxBleDevice";
            listboxBleDevice.Size = new Size(412, 424);
            listboxBleDevice.TabIndex = 10;
            listboxBleDevice.SelectedIndexChanged += listboxBleDevice_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(26, 18);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(132, 40);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "扫描";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClearLog
            // 
            btnClearLog.Location = new Point(543, 18);
            btnClearLog.Margin = new Padding(4, 5, 4, 5);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(96, 40);
            btnClearLog.TabIndex = 12;
            btnClearLog.Text = "清空Log";
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // cmbServer
            // 
            cmbServer.FormattingEnabled = true;
            cmbServer.Location = new Point(159, 562);
            cmbServer.Margin = new Padding(4, 5, 4, 5);
            cmbServer.Name = "cmbServer";
            cmbServer.Size = new Size(474, 28);
            cmbServer.TabIndex = 13;
            // 
            // cmbFeatures
            // 
            cmbFeatures.FormattingEnabled = true;
            cmbFeatures.Location = new Point(159, 610);
            cmbFeatures.Margin = new Padding(4, 5, 4, 5);
            cmbFeatures.Name = "cmbFeatures";
            cmbFeatures.Size = new Size(474, 28);
            cmbFeatures.TabIndex = 14;
            // 
            // listboxMessage
            // 
            listboxMessage.Dock = DockStyle.Fill;
            listboxMessage.FormattingEnabled = true;
            listboxMessage.Location = new Point(0, 0);
            listboxMessage.Margin = new Padding(4, 5, 4, 5);
            listboxMessage.Name = "listboxMessage";
            listboxMessage.Size = new Size(1232, 1067);
            listboxMessage.TabIndex = 15;
            // 
            // btn_DisConn
            // 
            btn_DisConn.Location = new Point(166, 662);
            btn_DisConn.Margin = new Padding(4, 5, 4, 5);
            btn_DisConn.Name = "btn_DisConn";
            btn_DisConn.Size = new Size(132, 40);
            btn_DisConn.TabIndex = 16;
            btn_DisConn.Text = "断开";
            btn_DisConn.UseVisualStyleBackColor = true;
            btn_DisConn.Click += btn_DisConnect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 792);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 17;
            label2.Text = "Hex";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 892);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 20);
            label3.TabIndex = 18;
            label3.Text = "读回:";
            // 
            // txt_Read
            // 
            txt_Read.Location = new Point(104, 887);
            txt_Read.Margin = new Padding(4, 5, 4, 5);
            txt_Read.Name = "txt_Read";
            txt_Read.ReadOnly = true;
            txt_Read.Size = new Size(332, 27);
            txt_Read.TabIndex = 19;
            // 
            // sp1
            // 
            sp1.Dock = DockStyle.Fill;
            sp1.FixedPanel = FixedPanel.Panel1;
            sp1.IsSplitterFixed = true;
            sp1.Location = new Point(0, 0);
            sp1.Margin = new Padding(4, 5, 4, 5);
            sp1.Name = "sp1";
            // 
            // sp1.Panel1
            // 
            sp1.Panel1.Controls.Add(btn_OpenBL);
            sp1.Panel1.Controls.Add(btn_CLoseBL);
            sp1.Panel1.Controls.Add(txt_SelectedBL);
            sp1.Panel1.Controls.Add(lab_Selected);
            sp1.Panel1.Controls.Add(btn_CRC16HL);
            sp1.Panel1.Controls.Add(btn_CRC16);
            sp1.Panel1.Controls.Add(btnSearch);
            sp1.Panel1.Controls.Add(txt_Read);
            sp1.Panel1.Controls.Add(btnWriteStr);
            sp1.Panel1.Controls.Add(label3);
            sp1.Panel1.Controls.Add(tbCode);
            sp1.Panel1.Controls.Add(label2);
            sp1.Panel1.Controls.Add(label1);
            sp1.Panel1.Controls.Add(btn_DisConn);
            sp1.Panel1.Controls.Add(btnServes);
            sp1.Panel1.Controls.Add(cmbFeatures);
            sp1.Panel1.Controls.Add(btnFeatures);
            sp1.Panel1.Controls.Add(cmbServer);
            sp1.Panel1.Controls.Add(btn_OptAndConn);
            sp1.Panel1.Controls.Add(btnClearLog);
            sp1.Panel1.Controls.Add(btnRead);
            sp1.Panel1.Controls.Add(btnWriteHex);
            sp1.Panel1.Controls.Add(listboxBleDevice);
            sp1.Panel1.Controls.Add(tbReadWriteInfo);
            // 
            // sp1.Panel2
            // 
            sp1.Panel2.Controls.Add(listboxMessage);
            sp1.Size = new Size(1884, 1067);
            sp1.SplitterDistance = 646;
            sp1.SplitterWidth = 6;
            sp1.TabIndex = 20;
            // 
            // btn_CLoseBL
            // 
            btn_CLoseBL.Location = new Point(506, 68);
            btn_CLoseBL.Name = "btn_CLoseBL";
            btn_CLoseBL.Size = new Size(127, 43);
            btn_CLoseBL.TabIndex = 24;
            btn_CLoseBL.Text = "关闭蓝牙";
            btn_CLoseBL.UseVisualStyleBackColor = true;
            btn_CLoseBL.Click += btn_CLoseBL_Click;
            // 
            // txt_SelectedBL
            // 
            txt_SelectedBL.Location = new Point(156, 517);
            txt_SelectedBL.Margin = new Padding(4, 5, 4, 5);
            txt_SelectedBL.Name = "txt_SelectedBL";
            txt_SelectedBL.ReadOnly = true;
            txt_SelectedBL.Size = new Size(476, 27);
            txt_SelectedBL.TabIndex = 23;
            // 
            // lab_Selected
            // 
            lab_Selected.AutoSize = true;
            lab_Selected.Location = new Point(28, 518);
            lab_Selected.Margin = new Padding(4, 0, 4, 0);
            lab_Selected.Name = "lab_Selected";
            lab_Selected.Size = new Size(88, 20);
            lab_Selected.TabIndex = 22;
            lab_Selected.Text = "选中的蓝牙:";
            // 
            // btn_CRC16HL
            // 
            btn_CRC16HL.Location = new Point(244, 822);
            btn_CRC16HL.Margin = new Padding(4, 5, 4, 5);
            btn_CRC16HL.Name = "btn_CRC16HL";
            btn_CRC16HL.Size = new Size(132, 40);
            btn_CRC16HL.TabIndex = 21;
            btn_CRC16HL.Text = "CRC16-HL";
            btn_CRC16HL.UseVisualStyleBackColor = true;
            btn_CRC16HL.Click += btn_CRC16HL_Click;
            // 
            // btn_CRC16
            // 
            btn_CRC16.Location = new Point(104, 822);
            btn_CRC16.Margin = new Padding(4, 5, 4, 5);
            btn_CRC16.Name = "btn_CRC16";
            btn_CRC16.Size = new Size(132, 40);
            btn_CRC16.TabIndex = 20;
            btn_CRC16.Text = "ModBusCRC";
            btn_CRC16.UseVisualStyleBackColor = true;
            btn_CRC16.Click += btn_CRC16_Click;
            // 
            // btn_OpenBL
            // 
            btn_OpenBL.Location = new Point(505, 117);
            btn_OpenBL.Name = "btn_OpenBL";
            btn_OpenBL.Size = new Size(127, 43);
            btn_OpenBL.TabIndex = 26;
            btn_OpenBL.Text = "打开蓝牙";
            btn_OpenBL.UseVisualStyleBackColor = true;
            btn_OpenBL.Click += btn_OpenBL_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1884, 1067);
            Controls.Add(sp1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "ESP32-PICO-D4 BLE蓝牙测试V1.0.0";
            sp1.Panel1.ResumeLayout(false);
            sp1.Panel1.PerformLayout();
            sp1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sp1).EndInit();
            sp1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWriteStr;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnServes;
        private System.Windows.Forms.Button btnFeatures;
        private System.Windows.Forms.Button btn_OptAndConn;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnWriteHex;
        private System.Windows.Forms.TextBox tbReadWriteInfo;
        private System.Windows.Forms.ListBox listboxBleDevice;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.ComboBox cmbFeatures;
        private System.Windows.Forms.ListBox listboxMessage;
        private System.Windows.Forms.Button btn_DisConn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Read;
        private System.Windows.Forms.SplitContainer sp1;
        private System.Windows.Forms.Button btn_CRC16;
        private System.Windows.Forms.Button btn_CRC16HL;
        private System.Windows.Forms.TextBox txt_SelectedBL;
        private System.Windows.Forms.Label lab_Selected;
        private Button btn_CLoseBL;
        private Button btn_OpenBL;
    }
}

