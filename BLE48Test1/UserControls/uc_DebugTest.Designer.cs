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
            this.tablePanel_Debug = new System.Windows.Forms.TableLayoutPanel();
            this.group_Head = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.group_Select = new System.Windows.Forms.GroupBox();
            this.tablePanel_BL = new System.Windows.Forms.TableLayoutPanel();
            this.cmb_NotifyFeatures = new System.Windows.Forms.ComboBox();
            this.btn_Features = new System.Windows.Forms.Button();
            this.cmb_WriteFeatures = new System.Windows.Forms.ComboBox();
            this.cmb_Server = new System.Windows.Forms.ComboBox();
            this.btn_WriteStr = new System.Windows.Forms.Button();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.btn_WriteHex = new System.Windows.Forms.Button();
            this.txt_ReadWriteInfo = new System.Windows.Forms.TextBox();
            this.btn_Read = new System.Windows.Forms.Button();
            this.txt_Read = new System.Windows.Forms.TextBox();
            this.lab_Selected = new System.Windows.Forms.Label();
            this.txt_SelectedBL = new System.Windows.Forms.TextBox();
            this.btn_Serves = new System.Windows.Forms.Button();
            this.flowPanel_CRCBtns = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_CRC16 = new System.Windows.Forms.Button();
            this.btn_CRC16HL = new System.Windows.Forms.Button();
            this.btn_Sleep = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowPanel_Conn = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_OptAndConn2 = new System.Windows.Forms.Button();
            this.btn_OptAndConn = new System.Windows.Forms.Button();
            this.btn_DisConn = new System.Windows.Forms.Button();
            this.lab_PropertieWrite = new System.Windows.Forms.Label();
            this.lab_PropertieNotify = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listboxBleDevice = new System.Windows.Forms.ListBox();
            this.tablePanel_Debug.SuspendLayout();
            this.group_Head.SuspendLayout();
            this.group_Select.SuspendLayout();
            this.tablePanel_BL.SuspendLayout();
            this.flowPanel_CRCBtns.SuspendLayout();
            this.flowPanel_Conn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel_Debug
            // 
            this.tablePanel_Debug.ColumnCount = 1;
            this.tablePanel_Debug.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel_Debug.Controls.Add(this.group_Head, 0, 0);
            this.tablePanel_Debug.Controls.Add(this.group_Select, 0, 2);
            this.tablePanel_Debug.Controls.Add(this.listboxBleDevice, 0, 1);
            this.tablePanel_Debug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel_Debug.Location = new System.Drawing.Point(0, 0);
            this.tablePanel_Debug.Name = "tablePanel_Debug";
            this.tablePanel_Debug.RowCount = 3;
            this.tablePanel_Debug.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_Debug.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel_Debug.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_Debug.Size = new System.Drawing.Size(811, 978);
            this.tablePanel_Debug.TabIndex = 28;
            // 
            // group_Head
            // 
            this.group_Head.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Head.Controls.Add(this.btnSearch);
            this.group_Head.Controls.Add(this.btnClearLog);
            this.group_Head.Location = new System.Drawing.Point(3, 3);
            this.group_Head.Name = "group_Head";
            this.group_Head.Size = new System.Drawing.Size(805, 55);
            this.group_Head.TabIndex = 26;
            this.group_Head.TabStop = false;
            this.group_Head.Text = "扫描";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(6, 18);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 30);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "扫描";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(132, 18);
            this.btnClearLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(85, 30);
            this.btnClearLog.TabIndex = 12;
            this.btnClearLog.Text = "清空Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // group_Select
            // 
            this.group_Select.Controls.Add(this.tablePanel_BL);
            this.group_Select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_Select.Location = new System.Drawing.Point(3, 545);
            this.group_Select.Name = "group_Select";
            this.group_Select.Size = new System.Drawing.Size(805, 430);
            this.group_Select.TabIndex = 25;
            this.group_Select.TabStop = false;
            this.group_Select.Text = "蓝牙选择";
            // 
            // tablePanel_BL
            // 
            this.tablePanel_BL.ColumnCount = 4;
            this.tablePanel_BL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel_BL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel_BL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel_BL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel_BL.Controls.Add(this.cmb_NotifyFeatures, 1, 4);
            this.tablePanel_BL.Controls.Add(this.btn_Features, 0, 2);
            this.tablePanel_BL.Controls.Add(this.cmb_WriteFeatures, 1, 2);
            this.tablePanel_BL.Controls.Add(this.cmb_Server, 1, 1);
            this.tablePanel_BL.Controls.Add(this.btn_WriteStr, 3, 7);
            this.tablePanel_BL.Controls.Add(this.tbCode, 1, 7);
            this.tablePanel_BL.Controls.Add(this.btn_WriteHex, 3, 8);
            this.tablePanel_BL.Controls.Add(this.txt_ReadWriteInfo, 1, 8);
            this.tablePanel_BL.Controls.Add(this.btn_Read, 3, 10);
            this.tablePanel_BL.Controls.Add(this.txt_Read, 1, 10);
            this.tablePanel_BL.Controls.Add(this.lab_Selected, 0, 0);
            this.tablePanel_BL.Controls.Add(this.txt_SelectedBL, 1, 0);
            this.tablePanel_BL.Controls.Add(this.btn_Serves, 0, 1);
            this.tablePanel_BL.Controls.Add(this.flowPanel_CRCBtns, 1, 9);
            this.tablePanel_BL.Controls.Add(this.label4, 3, 2);
            this.tablePanel_BL.Controls.Add(this.label5, 3, 4);
            this.tablePanel_BL.Controls.Add(this.label1, 0, 7);
            this.tablePanel_BL.Controls.Add(this.label2, 0, 8);
            this.tablePanel_BL.Controls.Add(this.label3, 0, 10);
            this.tablePanel_BL.Controls.Add(this.flowPanel_Conn, 1, 6);
            this.tablePanel_BL.Controls.Add(this.lab_PropertieWrite, 1, 3);
            this.tablePanel_BL.Controls.Add(this.lab_PropertieNotify, 1, 5);
            this.tablePanel_BL.Controls.Add(this.label6, 3, 3);
            this.tablePanel_BL.Controls.Add(this.label7, 3, 5);
            this.tablePanel_BL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel_BL.Location = new System.Drawing.Point(3, 21);
            this.tablePanel_BL.Margin = new System.Windows.Forms.Padding(1);
            this.tablePanel_BL.Name = "tablePanel_BL";
            this.tablePanel_BL.RowCount = 12;
            this.tablePanel_BL.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_BL.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_BL.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_BL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tablePanel_BL.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_BL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tablePanel_BL.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_BL.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_BL.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_BL.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_BL.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_BL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel_BL.Size = new System.Drawing.Size(799, 406);
            this.tablePanel_BL.TabIndex = 28;
            // 
            // cmb_NotifyFeatures
            // 
            this.tablePanel_BL.SetColumnSpan(this.cmb_NotifyFeatures, 2);
            this.cmb_NotifyFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_NotifyFeatures.FormattingEnabled = true;
            this.cmb_NotifyFeatures.Location = new System.Drawing.Point(170, 138);
            this.cmb_NotifyFeatures.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_NotifyFeatures.Name = "cmb_NotifyFeatures";
            this.cmb_NotifyFeatures.Size = new System.Drawing.Size(500, 23);
            this.cmb_NotifyFeatures.TabIndex = 25;
            this.cmb_NotifyFeatures.SelectedIndexChanged += new System.EventHandler(this.cmb_NotifyFeatures_SelectedIndexChanged);
            // 
            // btn_Features
            // 
            this.btn_Features.Enabled = false;
            this.btn_Features.Location = new System.Drawing.Point(4, 75);
            this.btn_Features.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Features.Name = "btn_Features";
            this.btn_Features.Size = new System.Drawing.Size(158, 30);
            this.btn_Features.TabIndex = 5;
            this.btn_Features.Text = "特征";
            this.btn_Features.UseVisualStyleBackColor = true;
            this.btn_Features.Click += new System.EventHandler(this.btn_Features_Click);
            // 
            // cmb_WriteFeatures
            // 
            this.cmb_WriteFeatures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tablePanel_BL.SetColumnSpan(this.cmb_WriteFeatures, 2);
            this.cmb_WriteFeatures.FormattingEnabled = true;
            this.cmb_WriteFeatures.Location = new System.Drawing.Point(170, 75);
            this.cmb_WriteFeatures.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_WriteFeatures.Name = "cmb_WriteFeatures";
            this.cmb_WriteFeatures.Size = new System.Drawing.Size(500, 23);
            this.cmb_WriteFeatures.TabIndex = 14;
            this.cmb_WriteFeatures.SelectedIndexChanged += new System.EventHandler(this.cmb_WriteFeatures_SelectedIndexChanged);
            // 
            // cmb_Server
            // 
            this.tablePanel_BL.SetColumnSpan(this.cmb_Server, 2);
            this.cmb_Server.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_Server.FormattingEnabled = true;
            this.cmb_Server.Location = new System.Drawing.Point(170, 37);
            this.cmb_Server.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Server.Name = "cmb_Server";
            this.cmb_Server.Size = new System.Drawing.Size(500, 23);
            this.cmb_Server.TabIndex = 13;
            // 
            // btn_WriteStr
            // 
            this.btn_WriteStr.Enabled = false;
            this.btn_WriteStr.Location = new System.Drawing.Point(678, 235);
            this.btn_WriteStr.Margin = new System.Windows.Forms.Padding(4);
            this.btn_WriteStr.Name = "btn_WriteStr";
            this.btn_WriteStr.Size = new System.Drawing.Size(117, 30);
            this.btn_WriteStr.TabIndex = 0;
            this.btn_WriteStr.Text = "发送字符串";
            this.btn_WriteStr.UseVisualStyleBackColor = true;
            this.btn_WriteStr.Click += new System.EventHandler(this.btn_WriteStr_Click);
            // 
            // tbCode
            // 
            this.tablePanel_BL.SetColumnSpan(this.tbCode, 2);
            this.tbCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCode.Location = new System.Drawing.Point(170, 235);
            this.tbCode.Margin = new System.Windows.Forms.Padding(4);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(500, 25);
            this.tbCode.TabIndex = 2;
            this.tbCode.Text = "Test1234";
            // 
            // btn_WriteHex
            // 
            this.btn_WriteHex.Enabled = false;
            this.btn_WriteHex.Location = new System.Drawing.Point(678, 273);
            this.btn_WriteHex.Margin = new System.Windows.Forms.Padding(4);
            this.btn_WriteHex.Name = "btn_WriteHex";
            this.btn_WriteHex.Size = new System.Drawing.Size(117, 30);
            this.btn_WriteHex.TabIndex = 8;
            this.btn_WriteHex.Text = "发送Hex";
            this.btn_WriteHex.UseVisualStyleBackColor = true;
            this.btn_WriteHex.Click += new System.EventHandler(this.btn_WriteHex_Click);
            // 
            // txt_ReadWriteInfo
            // 
            this.tablePanel_BL.SetColumnSpan(this.txt_ReadWriteInfo, 2);
            this.txt_ReadWriteInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ReadWriteInfo.Location = new System.Drawing.Point(170, 273);
            this.txt_ReadWriteInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ReadWriteInfo.Name = "txt_ReadWriteInfo";
            this.txt_ReadWriteInfo.Size = new System.Drawing.Size(500, 25);
            this.txt_ReadWriteInfo.TabIndex = 9;
            this.txt_ReadWriteInfo.Text = "01 03 00 00 00 01 84 0A ";
            // 
            // btn_Read
            // 
            this.btn_Read.Enabled = false;
            this.btn_Read.Location = new System.Drawing.Point(678, 352);
            this.btn_Read.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(117, 30);
            this.btn_Read.TabIndex = 7;
            this.btn_Read.Text = "读";
            this.btn_Read.UseVisualStyleBackColor = true;
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // txt_Read
            // 
            this.tablePanel_BL.SetColumnSpan(this.txt_Read, 2);
            this.txt_Read.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Read.Location = new System.Drawing.Point(170, 352);
            this.txt_Read.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Read.Name = "txt_Read";
            this.txt_Read.ReadOnly = true;
            this.txt_Read.Size = new System.Drawing.Size(500, 25);
            this.txt_Read.TabIndex = 19;
            // 
            // lab_Selected
            // 
            this.lab_Selected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_Selected.AutoSize = true;
            this.lab_Selected.Location = new System.Drawing.Point(4, 9);
            this.lab_Selected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_Selected.Name = "lab_Selected";
            this.lab_Selected.Size = new System.Drawing.Size(158, 15);
            this.lab_Selected.TabIndex = 22;
            this.lab_Selected.Text = "选中的蓝牙:";
            this.lab_Selected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SelectedBL
            // 
            this.tablePanel_BL.SetColumnSpan(this.txt_SelectedBL, 3);
            this.txt_SelectedBL.Location = new System.Drawing.Point(170, 4);
            this.txt_SelectedBL.Margin = new System.Windows.Forms.Padding(4);
            this.txt_SelectedBL.Name = "txt_SelectedBL";
            this.txt_SelectedBL.ReadOnly = true;
            this.txt_SelectedBL.Size = new System.Drawing.Size(625, 25);
            this.txt_SelectedBL.TabIndex = 23;
            // 
            // btn_Serves
            // 
            this.btn_Serves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Serves.Location = new System.Drawing.Point(4, 37);
            this.btn_Serves.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Serves.Name = "btn_Serves";
            this.btn_Serves.Size = new System.Drawing.Size(158, 30);
            this.btn_Serves.TabIndex = 4;
            this.btn_Serves.Text = "服务";
            this.btn_Serves.UseVisualStyleBackColor = true;
            this.btn_Serves.Click += new System.EventHandler(this.BtnServes_Click);
            // 
            // flowPanel_CRCBtns
            // 
            this.tablePanel_BL.SetColumnSpan(this.flowPanel_CRCBtns, 3);
            this.flowPanel_CRCBtns.Controls.Add(this.btn_CRC16);
            this.flowPanel_CRCBtns.Controls.Add(this.btn_CRC16HL);
            this.flowPanel_CRCBtns.Controls.Add(this.btn_Sleep);
            this.flowPanel_CRCBtns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel_CRCBtns.Location = new System.Drawing.Point(169, 310);
            this.flowPanel_CRCBtns.Name = "flowPanel_CRCBtns";
            this.flowPanel_CRCBtns.Size = new System.Drawing.Size(627, 35);
            this.flowPanel_CRCBtns.TabIndex = 28;
            // 
            // btn_CRC16
            // 
            this.btn_CRC16.Location = new System.Drawing.Point(1, 1);
            this.btn_CRC16.Margin = new System.Windows.Forms.Padding(1);
            this.btn_CRC16.Name = "btn_CRC16";
            this.btn_CRC16.Size = new System.Drawing.Size(117, 30);
            this.btn_CRC16.TabIndex = 20;
            this.btn_CRC16.Text = "ModBusCRC";
            this.btn_CRC16.UseVisualStyleBackColor = true;
            this.btn_CRC16.Click += new System.EventHandler(this.btn_CRC16_Click);
            // 
            // btn_CRC16HL
            // 
            this.btn_CRC16HL.Location = new System.Drawing.Point(120, 1);
            this.btn_CRC16HL.Margin = new System.Windows.Forms.Padding(1);
            this.btn_CRC16HL.Name = "btn_CRC16HL";
            this.btn_CRC16HL.Size = new System.Drawing.Size(117, 30);
            this.btn_CRC16HL.TabIndex = 21;
            this.btn_CRC16HL.Text = "CRC16-HL";
            this.btn_CRC16HL.UseVisualStyleBackColor = true;
            this.btn_CRC16HL.Click += new System.EventHandler(this.btn_CRC16HL_Click);
            // 
            // btn_Sleep
            // 
            this.btn_Sleep.Location = new System.Drawing.Point(239, 1);
            this.btn_Sleep.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Sleep.Name = "btn_Sleep";
            this.btn_Sleep.Size = new System.Drawing.Size(117, 30);
            this.btn_Sleep.TabIndex = 22;
            this.btn_Sleep.Text = "休眠命令";
            this.btn_Sleep.UseVisualStyleBackColor = true;
            this.btn_Sleep.Click += new System.EventHandler(this.btn_Sleep_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(678, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "写特征(1)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(678, 142);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 15);
            this.label5.TabIndex = 27;
            this.label5.Text = "Notify特征";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 242);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "字符串";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 280);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Hex";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 359);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "读回:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowPanel_Conn
            // 
            this.tablePanel_BL.SetColumnSpan(this.flowPanel_Conn, 3);
            this.flowPanel_Conn.Controls.Add(this.btn_OptAndConn2);
            this.flowPanel_Conn.Controls.Add(this.btn_OptAndConn);
            this.flowPanel_Conn.Controls.Add(this.btn_DisConn);
            this.flowPanel_Conn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel_Conn.Location = new System.Drawing.Point(169, 193);
            this.flowPanel_Conn.Name = "flowPanel_Conn";
            this.flowPanel_Conn.Size = new System.Drawing.Size(627, 35);
            this.flowPanel_Conn.TabIndex = 29;
            // 
            // btn_OptAndConn2
            // 
            this.btn_OptAndConn2.Location = new System.Drawing.Point(1, 1);
            this.btn_OptAndConn2.Margin = new System.Windows.Forms.Padding(1);
            this.btn_OptAndConn2.Name = "btn_OptAndConn2";
            this.btn_OptAndConn2.Size = new System.Drawing.Size(158, 30);
            this.btn_OptAndConn2.TabIndex = 24;
            this.btn_OptAndConn2.Text = "连接Write+Notify";
            this.btn_OptAndConn2.UseVisualStyleBackColor = true;
            this.btn_OptAndConn2.Click += new System.EventHandler(this.btn_OptAndConn2_Click);
            // 
            // btn_OptAndConn
            // 
            this.btn_OptAndConn.Enabled = false;
            this.btn_OptAndConn.Location = new System.Drawing.Point(161, 1);
            this.btn_OptAndConn.Margin = new System.Windows.Forms.Padding(1);
            this.btn_OptAndConn.Name = "btn_OptAndConn";
            this.btn_OptAndConn.Size = new System.Drawing.Size(140, 30);
            this.btn_OptAndConn.TabIndex = 6;
            this.btn_OptAndConn.Text = "连接";
            this.btn_OptAndConn.UseVisualStyleBackColor = true;
            this.btn_OptAndConn.Click += new System.EventHandler(this.btn_OptAndConn_Click);
            // 
            // btn_DisConn
            // 
            this.btn_DisConn.Location = new System.Drawing.Point(303, 1);
            this.btn_DisConn.Margin = new System.Windows.Forms.Padding(1);
            this.btn_DisConn.Name = "btn_DisConn";
            this.btn_DisConn.Size = new System.Drawing.Size(117, 30);
            this.btn_DisConn.TabIndex = 16;
            this.btn_DisConn.Text = "断开";
            this.btn_DisConn.UseVisualStyleBackColor = true;
            this.btn_DisConn.Click += new System.EventHandler(this.btn_DisConnect_Click);
            // 
            // lab_PropertieWrite
            // 
            this.lab_PropertieWrite.AutoSize = true;
            this.lab_PropertieWrite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tablePanel_BL.SetColumnSpan(this.lab_PropertieWrite, 2);
            this.lab_PropertieWrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_PropertieWrite.Location = new System.Drawing.Point(169, 109);
            this.lab_PropertieWrite.Name = "lab_PropertieWrite";
            this.lab_PropertieWrite.Size = new System.Drawing.Size(502, 25);
            this.lab_PropertieWrite.TabIndex = 30;
            this.lab_PropertieWrite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_PropertieNotify
            // 
            this.lab_PropertieNotify.AutoSize = true;
            this.lab_PropertieNotify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tablePanel_BL.SetColumnSpan(this.lab_PropertieNotify, 2);
            this.lab_PropertieNotify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_PropertieNotify.Location = new System.Drawing.Point(169, 165);
            this.lab_PropertieNotify.Name = "lab_PropertieNotify";
            this.lab_PropertieNotify.Size = new System.Drawing.Size(502, 25);
            this.lab_PropertieNotify.TabIndex = 31;
            this.lab_PropertieNotify.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(678, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "属性";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(678, 170);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "属性";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listboxBleDevice
            // 
            this.listboxBleDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listboxBleDevice.FormattingEnabled = true;
            this.listboxBleDevice.ItemHeight = 15;
            this.listboxBleDevice.Location = new System.Drawing.Point(4, 65);
            this.listboxBleDevice.Margin = new System.Windows.Forms.Padding(4);
            this.listboxBleDevice.Name = "listboxBleDevice";
            this.listboxBleDevice.Size = new System.Drawing.Size(803, 473);
            this.listboxBleDevice.TabIndex = 10;
            this.listboxBleDevice.SelectedIndexChanged += new System.EventHandler(this.listboxBleDevice_SelectedIndexChanged);
            // 
            // uc_DebugTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel_Debug);
            this.Name = "uc_DebugTest";
            this.Size = new System.Drawing.Size(811, 978);
            this.tablePanel_Debug.ResumeLayout(false);
            this.group_Head.ResumeLayout(false);
            this.group_Select.ResumeLayout(false);
            this.tablePanel_BL.ResumeLayout(false);
            this.tablePanel_BL.PerformLayout();
            this.flowPanel_CRCBtns.ResumeLayout(false);
            this.flowPanel_Conn.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}
