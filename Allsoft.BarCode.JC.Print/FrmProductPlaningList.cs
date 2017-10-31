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
using System.IO;
using System.Data.SqlClient;

namespace Allsoft.BarCode.JC
{
    public partial class FrmProductPlaningList : DevExpress.XtraEditors.XtraForm
    {
        public FrmProductPlaningList()
        {
            InitializeComponent();
        }

        private void FrmProductPlaningList_Load(object sender, EventArgs e)
        {
            DataTable dt = SqlHelper.Table("SELECT * FROM Data_Planing");
            this.gcPlanList.DataSource = dt;
        }

        private void gvPlanList_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = gvPlanList.GetDataRow(gvPlanList.FocusedRowHandle);
            Form frm = new FrmProductPlaning(row["cDocumentsNum"].ToString());
            frm.Show();
        }

        private void btnReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvPlanList.DataSource == null) //没有查询数据的处理
            {
                XtraMessageBox.Show("无数据，请先查询");
                return;
            }
            else                                //查询数据之后的处理
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog()) //离开后销毁对话框
                {
                    //保存文件的类型
                    saveDialog.Filter = "Excel (97-2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx";
                    Start: if (saveDialog.ShowDialog() != DialogResult.Cancel)  //用户点击保存按钮
                    {
                        string exportFilePath = saveDialog.FileName;     //定义文件路径              
                        string fileExtenstion = new FileInfo(exportFilePath).Extension; //创建文件

                        try
                        {
                            switch (fileExtenstion)                             //判断文件类型
                            {
                                case ".xls":
                                    gcPlanList.ExportToXls(exportFilePath);    //.xls类型
                                    break;
                                case ".xlsx":
                                    gcPlanList.ExportToXlsx(exportFilePath);   //.xlsx类型
                                    break;                                
                                default:
                                    break;
                            }
                        }
                        catch
                        {
                            //文件无法打开，消息字符串msg= 提示语+/n/n+path:+路径
                            String msg = "文件无法被创建或者修改，正在使用或者没有权限,请检查是否同名文件被打开，请尝试关闭打开文件后重试" + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            XtraMessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto Start;

                        }

                        if (File.Exists(exportFilePath))        //文件创建成功的情况
                        {
                            try
                            {
                                //文件存在，弹窗提示是否打开
                                if (DialogResult.Yes == XtraMessageBox.Show("文件已成功导出，是否打开文件?", "提示", MessageBoxButtons.YesNo))
                                {
                                    //打开文件 
                                    System.Diagnostics.Process.Start(exportFilePath);
                                }
                            }
                            catch
                            {
                                //文件无法打开，弹窗提示 
                                String msg = "文件无法打开" + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                XtraMessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            //文件无法保存，弹窗提示
                            string msg = "文件无法保存" + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            XtraMessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@cCode", this.txtCode.Text),
               //new SqlParameter("@dMake_time1", this.txtData1.Text), new SqlParameter("@dMake_time2", this.txtData2.Text),
               // new SqlParameter("@cThickness", this.txtThickness.Text), new SqlParameter("@cWidth", this.txtWidth.Text),
                new SqlParameter("@cCustomer", this.txtCustomer.Text), new SqlParameter("@cProductModel", this.txtProductModel.Text),
                new SqlParameter("@cBigLength", this.txtBigLength.Text),
            };
            string where = "";
            if (this.txtCode.Text != "")
                where += " and cCode= @cCode";
            if (this.txtData1.Text != "")
                where += " and dMake_time >'"+ this.txtData1.Text+"' ";
            if (this.txtData2.Text != "")
                where += " and dMake_time <'"+ this.txtData2.Text+"' ";
            if (this.txtThickness.Text != "")
                where += " and cModel like '%"+ this.txtThickness.Text + "%'";
            if (this.txtWidth.Text != "")
                where += " and cModel like '%" + this.txtWidth.Text + "%'";
            if (this.txtCustomer.Text != "")
                where += " and cCustomer=@cCustomer";
            if (this.txtProductModel.Text != "")
                where += " and cModelName=@cProductModel";
            if (this.txtBigLength.Text != "")
                where += "";

            dt = SqlHelper.Table("SELECT * FROM Data_Planing AS a LEFT JOIN (SELECT Did,cCode as code,cMake_person,dMake_time,cCheck_person,dCheck_time,do_flag FROM Data_Documents) AS b ON a.cDocumentsNum = b.code where '1'='1' " + where, param);
            this.gcPlanList.DataSource = dt;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = gcPlanList.DataSource as DataTable;
            easyReport1.SetReportDataSource(dt);                                                                            //打印控件绑定数据源
            easyReport1.SetReportFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "label\\PlanList.mb"); //设置打印控件模版
            //easyReport1.CreateReport();                                                                                   //创建初始化模版
            easyReport1.PrintReport(false, false, true, false);
        }
    }
}