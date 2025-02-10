using JSBilling.DA;
using JSBilling.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSBilling.BL
{
    public class AdminDash
    {
        private readonly SQLHelper helper;
        public AdminDash()
        { 
            helper = new SQLHelper();
        }
        public List<Admin> getCheckindata(string query)
        {
            string sqlquery = "Select * from StudentDetails";
            DataSet dataSet = new DataSet();
            dataSet =helper.SqlDataset(sqlquery);
            var JSONString = JsonConvert.SerializeObject(dataSet.Tables[0]);
            List<Admin> list = JsonConvert.DeserializeObject<List<Admin>>(JSONString);
            return list;
        }

    }
}
