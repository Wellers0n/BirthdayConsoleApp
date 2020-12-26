using Birthday.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday.Domain.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        void Add(Person person);
        List<Person> GetAllPerson();
        void Edit(Person person);
        void Delete(Person person);
    }
}
