using CRUDADO.Models;
using System;
using System.Windows.Forms;

namespace CRUDADO
{
    public partial class FormStudentInfo : Form
    {
        readonly FormStudent frmStudent;
        public FormStudentInfo()
        {
            InitializeComponent();
            frmStudent = new FormStudent(this);
        }
        public void Display()
        {
            StudentDb.DisplayAndSearch(dataGridView, "SELECT ID, Name, Reg, Class, Section FROM Student");
        }
        private void newButton_Click(object sender, EventArgs e)
        {
            frmStudent.Clear();
            frmStudent.SaveInfo();
            frmStudent.ShowDialog();
        }

        private void FormStudentInfo_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            StudentDb.DisplayAndSearch(dataGridView,"SELECT ID, Name, Reg, Class, Section FROM Student WHERE Name LIKE '%" + searchTextBox.Text + "%'");
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Edit
                frmStudent.Clear();
                var student = new Student(
                    dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString(), 
                    dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString()
                    );                
                frmStudent.UpdateInfo(student);
                frmStudent.ShowDialog();;
                return;
            }
            if (e.ColumnIndex == 1)
            {
                //Delete
                if (MessageBox.Show("Are you want to delete student record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    StudentDb.Delete(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }
    }
}
