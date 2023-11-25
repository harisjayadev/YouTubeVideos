// See https://aka.ms/new-console-template for more information
using System.Linq;

Console.WriteLine("Hello, World!");

List<Person> list = new List<Person>
{
    new Person(1, "Hari", 14),
    new Person(2, "Shankar", 10),
    new Person(3, "Karan", 12)
};

//list.OrderByDescending(x => x.Age).ToList();

Func<Person,int> keySelector = x => x.Age;
var c = HEnumerable.HOrderByDescending(list, xc => xc.Age).ToList();

Console.ReadLine();
public class Person
{
    public Person(int id,string name,int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public static class HEnumerable
{
    public static IOrderedEnumerable<TSource> HOrderByDescending<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        return source.OrderByDescending(keySelector);
    }
}