using UnityEngine;

public class Spell : MonoBehaviour {
    private Rigidbody2D MojeRigidbody2D;
    [SerializeField] private int rychlost;
    private Transform cil;
    private Vector2 _poziceMysi;
    public Camera _camera;
    private float _pomocna;

    void Start() {
        MojeRigidbody2D = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        _poziceMysi = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate() {
        MojeRigidbody2D.velocity = (_poziceMysi - (Vector2)transform.position) * rychlost;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Ohynek")) {
            Destroy(gameObject);
        }
    }
}
