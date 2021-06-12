using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject spawner;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Hrac") && !spawner.activeSelf) {
            spawner.SetActive(true);
        }
    }
}
