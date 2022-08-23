using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;


namespace JasonParser
{
    class Program 
    {
        static void Main(string[] args)
        {


            JObject o1 = JObject.Parse(File.ReadAllText("C:\\Users\\GakkUser\\Downloads\\Telegram Desktop\\banglalink-estore-export.json"));
            var dst = o1["users"];

            foreach (var item in dst)
            {
                var data = item.Children().Children().ToList(); ;
                List<string> stringList = data.Values<string>().ToList();

                var count = stringList.Count;

               

                string id = stringList[0];
                string name = stringList[1];
                string profilePicUrl = stringList[2];
                bool subscribed = Convert.ToBoolean(stringList[3]);
                string userType = stringList[4];


                var cmdText = @"
                insert into userinfo (Name, PPUrl, UserType, UserCode, Subscribed)
                values ('"+name+"', '"+profilePicUrl+"','"+ userType + "', '"+id+ "','" + subscribed + "')";

                var connectionString = "Data Source=DESKTOP-L73JFTA\\SQLEXPRESS;Initial Catalog=BStoreDB;User ID=DESKTOP-L73JFTA\\GakkUser;Trusted_Connection=True;MultipleActiveResultSets=True;";
           
                    using (var connection = new SqlConnection(connectionString))
                    {
                        var command = new SqlCommand(cmdText, connection);
                        
                        
                        //command.Parameters.AddWithValue("@State", customer.State);
                        //command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                        //command.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);

                       
                        
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                    }
                    
                


                //SqlConnection cn = new SqlConnection();
                //cn.ConnectionString = "Data Source=DESKTOP-L73JFTA\\SQLEXPRESS;Initial Catalog=BStoreDB;User ID=DESKTOP-L73JFTA\\GakkUser;Trusted_Connection=True;MultipleActiveResultSets=True;";
                //cn.Open();

                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = cn;
                ////cmd.CommandText = @"insert into userinfo (Name, PPUrl, Subscribed, UserType, UserCode) 
                ////values('" + name + "', '" + profilePicUrl + "', '" + subscribed + "', '" + userType + "','" + id + "')";
                //cmd.CommandText = @"INSERT INTO userinfo(Name, PPUrl, Subscribed, UserType, UserCode)
                //                    SELECT Name, PPUrl, Subscribed, UserType, UserCode from (VALUES
                //                    ('" + name + "', '" + profilePicUrl + "', '" + subscribed + "', '" + userType + "','" + id + "'), as Subscribed (Name, PPUrl, Subscribed, UserType, UserCode)";

                //cmd.ExecuteNonQuery();
                //cn.Close();

                ////cmd.CommandText = @"INSERT INTO userinfo(Name, PPUrl, Subscribed, UserType, UserCode)
                ////                    SELECT Name, PPUrl, Subscribed, UserType, UserCode from (VALUES
                ////                    ('" + name + "', '" + profilePicUrl + "', '" + subscribed + "', '" + userType + "','" + id + "'), as Subscribed (Name, PPUrl, Subscribed, UserType, UserCode)";
            }
        }
    }   
}
