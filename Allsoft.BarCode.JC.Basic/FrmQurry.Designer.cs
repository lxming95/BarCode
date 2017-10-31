namespace Allsoft.BarCode.JC
{
    partial class FrmQurry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQurry));
            this.bmControl = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnChange = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gcTable = new DevExpress.XtraGrid.GridControl();
            this.gvTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.buttonEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bmControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bmControl
            // 
            this.bmControl.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.bmControl.DockControls.Add(this.barDockControlTop);
            this.bmControl.DockControls.Add(this.barDockControlBottom);
            this.bmControl.DockControls.Add(this.barDockControlLeft);
            this.bmControl.DockControls.Add(this.barDockControlRight);
            this.bmControl.Form = this;
            this.bmControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnChange,
            this.btnDelete,
            this.btnSave,
            this.barButtonItem1,
            this.barButtonItem2});
            this.bmControl.MainMenu = this.bar2;
            this.bmControl.MaxItemId = 5;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnChange, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "新增";
            this.barButtonItem2.Id = 4;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ItemAppearance.Normal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.barButtonItem2.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btnChange
            // 
            this.btnChange.Caption = "修改";
            this.btnChange.Id = 0;
            this.btnChange.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChange.ImageOptions.Image")));
            this.btnChange.ItemAppearance.Normal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnChange.ItemAppearance.Normal.Options.UseFont = true;
            this.btnChange.Name = "btnChange";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "删除";
            this.btnDelete.Id = 1;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ItemAppearance.Normal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDelete.Name = "btnDelete";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "取消";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "保存";
            this.btnSave.Id = 2;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ItemAppearance.Normal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSave.Name = "btnSave";
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
            // gcTable
            // 
            this.gcTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcTable.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gcTable.Location = new System.Drawing.Point(0, 165);
            this.gcTable.MainView = this.gvTable;
            this.gcTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gcTable.MenuManager = this.bmControl;
            this.gcTable.Name = "gcTable";
            this.gcTable.Size = new System.Drawing.Size(1120, 556);
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
            this.gvTable.Appearance.Row.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTable.Appearance.Row.Options.UseFont = true;
            this.gvTable.Appearance.Row.Options.UseTextOptions = true;
            this.gvTable.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName});
            this.gvTable.GridControl = this.gcTable;
            this.gvTable.Name = "gvTable";
            this.gvTable.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.Name = "colID";
            // 
            // colName
            // 
            this.colName.Caption = "枚举项目";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(33, 115);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 21);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "枚举类型";
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(129, 108);
            this.buttonEdit1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEdit1.MenuManager = this.bmControl;
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEdit1.Properties.Appearance.Options.UseFont = true;
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.buttonEdit1.Size = new System.Drawing.Size(213, 28);
            this.buttonEdit1.TabIndex = 15;
            // 
            // FrmQurry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 724);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gcTable);
            this.Controls.Add(this.buttonEdit1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmQurry";
            this.Text = "枚举档案";
            ((System.ComponentModel.ISupportInitialize)(this.bmControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager bmControl;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnChange;
        private DevExpress.XtraGrid.GridControl gcTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTable;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraEditors.ComboBoxEdit buttonEdit1;
    }
}

