

using System.Net.Sockets;

int maxValueOfNumber = 100;
string[] optionsNames = ["ADDITION", "SUBSTRACTION", "MULTIPLICATION", "DIVISION"];
string[] mainMenuStrings = ["STANDARD MODE", "RANDOMIZER", "CHOOSE DIFFICULTY", "GAMES HISTORY"];
char[] opperands = ['+', '-', '*', '/'];
var randomVar = new Random();

void handleReadKey()
{

}
void startBasicGame(int selectedGame)
{
    Console.Clear();
    Console.WriteLine("Calculate this equation:");

    int correctAnswer = 0;
    int firstNumber = randomVar.Next(maxValueOfNumber);
    int secondNumber = randomVar.Next(maxValueOfNumber);

    switch (selectedGame)
    {
        case 0:
            correctAnswer = firstNumber + secondNumber;
            break;
        case 1:
            correctAnswer = firstNumber - secondNumber;
            break;
        case 2:
            correctAnswer = firstNumber * secondNumber;
            break;
        case 3:
            correctAnswer = firstNumber / secondNumber;
            break;

    }

    Console.Write($"{firstNumber} {opperands[selectedGame]} {secondNumber} = ");
    var userAnswer = Console.ReadLine();

    if (userAnswer != null && userAnswer.Equals(correctAnswer.ToString()))
    {
        Console.WriteLine("Good job!");
    }
    else
    {
        Console.WriteLine("Wrong answer!");
    }
    Console.WriteLine("Press any key to exit");
    Console.ReadKey();

}

int showMenu(string[] namesTable, string menuHeader)
{
    ConsoleKey clickedKey;
    int selectedOption = 0;
    do
    {
        Console.Clear();
        if(menuHeader != null)
            Console.WriteLine(menuHeader);

        for (int i = 0; i < namesTable.Length; i++)
        {
            if (selectedOption == i)
                Console.Write("--> ");
            Console.WriteLine(namesTable[i]);
        }

        handleReadKey();
        clickedKey = Console.ReadKey().Key;

        //UP click
        if (clickedKey == ConsoleKey.UpArrow)
        {
            if (selectedOption == 0)
                selectedOption = namesTable.Length - 1;
            else
                selectedOption -= 1;
        }

        //DOWN click
        if (clickedKey == ConsoleKey.DownArrow)
        {
            if (selectedOption == (namesTable.Length-1))
                selectedOption = 0;
            else
                selectedOption += 1;
        }       
        
        //ESC click
        if (clickedKey == ConsoleKey.Escape)
        {
            return -1;
        }

    } while (clickedKey != ConsoleKey.Enter);

    return selectedOption;
}


//menu for choosing mode of game
void main()
{
    int outcome;
    //making game in loop until user quits
    do
    {
        //show main menu
        outcome = showMenu(mainMenuStrings, "Navigate with arrows and use ESC to go back");

        //standard mode
        if(outcome == 0)
        {
            var mode = showMenu(optionsNames, "Choose your game (UP/DOWN ARROWS):");
            if (mode != -1)
                startBasicGame(mode);
        }
        //randomizer
        if (outcome == 1)
        {
            startBasicGame(randomVar.Next() % 4);
        }
    } while (outcome != -1);
}

main();