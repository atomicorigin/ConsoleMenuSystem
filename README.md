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
int curMenu = 1;

while (true) {
    if (curMenu == 1) {
        MainMenu();
    } else if (curMenu == 0) {
        break;
    }
}

void MainMenu() {
    Menu main = new Menu("Main Menu") {
        { 'h', "Hello World" },
        { 'q', "Quit Program" }
    };
    try {
        char selection = main.DisplayMenu(true);
        if (selection.Equals('h')) {
            Console.Clear();
            Console.WriteLine("Hello World");
            Console.WriteLine();
            Console.Write("Press any key to continue ... ");
            Console.ReadKey();
        } else if (selection.Equals('q')) {
            curMenu = 0;
        }
    } catch (InvalidMenuSelectionException) {
        Console.Clear();
        Console.WriteLine("Invalid selection. Please try again.");
        Console.WriteLine();
        Console.Write("Press any key to continue ... ");
        Console.ReadKey();
    }
}
```

This example demonstrates how to use the `Menu` class to create a main menu with two options: "Hello World" and "Quit Program". The `MainMenu` method is called in a loop, which displays the menu and waits for the user to make a selection. If the user selects "Hello World", a message is displayed and the user is prompted to press a key to continue. If the user selects "Quit Program", the loop is exited and the program terminates. If the user selects an invalid menu item, an error message is displayed and the user is prompted to press a key to continue.
