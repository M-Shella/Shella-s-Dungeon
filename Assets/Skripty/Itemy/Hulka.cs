using System;
using UnityEngine;

namespace Skripty.Itemy {
    [CreateAssetMenu(fileName = "Nova Hulka", menuName = "Inventar/Predmety/Hulka")]
    public class Hulka : Item {
        [SerializeField]private int addMana;

        public int AddMana => addMana;
    }
}