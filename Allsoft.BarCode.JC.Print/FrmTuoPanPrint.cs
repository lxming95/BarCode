using Allsoft.BarCode.Print;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            DataTable dt = new DataTable();
            dt.Columns.Add("cCode",typeof(string));
            txtPrintData.Text = DateTime.Now.ToString();
            txtPrintPersion.Text = Pub.PubValue.UserName;
            gcProdctList.DataSource = dt;
        }

        /// <summary>
        /// 清空按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clear();
        }
        /// <summary>
        ///  打印按钮点击事件
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
        /// 录入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                if (txtCode.Text != "")
                {
                    foreach (DataRow r in (gcProdctList.DataSource as DataTable).Rows)
                    {
                        if (r["cCode"].Equals(txtCode.Text))
                        {
                            XtraMessageBox.Show("该码已存在，请扫描其他码");
                            return;
                        }
                    }
                    if (isSafe(txtCode.Text))
                    {
                        SqlParameter[] param = new SqlParameter[] { new SqlParameter("g_ccdcode", txtCode.Text) };
                        DataTable dt = SqlHelper.Table("SELECT * FROM data_printlog WHERE g_ccdcode=@g_ccdcode AND do_flag='1'");
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            dt = gcProdctList.DataSource as DataTable;
                            dt.Rows.Add();
                            dt.Rows[dt.Rows.Count - 1]["cCode"] = txtCode.Text;
                            gcProdctList.DataSource = dt;
                        }
                    }
                    txtCode.Text = "";
                }
            }
        }
        /// <summary>
        /// 删行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delRow_Click(object sender, EventArgs e)
        {
            //删行
            gvProdctList.DeleteRow(gvProdctList.FocusedRowHandle);
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
        /// <summary>
        /// 向数据库中插入数据
        /// </summary>
        /// <returns></returns>
        private DataTable insert()
        {
            DataTable dt = new DataTable();
            if (dtStr()!= "")
            {
                DataTable dt1 = SqlHelper.Table("select max(ls_code) as code from data_printlog");
                string s = "";
                if (dt1 == null || dt1.Rows.Count <= 0|| dt1.Rows[0]["code"].ToString()=="")
                {
                    s = DateTime.Now.ToString("yyyyMMdd") + "001";
                }
                else
                {
                    s = (Convert.ToDecimal(dt1.Rows[0]["code"])+1).ToString();
                }
                SqlHelper.ExecuteNonQuery("update data_printlog set ls_code='"+s+"' where g_ccdcode in("+dtStr()+")");
                dt= SqlHelper.Table("select * from data_printlog where ls_code='"+s+"'");
                
            }
            return dt;

        }

        /// <summary>
        /// 输入字符的安全检测
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool isSafe(string s)
        {
            //  过滤@"[-|;|,|\/||||\}|\{|%|@|\*|!|\']"""
            if (Regex.IsMatch(s, @"[;|,|\/||||\}|\{|%|@|\*|!|\']"""))
            {
                XtraMessageBox.Show("请不要录入特殊字符");
                return false;
            }
            else { return true; }
        }

        /// <summary>
        /// 获得录入的 条码拼接字符
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string dtStr()
        {
            DataTable dt = gcProdctList.DataSource as DataTable;
            string s = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                s += " '"+dt.Rows[i]["cCode"].ToString()+"',";
            }
            s = s.Substring(0, s.Length - 1);
            return s;
        }
    }
}