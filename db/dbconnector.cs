using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM_Machine.db
{
    class DBConnector
    {
        public string url = @"C:\Users\Marcos Oliveira\source\repos\ATM-Machine\db\db.xlsx";
        public StreamReader connection;

        public DBConnector()
        {
            StreamReader reader = new(this.url);
            this.connection = reader;
        }
    }
}
