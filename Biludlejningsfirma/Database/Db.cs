using Biludlejningsfirma.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Biludlejningsfirma.Database
{

    public class Db
    {
        string CornectionString = "Server=localhost;Database=Biludlejningsfirma;Trusted_Connection=True;TrustServerCertificate=True;";

        public Db()
        {

        }
        public List<Biltype> /*Biltyper*/ GetAllBiltype()
        {
            List<Biltype> list = new List<Biltype>();
            //Biltyper b = null;
            string queryString = "select * from Biltyper;";

            //DB connection inside a using clause to ensure the closing of connection when done.
            using (SqlConnection connection = new SqlConnection(CornectionString))
            {
                //OPEN CONNECTION
                connection.Open();
                //Create a new SQL query command
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandText = queryString;
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //Read the data
                        while (reader.Read())
                        {
                            int Id = (int)reader["Id"];
                            string Car_Size = (string)reader["Car_Size"];
                            decimal Price = (decimal)reader["Price"];


                            //do stuff 
                            list.Add(new Biltype()
                            {
                                Id = Id,
                                carSize = Car_Size,
                                price = Price,
                            });
                        }
                    }
                }
                connection.Close();
            }
            return list;
        }

        public List<Extra> /*Extra*/ GetAllExtra()
        {
            List<Extra> list = new List<Extra>();
            //Extra b = null;
            string queryString = "select * from Extra;";

            //DB connection inside a using clause to ensure the closing of connection when done.
            using (SqlConnection connection = new SqlConnection(CornectionString))
            {
                //OPEN CONNECTION
                connection.Open();
                //Create a new SQL query command
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandText = queryString;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //Read the data
                        while (reader.Read())
                        {
                            int Id = (int)reader["Id"];
                            string addons = (string)reader["Addons"];
                            decimal Price = (decimal)reader["Price"];


                            //do stuff 
                            list.Add(new Extra()
                            {
                                Id = Id,
                                addons = addons,
                                price = Price,
                            });
                        }
                    }
                }
                connection.Close();
            }
            return list;
        }
        public List<Bruger> /*Bruger*/ GetAllBruger()
        {
            List<Bruger> list = new List<Bruger>();
            //Bruger b = null;
            string queryString = "select * from Bruger;";

            //DB connection inside a using clause to ensure the closing of connection when done.
            using (SqlConnection connection = new SqlConnection(CornectionString))
            {
                //OPEN CONNECTION
                connection.Open();
                //Create a new SQL query command
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandText = queryString;
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //Read the data
                        while (reader.Read())
                        {
                            int Id = (int)reader["Id"];
                            string UserName = (string)reader["UserName"];
                            string UserPassword = (string)reader["UserPassword"];
                            string Email = (string)reader["Email"];
                            string City = (string)reader["City"];
                            int PhoneNumber = (int)reader["PhoneNumber"];

                            //do stuff 
                            list.Add(new Bruger()
                            {
                                Id = Id,
                                userName = UserName,
                                userPassword = UserPassword,
                                email = Email,
                                city = City,
                                phoneNumber = PhoneNumber
                            });
                        }
                    }
                }
                connection.Close();
            }
            return list;
        }

        public List<AdminUser> /*AdminUser*/ GetAllAdminUsers()
        {
            List<AdminUser> list = new List<AdminUser>();
            //Bruger b = null;
            string queryString = "select * from AdminUser;";

            //DB connection inside a using clause to ensure the closing of connection when done.
            using (SqlConnection connection = new SqlConnection(CornectionString))
            {
                //OPEN CONNECTION
                connection.Open();
                //Create a new SQL query command
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandText = queryString;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //Read the data
                        while (reader.Read())
                        {
                            int Id = (int)reader["Id"];
                            string AdminName = (string)reader["AdminName"];
                            string AdminPassword = (string)reader["AdminPassword"];
 

                            //do stuff 
                            list.Add(new AdminUser()
                            {
                                Id = Id,
                                adminName = AdminName,
                                adminPassword = AdminPassword
                            });
                        }
                    }
                }
                connection.Close();
            }
            return list;
        }

        public List<Udlejning> /*AdminUser*/ GetAllUdlejning()
        {
            List<Udlejning> list = new List<Udlejning>();
            //Bruger b = null;
            string queryString = "select * from Udlejning;";

            //DB connection inside a using clause to ensure the closing of connection when done.
            using (SqlConnection connection = new SqlConnection(CornectionString))
            {
                //OPEN CONNECTION
                connection.Open();
                //Create a new SQL query command
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandText = queryString;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //Read the data
                        while (reader.Read())
                        {
                            int Id = (int)reader["Id"];

                            //her henter jeg alle addons med et id hved hjelp af Udlejning_id fra GetAllAddonsWithId
                            //og tilføjer det til en liste af addons


                            int biltyperId = (int)reader["Biltyper_id"];
                            string Car_Size = (string)reader["Car_Size"];
                            decimal CPrice = (decimal)reader["Price"];
                            Biltype biltype = new Biltype();
                            biltype.Id = biltyperId;
                            biltype.carSize = Car_Size;
                            biltype.price = CPrice;

                            int BrugerId = (int)reader["Bruger_id"];
                            string UserName = (string)reader["UserName"];
                            string UserPassword = (string)reader["UserPassword"];
                            string Email = (string)reader["Email"];
                            string City = (string)reader["City"];
                            int PhoneNumber = (int)reader["PhoneNumber"];
                            Bruger bruger = new Bruger();
                            bruger.Id = BrugerId;
                            bruger.userName = UserName;
                            bruger.userPassword = UserPassword;
                            bruger.email = Email;
                            bruger.city = City;
                            bruger.phoneNumber = PhoneNumber;


                            DateTime StartDate = (DateTime)reader["StartDate"];
                            DateTime EndDate = (DateTime)reader["EndDate"];


                            string ExtraId = (string)reader["Extra_id"];
                            string Addons = (string)reader["Addons"];
                            decimal EPrice = (decimal)reader["Price"];



                           

                            //do stuff 
                            list.Add(new Udlejning()
                            {
                                Id = Id,
                                
                                
                                
                            });
                        }
                    }
                }
                connection.Close();
            }
            return list;
        }


        public bool /*Bruger*/ CreateBruger(string UserName, string UserPassword, string Email, string City, int PhoneNumber)
        {
            List<Bruger> list = new List<Bruger>();
            //Bruger b = null;
            string queryString = "INSERT INTO Bruger(UserName, UserPassword, Email, City, PhoneNumber)" +
                $"VALUES('{UserName}','{UserPassword}','{Email}','{City}','{PhoneNumber}');";

            //DB connection inside a using clause to ensure the closing of connection when done.
            using (SqlConnection connection = new SqlConnection(CornectionString))
            {
                //OPEN CONNECTION
                connection.Open();
                //Create a new SQL query command
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandText = queryString;
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
            return true;
        }

        public bool /*Bruger*/ CreateUdlejning(Biltype biltype, Bruger bruger, DateTime startdate, DateTime enddate, Extra extra)
        {
            
            string queryString = "INSERT INTO Udlejning(biltyperId,BrugerId,StartDate,EndDate,ExtraId)" +
                $"VALUES('{biltype.Id}','{bruger.Id}','{startdate.ToString()}','{enddate.ToString()}','{extra.Id}');";

            //DB connection inside a using clause to ensure the closing of connection when done.
            using (SqlConnection connection = new SqlConnection(CornectionString))
            {
                //OPEN CONNECTION
                connection.Open();
                //Create a new SQL query command
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandText = queryString;

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        //public bool /*AdminUser*/ CreateAdminUser(string UserName, string UserPassword)
        //{
        //    List<AdminUser> list = new List<AdminUser>();
        //    //AdminUser b = null;
        //    string queryString = "INSERT INTO AdminUser(UserName, UserPassword, )" +
        //        $"VALUES('{UserName}','{UserPassword}');";

        //    //DB connection inside a using clause to ensure the closing of connection when done.
        //    using (SqlConnection connection = new SqlConnection(CornectionString))
        //    {
        //        //OPEN CONNECTION
        //        connection.Open();
        //        //Create a new SQL query command
        //        using (SqlCommand command = new SqlCommand(queryString, connection))
        //        {
        //            command.CommandText = queryString;

        //            command.ExecuteNonQuery();
        //        }
        //        connection.Close();
        //    }
        //    return true;
        //}
    }
}
