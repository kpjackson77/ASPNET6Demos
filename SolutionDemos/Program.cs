// See https://aka.ms/new-console-template for more information

class SomeData
{
  public string Desc { get; set; }
  public int Number { get; set; }
}
record SomeData2(string Desc, int Number) { }

class Program
{
  public static void Main()
  {
    string msg = null;

    Console.WriteLine(msg.Length);



    SomeData sd = new SomeData() { Desc = "Something", Number = 2 };
    SomeData2 sd2 = new SomeData2( "Something", 2);

    Console.WriteLine(sd);
    Console.WriteLine(sd2);
    Console.WriteLine($"{sd2.Desc}, {sd2.Number}");

    Console.WriteLine("Hello, World!");

    Console.WriteLine("Hello Again!");

  }
}
