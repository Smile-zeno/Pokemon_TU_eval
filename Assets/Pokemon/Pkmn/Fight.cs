
using System;

namespace Pkmn
{
    public class Fight
    {
        public Fight(Character character1, Character character2)
        {
            if (character1 == null || character2 == null)
            {
                throw new ArgumentNullException("A fight must have two participants");
            }
            Character1 = character1;
            Character2 = character2;
            _isFightFinished = false;
        }

        public Character Character1 { get; }
        public Character Character2 { get; }

        /// <summary>
        /// Est-ce la condition de victoire/défaite a été rencontré ?
        /// </summary>
        private bool _isFightFinished;
        public bool IsFightFinished => _isFightFinished;

        /// <summary>
        /// Jouer l'enchainement des attaques. Attention à bien gérer l'ordre des attaques par apport à la speed des personnages
        /// </summary>
        /// <param name="skillFromCharacter1">L'attaque selectionné par le joueur 1</param>
        /// <param name="skillFromCharacter2">L'attaque selectionné par le joueur 2</param>
        /// <exception cref="ArgumentNullException">si une des deux attaques est null</exception>
        public void ExecuteTurn(Skill skillFromCharacter1, Skill skillFromCharacter2)
        {
            if (IsFightFinished)
            {
                return;
            }

            if (Character1.CurrentEquipment.AsPriority)
            {
                Character1Start(skillFromCharacter1, skillFromCharacter2);
            }
            else if (Character2.CurrentEquipment.AsPriority)
            {
                Character2Start(skillFromCharacter1, skillFromCharacter2);
            }
            else
            {
                if (Character1.Speed < Character2.Speed)
                {
                    Character2Start(skillFromCharacter1, skillFromCharacter2);
                }
                else
                {
                    Character1Start(skillFromCharacter1, skillFromCharacter2);
                }
            }
        }

        private void Character1Start(Skill skillFromChar1, Skill skillFromChar2)
        {
            Character2.ReceiveAttack(skillFromChar1);
            if (Character2.IsAlive)
            {
                Character1.ReceiveAttack(skillFromChar2);
            }
            else
            {
                _isFightFinished = true;
            }
        }

        private void Character2Start(Skill skillFromChar1, Skill skillFromChar2)
        {
            Character1.ReceiveAttack(skillFromChar2);
            if (Character1.IsAlive)
            {
                Character2.ReceiveAttack(skillFromChar1);
            }
            else
            {
                _isFightFinished = true;
            }
        }
    }
}
