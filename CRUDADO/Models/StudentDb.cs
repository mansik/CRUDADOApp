using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUDADO.Models
{
    class StudentDb
    {
        public static void Insert(Student student)
        {
            using (var connection = AppConnection.GetConnection())
            {
                var sql = "INSERT INTO Student(Name, Reg, Class, Section) VALUES (@Name, @Reg, @Class, @Section)";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = student.Name;
                    command.Parameters.Add("@Reg", SqlDbType.NVarChar).Value = student.Reg;
                    command.Parameters.Add("@Class", SqlDbType.NVarChar).Value = student.Class;
                    //command.Parameters.Add("@Section", SqlDbType.NVarChar).Value = student.Section;
                    command.Parameters.AddWithValue("@Section", student.Section);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Added Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Student not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //throw;
                    }
                }
            }
        }
        public static void Update(Student student)
        {
            using (var connection = AppConnection.GetConnection())
            {
                var sql =
                    @"UPDATE Student SET
                        Name = @Name
                        ,Reg = @Reg
                        ,Class = @Class
                        ,Section = @Section 
                     WHERE ID = @ID";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = student.Id;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = student.Name;
                    command.Parameters.Add("@Reg", SqlDbType.NVarChar).Value = student.Reg;
                    command.Parameters.Add("@Class", SqlDbType.NVarChar).Value = student.Class;
                    command.Parameters.Add("@Section", SqlDbType.NVarChar).Value = student.Section;

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Updated Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Student not update. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //throw;
                    }
                }
            }
        }
        public static void Delete(string id)
        {
            using (var connection = AppConnection.GetConnection())
            {
                var sql =
                    @"DELETE Student 
                      WHERE ID = @ID";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Deleted Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Student not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //throw;
                    }
                }
            }
        }

        public static void DisplayAndSearch(DataGridView dgv, string query, params SqlParameter[] param)
        {
            var sql = query;
            using (var connection = AppConnection.GetConnection())
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddRange(param);
                    var adapter = new SqlDataAdapter(command);
                    var tbl = new DataTable();
                    adapter.Fill(tbl);
                    dgv.DataSource = tbl;
                }
            }
        }
    }
}
