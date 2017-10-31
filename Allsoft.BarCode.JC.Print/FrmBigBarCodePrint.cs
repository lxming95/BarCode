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
using System.Data.SqlClient;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Configuration;

namespace Allsoft.BarCode.JC
{
    public partial class FrmBigBarCodePrint : DevExpress.XtraEditors.XtraForm
    {
        //设置窗口的基本信息
        public SerialPort port1 = new SerialPort();
        public FrmBigBarCodePrint()
        {
            InitializeComponent();
        }

        private void FrmBigBarCodePrint_Load(object sender, EventArgs e)
        {

            
            DataTable dt = new DataTable();
            dt = SqlHelper.Table("SELECT * FROM Data_Planing");
            this.gcPlanList.DataSource = dt;

            BindData();


        }

        private void gvPlanList_DoubleClick(object sender, EventArgs e)
        {
            clear();
            SelectRow();
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.txtCode.Text = "";
            clear();
            
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.txtCode.Text=="")
            {
                XtraMessageBox.Show("请选择某项之后再打印");
                return;
            }
            if (this.txtReel.Text == ""|| this.txtRealLen.Text == "" || this.txtReelNum.Text == "" || this.txtProductionDate.Text == "" || this.txtTeam.Text == "" || this.txtProductionstaff.Text == "" || this.txtQualityInspector.Text == "")
            {
                XtraMessageBox.Show("请填写完整之后再打印");
                return;
            }
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("cCode", this.txtCode.Text), };
            DataTable dt = SqlHelper.Table("select * from data_printlog where g_scbh=@cCode", param);

            //if (dt.Rows.Count>0)
            //{
            //    XtraMessageBox.Show("已经打印过");
            //    return;
            //}
            //"cProductionDate,cQualityInspector,cProductionstaff,cTeam,cEmbossed,cLayer,cRealLen,cFinshedLen,cWidth,cThickness,cModelName,cWeight,cReel,cWeightNum,cProductName,cReelNum,cCode,";
            //存在数据则不插入直接打印

            if (dt.Rows.Count < 0)
            {
                dt = inset();
            }
            easyReport1.SetReportDataSource(dt);                                                                            //打印控件绑定数据源
            easyReport1.SetReportFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "label\\BigBarCode.mb"); //设置打印控件模版
            //easyReport1.CreateReport();                                                                                   //创建初始化模版
            easyReport1.PrintReport(false, false, true, false);
        }

        private void TestMethod()
        {
            while (true)
            {
                try
                {
                    if (port1.ReadLine().Length >= 10)
                    {
                        //wn00075.30kg      US,NT,+  91.10kg
                        txtWeightNum.Text = port1.ReadLine().Substring(5, 5);
                        Thread.Sleep(100);
                    }
                }
                catch (IOException ex)
                {
                    if (port1.IsOpen)
                    {
                        port1.Close();
                    }
                    break;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("请检查电子称是否正常运行！");
                    //timer1.Enabled = false;
                    port1.Close();
                    break;
                }
            }
       } 

        private void btnStartCOM_Click(object sender, EventArgs e)
        {
            // 打开串口
            port1.PortName = ConfigurationManager.AppSettings["PortName"];
            port1.BaudRate = Convert.ToInt32(ConfigurationManager.AppSettings["BautRate"]);
            port1.DataBits = Convert.ToInt32(ConfigurationManager.AppSettings["DataBits"]);
            //serialPort1.StopBits = StopBits.One;
            try
            {
                if (port1.IsOpen)
                {
                    port1.Close();
                    port1.Open(); //打开串口
                }
                else
                {
                    port1.Open();
                }
                Thread t1 = new Thread(new ThreadStart(this.TestMethod));            //根据登陆人判断扑打按钮是否可用
                t1.Start();
            }
            catch
            {
                XtraMessageBox.Show("串口打开失败！");
            }
        }

        private void btnCloseCOM_Click(object sender, EventArgs e)
        {
            if (port1.IsOpen)
            {
                port1.Close();
            }
        }

        private void txtWeightNum_TextChanged(object sender, EventArgs e)
        {
            DataRow row = gvPlanList.GetDataRow(gvPlanList.FocusedRowHandle);
            this.txtWeight.Text = (Convert.ToDecimal(txtWeightNum.Text)-Convert.ToDecimal(row["cReelWeight"])).ToString();
        }

        private void gvPlanList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            clear();
            //带入值到窗体
            SelectRow();
        }
        /// <summary>
        /// 将焦点行的值带入到上面的text控件中
        /// </summary>
        private void SelectRow()
        {
            DataRow row = gvPlanList.GetDataRow(gvPlanList.FocusedRowHandle);
            this.txtCode.Text = row["cCode"].ToString();
            this.txtThickness.Text = row["cThickness"].ToString();
            this.txtLayer.Text = row["cLayer"].ToString();
            this.txtRemarks.Text = row["cRemarks"].ToString();
            this.txtWidth.Text = row["cWidth"].ToString();
            this.txtEmbossed.Text = row["cEmbossed"].ToString();
            this.txtProductName.Text = row["cProductName"].ToString();
            this.txtFinshedLen.Text = row["cLength"].ToString();
            this.txtModelName.Text = row["cModelName"].ToString();
            this.txtWeight.Text = row["cWeight"].ToString();
            this.txtCustomer.Text= row["cCustomer"].ToString();
        }
        /// <summary>
        /// 清空界面
        /// </summary>
        private void clear()
        {
            cbInStock.Checked = false;
            cbIsRemain.Checked = false;
            cbIsBeginning.Checked = false;
            #region  循环清空
            //string name = "";//dt.Rows[0]["cLayer"] = this.txtLayer.Text;  遍历来构建打印数据，很好用
            foreach (Control c in this.Controls)
            {

                String type = c.GetType().ToString();
                switch (type)
                {
                    case "DevExpress.XtraEditors.TextEdit":
                        c.Text = "";
                        //name += "dt.Rows[0][\"c" + c.Name.Substring(3) + "\"] = this."+c.Name+ ".Text;";
                        break;
                    case "DevExpress.XtraEditors.DateEdit":
                        c.ResetText();
                        //name += "dt.Rows[0][\"c" + c.Name.Substring(3) + "\"] = this." + c.Name + ".Text;";
                        break;
                    case "DevExpress.XtraEditors.ButtonEdit":
                        c.ResetText();
                        //name += "dt.Rows[0][\"c" + c.Name.Substring(3) + "\"] = this." + c.Name + ".Text;";
                        break;
                }
            }
            this.Refresh();
            #endregion
        }

        private void cbIsBeginning_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsBeginning.Checked == true)
            {
                cbInStock.Checked = true;
                cbInStock.Enabled = false;
            }
            if (cbIsBeginning.Checked == false)
            {
                cbInStock.Checked = false;
                cbInStock.Enabled = true;
            }
        }
        /// <summary>
        /// 将数据插入到data_paintlog（标签表）表中，打印的时调用此函数
        /// </summary>
        /// <returns></returns>
        private DataTable inset()
        {
            #region 将数据制作成SqlParameter
            //DataRow row = gvPlanList.GetDataRow(gvPlanList.FocusedRowHandle);
            List<SqlParameter> ilistStr = new List<SqlParameter> {
                    new SqlParameter("cFProductName", this.txtFProductName.Text),               //查询条件-产品名称
                    new SqlParameter("cFCustomer", this.txtFCustomer.Text),                     //查询条件-客户
                    new SqlParameter("cFProductionDate", this.txtFProductionDate.Text),         //查询条件-生产日期
                    new SqlParameter("cFCode", this.txtFCode.Text),                             //查询条件-工单号
                    new SqlParameter("cProductionDate", this.txtProductionDate.Text),           //生产日期
                    new SqlParameter("cQualityInspector", this.txtQualityInspector.Text),       //质检员
                    new SqlParameter("cProductionstaff", this.txtProductionstaff.Text),         //生产人员
                    new SqlParameter("cTeam", this.txtTeam.Text),                               //生产班组
                    new SqlParameter("cEmbossed", this.txtEmbossed.Text),                       //压花
                    new SqlParameter("cLayer", this.txtLayer.Text),                             //图层
                    new SqlParameter("cRealLen", Convert.ToDecimal(this.txtRealLen.Text)),      //实际长度
                    new SqlParameter("cFinshedLen", Convert.ToDecimal(this.txtFinshedLen.Text)),//正品长度
                    new SqlParameter("cWidth", Convert.ToDecimal(this.txtWidth.Text)),          //宽度
                    new SqlParameter("cThickness", Convert.ToDecimal(this.txtThickness.Text)),  //厚度
                    new SqlParameter("cModelName", this.txtModelName.Text),                     //产品型号
                    new SqlParameter("cWeight", Convert.ToDecimal(this.txtWeight.Text)),        //净重
                    new SqlParameter("cReel", this.txtReel.Text),                               //轴芯
                    new SqlParameter("cWeightNum", this.txtWeightNum.Text),                     //称重数据
                    new SqlParameter("cCustomer", this.txtCustomer.Text),                       //客户
                    new SqlParameter("cProductName", this.txtProductName.Text),                 //产品名称
                    new SqlParameter("cReelNum", this.txtReelNum.Text),                         //轴号
                    new SqlParameter("cCode", this.txtCode.Text),                               //工单号
                    new SqlParameter("print_date", DateTime.Now.ToString("d")),                 //打印日期&制单日期
                    new SqlParameter("print_time", DateTime.Now.ToString()),                    //打印时间&制单时间
                    new SqlParameter("print_user", Pub.PubValue.UserName),                      //打印人&制单人
                };
            #endregion
            if (cbInStock.Checked == false)
            {
                ilistStr.Add(new SqlParameter("do_flag", "1"));
                SqlParameter[] param = ilistStr.ToArray();
                SqlHelper.ExecuteNonQuery("INSERT INTO data_printlog"
                    + " (g_scbh,pg_sheetcode,g_name,g_enname,g_touqidu,g_guangzhong,g_zenzhongl,changdu,g_bz,g_zxname,g_amount,made_date,g_rl,g_ndcl,g_sxcc,print_date,print_time,print_user,do_flag)"
                    + " VALUES( @cCode,@cReelNum,@cProductName,@cModelName,@cThickness,@cWidth,@cFinshedLen,@cRealLen,@cLayer,@cReel,@cWeight,@cProductionDate,@cTeam,@cProductionstaff,@cQualityInspector,@print_date,@print_time,@print_user,@do_flag)", param);
                //查询插入后的数据
                param = new SqlParameter[] { new SqlParameter("cCode", this.txtCode.Text), };
                return SqlHelper.Table("select * from data_printlog where g_scbh=@cCode", param);
            }
            else
            {
                ilistStr.Add(new SqlParameter("do_flag", "2"));                 //在库状态
                ilistStr.Add(new SqlParameter("cWareHouseCode", "0"));          //添加仓库编码
                ilistStr.Add(new SqlParameter("cWareHouseName", "0"));          //添加仓库名称
                ilistStr.Add(new SqlParameter("cInvStd", "0"));                 //添加规格型号
                ilistStr.Add(new SqlParameter("iInQuantity", "1"));             //添加入库数量
                //根据期初的选择状态添加数据
                if (cbIsBeginning.Checked == true)                              //期初为选择状态
                {
                    ilistStr.Add(new SqlParameter("cVoucherType", "期初"));     //添加收发存类型为期初
                    ilistStr.Add(new SqlParameter("bQiChu", "1"));              //添加收发存标识位为期初
                }
                else                                                            //期初为选择状态
                {
                    ilistStr.Add(new SqlParameter("cVoucherType", "入库"));     //添加收发存类型为入库
                    ilistStr.Add(new SqlParameter("bQiChu", "0"));              //添加收发存标识位为其他
                }
                SqlParameter[] param = ilistStr.ToArray();

                SqlHelper.ExecuteNonQuery("INSERT INTO data_printlog"
                    + " (g_zjcl,g_scbh,pg_sheetcode,g_name,g_enname,g_touqidu,g_guangzhong,g_zenzhongl,changdu,g_bz,g_zxname,g_amount,made_date,g_rl,g_ndcl,g_sxcc,print_date,print_time,print_user,do_flag,qc_flag)"
                    + " VALUES(@cEmbossed,@cCode,@cReelNum,@cProductName,@cModelName,@cThickness,@cWidth,@cFinshedLen,@cRealLen,@cLayer,@cReel,@cWeight,@cProductionDate,@cTeam,@cProductionstaff,@cQualityInspector,@print_date,@print_time,@print_user,@do_flag,@bQiChu)"
                    + "INSERT INTO Data_SFCReoprt"
                    + " (cVoucherType,cBarCode,cWareHouseCode,cWareHouseName,cInvCode,cInvName,cInvStd,iInQuantity,cMaker,dMakeDate,bQiChu)"
                    + " VALUES(@cVoucherType,@cReelNum,@cWareHouseCode,@cWareHouseName,@cCode,@cProductName,@cInvStd,@iInQuantity,@print_user,@print_time,@bQiChu)", param);

                //查询插入后的数据
                param = new SqlParameter[] { new SqlParameter("cCode", this.txtCode.Text), };
                return SqlHelper.Table("select * from data_printlog where g_scbh=@cCode", param);
            }
            
        }

        private void btnQuerry_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@cCode", this.txtCode.Text),
               //new SqlParameter("@dMake_time1", this.txtData1.Text), new SqlParameter("@dMake_time2", this.txtData2.Text),
               // new SqlParameter("@cThickness", this.txtThickness.Text), new SqlParameter("@cWidth", this.txtWidth.Text),
                new SqlParameter("@cCustomer", this.txtFCustomer.Text), new SqlParameter("@cProductName", this.txtFProductName.Text),
                new SqlParameter("@cCode", this.txtFCode.Text),new SqlParameter("@cProductionDate", this.txtFProductionDate.Text),
            };
            string where = "";
            if (this.txtCode.Text != "")
                where += " and cCode= @cCode";
            if (this.txtFProductionDate.Text != "")
                where += " and dMake_time ='" + this.txtFProductionDate.Text + "' ";
            if (this.txtFCustomer.Text != "")
                where += " and cCustomer=@cCustomer";
            if (this.txtFProductName.Text != "")
                where += " and cProductName=@cProductName";

            dt = SqlHelper.Table("SELECT * FROM Data_Planing AS a LEFT JOIN (SELECT Did,cCode as code,cMake_person,dMake_time,cCheck_person,dCheck_time,do_flag FROM Data_Documents) AS b ON a.cDocumentsNum = b.code where '1'='1' " + where, param);
            this.gcPlanList.DataSource = dt;
        }

        private void btnClearQuerry_Click(object sender, EventArgs e)
        {
            txtFProductionDate.Text = "";                         //查询条件-生产日期
            txtFCode.Text = "";                                   //查询条件-工单号
            txtFCustomer.Text = "";                               //查询条件-客户
            txtFProductName.Text = "";                            //查询条件-产品名称
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            txtTeam.Properties.DataSource = SqlHelper.Table("select cEnumValue from AA_Enum where cEnumType='基材大轴班组'");                      //查询班组字段
            txtTeam.Properties.DisplayMember = "cEnumValue";                                                                                     //绑定显示班组组名
            txtProductionstaff.Properties.DataSource = SqlHelper.Table("select cEnumValue from AA_Enum where cEnumType='基材大轴生产人员'");       //查询生产人员字段
            txtProductionstaff.Properties.DisplayMember = "cEnumValue";                                                                      //绑定显示生产人员组名
            txtQualityInspector.Properties.DataSource = SqlHelper.Table("select cEnumValue from AA_Enum where cEnumType='基材大轴质检员'");        //查询质检员字段
            txtQualityInspector.Properties.DisplayMember = "cEnumValue";                                                                       //绑定显示质检员组名
            //txtUse.Properties.DataSource=                 //调用NC接口绑定仓库名称
        }
    }
}