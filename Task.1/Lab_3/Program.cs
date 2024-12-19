using System;
using System.Collections.Generic;

// Інтерфейс IReproducible 
public interface IReproducible
{
    void Reproduce();
}

// Інтерфейс IPredator 
public interface IPredator
{
    void Hunt(LivingOrganism prey);
}

// Базовий клас "Живий організм"
public abstract class LivingOrganism
{
    public int Energy { get; set; }
    public int Age { get; set; }
    public double Size { get; set; }

    public LivingOrganism(int energy, int age, double size)
    {
        Energy = energy;
        Age = age;
        Size = size;
    }

    public virtual void Grow()
    {
        Age++;
        Size += 0.5;
    }
}

// Клас Тварина
public class Animal : LivingOrganism, IReproducible, IPredator
{
    public bool IsCarnivore { get; set; }

    public Animal(int energy, int age, double size, bool isCarnivore)
        : base(energy, age, size)
    {
        IsCarnivore = isCarnivore;
    }

    public void Reproduce()
    {
        Console.WriteLine("Тварина розмножується");
    }

    public void Hunt(LivingOrganism prey)
    {
        if (IsCarnivore && prey != null)
        {
            Energy += prey.Energy / 2;
            Console.WriteLine("Тварина  полює на інший організм та отримує енергію");
        }
    }
}

// Клас Рослина
public class Plant : LivingOrganism, IReproducible
{
    public double PhotosynthesisRate { get; set; }

    public Plant(int energy, int age, double size, double photosynthesisRate)
        : base(energy, age, size)
    {
        PhotosynthesisRate = photosynthesisRate;
    }

    public void Reproduce()
    {
        Console.WriteLine("Рослина розмножується");
    }

    public void Photosynthesize()
    {
        Energy += (int)(PhotosynthesisRate * 10);
        Console.WriteLine("Рослина виконує фотосинтез і отримує енергію");
    }
}

// Клас Мікроорганізм
public class Microorganism : LivingOrganism, IReproducible
{
    public int DivisionRate { get; set; }

    public Microorganism(int energy, int age, double size, int divisionRate)
        : base(energy, age, size)
    {
        DivisionRate = divisionRate;
    }

    public void Reproduce()
    {
        Console.WriteLine("Мікроорганізм ділиться для розмноення");
    }
}

// Клас Екосистема
public class Ecosystem
{
    private List<LivingOrganism> organisms = new List<LivingOrganism>();

    public void AddOrganism(LivingOrganism organism)
    {
        organisms.Add(organism);
    }

    public void SimulateInteraction()
    {
        foreach (var organism in organisms)
        {
            organism.Grow();
            if (organism is IReproducible reproducible)
            {
                reproducible.Reproduce();
            }

            if (organism is IPredator predator)
            {
                LivingOrganism prey = organisms.Find(o => o != organism && o.Energy > 0);
                if (prey != null)
                {
                    predator.Hunt(prey);
                }
            }
        }
    }
}

// Тестування системи
class Program
{
    static void Main()
    {
        Ecosystem ecosystem = new Ecosystem();

        Animal lion = new Animal(100, 5, 70.5, true);
        Plant fern = new Plant(50, 3, 1.2, 0.8);
        Microorganism bacteria = new Microorganism(20, 1, 0.01, 5);

        ecosystem.AddOrganism(lion);
        ecosystem.AddOrganism(fern);
        ecosystem.AddOrganism(bacteria);

        ecosystem.SimulateInteraction();
    }
}

