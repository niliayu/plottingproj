using System;
using System.IO;
using CsvHelper;
using OxyPlot;

namespace ConsoleApplication
{
    public class CsvParser
    {
        private string filename = null;
        private TextReader textReader;
        private CsvReader readerplot;

        private string filename_temp()
        {
            StringReader str = new StringReader("temp.txt");
            filename = str.ReadToEnd();
            Console.WriteLine(filename); // DEBUG
            return filename;
        }

        public void parse()
        {
            textReader = File.OpenText(filename_temp());
            readerplot = new CsvReader(textReader);
            string value;
            while (readerplot.Read())
            {
                for (int i = 0; readerplot.TryGetField<string>(i, out value); i++)
                {
                    Console.WriteLine(value);
                }
            }
            Console.WriteLine("Exit");
        }
    }
}