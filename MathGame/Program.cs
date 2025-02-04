

using System.Net.Sockets;

int[] maxValueOfNumber = {10,30,100};
string[] optionsNames = ["ADDITION", "SUBSTRACTION", "MULTIPLICATION", "DIVISION"];
string[] mainMenuStrings = ["STANDARD MODE", "RANDOMIZER", "CHOOSE DIFFICULTY", "GAMES HISTORY"];
string[] difficultiesLevel = ["EASY", "NORMAL", "HARD"];
char[] opperands = ['+', '-', '*', '/'];
var randomVar = new Random();
int gameLength = 3;
int difficultyLevel = 0;

void handleReadKey()
{

}

int startBasicGame(int selectedGame, int currentRound, int maxRounds)
{
    Console.Clear();
    Console.WriteLine($"Calculate this equation ({currentRound}/{maxRounds}):");

    int correctAnswer = 0;
    //need to fix making numbers
    int firstNumber = randomVar.Next(maxValueOfNumber[difficultyLevel]);
    int secondNumber = randomVar.Next(maxValueOfNumber[difficultyLevel]);

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
    var points = 0;

    if (userAnswer != null && userAnswer.Equals(correctAnswer.ToString()))
    {
        Console.WriteLine("Good job!");
        points = 1;
    }
    else
    {
        Console.WriteLine("Wrong answer!");
        points = 0;
    }

    Console.WriteLine("Press any key to " + (currentRound == maxRounds ? "exit" : "continue"));
    Console.ReadKey();

    return points;

}

int showMenu(string[] namesTable, string menuHeader, int selectedOption = 0)
{
    ConsoleKey clickedKey;
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
            if (mode == -1)
                break;
            
            for (int i = 0; i < gameLength; i++)
                startBasicGame(mode, (i + 1), gameLength);
        }
        //randomizer
        if (outcome == 1)
        {
            for(int i = 0;i<gameLength;i++)
                startBasicGame((randomVar.Next() % optionsNames.Length), (i + 1), gameLength);
        }
        //randomizer
        if (outcome == 2)
        {
            difficultyLevel = showMenu(difficultiesLevel, "Choose difficulty", difficultyLevel);
        }
    } while (outcome != -1);
}

main();