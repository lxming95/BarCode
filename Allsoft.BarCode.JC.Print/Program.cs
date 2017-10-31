using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Windows.Forms;

namespace Allsoft.BarCode.JC.Print
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //Application.Run(new FrmProductPlaning());
            //Application.Run(new FrmProductPlaningList());
            //Application.Run(new FrmCutProductPlan("F321456"));
            //Application.Run(new FrmBigBarCodePrint());
            //Application.Run(new FrmBigBarCodePrintList());
            //Application.Run(new FrmCutBarCodePrint());
            Application.Run(new FrmTuoPanPrint());
        }
    }
}
