using System;
using UnityEngine;

namespace Skripty.Itemy {
    [CreateAssetMenu(fileName = "Novy Boty", menuName = "Inventar/Predmety/Boty")]
    public class Boty : Item {
        [SerializeField]private int addStamina;

        public int AddStamina => addStamina;
    }
}