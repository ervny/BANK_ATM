using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ViewChanger
{
    public class Users
    {
        public string username { get; set; }
        public string password { get; set; }

        public double amount { get; set; }
        public string WriteToJson(Users s)
        {
            string res = "";
            if (File.Exists(@"Users.json"))
            {
                string frmjson = File.ReadAllText(@"Users.json");

                List<Users> lstFromJson = JsonConvert.DeserializeObject<List<Users>>(frmjson);
                lstFromJson.Add(s);

                string tojson = JsonConvert.SerializeObject(lstFromJson);
                File.WriteAllText(@"Users.json", tojson);
                //MessageBox.Show(tojson);
            }
            else
            {
                List<Users> lstToJson = new List<Users>();
                lstToJson.Add(s);
                string tojson = JsonConvert.SerializeObject(lstToJson);
                File.WriteAllText(@"Users.json", tojson);
                //MessageBox.Show(tojson);

            }
            res = "Done !!";
            return res;


        }

        public string WriteToJson(List<Users> list)
        {
            string val = "";

            string tojson = JsonConvert.SerializeObject(list);
            File.WriteAllText(@"Users.json", tojson);
            return val;
        }

    }

   
}
