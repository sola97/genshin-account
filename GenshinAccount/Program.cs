using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenshinAccount
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new FormMain();

            // 解析参数...
            string nameValue = null;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--name" && i + 1 < args.Length)
                {
                    nameValue = args[i + 1];
                    i++;  // 跳过参数值
                }
            }

            mainForm.SwitchName = nameValue;

            Application.Run(mainForm);

    }
}
}
