namespace Learning05
{
    public class Program
    {
        public static void Main(string[] args)
        {

            List<Shape> shapes = new List<Shape>()
            {
                new Square(5, "blue"),
                new Circle(5, "red"),
                new Rectangle(5, 10, "green")
            };

            Console.WriteLine("Creating shapes...");
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Color: {shape.GetColor()}");
                Console.WriteLine($"Area: {shape.GetArea()}");
            }
            
        }
    }
}
