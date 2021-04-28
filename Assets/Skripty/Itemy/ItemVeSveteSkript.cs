using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVeSveteSkript : MonoBehaviour {
    public SpriteRenderer _spriteRenderer;
    private int id;

    public void vyberItem(int id) {
        this.id = id;
        _spriteRenderer.sprite = InventarSkript.MojeInstance._inventar.vratSpriteZId(id);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.gameObject.CompareTag("Hrac")) return;
        if (InventarSkript.MojeInstance._inventar.jeInvPlny()) return;
        
        InventarSkript.MojeInstance._inventar.addItem(InventarSkript.MojeInstance._inventar.getItem(id));
        Debug.Log(id);
        Destroy(gameObject);
    }
}
