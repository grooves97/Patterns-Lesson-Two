using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPractice
{
    public abstract class Weapon
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            // Вызываем фабричный метод, чтобы получить объект-продукт.
            IProduct product = FactoryMethod();
            // Далее, работаем с этим продуктом.
            string result = "Creator: The same creator's code has just worked with "
                + product.Operation();

            return result;
        }
    }

    public interface IProduct
    {
        string Operation();
    }

    public class WeaponAK47 : Weapon
    {
        public override IProduct FactoryMethod()
        {
            return new AK47();
        }
    }

    public class WeaponAUG : Weapon
    {
        public override IProduct FactoryMethod()
        {
            return new AUG();
        }
    }

    public class AK47 : IProduct
    {
        public string Operation()
        {
            return "AK47 bullet";
        }
    }

    public class AUG : IProduct
    {
        public string Operation()
        {
            return "AUG bullet";
        }
    }

    class ClientWeapon
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the AK47 weapon");
            ClientCode(new WeaponAK47());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the AUG weapon");
            ClientCode(new WeaponAUG());
        }

        // Клиентский код работает с экземпляром конкретного создателя, хотя
        // и через его базовый интерфейс. Пока клиент продолжает работать с
        // создателем через базовый интерфейс, вы можете передать ему любой
        // подкласс создателя.
        public void ClientCode(Weapon creator)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.SomeOperation());
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            new ClientWeapon().Main();
        }
    }
}
