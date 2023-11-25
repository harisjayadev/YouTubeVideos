// See https://aka.ms/new-console-template for more information
using MongoDB.Driver;
using MongoDB.Bson;

const string connectionUri = "mongodb+srv://harishankaran1987:UB24taWL8HSoM8Ha@cluster0.oauc7wb.mongodb.net/?retryWrites=true&w=majority";

var settings = MongoClientSettings.FromConnectionString(connectionUri);

// Set the ServerApi field of the settings object to Stable API version 1
settings.ServerApi = new ServerApi(ServerApiVersion.V1);

// Create a new client and connect to the server
var client = new MongoClient(settings);

// Send a ping to confirm a successful connection
try
{
    var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");

    
    Console.WriteLine("Hello, World!");


    var collection = client.GetDatabase("LearnMongo").GetCollection<Community>("Community");

    //var com = new List<Community>();
    //for (int i = 0; i < 10; i++)
    //{
    //    var c1 = new Community(i, "Name" + i);
    //    c1.Persons= new List<Person>();
    //    for (int j = 0; j < 50; j++)
    //    {
    //        c1.Persons.Add(new Person(j, "name" + j, DateTime.Now.AddDays(-j)));
    //    }
    //    com.Add(c1);
    //}

    //await collection.InsertManyAsync(com);


    ////var filter = Builders<Community>.Filter.Eq("title", "Back to the Future");
    //var document = collection.Find(filter).First();

    FilterDefinition<Community> x = Builders<Community>.Filter.Gt(c => c.Id, 1);
    var document = collection.Find(x).ToList();


    FilterDefinition<Community> x1 = Builders<Community>.Filter.ElemMatch(c => c.Persons, p => p.Name.Equals("name1"));

    var document1 = collection.Find(x1).ToList();

    Console.WriteLine("mm");
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}


public class Person
{
    public Person(int id, string name, DateTime dob)
    {
        Id = id;
        Name = name;
        Dob = dob;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Dob { get; set; }
}

public class Community
{
    public Community(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Person>? Persons { get; set; }
}






