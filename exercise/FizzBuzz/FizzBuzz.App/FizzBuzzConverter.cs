namespace FizzBuzz.App
{
    public class FizzBuzzConverter
    {
        public string Convert(string input)
        {
            if (input == "3") return "Fizz";
            if (input == "5") return "Buzz";
            return input;
        }
    }
}
