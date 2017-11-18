using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// classes are grouped together making a namespace


public class Hacker : MonoBehaviour {


    // Function/Method for initialization
    // Functions "Messages" 
    // get called from outside the 
    // class.
    // OnStart

    
    int level; //Game State 0
    enum Screen { MainMenu, Password,  Win }; 
    Screen currentScreen;
    string password;
    string[] lvlOnePasswords = { "search", "purple", "password", "help", "find" };
    string[] lvlTwoPasswords = { "federal", "criminal", "financial", "savings", "private", };
    string[] lvlThreePasswords = { "interpolate", "clandestine", "crossword", "algorithm", "national" };
    //private System.Random rand = new System.Random(); //Make the passwords randomized

    void Start() {

        ShowMainMenu();

    }
    void ShowMainMenu()
    {

        currentScreen = Screen.MainMenu;

        Terminal.ClearScreen();

        Terminal.WriteLine("Welcome to Terminal Hacker");
        Terminal.WriteLine("Test your Hacking skills");
        Terminal.WriteLine("Please choose your skill level" +
            "\n");
        Terminal.WriteLine("Enter (0) for Yahoo (Easy)");
        Terminal.WriteLine("Enter (1) for Credit Bureau (Medium)");
        Terminal.WriteLine("Enter (2) for NSA (Hard)\n");
        Terminal.WriteLine("To return type menu at any time");
        Terminal.WriteLine("Skill Level (0 - 2): ");


        //  string helloMessage = " ";
        //  Terminal.WriteLine(helloMessage);

    }
    void OnUserInput(string input)
    {

        //Execution Flow 
        string menu = input.ToUpper();


        if (menu == "MENU")
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
        bool isValdiLevelNumber = (input == "0" || input == "1" || input == "2" );
        if (isValdiLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }

        else if (input == "007")
        {
            Terminal.WriteLine("Please Select a level Mr. Bond");
        }

        else
        {
            Terminal.WriteLine("Please enter a valid selection");
        }

    }
    
    void AskForPassword()
    {
        currentScreen = Screen.Password;

        Terminal.ClearScreen();
        GenerateRandomPassword();
        Terminal.WriteLine("Hint: " + password.Anagram());
        Terminal.WriteLine("Enter Password:");

    }
    void GenerateRandomPassword()
    {
        print(1);
        
        switch (level)
        {
            case 0:
                print(password);
                password = lvlOnePasswords[UnityEngine.Random.Range(0, 5)];
                print(password);
                break;

            case 1:

                password = lvlTwoPasswords[UnityEngine.Random.Range(0, 5)];
                break;

            case 2:
                password = lvlThreePasswords[UnityEngine.Random.Range(0, 5)];
                break;

            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }
    void CheckPassword(string input)
    {
       
        //currentScreen = Screen.Password;
        //GenerateRandomPassword();

        if (input.ToLower() == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("This attempt has been logged.");
            Terminal.WriteLine("Hint: " + password.Anagram());
            // AskForPassword();
        }

    }
    void DisplayWinScreen()
    {
        Terminal.ClearScreen();
        
        switch (level)
        {
            case 0:
                Terminal.WriteLine(@"C:\\Yahoo\\SuperSecretFiles> 
 __     __   _                 
 \ \   / /  | |                
  \ \_/ /_ _| |__   ___   ___  
   \   / _` | '_ \ / _ \ / _ \ 
    | | (_| | | | | (_) | (_) |
    |_|\__,_|_| |_|\___/ \___/ 
                                 ");
                break;
            case 1:
                Terminal.WriteLine(@"admin@equifax.com:~$  
   ___ ___  _   _ ___ ___ _  __  __
 | __/ _ \| | | |_ _| __/_\ \ \/ /
 | _| (_) | |_| || || _/ _ \ >  < 
 |___\__\_\\___/|___|_/_/ \_/_/\_\
                                  
                       
                                 ");
                break;
            case 2:
                Terminal.WriteLine(@"root:~ 
  _   _ ____    _    
 | \ | / ___|  / \   
 |  \| \___ \ / _ \  
 | |\  |___) / ___ \ 
 |_| \_|____/_/   \_\
                                 ");
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
        Terminal.WriteLine("Type Menu at any time");
        currentScreen = Screen.Win;
    }

}
