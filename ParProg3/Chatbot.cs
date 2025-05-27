namespace ParProg3;

public class Chatbot
{
    public string Name { get; }
    private List<string> _messages = new List<string>
    {
       "Hello",
       "Hi",
       "How are you",
       "I am fine",
       "What is your name",
       "What is your age",
       "I am 20 years old",
       "What is your favorite color",
       "My favorite color is blue",
       "What is your favorite food",
       "My favorite food is pizza",
       "What is your favorite movie",
       "My favorite movie is The Matrix",
       "What is your favorite book",
       "My favorite book is The Hobbit",
       "What is your favorite song",
       "My favorite song is The Beatles - Yesterday",
       "What is your favorite author",  
    };

    public Chatbot(string name)
    {
        Name = name;
    }

    public string GetMessage()
    {
        return _messages[new Random().Next(0, _messages.Count)];
    }
    
    
}