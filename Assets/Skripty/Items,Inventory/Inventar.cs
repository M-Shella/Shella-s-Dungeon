using System;
using Skripty.Itemy;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Vytvor Inventer", menuName = "Inventar/Novy")]
public class Inventar : ScriptableObject {
    public Slot[] inventar = new Slot[20];
    public int Length = 20;
    public Item[] item;

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
    
    public Item getRandomItem() {
        var randomCislo = Random.Range(1,100);
        Debug.Log(randomCislo);
        //Legendary
        if (randomCislo <= 5) {
            //return item[Random.Range(1,50)];
            Debug.Log("Legend");
            return item[Random.Range(1,4)];
            
        }
        //Epic
        if (randomCislo > 5 && randomCislo <=20) {
           // return item[Random.Range(51,100)];
           Debug.Log("Epic");
           return item[Random.Range(51,54)];
           
        }
        //Rare
        if (randomCislo > 20 && randomCislo <= 50) {
            //return item[Random.Range(101,250)];
            Debug.Log("Rare");
            return item[Random.Range(101,112)];
        }
        //Common
        if (randomCislo > 50) {
            //return item[Random.Range(250, 400)];
            Debug.Log("Common");
            return item[Random.Range(251,270)];
        }

        return null;
    }

    public Sprite vratSprite(int pozice) {
        if (inventar[pozice] == null) return null;
        return inventar[pozice].item != null ? inventar[pozice].item.Icona : null;
    }
    public Sprite vratSpriteZId(int id) {
        Debug.Log(id);
        return item[id].Icona;
    }

    public bool jeInvPlny() {
        foreach (var item in inventar) {
            if (item == null || item.item == null) {
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

