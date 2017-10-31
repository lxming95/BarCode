using Allsoft.BarCode.Print;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace Allsoft.BarCode.JC
{
    public partial class FrmCutBarCodePrint : DevExpress.XtraEditors.XtraForm
    {
        //设置窗口的基本信息
        public SerialPort port1 = new SerialPort();
        public FrmCutBarCodePrint()
        {
            InitializeComponent();
        }
        public FrmCutBarCodePrint(string code)
        {
            InitializeComponent();

        }


        private void FrmCutBarCodePrint_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = SqlHelper.Table("SELECT * FROM Data_Planing");
            this.gcPlanList.DataSource = dt;


            txtTeam.Properties.DataSource = SqlHelper.Table("select cEnumValue from AA_Enum where cEnumType='基材成品班组'");                //查询班组字段
            txtTeam.Properties.DisplayMember = "cEnumValue";                                                                                 //绑定显示班组组名
            txtProductionstaff.Properties.DataSource = SqlHelper.Table("select cEnumValue from AA_Enum where cEnumType='基材成品生产人员'"); //查询生产人员字段
            txtProductionstaff.Properties.DisplayMember = "cEnumValue";                                                                      //绑定显示生产人员组名
            txtQualityInspector.Properties.DataSource = SqlHelper.Table("select cEnumValue from AA_Enum where cEnumType='基材成品质检员'");  //查询质检员字段
            txtQualityInspector.Properties.DisplayMember = "cEnumValue";
            txtPrintModel.Properties.DataSource = SqlHelper.Table("select lable_name FROM sys_lable WHERE lable_name LIKE '基材%'");                  //查询基材模版字段
            txtPrintModel.Properties.DisplayMember = "lable_name";
            //大轴条码输入框得到焦点
            txtReReelNum.Focus();
        }

        private void gvPlanList_DoubleClick(object sender, EventArgs e)
        {
            clear();
            SelectRow();
        }

        private void gvPlanList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            clear();
            SelectRow();
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

        private void btnPrintBarCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //根据模版类型，取label表中的sys_lable字段，根据字段，取模版名称（label file name）。
            if (txtPrintModel.Text == "")
            {
                XtraMessageBox.Show("请选择模版后打印");
                return;
            }
            string labelname = FindLabel(txtPrintModel.Text);
                DataTable dt = insert();
                easyReport1.SetReportDataSource(dt);                                                                            //打印控件绑定数据源
                easyReport1.SetReportFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "label\\"+labelname); //设置打印控件模版
                //easyReport1.CreateReport();                                                                                   //创建初始化模版
                easyReport1.PrintReport(false, false, true, false);

        }

        private void btnPrintList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = insert();
            easyReport1.SetReportDataSource(dt);                                                                            //打印控件绑定数据源
            easyReport1.SetReportFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "label\\CutBarCode.mb"); //设置打印控件模版
            //easyReport1.CreateReport();                                                                                   //创建初始化模版
            easyReport1.PrintReport(false, false, true, false);
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clear();
        }
        /// <summary>
        /// 将焦点行的数据带入到窗体控件中
        /// </summary>
        private void SelectRow()
        {
            DataRow row = gvPlanList.GetDataRow(gvPlanList.FocusedRowHandle);
            //txtReReelNum.Text = row["cProductName"].ToString();   //原始轴号
            //txtBarCode.Text = row["cProductName"].ToString();     //整理后轴号
            //txtSource.Text = row["cProductName"].ToString();      //大轴来源
            txtProductName.Text = row["cProductName"].ToString();   //产品名称
            txtThickness.Text = row["cThickness"].ToString();       //厚度
            txtWidth.Text = row["cWidth"].ToString();               //宽度
            //txtRealLen.Text = row["cCode"].ToString();            //实长
            txtReelWeight.Text = row["cReelWeight"].ToString();     //轴芯重量
            //txtDescription_Ills.Text = row["cReel"].ToString();   //弊病描述
            //txtCheckResults.Text = row["cCode"].ToString();       //检验年结论

            //规格长度
            txtModelLen.Text = row["cSortModel"].ToString() == "" ? "" : row["cSortModel"].ToString().Split('*')[1];
            
            //txtWeight.Text = row["cCode"].ToString();             //净重
            //cbUse.Text = row["cCode"].ToString();                 //去向
            //txtProductionDate.Text = row["cCode"].ToString();     //生产日期
            //txtTeam.Text = row["cCode"].ToString();               //班组
            //txtProductionstaff.Text = row["cCode"].ToString();    //生产人员
            //txtQualityInspector.Text = row["cCode"].ToString();   //质检员
            //txtTrayNum.Text = row["cCode"].ToString();            //托盘号
            //txtMatters.Text = row["cCode"].ToString();            //交班事项
            //txtOthers.Text = row["cCode"].ToString();             //其他
            //cbPrintModel.Text = row["cCode"].ToString();          //打印模版


            txtCode.Text = row["cCode"].ToString();                 //工单号
            //txtModel.Text = row["cModelName"].ToString();         //产品型号
            txtReModel.Text = row["cModelName"].ToString();         //原型号
            txtReThickness.Text = row["cThickness"].ToString();     //原厚度
            //txtReRealLen.Text = row["cCode"].ToString();          //原实长
            txtReFinshedLen.Text = row["cLength"].ToString();       //原成品长度
            txtReWidth.Text = row["cWidth"].ToString();             //原宽度
            cbLayer.Text = row["cLayer"].ToString();                //涂层
            cbCorona.Text = row["cCorona"].ToString();              //电晕情况
            cbEmbossed.Text = row["cEmbossed"].ToString();          //压花
            //txtReCheckResults.Text = row["cCode"].ToString();     //原检验结论

            //txtFProductionDate.Text = "";                         //查询条件-生产日期
            //txtFCode.Text = "";                                   //查询条件-工单号
            //txtFCustomer.Text = "";                               //查询条件-客户
            //txtFProductName.Text = "";                            //查询条件-产品名称
        }
        /// <summary>
        /// 将数据插入到data_paintlog（标签表）表中，打印的时调用此函数
        /// </summary>
        /// <returns></returns>
        private DataTable insert()
        {
            #region 将数据制作成SqlParameter
            DataRow row = gvPlanList.GetDataRow(gvPlanList.FocusedRowHandle);
            List<SqlParameter> ilistStr = new List<SqlParameter> {
                    new SqlParameter("print_sheetcode", txtBarCode.Text),          //整理后轴号
                    new SqlParameter("pg_sheetcode", txtReReelNum.Text),           //原始轴号
                    new SqlParameter("g_scbh", txtCode.Text),                      //工单号
                    //new SqlParameter("pg_madein", txtCode.Text),                 //物流号
                    new SqlParameter("g_code", row["cFProductCode"].ToString()),   //产品编码
                    new SqlParameter("g_name", txtProductName.Text),               //产品名称
                    new SqlParameter("g_enname", txtModel.Text),                   //产品型号
                    new SqlParameter("g_stockspec", txtSource.Text),               //大轴来源
                    new SqlParameter("g_zxname", row["cReel"].ToString()),         //轴心
                    new SqlParameter("pip_length", txtReRealLen.Text),             //原实长
                    new SqlParameter("g_zs", txtReCheckResults.Text),              //原检验结论
                    new SqlParameter("g_jd", cbCorona.Text),                       //电晕情况
                    new SqlParameter("g_sz", txtCheckResults.Text),                //检验结论
                    new SqlParameter("g_power", txtModel.Text),                    //型号
                    new SqlParameter("g_fa", txtReModel.Text),                     //原型号
                    new SqlParameter("g_bz", cbLayer.Text),                        //涂层
                    new SqlParameter("g_sellspec", txtDescription_Ills.Text),      //弊病描述
                    new SqlParameter("ku_code", cbUse.Text),                       //去向
                    new SqlParameter("g_rl", txtTeam.Text),                        //班组
                    new SqlParameter("g_ndcl", txtProductionstaff.Text),           //生产人员
                    new SqlParameter("g_sxcc", txtQualityInspector.Text),          //质检员
                    new SqlParameter("g_cgmj", row["cInspectionStandards"].ToString()), //检验标准
                    new SqlParameter("g_wkcl",  row["cPacking"].ToString()),       //包装方式
                    new SqlParameter("g_zjcl", cbEmbossed.Text),                   //压花
                    new SqlParameter("g_edyl", "成品"),                            //产品类别
                    new SqlParameter("g_ccdcode", txtBarCode.Text),                //轴的条码号
                    new SqlParameter("g_amount", txtWeight.Text),                  //净重
                    new SqlParameter("uf_bz", txtMatters.Text),                    //交班事项
                    //new SqlParameter("ls_code", txtCode.Text),                   //托号
                    new SqlParameter("lingshu", txtReThickness.Text),              //原厚度
                    new SqlParameter("zhangshu", txtReFinshedLen.Text),            //原正品长度
                    new SqlParameter("changdu", txtRealLen.Text),                  //实长
                    new SqlParameter("kuandu", txtReWidth.Text),                   //原宽度
                    //new SqlParameter("p_enddate", ""),                           //作废日期
                    //new SqlParameter("p_endcode", ""),                           //作废人

                    //new SqlParameter("made_date", txtCode.Text),                 //生产日期
                    //new SqlParameter("qc_flag", txtCode.Text),                   //是否期初
                    new SqlParameter("g_touqidu", txtThickness.Text),              //厚度
                    new SqlParameter("g_guangzhong", txtWidth.Text),               //宽度
                    new SqlParameter("g_zenzhongl", txtModelLen.Text),             //规格长度
                    new SqlParameter("kh_name", row["cCustomer"].ToString()),      //客户名称
                    new SqlParameter("rk_amount", txtWeightNum.Text),              //重量

                    new SqlParameter("print_date", DateTime.Now.ToString("d")),    //打印日期&制单日期
                    new SqlParameter("print_time", DateTime.Now.ToString()),       //打印时间&制单时间
                    new SqlParameter("print_user", Pub.PubValue.UserName),         //打印人&制单人
                   // new SqlParameter("do_flag", txtCode.Text),           //在库状态

                };
            ilistStr.Add(new SqlParameter("cInvStd",row["cSortModel"].ToString()));                 //添加规格型号
            #endregion


            if (cbInStock.Checked == false)
            {
                ilistStr.Add(new SqlParameter("do_flag", "1"));
                SqlParameter[] param = ilistStr.ToArray();
                SqlHelper.ExecuteNonQuery("INSERT INTO data_printlog"
                    + " (print_sheetcode,pg_sheetcode,g_scbh,pg_madein,g_code,g_name,g_enname,g_stockspec,g_zxname,pip_length,g_zs,g_jd,g_sz,g_power,g_fa,g_bz,g_sellspec,ku_code,g_rl,g_ndcl,g_sxcc,g_cgmj,g_wkcl,g_zjcl,g_edyl,g_ccdcode,g_amount,uf_bz,lingshu,zhangshu,changdu,kuandu,made_date,qc_flag,g_touqidu,g_guangzhong,g_zenzhongl,kh_name,rk_amount,print_date,print_time,print_user,do_flag)"
                    + " VALUES(@print_sheetcode,@pg_sheetcode,@g_scbh,@pg_madein,@g_code,@g_name,@g_enname,@g_stockspec,@g_zxname,@pip_length,@g_zs,@g_jd,@g_sz,@g_power,@g_fa,@g_bz,@g_sellspec,@ku_code,@g_rl,@g_ndcl,@g_sxcc,@g_cgmj,@g_wkcl,@g_zjcl,@g_edyl,@g_ccdcode,@g_amount,@uf_bz,@lingshu,@zhangshu,@changdu,@kuandu,@made_date,@qc_flag,@g_touqidu,@g_guangzhong,@g_zenzhongl,@kh_name,@rk_amount,@print_date,@print_time,@print_user,@do_flag)", param);
                //查询插入后的数据
                param = new SqlParameter[] { new SqlParameter("cCode", txtReReelNum.Text), };
                return SqlHelper.Table("select * from data_printlog where g_scbh=@cCode", param);
            }
            else
            {
                ilistStr.Add(new SqlParameter("do_flag", "2"));                 //在库状态
                ilistStr.Add(new SqlParameter("cWareHouseCode", "0"));          //添加仓库编码
                ilistStr.Add(new SqlParameter("cWareHouseName", "0"));          //添加仓库名称
                //ilistStr.Add(new SqlParameter("cInvStd", "0"));                 //添加规格型号
                ilistStr.Add(new SqlParameter("iInQuantity", "1"));             //添加入库数量

                if (cbIsBeginning.Checked == true)
                {
                    ilistStr.Add(new SqlParameter("qc_flag", "1"));             //是否期初
                    ilistStr.Add(new SqlParameter("cVoucherType", "期初"));     //添加收发存类型为期初
                    ilistStr.Add(new SqlParameter("bQiChu", "1"));              //添加收发存标识位为期初
                }
                else
                {
                    ilistStr.Add(new SqlParameter("qc_flag", "0"));             //是否期初
                    ilistStr.Add(new SqlParameter("cVoucherType", "入库"));     //添加收发存类型为入库
                    ilistStr.Add(new SqlParameter("bQiChu", "0"));              //添加收发存标识位为其他
                }
                SqlParameter[] param = ilistStr.ToArray();
                SqlHelper.ExecuteNonQuery("INSERT INTO data_printlog"
                    + " (g_zjcl,g_scbh,pg_sheetcode,g_name,g_enname,g_touqidu,g_guangzhong,g_zenzhongl,changdu,g_bz,g_zxname,g_amount,made_date,g_rl,g_ndcl,g_sxcc,print_date,print_time,print_user,do_flag,qc_flag)"
                    + " VALUES(@cEmbossed,@cCode,@cReelNum,@cProductName,@cModelName,@cThickness,@cWidth,@cFinshedLen,@cRealLen,@cLayer,@cReel,@cWeight,@cProductionDate,@cTeam,@cProductionstaff,@cQualityInspector,@print_date,@print_time,@print_user,@do_flag,@bQiChu)"
                    + "INSERT INTO Data_SFCReoprt"
                    + " (cVoucherType,cBarCode,cWareHouseCode,cWareHouseName,cInvCode,cInvName,cInvStd,iInQuantity,cMaker,dMakeDate,bQiChu)"
                    + " VALUES(@cVoucherType,@g_ccdcode,@cWareHouseCode,@cWareHouseName,@g_scbh,@g_name,@cInvStd,@iInQuantity,@print_user,@print_time,@bQiChu)", param);


                //查询插入后的数据
                param = new SqlParameter[] { new SqlParameter("cCode", this.txtCode.Text), };
                return SqlHelper.Table("select * from data_printlog where g_scbh=@cCode", param);
            }
            
        }
        /// <summary>
        /// 清空form 数据
        /// </summary>
        private void clear()
        {
            cbInStock.Checked = false;       //清空按钮选择-在库选择
            cbIsBeginning.Checked = false;   //清空按钮选择-期初选择
            txtReReelNum.Text = "";          //原始轴号
            txtBarCode.Text = "";            //整理后轴号
            txtSource.Text = "";             //大轴来源
            txtProductName.Text = "";        //产品名称
            txtThickness.Text = "";          //厚度
            txtWidth.Text = "";              //宽度
            txtRealLen.Text = "";            //实长
            txtReelWeight.Text = "";         //轴芯重量
            txtDescription_Ills.Text = "";   //弊病描述
            txtCheckResults.Text = "";       //检验年结论
            txtModelLen.Text = "";           //规格长度
            txtWeight.Text = "";             //净重
            cbUse.Text = "";                 //去向
            txtProductionDate.Text = "";     //生产日期
            txtTeam.Text = "";               //班组
            txtProductionstaff.Text = "";    //生产人员
            txtQualityInspector.Text = "";   //质检员
            txtTrayNum.Text = "";            //托盘号
            txtMatters.Text = "";            //交班事项
            txtOthers.Text = "";             //其他
            txtPrintModel.Text = "";          //打印模版


            txtCode.Text = "";               //工单号
            txtModel.Text = "";              //产品型号
            txtReModel.Text = "";            //原型号
            txtReThickness.Text = "";        //原厚度
            txtReRealLen.Text = "";          //原实长
            txtReFinshedLen.Text = "";       //原成品长度
            txtReWidth.Text = "";            //原宽度
            cbLayer.Text = "";               //图层
            cbCorona.Text = "";              //电晕情况
            cbEmbossed.Text = "";            //压花
            txtReCheckResults.Text = "";     //原检验结论
            txtWeightNum.Text = "";          //称重数据
            txtFProductionDate.Text = "";    //查询条件-生产日期
            txtFCode.Text = "";              //查询条件-工单号
            txtFCustomer.Text = "";          //查询条件-客户
            txtFProductName.Text = "";       //查询条件-产品名称
        }

        private void btnOpenCOM_Click(object sender, EventArgs e)
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
        /// <summary>
        /// 称重函数
        /// </summary>
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
                    XtraMessageBox.Show(ex.Message);
                    if (port1.IsOpen)
                    {
                        port1.Close();
                    }
                    break;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("请检查电子称是否正常运行！"+ex.Message);
                    //timer1.Enabled = false;
                    port1.Close();
                    break;
                }
            }
        }

        private string FindLabel(string name)
        {
            SqlParameter[] param = { new SqlParameter("name", name), };
            return SqlHelper.Table("select label_filename from sys_lable where lable_name=@name", param).Rows[0]["label_filename"].ToString();
        }
    }
}