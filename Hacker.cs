using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game configuration data
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string menuhint = "Type Menu to go back to main menu";

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }
    void Update()
    {
        int index = Random.Range(0, level1Passwords.Length);
        print(index);
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskforPassword();
        }

        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void AskforPassword()
    {
        print(level1Passwords.Length);
        print(level2Passwords.Length);
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password,hint: " + password.Anagram());


        Terminal.WriteLine(menuhint);
    }

     void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number!");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskforPassword();
        }
    }

     void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

     void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Here's a book for ya!");
                Terminal.WriteLine(@"

     ______
    /     //
   /     //
  /     //
 /_____//
(_____(/

                ");


                Terminal.WriteLine(menuhint);
                break;
                
            case 2:
                Terminal.WriteLine("You got the prison key");
                Terminal.WriteLine(@"

/0 \__________
\__/-='-=-'-='

                ");


                Terminal.WriteLine(menuhint); ;
                break;
                
        }
        
    }
}