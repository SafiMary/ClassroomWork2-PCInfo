using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClassroomWork2_PCInfo
{
    public partial class DiskForm : Form
    {
        int counter = 0;
        DriveInfo[] allDrives = DriveInfo.GetDrives();
       
        public DiskForm()
        {
            InitializeComponent();
            comboBoxDisk.Items.AddRange(new string[] {@"D:\" ,@"C:\" , @"E:\" });
            this.Height = 500;
            this.Width = 500;
        }

        private void comboBoxDisk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DiskForm_Load(object sender, EventArgs e)
        {
           
            timer1.Interval = 10;
            progressBarDisk.Minimum = 0;
            progressBarDisk.Maximum = 100;
            toolTip1.IsBalloon = true;
        }
        private void GetDriveInfo(DriveInfo drive)
        {
   
                if (drive.IsReady == true)
                {
                    label2.Text = string.Format("Имя диска: " + drive.Name);
                    label3.Text = string.Format("Объем доступного свободного места : " + СonversionTogigabytes(drive.AvailableFreeSpace) + " ГБ");
                    label4.Text = string.Format("Размер диска: " + СonversionTogigabytes(drive.TotalSize) + " ГБ");
                    label5.Text = string.Format("Занято на диске: " + СonversionBusyonDisk(drive.AvailableFreeSpace, drive.TotalSize) + " ГБ");
                    label6.Text = "Объем свободного места: " + ValueDisk(drive.TotalSize, drive.AvailableFreeSpace).ToString() + " ГБ";
                    toolTip1.SetToolTip(progressBarDisk, "Диск: " + drive.Name + "Объем свободного места: "
                        + СonversionTogigabytes(drive.AvailableFreeSpace) + " ГБ");
                    progressBarDisk.Value = (((int)ValueDisk(drive.TotalSize, drive.AvailableFreeSpace)));
                }
           
        }

        private double СonversionTogigabytes(long _byte)//конвертация в гб
        {
            return Math.Round((((double)_byte / 1024) / 1024) / 1024, 1);
        }
        private double СonversionBusyonDisk(long _byte, long _byte2)//получение сколько занято на диске
        {
            long res;
            res = _byte2 - _byte;

            return СonversionTogigabytes(res);
        }
        private double ValueDisk(long _byte, long _byte2)
        {
            long res, res2;
            res = _byte / 100;
            res2 = _byte2 / res;
            return (double)res2;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            foreach (DriveInfo drive in allDrives)
            {
                if (comboBoxDisk.SelectedIndex == 0)
                {
                    if (drive.Name == @"D:\")
                    {
                        GetDriveInfo(drive);
                      
                    }
                   
                }
                if (comboBoxDisk.SelectedIndex == 1 )
                {
                    if (drive.Name == @"C:\")
                    {
                        GetDriveInfo(drive);
                     
                    }
                    
                }
                if (comboBoxDisk.SelectedIndex == 2)
                {
                        if (drive.Name == @"E:\")
                        {
                            GetDriveInfo(drive);
                        
                        }
 
                }
                
            }
            if (counter == 10)
            {
                timer1.Stop();
            }

        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }
    }
}
