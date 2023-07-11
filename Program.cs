using ATM_Machine.db;
using System;
using System.Collections.Generic;
using System.Linq;
using ExcelDataReader;
using System.Data;

namespace ATM_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            // User data input
            int selectedUserId = 1;
            int userPin = 123123;
            
            // Action input
            string action = "Deposit";
            // string action = "Withdrawal";
            float amount = 2000;

            var db = new DBConnector();
            var reader = db.connection;
            var workSheet = reader.AsDataSet().Tables[0];
            var rows = from DataRow a in workSheet.Rows select a;

            // Get logged user instance
            User currentUser = GetLoggedUser(rows: rows, selectedUserId: selectedUserId, userPin: userPin);

            // Perform action for user instance
            string result = currentUser.PerformAction(action: action, amount: amount);
            Console.WriteLine(result);
        }

        static bool IsAuth(int password_input, int password)
        {
            if (password_input == password)
            {
                return true;
            }
            return false;
        }

        static User? GetLoggedUser(IEnumerable<DataRow> rows, int selectedUserId, int userPin)
        {
            DataRow currentRow;
            int count = 0;

            foreach (DataRow row in rows)
            {
                if (count > 0)
                {
                    if (Convert.ToInt32(row[0]) == selectedUserId)
                    {
                        currentRow = row;
                        int userPassword = Convert.ToInt32(row[3]);

                        if (IsAuth(password_input: userPin, password: userPassword))
                        {
                            User currentUser = new User(
                                    userId: selectedUserId,
                                    userFirstName: Convert.ToString(row[1]),
                                    userLastName: Convert.ToString(row[2]),
                                    userPin: userPin,
                                    accountCode: Convert.ToInt32(row[4]),
                                    agencyCode: Convert.ToInt32(row[5]),
                                    availableBalance: Convert.ToDouble(row[6])
                                );
                            Console.WriteLine("User " + currentUser.fullName + " is authenticated");
                            return currentUser;
                        }
                        else
                        {
                            Console.WriteLine("Wrong password. User is not authenticated");
                            return null;
                        }
                    }
                }
                count++;
            }
            Console.WriteLine("User not found. Invalid user input");
            return null;
        }
    }
}
