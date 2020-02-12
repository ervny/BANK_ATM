using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace ViewChanger
{
    public class Students
    {
        public string name { get; set; }
        public string cls { get; set; }
        public string roll { get; set; }

        public string WriteToJson(Students s)
        {
            string res = "";
            if (File.Exists(@"Students.json"))
            {
                    string frmjson = File.ReadAllText(@"Students.json");
                
                    List<Students> lstFromJson = JsonConvert.DeserializeObject<List<Students>>(frmjson);
                    lstFromJson.Add(s);
                    
                    string tojson = JsonConvert.SerializeObject(lstFromJson);
                    File.WriteAllText(@"Students.json", tojson);
                    //MessageBox.Show(tojson);
            }
         else
            {
                List<Students> lstToJson = new List<Students>();
                lstToJson.Add(s);
                string tojson = JsonConvert.SerializeObject(lstToJson);
                File.WriteAllText(@"Students.json", tojson);
                //MessageBox.Show(tojson);

            }
            res = "Done !!";
            return res;
            

        }

      

    }

    
}
