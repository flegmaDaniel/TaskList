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
}

public interface IFlying
{
    void Fly();
}

public abstract class Animal : IAnimal
{
    public virtual void Move()
    {
        Console.WriteLine($"{GetType().Name} is moving.");
    }

    public virtual void Eat()
    {
        Console.WriteLine($"{GetType().Name} is eating.");
    }

    public virtual void Sleep()
    {
        Console.WriteLine($"{GetType().Name} is sleeping.");
    }
}
public abstract class RunningAnimal : Animal
{
    public override void Move()
    {
        Run();
    }

    protected void Run()
    {
        Console.WriteLine($"{GetType().Name} is running.");
    }
}

public class Dog : RunningAnimal
{
}

public class Cat : RunningAnimal
{
}

public class Bird : Animal, IFlying
{
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
        foreach (var animal in animals)
        {
            try
            {
                animal.Move();
                animal.Eat();
                animal.Sleep();

                if (animal is IFlying flyingAnimal)
                {
                    flyingAnimal.Fly();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{animal.GetType().Name} has a problem: {ex.Message}");
            }
        }
    }
}

#region Task

public static class RunTask
{
    public static void Run()
    {
        Console.WriteLine("Running Task 4 \n");
        var zoo = new Zoo();
        zoo.StartZoo();
    }
}

#endregion