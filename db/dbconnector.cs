using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExcelDataReader;
using System.Data;

namespace ATM_Machine.db
{
    class DBConnector
    {
        public string url = @"C:\Users\Marcos Oliveira\source\repos\ATM-Machine\db\db.xlsx";
        public IExcelDataReader connection;

        public DBConnector()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var reader = this.getExcelReader(path: this.url);
            var workSheet = reader.AsDataSet().Tables[0];
            var rows = from DataRow a in workSheet.Rows select a;
            foreach (DataRow row in rows)
            {
                Console.WriteLine("{0}, {1}", row[0], row[1]);
            }
            Console.WriteLine(rows.ToArray());
            this.connection = reader;
        }

        public IExcelDataReader getExcelReader(string path)
        {
            // ExcelDataReader works with the binary Excel file, so it needs a FileStream
            // to get started. This is how I avoid dependencies on ACE or Interop:
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);

            // Return the interface, so that
            IExcelDataReader reader = null;
            try
            {
                if (path.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                if (path.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                return reader;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
