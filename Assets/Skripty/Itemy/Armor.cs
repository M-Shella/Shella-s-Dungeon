using System;
using UnityEngine;

namespace Skripty.Itemy {
    [CreateAssetMenu(fileName = "Novy Armor", menuName = "Inventar/Predmety/Armor")]
    public class Armor : Item {
        [SerializeField]private int addHP;

        public int AddHp => addHP;
    }
}