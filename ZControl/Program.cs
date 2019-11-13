using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZControl
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //BeginRun();
        }
        static void BeginRun()
        {

           
            Application.Run(new Form1());

        }
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs e)
        {
            //ZControl, 嵌入dll资源在libs文件夹下，所以这里用的命名空间为： ZControl.libs.
            string _resName = "ZControl.lib." + new AssemblyName(e.Name).Name + ".dll";
            using (var _stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_resName))
            {
                byte[] _data = new byte[_stream.Length];
                _stream.Read(_data, 0, _data.Length);
                return Assembly.Load(_data);
            }
        }

    }
}
