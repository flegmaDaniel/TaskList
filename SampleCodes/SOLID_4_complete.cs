public interface IAnimal
{
    void PerformActions();
}

public interface IMovable
{
    void Move();
}

public interface IEatable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

public class GenericAnimal : IAnimal, IMovable, IEatable, ISleepable
{
    public virtual void PerformActions()
    {
        Move();
        Eat();
        Sleep();
    }

    public void Move()
    {
        Console.WriteLine($"{GetType().Name} is moving.");
    }

    public void Eat()
    {
        Console.WriteLine($"{GetType().Name} is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine($"{GetType().Name} is sleeping.");
    }
}

public class Dog : GenericAnimal
{
}

public class Cat : GenericAnimal
{
}

public class Bird : GenericAnimal, IFlyable
{
    public void Fly()
    {
        Console.WriteLine($"{typeof(Bird).Name} is flying.");
    }

    public override void PerformActions()
    {
        base.PerformActions();
        Fly();
    }
}

public interface IFlyable
{
    void Fly();
}

public class Zoo
{
    private readonly IAnimal[] _animals;

    public Zoo(IAnimal[] animals)
    {
        _animals = animals;
    }

    public void StartZoo()
    {
        foreach (var animal in _animals)
        {
            animal.PerformActions();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog();
        Cat cat = new Cat();
        Bird bird = new Bird();

        IAnimal[] animals = { dog, cat, bird };

        Zoo zoo = new Zoo(animals);
        zoo.StartZoo();
    }
}