#region Questions

/***
How would you improve the code's error handling?

The error handling in the original code happens outside the foreach loop. If the code reaches an error, which it certainly will because of the `NotImplementedException`s, the program won't be able to continue with the following animals, even though they might run without any exceptions.
***/

/***
What SOLID principles does the code violate and how would you fix them?

Single Responsibility Principle,
Interface Segregation Principle:
The IAnimal interface requires all animals to implement Fly(), which is not appropriate for all animals. Introducing a separate IFlying interface can solve this issue.
   
Open/Closed Principle:
    The original solution makes it hard to introduce new animal behaviors or types without having to modify existing animal implementations.
***/

/*** 
Can you think of any other optimizations?

Using polymorphism and abstract class: a common Animal ancestor class can reduce redundancy and provide a default implementation for common behaviors using GetType().Name to dynamically identify the current subclass at runtime.
   
I've also introduced a RunningAnimal ancestor for Cat and Dog to override the default Move method as they are both running.
***/

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