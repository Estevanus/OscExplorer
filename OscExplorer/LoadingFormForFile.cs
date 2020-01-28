using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OscExplorer
{
	public partial class LoadingFormForFile : Form
	{
		public LoadingFormForFile()
		{
			InitializeComponent();
		}

		private void LoadingFormForFile_Load(object sender, EventArgs e)
		{

		}

		private void Button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			MainForm.mf.GetFiles();
			Close();
		}
	}
}
