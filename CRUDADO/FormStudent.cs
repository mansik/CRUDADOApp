using CRUDADO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace CRUDADO
{
    public partial class FormStudent : Form
    {
        private readonly FormStudentInfo _parent;
        //public string id, name, reg, @class, section;
        public string id;
        public FormStudent(FormStudentInfo parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo(Student student)
        {
            this.id = student.Id;
            titleLabel.Text = "Update Student";
            saveButton.Text = "Update";
            nameTextBox.Text = student.Name;
            regTextBox.Text = student.Reg;
            classTextBox.Text = student.Class;
            sectionTextBox.Text = student.Section;            
        }
        public void SaveInfo()
        {
            titleLabel.Text = "Save Student";
            saveButton.Text = "Save";
        }

        public void Clear()
        {
            nameTextBox.Text = regTextBox.Text = classTextBox.Text = sectionTextBox.Text = string.Empty;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student name is Empty ( > 3).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (regTextBox.Text.Trim().Length < 1)
            {
                MessageBox.Show("Student reg is Empty ( > 1).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (classTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student Class is Empty ( > 1).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sectionTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student Section is Empty ( > 1).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (saveButton.Text == "Save")
            {
                var student = new Student(id, nameTextBox.Text.Trim(), regTextBox.Text.Trim(), classTextBox.Text.Trim(), sectionTextBox.Text.Trim());
                StudentDb.Insert(student);
                Clear();
            }
            if (saveButton.Text == "Update")
            {
                var student = new Student(id, nameTextBox.Text.Trim(), regTextBox.Text.Trim(), classTextBox.Text.Trim(), sectionTextBox.Text.Trim());
                StudentDb.Update(student);
            }
            _parent.Display();
        }
    }
}
