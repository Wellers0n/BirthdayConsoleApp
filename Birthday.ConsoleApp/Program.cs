using Birthday.Domain.Entities;
using Birthday.Domain.Services;
using Birthday.Infrastructure.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PersonService(new PersonRepository());
            int option = 0;

            do
            {
                Console.WriteLine("1 - Registrar Pessoa");
                Console.WriteLine("2 - Editar Pessoa");
                Console.WriteLine("3 - Imprimir Pessoas");
                Console.WriteLine("4 - Deletar Pessoa");
                Console.WriteLine("5 - Buscar Pessoa");
                Console.WriteLine("6 - Aniversáriantes de hoje");
                Console.WriteLine("7 - Sair");

                option = int.Parse(Console.ReadLine());
                Person person;

                switch (option)
                {
                    case 1:
                        person = new Person();
                        person.Id = Guid.NewGuid();
                        Console.WriteLine("Digite seu nome");
                        person.Name = Console.ReadLine();
                        Console.WriteLine("Digite o data de aniversário");
                        var date = Console.ReadLine();
                        person.Date = DateTime.Parse(date+" "+DateTime.Now.TimeOfDay);
                        service.Add(person);
                        break;
                    case 2:
                        Console.WriteLine("Digite o Id do contato que deseja editar");
                        var Id = Guid.Parse(Console.ReadLine());

                        var editPerson = service.GetPersonById(Id);

                        Console.WriteLine("Digite o novo nome");
                        var Name = Console.ReadLine();

                        Console.WriteLine("Digite uma nova data de aniversário");
                        var Date = Console.ReadLine();

                       service.Edit(Id, Name, Date);
                        break;
                    case 3:
                        var personList = service.GetPerson("");
                        foreach (var p in personList)
                        {
                            Console.WriteLine("-");
                            Console.WriteLine("Id: " + p.Id);
                            Console.WriteLine("Nome: " + p.Name);
                            Console.WriteLine("Data: " + p.Date);
                            Console.WriteLine("===");

                        }
                        break;
                    case 4:
                        Console.WriteLine("Digite o Id do contato que deseja editar");
                        var IdDelete = Console.ReadLine();
                        if(IdDelete != "")
                        {
                        service.Delete(Guid.Parse(IdDelete));
                        } else
                        {
                            Console.WriteLine("Id inválido");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Digite seu nome");
                        string NameSearch = Console.ReadLine();
                        var listSerached = service.GetPerson(NameSearch);
                        if(listSerached.Count == 0)
                        {
                            Console.WriteLine("-");
                            Console.WriteLine("Nenhuma pessoa encontrada com esse nome");
                            Console.WriteLine("===");
                        } else
                        {
                            foreach (var p in listSerached)
                            {
                                Console.WriteLine("-");
                                Console.WriteLine("Id: " + p.Id);
                                Console.WriteLine("Nome: " + p.Name);
                                Console.WriteLine("Data: " + p.Date);
                                Console.WriteLine("===");

                            }
                        }
                       
                        break;
                    case 6:
                        var birthdayToday = service.GetBirthdayPerson();
                        if(birthdayToday.Count == 0 )
                        {
                            Console.WriteLine("-");
                            Console.WriteLine("Ninguém faz aniversário hoje");
                            Console.WriteLine("===");
                        } else
                        {
                        foreach (var p in birthdayToday)
                        {
                            Console.WriteLine("-");
                            Console.WriteLine("Id: " + p.Id);
                            Console.WriteLine("Nome: " + p.Name);
                            Console.WriteLine("Data: " + p.Date);
                            Console.WriteLine("===");

                        }

                        }
                        break;
                }

            } while (option != 7);

        }
    }
}
