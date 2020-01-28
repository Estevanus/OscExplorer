namespace OscExplorer
{
	partial class NameSetForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.doneButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(534, 29);
			this.textBox1.TabIndex = 0;
			// 
			// doneButton
			// 
			this.doneButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.doneButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.doneButton.Location = new System.Drawing.Point(0, 29);
			this.doneButton.Name = "doneButton";
			this.doneButton.Size = new System.Drawing.Size(104, 70);
			this.doneButton.TabIndex = 1;
			this.doneButton.Text = "Done";
			this.doneButton.UseVisualStyleBackColor = true;
			this.doneButton.Click += new System.EventHandler(this.DoneButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.cancelButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelButton.Location = new System.Drawing.Point(430, 29);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(104, 70);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// NameSetForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 99);
			this.ControlBox = false;
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.doneButton);
			this.Controls.Add(this.textBox1);
			this.Name = "NameSetForm";
			this.Text = "NameSetForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button doneButton;
		private System.Windows.Forms.Button cancelButton;
	}
}