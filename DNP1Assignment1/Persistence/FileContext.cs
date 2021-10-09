using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DNP1Assignment1.Models;

namespace DNP1Assignment1.Persistence
{
    public class FileContext : IFileContext
    {
        public IList<Adult> Adults { get; private set; }

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
            foreach (var adult in Adults)
            {
                if (adult.JobTitle == null)
                {
                    adult.JobTitle.JobTitle = "No job";
                    adult.JobTitle.Salary = 0;
                }
            }
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {

            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }

        public void AddAdult(Adult adult)
        {
            int max = Adults.Max(adult => adult.Id);
            adult.Id = (++max);
            Adults.Add(adult);
            SaveChanges();
        }

        public IList<Adult> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(Adults);
            return tmp;
        }
    }
}