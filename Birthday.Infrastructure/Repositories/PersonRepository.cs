using System;
using System.Collections.Generic;
using System.Text;
using Birthday.Domain.Interfaces.Repositories;
using Birthday.Domain.Entities;
using System.IO;
using System.Linq;

namespace Birthday.Infrastructure.DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private static List<Person> Persons = new List<Person>();

        public void Add(Person person)
        {
            Persons.Add(person);
            StreamWriter File = new StreamWriter(FileName(), true);
            File.WriteLine(person.Id + ";" + person.Name + ";" + person.Date);
            File.Close();
        }

        private string FileName()
        {
            var filepath = Environment.SpecialFolder.Desktop;

            string root = Environment.GetFolderPath(filepath);

            string fileName = @"\Birthday.txt";

            return root + fileName;

        }

        public void Delete(Person person)
        {
            Persons.Remove(person);
            File.Delete(FileName());
            FileStream file;

            if (!File.Exists(FileName()))
            {
                file = File.Create(FileName());
                file.Close();
            }

            foreach (Person p in Persons.ToList())
            {
                Add(p);
            }
        }

        public List<Person> GetAllPerson()
        {
            FileStream newFile;

            if (!File.Exists(FileName()))
            {
                newFile = File.Create(FileName());
                newFile.Close();
            }

            var file = new StreamReader(FileName());
            var line = file.ReadLine();
            Persons.Clear();

            while (line != null)
            {
                var lineSplited = line.Split(';');

                Person person = new Person();

                person.Id = Guid.Parse(lineSplited[0]);
                person.Name = lineSplited[1];
                person.Date = DateTime.Parse(lineSplited[2]);
                Persons.Add(person);

                line = file.ReadLine();
            }
            file.Close();

            return Persons;
        }

        public void Edit(Person person)
        {
            Delete(person);
            Add(person);
        }
    }
}
