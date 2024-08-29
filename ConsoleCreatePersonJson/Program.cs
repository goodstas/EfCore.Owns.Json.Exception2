using System.Text.Json;
using WebApplication1.Models;

namespace ConsoleCreatePersonJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person()
            {
                Id = Guid.NewGuid(),
                Name = $"aaa",
                PersonalDetails = new Details()
                {
                    BoolDetail = true,
                    StrDetail = "asdasdada",
                    SubDetails = new List<SubDetail> { new SubDetail() { IntSubDetail = 1, DoubleSubDetail = 1.0, StrSubDetail = "a"},
                                                       new SubDetail() { IntSubDetail = 2, DoubleSubDetail = 2.0, StrSubDetail = "b"},
                                                       new SubDetail() { IntSubDetail = 3, DoubleSubDetail = 3.0, StrSubDetail = "c"}}
                }
            };


            var jsonPerson = JsonSerializer.Serialize(person);

            Console.WriteLine(jsonPerson);
        }
    }
}
