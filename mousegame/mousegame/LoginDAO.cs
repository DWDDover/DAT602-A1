using MySqlConnector;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    class LoginDAO : DatabaseAccessObject
    {
        public LoginResult Login(string p_username, string p_password)
        {
            try
            {
                var result = new LoginResult();

                using (var command = new MySqlCommand("sp_login", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_username", p_username);
                    command.Parameters.AddWithValue("@p_password", p_password);

                    mySqlConnection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result.Status = (string)reader["status"];
                            result.Message = (string)reader["message"];
                            result.UserId = reader["user_id"] == DBNull.Value
                                ? null
                                : (int?)reader["user_id"];
                            result.Admin = reader["admin"] == DBNull.Value
                                ? null
                                : (int?)reader["admin"];
                        }
                    }
                }

                return result;
            }
            catch (MySqlException)
            {
                return new LoginResult
                {
                    Status = "error",
                    Message = "Unable to connect to the database. Please try again later."
                };
            }
            catch (Exception)
            {
                return new LoginResult
                {
                    Status = "error",
                    Message = "An unexpected error occurred."
                };
            }
            finally
            {
                if (mySqlConnection.State != ConnectionState.Closed)
                {
                    mySqlConnection.Close();
                }
            }
        }
        public string Register(string p_username, string p_password)
        {
            try
            {
                using (var command = new MySqlCommand("sp_registration", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_username", p_username);
                    command.Parameters.AddWithValue("@p_password", p_password);

                    mySqlConnection.Open();
                    var status = command.ExecuteScalar();
                    mySqlConnection.Close();

                    return Convert.ToString(status);
                }
            }
            catch (MySqlException)
            {
                return "Unable to connect to the database. Please try again later.";
            }
            catch (Exception)
            {
                return "An unexpected error occurred.";
            }
            finally
            {
                if (mySqlConnection.State != ConnectionState.Closed)
                {
                    mySqlConnection.Close();
                }
            }
        }
    }
}
