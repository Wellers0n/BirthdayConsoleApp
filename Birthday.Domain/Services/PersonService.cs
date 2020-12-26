using Birthday.Domain.Entities;
using Birthday.Domain.Interfaces.Repositories;
using Birthday.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Birthday.Domain.Services
{
    public class PersonService : IAddPerson, IDeletePerson, IEditPerson, IGetPerson, IGetPersonById, IGetBirthdayPerson
    {

        private readonly IPersonRepository repository;

        public PersonService(IPersonRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Person person)
        {
            repository.Add(person);
        }

        public void Delete(Guid id)
        {
            Person person = GetPersonById(id);
            repository.Delete(person);
        }

        public List<Person> GetPerson(string search)
        {
            if (search != null)
            {
                return repository.GetAllPerson().Where(person => person.Name.Contains(search)).ToList();
            }
            return repository.GetAllPerson().ToList();
        }

        public Person GetPersonById(Guid id)
        {
            return repository.GetAllPerson().First(person => person.Id == id);
        }

        public void Edit(Guid id, string name, string date)
        {
            Person PersonEdited = GetPersonById(id);
            PersonEdited.Name = name;
            PersonEdited.Date = DateTime.Parse(date + " " + DateTime.Now.TimeOfDay);
            repository.Edit(PersonEdited);
        }

        public List<Person> GetBirthdayPerson()
        {
            var cultureInfo = new CultureInfo("pt-BR");
            string dateString = DateTime.Now.ToString();
            var dateTime = DateTime.Parse(dateString, cultureInfo);
            return repository.GetAllPerson().Where(person => person.Date.Day.Equals(dateTime.Date.Day) && person.Date.Month.Equals(dateTime.Date.Month)).ToList();
        }
    }
}
