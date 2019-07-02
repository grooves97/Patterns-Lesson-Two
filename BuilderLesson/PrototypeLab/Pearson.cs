using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeLab
{
    public class Pearson
    {
        int age;
        public DateTime bithDate;
        public string name;
        public IdInfo idInfo;
        public Addres addres;
        public int numberStreet;
        public string SecondName;

        public Pearson ShallowCopy()
        {
            return (Pearson)this.MemberwiseClone();
        }

        public Pearson DeepCopy()
        {
            Pearson clone = (Pearson)this.MemberwiseClone();
            clone.idInfo = new IdInfo(idInfo.IdNumber);
            clone.addres = new Addres(addres,numberStreet);
            clone.name = String.Copy(name);
            return clone;
        }
    }
}
