using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPractice
{
    public interface IBuilder
    {
        void BuildBodypart();
        void BuildBatteryPlusPart();
        void BuildCoverPart();
    }

    public class SamsungBuilder : IBuilder
    {
        private Product _product = new Product();

        public SamsungBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void BuildBodypart()
        {
            this._product.Add("Body samsung");
        }

        public void BuildBatteryPlusPart()
        {
            this._product.Add("Battery plus samsung");
        }

        public void BuildCoverPart()
        {
            this._product.Add("Cover samsung");
        }

        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }

    //public class NokiaBuilder : IBuilder
    //{
    //    private Product _product = new Product();

    //    public NokiaBuilder()
    //    {
    //        this.Reset();
    //    }

    //    public void Reset()
    //    {
    //        this._product = new Product();
    //    }
    //    public void BuildBatteryPlusPart()
    //    {
    //        this._product.Add("");
    //    }

    //    public void BuildBodypart()
    //    {
    //    }

    //    public void BuildCoverPart()
    //    {
    //    }
    //}

    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2);

            return "Product parts: " + str + "\n";
        }
    }

    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void buildMinimalViableProduct()
        {
            this._builder.BuildBodypart();
        }

        public void buildFullFeaturedProduct()
        {
            this._builder.BuildBodypart();
            this._builder.BuildCoverPart();
            this._builder.BuildBatteryPlusPart();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            SamsungBuilder builder = new SamsungBuilder();
            director.Builder = builder;

            Console.WriteLine("Standard basic product:");
            director.buildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Standard full featured product:");
            director.buildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Custom product:");
            builder.BuildBodypart();
            builder.BuildBatteryPlusPart();
            Console.Write(builder.GetProduct().ListParts());
        }
    }
}
