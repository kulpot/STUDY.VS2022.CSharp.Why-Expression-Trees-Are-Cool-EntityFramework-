using System;
using System.Linq;
using System.Data.Entity;

//ref link:https://www.youtube.com/watch?v=RYvuaU47h2w&list=PLRwVmtr-pp06SlwcsqhreZ2byuozdnPlg&index=9&t=10s
//

class MeContext : DbContext
{
   public MeContext() : base("meConnectionInfo") { }
    public DbSet<Person> People { get; set; }
}

class Person
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

class MainClass
{
    static void Main()
    {
        var plumber = new MeContext();
        foreach(Person person in plumber.People.AsEnumerable().Where(p => p.Age > 30))  // deferred execution knowledge
            Console.WriteLine(person.FirstName + " " + person.LastName);
    }
}