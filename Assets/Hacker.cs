using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    const string menuHint = "[REMINDER]: You may type 'menu' at any time you want to.";
    string[] level1Passwords = { "books", "directories", "shelf", "folders", "pages" };
    string[] level2Passwords = { "prisoners", "inmates", "stations", "warrant", "arrest" };
    string[] level3Passwords = { "constellations", "spaceships", "intergalactic", "explorations", "astronauts" };
    
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 for the library.");
        Terminal.WriteLine("Press 2 for the police station.");
        Terminal.WriteLine("Press 3 for NASA.");
        Terminal.WriteLine("\nEnter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            Terminal.ClearScreen();
            ShowMainMenu();
        }
        else if (input.Equals("007"))
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("\nWelcome Mr. Bond!\nType 'menu' and choose a level.");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            Terminal.ClearScreen();
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input.Equals("1"))
        {
            level = 1;
            StartGame();
        }
        else if (input.Equals("2"))
        {
            level = 2;
            StartGame();
        }
        else if (input.Equals("3"))
        {
            level = 3;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
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
                Debug.LogError("INVALID!");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayScreen();
        }
        else
        {
            StartGame();
        }
    }

    void DisplayScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Here's your book, Mr. Bond!");
                Terminal.WriteLine(@"
         ___________
        /         //
       / BOOK OF //
      /    C#   //
     /________ //
    (_________(/           
    "
                );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key, Mister!");
                Terminal.WriteLine("Play again for a greater challenge.");
                Terminal.WriteLine(@"
         __
        /0 \_______
        \__/-=' = '         
        "
                );
                break;
            case 3:
                Terminal.WriteLine(@"
     _ __   __ _ ___  __ _
    | '_ \ / _` / __|/ _` |
    | | | | (_| \__ \ (_| |
    |_| |_|\__,_|___)\__,_|
    "
                );
                Terminal.WriteLine("Welcome to NASA's internal system!");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
