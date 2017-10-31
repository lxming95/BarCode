using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using Allsoft.BarCode.Print;
using System.Configuration;

namespace Allsoft.BarCode.JC
{
    public partial class FrmCutProductPlan : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 请传入工单号，不传工单号，此界面没有任何意义，请勿调用。
        /// </summary>
        public FrmCutProductPlan()
        {
            InitializeComponent();
        }
        public FrmCutProductPlan(string code)
        {
            InitializeComponent();
            this.txtCode.Text = code;
            
        }

        private void FrmCutProductPlan_Load(object sender, EventArgs e)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@cCode", this.txtCode.Text), };
            DataTable dt = SqlHelper.Table("SELECT * FROM Data_Planing where cCode=@cCode", param);
            if (dt.Rows.Count <= 0)
            {
                XtraMessageBox.Show("没有该数据，请刷新列表后重试");
                this.Close();
            }
            else
            {
                this.txtLayer.Text = dt.Rows[0]["cLayer"].ToString();
                this.txtCustomer.Text = dt.Rows[0]["cCustomer"].ToString();
                this.txtProductName.Text = dt.Rows[0]["cProductName"].ToString();
                this.txtProductModel.Text = dt.Rows[0]["cModelName"].ToString();
                this.txtPlanNum.Text= dt.Rows[0]["iSortNum"].ToString();
                this.txtModel.Text = dt.Rows[0]["cThickness"].ToString() + "*" + dt.Rows[0]["cWidth"].ToString() + "*"+ dt.Rows[0]["cLength"].ToString();
                this.txtPackingModel.Text = dt.Rows[0]["cPackName"].ToString();
                this.txtPacking.Text = dt.Rows[0]["cPacking"].ToString();
                this.txtReel.Text = dt.Rows[0]["cReel"].ToString();
                this.txtReelLength.Text = dt.Rows[0]["cLength"].ToString();
                this.txtRollDiameter.Text= dt.Rows[0]["cRollDiameter"].ToString();
                this.txtInspectionStandards.Text = dt.Rows[0]["cInspectionStandards"].ToString();
                this.txtNotes.Text = dt.Rows[0]["cNotes"].ToString();
                this.txtPackInf.Text = dt.Rows[0]["cPackInf"].ToString();
                this.txtNotes.Text= dt.Rows[0]["cNotes"].ToString();
                this.txtPackInf.Text= dt.Rows[0]["cPackInf"].ToString();
                this.txtTemperature.Text = ConfigurationManager.AppSettings["Temperature"].ToString();
                this.txtHumidity.Text= ConfigurationManager.AppSettings["Humidity"].ToString();
                param = new SqlParameter[] { new SqlParameter("@cCode", dt.Rows[0]["cDocumentsNum"].ToString()), };
                dt = SqlHelper.Table("SELECT * FROM Data_Documents where cCode=@cCode", param);
                this.txtmaker.Text = dt.Rows[0]["cMake_person"].ToString();
                this.txtMakeTime.Text = dt.Rows[0]["dMake_time"].ToString();
                this.txtChecker.Text = dt.Rows[0]["cCheck_person"].ToString();
                this.txtCkeckTime.Text = dt.Rows[0]["dCheck_time"].ToString();
            }

        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region 创建打印数据表，并且绑定数据
            DataTable dt = new DataTable();
            dt.Columns.Add("cLayer", typeof(String));           //涂层
            dt.Columns.Add("cCustomer", typeof(String));        //顾客
            dt.Columns.Add("cProductName", typeof(String));     //产品名称 
            dt.Columns.Add("cModelName", typeof(String));       //型号
            dt.Columns.Add("PlanNum", typeof(String));          //计划数
            dt.Columns.Add("cModel", typeof(String));           //规格
            dt.Columns.Add("cPackName", typeof(String));        //包装型号
            dt.Columns.Add("cPacking", typeof(String));         //包装方式
            dt.Columns.Add("cReel", typeof(String));            //轴心
            dt.Columns.Add("cReelLength", typeof(String));      //纸轴长度
            dt.Columns.Add("cRollDiameter", typeof(String));    //卷径
            dt.Columns.Add("cInspectionStandards", typeof(String));//检验标准
            dt.Columns.Add("cNotes", typeof(String));           //记事
            dt.Columns.Add("cPackInf", typeof(String));         //包材信息
            dt.Columns.Add("cWidth", typeof(String));           //宽度范围
            dt.Columns.Add("cThickness", typeof(String));       //厚度范围
            dt.Columns.Add("cMaker", typeof(String));           //制表人
            dt.Columns.Add("cMakeTime", typeof(String));        //制表时间
            dt.Columns.Add("cChecker", typeof(String));         //审核人
            dt.Columns.Add("cCheckTime", typeof(String));       //审核时间

            dt.Rows.Add();
            dt.Rows[0]["cLayer"] = this.txtLayer.Text;
            dt.Rows[0]["cCustomer"] = this.txtCustomer.Text;
            dt.Rows[0]["cProductName"] = this.txtProductName.Text;
            dt.Rows[0]["cModelName"] = this.txtProductModel.Text;
            dt.Rows[0]["PlanNum"] = this.txtPlanNum.Text;
            dt.Rows[0]["cModel"] = this.txtModel.Text;
            dt.Rows[0]["cPackName"] = this.txtPackingModel.Text;
            dt.Rows[0]["cPacking"] = this.txtPacking.Text;
            dt.Rows[0]["cReel"] = this.txtReel.Text;
            dt.Rows[0]["cReelLength"] = this.txtReelLength.Text;
            dt.Rows[0]["cRollDiameter"] = this.txtRollDiameter.Text;
            dt.Rows[0]["cInspectionStandards"] = this.txtInspectionStandards.Text;
            dt.Rows[0]["cNotes"] = this.txtNotes.Text;
            dt.Rows[0]["cPackInf"] = this.txtPackInf.Text;
            dt.Rows[0]["cWidth"] = this.txtWidth.Text;
            dt.Rows[0]["cThickness"] = this.txtThickness.Text;
            dt.Rows[0]["cMaker"] = this.txtmaker.Text;
            dt.Rows[0]["cMakeTime"] = this.txtMakeTime.Text;
            dt.Rows[0]["cChecker"] = this.txtChecker.Text;
            dt.Rows[0]["cCheckTime"] = this.txtCkeckTime.Text;
            #endregion //
            easyReport1.SetReportDataSource(dt);                                                                            //打印控件绑定数据源
            easyReport1.SetReportFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "label\\CutPlan.mb"); //设置打印控件模版
            //easyReport1.CreateReport();                                                                                   //创建初始化模版
            easyReport1.PrintReport(false, false, true, false);
        }
    }
}