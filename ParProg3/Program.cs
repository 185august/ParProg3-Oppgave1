using ParProg3;

Chatbot currentChatbot;
Console.WriteLine("Please write your name:");
var name = Console.ReadLine();
User user = new (name);
Main();
void Main()
{
    do
    {
        Console.Clear();
        Console.WriteLine($"Welcome {user.Name}");
        Console.WriteLine("1) Make a new chatbot\n2) Talk to one of your chatbots");
        var choice = Console.ReadKey(true).KeyChar;
        if (choice == '1')
        {
            Console.Clear();
            MakeChatBot();
        }
        else if (choice == '2')
        {
            currentChatbot = SelectChatBot();
            if (currentChatbot == null)
            {
                Console.WriteLine("Do you want to make a new chatbot (y/n)");
                var input = Console.ReadKey(true).KeyChar;
                if (input == 'y')
                {
                    MakeChatBot();
                    Main();
                }
                else
                {
                    Main();
                }
            }
            Console.Clear();
            Console.WriteLine($"You have selected {currentChatbot.Name}");
            ChatWithChatbot(currentChatbot);
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    } while (true);
}

void MakeChatBot()
{
    Console.Clear();
    Console.WriteLine("\nPlease write the name of the chatbot:");
    var chatbotName = Console.ReadLine();
    Chatbot chatbot = new (chatbotName);
    user.Chatbots.Add(chatbot);
    Console.WriteLine($"You have added {chatbot.Name} to your chatbots, press any key to continue");
    Console.ReadKey();
}

void ChatWithChatbot(Chatbot currentChatbot)
{
    Console.WriteLine($"Say something to {currentChatbot.Name}");
    Console.ReadLine();
    Loading();
    Loading();
    Loading();
    Console.Clear();
    Console.WriteLine(currentChatbot.GetMessage());
    Console.WriteLine("Do you want to continue? (y/n)");
    var choice = Console.ReadKey(true).KeyChar;
    if (choice == 'y')
    {
        ChatWithChatbot(currentChatbot);
    }
    else
    {
        Console.WriteLine("Goodbye");
    }
}

Chatbot SelectChatBot()
{
    if (user.Chatbots.Count == 0)
    {
        Console.WriteLine("You have no chatbots");
        return null;
    }
    int i = 1;
    foreach (var chatbot in user.Chatbots)
    {
        Console.WriteLine($"\n{i}) {chatbot.Name}");
        i++;
    }
    Console.WriteLine("Please select a chatbot");
    var chatbotChoice = Console.ReadKey().KeyChar;
    int chatbotIndex = chatbotChoice - '1';
    if (chatbotIndex < 0 || chatbotIndex >= user.Chatbots.Count)
    {
        Console.WriteLine("Invalid choice");
        SelectChatBot();
    }
    return user.Chatbots[chatbotIndex];
}

void Loading()
{
    Console.Write("\b\b\b\b\b\b\b");
    Console.Write("Loading");
    Thread.Sleep(200);
    Console.Write(".");
    Thread.Sleep(200);
    Console.Write(".");
    Thread.Sleep(200);
    Console.Write(".");
    Thread.Sleep(200);
    Console.Write("\b\b\b");
}