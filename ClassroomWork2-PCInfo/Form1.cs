using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ClassroomWork2_PCInfo
{
    
    public partial class Form1 : Form
    {
        
        Form diskForm = null;
        Form fileForm = null;


        public Form1()
        {
            InitializeComponent();
            this.Height = 500;
            this.Width = 500;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void toolStripMenuDisk_Click(object sender, EventArgs e)
        {
            if (diskForm == null)
            {
                diskForm = new DiskForm();
                diskForm.Show();
            }
            else
            {
                if (MessageBox.Show(
                    "Закрыть окно ?", "Окно уже открыто",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    diskForm.Close();
                    diskForm = null;
                }
            }
        }

        private void toolStripMenuFile_Click(object sender, EventArgs e)
        {
            if (fileForm == null)
            {
                fileForm = new FileForm();
                fileForm.Show();
            }
            else
            {
                if (MessageBox.Show(
                    "Закрыть окно ?", "Окно уже открыто",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    fileForm.Close();
                    fileForm = null;
                }
            }
        }
    }
    }

