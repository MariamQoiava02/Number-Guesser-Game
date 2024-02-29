
//Program starts here
Console.WriteLine("**************");
Console.WriteLine("Number Guesser");
Console.WriteLine("**************");

//Generates a random number between 0 and 100 and sets attempts to 5
var randNumber = new Random().Next(100);
int attempts = 5;

//Actual game loop begins. 
while(true)
{
    //when attempts are less than 1, you lose and program exits.
    if(attempts < 1)
    {
        Console.WriteLine("You Lost :(");
        break;
    }

    //Asks the user to enter a number between 0-100
    Console.WriteLine("Enter your number between 0 - 100:");
    int guessedNumber;
    string enteredString = Console.ReadLine();

    //if entered string is not parseable, or out of bounds it asks the user to enter it again
    while(!int.TryParse(enteredString, out guessedNumber) || (guessedNumber < 0 || guessedNumber > 100))
    {
        Console.WriteLine("Number is invalid please enter again:");
        enteredString = Console.ReadLine();
    }

    //if guessed number is more that tha randomly generated number, we decrease the attempts 
    //and write that the user's number is higher.
    if (guessedNumber > randNumber)
    {
        Console.WriteLine("Your Number is higher");
        attempts--;
        Console.WriteLine($"You have {attempts} attempts left");
    } else if (guessedNumber < randNumber)  
    {
        Console.WriteLine("Your Number is lower");
        attempts--;
        Console.WriteLine($"You have {attempts} attempts left");
    }
    else //It breaks out of the loop and program exits if user's number is correct. 
    {
        Console.WriteLine("Congratulations!!!");
        Console.WriteLine("You Won!!!");
        break;
    }

}