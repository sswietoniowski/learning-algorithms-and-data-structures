using neetcode;

Console.WriteLine("Hello Algorithms & Data Structures");

string[] words = new string[]
{
    "Hello", "Algorithms", "Data", "Structures"
};

Codec codec = new Codec();

string result = codec.encode(words);

Console.WriteLine(result);

IList<string> result2 = codec.decode(result);

foreach (var s in result2)
{
    Console.WriteLine(s);
}