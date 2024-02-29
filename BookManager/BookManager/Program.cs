using BookManager;

//Creates new bookAdmin object
var bookAdmin = new BookAdmin();

Console.WriteLine("************");
Console.WriteLine("Welcome to Book Manager");
Console.WriteLine("************");
bool willRun = true;

//menu
//This loop runs while willRun variable is true
while (willRun)
{
    Console.WriteLine("************");
    Console.WriteLine("*   Menu   *");
    Console.WriteLine("************");
    Console.WriteLine("Choose one option: ");
    Console.WriteLine("1. Add a new book.");
    Console.WriteLine("2. Show all books.");
    Console.WriteLine("3. Find a book by title.");
    Console.WriteLine("9. Exit the application");

    
    //Waits for customer to enter key and saves it
    string key = Console.ReadLine();

    //For different keys runs different methods
    switch (key)
    {
        case "1":
            AddNewBook(bookAdmin);
            break;
        case "2":
            ShowAllBooks(bookAdmin);
            break;
        case "3":
            ShowBookByTitle(bookAdmin);
            break;
        default:
            //If any other option is entered, the program exits
            //Sets willRun variable to false and exits the program
            willRun = false;
            Console.WriteLine("GoodBye!");
            break;
    }
}



//Asks for the title, author, and the year of the book to add to the list
static void AddNewBook(BookAdmin bookAdmin)
{
    //Asks for title
    Console.WriteLine("Enter a new book title.");
    string bookTitle = Console.ReadLine();
    //If book title is null (no value is entered), it will ask again until the valid value is entered
    while( bookTitle == null || bookTitle == "" )
    {
        Console.WriteLine("Please enter valid book title:");
        bookTitle = Console.ReadLine();
    }

    //Asks for author
    Console.WriteLine("Enter the name of the author:");
    string bookAuthor = Console.ReadLine();
    //If book author is null (no value is entered), it will ask again until the valid value is entered
    while (bookAuthor == null || bookAuthor == "")
    {
        Console.WriteLine("Please enter valid author name:");
        bookTitle = Console.ReadLine();
    }

    //Asks for the year
    Console.WriteLine("Enter the year the book was published:");
    string bookYear = Console.ReadLine();
    int year;

    //If entered line is not convertible to integer values, asks again until the valid value is entered
    while(!int.TryParse(bookYear, out year ))
    {
        Console.WriteLine("Invalid year");
        Console.WriteLine("Enter the year the book was published:");
        bookYear = Console.ReadLine();
    }

    //Passes the title, author and the year to the AddBook method that adds new books to the list
    bookAdmin.AddBook(bookTitle, bookAuthor, year);
    Console.WriteLine("Book was added successfully");


}


//Shows all books to the console
static void ShowAllBooks(BookAdmin bookAdmin)
{
    //Loops through the book list and prints every book object to the console
    bookAdmin.GetBookList().ForEach(book =>
    {
        Console.WriteLine($"{book.title} by {book.author}. published in {book.year}");
    });
}


//Shows book information to the console
static void ShowBookByTitle(BookAdmin bookAdmin)
{
    //Asks for title
    Console.WriteLine("Please Enter a book title: ");
    string bookTitle = Console.ReadLine();
    //If book title is null (no value is entered), it will ask again until the valid value is entered
    while (bookTitle == null)
    {
        Console.WriteLine("Please enter valid book title:");
        bookTitle = Console.ReadLine();
    }
    //Uses GetBook method to return book from the book list 
    var book = bookAdmin.GetBook(bookTitle);
    //If book is not found, GetBook method returns null, and an error is printed.
    if (book == null)
    {
        Console.WriteLine("Error 404: Book Not Found");
    } else //if book is found, the information is printed to the console
    {
        Console.WriteLine($"{book.title} by {book.author}. published in {book.year}");
    }
}
