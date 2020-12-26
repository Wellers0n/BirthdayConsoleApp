using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
