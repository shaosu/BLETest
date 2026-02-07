namespace BLETest1.UserControls
{
    partial class uc_SleepLoopTest
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
            this.btn_ClearTJ = new System.Windows.Forms.Button();
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
            this.com_SleepCurrentSrc = new System.Windows.Forms.ComboBox();
            this.txt_TJ = new System.Windows.Forms.TextBox();
            this.btn_FlashTJ = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Test = new System.Windows.Forms.Button();
            this.chk_DLLDebugLoop = new System.Windows.Forms.CheckBox();
            this.btnClearLog2 = new System.Windows.Forms.Button();
            this.tablePanel_DLLDebugParam = new System.Windows.Forms.TableLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.com_VirPadPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.num_MaxSleepCurrent = new System.Windows.Forms.NumericUpDown();
            this.num_SleepUpLoopDelay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.nmu_DelayForGetCurrent = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_minDb)).BeginInit();
            this.panel1.SuspendLayout();
            this.tablePanel_DLLDebugParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_MaxSleepCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_SleepUpLoopDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmu_DelayForGetCurrent)).BeginInit();
            this.SuspendLayout();
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
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(664, 360);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 15);
            this.label19.TabIndex = 34;
            this.label19.Text = "注意量程";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(664, 330);
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
            this.label3.Location = new System.Drawing.Point(664, 299);
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
            this.label16.Location = new System.Drawing.Point(39, 268);
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
            this.label15.Location = new System.Drawing.Point(664, 237);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 15);
            this.label15.TabIndex = 18;
            this.label15.Text = "必须包含的字符";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_filterName
            // 
            this.txt_filterName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filterName.Location = new System.Drawing.Point(152, 232);
            this.txt_filterName.Name = "txt_filterName";
            this.txt_filterName.Size = new System.Drawing.Size(506, 25);
            this.txt_filterName.TabIndex = 17;
            this.txt_filterName.Text = "ESP";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(41, 237);
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
            this.label13.Location = new System.Drawing.Point(664, 206);
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
            this.label12.Location = new System.Drawing.Point(71, 206);
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
            this.label11.Location = new System.Drawing.Point(664, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Notify特征";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_tagNotifyChar
            // 
            this.txt_tagNotifyChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tagNotifyChar.Location = new System.Drawing.Point(152, 172);
            this.txt_tagNotifyChar.Name = "txt_tagNotifyChar";
            this.txt_tagNotifyChar.Size = new System.Drawing.Size(506, 25);
            this.txt_tagNotifyChar.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 176);
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
            this.label9.Location = new System.Drawing.Point(664, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "写特征";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_tagWriteChar
            // 
            this.txt_tagWriteChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tagWriteChar.Location = new System.Drawing.Point(152, 142);
            this.txt_tagWriteChar.Name = "txt_tagWriteChar";
            this.txt_tagWriteChar.Size = new System.Drawing.Size(506, 25);
            this.txt_tagWriteChar.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 146);
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
            this.label7.Location = new System.Drawing.Point(664, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "服务";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_tagService
            // 
            this.txt_tagService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tagService.Location = new System.Drawing.Point(152, 112);
            this.txt_tagService.Name = "txt_tagService";
            this.txt_tagService.Size = new System.Drawing.Size(506, 25);
            this.txt_tagService.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 116);
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
            this.lab_TitleMAC.Location = new System.Drawing.Point(107, 86);
            this.lab_TitleMAC.Name = "lab_TitleMAC";
            this.lab_TitleMAC.Size = new System.Drawing.Size(39, 15);
            this.lab_TitleMAC.TabIndex = 0;
            this.lab_TitleMAC.Text = "MAC:";
            this.lab_TitleMAC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_MAC
            // 
            this.txt_MAC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MAC.Location = new System.Drawing.Point(152, 82);
            this.txt_MAC.Name = "txt_MAC";
            this.txt_MAC.Size = new System.Drawing.Size(506, 25);
            this.txt_MAC.TabIndex = 1;
            this.txt_MAC.Text = "30:83:98:FC:B4:3E";
            // 
            // lab_RemarkMAC
            // 
            this.lab_RemarkMAC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lab_RemarkMAC.AutoSize = true;
            this.lab_RemarkMAC.Location = new System.Drawing.Point(664, 86);
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
            this.com_BLList.Location = new System.Drawing.Point(152, 202);
            this.com_BLList.Name = "com_BLList";
            this.com_BLList.Size = new System.Drawing.Size(506, 23);
            this.com_BLList.TabIndex = 15;
            this.com_BLList.SelectedIndexChanged += new System.EventHandler(this.com_BLList_SelectedIndexChanged);
            this.com_BLList.Click += new System.EventHandler(this.com_BLList_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(664, 268);
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
            this.num_minDb.Location = new System.Drawing.Point(152, 263);
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
            this.num_minDb.Size = new System.Drawing.Size(506, 25);
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
            this.label5.Location = new System.Drawing.Point(101, 459);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "统计:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // com_SleepCurrentSrc
            // 
            this.com_SleepCurrentSrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.com_SleepCurrentSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_SleepCurrentSrc.FormattingEnabled = true;
            this.com_SleepCurrentSrc.Items.AddRange(new object[] {
            "工作电流(量程:0-6553.5mA)",
            "休眠电流(量程:0-6.555mA)"});
            this.com_SleepCurrentSrc.Location = new System.Drawing.Point(152, 356);
            this.com_SleepCurrentSrc.Name = "com_SleepCurrentSrc";
            this.com_SleepCurrentSrc.Size = new System.Drawing.Size(506, 23);
            this.com_SleepCurrentSrc.TabIndex = 33;
            this.com_SleepCurrentSrc.SelectedIndexChanged += new System.EventHandler(this.com_SleepCurrentSrc_SelectedIndexChanged);
            this.com_SleepCurrentSrc.Click += new System.EventHandler(this.com_SleepCurrentSrc_SelectedIndexChanged);
            // 
            // txt_TJ
            // 
            this.txt_TJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TJ.Location = new System.Drawing.Point(152, 416);
            this.txt_TJ.Multiline = true;
            this.txt_TJ.Name = "txt_TJ";
            this.txt_TJ.ReadOnly = true;
            this.txt_TJ.Size = new System.Drawing.Size(506, 102);
            this.txt_TJ.TabIndex = 31;
            // 
            // btn_FlashTJ
            // 
            this.btn_FlashTJ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_FlashTJ.Location = new System.Drawing.Point(664, 453);
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
            this.panel1.Size = new System.Drawing.Size(773, 44);
            this.panel1.TabIndex = 35;
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
            // tablePanel_DLLDebugParam
            // 
            this.tablePanel_DLLDebugParam.ColumnCount = 3;
            this.tablePanel_DLLDebugParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel_DLLDebugParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel_DLLDebugParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel_DLLDebugParam.Controls.Add(this.label20, 0, 1);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label19, 2, 11);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label4, 2, 10);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label3, 2, 9);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label16, 0, 8);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label15, 2, 7);
            this.tablePanel_DLLDebugParam.Controls.Add(this.txt_filterName, 1, 7);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label14, 0, 7);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label13, 2, 6);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label12, 0, 6);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label11, 2, 5);
            this.tablePanel_DLLDebugParam.Controls.Add(this.txt_tagNotifyChar, 1, 5);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label10, 0, 5);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label9, 2, 4);
            this.tablePanel_DLLDebugParam.Controls.Add(this.txt_tagWriteChar, 1, 4);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label8, 0, 4);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label7, 2, 3);
            this.tablePanel_DLLDebugParam.Controls.Add(this.txt_tagService, 1, 3);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label6, 0, 3);
            this.tablePanel_DLLDebugParam.Controls.Add(this.lab_TitleMAC, 0, 2);
            this.tablePanel_DLLDebugParam.Controls.Add(this.txt_MAC, 1, 2);
            this.tablePanel_DLLDebugParam.Controls.Add(this.lab_RemarkMAC, 2, 2);
            this.tablePanel_DLLDebugParam.Controls.Add(this.com_BLList, 1, 6);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label17, 2, 8);
            this.tablePanel_DLLDebugParam.Controls.Add(this.num_minDb, 1, 8);
            this.tablePanel_DLLDebugParam.Controls.Add(this.com_SleepCurrentSrc, 1, 11);
            this.tablePanel_DLLDebugParam.Controls.Add(this.panel1, 0, 0);
            this.tablePanel_DLLDebugParam.Controls.Add(this.com_VirPadPort, 1, 1);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label1, 0, 10);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label21, 0, 9);
            this.tablePanel_DLLDebugParam.Controls.Add(this.num_MaxSleepCurrent, 1, 10);
            this.tablePanel_DLLDebugParam.Controls.Add(this.num_SleepUpLoopDelay, 1, 9);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label2, 0, 11);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label5, 0, 13);
            this.tablePanel_DLLDebugParam.Controls.Add(this.txt_TJ, 1, 13);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label18, 0, 12);
            this.tablePanel_DLLDebugParam.Controls.Add(this.btn_FlashTJ, 2, 13);
            this.tablePanel_DLLDebugParam.Controls.Add(this.nmu_DelayForGetCurrent, 1, 12);
            this.tablePanel_DLLDebugParam.Controls.Add(this.label22, 2, 12);
            this.tablePanel_DLLDebugParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel_DLLDebugParam.Location = new System.Drawing.Point(0, 0);
            this.tablePanel_DLLDebugParam.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tablePanel_DLLDebugParam.Name = "tablePanel_DLLDebugParam";
            this.tablePanel_DLLDebugParam.RowCount = 16;
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel_DLLDebugParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel_DLLDebugParam.Size = new System.Drawing.Size(779, 682);
            this.tablePanel_DLLDebugParam.TabIndex = 20;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(56, 57);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(90, 15);
            this.label20.TabIndex = 39;
            this.label20.Text = "模拟板串口:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // com_VirPadPort
            // 
            this.com_VirPadPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.com_VirPadPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_VirPadPort.FormattingEnabled = true;
            this.com_VirPadPort.Location = new System.Drawing.Point(152, 53);
            this.com_VirPadPort.Name = "com_VirPadPort";
            this.com_VirPadPort.Size = new System.Drawing.Size(506, 23);
            this.com_VirPadPort.TabIndex = 38;
            this.com_VirPadPort.Click += new System.EventHandler(this.com_VirPadPort_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 15);
            this.label1.TabIndex = 41;
            this.label1.Text = "最大休眠电流(mA):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(40, 299);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(106, 15);
            this.label21.TabIndex = 40;
            this.label21.Text = "一轮间隔(秒):";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_MaxSleepCurrent
            // 
            this.num_MaxSleepCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.num_MaxSleepCurrent.DecimalPlaces = 3;
            this.num_MaxSleepCurrent.Location = new System.Drawing.Point(152, 325);
            this.num_MaxSleepCurrent.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_MaxSleepCurrent.Name = "num_MaxSleepCurrent";
            this.num_MaxSleepCurrent.Size = new System.Drawing.Size(506, 25);
            this.num_MaxSleepCurrent.TabIndex = 42;
            this.num_MaxSleepCurrent.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.num_MaxSleepCurrent.ValueChanged += new System.EventHandler(this.num_MaxSleepCurrent_ValueChanged);
            // 
            // num_SleepUpLoopDelay
            // 
            this.num_SleepUpLoopDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.num_SleepUpLoopDelay.Location = new System.Drawing.Point(152, 294);
            this.num_SleepUpLoopDelay.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.num_SleepUpLoopDelay.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_SleepUpLoopDelay.Name = "num_SleepUpLoopDelay";
            this.num_SleepUpLoopDelay.Size = new System.Drawing.Size(506, 25);
            this.num_SleepUpLoopDelay.TabIndex = 43;
            this.num_SleepUpLoopDelay.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.num_SleepUpLoopDelay.ValueChanged += new System.EventHandler(this.num_SleepUpLoopDelay_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 44;
            this.label2.Text = "休眠电流来源:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 390);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(143, 15);
            this.label18.TabIndex = 45;
            this.label18.Text = "延迟N秒后获取电流:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nmu_DelayForGetCurrent
            // 
            this.nmu_DelayForGetCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nmu_DelayForGetCurrent.Location = new System.Drawing.Point(152, 385);
            this.nmu_DelayForGetCurrent.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nmu_DelayForGetCurrent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmu_DelayForGetCurrent.Name = "nmu_DelayForGetCurrent";
            this.nmu_DelayForGetCurrent.Size = new System.Drawing.Size(506, 25);
            this.nmu_DelayForGetCurrent.TabIndex = 46;
            this.nmu_DelayForGetCurrent.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmu_DelayForGetCurrent.ValueChanged += new System.EventHandler(this.nmu_DelayForGetCurrent_ValueChanged);
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(664, 390);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 15);
            this.label22.TabIndex = 47;
            this.label22.Text = "会重试3次";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uc_SleepLoopTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel_DLLDebugParam);
            this.Name = "uc_SleepLoopTest";
            this.Size = new System.Drawing.Size(779, 682);
            this.Load += new System.EventHandler(this.uc_SleepLoopTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_minDb)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tablePanel_DLLDebugParam.ResumeLayout(false);
            this.tablePanel_DLLDebugParam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_MaxSleepCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_SleepUpLoopDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmu_DelayForGetCurrent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ClearTJ;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox com_SleepCurrentSrc;
        private System.Windows.Forms.TextBox txt_TJ;
        private System.Windows.Forms.Button btn_FlashTJ;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tablePanel_DLLDebugParam;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.CheckBox chk_DLLDebugLoop;
        private System.Windows.Forms.Button btnClearLog2;
        private System.Windows.Forms.ComboBox com_VirPadPort;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_MaxSleepCurrent;
        private System.Windows.Forms.NumericUpDown num_SleepUpLoopDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown nmu_DelayForGetCurrent;
        private System.Windows.Forms.Label label22;
    }
}
