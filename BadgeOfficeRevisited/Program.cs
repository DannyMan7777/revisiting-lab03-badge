/*
* This is a header.
* It heads.
* Yes. Earth-shattering, I know.
* I am clinically insane.
* And YOU JUST LOST THE GAME
*/

//Program

System.Console.Write("How many students do you want to enter? ");
int numStudents = Convert.ToInt32(Console.ReadLine());

if(numStudents > 20)
{
    numStudents = 20;
    System.Console.WriteLine("Screw off; I'm not paid enough to deal with that many entries. We're doing 20, no more.");
}

string[] names = new string[numStudents];

for(int i = 0; i < numStudents; i++)
{
    string[] ordinalSuffices = {"st", "nd", "rd", "th"};
    if(i < 3)
    {
       int j = i;
       System.Console.Write($"Please enter the {i + 1}{ordinalSuffices[j]} student's name: "); 
    }
    else
    {
        System.Console.Write($"Please enter the {i + 1}{ordinalSuffices[3]} student's name: ");
    }

    names[i] = Console.ReadLine();
}

string[] usernames = CreateUsernameList(names);
int[] studentIDs = CreateStudentIDs(names.Length);
int[] studentLockers = CreateStudentLockers(names.Length);

DisplayStudentInfo(names, usernames, studentIDs, studentLockers);

int userInput = 0;
do{
    System.Console.WriteLine("\nWhich student would you like to see more information on? (enter 0 to exit)");
    DisplayStudentNames(names);
    userInput = Convert.ToInt32(Console.ReadLine());
    if(userInput != 0)
    {
        DisplayIndividualStudentInfo(names, usernames, studentIDs, studentLockers, userInput);
    }
}while(userInput != 0);

//Methods

static string CreateUsername(string firstName, string lastName)
{
    string username = firstName.ToLower().Trim()[0].ToString();
    username += lastName.ToLower().Trim();
    return username;
}

static string[] CreateUsernameList(string[] names)
{
    string[] usernames = new string[names.Length];
    for(int i = 0; i < names.Length; i++)
    {
        string[] splitName = names[i].Split(' ');
        usernames[i] = CreateUsername(splitName[0], splitName[1]);
    }

    return usernames;
}

static int[] CreateStudentIDs(int number)
{
    Random r = new Random();
    int[] studentIDs = new int[number];

    for(int i = 0; i < number; i++)
    {
        studentIDs[i] = r.Next(10000, 1000000);
    }

    return studentIDs;

}

static int[] CreateStudentLockers(int number)
{
    Random r = new Random();
    int[] studentLockers = new int[number];

    for(int i = 0; i < number; i++)
    {
        studentLockers[i] = r.Next(1, 501);
    }

    return studentLockers;

}

static void DisplayStudentInfo(string[] names, string[] usernames, int[] studentIDs, int[] studentLockers)
{
    for(int i = 0; i < names.Length; i++)
    {
        System.Console.WriteLine($"Name: {names[i]}");
        System.Console.WriteLine($"Username: {usernames[i]}");
        System.Console.WriteLine($"Student ID: {studentIDs[i]}");
        System.Console.WriteLine($"Student locker: {studentLockers[i]}\n");
    }
}

static void DisplayIndividualStudentInfo(string[] names, string[] usernames, int[] studentIDs, int[] studentLockers, int target)
{
    System.Console.WriteLine($"Name: {names[target - 1]}");
    System.Console.WriteLine($"Username: {usernames[target - 1]}");
    System.Console.WriteLine($"Student ID: {studentIDs[target - 1]}");
    System.Console.WriteLine($"Student locker: {studentLockers[target - 1]}\n");
}

static void DisplayStudentNames(string[] names)
{
    for(int i = 0; i < names.Length; i++)
    {
        System.Console.WriteLine($"{i + 1}. {names[i]}");
    }

}