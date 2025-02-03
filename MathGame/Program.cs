// See https://aka.ms/new-console-template for more information

string x;
void startGame()
{

    ConsoleKey clickedKey;
    int selectedOption = 0;
    string[] optionsNames = ["ADDITION", "SUBSTRACTION", "MULTIPLICATION", "DIVISION"];

    do
    {
        Console.Clear();
        Console.WriteLine("Choose your game (UP/DOWN ARROWS): ");
        
        for(int i = 0;i<optionsNames.Length;i++)
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

startGame();