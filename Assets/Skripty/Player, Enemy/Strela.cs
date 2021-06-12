using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strela : MonoBehaviour {
    public float speed;

    private Transform hrac;
    public Enemy enemy;
    private Vector2 cil;
    void Start() {
        hrac = Hrac.MojeInstance.transform;
        cil = new Vector2(hrac.position.x, hrac.position.y);
        Vector2 cilecek = transform.position;
        var cil2 = (cil - cilecek) * 0.3f;
        cil = cil2 + cil;
    }
    
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, cil, speed * Time.deltaTime);

        if (transform.position.x == cil.x && transform.position.y == cil.y) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("hitbox")) {
            Hrac.MojeInstance.ChangeHp(-enemy.dmg);
            Destroy(gameObject);
        }
    }
    
}
