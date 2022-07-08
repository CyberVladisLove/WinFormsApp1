using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Windows.Forms;
using System.IO;

namespace WinFormsApp1
{
    
    public partial class Form1 : Form
    {
        
        string path = @"d:\\test2.txt";
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            
        }

        private void button_add_line_Click_1(object sender, EventArgs e)
        {
            StreamWriter file2 = new StreamWriter(path, true);
            try
            {
                if (textBox1.Text.Length > 0 &&
                textBox2.Text.Length > 0 &&
                textBox3.Text.Length > 0 &&
                textBox4.Text.Length > 0 &&
                textBox5.Text.Length > 0 &&
                textBox6.Text.Length > 0 &&
                textBox7.Text.Length > 0 &&
                textBox8.Text.Length > 0 &&
                textBox9.Text.Length > 0 &&
                textBox10.Text.Length > 0)
                {
                    Request r = new Request();
                    r.Surname = textBox1.Text;
                    r.Name = textBox2.Text;
                    r.Patronymic = textBox3.Text;
                    if (int.TryParse(textBox4.Text, out int res)) r.Request_num = res;
                    else
                    {
                        MessageBox.Show("Неправильный номер");
                        return;
                    }

                    
                    
                    r.Purpose = textBox5.Text;
                    r.Request_date = textBox6.Text;
                    r.Answer_date = textBox7.Text;
                    r.Empl_surname = textBox8.Text;
                    r.Empl_name = textBox9.Text;
                    r.Empl_patronymic = textBox10.Text;

                    string req_str = r.Surname + "_" + r.Name + "_" + r.Patronymic + "_"
                        + r.Request_num + "_" + r.Purpose + "_" + r.Request_date + "_" + r.Answer_date + "_"
                        + r.Empl_surname + "_" + r.Empl_name + "_" + r.Empl_patronymic;

                    file2.WriteLine(req_str);
                    
                    
                    MessageBox.Show("Запись добавлена");
                }
                else
                {
                    MessageBox.Show("Заполните поля");
                }
            }
            finally
            {
                file2.Close();
                file2.Dispose();
            }

            PrintData(GetFileData());
        }
        public List<Request> GetFileData()
        {
            List<Request> list = new List<Request>();
            StreamReader reader = new StreamReader(path);
            try
            {            
                string line = reader.ReadLine();

                while (line != null)
                {
                    var str_arr = line.Split("_");
                    Request r = new Request();
                    r.Surname = str_arr[0];
                    r.Name = str_arr[1];
                    r.Patronymic = str_arr[2];
                    if (int.TryParse(str_arr[3], out int res)) r.Request_num = res;

                    r.Purpose = str_arr[4];
                    r.Request_date = str_arr[5];
                    r.Answer_date = str_arr[6];
                    r.Empl_surname = str_arr[7];
                    r.Empl_name = str_arr[8];
                    r.Empl_patronymic = str_arr[9];

                    list.Add(r);
                    line = reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проблема с файлом");
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
            
            
            return list;
        }
        //вывод данных в таблицу
        public void PrintData(List<Request> list)
        {
            BindingList<Request> data = new BindingList<Request>(list);
            dataGridView1.DataSource = data;
        }
        //чтение файла
        private void button_read_file_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            try
            {
                PrintData(GetFileData());
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файла нет");
            }
        }

        //очистка файла
        private void button_clear_file_Click(object sender, EventArgs e)
        {
            File.WriteAllText(path, "");
            MessageBox.Show("Файл очищен");
            PrintData(GetFileData());
        }

        //перезапись всего файла новыми данными
        public void WriteFile(List<Request> file)
        {
            File.WriteAllText(path, "");
            StreamWriter writer = new StreamWriter(path, true);
            

            for (int i = 0; i < file.Count; i++)
            {             
                Request r = file[i];

                string req_str = r.Surname + "_" + r.Name + "_" + r.Patronymic + "_"
                        + r.Request_num + "_" + r.Purpose + "_" + r.Request_date + "_" + r.Answer_date + "_"
                        + r.Empl_surname + "_" + r.Empl_name + "_" + r.Empl_patronymic;
                writer.WriteLine(req_str);
            }
 
            writer.Close();
            writer.Dispose();

        }
        
        //обработчики кнопок поиска по соотв признаку
        private void button1_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox1.Text;
            
            for(int i = 0; i<file.Count; i++)
            {
                if (file[i].Surname != val) file.RemoveAt(i);
            }
            
            PrintData(file);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox2.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Name != val) file.RemoveAt(i);
            }
            
            PrintData(file);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox3.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Patronymic != val) file.RemoveAt(i);
            }

            PrintData(file);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = 0;
            if (int.TryParse(textBox4.Text, out int res)) val = res;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Request_num != val) file.RemoveAt(i);
            }

            PrintData(file);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox5.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Purpose != val) file.RemoveAt(i);
            }

            PrintData(file);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox6.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Request_date != val) file.RemoveAt(i);
            }

            PrintData(file);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox7.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Answer_date != val) file.RemoveAt(i);
            }

            PrintData(file);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox8.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Empl_surname != val) file.RemoveAt(i);
            }

            PrintData(file);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox9.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Empl_name != val) file.RemoveAt(i);
            }

            PrintData(file);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox10.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Empl_patronymic != val) file.RemoveAt(i);
            }

            PrintData(file);
        }

        //обработчики кнопок удаления по соотв признаку
        private void button11_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox1.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Surname == val) file.RemoveAt(i);
            }
            WriteFile(file);
            PrintData(file);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox2.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Name == val) file.RemoveAt(i);
            }
            WriteFile(file);
            PrintData(file);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox3.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Patronymic == val) file.RemoveAt(i);
            }
            WriteFile(file);
            PrintData(file);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = 0;
            if (int.TryParse(textBox4.Text, out int res)) val = res;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Request_num == val) file.RemoveAt(i);
            }
            WriteFile(file);
            PrintData(file);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox5.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Purpose == val) file.RemoveAt(i);
            }
            WriteFile(file);
            PrintData(file);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox6.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Request_date == val) file.RemoveAt(i);
            }
            WriteFile(file);
            PrintData(file);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox7.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Answer_date == val) file.RemoveAt(i);
            }
            WriteFile(file);
            PrintData(file);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox8.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Empl_surname == val) file.RemoveAt(i);
            }
            WriteFile(file);
            PrintData(file);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox9.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Empl_name == val) file.RemoveAt(i);
            }
            WriteFile(file);
            PrintData(file);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = textBox10.Text;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Empl_patronymic == val) file.RemoveAt(i);
            }
            WriteFile(file);
            PrintData(file);
        }

        //редактирование записи по номеру заявки
        private void button21_Click(object sender, EventArgs e)
        {
            var file = GetFileData();
            var val = 0;
            if (int.TryParse(textBox4.Text, out int res)) val = res;
            bool isFind = false;
            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Request_num == val)
                {
                    isFind = true;
                    Request r = new Request();
                    r.Surname = textBox1.Text;
                    r.Name = textBox2.Text;
                    r.Patronymic = textBox3.Text;
                    r.Request_num = val;
                    r.Purpose = textBox5.Text;
                    r.Request_date = textBox6.Text;
                    r.Answer_date = textBox7.Text;
                    r.Empl_surname = textBox8.Text;
                    r.Empl_name = textBox9.Text;
                    r.Empl_patronymic = textBox10.Text;
                    
                    file[i] = r;
                    break;
                }
            }
            if(!isFind) MessageBox.Show("Записи с таким номером заявки нет");
            WriteFile(file);
            PrintData(file);
        }
    }
}


