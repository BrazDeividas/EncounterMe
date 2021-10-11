using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

//TODO:Add check if path exists, if records are not null (I think they should be new functions) (for write, read etc.)
//Also should ID be generated by taking the last record from database, it shuld not be hardcoded (we missed that)

namespace EncounterMe
{
    public class DatabaseManager
    {
        public String path { get; set; }

        public DatabaseManager(string newPath, string filename)
        {
            //var name = filename + ".csv";
            path = newPath;

            //Creates folder and file, if they are not initialized
            //if (!Directory.Exists("Records"))
            //{
            //    try
            //    {
            //        Directory.CreateDirectory("Records");
            //        Console.WriteLine("Directory created");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }

            //}

            if (!File.Exists(path))
            {
                try
                {
                    File.Create(path).Dispose();
                    Console.WriteLine("File created");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
            
        }


        public void writeToFile(List<Location> records)
        {


            //Checks file size, if file is empty (less than 10 KB), if so cretes file, else appends to it
            FileInfo fi = new FileInfo(path);

            if (fi.Length < 10)
            {
                using (var writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }
            }
            else
            {
                //read all records
                var readRecords = readSavedLocations();

                //check if any of the passed record names are in the file, if so remove them from the list
                foreach (var readRecord in readRecords)
                {
                    foreach (var passedRecord in records.ToList()) 
                    {
                        if (readRecord.Name.Equals(passedRecord.Name))
                        {
                            records.Remove(passedRecord);
                            Console.WriteLine("Duplicate " + passedRecord.Name);
                        }
                    }
                }
                

                //Exit if list is empty
                if (!records.Any())
                {
                    return;
                }
                //write all the left records to file
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    // Don't write the header again.
                    HasHeaderRecord = false,
                };
                using (var stream = File.Open(path, FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, config))
                {
                    csv.WriteRecords(records);
                }
            }

        }

        public List<Location> readSavedLocations()
        {
            //read file
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<Location> records = csv.GetRecords<Location>().ToList();
                return records;
            }

        }

        public String getPath()
        {
            //read file
            var newDir = Directory.GetCurrentDirectory();
            return newDir;
        }

    }
}