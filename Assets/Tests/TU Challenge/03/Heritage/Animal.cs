using System;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;

namespace TU_Challenge.Heritage
{
    public abstract class Animal
    {
        protected string _name;
        protected int _pattes;
        protected bool _wasFeed;
        protected bool _isAlive;
        protected Animalerie _animalerie;
        
        public event Action OnDie;
        
        public string Name => _name;
        public int Pattes => _pattes;


        public Animal(string name)
        {
            _name = name;
            _wasFeed = false;
            _isAlive = true;
        }

        public bool IsAlive()
        {
            return _isAlive;
        }
        
        public virtual void Die()
        {
            _isAlive = false;
            OnDie?.Invoke();
        }

        public abstract string Crier();

        public virtual void Feed()
        {
            _wasFeed = true;
        }

        public virtual void Welcome(Animalerie animalerie)
        {
            _animalerie = animalerie;
        }
    }
}
