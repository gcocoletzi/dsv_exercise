namespace DsvExercise.Hierarchy
{

    /*
     * Problem 3: Inheritance and Polymorphism
     * Create a C# class hierarchy with inheritance and polymorphism. For example, define a base class and derived classes with overridden methods.
     */

    //Base class
    public class Vehicle
    {
        public virtual void Move()
        {
            Console.WriteLine("The vehicle moves.");
        }
    }

    //Child class
    public class Plane : Vehicle
    {
        //run-time polymorphism
        public override void Move()
        {
            Console.WriteLine("The plane flies.");
        }
    }

    //Child class
    public class Car : Vehicle
    {
        //run-time polymorphism
        public override void Move()
        {
            Console.WriteLine("The car drives.");
        }

        //compile-time polymorphism
        public void Move(string specificMove)
        {
            Console.WriteLine($"The car is {specificMove}.");
        }
    }
}
