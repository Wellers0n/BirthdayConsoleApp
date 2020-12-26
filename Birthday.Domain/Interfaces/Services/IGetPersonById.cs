using Birthday.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday.Domain.Interfaces.Services
{
    public interface IGetPersonById
    {
        Person GetPersonById(Guid id);

    }
}
