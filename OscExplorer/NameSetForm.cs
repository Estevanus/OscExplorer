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
	public partial class NameSetForm : Form
	{
		public string mode = "rename";
		public string source = "";

		public MainForm mf;

		public NameSetForm()
		{
			InitializeComponent();
			textBox1.KeyUp += TextBox1_KeyUp;
		}

		private void TextBox1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Selesai();
			}
		}

		void Selesai()
		{
			if (mode == "rename")
			{
				//check if file
				if (System.IO.File.Exists(source))
				{
					Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(source, textBox1.Text);
				}

				//check if directory
				if (System.IO.Directory.Exists(source))
				{
					Microsoft.VisualBasic.FileIO.FileSystem.RenameDirectory(source, textBox1.Text);
				}
			}
			else if (mode == "createFile")
			{
				System.IO.FileStream F = System.IO.File.Create(source + "/" + textBox1.Text);
				F.Close();
			}
			else if (mode == "createFolder")
			{
				System.IO.Directory.CreateDirectory(source + "/" + textBox1.Text);
			}

			mf.GetDirItems();

			Close();
		}


		private void DoneButton_Click(object sender, EventArgs e)
		{
			Selesai();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
