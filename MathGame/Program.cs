

int selectedOption = 0;
int maxValueOfNumber = 100;
string[] optionsNames = ["ADDITION", "SUBSTRACTION", "MULTIPLICATION", "DIVISION"];
char[] opperands = ['+', '-', '*', '/'];


void startBasicGame(int selectedOperationOption)
{
    Console.Clear();
    Console.WriteLine("Calculate this equation:");

    var randomVar = new Random();
    int correctAnswer = 0;
    int firstNumber = randomVar.Next(maxValueOfNumber);
    int secondNumber = randomVar.Next(maxValueOfNumber);

    switch (selectedOperationOption)
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

    Console.Write($"{firstNumber} {opperands[selectedOperationOption]} {secondNumber} = ");
    var userAnswer = Console.ReadLine();

    if (userAnswer != null && userAnswer.Equals(correctAnswer.ToString()))
    {
        Console.WriteLine("Good job!");
    }
    else
    {
        Console.WriteLine("Wrong answer!");
    }

}

void showMenuForArythmeticModes()
{
    ConsoleKey clickedKey;
    do
    {
        Console.Clear();
        Console.WriteLine("Choose your game (UP/DOWN ARROWS): ");

        for (int i = 0; i < optionsNames.Length; i++)
        {
            if (selectedOption == i)
                Console.Write("--> ");
            Console.WriteLine(optionsNames[i]);
        }

        clickedKey = Console.ReadKey().Key;

        //UP click
        if (clickedKey == ConsoleKey.UpArrow)
        {
            if (selectedOption == 0)
                selectedOption = 3;
            else
                selectedOption -= 1;
        }

        //DOWN click
        if (clickedKey == ConsoleKey.DownArrow)
        {
            if (selectedOption == 3)
                selectedOption = 0;
            else
                selectedOption += 1;
        }

    } while (clickedKey != ConsoleKey.Enter);

}


//menu for choosing mode of game
void main()
{

    showMenuForArythmeticModes();
    startBasicGame(selectedOption);

}

main();