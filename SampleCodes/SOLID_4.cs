#region Questions

// How would you improve the code's error handling?
// What SOLID principles does the code violate and how would you fix them?
// Can you think of any other optimizations?

#endregion

namespace Task_4;

public interface IAnimal
{
    void Move();
    void Eat();
    void Sleep();
    void Fly();
}

public class Dog : IAnimal
{
    public void Move()
    {
        Console.WriteLine("Dog is running.");
    }

    public void Eat()
    {
        Console.WriteLine("Dog is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine("Dog is sleeping.");
    }

    public void Fly()
    {
        throw new NotImplementedException();
    }
}

public class Cat : IAnimal
{
    public void Move()
    {
        Console.WriteLine("Cat is running.");
    }

    public void Eat()
    {
        Console.WriteLine("Cat is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine("Cat is sleeping.");
    }
    public void Fly()
    {
        throw new NotImplementedException();
    }
}

public class Bird : IAnimal
{
    public void Move()
    {
        Console.WriteLine("Bird is moving.");
    }

    public void Eat()
    {
        Console.WriteLine("Bird is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine("Bird is sleeping.");
    }
    public void Fly()
    {
        Console.WriteLine("Bird is flying.");
    }
}

public class Zoo
{
    private readonly IAnimal[] animals = [new Dog(), new Cat(), new Bird()];

    public Zoo()
    {
    }

    public void StartZoo()
    {
        try
        {
            foreach (var animal in animals)
            {
                animal.Move();
                animal.Eat();
                animal.Fly();
                animal.Sleep();
            }
        } 
        catch (Exception ex)
        {
            Console.WriteLine($"Animal has a problem: {ex.Message}");
        }
    }
}

#region Task

public static class RunTask
{

    public static void Run()
    {

        Console.WriteLine("Running Task 4 \n");
        Zoo zoo = new Zoo();
        zoo.StartZoo();
    }
}

#endregion

