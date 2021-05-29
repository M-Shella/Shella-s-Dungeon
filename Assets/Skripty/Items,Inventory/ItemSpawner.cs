using System;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    private static GameObject spawner;
    private ItemVeSveteSkript _skript;
    private static ItemSpawner instance;
    private GameObject item;

    public static ItemSpawner MojeInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<ItemSpawner>();
            }

            return instance;
        }
    }
    private void Awake() {
        spawner = gameObject;
        item = transform.GetChild(0).gameObject;
        _skript = item.GetComponent<ItemVeSveteSkript>();
    }
    

    public void SpawniItem(Vector3 pozice,int idItemu) {
        var clon = Instantiate(item, pozice, Quaternion.identity);
        Debug.Log(idItemu);
        clon.GetComponent<ItemVeSveteSkript>().vyberItem(idItemu);
    }
}
