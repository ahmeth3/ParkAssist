using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace ParkAssist
{
	public partial class oAplikaciji : UserControl
	{
		public oAplikaciji()
		{
			InitializeComponent();
            string appDir = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase);
            webBrowser1.Url = new Uri(Path.Combine(appDir, @"New folder\uputstvo.html"));
        }
	}
}
