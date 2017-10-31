using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Allsoft.BarCode.Print;

namespace Allsoft.BarCode.JC
{
    public partial class FrmTuoPanPrint : DevExpress.XtraEditors.XtraForm
    {
        public FrmTuoPanPrint()
        {
            InitializeComponent();
        }

        private void FrmTuoPanPrint_Load(object sender, EventArgs e)
        {
            txtPrintData.Text = DateTime.Now.ToString();
            txtPrintPersion.Text = Pub.PubValue.UserName;
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = insert();
            easyReport1.SetReportDataSource(dt);                                                                             //打印控件绑定数据源
            easyReport1.SetReportFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "label\\tuopan.mb"); //设置打印控件模版
            //easyReport1.CreateReport();                                                                                   //创建初始化模版
            easyReport1.PrintReport(false, false, true, false);
        }
        /// <summary>
        /// 清空界面
        /// </summary>
        private void clear()
        {
            txtCode.Text = "";
            txtPrintData.Text = "";
            txtPrintPersion.Text = "";
        }

        private DataTable insert()
        {
            DataTable dt = SqlHelper.Table("");
            return dt;
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                DataTable dt = gcProdctList.DataSource as DataTable;
                dt.Rows.Add();
            }
        }

        private void delRow_Click(object sender, EventArgs e)
        {

        }
    }
}