using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BarCode.BaseForm
{
    public partial class FrmRefB : XtraForm
    {
        /// <summary>
        /// 返回DataTable
        /// </summary>
        public DataTable ReturnDT;

        /// <summary>
        /// 参照窗体标题
        /// </summary>
        public string RefCaption = "";

        /// <summary>
        /// 是否显示CheckBox
        /// </summary>
        public bool RefCheckBox = true;

        /// <summary>
        /// 显示列
        /// </summary>
        private List<String> showColumns;
        /// <summary>
        /// 显示列栏目属性
        /// </summary>
        public string ShowColumns
        {
            get { return string.Join(",", showColumns.ToArray()); }
            set { showColumns = value.Split(',').ToList(); }
        }

        /// <summary>
        /// 参照窗体
        /// </summary>
        /// <param name="dt">参照数据源DataTable</param>
        public FrmRefB(DataTable dt)
        {
            InitializeComponent();

            //初始化参照窗体表格数据
            gcRef.DataSource = dt;
            gvRef.Columns.Clear();

            //复制数据源DataTable数据架构
            ReturnDT = dt.Clone();
        }

        private void FrmRefB_Load(object sender, EventArgs e)
        {
            //显示参照标题
            this.Text = RefCaption;
            //显示CheckBox列初始化界面
            if (RefCheckBox)
            {
                gvRef.OptionsSelection.MultiSelect = true;
                gvRef.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            }
            //不显示CheckBox列初始化界面
            else
            {
                gvRef.OptionsSelection.MultiSelect = false;
                gvRef.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            }

            //显示数据列
            foreach (DataColumn dc in ReturnDT.Columns)
            {
                GridColumn gc = new GridColumn();
                gc.Name = dc.ColumnName;
                gc.Caption = dc.Caption;
                gc.FieldName = dc.ColumnName;
                if (showColumns != null)
                {
                    gc.Visible = showColumns.Contains(dc.ColumnName);
                }
                else
                {
                    gc.Visible = true;
                }
                gvRef.Columns.Add(gc);
            }

            gvRef.Focus();
        }

        private void gvRef_DoubleClick(object sender, EventArgs e)
        {
            btnEnter.PerformClick();
        }

        private void btnEnter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //带CheckBox传值
            if (RefCheckBox)
            {
                //返回传值
                foreach (int drid in gvRef.GetSelectedRows())
                {
                    ReturnDT.Rows.Add(gvRef.GetDataRow(drid).ItemArray);
                }
            }
            //不带CheckBox传值
            else
            {
                //判断当前行是否为null
                if (gvRef.RowCount == 0)
                {
                    MessageBox.Show("数据为空！");
                    return;
                }

                ReturnDT.Rows.Add(gvRef.GetFocusedDataRow().ItemArray);
            }
            this.Close();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReturnDT = null;
            this.Close();
        }

        private void gvRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnEnter.PerformClick();
            }
        }
    }
}
