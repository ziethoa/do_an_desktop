
namespace do_an
{
    partial class TableManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableManager));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lsvBills = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pAbate = new System.Windows.Forms.Panel();
            this.btnTimeStart = new System.Windows.Forms.Button();
            this.btnAbate = new System.Windows.Forms.Button();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.txtTimeFinish = new System.Windows.Forms.TextBox();
            this.txtTimeStart = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pFoodAndDrink = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FoodAndDrinkCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddFoodOrDrink = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFoodOrDrink = new System.Windows.Forms.ComboBox();
            this.cbCatagoryFoodOrDrink = new System.Windows.Forms.ComboBox();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBill = new System.Windows.Forms.Button();
            this.txtTotalPriceAll = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pAbate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            this.panel5.SuspendLayout();
            this.pFoodAndDrink.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FoodAndDrinkCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Azure;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1384, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("homeToolStripMenuItem.BackgroundImage")));
            this.homeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.homeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.homeToolStripMenuItem.Image = global::do_an.Properties.Resources.kisspng_house_real_estate_home_building_dormitory_5b4663123fd570_4975341015313395382615;
            this.homeToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(85, 26);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("adminToolStripMenuItem.BackgroundImage")));
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.adminToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.adminToolStripMenuItem.Image = global::do_an.Properties.Resources.R;
            this.adminToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("thôngTinTàiKhoảnToolStripMenuItem.BackgroundImage")));
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.thôngTinTàiKhoảnToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.thôngTinTàiKhoảnToolStripMenuItem.Image = global::do_an.Properties.Resources.OIP__1_;
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lsvBills);
            this.panel3.Location = new System.Drawing.Point(486, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(487, 391);
            this.panel3.TabIndex = 2;
            // 
            // lsvBills
            // 
            this.lsvBills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBills.GridLines = true;
            this.lsvBills.HideSelection = false;
            this.lsvBills.Location = new System.Drawing.Point(3, 3);
            this.lsvBills.Name = "lsvBills";
            this.lsvBills.Size = new System.Drawing.Size(481, 397);
            this.lsvBills.TabIndex = 0;
            this.lsvBills.UseCompatibleStateImageBehavior = false;
            this.lsvBills.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món ăn";
            this.columnHeader1.Width = 91;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn  giá";
            this.columnHeader3.Width = 77;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tổng giá";
            this.columnHeader4.Width = 96;
            // 
            // pAbate
            // 
            this.pAbate.Controls.Add(this.btnTimeStart);
            this.pAbate.Controls.Add(this.btnAbate);
            this.pAbate.Controls.Add(this.numDiscount);
            this.pAbate.Controls.Add(this.txtTimeFinish);
            this.pAbate.Controls.Add(this.txtTimeStart);
            this.pAbate.Controls.Add(this.label9);
            this.pAbate.Controls.Add(this.label8);
            this.pAbate.Controls.Add(this.label7);
            this.pAbate.Location = new System.Drawing.Point(979, 256);
            this.pAbate.Name = "pAbate";
            this.pAbate.Size = new System.Drawing.Size(371, 175);
            this.pAbate.TabIndex = 3;
            // 
            // btnTimeStart
            // 
            this.btnTimeStart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTimeStart.Location = new System.Drawing.Point(66, 125);
            this.btnTimeStart.Name = "btnTimeStart";
            this.btnTimeStart.Size = new System.Drawing.Size(132, 35);
            this.btnTimeStart.TabIndex = 12;
            this.btnTimeStart.Text = "Bắt đầu tính giờ";
            this.btnTimeStart.UseVisualStyleBackColor = true;
            this.btnTimeStart.Click += new System.EventHandler(this.btnTimeStart_Click);
            // 
            // btnAbate
            // 
            this.btnAbate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAbate.Location = new System.Drawing.Point(229, 125);
            this.btnAbate.Name = "btnAbate";
            this.btnAbate.Size = new System.Drawing.Size(107, 35);
            this.btnAbate.TabIndex = 7;
            this.btnAbate.Text = "Thanh toán";
            this.btnAbate.UseVisualStyleBackColor = true;
            this.btnAbate.Click += new System.EventHandler(this.btnAbate_Click);
            // 
            // numDiscount
            // 
            this.numDiscount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDiscount.Location = new System.Drawing.Point(257, 95);
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(93, 22);
            this.numDiscount.TabIndex = 11;
            this.numDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTimeFinish
            // 
            this.txtTimeFinish.Location = new System.Drawing.Point(173, 58);
            this.txtTimeFinish.Name = "txtTimeFinish";
            this.txtTimeFinish.Size = new System.Drawing.Size(177, 22);
            this.txtTimeFinish.TabIndex = 10;
            // 
            // txtTimeStart
            // 
            this.txtTimeStart.Location = new System.Drawing.Point(171, 23);
            this.txtTimeStart.Name = "txtTimeStart";
            this.txtTimeStart.Size = new System.Drawing.Size(179, 22);
            this.txtTimeStart.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(38, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Giảm giá: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(38, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Thời gian kết thúc: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(38, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Thời gian bắt đầu: ";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pFoodAndDrink);
            this.panel5.Location = new System.Drawing.Point(979, 137);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(371, 113);
            this.panel5.TabIndex = 4;
            // 
            // pFoodAndDrink
            // 
            this.pFoodAndDrink.Controls.Add(this.label3);
            this.pFoodAndDrink.Controls.Add(this.label2);
            this.pFoodAndDrink.Controls.Add(this.FoodAndDrinkCount);
            this.pFoodAndDrink.Controls.Add(this.btnAddFoodOrDrink);
            this.pFoodAndDrink.Controls.Add(this.label1);
            this.pFoodAndDrink.Controls.Add(this.cbFoodOrDrink);
            this.pFoodAndDrink.Controls.Add(this.cbCatagoryFoodOrDrink);
            this.pFoodAndDrink.Location = new System.Drawing.Point(3, 3);
            this.pFoodAndDrink.Name = "pFoodAndDrink";
            this.pFoodAndDrink.Size = new System.Drawing.Size(365, 105);
            this.pFoodAndDrink.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(14, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Món:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(14, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Loại: ";
            // 
            // FoodAndDrinkCount
            // 
            this.FoodAndDrinkCount.Location = new System.Drawing.Point(273, 72);
            this.FoodAndDrinkCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.FoodAndDrinkCount.Name = "FoodAndDrinkCount";
            this.FoodAndDrinkCount.Size = new System.Drawing.Size(74, 22);
            this.FoodAndDrinkCount.TabIndex = 4;
            this.FoodAndDrinkCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FoodAndDrinkCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFoodOrDrink
            // 
            this.btnAddFoodOrDrink.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddFoodOrDrink.Location = new System.Drawing.Point(240, 32);
            this.btnAddFoodOrDrink.Name = "btnAddFoodOrDrink";
            this.btnAddFoodOrDrink.Size = new System.Drawing.Size(107, 35);
            this.btnAddFoodOrDrink.TabIndex = 3;
            this.btnAddFoodOrDrink.Text = "Thêm món";
            this.btnAddFoodOrDrink.UseVisualStyleBackColor = true;
            this.btnAddFoodOrDrink.Click += new System.EventHandler(this.btnAddFoodOrDrink_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thức Ăn và Đồ Uống";
            // 
            // cbFoodOrDrink
            // 
            this.cbFoodOrDrink.FormattingEnabled = true;
            this.cbFoodOrDrink.Location = new System.Drawing.Point(63, 71);
            this.cbFoodOrDrink.Name = "cbFoodOrDrink";
            this.cbFoodOrDrink.Size = new System.Drawing.Size(154, 24);
            this.cbFoodOrDrink.TabIndex = 1;
            // 
            // cbCatagoryFoodOrDrink
            // 
            this.cbCatagoryFoodOrDrink.BackColor = System.Drawing.SystemColors.Window;
            this.cbCatagoryFoodOrDrink.FormattingEnabled = true;
            this.cbCatagoryFoodOrDrink.Location = new System.Drawing.Point(63, 32);
            this.cbCatagoryFoodOrDrink.Name = "cbCatagoryFoodOrDrink";
            this.cbCatagoryFoodOrDrink.Size = new System.Drawing.Size(154, 24);
            this.cbCatagoryFoodOrDrink.TabIndex = 0;
            this.cbCatagoryFoodOrDrink.SelectedIndexChanged += new System.EventHandler(this.cbCatagoryFoodOrDrink_SelectedIndexChanged);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.BackColor = System.Drawing.Color.MintCream;
            this.flpTable.Location = new System.Drawing.Point(12, 40);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(468, 391);
            this.flpTable.TabIndex = 5;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBill);
            this.panel1.Controls.Add(this.txtTotalPriceAll);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(979, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 91);
            this.panel1.TabIndex = 7;
            // 
            // btnBill
            // 
            this.btnBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBill.ForeColor = System.Drawing.Color.Black;
            this.btnBill.Location = new System.Drawing.Point(229, 44);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(121, 30);
            this.btnBill.TabIndex = 9;
            this.btnBill.Text = "Xem bill";
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // txtTotalPriceAll
            // 
            this.txtTotalPriceAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTotalPriceAll.Location = new System.Drawing.Point(45, 44);
            this.txtTotalPriceAll.Name = "txtTotalPriceAll";
            this.txtTotalPriceAll.ReadOnly = true;
            this.txtTotalPriceAll.Size = new System.Drawing.Size(147, 30);
            this.txtTotalPriceAll.TabIndex = 8;
            this.txtTotalPriceAll.Text = "0";
            this.txtTotalPriceAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Snow;
            this.label4.Location = new System.Drawing.Point(62, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tổng tiền";
            // 
            // TableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1384, 455);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pAbate);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pAbate.ResumeLayout(false);
            this.pAbate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            this.panel5.ResumeLayout(false);
            this.pFoodAndDrink.ResumeLayout(false);
            this.pFoodAndDrink.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FoodAndDrinkCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pAbate;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pFoodAndDrink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFoodOrDrink;
        private System.Windows.Forms.ComboBox cbCatagoryFoodOrDrink;
        private System.Windows.Forms.NumericUpDown FoodAndDrinkCount;
        private System.Windows.Forms.Button btnAddFoodOrDrink;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.TextBox txtTimeFinish;
        private System.Windows.Forms.TextBox txtTimeStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAbate;
        private System.Windows.Forms.Button btnTimeStart;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ListView lsvBills;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTotalPriceAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBill;
    }
}