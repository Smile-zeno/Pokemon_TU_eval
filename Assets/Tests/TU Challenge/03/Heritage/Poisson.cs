using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Poisson : Animal
    {
        public Poisson(string name) : base(name + " le poisson")
        {
            _pattes = 0;
        }

        public override string Crier()
        {
            return "Blop blop blop !";
        }
    }
}
