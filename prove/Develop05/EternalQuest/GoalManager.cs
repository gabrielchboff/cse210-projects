namespace EternalQuest
{
    // This namespace groups related classes together under the name "EternalQuest".
    public class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        public GoalManager(){ }

        public int GetScore()
        {
            return _score;
        }

        public void Start()
        {
            List<string> options = new List<string>() {
                "Create New Goal",
                "List Goals",
                "Save Goals",
                "Load Goals",
                "Record Event",
                "Quit"
            };

            int choice = 0;
            do 
            { 
                //Using the menu class to create a menu as exciding requirement
                Menu menu = new Menu(
                        "Eternal Quest", 
                        $"Life's Tasks Gamification\n\nYou have {GetScore()} points\n", 
                        options
                );
                menu.Display();
                Console.WriteLine("Select an option from the menu: ");
                choice = menu.GetChoice();
                
                switch (choice)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalsDetails();
                        break;
                    case 3:
                        Console.WriteLine("Type in the name of the file you would like to save to: ");
                        string fileName = Console.ReadLine();
                        SaveGoals(fileName + ".txt");
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice! Try Again.");
                        break;
                    
                }
            } while (choice != 6);
        }

        public void DisplayPlayerInfo()
        {

        }

        public void ListGoalsNames()
        {

        }

        public bool isExists(string name)
        {
            bool exists = false;
            foreach (Goal goal in _goals)
            {
                if (goal.GetShortName() == name)
                {
                    exists = true;
                }
            }

            return exists;
        }

        public void ListGoalsDetails()
        {
            Console.WriteLine("The goals are: ");
            foreach (Goal goal in _goals)
            {
                Console.WriteLine(goal.GetStringRepresentation());
            }

        }

        public void CreateGoal()
        {
            Menu goalMenu = new Menu(
                "Create New Goal",
                "What type of goal would you like to create?",
                new List<string>() { "Simple Goal", "Eternal Goal", "Checklist Goal" }
            );
            goalMenu.Display();
            Console.WriteLine("Select an option from the menu: ");
            int goalchoice = goalMenu.GetChoice();
            int currentPoints = 0;
            string currentName = "";
            string currentDescription = "";
            switch (goalchoice)
            {
                case 1:
                    Console.WriteLine("What is the name of your goal?");
                    currentName = Console.ReadLine();
                    Console.WriteLine("What is a short description of it?");
                    currentDescription = Console.ReadLine();
                    Console.WriteLine("What is the amount of points associated with this goal?");
                    currentPoints = int.Parse(Console.ReadLine());
                    SimpleGoal simpleGoal = new SimpleGoal(currentName, currentDescription, currentPoints);
                    _goals.Add(simpleGoal);
                    ListGoalsDetails();
                    break;
                case 2:
                    Console.WriteLine("What is the name of your goal?");
                    currentName = Console.ReadLine();
                    Console.WriteLine("What is a short description of it?");
                    currentDescription = Console.ReadLine();
                    Console.WriteLine("What is the amount of points associated with this goal?");
                    currentPoints = int.Parse(Console.ReadLine());
                    EternalGoal eternalGoal = new EternalGoal(currentName, currentDescription, currentPoints);
                    _goals.Add(eternalGoal);
                    ListGoalsDetails();
                    break;
                case 3:
                    Console.WriteLine("What is the name of your goal?");
                    currentName = Console.ReadLine();
                    Console.WriteLine("What is a short description of it?");
                    currentDescription = Console.ReadLine();
                    Console.WriteLine("What is the amount of points associated with this goal?");
                    currentPoints = int.Parse(Console.ReadLine());
                    Console.WriteLine("How many times does this goal need to be accomplished for a bonus?");
                    int target = int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the bonus for accomplishing it that many times?");
                    int bonus = int.Parse(Console.ReadLine());
                    CheckListGoal checkListGoal = new CheckListGoal(
                            currentName, currentDescription, 
                            currentPoints, target ,bonus
                    );
                    _goals.Add(checkListGoal);
                    ListGoalsDetails();
                    break;
                default:
                    break;
            }

        }

        public void RecordEvent()
        {
            Menu eventMenu = new Menu(
                    "Record Event", 
                    "Which goal did you accomplish?", 
                    _goals.Select(goal => goal.GetStringRepresentation()).ToList()
            );
            eventMenu.Display();
            Console.WriteLine("Select an option from the menu: ");
            int enventchoice = eventMenu.GetChoice();
            _goals[enventchoice - 1].RecordEvent();
            _score += _goals[enventchoice - 1].GetPoints();

        }
        
        public void SaveGoals(string filePath)
        {
            try
            {
                List<string> list = new List<string>();
                for(int i = 0; i < _goals.Count; i++)
                {
                    string currentGoalType = _goals[i].GetType().ToString().Split('.').Last();
                    string str = $"{currentGoalType}, " + _goals[i].GetDetailsString();
                    list.Add(str);
                }

                using (StreamWriter outputFile = new StreamWriter(filePath))
                {
                    outputFile.WriteLine($"score, {_score}");
                    foreach (string line in list)
                    {
                        outputFile.WriteLine(line);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }

        }

        public void LoadGoals()
        {
            Console.WriteLine("Type in the name of the file you would like to load from: ");
            string fileName = Console.ReadLine();
            fileName += ".txt";
            try
            {
                using (StreamReader inputFile = new StreamReader(fileName))
                {
                    List<string> lines = new List<string>(File.ReadAllLines(fileName));
                    Console.WriteLine(lines[1]);
                    _score = int.Parse(lines[0].Split(',')[1]);

                    lines.RemoveAt(0);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        string goalType = parts[0];
                        string shortName = parts[1];
                        string description = parts[2];
                        if (goalType == "SimpleGoal" && !isExists(shortName))
                        {
                            SimpleGoal simpleGoal = new SimpleGoal(shortName, description, int.Parse(parts[3]));
                            simpleGoal.SetIsComplete(bool.Parse(parts[4]));
                            _goals.Add(simpleGoal);
                        }
                        else if (goalType == "EternalGoal" && !isExists(shortName))
                        {
                            EternalGoal eternalGoal = new EternalGoal(shortName, description, int.Parse(parts[3]));
                            _goals.Add(eternalGoal);
                        }
                        else if (goalType == "CheckListGoal" && !isExists(shortName))
                        {
                            CheckListGoal checkListGoal = new CheckListGoal(shortName, description, int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                            checkListGoal.SetAmountCompleted(int.Parse(parts[6]));
                            _goals.Add(checkListGoal);
                        }
                        
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }


        }

    }
}
