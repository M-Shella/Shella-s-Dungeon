using System;
using Skripty.Itemy;
using UnityEngine;
[CreateAssetMenu(fileName = "Vytvor Inventer", menuName = "Inventar/Novy")]
public class Inventar : ScriptableObject {
    public Slot[] inventar = new Slot[20];
    public int Length = 20;
    public Item[] item;

    private void Awake() {
        inventar = new Slot[Length];
    }

    public void addItem(Item item) {
        for (var i = 0; i < inventar.Length; i++) {
            if (inventar[i] == null || inventar[i].item) continue;
            inventar[i] = new Slot(item);
            break;
        }
        InventarSkript.MojeInstance.aktualizujInventar();
        Hrac.MojeInstance.UpdatujStaty();
    }

    public void removeItem(int id) {
        inventar[id].item = null;
        InventarSkript.MojeInstance.aktualizujInventar();
        //Hrac.MojeInstance.UpdatujStaty();
    }

    public Item getItem(int id) {
        return item[id];
    }

    public Sprite vratSprite(int pozice) {
        if (inventar[pozice] == null) return null;
        return inventar[pozice].item != null ? inventar[pozice].item.Icona : null;
    }
    public Sprite vratSpriteZId(int id) {
        return item[id].Icona;
    }

    public bool jeInvPlny() {
        foreach (var item in inventar) {
            if (item.item == null) {
                return false;
            }
        }

        return true;
    }
}

[Serializable] public class Slot {
    public Item item;

    public Slot(Item item) {
        this.item = item;
    }
}

