using Pkmn;
using NUnit.Framework;
using System;

namespace Pkmn.Tests
{
    public class FightMoreTests
    {
        // Tu as probablement remarqué qu'il y a encore beaucoup de code qui n'a pas été testé ...
        // À présent c'est à toi de créer des features et les TU sur le reste du projet
        
        // Ce que tu peux ajouter:
        // - Ajouter davantage de sécurité sur les tests apportés
            // - un heal ne régénère pas plus que les HP Max
            [Test]
            public void CharacterHeal()
            {
                var pikachu = new Character(100, 50, 30, 20, TYPE.NORMAL);
                var punch = new Punch();
                var oldHealth = pikachu.CurrentHealth;

                pikachu.ReceiveAttack(punch); // hp : 100 => 60
                Assert.That(pikachu.CurrentHealth, 
                    Is.EqualTo(oldHealth - (punch.Power - pikachu.Defense))); // 100 - (70-30)
                Assert.That(pikachu.CurrentStatus, Is.EqualTo(null));
                Assert.That(pikachu.IsAlive, Is.EqualTo(true));

                int healValue = 20;
                oldHealth = pikachu.CurrentHealth;
                pikachu.Heal(healValue);
                Assert.That(pikachu.CurrentHealth, Is.EqualTo(oldHealth + healValue));
            }

            [Test]
            public void CharacterOverHeal()
            {
                var pikachu = new Character(100, 50, 30, 20, TYPE.NORMAL);
                pikachu.Heal(100);
                Assert.That(pikachu.CurrentHealth, Is.EqualTo(pikachu.MaxHealth));
            }
            // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
            [Test]
            public void CharacterLoweringMaxHP()
            {
                var pikachu = new Character(100, 50, 30, 20, TYPE.NORMAL);
                pikachu.MaxHealth = 70;
                Assert.That(pikachu.CurrentHealth, Is.EqualTo(pikachu.MaxHealth));
                
                var bulbizarre = new Character(90, 60, 10, 200, TYPE.NORMAL);
                var p = new Punch();
                var oldHealth = bulbizarre.CurrentHealth;
                bulbizarre.ReceiveAttack(p);
                bulbizarre.MaxHealth = 90;
                Assert.That(bulbizarre.CurrentHealth, Is.EqualTo(oldHealth - (p.Power - bulbizarre.Defense)));
                Assert.That(bulbizarre.MaxHealth, Is.EqualTo(90));
            }
            // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)
            [Test]
            public void EquipementWithPriority()
            {
                var c = new Character(100, 500, 30, 20, TYPE.NORMAL);
                var c2 = new Character(100, 50, 30, 200, TYPE.NORMAL);
                var c3 = new Character(100, 500, 30, 200, TYPE.NORMAL);
                var e = new Equipment(100, 90, 70, 12, true);

                // Equip character
                c.Equip(e);
                Fight f = new Fight(c, c2);
                Punch p = new Punch();

                // Both uses punch
                f.ExecuteTurn(p, p);

                Assert.That(c.IsAlive, Is.EqualTo(true));
                Assert.That(c2.IsAlive, Is.EqualTo(false));
                Assert.That(f.IsFightFinished, Is.EqualTo(false));
                
                c.Unequip();
                Fight f2 = new Fight(c, c3);
                
                f2.ExecuteTurn(p, p);

                Assert.That(c.IsAlive, Is.EqualTo(false));
                Assert.That(c3.IsAlive, Is.EqualTo(true));
                Assert.That(f.IsFightFinished, Is.EqualTo(false));
            }
        // - Le support des status (sleep et burn) qui font des effets à la fin du tour et/ou empeche le pkmn d'agir
        // - Gérer la notion de force/faiblesse avec les différentes attaques à disposition (skills.cs)
        // - Cumuler les force/faiblesses en ajoutant un type pour l'équipement qui rendrait plus sensible/résistant à un type
        // - L'utilisation d'objets : Potion, SuperPotion, Vitess+, Attack+ etc.
        // - Gérer les PP (limite du nombre d'utilisation) d'une attaque,
            // si on selectionne une attack qui a 0 PP on inflige 0
        
        // Choisis ce que tu veux ajouter comme feature et fait en au max.
        // Les nouveaux TU doivent être dans ce fichier.
        // Modifiant des features il est possible que certaines valeurs
            // des TU précédentes ne matchent plus, tu as le droit de réadapter les valeurs
            // de ces anciens TU pour ta nouvelle situation.
        
    }
}
