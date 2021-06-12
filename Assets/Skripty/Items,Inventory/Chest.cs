using UnityEngine;

public class Chest : MonoBehaviour {
    public Inventar _inventar;
    [SerializeField]private Sprite otevrenaTruhla;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Hrac")) {
            gameObject.GetComponent<SpriteRenderer>().sprite = otevrenaTruhla;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            var spawn = gameObject.transform.position;
            spawn.y -= 1;
            var item = _inventar.getRandomItem();
            ItemSpawner.MojeInstance.SpawniItem(spawn, item.Id);
        }
    }
}
