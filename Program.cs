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
            // User data input
            int selectedUserId = 13;
            int userPin = 123123;
            
            // Action input
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
                        int userPassword = Convert.ToInt32(row[3]);

                        if (IsAuth(password_input: userPin, password: userPassword))
                        {
                            Console.WriteLine("User " + selectedUserId + " is authenticated");
                            User currentUser = new User(
                                    userId: selectedUserId,
                                    userFirstName: Convert.ToString(row[1]),
                                    userLastName: Convert.ToString(row[2]),
                                    userPin: userPin,
                                    accountCode: Convert.ToInt32(row[4]),
                                    agencyCode: Convert.ToInt32(row[5]),
                                    availableBalance: Convert.ToDouble(row[6])
                                );
                            Console.WriteLine(currentUser.availableBalance);
                        }
                        else
                        {
                            Console.WriteLine("User is not authenticated");
                        }
                    }
                }
                count++;
            }
        }

        static bool IsAuth(int password_input, int password)
        {
            if (password_input == password)
            {
                return true;
            }
            return false;
        }
    }
}
