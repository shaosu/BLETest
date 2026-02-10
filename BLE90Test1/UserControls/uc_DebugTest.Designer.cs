namespace BLETest1.UserControls
{
    partial class uc_DebugTest
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            tablePanel_Debug = new TableLayoutPanel();
            group_Head = new GroupBox();
            btn_ReStartBL = new Button();
            btnSearch = new Button();
            btnClearLog = new Button();
            group_Select = new GroupBox();
            tablePanel_BL = new TableLayoutPanel();
            label16 = new Label();
            cmb_NotifyFeatures = new ComboBox();
            btn_Features = new Button();
            cmb_WriteFeatures = new ComboBox();
            cmb_Server = new ComboBox();
            btn_WriteStr = new Button();
            tbCode = new TextBox();
            btn_WriteHex = new Button();
            txt_ReadWriteInfo = new TextBox();
            btn_Read = new Button();
            txt_Read = new TextBox();
            lab_Selected = new Label();
            txt_SelectedBL = new TextBox();
            btn_Serves = new Button();
            flowPanel_CRCBtns = new FlowLayoutPanel();
            btn_CRC16 = new Button();
            btn_CRC16HL = new Button();
            btn_Sleep = new Button();
            label4 = new Label();
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            flowPanel_Conn = new FlowLayoutPanel();
            btn_OptAndConn2 = new Button();
            btn_OptAndConn = new Button();
            btn_DisConn = new Button();
            lab_PropertieWrite = new Label();
            lab_PropertieNotify = new Label();
            label6 = new Label();
            label7 = new Label();
            num_minDb = new NumericUpDown();
            label14 = new Label();
            txt_filterName = new TextBox();
            listboxBleDevice = new ListBox();
            tablePanel_Debug.SuspendLayout();
            group_Head.SuspendLayout();
            group_Select.SuspendLayout();
            tablePanel_BL.SuspendLayout();
            flowPanel_CRCBtns.SuspendLayout();
            flowPanel_Conn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_minDb).BeginInit();
            SuspendLayout();
            // 
            // tablePanel_Debug
            // 
            tablePanel_Debug.ColumnCount = 1;
            tablePanel_Debug.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tablePanel_Debug.Controls.Add(group_Head, 0, 0);
            tablePanel_Debug.Controls.Add(group_Select, 0, 2);
            tablePanel_Debug.Controls.Add(listboxBleDevice, 0, 1);
            tablePanel_Debug.Dock = DockStyle.Fill;
            tablePanel_Debug.Location = new Point(0, 0);
            tablePanel_Debug.Margin = new Padding(3, 4, 3, 4);
            tablePanel_Debug.Name = "tablePanel_Debug";
            tablePanel_Debug.RowCount = 3;
            tablePanel_Debug.RowStyles.Add(new RowStyle());
            tablePanel_Debug.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tablePanel_Debug.RowStyles.Add(new RowStyle());
            tablePanel_Debug.Size = new Size(912, 1304);
            tablePanel_Debug.TabIndex = 28;
            // 
            // group_Head
            // 
            group_Head.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            group_Head.Controls.Add(btn_ReStartBL);
            group_Head.Controls.Add(btnSearch);
            group_Head.Controls.Add(btnClearLog);
            group_Head.Location = new Point(3, 4);
            group_Head.Margin = new Padding(3, 4, 3, 4);
            group_Head.Name = "group_Head";
            group_Head.Padding = new Padding(3, 4, 3, 4);
            group_Head.Size = new Size(906, 73);
            group_Head.TabIndex = 26;
            group_Head.TabStop = false;
            group_Head.Text = "扫描";
            // 
            // btn_ReStartBL
            // 
            btn_ReStartBL.Location = new Point(269, 28);
            btn_ReStartBL.Margin = new Padding(3, 4, 3, 4);
            btn_ReStartBL.Name = "btn_ReStartBL";
            btn_ReStartBL.Size = new Size(138, 35);
            btn_ReStartBL.TabIndex = 13;
            btn_ReStartBL.Text = "重新开启蓝牙";
            btn_ReStartBL.UseVisualStyleBackColor = true;
            btn_ReStartBL.Click += btn_ReStartBL_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(7, 24);
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
            btnClearLog.Location = new Point(148, 24);
            btnClearLog.Margin = new Padding(4, 5, 4, 5);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(96, 40);
            btnClearLog.TabIndex = 12;
            btnClearLog.Text = "清空Log";
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // group_Select
            // 
            group_Select.Controls.Add(tablePanel_BL);
            group_Select.Dock = DockStyle.Fill;
            group_Select.Location = new Point(3, 727);
            group_Select.Margin = new Padding(3, 4, 3, 4);
            group_Select.Name = "group_Select";
            group_Select.Padding = new Padding(3, 4, 3, 4);
            group_Select.Size = new Size(906, 573);
            group_Select.TabIndex = 25;
            group_Select.TabStop = false;
            group_Select.Text = "蓝牙选择";
            // 
            // tablePanel_BL
            // 
            tablePanel_BL.ColumnCount = 4;
            tablePanel_BL.ColumnStyles.Add(new ColumnStyle());
            tablePanel_BL.ColumnStyles.Add(new ColumnStyle());
            tablePanel_BL.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tablePanel_BL.ColumnStyles.Add(new ColumnStyle());
            tablePanel_BL.Controls.Add(label16, 0, 0);
            tablePanel_BL.Controls.Add(cmb_NotifyFeatures, 1, 6);
            tablePanel_BL.Controls.Add(btn_Features, 0, 4);
            tablePanel_BL.Controls.Add(cmb_WriteFeatures, 1, 4);
            tablePanel_BL.Controls.Add(cmb_Server, 1, 3);
            tablePanel_BL.Controls.Add(btn_WriteStr, 3, 9);
            tablePanel_BL.Controls.Add(tbCode, 1, 9);
            tablePanel_BL.Controls.Add(btn_WriteHex, 3, 10);
            tablePanel_BL.Controls.Add(txt_ReadWriteInfo, 1, 10);
            tablePanel_BL.Controls.Add(btn_Read, 3, 12);
            tablePanel_BL.Controls.Add(txt_Read, 1, 12);
            tablePanel_BL.Controls.Add(lab_Selected, 0, 2);
            tablePanel_BL.Controls.Add(txt_SelectedBL, 1, 2);
            tablePanel_BL.Controls.Add(btn_Serves, 0, 3);
            tablePanel_BL.Controls.Add(flowPanel_CRCBtns, 1, 11);
            tablePanel_BL.Controls.Add(label4, 3, 4);
            tablePanel_BL.Controls.Add(label5, 3, 6);
            tablePanel_BL.Controls.Add(label1, 0, 9);
            tablePanel_BL.Controls.Add(label2, 0, 10);
            tablePanel_BL.Controls.Add(label3, 0, 12);
            tablePanel_BL.Controls.Add(flowPanel_Conn, 1, 8);
            tablePanel_BL.Controls.Add(lab_PropertieWrite, 1, 5);
            tablePanel_BL.Controls.Add(lab_PropertieNotify, 1, 7);
            tablePanel_BL.Controls.Add(label6, 3, 5);
            tablePanel_BL.Controls.Add(label7, 3, 7);
            tablePanel_BL.Controls.Add(num_minDb, 1, 0);
            tablePanel_BL.Controls.Add(label14, 0, 1);
            tablePanel_BL.Controls.Add(txt_filterName, 1, 1);
            tablePanel_BL.Dock = DockStyle.Fill;
            tablePanel_BL.Location = new Point(3, 24);
            tablePanel_BL.Margin = new Padding(1);
            tablePanel_BL.Name = "tablePanel_BL";
            tablePanel_BL.RowCount = 14;
            tablePanel_BL.RowStyles.Add(new RowStyle());
            tablePanel_BL.RowStyles.Add(new RowStyle());
            tablePanel_BL.RowStyles.Add(new RowStyle());
            tablePanel_BL.RowStyles.Add(new RowStyle());
            tablePanel_BL.RowStyles.Add(new RowStyle());
            tablePanel_BL.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tablePanel_BL.RowStyles.Add(new RowStyle());
            tablePanel_BL.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tablePanel_BL.RowStyles.Add(new RowStyle());
            tablePanel_BL.RowStyles.Add(new RowStyle());
            tablePanel_BL.RowStyles.Add(new RowStyle());
            tablePanel_BL.RowStyles.Add(new RowStyle());
            tablePanel_BL.RowStyles.Add(new RowStyle());
            tablePanel_BL.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tablePanel_BL.Size = new Size(900, 545);
            tablePanel_BL.TabIndex = 28;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Location = new Point(81, 7);
            label16.Name = "label16";
            label16.Size = new Size(102, 20);
            label16.TabIndex = 22;
            label16.Text = "信号过滤(dB):";
            label16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmb_NotifyFeatures
            // 
            tablePanel_BL.SetColumnSpan(cmb_NotifyFeatures, 2);
            cmb_NotifyFeatures.DisplayMember = "Uuid";
            cmb_NotifyFeatures.Dock = DockStyle.Fill;
            cmb_NotifyFeatures.FormattingEnabled = true;
            cmb_NotifyFeatures.Location = new Point(190, 245);
            cmb_NotifyFeatures.Margin = new Padding(4, 5, 4, 5);
            cmb_NotifyFeatures.Name = "cmb_NotifyFeatures";
            cmb_NotifyFeatures.Size = new Size(566, 28);
            cmb_NotifyFeatures.TabIndex = 25;
            cmb_NotifyFeatures.SelectedIndexChanged += cmb_NotifyFeatures_SelectedIndexChanged;
            // 
            // btn_Features
            // 
            btn_Features.Enabled = false;
            btn_Features.Location = new Point(4, 162);
            btn_Features.Margin = new Padding(4, 5, 4, 5);
            btn_Features.Name = "btn_Features";
            btn_Features.Size = new Size(178, 40);
            btn_Features.TabIndex = 5;
            btn_Features.Text = "特征";
            btn_Features.UseVisualStyleBackColor = true;
            btn_Features.Click += btn_Features_Click;
            // 
            // cmb_WriteFeatures
            // 
            cmb_WriteFeatures.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tablePanel_BL.SetColumnSpan(cmb_WriteFeatures, 2);
            cmb_WriteFeatures.DisplayMember = "Uuid";
            cmb_WriteFeatures.FormattingEnabled = true;
            cmb_WriteFeatures.Location = new Point(190, 162);
            cmb_WriteFeatures.Margin = new Padding(4, 5, 4, 5);
            cmb_WriteFeatures.Name = "cmb_WriteFeatures";
            cmb_WriteFeatures.Size = new Size(562, 28);
            cmb_WriteFeatures.TabIndex = 14;
            cmb_WriteFeatures.SelectedIndexChanged += cmb_WriteFeatures_SelectedIndexChanged;
            // 
            // cmb_Server
            // 
            tablePanel_BL.SetColumnSpan(cmb_Server, 2);
            cmb_Server.Dock = DockStyle.Fill;
            cmb_Server.FormattingEnabled = true;
            cmb_Server.Location = new Point(190, 112);
            cmb_Server.Margin = new Padding(4, 5, 4, 5);
            cmb_Server.Name = "cmb_Server";
            cmb_Server.Size = new Size(566, 28);
            cmb_Server.TabIndex = 13;
            // 
            // btn_WriteStr
            // 
            btn_WriteStr.Enabled = false;
            btn_WriteStr.Location = new Point(764, 371);
            btn_WriteStr.Margin = new Padding(4, 5, 4, 5);
            btn_WriteStr.Name = "btn_WriteStr";
            btn_WriteStr.Size = new Size(132, 40);
            btn_WriteStr.TabIndex = 0;
            btn_WriteStr.Text = "发送字符串";
            btn_WriteStr.UseVisualStyleBackColor = true;
            btn_WriteStr.Click += btn_WriteStr_Click;
            // 
            // tbCode
            // 
            tablePanel_BL.SetColumnSpan(tbCode, 2);
            tbCode.Dock = DockStyle.Fill;
            tbCode.Location = new Point(190, 371);
            tbCode.Margin = new Padding(4, 5, 4, 5);
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(566, 27);
            tbCode.TabIndex = 2;
            tbCode.Text = "Test1234";
            // 
            // btn_WriteHex
            // 
            btn_WriteHex.Enabled = false;
            btn_WriteHex.Location = new Point(764, 421);
            btn_WriteHex.Margin = new Padding(4, 5, 4, 5);
            btn_WriteHex.Name = "btn_WriteHex";
            btn_WriteHex.Size = new Size(132, 40);
            btn_WriteHex.TabIndex = 8;
            btn_WriteHex.Text = "发送Hex";
            btn_WriteHex.UseVisualStyleBackColor = true;
            btn_WriteHex.Click += btn_WriteHex_Click;
            // 
            // txt_ReadWriteInfo
            // 
            tablePanel_BL.SetColumnSpan(txt_ReadWriteInfo, 2);
            txt_ReadWriteInfo.Dock = DockStyle.Fill;
            txt_ReadWriteInfo.Location = new Point(190, 421);
            txt_ReadWriteInfo.Margin = new Padding(4, 5, 4, 5);
            txt_ReadWriteInfo.Name = "txt_ReadWriteInfo";
            txt_ReadWriteInfo.Size = new Size(566, 27);
            txt_ReadWriteInfo.TabIndex = 9;
            txt_ReadWriteInfo.Text = "01 03 00 00 00 01 84 0A ";
            // 
            // btn_Read
            // 
            btn_Read.Enabled = false;
            btn_Read.Location = new Point(764, 526);
            btn_Read.Margin = new Padding(4, 5, 4, 5);
            btn_Read.Name = "btn_Read";
            btn_Read.Size = new Size(132, 40);
            btn_Read.TabIndex = 7;
            btn_Read.Text = "读";
            btn_Read.UseVisualStyleBackColor = true;
            btn_Read.Click += btn_Read_Click;
            // 
            // txt_Read
            // 
            tablePanel_BL.SetColumnSpan(txt_Read, 2);
            txt_Read.Dock = DockStyle.Fill;
            txt_Read.Location = new Point(190, 526);
            txt_Read.Margin = new Padding(4, 5, 4, 5);
            txt_Read.Name = "txt_Read";
            txt_Read.ReadOnly = true;
            txt_Read.Size = new Size(566, 27);
            txt_Read.TabIndex = 19;
            // 
            // lab_Selected
            // 
            lab_Selected.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lab_Selected.AutoSize = true;
            lab_Selected.Location = new Point(4, 78);
            lab_Selected.Margin = new Padding(4, 0, 4, 0);
            lab_Selected.Name = "lab_Selected";
            lab_Selected.Size = new Size(178, 20);
            lab_Selected.TabIndex = 22;
            lab_Selected.Text = "选中的蓝牙:";
            lab_Selected.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txt_SelectedBL
            // 
            tablePanel_BL.SetColumnSpan(txt_SelectedBL, 3);
            txt_SelectedBL.Location = new Point(190, 75);
            txt_SelectedBL.Margin = new Padding(4, 5, 4, 5);
            txt_SelectedBL.Name = "txt_SelectedBL";
            txt_SelectedBL.ReadOnly = true;
            txt_SelectedBL.Size = new Size(703, 27);
            txt_SelectedBL.TabIndex = 23;
            // 
            // btn_Serves
            // 
            btn_Serves.Dock = DockStyle.Fill;
            btn_Serves.Location = new Point(4, 112);
            btn_Serves.Margin = new Padding(4, 5, 4, 5);
            btn_Serves.Name = "btn_Serves";
            btn_Serves.Size = new Size(178, 40);
            btn_Serves.TabIndex = 4;
            btn_Serves.Text = "服务";
            btn_Serves.UseVisualStyleBackColor = true;
            btn_Serves.Click += BtnServes_Click;
            // 
            // flowPanel_CRCBtns
            // 
            tablePanel_BL.SetColumnSpan(flowPanel_CRCBtns, 3);
            flowPanel_CRCBtns.Controls.Add(btn_CRC16);
            flowPanel_CRCBtns.Controls.Add(btn_CRC16HL);
            flowPanel_CRCBtns.Controls.Add(btn_Sleep);
            flowPanel_CRCBtns.Dock = DockStyle.Fill;
            flowPanel_CRCBtns.Location = new Point(189, 470);
            flowPanel_CRCBtns.Margin = new Padding(3, 4, 3, 4);
            flowPanel_CRCBtns.Name = "flowPanel_CRCBtns";
            flowPanel_CRCBtns.Size = new Size(708, 47);
            flowPanel_CRCBtns.TabIndex = 28;
            // 
            // btn_CRC16
            // 
            btn_CRC16.Location = new Point(1, 1);
            btn_CRC16.Margin = new Padding(1);
            btn_CRC16.Name = "btn_CRC16";
            btn_CRC16.Size = new Size(132, 40);
            btn_CRC16.TabIndex = 20;
            btn_CRC16.Text = "ModBusCRC";
            btn_CRC16.UseVisualStyleBackColor = true;
            btn_CRC16.Click += btn_CRC16_Click;
            // 
            // btn_CRC16HL
            // 
            btn_CRC16HL.Location = new Point(135, 1);
            btn_CRC16HL.Margin = new Padding(1);
            btn_CRC16HL.Name = "btn_CRC16HL";
            btn_CRC16HL.Size = new Size(132, 40);
            btn_CRC16HL.TabIndex = 21;
            btn_CRC16HL.Text = "CRC16-HL";
            btn_CRC16HL.UseVisualStyleBackColor = true;
            btn_CRC16HL.Click += btn_CRC16HL_Click;
            // 
            // btn_Sleep
            // 
            btn_Sleep.Location = new Point(269, 1);
            btn_Sleep.Margin = new Padding(1);
            btn_Sleep.Name = "btn_Sleep";
            btn_Sleep.Size = new Size(132, 40);
            btn_Sleep.TabIndex = 22;
            btn_Sleep.Text = "休眠命令";
            btn_Sleep.UseVisualStyleBackColor = true;
            btn_Sleep.Click += btn_Sleep_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(764, 172);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(132, 20);
            label4.TabIndex = 26;
            label4.Text = "写特征(1)";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(764, 249);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(132, 20);
            label5.TabIndex = 27;
            label5.Text = "Notify特征";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(4, 381);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(178, 20);
            label1.TabIndex = 3;
            label1.Text = "字符串";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(4, 431);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(178, 20);
            label2.TabIndex = 17;
            label2.Text = "Hex";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(4, 536);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(178, 20);
            label3.TabIndex = 18;
            label3.Text = "读回:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flowPanel_Conn
            // 
            tablePanel_BL.SetColumnSpan(flowPanel_Conn, 3);
            flowPanel_Conn.Controls.Add(btn_OptAndConn2);
            flowPanel_Conn.Controls.Add(btn_OptAndConn);
            flowPanel_Conn.Controls.Add(btn_DisConn);
            flowPanel_Conn.Dock = DockStyle.Fill;
            flowPanel_Conn.Location = new Point(189, 315);
            flowPanel_Conn.Margin = new Padding(3, 4, 3, 4);
            flowPanel_Conn.Name = "flowPanel_Conn";
            flowPanel_Conn.Size = new Size(708, 47);
            flowPanel_Conn.TabIndex = 29;
            // 
            // btn_OptAndConn2
            // 
            btn_OptAndConn2.Location = new Point(1, 1);
            btn_OptAndConn2.Margin = new Padding(1);
            btn_OptAndConn2.Name = "btn_OptAndConn2";
            btn_OptAndConn2.Size = new Size(178, 40);
            btn_OptAndConn2.TabIndex = 24;
            btn_OptAndConn2.Text = "连接Write+Notify";
            btn_OptAndConn2.UseVisualStyleBackColor = true;
            btn_OptAndConn2.Click += btn_OptAndConn2_Click;
            // 
            // btn_OptAndConn
            // 
            btn_OptAndConn.Enabled = false;
            btn_OptAndConn.Location = new Point(181, 1);
            btn_OptAndConn.Margin = new Padding(1);
            btn_OptAndConn.Name = "btn_OptAndConn";
            btn_OptAndConn.Size = new Size(158, 40);
            btn_OptAndConn.TabIndex = 6;
            btn_OptAndConn.Text = "连接";
            btn_OptAndConn.UseVisualStyleBackColor = true;
            btn_OptAndConn.Click += btn_OptAndConn_Click;
            // 
            // btn_DisConn
            // 
            btn_DisConn.Location = new Point(341, 1);
            btn_DisConn.Margin = new Padding(1);
            btn_DisConn.Name = "btn_DisConn";
            btn_DisConn.Size = new Size(132, 40);
            btn_DisConn.TabIndex = 16;
            btn_DisConn.Text = "断开";
            btn_DisConn.UseVisualStyleBackColor = true;
            btn_DisConn.Click += btn_DisConnect_Click;
            // 
            // lab_PropertieWrite
            // 
            lab_PropertieWrite.AutoSize = true;
            lab_PropertieWrite.BorderStyle = BorderStyle.FixedSingle;
            tablePanel_BL.SetColumnSpan(lab_PropertieWrite, 2);
            lab_PropertieWrite.Dock = DockStyle.Fill;
            lab_PropertieWrite.Location = new Point(189, 207);
            lab_PropertieWrite.Name = "lab_PropertieWrite";
            lab_PropertieWrite.Size = new Size(568, 33);
            lab_PropertieWrite.TabIndex = 30;
            lab_PropertieWrite.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lab_PropertieNotify
            // 
            lab_PropertieNotify.AutoSize = true;
            lab_PropertieNotify.BorderStyle = BorderStyle.FixedSingle;
            tablePanel_BL.SetColumnSpan(lab_PropertieNotify, 2);
            lab_PropertieNotify.Dock = DockStyle.Fill;
            lab_PropertieNotify.Location = new Point(189, 278);
            lab_PropertieNotify.Name = "lab_PropertieNotify";
            lab_PropertieNotify.Size = new Size(568, 33);
            lab_PropertieNotify.TabIndex = 31;
            lab_PropertieNotify.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(764, 213);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(132, 20);
            label6.TabIndex = 32;
            label6.Text = "属性";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(764, 284);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(132, 20);
            label7.TabIndex = 33;
            label7.Text = "属性";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // num_minDb
            // 
            num_minDb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            num_minDb.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            num_minDb.Location = new Point(189, 4);
            num_minDb.Margin = new Padding(3, 4, 3, 4);
            num_minDb.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            num_minDb.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            num_minDb.Name = "num_minDb";
            num_minDb.Size = new Size(569, 27);
            num_minDb.TabIndex = 23;
            num_minDb.Value = new decimal(new int[] { 70, 0, 0, int.MinValue });
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Location = new Point(80, 42);
            label14.Name = "label14";
            label14.Size = new Size(103, 20);
            label14.TabIndex = 34;
            label14.Text = "蓝牙过滤名称:";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txt_filterName
            // 
            txt_filterName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txt_filterName.Location = new Point(189, 39);
            txt_filterName.Margin = new Padding(3, 4, 3, 4);
            txt_filterName.Name = "txt_filterName";
            txt_filterName.Size = new Size(569, 27);
            txt_filterName.TabIndex = 35;
            txt_filterName.TextChanged += txt_filterName_TextChanged;
            // 
            // listboxBleDevice
            // 
            listboxBleDevice.Dock = DockStyle.Fill;
            listboxBleDevice.FormattingEnabled = true;
            listboxBleDevice.Location = new Point(4, 86);
            listboxBleDevice.Margin = new Padding(4, 5, 4, 5);
            listboxBleDevice.Name = "listboxBleDevice";
            listboxBleDevice.Size = new Size(904, 632);
            listboxBleDevice.TabIndex = 10;
            listboxBleDevice.SelectedIndexChanged += listboxBleDevice_SelectedIndexChanged;
            // 
            // uc_DebugTest
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tablePanel_Debug);
            Margin = new Padding(3, 4, 3, 4);
            Name = "uc_DebugTest";
            Size = new Size(912, 1304);
            tablePanel_Debug.ResumeLayout(false);
            group_Head.ResumeLayout(false);
            group_Select.ResumeLayout(false);
            tablePanel_BL.ResumeLayout(false);
            tablePanel_BL.PerformLayout();
            flowPanel_CRCBtns.ResumeLayout(false);
            flowPanel_Conn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)num_minDb).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tablePanel_Debug;
        private System.Windows.Forms.GroupBox group_Head;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.GroupBox group_Select;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_NotifyFeatures;
        private System.Windows.Forms.Button btn_DisConn;
        private System.Windows.Forms.Button btn_OptAndConn2;
        private System.Windows.Forms.TextBox txt_ReadWriteInfo;
        private System.Windows.Forms.TextBox txt_SelectedBL;
        private System.Windows.Forms.Button btn_WriteHex;
        private System.Windows.Forms.Label lab_Selected;
        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.Button btn_CRC16HL;
        private System.Windows.Forms.Button btn_OptAndConn;
        private System.Windows.Forms.Button btn_CRC16;
        private System.Windows.Forms.ComboBox cmb_Server;
        private System.Windows.Forms.Button btn_Features;
        private System.Windows.Forms.TextBox txt_Read;
        private System.Windows.Forms.ComboBox cmb_WriteFeatures;
        private System.Windows.Forms.Button btn_WriteStr;
        private System.Windows.Forms.Button btn_Serves;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listboxBleDevice;
        private System.Windows.Forms.TableLayoutPanel tablePanel_BL;
        private System.Windows.Forms.FlowLayoutPanel flowPanel_CRCBtns;
        private System.Windows.Forms.FlowLayoutPanel flowPanel_Conn;
        private System.Windows.Forms.Button btn_Sleep;
        private System.Windows.Forms.Label lab_PropertieWrite;
        private System.Windows.Forms.Label lab_PropertieNotify;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown num_minDb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_filterName;
        private System.Windows.Forms.Button btn_ReStartBL;
    }
}
