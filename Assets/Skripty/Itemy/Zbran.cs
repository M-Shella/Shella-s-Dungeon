using System;
using UnityEngine;

namespace Skripty.Itemy {
    [CreateAssetMenu(fileName = "Nova Zbran", menuName = "Inventar/Predmety/Zbran")]
    public class Zbran : Item {
        [SerializeField]private int dmgChange;
        public int DmgChange => dmgChange;
    }
}