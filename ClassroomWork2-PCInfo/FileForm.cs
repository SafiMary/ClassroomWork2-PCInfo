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
    public partial class FileForm : Form
    {
        DirectoryInfo files;
        int counter = 0;
        string download = "C:\\Users\\safim\\Downloads";
        string temp = "C:\\Users\\safim\\AppData\\Local\\Temp";
        string desktop = "C:\\Users\\safim\\Desktop";
        string appdata = "C:\\Users\\safim\\AppData";//не работает  так как нет доступа к системной папке
        public FileForm()
        {
            InitializeComponent();
            comboBoxFile.Items.AddRange(new string[] { "Temp", "Загрузки", "Рабочий стол", "Appadata" });
            this.Height = 500;
            this.Width = 500;
        }

        private void FileForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
 
            toolTip1.IsBalloon = true;
            
        }
        private void GetDirectorySize(string folderPath)
        {
            files = new DirectoryInfo(folderPath);
            long sum = (files.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length));
            label8.Text = СonversionTogigabytes(sum).ToString() + " ГБ";
            label1.Text = СonversionToMegabytes(sum).ToString() + " МБ";
            progressBarFile.Value = (int)СonversionTogigabytes(sum);
            toolTip1.SetToolTip(progressBarFile, "Объем папки: "
                        + СonversionTogigabytes(sum).ToString() + " ГБ");
            
        }
        private double СonversionTogigabytes(long _byte)//конвертация в гб
        {
            return Math.Round((((double)_byte / 1024) / 1024) / 1024, 1);
        }
        private double СonversionToMegabytes(long _Kbyte)//килобайты перевели в мегабайты
        {
            return _Kbyte /1048576;
        }
        private void Getfiles()
        {
            counter++;
            if (comboBoxFile.SelectedIndex == 0)
            {
                GetDirectorySize(temp);//temp
               
            }
            if (comboBoxFile.SelectedIndex == 1)
            {
       
                GetDirectorySize(download);//загрузки
            }
            if (comboBoxFile.SelectedIndex == 2)
            {
          
                GetDirectorySize(desktop);//рабочий стол
            }
            if (comboBoxFile.SelectedIndex == 3)
            {
  
                GetDirectorySize(appdata);//appdata
            }
            if (counter == 10)
            {
                timer1.Stop();
            }

        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Getfiles();
        }
    }
}
