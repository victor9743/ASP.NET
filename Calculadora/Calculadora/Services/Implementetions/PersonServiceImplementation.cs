using Calculadora.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Calculadora.Services.Implementetions
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for(int x= 0; x<8; x++)
            {
                Person person = MockPerson(x);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int x)
        {
            return new Person
            {

                id = IncrementAndGet(),
                firstName = "Primeiro Nome" + x ,
                lastName = "Ultimo Nome" + x,
                endereco = "Brazil" + x,
                gender = "Male"

            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person {
                
                id= IncrementAndGet(),
                firstName ="Victor",
                lastName = "Costa",
                endereco ="Brazil",
                gender = "Male"

            };


        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
