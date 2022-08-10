using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;


namespace JasonParser
{
    class Program
    {
        static void Main(string[] args)
        {

            //JObject o1 = JObject.Parse(File.ReadAllText("C:\\Users\\GakkUser\\Downloads\\Telegram Desktop\\banglalink-estore-export.json"));
            //var dst = o1["users"];

            //foreach (var item in dst)
            //{
            //    var data = item.Children().Children().ToList();

            //    foreach (var item2 in data)
            //    {


            //    }


            //}


            JObject o1 = JObject.Parse(File.ReadAllText("C:\\Users\\GakkUser\\Downloads\\Telegram Desktop\\banglalink-estore-export.json"));
            var dst = o1["users"];

            foreach (var item in dst)
            {
                var data = item.Children().Children().ToList(); ;
                List<string> stringList = data.Values<string>().ToList();

                string id = stringList[0];
                string name = stringList[1];
                string profilePicUrl = stringList[2];
                string subscribed = stringList[3];
                string userType = stringList[4];

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=DESKTOP-L73JFTA\\SQLEXPRESS;Initial Catalog=BStoreDB;User ID=DESKTOP-L73JFTA\\GakkUser;Trusted_Connection=True;MultipleActiveResultSets=True;";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"insert into userinfo (Name, PPUrl, Subscribed, UserType, UserCode) 
                values('" + name + "', '" + profilePicUrl + "', '" + subscribed + "', '" + userType + "','" + id + "')";

                cmd.ExecuteNonQuery();
            }





            //var json = System.IO.File.ReadAllText("C:\\Users\\GakkUser\\Downloads\\Telegram Desktop\\banglalink-estore-export.json");
            //dynamic jobj = JObject.Parse(json);

            //var dst = jobj.users;

            //var converter = new ExpandoObjectConverter();
            //dynamic message = JsonConvert.DeserializeObject<ExpandoObject>(json, converter);
            //var dste = message.users;

            //var byName = (IDictionary<string, object>)dste;
            //foreach (var key in dste.Keys)
            //{
            //    // check if the value is not null or empty.
            //    var value = dste[key];

            //}

            // IEnumerable<dynamic> listDyn = dste[0][1].Select
            // new // gives error here as whole
            // {
            //    id = items["id"].ToString(),
            //    name = items["name"].ToString(),
            //    profilePicUrl = items["profilePicUrl"].ToString(),
            //    subscribed = (bool)items["subscribed"],
            //    userType = items["userType"]
            //});




            //Console.WriteLine(jobj[0][0][0]["id"]);
            //Console.WriteLine(jobj[0][0]["endTime"]);
            //Console.WriteLine(jobj[0][0]["status"]);


            //var json = System.IO.File.ReadAllText("C:\\Users\\GakkUser\\Downloads\\Telegram Desktop\\banglalink-estore-export.json");
            ////var jobj = JObject.Parse(json);

            //var Jsresult = new JavaScriptSerializer().Deserialize<dynamic>(json).ToString();

            //JObject jObject = JObject.Parse(json);

            //IEnumerable<dynamic> listDyn = jObject["user"].Select(items =>
            //new // gives error here as whole
            //{
            //    id = items["id"].ToString(),
            //    name = items["name"].ToString(),
            //    profilePicUrl = items["profilePicUrl"].ToString(),
            //    subscribed = (bool)items["subscribed"],
            //    userType = items["userType"]
            //});

            //var list = listDyn;

            //StreamReader sr = new StreamReader(@"C:/Users/GakkUser/Downloads/Telegram Desktop/banglalink-estore-export.json");
            //string jsonString = sr.ReadToEnd();
            //dynamic d = JsonConvert.DeserializeObject<dynamic>(jsonString);
            //DataSet ds = new DataSet();
            //var t = ds.Tables.Add(jsonString);

            //foreach (var item in t.Columns)
            //{

            //}
            ////List<List<double>> coords = new List<List<double>>();
            ////coords.Add(new List<double> });
            ////coords.Add(new List<double> { 32, 45, 48 });
            ////Console.WriteLine(coords[1][1]);

            //foreach (var item in d[""]["users"][""])
            //{
            //    Console.WriteLine($"Point=({item.id})");
            //}
        }
    }


   
}
