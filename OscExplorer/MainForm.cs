using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OscExplorer
{
	public partial class MainForm : Form
	{
		string folderIconPath = "icons/folder.ico";
		string driveIconPath = "icons/disk.ico";

		System.IO.DriveInfo[] allDrivers;
		List<string> daftarDriver = new List<string>();

		ImageList imagelist1 = new ImageList();
		ImageList iList1 = new ImageList();
		delegate void AddIList(string key, Icon icon);
		delegate void SetIL();
		Task fileThread;

		bool isJustStart = true;
		string lastPath = "";
		string[] imageFileCollection;

		//string appPath = "";

		int copyState = 0;//0 = nothing, 1 = copy, 2 = cut
		List<string> filesToCopy = new List<string>();

		public delegate void coba_delegate();
		public delegate void coba_delegate2(long indeks, int totalhread);
		public static MainForm mf;

		delegate ListViewItem AddListView(ListViewItem item);
		delegate void AddIL(System.IO.DirectoryInfo parDir);

		int curFileIndeks = 0;

		public MainForm()
		{
			InitializeComponent();

			listView1.DoubleClick += listView1_klikDuaKali;
			listView1.KeyUp += ListView1_KeyUp;

			mf = this;
		}

		private void ListView1_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Back)
				{
					if (daftarDriver.Contains(addressBox.Text))
					{
						GetDrivers();
						addressBox.Text = "";
					}
					else
					{
						System.IO.DirectoryInfo curDir = new System.IO.DirectoryInfo(addressBox.Text);
						System.IO.DirectoryInfo parDir = curDir.Parent;
						addressBox.Text = parDir.FullName;
						GetDirItems();
					}
				}
				else if (e.KeyCode == Keys.Enter)
				{
					if (listView1.SelectedItems.Count > 0)
					{
						Pembuka();
					}
				}
				else if (e.KeyCode == Keys.Delete)
				{
					DeleteFile();
				}
				else if (e.KeyCode == Keys.F5)
				{
					GetDirItems();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " \n " + ex.Source, "Something is error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				//pass
			}
		}

		void CopyFile()
		{
			foreach (ListViewItem l in listView1.SelectedItems)
			{
				filesToCopy.Add(addressBox.Text + "\\" + l.Text);
			}
			copyState = 1;
		}

		void CutFile()
		{
			foreach (ListViewItem l in listView1.SelectedItems)
			{
				filesToCopy.Add(addressBox.Text + "\\" + l.Text);
			}
			copyState = 2;
		}

		void PasteFile()
		{
			string alamat = addressBox.Text;

			LoadingForm loading = new LoadingForm();
			loading.Show();

			if (copyState == 1)
			{
				foreach (string fileToCopy in filesToCopy)
				{
					//if it's a file
					if (System.IO.File.Exists(fileToCopy))
					{
						System.IO.FileInfo sourceFile = new System.IO.FileInfo(fileToCopy);
						string tempS = alamat + "/" + sourceFile.Name;
						if (System.IO.File.Exists(tempS))
						{
							DialogResult psn = MessageBox.Show("File " + sourceFile.Name + " is already exist. Overwrite?", "File exist", MessageBoxButtons.YesNo);
							if (psn == DialogResult.OK)
							{
								System.IO.File.Copy(fileToCopy, tempS);
							}
						}
						else
						{
							System.IO.File.Copy(fileToCopy, tempS);
						}
					}

					//if it's a folder
					if (System.IO.Directory.Exists(fileToCopy))
					{
						System.IO.DirectoryInfo sourceFile = new System.IO.DirectoryInfo(fileToCopy);
						string tempS = alamat + "/" + sourceFile.Name;
						if (System.IO.Directory.Exists(tempS))
						{
							DialogResult psn = MessageBox.Show("Directory " + sourceFile.Name + " is already exist. Overwrite?", "File exist", MessageBoxButtons.YesNo);
							if (psn == DialogResult.OK)
							{
								//System.IO.Directory.Copy(fileToCopy, tempS);
								Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(fileToCopy, tempS);


							}
						}
						else
						{
							//System.IO.Directory.Copy(fileToCopy, tempS);
							Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(fileToCopy, tempS);
						}
					}
				}

				
			}
			else if (copyState == 2)
			{
				foreach (string fileToCopy in filesToCopy)
				{
					//if it's a file
					if (System.IO.File.Exists(fileToCopy))
					{
						System.IO.FileInfo sourceFile = new System.IO.FileInfo(fileToCopy);
						string tempS = alamat + "/" + sourceFile.Name;
						if (System.IO.File.Exists(tempS))
						{
							DialogResult psn = MessageBox.Show("File " + sourceFile.Name + " is already exist. Overwrite?", "File exist", MessageBoxButtons.YesNo);
							if (psn == DialogResult.OK)
							{
								System.IO.File.Move(fileToCopy, tempS);
							}
						}
						else
						{
							System.IO.File.Move(fileToCopy, tempS);
						}
					}

					//if it's a folder
					if (System.IO.Directory.Exists(fileToCopy))
					{
						System.IO.DirectoryInfo sourceFile = new System.IO.DirectoryInfo(fileToCopy);
						string tempS = alamat + "/" + sourceFile.Name;
						if (System.IO.Directory.Exists(tempS))
						{
							DialogResult psn = MessageBox.Show("Directory " + sourceFile.Name + " is already exist. Overwrite?", "File exist", MessageBoxButtons.YesNo);
							if (psn == DialogResult.OK)
							{
								//Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(fileToCopy, tempS);
								System.IO.Directory.Move(fileToCopy, tempS);


							}
						}
						else
						{
							//Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(fileToCopy, tempS);
							System.IO.Directory.Move(fileToCopy, tempS);
						}
					}
				}

				
			}

			//refreshing
			filesToCopy.Clear();
			GetDirItems();

			loading.Close();
		}

		void DeleteFile()
		{
			string tempT = addressBox.Text;

			if (listView1.SelectedItems.Count == 1)
			{
				string selectedItem = tempT + "\\" + listView1.SelectedItems[0].Text;
				DialogResult psn = MessageBox.Show("Do you really want to delete this file?\n\n" + selectedItem, "Delete File", MessageBoxButtons.YesNo);

				if (psn == DialogResult.Yes)
				{
					//check if file
					if (System.IO.File.Exists(selectedItem))
					{
						System.IO.File.Delete(selectedItem);
					}

					//check if directory
					if (System.IO.Directory.Exists(selectedItem))
					{
						//System.IO.Directory.Delete(selectedItem);
						Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(selectedItem, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);
					}
				}
			}
			else if (listView1.SelectedItems.Count > 1)
			{
				DialogResult psn = MessageBox.Show("Do you really want to delete this files?", "Delete File", MessageBoxButtons.YesNo);
				foreach (ListViewItem sel in listView1.SelectedItems)
				{
					string selectedItem = tempT + "\\" + sel.Text;
					//check if file
					if (System.IO.File.Exists(selectedItem))
					{
						System.IO.File.Delete(selectedItem);
					}

					//check if directory
					if (System.IO.Directory.Exists(selectedItem))
					{
						//System.IO.Directory.Delete(selectedItem);
						Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(selectedItem, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);
					}
				}
			}


			//refreshing
			GetDirItems();
		}

		public void RenameFile()
		{
			string tempT = addressBox.Text;
			string selectedItem = tempT + "\\" + listView1.SelectedItems[0].Text;

			NameSetForm penama = new NameSetForm();
			penama.mf = this;
			penama.textBox1.Text = listView1.SelectedItems[0].Text;
			penama.source = selectedItem;
			penama.Show();
		}

		public void CreateFile()
		{
			string tempT = addressBox.Text;

			NameSetForm penama = new NameSetForm();
			penama.mf = this;
			penama.mode = "createFile";
			penama.source = tempT;
			penama.Show();
		}

		public void CreateFolder()
		{
			string tempT = addressBox.Text;

			NameSetForm penama = new NameSetForm();
			penama.mf = this;
			penama.mode = "createFolder";
			penama.source = tempT;
			penama.Show();
		}

		public void GetDirecktories()
		{
			string arah = addressBox.Text;

			System.IO.DirectoryInfo pardir = new System.IO.DirectoryInfo(arah);

			//get daftar directory
			foreach (System.IO.DirectoryInfo dir in pardir.GetDirectories())
			{
				ListViewItem item = new ListViewItem(dir.Name);
				item.ImageKey= "folder";
				item.Text = dir.Name;
				listView1.Items.Add(item);
			}
		}

		public void GetFiles()
		{
			string arah = addressBox.Text;

			System.IO.DirectoryInfo pardir = new System.IO.DirectoryInfo(arah);

			//get daftar directory
			foreach (System.IO.FileInfo dir in pardir.GetFiles())
			{
				Icon fileIcon = System.Drawing.Icon.ExtractAssociatedIcon(dir.FullName);
				iList1.Images.Add(dir.Name, fileIcon);
				ListViewItem item = new ListViewItem(dir.Name);
				item.ImageKey = dir.Name;
				listView1.Items.Add(item);
			}
			/*
			Parallel.ForEach(pardir.GetFiles(), (dir) =>
			{
				Icon fileIcon = System.Drawing.Icon.ExtractAssociatedIcon(dir.FullName);
				iList1.Images.Add(dir.Name, fileIcon);
				ListViewItem item = new ListViewItem(dir.Name);
				item.ImageKey = dir.Name;
				listView1.Items.Add(item);
			});
			*/

		}

		public void GetFiles2(long indeks, int totalThread)
		{
			string arah = addressBox.Text;

			System.IO.DirectoryInfo pardir = new System.IO.DirectoryInfo(arah);
			System.IO.FileInfo[] files = pardir.GetFiles();
			long total = files.Count();

			long i = indeks;
			while (i < total)
			{
				System.IO.FileInfo dir = files[i];
				Icon fileIcon = System.Drawing.Icon.ExtractAssociatedIcon(dir.FullName);
				iList1.Images.Add(dir.Name, fileIcon);
				ListViewItem item = new ListViewItem(dir.Name);
				item.ImageKey = dir.Name;
				listView1.Items.Add(item);

				i = i + totalThread;
			}
		}

		public void AddIListFungtion(string key, Icon icon)
		{
			iList1.Images.Add(key, icon);
		}

		private void ImagePlacer_Tick(object sender, EventArgs e)
		{
			string arah = addressBox.Text;
			System.IO.DirectoryInfo pardir = new System.IO.DirectoryInfo(arah);
			System.IO.FileInfo[] files = pardir.GetFiles();
			if (curFileIndeks < files.Length)
			{
				System.IO.FileInfo dir = files[curFileIndeks];

				if (imageFileCollection.Contains(dir.Extension))
				{
					Bitmap fileIcon = new Bitmap(@dir.FullName);
					iList1.Images.Add(dir.Name, fileIcon);
				}
				else
				{
					Icon fileIcon = System.Drawing.Icon.ExtractAssociatedIcon(dir.FullName);
					iList1.Images.Add(dir.Name, fileIcon);
				}

				curFileIndeks++;
			}
			else
			{
				curFileIndeks = 0;
				ImagePlacer.Enabled = false;
			}
		}

		public void GetFiles3()
		{
			string arah = addressBox.Text;

			System.IO.DirectoryInfo pardir = new System.IO.DirectoryInfo(arah);

			//AddListView addListView = listView1.Items.Add;

			System.IO.FileInfo[] files = pardir.GetFiles();

			//int proCount = System.Environment.ProcessorCount;

			AddIList tambahGambar = AddIListFungtion;
			long totalFiles = files.Length;
			System.Collections.Specialized.StringCollection keys = iList1.Images.Keys;
			Action action = () =>
			{
				foreach (System.IO.FileInfo file in files)
				{
					if(keys.Contains(file.Name) == false)
					Invoke(tambahGambar, new object[] { file.Name, System.Drawing.Icon.ExtractAssociatedIcon(file.FullName) });
					Console.WriteLine(file.Name);
				}
			};

			if (fileThread == null)
			{
				fileThread = new Task(action);
				fileThread.Start();
			}
			else
			{
				if (fileThread.IsCompleted)
				{
					fileThread.Dispose();
					fileThread = new Task(action);
					fileThread.Start();
				}
				else
				{
					//kill task
				}
			}
			//Task t1 = new Task(action);
			//t1.Start();


			ListViewItem[] items1 = new ListViewItem[totalFiles];


			Parallel.For(0, totalFiles, (i) => {
				items1[i] = new ListViewItem(files[i].Name);
				items1[i].ImageKey = files[i].Name;
				//imgs.Images.Add(files[i].Name, System.Drawing.Icon.ExtractAssociatedIcon(files[i].FullName));
			});

			listView1.Items.AddRange(items1);
			//iList1.Images.AddRange(imgs.Images);

			//t1.Wait();


			curFileIndeks = 0;
			//ImagePlacer.Enabled = true;

		}

		public void SetIListImage()
		{
			string arah = addressBox.Text;
			System.IO.DirectoryInfo pardir = new System.IO.DirectoryInfo(arah);

			ImageList imgs = new ImageList();

			foreach (System.IO.FileInfo file in pardir.GetFiles())
			{
				iList1.Images.Add(file.Name, System.Drawing.Icon.ExtractAssociatedIcon(file.FullName).ToBitmap());
			}


			//iList1 = imgs;
			//listView1.LargeImageList = imgs;
			//listView1.SmallImageList = imgs;
		}

		public void GetFiles4()
		{
			string arah = addressBox.Text;
			System.IO.DirectoryInfo pardir = new System.IO.DirectoryInfo(arah);
			System.IO.FileInfo[] files = pardir.GetFiles();

			int totalFiles = files.Length;
			ListViewItem[] items1 = new ListViewItem[totalFiles];


			Parallel.For(0, totalFiles, (i) => {
				items1[i] = new ListViewItem(files[i].Name);
				items1[i].ImageKey = files[i].Name;
				//Invoke(tambahGambar, new object[] { file.Name, System.Drawing.Icon.ExtractAssociatedIcon(file.FullName) });
				//imgs.Images.Add(files[i].Name, System.Drawing.Icon.ExtractAssociatedIcon(files[i].FullName));
			});
			listView1.Items.AddRange(items1);

			SetIL tambahGambar = SetIListImage;
			Invoke(tambahGambar);
		}

		public void GetFiles5()
		{
			string arah = addressBox.Text;
			System.IO.DirectoryInfo pardir = new System.IO.DirectoryInfo(arah);
			System.IO.FileInfo[] files = pardir.GetFiles();
			long totalFiles = files.Length;


			ListViewItem[] items1 = new ListViewItem[totalFiles];

			//AddIList addIList = AddIListFungtion;

			ImageList imgs = new ImageList();
			imgs.ImageSize = new System.Drawing.Size(42, 42);
			Parallel.For(0, totalFiles, (i) => {
				items1[i] = new ListViewItem(files[i].Name);
				items1[i].ImageKey = files[i].Name;
				//imgs.Images.Add(files[i].Name, System.Drawing.Icon.ExtractAssociatedIcon(files[i].FullName).ToBitmap());
				//addIList(files[i].Name, System.Drawing.Icon.ExtractAssociatedIcon(files[i].FullName));
				//Invoke(addIList, new object[]{files[i].Name, System.Drawing.Icon.ExtractAssociatedIcon(files[i].FullName)});
			});

			listView1.Items.AddRange(items1);

			foreach (System.IO.FileInfo file in files)
			{
				imgs.Images.Add(file.Name, System.Drawing.Icon.ExtractAssociatedIcon(file.FullName).ToBitmap());

			}

			listView1.LargeImageList = imgs;
			listView1.SmallImageList = imgs;
			listView1.Update();
			//iList1.Images.Keys.AddRange(keys);
			//iList1.Images.AddRange(imgs1);
		}

		public void GetFiles6()
		{
			string arah = addressBox.Text;

			System.IO.DirectoryInfo pardir = new System.IO.DirectoryInfo(arah);

			//AddListView addListView = listView1.Items.Add;

			System.IO.FileInfo[] files = pardir.GetFiles();

			AddIList tambahGambar = AddIListFungtion;
			long totalFiles = files.Length;
			System.Collections.Specialized.StringCollection keys = iList1.Images.Keys;
			Action action = () =>
			{
				foreach (System.IO.FileInfo file in files)
				{
					if (keys.Contains(file.Name) == false)
						Invoke(tambahGambar, new object[] { file.Name, System.Drawing.Icon.ExtractAssociatedIcon(file.FullName) });
					Console.WriteLine(file.Name);
				}
			};

			/*
			 Jang lupa cari:
				Disable UI Update

			supaya tuh iList bole mo fokus di add image kong nanti refresh satu kali dp UI supaya cepat dp respon
			 */

			Parallel.Invoke(new Action[] { action});


			ListViewItem[] items1 = new ListViewItem[totalFiles];


			Parallel.For(0, totalFiles, (i) => {
				items1[i] = new ListViewItem(files[i].Name);
				items1[i].ImageKey = files[i].Name;
				//imgs.Images.Add(files[i].Name, System.Drawing.Icon.ExtractAssociatedIcon(files[i].FullName));
			});

			listView1.Items.AddRange(items1);
		}

		public void GetDirItems()
		{
			listView1.Clear();//membersihkan items dalam list view
			//iList1.Images.Clear();

			//GetDirecktories();
			coba_delegate getDir = GetDirecktories;
			getDir();
			//GetFiles();
			GetFiles6();
			//coba_delegate2 cobalah = GetFiles2;
			//Invoke(cobalah, 3, 4);
		}

		void CheckDrivers()
		{
			allDrivers = System.IO.DriveInfo.GetDrives();

			foreach (System.IO.DriveInfo d in allDrivers)
			{
				if (d.IsReady)
				{
					daftarDriver.Add(d.Name);
				}
			}
		}

		void tree_open()
		{
			if (treeView1.SelectedNode.GetNodeCount(true) == 0)
			{
				System.IO.DirectoryInfo pardir = new System.IO.DirectoryInfo(treeView1.SelectedNode.FullPath);
				foreach (System.IO.DirectoryInfo dir in pardir.GetDirectories())
				{
					treeView1.SelectedNode.Nodes.Add(dir.Name);
				}
			}

			//treeView1.SelectedNode.Expand();


			if (isJustStart)
			{
				isJustStart = false;
			}
			else
			{
				addressBox.Text = treeView1.SelectedNode.FullPath;
				GetDirItems();
			}
		}

		void tree_open_byDir()
		{
			string fullPath = addressBox.Text;
			//masih mo ada masalah ketika user memasukan fullPathnya langsung dari address box
			if (treeView1.SelectedNode.GetNodeCount(true) == 0)
			{
				System.IO.DirectoryInfo pardir = new System.IO.DirectoryInfo(fullPath);
				foreach (System.IO.DirectoryInfo dir in pardir.GetDirectories())
				{
					//treeView1..Nodes.Add(dir.Name);
					
				}
			}
		}

		void Pembuka()
		{
			string tempT = addressBox.Text;
			
			if (lastPath != tempT)
			{
				lastPath = tempT;
			}
			string selectedItem = tempT + "\\" + listView1.SelectedItems[0].Text;

			if (addressBox.Text == "")
			{
				//listView1.SelectedItems[0].Text
				addressBox.Text = listView1.SelectedItems[0].Text;
				if (daftarDriver.Contains(addressBox.Text))
				{
					GetDirItems();
					//tree_open_byDir();
				}
			}
			else
			{
				if (System.IO.Directory.Exists(selectedItem))
				{
					addressBox.Text = selectedItem;
					GetDirItems();
					//tree_open_byDir();
				}
				else
				{
					//buka file
					if (System.IO.File.Exists(selectedItem))
					{
						System.Diagnostics.Process.Start(selectedItem);
					}
					else
					{
						MessageBox.Show("File " + selectedItem + " not found", "404 File not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
					}
				}
			}
		}

		void GetDrivers()
		{
			listView1.Clear();
			treeView1.Nodes.Clear();
			foreach (string disk in daftarDriver)
			{
				Icon fileIcon = System.Drawing.Icon.ExtractAssociatedIcon(driveIconPath);
				iList1.Images.Add(disk, fileIcon);

				treeView1.Nodes.Add(disk);

				ListViewItem item = new ListViewItem(disk);
				item.Name = disk;
				item.ImageKey = disk;

				listView1.Items.Add(item);
			}
		}


		private void MainForm_Load(object sender, EventArgs e)
		{
			imageFileCollection = new string[] {".jpg", ".png" };

			iList1.ImageSize = new System.Drawing.Size(42, 42);

			treeView1.ImageList = imagelist1;
			listView1.SmallImageList = iList1;
			listView1.LargeImageList = iList1;
			listView1.BackgroundImage = Image.FromFile("D://Picture/Anime/C3/Fear Kubrick/Other/11fc23010b9194a1120134e9db383032.jpg");//nanti diganti
			listView1.BackgroundImageTiled = true;

			CheckDrivers();

			GetDrivers();

			//imagelist1.Images.Add("folder", System.Drawing.Icon.ExtractAssociatedIcon(folderIconPath));
			imagelist1.Images.Add("folder", new Icon(folderIconPath));
			//Icon icoFolder = System.Drawing.Icon.ExtractAssociatedIcon(folderIconPath);
			//iList1.Images.Add("folder", new Bitmap(@folderIconPath)); ;
			iList1.Images.Add("folder", new Icon(folderIconPath)); ;

		}

		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			tree_open();
		}

		private void listView1_klikDuaKali(object sender, System.EventArgs e)
		{
			Pembuka();

		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Pembuka();
		}

		private void LainnyaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string tempT = addressBox.Text;
			string selectedItem = tempT + "\\" + listView1.SelectedItems[0].Text;

			if (System.IO.File.Exists(selectedItem))
			{
				OpenFileDialog pb = new OpenFileDialog();
				if (pb.ShowDialog() == DialogResult.OK)
				{
					string programName = pb.FileName;

					System.Diagnostics.Process.Start(programName, "\"" + selectedItem + "\"");
					//MessageBox.Show(selectedItem);
				}

			}
			else
			{
				MessageBox.Show("It's not a file");
			}
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyFile();
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CutFile();
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PasteFile();
		}

		private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GetDirItems();
		}

		private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DeleteFile();
		}

		private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RenameFile();
		}

		private void FileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CreateFile();
		}

		private void FolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CreateFolder();
		}
	}
}
