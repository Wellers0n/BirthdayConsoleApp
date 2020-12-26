using Birthday.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday.Domain.Interfaces.Services
{
    public interface IDeletePerson
    {
        void Delete(Guid id);

    }
}
