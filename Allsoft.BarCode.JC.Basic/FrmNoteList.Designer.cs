namespace Allsoft.BarCode.JC
{
    partial class FrmNoteList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNoteList));
            this.gcTable = new DevExpress.XtraGrid.GridControl();
            this.gvTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riceCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bmControl = new DevExpress.XtraBars.BarManager();
            this.barControl = new DevExpress.XtraBars.Bar();
            this.btnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTable
            // 
            this.gcTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcTable.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gcTable.Location = new System.Drawing.Point(17, 187);
            this.gcTable.MainView = this.gvTable;
            this.gcTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gcTable.Name = "gcTable";
            this.gcTable.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riceCheck});
            this.gcTable.Size = new System.Drawing.Size(1086, 519);
            this.gcTable.TabIndex = 4;
            this.gcTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTable});
            // 
            // gvTable
            // 
            this.gvTable.Appearance.HeaderPanel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTable.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvTable.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTable.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCode,
            this.colCompany,
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.colTime});
            this.gvTable.GridControl = this.gcTable;
            this.gvTable.Name = "gvTable";
            this.gvTable.OptionsView.ColumnAutoWidth = false;
            this.gvTable.OptionsView.ShowGroupPanel = false;
            this.gvTable.DoubleClick += new System.EventHandler(this.gvTable_DoubleClick);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 100;
            // 
            // colCode
            // 
            this.colCode.Caption = "发货单编码";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 129;
            // 
            // colCompany
            // 
            this.colCompany.Caption = "要货公司";
            this.colCompany.Name = "colCompany";
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 1;
            this.colCompany.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "所需数量";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "长度";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "宽度";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "厚度";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "压花";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 100;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "电晕";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 100;
            // 
            // colTime
            // 
            this.colTime.Caption = "日期";
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 8;
            this.colTime.Width = 100;
            // 
            // riceCheck
            // 
            this.riceCheck.AutoHeight = false;
            this.riceCheck.Name = "riceCheck";
            // 
            // bmControl
            // 
            this.bmControl.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barControl});
            this.bmControl.DockControls.Add(this.barDockControlTop);
            this.bmControl.DockControls.Add(this.barDockControlBottom);
            this.bmControl.DockControls.Add(this.barDockControlLeft);
            this.bmControl.DockControls.Add(this.barDockControlRight);
            this.bmControl.Form = this;
            this.bmControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSearch,
            this.barButtonItem1});
            this.bmControl.MainMenu = this.barControl;
            this.bmControl.MaxItemId = 2;
            // 
            // barControl
            // 
            this.barControl.BarName = "Main menu";
            this.barControl.DockCol = 0;
            this.barControl.DockRow = 0;
            this.barControl.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barControl.FloatLocation = new System.Drawing.Point(254, 129);
            this.barControl.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSearch, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barControl.OptionsBar.MultiLine = true;
            this.barControl.OptionsBar.UseWholeRow = true;
            this.barControl.Text = "Main menu";
            // 
            // btnSearch
            // 
            this.btnSearch.Caption = "查找";
            this.btnSearch.Id = 0;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ItemAppearance.Normal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSearch.Name = "btnSearch";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "选中项下载至PDA";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.bmControl;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barDockControlTop.Size = new System.Drawing.Size(1120, 60);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 724);
            this.barDockControlBottom.Manager = this.bmControl;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barDockControlBottom.Size = new System.Drawing.Size(1120, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 60);
            this.barDockControlLeft.Manager = this.bmControl;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 664);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1120, 60);
            this.barDockControlRight.Manager = this.bmControl;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 664);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(81, 72);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 21);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "日期";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(583, 127);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textEdit1.MenuManager = this.bmControl;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(239, 28);
            this.textEdit1.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(489, 132);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 21);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "要货公司";
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(133, 127);
            this.textEdit3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textEdit3.MenuManager = this.bmControl;
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(239, 28);
            this.textEdit3.TabIndex = 14;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(17, 132);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(110, 21);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "发货单编码";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(553, 72);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(22, 21);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "至";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(583, 68);
            this.dateEdit1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEdit1.MenuManager = this.bmControl;
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(239, 28);
            this.dateEdit1.TabIndex = 21;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(133, 68);
            this.dateEdit2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEdit2.MenuManager = this.bmControl;
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(239, 28);
            this.dateEdit2.TabIndex = 22;
            // 
            // FrmNoteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 724);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.textEdit3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.gcTable);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmNoteList";
            this.Text = "发货通知单列表";
            ((System.ComponentModel.ISupportInitialize)(this.gcTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTable;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riceCheck;
        private DevExpress.XtraBars.BarManager bmControl;
        private DevExpress.XtraBars.Bar barControl;
        private DevExpress.XtraBars.BarButtonItem btnSearch;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}