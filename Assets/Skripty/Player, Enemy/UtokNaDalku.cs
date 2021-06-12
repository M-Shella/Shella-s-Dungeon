using Pathfinding;
using UnityEngine;

public class UtokNaDalku : MonoBehaviour {
    public Transform PoziceHrace;
    public Hrac hrac;
    public Enemy enemy;
    private float _pomocna;
    public AIPath aipath;
    public GameObject strela;
    public ParticleSystem ps;
    private void Start() {
        PoziceHrace = GameObject.FindGameObjectWithTag("Hrac").GetComponent<Transform>();
    }   
    private void FixedUpdate() {
        if (aipath.velocity == Vector3.zero && Vector2.Distance(transform.position , PoziceHrace.position) < 8) {
            if (Time.time > _pomocna) {
                var spawn = Instantiate(strela, transform.position, Quaternion.identity);
                spawn.GetComponent<Strela>().enemy = enemy;
                spawn.GetComponent<Strela>().hit = ps;
                _pomocna = Time.time + 3f;
            }
        }
    }
}