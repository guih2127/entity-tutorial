using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            AdventureWorks2017Entities context = new AdventureWorks2017Entities();

            Address address = new Address();
            address.AddressLine1 = "Rua dos Bobos, 0";
            address.AddressLine2 = "Bairro do Morais";
            address.City = "Vinicius";
            address.PostalCode = "00000-000";
            address.StateProvinceID = 1;
            address.rowguid = new Guid();
            address.ModifiedDate = DateTime.Now;

            context.Addresses.Add(address);
            context.SaveChanges();
            // Inclusão de um address na tabela, utilizando o Entity Framework.

            Address ourAddress = new Address();
            ourAddress = (from a in context.Addresses
                          where a.PostalCode == "00000-000"
                          select a).First();

            Console.WriteLine(ourAddress.AddressLine1 + " " + ourAddress.AddressLine2);
            // Obtendo o registro que acabamos de incluir, através do LINQ To Entities.
            // A ordem é até um pouco mais lógica que a do SQL, primeiro, definimos a tabela da 
            // qual queremos obter os dados. Segundo, colocamos a condição que queremos e, terceiro,
            // utilizamos o select. O metódo First() pega o primeiro valor retornado e o atribui à nossa variável.

            Address ourAddress2 = new Address();
            ourAddress2 = context.Addresses.Where(x => x.PostalCode == "00000-000").First();
            // Obtemos o mesmo registro a partir de uma outra forma, utilizando uma expressão LAMBDA. A diferença entre o LAMDBA
            // e o LINQ é basicamente sintaxe, então cabe ao desenvolvedor escolher a melhor maneira de trabalhar, de acordo
            // com o que deve ser feito. Por exemplo, em alguns casos, com condições e agrupamentos, pode ser mais vantajoso utilizar
            // o LINQ, por exemplo.

            context.Addresses.Remove(ourAddress);
            context.SaveChanges();
            // Por fim, removendo o nosso registro do banco de dados.
            Console.ReadKey();
        }
    }
}
