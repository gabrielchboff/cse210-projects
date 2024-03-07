public class PromptGenerator
{
    // List of prompts
    public List<string> _prompt = new List<string>(){
            // Self-Reflection Prompts:
            "What is something you are proud of yourself for achieving recently?",
            "What is a fear you hold that you want to overcome?",
            "Describe a time you stepped outside your comfort zone and the outcome.",
            "What is a character trait you admire in someone else and why?",
            "What is something you've been meaning to learn, but haven't gotten around to?",

            // Gratitude Prompts:
            "List three things you are grateful for today, big or small.",
            "Write a letter to your future self expressing things you're thankful for now.",
            "Think of a person who has made a positive impact on your life and write about them.",
            "Describe a simple pleasure you often take for granted.",
            "What is something good that happened this week, even if it was minor?",

            // Creativity Prompts:
            "Describe a fictional world you'd love to visit. What is unique about it?",
            "Create a story based on a random object you see around you.",
            "Imagine you have a superpower. What is it and how would you use it?",
            "Write a poem or short story inspired by a recent dream you had.",
            "If you could only have three items with you on a deserted island, what would they be and why?",

            // Looking Inward Prompts:
            "What is something you've been avoiding and why?",
            "What is a recent decision you've made that has impacted your life?",
            "Describe a goal you are currently working towards.",
            "What is one thing you wish you could change about yourself?",
            "What is a recurring thought or feeling you've been experiencing lately?",

            // Looking Forward Prompts:
            "What are you most looking forward to in the coming year or month?",
            "Imagine your ideal future self. What are they like?",
            "What is one step you can take today to move closer to your goals?",
            "Describe a dream trip you'd like to take someday.",
            "What do you hope to learn or experience in the next few months?"
        };

    // Returns a random prompt
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompt.Count);
        string prompt = _prompt[index];
        
        return prompt;
    }
}
