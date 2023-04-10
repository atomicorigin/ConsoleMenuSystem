using System.Collections;

/// <summary>
/// Namespace for creating and managing console-based menus.
/// </summary>
namespace MenuSystem
{
    /// <summary>
    /// Represents a console-based menu with customizable options.
    /// </summary>
    class Menu : IEnumerable
    {
        /// <summary>
        /// The title of the menu.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The prompt displayed to the user when requesting input.
        /// </summary>
        public string? Prompt { get; set; }

        private Dictionary<char, string> _menuItems;

        /// <summary>
        /// Creates a new Menu instance with a specified title and prompt.
        /// </summary>
        /// <param name="Title">The title of the menu.</param>
        /// <param name="Prompt">The prompt displayed to the user when requesting input.</param>
        /// <param name="PadPrompt">Whether to add a colon and a space to the end of the prompt. Default value is false.</param>
        public Menu(string Title, string Prompt, bool PadPrompt = false)
        {
            this.Title = Title;
            this.Prompt = PadPrompt ? $"{Prompt}: " : Prompt;
            _menuItems = new();
        }

        /// <summary>
        /// Creates a new Menu instance with a specified title and a default prompt.
        /// </summary>
        /// <param name="Title">The title of the menu.</param>
        public Menu(string Title) : this(Title, "Make a Selection: ") { }

        /// <summary>
        /// Creates a new Menu instance with default title and prompt.
        /// </summary>
        public Menu() : this("Default Menu", "Make a Selection: ") { }

        /// <summary>
        /// Adds a menu item to the menu.
        /// </summary>
        /// <param name="MenuItem">A KeyValuePair where the key is the character input and the value is the description of the menu item.</param>
        public void Add(KeyValuePair<char, string> MenuItem)
        {
            if (!_menuItems.ContainsKey(MenuItem.Key))
            {
                _menuItems.Add(MenuItem.Key, MenuItem.Value);
            }
            else
            {
                throw new DuplicateItemException();
            }
        }

        /// <summary>
        /// Adds multiple menu items to the menu.
        /// </summary>
        /// <param name="MenuItems">A dictionary containing menu items, where the key is the character input and the value is the description of the menu item.</param>
        public void Add(Dictionary<char, string> MenuItems)
        {
            foreach (KeyValuePair<char, string> MenuItem in MenuItems)
            {
                Add(MenuItem);
            }
        }

        /// <summary>
        /// Adds a menu item to the menu using a key and a title.
        /// </summary>
        /// <param name="Key">The character input for the menu item.</param>
        /// <param name="Title">The description of the menu item.</param>
        public void Add(char Key, string Title) => Add(new KeyValuePair<char, string>(Key, Title));

        /// <summary>
        /// Returns an enumerator that iterates through the menu items.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the menu items.</returns>
        public IEnumerator GetEnumerator() => _menuItems.GetEnumerator();

        /// <summary>
        /// Displays the menu to the console and returns the selected menu item key.
        /// </summary>
        /// <param name="ClearConsole">Whether to clear the console before displaying the menu. Default value is false.</param>
        /// <returns>The character key of the selected menu item
        public char DisplayMenu(bool ClearConsole = false)
        {
            if (ClearConsole) Console.Clear();
            string Line = new string('-', (Title is not null) ? Title.Length : 10);
            System.Console.WriteLine(Title);
            System.Console.WriteLine(Line);
            System.Console.WriteLine();
            foreach (KeyValuePair<char, string> MenuItem in _menuItems)
            {
                System.Console.WriteLine($"{MenuItem.Key}: {MenuItem.Value}");
            }
            System.Console.WriteLine(Line);
            System.Console.Write(Prompt);
            ConsoleKeyInfo SelectedKey = Console.ReadKey(true);
            if (_menuItems.ContainsKey(SelectedKey.KeyChar))
            {
                return SelectedKey.KeyChar;
            }
            else
            {
                throw new InvalidMenuSelectionException();
            }
        }
    }
    /// <summary>
    /// Represents an exception that is thrown when a duplicate menu item is added to the menu.
    /// </summary>
    [System.Serializable]
    public class DuplicateItemException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the DuplicateItemException class.
        /// </summary>
        public DuplicateItemException() { }

        /// <summary>
        /// Initializes a new instance of the DuplicateItemException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public DuplicateItemException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the DuplicateItemException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public DuplicateItemException(string message, System.Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the DuplicateItemException class with serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        protected DuplicateItemException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Represents an exception that is thrown when an invalid menu item selection is made.
    /// </summary>
    [System.Serializable]
    public class InvalidMenuSelectionException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the InvalidMenuSelectionException class.
        /// </summary>
        public InvalidMenuSelectionException() { }

        /// <summary>
        /// Initializes a new instance of the InvalidMenuSelectionException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidMenuSelectionException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the InvalidMenuSelectionException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public InvalidMenuSelectionException(string message, System.Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the InvalidMenuSelectionException class with serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        protected InvalidMenuSelectionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
