using System;

namespace Pkmn
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            if (baseHealth <= 0)
            {
                throw new ArgumentOutOfRangeException("baseHealth should not be equal to 0 or negative");
            }
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;

            CurrentHealth = baseHealth;
            _isAlive = true;
        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth { get; private set; }
        public TYPE BaseType { get => _baseType;}
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                if (CurrentEquipment == null)
                {
                    return _baseHealth;
                }
                return _baseHealth + CurrentEquipment.BonusHealth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("MaxHp should not be equal to 0 or negative");
                }
                
                if (CurrentHealth > value)
                {
                    CurrentHealth = value;
                }
                _baseHealth = value;
            }
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                if (CurrentEquipment == null)
                {
                    return _baseAttack;
                }
                return _baseAttack + CurrentEquipment.BonusAttack;
            }
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                if (CurrentEquipment == null)
                {
                    return _baseDefense;
                }
                return _baseDefense + CurrentEquipment.BonusDefense;
            }
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                if (CurrentEquipment == null)
                {
                    return _baseSpeed;
                }
                return _baseSpeed + CurrentEquipment.BonusSpeed;
            }
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get; private set; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        private bool _isAlive;
        public bool IsAlive => _isAlive;


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            int newHealth = CurrentHealth;
            newHealth -= s.Power - Defense;
            CurrentStatus = StatusEffect.GetNewStatusEffect(s.Status);
            if (newHealth <= 0)
            {
                CurrentHealth = 0;
                _isAlive = false;
            }
            else
            {
                CurrentHealth = newHealth;
            }
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if (newEquipment == null)
            {
                throw new ArgumentNullException("Equipement cannot be null");
            }
            CurrentEquipment = newEquipment;
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            CurrentEquipment = null;
        }

        public void Heal(int amountHealed)
        {
            int newHealth = CurrentHealth;
            newHealth += amountHealed;
            if (amountHealed + CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            else
            {
                CurrentHealth = newHealth;
            }
        }
    }
}
