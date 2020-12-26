using Birthday.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday.Domain.Interfaces.Services
{
    public interface IEditPerson
    {
        void Edit(Guid id, string name, string date);

    }
}
