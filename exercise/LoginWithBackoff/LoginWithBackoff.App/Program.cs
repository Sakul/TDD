using LoginWithBackoff.App;
using LoginWithBackoff.App.Models;

const string TitleName = "Login with Backoff Challenge";
Console.WriteLine(TitleName);

var auth = new Authenticator();
LoginResult loginResult;

do
{
    Console.WriteLine(new string('─', TitleName.Length));
    Console.Write("Username: ");
    var username = Console.ReadLine();
    Console.Write("Password: ");
    var password = Console.ReadLine();
    loginResult = auth.Login(username, password, DateTime.Now);
    Console.Write($"Login attempts ({loginResult.AttemptCount}): ");
    if (loginResult.UnlockTime.HasValue)
    {
        var diff = loginResult.UnlockTime.Value - loginResult.CurrentServerTime;
        Console.WriteLine($"Failed, try again in {diff}.");
    }
} while (string.IsNullOrWhiteSpace(loginResult.Token));

Console.WriteLine($"Successful, token: {loginResult.Token}");