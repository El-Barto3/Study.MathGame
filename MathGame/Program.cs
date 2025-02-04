

using System.Net.Sockets;

int[] maxValueOfNumber = { 10, 30, 100 };
int[] minValueOfNumber = { 1, 10, 30 };
string[] standardGames = ["ADDITION", "SUBSTRACTION", "MULTIPLICATION", "DIVISION"];
string[] mainMenuStrings = ["STANDARD MODE", "RANDOMIZER", "CHOOSE DIFFICULTY", "GAMES HISTORY"];
string[] difficultiesLevel = ["EASY", "NORMAL", "HARD"];
char[] opperands = ['+', '-', '*', '/'];
var randomVar = new Random();
int gameLength = 3;
int difficultyLevel = 0;
string[] gamesHistory = new string[10];

int findLastNonEmpty(string[] array)
{
    int lastIndex = -1;
    for (int i = array.Length - 1; i >= 0; i--)
    {
        if (array[i] != null)
        {
            lastIndex = i;
            break; // Stop at the first non-empty element
        }
    }
    return lastIndex;
}

int startBasicGame(int selectedGame, int currentRound, int maxRounds)
{
    Console.Clear();
    Console.WriteLine($"Calculate this equation ({currentRound}/{maxRounds}):");

    int correctAnswer = 0;
    //need to fix making numbers
    int firstNumber = randomVar.Next(minValueOfNumber[difficultyLevel], maxValueOfNumber[difficultyLevel]);
    int secondNumber = randomVar.Next(minValueOfNumber[difficultyLevel], maxValueOfNumber[difficultyLevel]);

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
    var point = 0;

    if (userAnswer != null && userAnswer.Equals(correctAnswer.ToString()))
    {
        Console.WriteLine("Good job!");
        point = 1;
    }
    else
        Console.WriteLine("Wrong answer!");

    Console.WriteLine("Press any key to " + (currentRound == maxRounds ? "exit" : "continue"));
    Console.ReadKey();

    return point;

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

        clickedKey = Console.ReadKey().Key;

        //UP click
        if (clickedKey == ConsoleKey.UpArrow)
        {
            if (selectedOption <= 0)
                selectedOption = namesTable.Length - 1;
            else
                selectedOption -= 1;
        }

        //DOWN click
        if (clickedKey == ConsoleKey.DownArrow)
        {
            if (selectedOption >= (namesTable.Length-1))
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
            var mode = showMenu(standardGames, "Choose your game (UP/DOWN ARROWS):");
            if (mode == -1)
                continue;
            
            for (int i = 0; i < gameLength; i++)
                startBasicGame(mode, (i + 1), gameLength);
        }        
        
        //randomizer mode
        if (outcome == 0)
        {
            var mode = showMenu(standardGames, "Choose your game (UP/DOWN ARROWS):");
            if (mode == -1)
                continue;

            for (int i = 0; i < gameLength; i++)
                startBasicGame(mode, (i + 1), gameLength);
        }

        //randomizer and standard
        if (outcome == 1 || outcome == 0)
        {
            var pointsSum = 0;
            for(int i = 0;i<gameLength;i++)
                pointsSum += startBasicGame((randomVar.Next() % standardGames.Length), (i + 1), gameLength);

            var indexOfEmpty = Array.IndexOf(gamesHistory, null);
            if (indexOfEmpty == -1)
            {
                indexOfEmpty = gamesHistory.Length;
                Array.Resize(ref gamesHistory, (gamesHistory.Length + 10));
            }

            gamesHistory[indexOfEmpty] = $"No. {indexOfEmpty+1}\tDifficulty: {difficultiesLevel[difficultyLevel]}\tMode: {mainMenuStrings[1]}\tScore: {pointsSum} / {gameLength}";
        }

        //difficulty level
        if (outcome == 2)
        {
            var newDifficulty = showMenu(difficultiesLevel, "Choose difficulty", difficultyLevel);
            difficultyLevel = newDifficulty != -1 ? newDifficulty : difficultyLevel;
        }   
        
        //games history panel
        if (outcome == 3)
        {
            var lastValid = findLastNonEmpty(gamesHistory);
            showMenu(gamesHistory[0..(lastValid + 1)], "Games history", -1); //dont show choosing arrow and null elements when loaded
        }
    } while (outcome != -1);
}

main();
Console.WriteLine("test");