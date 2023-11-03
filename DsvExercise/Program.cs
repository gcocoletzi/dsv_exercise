using DsvExercise;
using DsvExercise.Hierarchy;

Console.WriteLine("FINDING THE MISSING NUMBER\n\nInsert a comma separated list of numbers and I'll find the missing consecutive subsets.");
Console.Write("Type your list here: ");
var numbersArray = Console.ReadLine().Trim().Split(",");
int[] numbersList = Array.Empty<int>();
bool isNumber;

if(numbersArray != null)
{
    foreach (var number in numbersArray)
    {
        isNumber = int.TryParse(number.Trim(), out int converted);
        if (isNumber)
        {
            numbersList = numbersList.Concat(new int[] { converted }).ToArray();
        }
    }

    var missingSets = MissingNumber.FindMissingIntervals(numbersList);
    if (!missingSets.Any())
    {
        Console.WriteLine("Couldn't find any missing consecutive numbers");
    }
    else
    {
        Console.WriteLine("The missing numbers are:\n");
    }

    foreach (var result in missingSets)
    {
        if (result.Difference > 2)
            Console.WriteLine($"\t{result.Start + 1}...{result.End - 1}");
        else
            Console.WriteLine($"\t{result.Start + 1}");
    }
}

Console.WriteLine("\nPress any key to see inheritance and polymorphism in action.\n");
Console.ReadKey();

var vehicle = new Vehicle();
var plane = new Plane();
var car = new Car();
vehicle.Move();
plane.Move();
car.Move();
car.Move("turning right");


Console.WriteLine("\nPress any key to see a linked list working.\n");
Console.ReadKey();

var linkedList = new DsvExercise.LinkedList<string>("hola");
linkedList.PrintList();
Console.WriteLine("\n");

linkedList.Append("mundo");
linkedList.PrintList();
Console.WriteLine("\n");


linkedList.Prepend("caray!");
linkedList.PrintList();
Console.WriteLine("\n");


linkedList.Insert(2, "ah");
linkedList.PrintList();
Console.WriteLine("\n");


linkedList.Delete(1);
linkedList.PrintList();
Console.WriteLine("\n");


var node = linkedList.Find("ah");
Console.WriteLine(node!.Value);

Console.WriteLine("\nPress any key to finish this program.");
Console.ReadKey();
