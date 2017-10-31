﻿using Allsoft.BarCode.Print;
using BarCode.BaseForm;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Allsoft.BarCode.JC
{
    public partial class FrmProductPlaning : DevExpress.XtraEditors.XtraForm
    {
        bool edit = false;
        public FrmProductPlaning()
        {
            InitializeComponent();
            txtMakePsersion.Text = Pub.PubValue.UserName;
            gvPlaning.OptionsBehavior.Editable = false;
            btnRedo.Enabled = false;
            this.btnSave.Enabled = false;
            cblist();

        }
        public FrmProductPlaning(String cCode)
        {
            InitializeComponent();
            this.txtcode.Text = cCode;
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@cCode", this.txtcode.Text), };
            DataTable dt = SqlHelper.Table("SELECT * FROM Data_Documents where cCode=@cCode", param);
            if (dt.Rows.Count<=0)
                return;
            //XtraMessageBox.Show(dt.Rows[0]["cCode"].ToString());
            if (dt.Rows[0]["do_flag"].Equals("1"))
            {
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
                btnRedo.Enabled = false;
                btnCheck.Enabled = false;
            }
            if (dt.Rows[0]["cMake_person"] != DBNull.Value)
            {
                this.txtMakePsersion.Text = dt.Rows[0]["cMake_person"].ToString();
                this.txtMakeTime.Text = Convert.ToDateTime(dt.Rows[0]["dMake_time"]).ToString("d");
                this.txtCheckPsersion.Text = dt.Rows[0]["cCheck_person"].ToString();
                this.txtCheckTime.Text = Convert.ToDateTime(dt.Rows[0]["dCheck_time"]).ToString("d");
            }
            else
            {
                this.txtMakePsersion.Text = Pub.PubValue.UserName;
            }
            gvPlaning.OptionsBehavior.Editable = false;
            btnRedo.Enabled = false;
            this.btnSave.Enabled = false;
            //下拉狂绑定
            cblist();
        }

        private void FrmProductPlaning_Load(object sender, EventArgs e)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@cDocumentsNum", this.txtcode.Text),};
            DataTable dt = SqlHelper.Table("SELECT * FROM Data_Planing where cDocumentsNum=@cDocumentsNum",param);       //查询标签数据
            gcPlaning.DataSource = dt;                                          //绑定数据源
            //this.txtMakePsersion.Text = Pub.PubValue.UserName;
            start();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.gvPlaning.AddNewRow();
            this.btnSave.Enabled = true;
            this.btnRedo.Enabled = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.gvPlaning.DeleteRow(this.gvPlaning.FocusedRowHandle);
            this.btnSave.Enabled = true;
            this.btnRedo.Enabled = true;
            start();
        }

        private void gvPlaning_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gvPlaning.GetDataRow(gvPlaning.FocusedRowHandle);
            //如果行为空或者ID字段为空可以修改
            if (row == null || !row.Table.Columns.Contains("Pid"))
            {
                gvPlaning.OptionsBehavior.Editable = true;
                return;
            }
            else if (row["Pid"] == DBNull.Value)
            {
                gvPlaning.OptionsBehavior.Editable = true;
            }
            DataTable dt = new DataTable();
            if (row["cModelName"].ToString() != "")
            {
                dt = SqlHelper.Table("SELECT cPacking FROM AA_Package WHERE cType= '" + row["cModelName"].ToString() + "' ");

            }
            else
            {
                dt = SqlHelper.Table("SELECT cPacking FROM AA_Package");
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbPacking.Items.Add(dt.Rows[i]["cPacking"]);
            }
        }

        private void gvPlaning_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!edit)
            {
                DataRow row = gvPlaning.GetDataRow(gvPlaning.FocusedRowHandle);
                //如果行为空或者ID字段为空可以修改
                if (row == null||!row.Table.Columns.Contains("Pid"))
                {
                    e.Cancel = false;
                    return;
                }
                else if(row["Pid"] == DBNull.Value)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnCut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow row = gvPlaning.GetDataRow(gvPlaning.FocusedRowHandle);
            if (row == null)
            {
                XtraMessageBox.Show(" 请选中数据");
                return;
            }
            if (!row.Table.Columns.Contains("cCode"))
            {
                XtraMessageBox.Show("选中行没有工单号");
                return;
            }
            Form frm = new FrmCutProductPlan(row["cCode"].ToString());
            frm.Show();

        }

        private void btnCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@cCode", this.txtcode.Text), };
            DataTable dt = SqlHelper.Table("SELECT * FROM Data_Documents where cCode=@cCode", param);
            if (dt.Rows[0]["do_flag"].Equals("1"))
            {
                XtraMessageBox.Show("已经审核，请勿重复提交");
                return;
            }
            btnSave_ItemClick(sender,e);
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnSave.Enabled = false;
            btnRedo.Enabled = false;
            btnCheck.Enabled = false;
            start();
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("确认删除这张数据表？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }
            SqlParameter[] param1 = new SqlParameter[] { new SqlParameter("@cCode", ""), }; //this.txtcode.Text
            SqlHelper.ExecuteNonQuery("DELETE from Data_Documents where cCode=@cCode");
            SqlHelper.ExecuteNonQuery("DELETE from Data_Planing where cDocumentsNum=@cCode");

        }

        private void btnUnapprove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@cCode", this.txtcode.Text), };
            DataTable dt = SqlHelper.Table("SELECT * FROM Data_Documents where cCode=@cCode", param);
            if (dt.Rows[0]["do_flag"].Equals("3"))
            {
                XtraMessageBox.Show("已经是弃审状态，请勿重复提交");
                return;
            }
            txtCheckPsersion.Text = "";
            txtCheckTime.Text = "";
            SqlParameter[] param1 = new SqlParameter[] { new SqlParameter("@cCode", this.txtcode.Text), };
            SqlHelper.ExecuteNonQuery("UPDATE Data_Documents SET do_flag='3',cCheck_person='',dCheck_time='' WHERE cCode=@cCode", param1);
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            //btnSave.Enabled = true;
            //btnRedo.Enabled = true;
            btnCheck.Enabled = true;
            start();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@cCode", this.txtcode.Text), };
            DataTable dt = SqlHelper.Table("SELECT * FROM Data_Documents where cCode=@cCode", param);
            if (dt.Rows.Count <= 0)
            {
                XtraMessageBox.Show("单据是新增单据，请直接编辑");
                return;
            }
            if (dt.Rows[0]["do_flag"].Equals("1"))
            {
                XtraMessageBox.Show("单据已经是审核状态无法修改");
                return;
            }
            else
            {
                gvPlaning.OptionsBehavior.Editable = true;
                edit = true;
                this.btnSave.Enabled = true;
                this.btnEdit.Enabled = false;
                btnRedo.Enabled = true;
            }
        }

        private void btnAddTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@cCode", this.txtcode.Text), };
            DataTable dt = SqlHelper.Table("SELECT * FROM Data_Documents where cCode=@cCode", param);
            if (dt.Rows.Count <= 0&&txtcode.Text!="")
            {
                XtraMessageBox.Show("单据已经是新增单据,无需新增");
                return;
            }
            if (this.btnSave.Enabled)
            {
                start();
                if (XtraMessageBox.Show("当前数据未保存，是否保存", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }
            }
            dt= SqlHelper.Table("SELECT MAX(Did) as Did FROM Data_Documents");
            decimal Did = Convert.ToDecimal(dt.Rows[0]["Did"]);
            Did += 1;
            this.txtcode.Text = DateTime.Now.ToString("yyyyMMdd")+ string.Format("{0:000}", Did);
            this.txtMakePsersion.Text = Pub.PubValue.UserName;
            this.txtCheckPsersion.Text = this.txtCheckTime.Text = this.txtMakeTime.Text="";
            this.gcPlaning.DataSource = new DataTable();
            this.btnEdit.Enabled = false;
            param = new SqlParameter[] { new SqlParameter("@cDocumentsNum", this.txtcode.Text), };
            dt = SqlHelper.Table("SELECT * FROM Data_Planing where cDocumentsNum=@cDocumentsNum", param);       //查询标签数据
            gcPlaning.DataSource = dt;
            start();
        }

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.btnSave.Enabled)
            {
                if (XtraMessageBox.Show("当前数据未保存，取消会导致当前未保存永久消失，是否继续", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }
            }
            FrmProductPlaning_Load(sender, e);
            this.btnSave.Enabled = false;
            this.btnEdit.Enabled = true;
            btnRedo.Enabled = false;
            edit = false;
            start();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvPlaning.CloseEditor();                                   //关闭编辑状态
            gvPlaning.UpdateCurrentRow();                              //更新编辑的值到数据
            gvPlaning.UpdateTotalSummary();
            this.txtMakeTime.Text= DateTime.Now.ToString();
            this.txtMakePsersion.Text= Pub.PubValue.UserName;
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@cCode", this.txtcode.Text), new SqlParameter("@cMake_person", this.txtMakePsersion.Text), new SqlParameter("@dMake_time", DateTime.Now.ToString()) };

            SqlHelper.ExecuteNonQuery("IF EXISTS(SELECT* FROM Data_Documents WHERE cCode = @cCode)"
                                        + " BEGIN"
                                        + " UPDATE Data_Documents SET cMake_person =@cMake_person, dMake_time=@dMake_time,do_flag='0' WHERE cCode = @cCode"
                                        + " END "
                                        +"ELSE "
                                        +"BEGIN "
                                        + "INSERT INTO Data_Documents(cCode,cMake_person,dMake_time,do_flag) VALUES(@cCode, @cMake_person,@dMake_time,'0')"
                                        + " END", param);

            //SqlHelper.ExecuteNonQuery("DELETE from Data_Planing where cDocumentsNum=@cCode", param);
            this.gcPlaning.RefreshDataSource();
            DataView dv = this.gvPlaning.DataSource as DataView;
            DataTable dt = this.gcPlaning.DataSource as DataTable;
            string cSequence = "";
            for (int i = 0; i < dv.Count; i++)
            {
                if (dt.Rows[i]["cSequence"] != DBNull.Value)
                    cSequence += dt.Rows[i]["cSequence"] + ",";                
            }
            cSequence = cSequence.Substring(0, cSequence.Length - 1);
            param = new SqlParameter[] { new SqlParameter("@cCode", this.txtcode.Text), new SqlParameter("@cSequence", cSequence) };
            SqlHelper.ExecuteNonQuery("DELETE from Data_Planing where cDocumentsNum=@cCode and cSequence not in (" + cSequence + ")", param);

            for (int i = 0; i < dv.Count; i++)
            {
                if (dt.Rows[i]["cSequence"]!=DBNull.Value)
                {
                    param = new SqlParameter[] { new SqlParameter("@cSequence", dt.Rows[i]["cSequence"]), new SqlParameter("@cCode", dt.Rows[i]["cCode"]),
                    new SqlParameter("@cMachhine", dt.Rows[i]["cMachhine"]),new SqlParameter("@cModel", dt.Rows[i]["cModel"]),
                    new SqlParameter("@iWindingNum", dt.Rows[i]["iWindingNum"]),new SqlParameter("@cSortModel", dt.Rows[i]["cSortModel"]),
                    new SqlParameter("@iSortNum", dt.Rows[i]["iSortNum"]),new SqlParameter("@cUse", dt.Rows[i]["cUse"]),
                    new SqlParameter("@cRequest", dt.Rows[i]["cRequest"]),new SqlParameter("@cCustomer", dt.Rows[i]["cCustomer"]),
                    new SqlParameter("@cLayer", dt.Rows[i]["cLayer"]),new SqlParameter("@cEmbossed", dt.Rows[i]["cEmbossed"]),
                    new SqlParameter("@cPacking", dt.Rows[i]["cPacking"]),new SqlParameter("@cPackInf", dt.Rows[i]["cPackInf"]),
                    new SqlParameter("@cNotes", dt.Rows[i]["cNotes"]),new SqlParameter("@cRemarks", dt.Rows[i]["cRemarks"]),
                    new SqlParameter("@cDocumentsNum", this.txtcode.Text)
                     };
                    if (dt.Rows[i]["Pid"] == DBNull.Value)
                    {
                        SqlHelper.ExecuteNonQuery("INSERT INTO Data_Planing(cSequence,cCode,cMachhine,cModel,iWindingNum,cSortModel,iSortNum,cUse,cRequest,cCustomer,cLayer,cEmbossed,cPacking,cPackInf,cNotes,cRemarks,cDocumentsNum)"
                            + " VALUES(@cSequence,@cCode,@cMachhine,@cModel,@iWindingNum,@cSortModel,@iSortNum,@cUse,@cRequest,@cCustomer,@cLayer,@cEmbossed,@cPacking,@cPackInf,@cNotes,@cRemarks,@cDocumentsNum)", param);
                    }
                    else
                    {
                        SqlHelper.ExecuteNonQuery(" UPDATE Data_Planing SET cCode=@cCode,cMachhine=@cMachhine,cModel=@cModel,iWindingNum=@iWindingNum,cSortModel=@cSortModel," +
                            "iSortNum=@iSortNum,cUse=@cUse,cRequest=@cRequest,cCustomer=@cCustomer,cLayer=@cLayer,cEmbossed=@cEmbossed,cPacking=@cPacking,cPackInf=@cPackInf,cNotes=@cNotes," +
                            "cRemarks=@cRemarks,cDocumentsNum=@cDocumentsNum WHERE cSequence = @cSequence", param);
                    }
                }
            }
            FrmProductPlaning_Load(sender, e);
            this.btnSave.Enabled = false;
            edit = false;
            this.btnEdit.Enabled = true;
            this.btnRedo.Enabled = false;
            btnAddTable.Enabled = true;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = gcPlaning.DataSource as DataTable;
            if(!dt.Columns.Contains("cMaker"))
                dt.Columns.Add("cMaker", typeof(String));
            if (!dt.Columns.Contains("cMakeTime"))
                dt.Columns.Add("cMakeTime", typeof(String));
            if (!dt.Columns.Contains("cChecker"))
                dt.Columns.Add("cChecker", typeof(String));
            if (!dt.Columns.Contains("cCheckTime"))
                dt.Columns.Add("cCheckTime", typeof(String));
            dt.Rows[0]["cMaker"] = this.txtMakePsersion.Text;
            dt.Rows[0]["cMakeTime"] = this.txtMakeTime.Text;
            easyReport1.SetReportDataSource(dt);                                                                            //打印控件绑定数据源
            easyReport1.SetReportFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "label\\PlaningTable.mb"); //设置打印控件模版
            //easyReport1.CreateReport();                                                                                   //创建初始化模版
            easyReport1.PrintReport(false,false, true, false);                                              //打印
        }

        private void btnReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gcPlaning.DataSource == null) //没有查询数据的处理
            {
                XtraMessageBox.Show("无数据，请先查询");                    //弹窗提示查询
                return;
            }
            else                                                            //查询数据之后的处理
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())    //离开后销毁对话框
                {
                    //保存文件的类型
                    saveDialog.Filter = "Excel (97-2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)  //用户点击保存按钮
                    {
                        string exportFilePath = saveDialog.FileName;        //定义文件路径              
                        string fileExtenstion = new FileInfo(exportFilePath).Extension; //创建文件

                        try
                        {
                            switch (fileExtenstion)                             //判断文件类型
                            {
                                case ".xls":
                                    gcPlaning.ExportToXls(exportFilePath);    //.xls类型
                                    break;
                                case ".xlsx":
                                    gcPlaning.ExportToXlsx(exportFilePath);   //.xlsx类型
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch
                        {
                            //文件无法打开 消息字符串 提示语+/n/n+path:+路径
                            String msg = "文件无法被创建或者修改，正在使用或者没有权限,请检查是否同名文件被打开，请尝试关闭打开文件后重试" + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            XtraMessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //转到执行保存事件
                            btnReport_ItemClick(sender,e);  //待测试替换goto;

                        }
                        //object MisValue = Type.Missing;
                        //Microsoft.Office.Interop.Excel.Workbook workbook = new Microsoft.Office.Interop.Excel.Workbook();
                        //workbook.LoadFromFile("测试.xlsx");
                        //DataSet ds;
                        //Microsoft.Office.Interop.Excel.Workbook xlsWorkbook = new Microsoft.Office.Interop.Excel.Workbook();
                        //Microsoft.Office.Interop.Excel.Worksheet xlsSheet = xlsWorkbook.Worksheets[1];
                        //Microsoft.Office.Interop.Excel.Range xlsRow = (Microsoft.Office.Interop.Excel.Range)xlsSheet.Rows[3, MisValue];
                        //xlsRow.Insert(Microsoft.Office.Interop.Excel.xlShiftDown, MisValue);

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

        private void gvPlaning_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.btnSave.Enabled = true;
            if (gvPlaning.FocusedColumn.Name == "cModelName")
            {
                DataRow row = gvPlaning.GetDataRow(gvPlaning.FocusedRowHandle);
                DataTable dt = new DataTable();
                if (row["cModelName"].ToString() != "")
                {
                    dt = SqlHelper.Table("SELECT cPacking FROM AA_Package WHERE cType= '" + row["cModelName"].ToString() + "' ");
                }
                else
                {
                    dt = SqlHelper.Table("SELECT cPacking FROM AA_Package");
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbPacking.Items.Add(dt.Rows[i]["cEnumValue"]);
                }
            }
        }
        //用于下拉框添加绑定
        private void cblist()
        {

            //收卷机下拉
            DataTable dt = SqlHelper.Table("SELECT cEnumValue FROM AA_Enum WHERE cEnumType='基材计划收卷机'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbMachhine.Items.Add(dt.Rows[i]["cEnumValue"]);
            }
            //计划颜色下拉
            dt = SqlHelper.Table("SELECT cEnumValue FROM AA_Enum WHERE cEnumType='基材计划颜色'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbColor.Items.Add(dt.Rows[i]["cEnumValue"]);
            }
            //计划轴心下拉
            dt = SqlHelper.Table("SELECT cEnumValue FROM AA_Enum WHERE cEnumType='基材计划轴芯'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbReel.Items.Add(dt.Rows[i]["cEnumValue"]);
            }
            //计划图层下拉
            dt = SqlHelper.Table("SELECT cEnumValue FROM AA_Enum WHERE cEnumType='基材计划涂层'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbLayer.Items.Add(dt.Rows[i]["cEnumValue"]);
            }
            //计划压花下拉
            dt = SqlHelper.Table("SELECT cEnumValue FROM AA_Enum WHERE cEnumType='基材计划压花'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbEmbossed.Items.Add(dt.Rows[i]["cEnumValue"]);
            }
            //计划电晕情况下拉
            dt = SqlHelper.Table("SELECT cEnumValue FROM AA_Enum WHERE cEnumType='基材计划电晕情况'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbCorona.Items.Add(dt.Rows[i]["cEnumValue"]);
            }
            //计划包装方式下拉
            //dt = SqlHelper.Table("SELECT cPacking FROM AA_Package WHERE cType='"+333+"'");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    cbPacking.Items.Add(dt.Rows[i]["cEnumValue"]);
            //}
        }
        //用于在窗体没有数据时对按钮的控制
        private void start()
        {
            DataView dv = this.gvPlaning.DataSource as DataView;
            if (dv.Count <= 0)
            {
                this.btnEdit.Enabled = false;
                btnSave.Enabled = false;
                btnDel.Enabled = false;
                //btnAddTable.Enabled = false;
                btnRedo.Enabled = false;
                btnCheck.Enabled = false;
                btnUnapprove.Enabled = false;
                btnPrint.Enabled = false;
                btnCut.Enabled = false;
                btnReport.Enabled = false;
            }
        }
        private void valueChanged()
        {
            btnSave.Enabled = true;
            btnRedo.Enabled = true;
            btnCheck.Enabled = true;
            btnUnapprove.Enabled = true;
        }

        private void btnProductCode_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            FrmRefB frm = new FrmRefB(dt);
            frm.RefCheckBox = false;
        }

        //型号的参照选择
        private void btnModelName_Click(object sender, EventArgs e)
        {
            DataRow row = gvPlaning.GetDataRow(gvPlaning.FocusedRowHandle);
            DataTable dt = SqlHelper.Table("SELECT cType as '型号' FROM AA_Package");
            FrmRefB frm = new FrmRefB(dt);
            frm.RefCheckBox = false;
            frm.ShowDialog();
            if (row != null)
            {
                if (frm.ReturnDT.Rows.Count > 0)
                {
                    if (frm.ReturnDT.Rows.Count > 1)
                        XtraMessageBox.Show("只能选取一行，请不要选取多行");
                    else if (frm.ReturnDT.Rows.Count == 1)
                        row["cModelName"] = frm.ReturnDT.Rows[0]["型号"];
                    else
                        XtraMessageBox.Show("选取数据不符合要求，请选取一行数据");
                }
            }
            gvPlaning.UpdateCurrentRow();
        }
    }
}