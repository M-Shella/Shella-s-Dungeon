using Pathfinding;
using UnityEngine;

public class Pronasledovani : MonoBehaviour {
    public Transform PoziceHrace;
    public Hrac hrac;
    public Enemy enemy;
    private float _pomocna;
    private void Start() {
        PoziceHrace = GameObject.FindGameObjectWithTag("Hrac").GetComponent<Transform>();
    }   
    private void FixedUpdate() {
       // if (Vector2.Distance(transform.position , PoziceHrace.position) > 1) {
       //     transform.position = Vector2.MoveTowards(transform.position, PoziceHrace.position, enemy.rychlost * Time.deltaTime);
       // }
        if (Vector2.Distance(transform.position , PoziceHrace.position) < 1.5){
            if (hrac.zivoty > 0 && Time.time > _pomocna) {
                hrac.ChangeHp(-enemy.dmg);
                _pomocna = Time.time + 0.5f;
                
            } 
        }
        
    }
}