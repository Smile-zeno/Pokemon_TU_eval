using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Animalerie
    {
        private List<Animal> _animals;

        public List<Animal> Animals => _animals;
        public event Action<Animal> OnAddAnimal;

        public Animalerie()
        {
            _animals = new List<Animal>();
        }
        
        public void AddAnimal(Animal a)
        {
            _animals.Add(a);
            a.Welcome(this);
            OnAddAnimal?.Invoke(a);
        }

        public bool Contains(Animal a)
        {
            return _animals.Contains(a);
        }

        public Animal GetAnimal(int index)
        {
            return _animals[index];
        }

        public void FeedAll()
        {
            foreach (var animal in _animals)
            {
                animal.Feed();
            }
        }

        // public void InteractInsideAnimalerie(Animal animal)
        // {
        //     if (animal.Species == Animal.typeofanimal.Kat && animal.Pattes == 4)
        //     {
        //         for (int i = 0; i < _animals.Count - 1; i++)
        //         {
        //             if (_animals[i].Species == Animal.typeofanimal.Fih)
        //             {
        //                 animal.Feed();
        //                 _animals[i].Die();
        //             }
        //         }
        //     }
        //     else if (animal.Species == Animal.typeofanimal.Fih)
        //     {
        //         for (int i = 0; i < _animals.Count - 1; i++)
        //         {
        //             if (_animals[i].Species == Animal.typeofanimal.Kat && _animals[i].Pattes == 4)
        //             {
        //                 _animals[i].Feed();
        //                 animal.Die();
        //             }
        //         }
        //     }
        // }
    }
}
