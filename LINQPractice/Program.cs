// See https://aka.ms/new-console-template for more information
using System.Linq;

Console.WriteLine("Hello, World!");


// Find the words in the collection that start with the letter 'L'
List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

//filters the list.
List<string> filterFruits = fruits.Where(s => s.StartsWith("L")).ToList();

foreach (string fruit in filterFruits)
{
    Console.WriteLine(fruit);
}

// Which of the following numbers are multiples of 4 or 6
List<int> firstNumbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

List<int> fourSixMultiples = firstNumbers.Where(num =>
                                           num % 4 == 0 ||
                                           num % 6 == 0)
                                    .OrderBy(num => num)
                                     .ToList();

foreach (int num in fourSixMultiples)
{
    Console.WriteLine(num);
}

// Order these student names alphabetically, in descending order (Z to A)
List<string> names = new List<string>()
{
    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
    "Francisco", "Tre"
};

List<string> descend = names.OrderByDescending(name => name).ToList();

foreach (string name in descend)
{
    Console.WriteLine(name);
}

// Build a collection of these numbers sorted in ascending order
List<int> secondNumbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

List<int> ascNumbers = secondNumbers.OrderBy(num => num).ToList();

foreach (int num in ascNumbers)
{
    Console.WriteLine(num);
}

// Output how many numbers are in this list
List<int> thirdNumbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

Console.WriteLine(thirdNumbers.Count);
//Or
int countOfThirdNumbers = thirdNumbers.Aggregate(0, (total, next) => total + 1);
Console.WriteLine(countOfThirdNumbers);

// How much money have we made?
List<double> purchases = new List<double>()
{
    2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
};

double totalPurchases = purchases.Aggregate(0.0, (total, current) => total + current);
//or 
double totalPurchasesTwo = purchases.Sum();

Console.WriteLine(totalPurchases);
Console.WriteLine(totalPurchasesTwo);


// What is our most expensive product?
List<double> prices = new List<double>()
{
    879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
};

double mostExpensiveProduct = prices.OrderByDescending(x => x)
                                    .FirstOrDefault();
//or 
double mostExpensiveProduct2 = prices.Max();

Console.WriteLine(mostExpensiveProduct);
Console.WriteLine(mostExpensiveProduct2);


List<int> wheresSquaredo = new List<int>()
{
    66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
};
/*
    Store each number in the following List until a perfect square
    is detected.

    Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 } 

    Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
*/


List<int> numberListUntilSquare = wheresSquaredo.TakeWhile(x => Math.Sqrt(x) % 1 != 0).ToList();

foreach (int number in numberListUntilSquare)
{
    Console.WriteLine(number);
}

// Build a collection of customers who are millionaires
List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
};


List<Customer> millionaires = customers.Where(customer => customer.Balance >= 1000000.00).ToList();

foreach (Customer customer in millionaires)
{
    Console.WriteLine(customer.Name);
}

/*
    Given the same customer set, display how many millionaires per bank.
    Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

    Expected Output:
    FTB 3
    WF 3
    BOA 2
    CITI 2
*/

//var banks = customers.GroupBy(
//                        customer => customer.Bank,
//                        customer => customer,
//                        (key, g) => new Bank(key, g.ToList())
//                        );


//foreach (Bank bank in banks)
//{
//    Console.WriteLine(bank.Name);
//    Console.WriteLine(bank.Customers.Count);
//}


List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };


/*
    TASK:
    As in the previous exercise, you're going to output the millionaires,
    but you will also display the full name of the bank. You also need
    to sort the millionaires' names, ascending by their LAST name.

    Example output:
        Tina Fey at Citibank
        Joe Landy at Wells Fargo
        Sarah Ng at First Tennessee
        Les Paul at Wells Fargo
        Peg Vale at Bank of America
*/


List<ReportItem> millionaireReport = customers.Where(customer => customer.Balance >= 1000000.00)
                                              .Select(customer =>
                                              {
                                                  Bank foundBank = banks.FirstOrDefault(bank => bank.Symbol == customer.Bank); 
                                                  return new ReportItem()
                                                  {
                                                      CustomerName = customer.Name,
                                                      BankName = foundBank.Name
                                                  };
                                              }).ToList();

/*
           You will need to use the `Where()`
           and `Select()` methods to generate
           instances of the following class.
       */





foreach (var item in millionaireReport)
{
    Console.WriteLine($"{item.CustomerName} at {item.BankName}");
}


//Define Customer class for millionaires exercise
public class Customer
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public string Bank { get; set; }
}

public class Bank
{
    public string Name { get; set; }
    public string Symbol { get; set; }
    public List<Customer> Customers { get; set; }
    public Bank(string name, List<Customer> customers)
    {
        Name = name;
        Customers = customers;
    }
    public Bank() { }
}





public class ReportItem
{
    public string CustomerName { get; set; }
    public string BankName { get; set; }
}