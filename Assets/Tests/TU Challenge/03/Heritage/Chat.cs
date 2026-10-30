using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TU_Challenge.Heritage
{
    public class Chat : Animal
    {
        private bool _wasFeedFish;
        
        public Chat(string name) : base(name)
        {
            _pattes = 4;
            _wasFeedFish = false;
        }

        public override string Crier()
        {
            if (_wasFeedFish)
            {
                return "Miaou (Le poisson etait bon)";
            }
            if (_wasFeed)
            {
                return "Miaou (c'est bon laisse moi tranquille humain)";
            }
            else
            {
                return "Miaou (j'ai faim)";
            }
        }

        public override void Feed()
        {
            _wasFeed = true;
        }
        
        public override void Welcome(Animalerie animalerie)
        {
            base.Welcome(animalerie);
            
            // manger bubulle
            foreach (var animal in animalerie.Animals)
            {
                if (animal is Poisson)
                {
                    EatAnimal(animal);
                    break;
                }
            }
            
            animalerie.OnAddAnimal += EatAnimal;
        }

        private void EatAnimal(Animal a)
        {
            if (a is Poisson)
            {
                a.Die();
                _wasFeedFish = true;
                _wasFeed = true;
            }
        }
        
        // private bool TryEatAnimal(Animal el)
        // {
        //     if (el is Poisson)
        //     {
        //         EatAnimal(el);
        //         return true;
        //     }
        //     return false;
        // }

        public override void Die()
        {
            base.Die();
            _animalerie.OnAddAnimal -= EatAnimal;
        }
    }
}
