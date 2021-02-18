using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlServerCe;

namespace WIUT.DAL
{
    public class CourseManager_Applicant
    {
        public void Create(Applicant c)
        {
            var connection = new SqlCeConnection("");
            try
            {
                var sql = $"INSERT INTO Applicant (Name, Surname, Address, DoB, MaritialStatus, PassportNo, Course) VALUES ('{c.Name}, {c.Surname}, {c.Address}, {c.Surname}, {c.MaritalStatus}')";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public List<Applicant> GetAll()
        {
            var connection = new SqlCeConnection("");
            var result = new List<Applicant>();
            try
            {
                var sql = "SELECT Id, Name FROM Applicant";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var c = new Applicant
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        Name = Convert.ToString(reader.GetValue(1))
                    };
                    result.Add(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return result;
        }

        public void Update(Applicant c)
        {
            var connection = new SqlCeConnection("");
            try
            {
                var sql = $"UPDATE Applicant SET Name = '{c.Name}' WHERE Id = {c.Id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public void Delete(int id)
        {
            var connection = new SqlCeConnection("");
            try
            {
                var sql = $"DELETE FROM Applicant WHERE Id = {id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public Applicant GetById(int id)
        {
            var connection = new SqlCeConnection("");
            var result = new Applicant();
            try
            {
                var sql = "SELECT Id, Name FROM Applicant";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result.Id = Convert.ToInt32(reader.GetValue(0));
                    result.Name = Convert.ToString(reader.GetValue(1));


                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return result;
        }
    }
    }

