﻿namespace BLETest1
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
            this.btnWriteStr = new System.Windows.Forms.Button();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnServes = new System.Windows.Forms.Button();
            this.btnFeatures = new System.Windows.Forms.Button();
            this.btn_OptAndConn = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWriteHex = new System.Windows.Forms.Button();
            this.tbReadWriteInfo = new System.Windows.Forms.TextBox();
            this.listboxBleDevice = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.cmbFeatures = new System.Windows.Forms.ComboBox();
            this.listboxMessage = new System.Windows.Forms.ListBox();
            this.btn_DisConn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Read = new System.Windows.Forms.TextBox();
            this.sp1 = new System.Windows.Forms.SplitContainer();
            this.txt_SelectedBL = new System.Windows.Forms.TextBox();
            this.lab_Selected = new System.Windows.Forms.Label();
            this.btn_CRC16HL = new System.Windows.Forms.Button();
            this.btn_CRC16 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sp1)).BeginInit();
            this.sp1.Panel1.SuspendLayout();
            this.sp1.Panel2.SuspendLayout();
            this.sp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWriteStr
            // 
            this.btnWriteStr.Enabled = false;
            this.btnWriteStr.Location = new System.Drawing.Point(298, 439);
            this.btnWriteStr.Name = "btnWriteStr";
            this.btnWriteStr.Size = new System.Drawing.Size(88, 24);
            this.btnWriteStr.TabIndex = 0;
            this.btnWriteStr.Text = "写字符串";
            this.btnWriteStr.UseVisualStyleBackColor = true;
            this.btnWriteStr.Click += new System.EventHandler(this.btnWriteStr_Click);
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(69, 439);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(223, 21);
            this.tbCode.TabIndex = 2;
            this.tbCode.Text = "Test1234";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 448);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "字符串";
            // 
            // btnServes
            // 
            this.btnServes.Location = new System.Drawing.Point(12, 337);
            this.btnServes.Name = "btnServes";
            this.btnServes.Size = new System.Drawing.Size(88, 24);
            this.btnServes.TabIndex = 4;
            this.btnServes.Text = "服务";
            this.btnServes.UseVisualStyleBackColor = true;
            this.btnServes.Click += new System.EventHandler(this.BtnServes_Click);
            // 
            // btnFeatures
            // 
            this.btnFeatures.Enabled = false;
            this.btnFeatures.Location = new System.Drawing.Point(12, 367);
            this.btnFeatures.Name = "btnFeatures";
            this.btnFeatures.Size = new System.Drawing.Size(88, 24);
            this.btnFeatures.TabIndex = 5;
            this.btnFeatures.Text = "特征";
            this.btnFeatures.UseVisualStyleBackColor = true;
            this.btnFeatures.Click += new System.EventHandler(this.BtnFeatures_Click);
            // 
            // btn_OptAndConn
            // 
            this.btn_OptAndConn.Enabled = false;
            this.btn_OptAndConn.Location = new System.Drawing.Point(12, 397);
            this.btn_OptAndConn.Name = "btn_OptAndConn";
            this.btn_OptAndConn.Size = new System.Drawing.Size(88, 24);
            this.btn_OptAndConn.TabIndex = 6;
            this.btn_OptAndConn.Text = "连接";
            this.btn_OptAndConn.UseVisualStyleBackColor = true;
            this.btn_OptAndConn.Click += new System.EventHandler(this.btn_OptAndConn_Click);
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Location = new System.Drawing.Point(298, 529);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(88, 24);
            this.btnRead.TabIndex = 7;
            this.btnRead.Text = "读";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // btnWriteHex
            // 
            this.btnWriteHex.Enabled = false;
            this.btnWriteHex.Location = new System.Drawing.Point(298, 469);
            this.btnWriteHex.Name = "btnWriteHex";
            this.btnWriteHex.Size = new System.Drawing.Size(88, 24);
            this.btnWriteHex.TabIndex = 8;
            this.btnWriteHex.Text = "写Hex";
            this.btnWriteHex.UseVisualStyleBackColor = true;
            this.btnWriteHex.Click += new System.EventHandler(this.BtnWriteHex_Click);
            // 
            // tbReadWriteInfo
            // 
            this.tbReadWriteInfo.Location = new System.Drawing.Point(69, 466);
            this.tbReadWriteInfo.Name = "tbReadWriteInfo";
            this.tbReadWriteInfo.Size = new System.Drawing.Size(223, 21);
            this.tbReadWriteInfo.TabIndex = 9;
            this.tbReadWriteInfo.Text = "01 03 00 00 00 01 0A 84";
            // 
            // listboxBleDevice
            // 
            this.listboxBleDevice.FormattingEnabled = true;
            this.listboxBleDevice.ItemHeight = 12;
            this.listboxBleDevice.Location = new System.Drawing.Point(17, 41);
            this.listboxBleDevice.Name = "listboxBleDevice";
            this.listboxBleDevice.Size = new System.Drawing.Size(276, 256);
            this.listboxBleDevice.TabIndex = 10;
            this.listboxBleDevice.SelectedIndexChanged += new System.EventHandler(this.listboxBleDevice_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(17, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 24);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "扫描";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(362, 11);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(64, 24);
            this.btnClearLog.TabIndex = 12;
            this.btnClearLog.Text = "清空Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(106, 337);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(317, 20);
            this.cmbServer.TabIndex = 13;
            // 
            // cmbFeatures
            // 
            this.cmbFeatures.FormattingEnabled = true;
            this.cmbFeatures.Location = new System.Drawing.Point(106, 366);
            this.cmbFeatures.Name = "cmbFeatures";
            this.cmbFeatures.Size = new System.Drawing.Size(317, 20);
            this.cmbFeatures.TabIndex = 14;
            // 
            // listboxMessage
            // 
            this.listboxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listboxMessage.FormattingEnabled = true;
            this.listboxMessage.ItemHeight = 12;
            this.listboxMessage.Location = new System.Drawing.Point(0, 0);
            this.listboxMessage.Name = "listboxMessage";
            this.listboxMessage.Size = new System.Drawing.Size(821, 640);
            this.listboxMessage.TabIndex = 15;
            // 
            // btn_DisConn
            // 
            this.btn_DisConn.Location = new System.Drawing.Point(111, 397);
            this.btn_DisConn.Name = "btn_DisConn";
            this.btn_DisConn.Size = new System.Drawing.Size(88, 24);
            this.btn_DisConn.TabIndex = 16;
            this.btn_DisConn.Text = "断开";
            this.btn_DisConn.UseVisualStyleBackColor = true;
            this.btn_DisConn.Click += new System.EventHandler(this.btn_DisConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 475);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "Hex";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 535);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "读回:";
            // 
            // txt_Read
            // 
            this.txt_Read.Location = new System.Drawing.Point(69, 532);
            this.txt_Read.Name = "txt_Read";
            this.txt_Read.ReadOnly = true;
            this.txt_Read.Size = new System.Drawing.Size(223, 21);
            this.txt_Read.TabIndex = 19;
            // 
            // sp1
            // 
            this.sp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sp1.IsSplitterFixed = true;
            this.sp1.Location = new System.Drawing.Point(0, 0);
            this.sp1.Name = "sp1";
            // 
            // sp1.Panel1
            // 
            this.sp1.Panel1.Controls.Add(this.txt_SelectedBL);
            this.sp1.Panel1.Controls.Add(this.lab_Selected);
            this.sp1.Panel1.Controls.Add(this.btn_CRC16HL);
            this.sp1.Panel1.Controls.Add(this.btn_CRC16);
            this.sp1.Panel1.Controls.Add(this.btnSearch);
            this.sp1.Panel1.Controls.Add(this.txt_Read);
            this.sp1.Panel1.Controls.Add(this.btnWriteStr);
            this.sp1.Panel1.Controls.Add(this.label3);
            this.sp1.Panel1.Controls.Add(this.tbCode);
            this.sp1.Panel1.Controls.Add(this.label2);
            this.sp1.Panel1.Controls.Add(this.label1);
            this.sp1.Panel1.Controls.Add(this.btn_DisConn);
            this.sp1.Panel1.Controls.Add(this.btnServes);
            this.sp1.Panel1.Controls.Add(this.cmbFeatures);
            this.sp1.Panel1.Controls.Add(this.btnFeatures);
            this.sp1.Panel1.Controls.Add(this.cmbServer);
            this.sp1.Panel1.Controls.Add(this.btn_OptAndConn);
            this.sp1.Panel1.Controls.Add(this.btnClearLog);
            this.sp1.Panel1.Controls.Add(this.btnRead);
            this.sp1.Panel1.Controls.Add(this.btnWriteHex);
            this.sp1.Panel1.Controls.Add(this.listboxBleDevice);
            this.sp1.Panel1.Controls.Add(this.tbReadWriteInfo);
            // 
            // sp1.Panel2
            // 
            this.sp1.Panel2.Controls.Add(this.listboxMessage);
            this.sp1.Size = new System.Drawing.Size(1256, 640);
            this.sp1.SplitterDistance = 431;
            this.sp1.TabIndex = 20;
            // 
            // txt_SelectedBL
            // 
            this.txt_SelectedBL.Location = new System.Drawing.Point(104, 310);
            this.txt_SelectedBL.Name = "txt_SelectedBL";
            this.txt_SelectedBL.ReadOnly = true;
            this.txt_SelectedBL.Size = new System.Drawing.Size(319, 21);
            this.txt_SelectedBL.TabIndex = 23;
            // 
            // lab_Selected
            // 
            this.lab_Selected.AutoSize = true;
            this.lab_Selected.Location = new System.Drawing.Point(19, 311);
            this.lab_Selected.Name = "lab_Selected";
            this.lab_Selected.Size = new System.Drawing.Size(71, 12);
            this.lab_Selected.TabIndex = 22;
            this.lab_Selected.Text = "选中的蓝牙:";
            // 
            // btn_CRC16HL
            // 
            this.btn_CRC16HL.Location = new System.Drawing.Point(163, 493);
            this.btn_CRC16HL.Name = "btn_CRC16HL";
            this.btn_CRC16HL.Size = new System.Drawing.Size(88, 24);
            this.btn_CRC16HL.TabIndex = 21;
            this.btn_CRC16HL.Text = "CRC16-HL";
            this.btn_CRC16HL.UseVisualStyleBackColor = true;
            this.btn_CRC16HL.Click += new System.EventHandler(this.btn_CRC16HL_Click);
            // 
            // btn_CRC16
            // 
            this.btn_CRC16.Location = new System.Drawing.Point(69, 493);
            this.btn_CRC16.Name = "btn_CRC16";
            this.btn_CRC16.Size = new System.Drawing.Size(88, 24);
            this.btn_CRC16.TabIndex = 20;
            this.btn_CRC16.Text = "ModBusCRC";
            this.btn_CRC16.UseVisualStyleBackColor = true;
            this.btn_CRC16.Click += new System.EventHandler(this.btn_CRC16_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 640);
            this.Controls.Add(this.sp1);
            this.Name = "Form1";
            this.Text = "ESP32-PICO-D4 BLE蓝牙测试V1.0.0";
            this.sp1.Panel1.ResumeLayout(false);
            this.sp1.Panel1.PerformLayout();
            this.sp1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp1)).EndInit();
            this.sp1.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}

