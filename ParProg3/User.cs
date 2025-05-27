namespace ParProg3;

public class User
{
    public string Name { get; }
    public List<Chatbot> Chatbots { get; } = new List<Chatbot>();
    
    public User(string name)
    {
        Name = name;
    }
    
}