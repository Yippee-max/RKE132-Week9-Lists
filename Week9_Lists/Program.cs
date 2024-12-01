string folderpath = @"C:\PGRclass_data";
string fileName = "ShoppingList.txt";
string filepath = Path.Combine(folderpath, fileName);

List<string> myShoppingList = new List<string>();
if (File.Exists(filepath)) // vaatab kas failu asukoht eksisteerib
{
    myShoppingList = getItemsFromUser();
    File.WriteAllLines(filepath, myShoppingList);
}
else
{
    File.Create(filepath).Close();
    Console.WriteLine($"File {fileName} has been created.");
    myShoppingList = getItemsFromUser();
    File.WriteAllLines(filepath, myShoppingList);
}

static List<string> getItemsFromUser()
{
    List<string> userList = new List<string>();
    // valmistab ette et aksepteerida listi
    // list saab ainult koosneda konkreetsest faili formatis
    // list on palju paindlikum kui array

    while (true)
    {
        Console.WriteLine("Add an item (add) / Exit (exit) ");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine("Enter an item");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
        }
        else if (userChoice == "exit")
        {
            Console.WriteLine("Ciao!");
            break;
        }
        else
        {
            Console.WriteLine("Invalid operator, write either add or exit");
        }
    }
    return userList;

}
static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();
    // kustutab eelnevad commands

    int listlength = someList.Count;
    Console.WriteLine($"You have added {listlength} items to your shopping list.");

    int i = 1;
    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
}