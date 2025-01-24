using System.Net.Http.Headers;
using Mission_3_food_bank;

List<FoodItem> foodItemList = new List<FoodItem>(); //Create list to store FoodItem objects

bool running = true;

Console.WriteLine("WELCOME TO THE FOOD BANK INVENTORY MANAGEMENT SYSTEM");
Console.WriteLine("\n");
Console.WriteLine("How may I help you today? Please view the menu and enter the letter that corresponds to your desired action.");
Console.WriteLine("\n");

while (running)

{
    Console.WriteLine("\n");
    Console.WriteLine("MAIN MENU");
    Console.WriteLine("\n");
    Console.WriteLine("a - Add Food Items");
    Console.WriteLine("d - Delete Food Items");
    Console.WriteLine("p - Print List of Current Food Items");
    Console.WriteLine("x - Exit the Program");

    string response = Console.ReadLine()?.ToLower();

    switch (response)

    {
        case "a":
            AddFoodItem(foodItemList);
            break;
        
        case "d":
            DeleteFoodItem(foodItemList);
            break;
        
        case "p":
            PrintFoodList(foodItemList); 
            break;

        case "x":
            running = false;
            Console.WriteLine("\n");
            Console.WriteLine("Thank you for using our program, enjoy your day!");
            break;
        
        default:
            Console.WriteLine("Invalid entry. Please enter \"a\", \"d\", or \"p\" to perform an action, or press \"x\" to exit the program.");
            break;
    }
}

//functions

void AddFoodItem(List<FoodItem> items)
{
    //Gather Food Name
    Console.WriteLine("\n");
    Console.WriteLine("Food Name (e.g., \"Canned Beans\"): ");
    string foodName = Console.ReadLine();

    
    //Gather Food Category
    
    Console.WriteLine("Category (e.g., \"Canned Goods\", \"Dairy\", \"Produce\"): ");
    string foodCategory = Console.ReadLine();

    
    
    //Gather foodquantity and validate
    
    int foodQuantity; //Initialize variable to store food quantity

    do
    {
        Console.WriteLine("Quantity (e.g., 15 units): ");
        string quantityInput = Console.ReadLine();

        if (int.TryParse(quantityInput, out foodQuantity) && foodQuantity >= 0)
        {
            break; //Exit loop and move on if number is valid
        }

        Console.WriteLine("Invalid quantity. Please enter a positive number.");

    } while (true);


    //Gather food expiration date and validate

    DateTime foodExpDate;

    do
    {
        Console.WriteLine("\n");
        Console.WriteLine("Expiration Date (YYYY-MM-DD):");
        string expDateInput = Console.ReadLine();

        if (DateTime.TryParse(expDateInput, out foodExpDate))
        {
            break; //Exit loop
        }

        Console.WriteLine("Invalid date. Please use YYYY-MM-DD format.");

    } while (true);


    items.Add(new FoodItem(foodName, foodCategory, foodQuantity,  foodExpDate));
    Console.WriteLine($"Successfully added: {foodName}, {foodCategory}, {foodQuantity}, expires: {foodExpDate}");

}

void DeleteFoodItem(List<FoodItem> items)
{
    //check if there is inventory
    if (items.Count == 0)
    {
        Console.WriteLine("\n");
        Console.WriteLine("There are no food items in inventory at this time.");
        return;
    }

    Console.WriteLine("\n");
    Console.WriteLine("The current items are in inventory: ");
    Console.WriteLine("\n");

    for (int i = 0; i< items.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {items[i]}"); //Loop through items and print out with numbers
    }

    Console.WriteLine("Enter the identification of the number of the item you would like to delete.");

    if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > items.Count)

    {
        Console.WriteLine("Invalid choice, please enter a valid number.");
        return;
    }

    FoodItem removedItem = items[index - 1];
    items.RemoveAt(index-1);
    Console.WriteLine($"{removedItem} was deleted from inventory.");

}


void PrintFoodList(List<FoodItem> items)
{
    if (items.Count == 0)
    {
        Console.WriteLine("\n");
        Console.WriteLine("There are no food items currently in inventory.");
    }

    else
    {
        Console.WriteLine("\n");
        Console.WriteLine("Current Food Item Inventory: ");

        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}