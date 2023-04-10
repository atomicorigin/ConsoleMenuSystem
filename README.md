Namespace: MenuSystem
---------------------

The `MenuSystem` namespace provides a class called `Menu`, which allows developers to create console application menus with ease. The `Menu` class implements `IEnumerable`, providing the ability to iterate over the menu items in the collection.

Class: Menu

The `Menu` class provides the following properties and methods:

### Properties

*   `Title`: Gets or sets the title of the menu.
*   `Prompt`: Gets or sets the prompt text that is displayed before the user makes a selection.

### Methods

*   `Menu(string Title, string Prompt, bool PadPrompt = false)`: Constructs a new instance of the `Menu` class with the specified title and prompt. The `PadPrompt` parameter, when `true`, will append a colon and space to the end of the prompt text.
*   `Menu(string Title)`: Constructs a new instance of the `Menu` class with the specified title and a default prompt of "Make a Selection: ".
*   `Menu()`: Constructs a new instance of the `Menu` class with a default title of "Default Menu" and a default prompt of "Make a Selection: ".
*   `Add(KeyValuePair<char, string> MenuItem)`: Adds a new menu item to the menu. The key of the `KeyValuePair` is used as the menu item's selector key.
*   `Add(Dictionary<char, string> MenuItems)`: Adds multiple menu items to the menu. The key of each dictionary entry is used as the menu item's selector key.
*   `Add(char Key, string Title)`: Adds a new menu item to the menu with the specified selector key and title.
*   `GetEnumerator()`: Returns an `IEnumerator` that can be used to iterate over the menu items in the collection.
*   `DisplayMenu(bool ClearConsole = false)`: Displays the menu and waits for the user to make a selection. The `ClearConsole` parameter, when `true`, will clear the console before displaying the menu. If the user selects a valid menu item, the character of the selector key will be returned. If the user selects an invalid menu item, an `InvalidMenuSelectionException` will be thrown.

### Exceptions

*   `DuplicateItemException`: Thrown when attempting to add a menu item with a selector key that already exists in the menu.
*   `InvalidMenuSelectionException`: Thrown when the user selects an invalid menu item.

### Examples

The following example demonstrates how to create and display a simple menu:

```csharp
// Import the MenuSystem library
using MenuSystem;

// Set running to true
bool running = true;

// Set current menu to 1
int curMenu = 1;

// Start a loop while running is true
while (running) {

    // Use switch statement to select which menu to display
    switch (curMenu) {
        case 1:
            MainMenu(); // Display main menu
            break;
        case 2:
            SecondMenu(); // Display second menu
            break;
        case 0:
            running = false; // Stop running if user quits
            System.Console.Clear(); // Clear the console
            break;
    }
}

// Define MainMenu function
void MainMenu() {

    // Create a new menu object with title "Main Menu" and options
    Menu main = new("Main Menu") {
        { 'h', "Hello World"}, // Option to display "Hello World"
        { '2', "Goto Second Menu"}, // Option to go to second menu
        { 'q', "Quit Program"}, // Option to quit program
    };

    // Use try-catch to handle any invalid input
    try {
        // Display the menu and get the user's selection
        char Selection = main.DisplayMenu(true);

        // Respond to the user's selection
        if (Selection.Equals('h')) {
            System.Console.Clear(); // Clear the console
            System.Console.WriteLine("Hello World!"); // Display "Hello World"
            System.Console.WriteLine(); // Print a blank line
            System.Console.Write("Press Any Key to Continue ..."); // Prompt user to press a key
            System.Console.ReadKey(); // Wait for user to press a key
        } else if (Selection.Equals('2')) {
            curMenu = 2; // Go to second menu
        } else if (Selection.Equals('q')) {
            curMenu = 0; // Quit program
        }
    } catch (InvalidMenuSelectionException) {
        // Handle any invalid input by displaying an error message
        System.Console.Clear();
        System.Console.WriteLine("You have made an invalid selection!");
        System.Console.WriteLine("Please make a selection from the options shown.");
        System.Console.WriteLine();
        System.Console.WriteLine("Press Any Key to Continue ... ");
        System.Console.ReadKey();
    }
}

// Define SecondMenu function
void SecondMenu() {

    // Create a new menu object with title "Second Menu" and options
    Menu main = new("Second Menu") {
        {'d', "Display Message"}, // Option to display a message
        {'b', "Go Back to Main Menu"}, // Option to go back to main menu
        {'q', "Quit Program"}, // Option to quit program
    };

    // Use try-catch to handle any invalid input
    try {
        // Display the menu and get the user's selection
        char Selection = main.DisplayMenu(true);

        // Respond to the user's selection
        if (Selection.Equals('d')) {
            System.Console.Clear(); // Clear the console
            System.Console.WriteLine("Hello awesome person!!!"); // Display a message
            System.Console.WriteLine(); // Print a blank line
            System.Console.Write("Press Any Key to Continue ... ");
            Console.ReadKey(); // Wait for user to press a key
        } else if (Selection.Equals('b')) {
            curMenu = 1; // Go back to main menu
        } else if (Selection.Equals('q')) {
            curMenu = 0; // Quit program
        }
    } catch (InvalidMenuSelectionException) {
        // Handle any invalid input by displaying an error message
        System.Console.Clear();
        System.Console.WriteLine("You have made an invalid selection!");
        System.Console.WriteLine("Please make a selection from the options shown.");
        System.Console.WriteLine();
        System.Console.Write("Press Any Key to Continue ... ");
        System.Console.ReadKey();
    }
}
```

This example demonstrates how to use the `Menu` class to create a main menu with two options: "Hello World" and "Quit Program". The `MainMenu` method is called in a loop, which displays the menu and waits for the user to make a selection. If the user selects "Hello World", a message is displayed and the user is prompted to press a key to continue. If the user selects "Quit Program", the loop is exited and the program terminates. If the user selects an invalid menu item, an error message is displayed and the user is prompted to press a key to continue.

1.  The first line of the code imports the MenuSystem namespace, which contains the Menu class and related exceptions.
2.  The variable running is initialized to true and curMenu is initialized to 1.
3.  The while loop runs until running is set to false.
4.  Inside the loop, a switch statement is used to determine which menu to display based on the value of curMenu.
5.  When curMenu is equal to 1, the MainMenu function is called, which displays the main menu and handles user input.
6.  When curMenu is equal to 2, the SecondMenu function is called, which displays the second menu and handles user input.
7.  When curMenu is equal to 0, the loop exits and the console is cleared.
8.  The MainMenu function creates a new Menu object with the title "Main Menu" and adds three menu items: "Hello World", "Goto Second Menu", and "Quit Program". The DisplayMenu method is then called on the Menu object, which displays the menu and handles user input. If the user selects "Hello World", a message is displayed on the console. If the user selects "Goto Second Menu", curMenu is set to 2. If the user selects "Quit Program", curMenu is set to 0. If the user enters an invalid selection, an error message is displayed on the console.
9.  The SecondMenu function creates a new Menu object with the title "Second Menu" and adds three menu items: "Display Message", "Go Back to Main Menu", and "Quit Program". The DisplayMenu method is then called on the Menu object, which displays the menu and handles user input. If the user selects "Display Message", a message is displayed on the console. If the user selects "Go Back to Main Menu", curMenu is set to 1. If the user selects "Quit Program", curMenu is set to 0. If the user enters an invalid selection, an error message is displayed on the console.
10.  Overall, the code allows the user to navigate through different menus and select options using the Menu class. When the user selects an option, the corresponding action is performed, and the user is prompted to continue or return to the main menu. The use of exceptions ensures that the user is notified when an invalid selection is made.
