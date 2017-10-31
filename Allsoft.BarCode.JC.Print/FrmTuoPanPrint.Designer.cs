namespace Allsoft.BarCode.JC
{
    partial class FrmTuoPanPrint
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTuoPanPrint));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.txtPrintPersion = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrintData = new DevExpress.XtraEditors.DateEdit();
            this.gcProdctList = new DevExpress.XtraGrid.GridControl();
            this.gvProdctList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl38 = new DevExpress.XtraEditors.LabelControl();
            this.delRow = new DevExpress.XtraEditors.SimpleButton();
            this.easyReport1 = new VBprinter.EasyReport(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintPersion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintData.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProdctList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProdctList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPrint,
            this.barButtonItem2,
            this.btnClear});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClear, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "打印";
            this.btnPrint.Id = 0;
            this.btnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.Image")));
            this.btnPrint.ItemAppearance.Normal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "清空";
            this.btnClear.Id = 2;
            this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
            this.btnClear.ItemAppearance.Normal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ItemAppearance.Normal.Options.UseFont = true;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(651, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 321);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(651, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 281);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(651, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 281);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // txtPrintPersion
            // 
            this.txtPrintPersion.Location = new System.Drawing.Point(238, 63);
            this.txtPrintPersion.MenuManager = this.barManager1;
            this.txtPrintPersion.Name = "txtPrintPersion";
            this.txtPrintPersion.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPrintPersion.Properties.Appearance.Options.UseFont = true;
            this.txtPrintPersion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPrintPersion.Size = new System.Drawing.Size(125, 20);
            this.txtPrintPersion.TabIndex = 89;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(188, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 14);
            this.labelControl2.TabIndex = 88;
            this.labelControl2.Text = "打印人";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(380, 66);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 87;
            this.labelControl4.Text = "打印日期";
            // 
            // txtPrintData
            // 
            this.txtPrintData.EditValue = null;
            this.txtPrintData.Location = new System.Drawing.Point(447, 63);
            this.txtPrintData.MenuManager = this.barManager1;
            this.txtPrintData.Name = "txtPrintData";
            this.txtPrintData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPrintData.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPrintData.Size = new System.Drawing.Size(109, 20);
            this.txtPrintData.TabIndex = 90;
            // 
            // gcProdctList
            // 
            this.gcProdctList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcProdctList.Location = new System.Drawing.Point(0, 122);
            this.gcProdctList.MainView = this.gvProdctList;
            this.gcProdctList.MenuManager = this.barManager1;
            this.gcProdctList.Name = "gcProdctList";
            this.gcProdctList.Size = new System.Drawing.Size(650, 200);
            this.gcProdctList.TabIndex = 115;
            this.gcProdctList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProdctList});
            // 
            // gvProdctList
            // 
            this.gvProdctList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cCode});
            this.gvProdctList.GridControl = this.gcProdctList;
            this.gvProdctList.Name = "gvProdctList";
            this.gvProdctList.OptionsBehavior.Editable = false;
            this.gvProdctList.OptionsView.ShowGroupPanel = false;
            // 
            // cCode
            // 
            this.cCode.Caption = "条码号";
            this.cCode.FieldName = "cCode";
            this.cCode.Name = "cCode";
            this.cCode.Visible = true;
            this.cCode.VisibleIndex = 0;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(72, 63);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Size = new System.Drawing.Size(107, 20);
            this.txtCode.TabIndex = 285;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // labelControl38
            // 
            this.labelControl38.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl38.Appearance.Options.UseFont = true;
            this.labelControl38.Location = new System.Drawing.Point(21, 66);
            this.labelControl38.Name = "labelControl38";
            this.labelControl38.Size = new System.Drawing.Size(45, 14);
            this.labelControl38.TabIndex = 284;
            this.labelControl38.Text = "条码号";
            // 
            // delRow
            // 
            this.delRow.Location = new System.Drawing.Point(13, 93);
            this.delRow.Name = "delRow";
            this.delRow.Size = new System.Drawing.Size(75, 23);
            this.delRow.TabIndex = 286;
            this.delRow.Text = "删行";
            this.delRow.Click += new System.EventHandler(this.delRow_Click);
            // 
            // easyReport1
            // 
            this.easyReport1.EnableSaveAsImage = true;
            this.easyReport1.EnableSaveAsPDF = true;
            this.easyReport1.IsDrawmargin = false;
            this.easyReport1.IsShowPrintStatusDialog = true;
            this.easyReport1.IsShowProgess = true;
            this.easyReport1.IsUseAPIprintDialog = true;
            this.easyReport1.OffsetX = 0F;
            this.easyReport1.OffsetY = 0F;
            // 
            // FrmTuoPanPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 321);
            this.Controls.Add(this.delRow);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelControl38);
            this.Controls.Add(this.gcProdctList);
            this.Controls.Add(this.txtPrintData);
            this.Controls.Add(this.txtPrintPersion);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmTuoPanPrint";
            this.Text = "托盘条码打印";
            this.Load += new System.EventHandler(this.FrmTuoPanPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintPersion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintData.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProdctList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProdctList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.ButtonEdit txtPrintPersion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit txtPrintData;
        private DevExpress.XtraBars.BarButtonItem btnClear;
        private DevExpress.XtraGrid.GridControl gcProdctList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProdctList;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labelControl38;
        private DevExpress.XtraEditors.SimpleButton delRow;
        private VBprinter.EasyReport easyReport1;
        private DevExpress.XtraGrid.Columns.GridColumn cCode;
    }
}