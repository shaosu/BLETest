namespace BLETest1.UserControls
{
    partial class uc_ConnDisConnTest
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
            this.chk_DLLDebugLoop = new System.Windows.Forms.CheckBox();
            this.tablePanel_DLLDebugParam = new System.Windows.Forms.TableLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_filterName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_tagNotifyChar = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_tagWriteChar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_tagService = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lab_TitleMAC = new System.Windows.Forms.Label();
            this.txt_MAC = new System.Windows.Forms.TextBox();
            this.lab_RemarkMAC = new System.Windows.Forms.Label();
            this.com_BLList = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.num_minDb = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.com_LoopMode = new System.Windows.Forms.ComboBox();
            this.txt_TJ = new System.Windows.Forms.TextBox();
            this.btn_FlashTJ = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ClearTJ = new System.Windows.Forms.Button();
            this.btn_Test = new System.Windows.Forms.Button();
            this.btnClearLog2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_ReadCount = new System.Windows.Forms.NumericUpDown();
            this.num_ReadDelay = new System.Windows.Forms.NumericUpDown();
            this.tablePanel_DLLDebugParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_minDb)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_ReadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ReadDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_DLLDebugLoop
            // 
            this.chk_DLLDebugLoop.AutoSize = true;
            this.chk_DLLDebugLoop.Location = new System.Drawing.Point(116, 13);
            this.chk_DLLDebugLoop.Name = "chk_DLLDebugLoop";
            this.chk_DLLDebugLoop.Size = new System.Drawing.Size(59, 19);
            this.chk_DLLDebugLoop.TabIndex = 20;
            this.chk_DLLDebugLoop.Text = "循环";
            this.chk_DLLDebugLoop.UseVisualStyleBackColor = true;
            this.chk_DLLDebugLoop.CheckedChanged += new System.EventHandler(this.chk_DLLDebugLoop_CheckedChanged);
            // 
            // tablePanel_DLLDebugParam
            // 
            this.tablePanel_DLLDebugParam.ColumnCount = 3;
            this.tablePanel_DLLDebugParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel_DLLDebugParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel_DLLDebugParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel_DLLDebugParam.Controls.Add(this.label18, 0, 10);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label19, 2, 10);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label4, 2, 9);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label3, 2, 8);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label16, 0, 7);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label15, 2, 6);
            this.tablePanel_DLLDebugParam.Controls.Add(this.txt_filterName, 1, 6);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label14, 0, 6);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label13, 2, 5);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label12, 0, 5);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label11, 2, 4);
            this.tablePanel_DLLDebugParam.Controls.Add(this.txt_tagNotifyChar, 1, 4);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label10, 0, 4);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label9, 2, 3);
            this.tablePanel_DLLDebugParam.Controls.Add(this.txt_tagWriteChar, 1, 3);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label8, 0, 3);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label7, 2, 2);
            this.tablePanel_DLLDebugParam.Controls.Add(this.txt_tagService, 1, 2);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label6, 0, 2);
            this.tablePanel_DLLDebugParam.Controls.Add(this.lab_TitleMAC, 0, 1);
            this.tablePanel_DLLDebugParam.Controls.Add(this.txt_MAC, 1, 1);
            this.tablePanel_DLLDebugParam.Controls.Add(this.lab_RemarkMAC, 2, 1);
            this.tablePanel_DLLDebugParam.Controls.Add(this.com_BLList, 1, 5);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label17, 2, 7);
            this.tablePanel_DLLDebugParam.Controls.Add(this.num_minDb, 1, 7);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label5, 0, 11);
            this.tablePanel_DLLDebugParam.Controls.Add(this.com_LoopMode, 1, 10);
            this.tablePanel_DLLDebugParam.Controls.Add(this.txt_TJ, 1, 11);
            this.tablePanel_DLLDebugParam.Controls.Add(this.btn_FlashTJ, 2, 11);
            this.tablePanel_DLLDebugParam.Controls.Add(this.panel1, 0, 0);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label1, 0, 8);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label2, 0, 9);
            this.tablePanel_DLLDebugParam.Controls.Add(this.num_ReadCount, 1, 8);
            this.tablePanel_DLLDebugParam.Controls.Add(this.num_ReadDelay, 1, 9);
            this.tablePanel_DLLDebugParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel_DLLDebugParam.Location = new System.Drawing.Point(0, 0);
            this.tablePanel_DLLDebugParam.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tablePanel_DLLDebugParam.Name = "tablePanel_DLLDebugParam";
            this.tablePanel_DLLDebugParam.RowCount = 14;
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanel_DLLDebugParam.Size = new System.Drawing.Size(649, 840);
            this.tablePanel_DLLDebugParam.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(50, 331);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 15);
            this.label18.TabIndex = 40;
            this.label18.Text = "循环方式:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(534, 331);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 15);
            this.label19.TabIndex = 34;
            this.label19.Text = "测试目的";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "修改后立即生效";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "修改后立即生效";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 239);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 15);
            this.label16.TabIndex = 19;
            this.label16.Text = "信号过滤(dB):";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(534, 208);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 15);
            this.label15.TabIndex = 18;
            this.label15.Text = "必须包含的字符";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_filterName
            // 
            this.txt_filterName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filterName.Location = new System.Drawing.Point(131, 203);
            this.txt_filterName.Name = "txt_filterName";
            this.txt_filterName.Size = new System.Drawing.Size(397, 25);
            this.txt_filterName.TabIndex = 17;
            this.txt_filterName.Text = "ESP";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 15);
            this.label14.TabIndex = 16;
            this.label14.Text = "蓝牙过滤名称:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(534, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 15);
            this.label13.TabIndex = 14;
            this.label13.Text = "已固定";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(50, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 15);
            this.label12.TabIndex = 13;
            this.label12.Text = "切换蓝牙:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(534, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Notify特征";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_tagNotifyChar
            // 
            this.txt_tagNotifyChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tagNotifyChar.Location = new System.Drawing.Point(131, 143);
            this.txt_tagNotifyChar.Name = "txt_tagNotifyChar";
            this.txt_tagNotifyChar.Size = new System.Drawing.Size(397, 25);
            this.txt_tagNotifyChar.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "通知特征UUID:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(534, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "写特征";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_tagWriteChar
            // 
            this.txt_tagWriteChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tagWriteChar.Location = new System.Drawing.Point(131, 113);
            this.txt_tagWriteChar.Name = "txt_tagWriteChar";
            this.txt_tagWriteChar.Size = new System.Drawing.Size(397, 25);
            this.txt_tagWriteChar.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "写特征UUID:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(534, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "服务";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_tagService
            // 
            this.txt_tagService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tagService.Location = new System.Drawing.Point(131, 83);
            this.txt_tagService.Name = "txt_tagService";
            this.txt_tagService.Size = new System.Drawing.Size(397, 25);
            this.txt_tagService.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "服务UUID:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_TitleMAC
            // 
            this.lab_TitleMAC.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lab_TitleMAC.AutoSize = true;
            this.lab_TitleMAC.Location = new System.Drawing.Point(86, 57);
            this.lab_TitleMAC.Name = "lab_TitleMAC";
            this.lab_TitleMAC.Size = new System.Drawing.Size(39, 15);
            this.lab_TitleMAC.TabIndex = 0;
            this.lab_TitleMAC.Text = "MAC:";
            this.lab_TitleMAC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_MAC
            // 
            this.txt_MAC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MAC.Location = new System.Drawing.Point(131, 53);
            this.txt_MAC.Name = "txt_MAC";
            this.txt_MAC.Size = new System.Drawing.Size(397, 25);
            this.txt_MAC.TabIndex = 1;
            this.txt_MAC.Text = "30:83:98:FC:B4:3E";
            // 
            // lab_RemarkMAC
            // 
            this.lab_RemarkMAC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lab_RemarkMAC.AutoSize = true;
            this.lab_RemarkMAC.Location = new System.Drawing.Point(534, 57);
            this.lab_RemarkMAC.Name = "lab_RemarkMAC";
            this.lab_RemarkMAC.Size = new System.Drawing.Size(106, 15);
            this.lab_RemarkMAC.TabIndex = 2;
            this.lab_RemarkMAC.Text = "蓝牙对应的MAC";
            this.lab_RemarkMAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // com_BLList
            // 
            this.com_BLList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.com_BLList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_BLList.FormattingEnabled = true;
            this.com_BLList.Items.AddRange(new object[] {
            "ESP32",
            "国民蓝牙/巨微蓝牙"});
            this.com_BLList.Location = new System.Drawing.Point(131, 173);
            this.com_BLList.Name = "com_BLList";
            this.com_BLList.Size = new System.Drawing.Size(397, 23);
            this.com_BLList.TabIndex = 15;
            this.com_BLList.SelectedIndexChanged += new System.EventHandler(this.com_BLList_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(534, 239);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 15);
            this.label17.TabIndex = 20;
            this.label17.Text = "最小信号";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // num_minDb
            // 
            this.num_minDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.num_minDb.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_minDb.Location = new System.Drawing.Point(131, 234);
            this.num_minDb.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num_minDb.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.num_minDb.Name = "num_minDb";
            this.num_minDb.Size = new System.Drawing.Size(397, 25);
            this.num_minDb.TabIndex = 21;
            this.num_minDb.Value = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "统计:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // com_LoopMode
            // 
            this.com_LoopMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.com_LoopMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_LoopMode.FormattingEnabled = true;
            this.com_LoopMode.Items.AddRange(new object[] {
            "读数据",
            "连接-断开"});
            this.com_LoopMode.Location = new System.Drawing.Point(131, 327);
            this.com_LoopMode.Name = "com_LoopMode";
            this.com_LoopMode.Size = new System.Drawing.Size(397, 23);
            this.com_LoopMode.TabIndex = 33;
            this.com_LoopMode.SelectedIndexChanged += new System.EventHandler(this.com_LoopMode_SelectedIndexChanged);
            // 
            // txt_TJ
            // 
            this.txt_TJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TJ.Location = new System.Drawing.Point(131, 356);
            this.txt_TJ.Multiline = true;
            this.txt_TJ.Name = "txt_TJ";
            this.txt_TJ.ReadOnly = true;
            this.txt_TJ.Size = new System.Drawing.Size(397, 84);
            this.txt_TJ.TabIndex = 31;
            // 
            // btn_FlashTJ
            // 
            this.btn_FlashTJ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_FlashTJ.Location = new System.Drawing.Point(534, 384);
            this.btn_FlashTJ.Name = "btn_FlashTJ";
            this.btn_FlashTJ.Size = new System.Drawing.Size(67, 27);
            this.btn_FlashTJ.TabIndex = 29;
            this.btn_FlashTJ.Text = "刷新";
            this.btn_FlashTJ.UseVisualStyleBackColor = true;
            this.btn_FlashTJ.Click += new System.EventHandler(this.btn_FlashTJ_Click);
            // 
            // panel1
            // 
            this.tablePanel_DLLDebugParam.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.btn_ClearTJ);
            this.panel1.Controls.Add(this.btn_Test);
            this.panel1.Controls.Add(this.chk_DLLDebugLoop);
            this.panel1.Controls.Add(this.btnClearLog2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 44);
            this.panel1.TabIndex = 35;
            // 
            // btn_ClearTJ
            // 
            this.btn_ClearTJ.Location = new System.Drawing.Point(182, 4);
            this.btn_ClearTJ.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ClearTJ.Name = "btn_ClearTJ";
            this.btn_ClearTJ.Size = new System.Drawing.Size(100, 35);
            this.btn_ClearTJ.TabIndex = 21;
            this.btn_ClearTJ.Text = "清空统计";
            this.btn_ClearTJ.UseVisualStyleBackColor = true;
            this.btn_ClearTJ.Click += new System.EventHandler(this.btn_ClearTJ_Click);
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(4, 4);
            this.btn_Test.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(100, 35);
            this.btn_Test.TabIndex = 17;
            this.btn_Test.Text = "开始";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // btnClearLog2
            // 
            this.btnClearLog2.Location = new System.Drawing.Point(290, 4);
            this.btnClearLog2.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearLog2.Name = "btnClearLog2";
            this.btnClearLog2.Size = new System.Drawing.Size(100, 35);
            this.btnClearLog2.TabIndex = 18;
            this.btnClearLog2.Text = "清空Log";
            this.btnClearLog2.UseVisualStyleBackColor = true;
            this.btnClearLog2.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "读数据个数:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "轮训读间隔(ms):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_ReadCount
            // 
            this.num_ReadCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.num_ReadCount.Location = new System.Drawing.Point(131, 265);
            this.num_ReadCount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.num_ReadCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_ReadCount.Name = "num_ReadCount";
            this.num_ReadCount.Size = new System.Drawing.Size(397, 25);
            this.num_ReadCount.TabIndex = 39;
            this.num_ReadCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_ReadCount.ValueChanged += new System.EventHandler(this.num_ReadCount_ValueChanged);
            // 
            // num_ReadDelay
            // 
            this.num_ReadDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.num_ReadDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_ReadDelay.Location = new System.Drawing.Point(131, 296);
            this.num_ReadDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_ReadDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_ReadDelay.Name = "num_ReadDelay";
            this.num_ReadDelay.Size = new System.Drawing.Size(397, 25);
            this.num_ReadDelay.TabIndex = 38;
            this.num_ReadDelay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_ReadDelay.ValueChanged += new System.EventHandler(this.num_ReadDelay_ValueChanged);
            // 
            // uc_ConnDisConnTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tablePanel_DLLDebugParam);
            this.Name = "uc_ConnDisConnTest";
            this.Size = new System.Drawing.Size(649, 840);
            this.Load += new System.EventHandler(this.uc_ConnDisConnTest_Load);
            this.tablePanel_DLLDebugParam.ResumeLayout(false);
            this.tablePanel_DLLDebugParam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_minDb)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_ReadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ReadDelay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_DLLDebugLoop;
        private System.Windows.Forms.TableLayoutPanel tablePanel_DLLDebugParam;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_filterName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_tagNotifyChar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_tagWriteChar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_tagService;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lab_TitleMAC;
        private System.Windows.Forms.TextBox txt_MAC;
        private System.Windows.Forms.Label lab_RemarkMAC;
        private System.Windows.Forms.ComboBox com_BLList;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown num_minDb;
        private System.Windows.Forms.Button btnClearLog2;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_ClearTJ;
        private System.Windows.Forms.Button btn_FlashTJ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TJ;
        private System.Windows.Forms.ComboBox com_LoopMode;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_ReadDelay;
        private System.Windows.Forms.NumericUpDown num_ReadCount;
        private System.Windows.Forms.Label label18;
    }
}
