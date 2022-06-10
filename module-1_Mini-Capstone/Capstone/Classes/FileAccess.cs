using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain any and all details of access to files
    /// </summary>
    public class FileAccess
    {
        // All external data files for this application should live in this directory.
        // You will likely need to create this directory and copy / paste any needed files.
        private const string DataDirectory = @"C:\Catering";

        // These files should be read from / written to in the DataDirectory
        private const string CateringFileName = @"cateringsystem.csv";
        private const string ReportFileName = @"totalsales.txt";

        public void ReadFromFile(CateringSystem catering)
        { // try 
            using (StreamReader reader = new StreamReader(Path.Combine(DataDirectory, CateringFileName)))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] properties = line.Split("|");
                    decimal costDecimal = decimal.Parse(properties[3]);
                    BeverageItem newBeverage = new BeverageItem(properties[0], properties[1], properties[2], costDecimal, 10);
                    //catering.ItemSaver(newBeverage);

                    catering.ItemSaver(newBeverage);
                }
            }
        }
    }
}

