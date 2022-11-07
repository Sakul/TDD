using FizzBuzz.App;

const string TitleName = "FizzBuzz Challenge";
Console.WriteLine(TitleName);

var converter = new FizzBuzzConverter();
var input = string.Empty;

do
{
    Console.WriteLine(new string('─', TitleName.Length));
    Console.Write("Number: ");
    input = Console.ReadLine();
    Console.WriteLine($"Result: {converter.Convert(input)}");

} while (input.ToLower() != "exit");