using System;
using Pathfinding;
using Skripty.Itemy;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour {
    public int dmg;
    public int zivoty;
    public int xpDrop;
    public Item drop;
    public Inventar _inventar;
    private float _pomocna;
    private float _pomocna2;
    private bool freez;
    public Hrac hrac;
    public AIPath aipath;

    private void Start() {
        hrac = GameObject.FindWithTag("Hrac").GetComponent<Hrac>();
        dmg = 28+(hrac.level+1)*4;
        zivoty = 10 * (hrac.level+1);
        xpDrop = 201 * (hrac.level+1);
        freez = false;
        aipath = GetComponent<AIPath>();
        
    }
    //SpellStats - 0_ReloadTime 1_spell1Dmg 2_spell1ManaCost
    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Louzicka") && Time.time > _pomocna) {
            zivoty -= hrac.dmg/2;
            _pomocna = Time.time + 0.3f;
            if(!freez) aipath.maxSpeed = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Utok") && Time.time > _pomocna) {
            zivoty -= hrac.dmg;
            _pomocna = Time.time + 0.3f;
        }
        if (other.gameObject.CompareTag("Ohynek") && Time.time > _pomocna) {
            zivoty -= hrac.dmg*2;
            _pomocna = Time.time + 0.3f;
        }
        if (other.gameObject.CompareTag("Ledik") && Time.time > _pomocna) {
            zivoty -= hrac.dmg;
            _pomocna = Time.time + 0.3f;
            _pomocna2 = Time.time + 2f;
            freez = true;
            aipath.maxSpeed = 0;
        }
    }

    void Update() {
        if (freez && _pomocna2 <= Time.time) {
            aipath.maxSpeed = 7;
            freez = false;
        }
        if (zivoty <= 0) {
            hrac.PridejXp(xpDrop);
            hrac.ChangePenize(10);
            if (Random.Range(1,25) == 1) {drop = _inventar.getRandomItem(); ItemSpawner.MojeInstance.SpawniItem(gameObject.transform.position,drop.Id);}
            Destroy(gameObject);
        }
    }
}
