﻿using System;
using Skripty.Itemy;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour {
    public int dmg;
    public int zivoty;
    public int xpDrop;
    public int rychlost;
    public Item drop;
    public Inventar _inventar;
    private float _pomocna;
    private float _pomocna2;
    private bool freez;
    public Hrac hrac;

    private void Start() {
        rychlost = 7;
        dmg = 28;
        zivoty = 10;
        xpDrop = 201;
        freez = false;
        
        hrac = GameObject.FindWithTag("Hrac").GetComponent<Hrac>();
    }
    //SpellStats - 0_ReloadTime 1_spell1Dmg 2_spell1ManaCost
    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Louzicka") && Time.time > _pomocna) {
            zivoty -= (int)hrac.spell2Stats[1];
            _pomocna = Time.time + 0.3f;
            if(!freez)rychlost = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Utok") && Time.time > _pomocna) {
            zivoty -= hrac.dmg;
            _pomocna = Time.time + 0.3f;
        }
        if (other.gameObject.CompareTag("Ohynek") && Time.time > _pomocna) {
            zivoty -= (int)hrac.spell1Stats[1];
            _pomocna = Time.time + 0.3f;
        }
        if (other.gameObject.CompareTag("Ledik") && Time.time > _pomocna) {
            zivoty -= (int)hrac.spell3Stats[1];
            _pomocna = Time.time + 0.3f;
            _pomocna2 = Time.time + 2f;
            freez = true;
            rychlost = 0;
        }
    }

    void Update() {
        if (freez && _pomocna2 <= Time.time) {
            rychlost = 7;
            freez = false;
        }
        if (zivoty <= 0) {
            hrac.PridejXp(xpDrop);
            hrac.ChangePenize(10);
            if (Random.Range(1,10) == 1) {drop = _inventar.getRandomItem(); ItemSpawner.MojeInstance.SpawniItem(gameObject.transform.position,drop.Id);}
            Destroy(gameObject);
        }
    }
}