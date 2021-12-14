using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "onion", "sheep", "tractor", "plow", "corn", "pasture" };
    string[] level2Passwords = { "brick", "concrete", "asphalt", "excavator", "bulldozer", "hammer" };
    string[] level3Passwords = { "hereditary", "ecosystem", "prokariot", "bacteria", "molecule", "nucleus" };

    // Game State 
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    private void Update()
    {
        // int index = Random.Range(0, level1Passwords.Length);
        // print(index);
    }
    void ShowMainMenu()
    {
        level = 0;
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into ?");
        Terminal.WriteLine("Input 1 to access Farming records.");
        Terminal.WriteLine("Input 2 to access Construction records.");
        Terminal.WriteLine("Input 3 to access Biological records.");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
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
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else  if (input == "GREYGOO")  // easter egg
        {
            Terminal.WriteLine("Welcome Goo");
        }
        else
        {
            Terminal.WriteLine("Please select a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
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
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
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
            AskForPassword();
        }
        Terminal.WriteLine(menuHint);
    }
    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Pretty good !");
                Terminal.WriteLine(@"	
         .-.
        (. .)__,')
        / V      )
  ()    \  (   \/
<)-`\()  `._`._ \
  <).>=====<<==`'====
   C-'`(>    
"
                );
                break;
            case 2:
                Terminal.WriteLine("Have a cup of coffee !");
                Terminal.WriteLine(@"
          oOOOOOo
         ,|    oO
        //|     |
        \\|     |
          `-----`
"
                );
                break;
            case 3:
                Terminal.WriteLine("Here is a diamond for you !");
                Terminal.WriteLine(@"
        _______
      .'_/_|_\_'.
      \`\  |  /`/
       `\\ | //'
         `\|/`
"
                );
                break;
        }
    }
}
