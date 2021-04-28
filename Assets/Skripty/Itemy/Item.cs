using System;
using UnityEngine;
using UnityEngine.UI;

namespace Skripty.Itemy {
    public enum type{
        Zbran,
        Armor,
        Hulka,
        Boty,
    }
    public abstract class Item : ScriptableObject {
        [SerializeField]private Sprite icona;
        [SerializeField]private int id;
        [SerializeField]private string nazev;
        [SerializeField][TextArea(15,20)]private string popis;
        [SerializeField]private type typ;

        public Sprite Icona => icona;
        public int Id => id;

        public string Popis => popis;

        public type Typ => typ;
    }
}
