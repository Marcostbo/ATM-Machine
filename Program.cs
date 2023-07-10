using ATM_Machine.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExcelDataReader;
using System.Data;

namespace ATM_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            int selectedUserId = 13;
            int accountCode = 17598;
            int agencyCode = 5995;
            int userPin = 123123;
            string action = "Deposit";
            float amount = 1000;

            var db = new DBConnector();
            var reader = db.connection;
            var workSheet = reader.AsDataSet().Tables[0];
            var rows = from DataRow a in workSheet.Rows select a;

            DataRow currentRow;
            int count = 0;

            foreach(DataRow row in rows)
            {
                if (count > 0)
                {
                    if (Convert.ToInt32(row[0]) == selectedUserId)
                    {
                        currentRow = row;
                    }
                }
                count++;
            }
        }
    }
}
