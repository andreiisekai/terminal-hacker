using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State 
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
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

    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else  if (input == "3")
        {
            level = 3;
            StartGame();
        }
        else  if (input == "GREYGOO")
        {
            Terminal.WriteLine("Welcome Goo");
        }
        else
        {
            Terminal.WriteLine("Waa waa waa, Wrong answer");
        }
    }

    void StartGame()
    {
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
        currentScreen = Screen.Password;
    }
}
