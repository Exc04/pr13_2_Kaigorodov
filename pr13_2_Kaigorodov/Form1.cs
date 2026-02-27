using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract13_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }
        private IList<Student> studentList = new List<Student>();
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        private DataGridViewColumn dataGridViewColumn4 = null;
        private DataGridViewColumn dataGridViewColumn5 = null;

        // Добавьте четыре метода приведенные ниже:
        //Инициализация таблицы
        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.Columns.Add(getDataGridViewColumn4());
            dataGridView1.Columns.Add(getDataGridViewColumn5());
            dataGridView1.AutoResizeColumns();
        }
        //Динамическое создание первой колонки в таблице
        private DataGridViewColumn getDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Имя";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn1;
        }
        //Динамическое создание второй колонки в таблице
        private DataGridViewColumn getDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Фамилия";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn2;
        }
        //Динамическое создание третей колонки в таблице
        private DataGridViewColumn getDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)



            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Зачетка";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn3;
        }
        private DataGridViewColumn getDataGridViewColumn4()
        {
            if (dataGridViewColumn4 == null)



            {
                dataGridViewColumn4 = new DataGridViewTextBoxColumn();
                dataGridViewColumn4.Name = "";
                dataGridViewColumn4.HeaderText = "Группа";
                dataGridViewColumn4.ValueType = typeof(string);
                dataGridViewColumn4.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn4;
        }
        private DataGridViewColumn getDataGridViewColumn5()
        {
            if (dataGridViewColumn5 == null)



            {
                dataGridViewColumn5 = new DataGridViewTextBoxColumn();
                dataGridViewColumn5.Name = "";
                dataGridViewColumn5.HeaderText = "Курс";
                dataGridViewColumn5.ValueType = typeof(string);
                dataGridViewColumn5.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn5;
        }




        private void addStudent(string name, string surname, string
        recordBookNumber, string group, int course)
        {
            Student newStudent = new Student(name, surname, recordBookNumber, group, course);
            studentList.Add(newStudent);


            showListInGrid();

        }
        //Удаление студента с колекции
        private void deleteStudent(int elementIndex)
        {
            studentList.RemoveAt(elementIndex);
            showListInGrid();
        }
        //Отображение колекции в таблице
        private void showListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Student s in studentList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell4 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell5 = new
                DataGridViewTextBoxCell();
                cell1.ValueType = typeof(string);
                cell1.Value = s.getName();
                cell2.ValueType = typeof(string);



                cell2.Value = s.getSurname();
                cell3.ValueType = typeof(string);
                cell3.Value = s.getRecordBookNumber();
                cell4.ValueType = typeof(string);
                cell4.Value = s.Group;
                cell5.ValueType = typeof(int);
                cell5.Value = s.Course;
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                dataGridView1.Rows.Add(row);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void Edits()
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберете студента для редактирования", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int selectedIndex = dataGridView1.SelectedRows[0].Index;
            string newName = textBox3.Text.Trim();
            string newSurname = textBox1.Text.Trim();
            string newRecordbook = textBox2.Text.Trim();
            string newGroup = textBox4.Text.Trim();
            string newCourseText = textBox5.Text.Trim();

            if(string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newSurname) 
            || string.IsNullOrWhiteSpace(newRecordbook) || string.IsNullOrWhiteSpace(newGroup) || string.IsNullOrWhiteSpace(newCourseText))
            {
                MessageBox.Show("Заполните все поля для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(newCourseText, out int newCourse))
            {
                MessageBox.Show("Курс должен быть числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (Student s in studentList)
            {
                if (s.getName() == newName && s.getSurname() == newSurname && s.getRecordBookNumber() == newRecordbook && s.Group == newGroup && s.Course == newCourse)
                {
                    MessageBox.Show("Студент с такими данными уже есть в списке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (newCourse < 1 || newCourse > 6)
            {
                MessageBox.Show("Курс должен быть от 1 до 6", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Student studentToEdit = studentList[selectedIndex];
            studentToEdit.setName(newName);
            studentToEdit.setSurname(newSurname);
            studentToEdit.setRecordBookNumber(newRecordbook);
            studentToEdit.Group = newGroup;
            studentToEdit.Course =newCourse;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            showListInGrid();
            MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string surname = textBox1.Text;
            string recordBook = textBox2.Text;
            string group = textBox4.Text;
            string courseText = textBox5.Text;

            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || 
                string.IsNullOrWhiteSpace(recordBook) || string.IsNullOrWhiteSpace(group) 
                || string.IsNullOrWhiteSpace(courseText))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if(!int.TryParse(courseText, out int course))
            {
                MessageBox.Show("Курс должен быть числом");
                return;
            }
            foreach(Student s in studentList) {
                if(s.getName() ==name && s.getSurname()==surname && s.getRecordBookNumber() ==recordBook && s.Group == group && s.Course == course)
                {
                    MessageBox.Show("Студент с такими данными уже есть в списке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if(course < 1 || course > 6)
            {
                MessageBox.Show("Курс должен быть от 1 до 6", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            addStudent(name, surname, recordBook, group, course);

           // Student newStudent = new Student(n, sn, rec);
            //studentList.Add(newStudent);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            showListInGrid();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Удалить студента?", "",
MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {



                    deleteStudent(selectedRow);
                }
                catch (Exception)
                {
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Edits();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}

