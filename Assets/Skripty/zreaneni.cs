using System;
using Skripty.Itemy;
using UnityEngine;
public class zreaneni : MonoBehaviour {
    private bool _bum;
    public Inventar _inventar;
    public Hrac hrac;
    public ParticleSystem ps;

    private void Update() {
        _bum = Input.GetKeyDown("k");
        if (hrac.zivoty > 0) {
            if (!_bum) return;
            ps.Play();
            
            hrac.PridejXp((int) ((500 * Mathf.Pow(hrac.level, 2)) - (500 * hrac.level)));
            //hrac.ChangeHp(10);
            //_inventar.addItem(_inventar.getItem(3));
            //ItemSpawner.MojeInstance.SpawniItem(new Vector3(-2,2,0),0);
            
            //_inventar.removeItem(1);
            //hrac.ChangeHp(-20);
            //if (hrac.mana > 0)hrac.ChangeMana(-5);
        }

    }
    
}
