using UnityEngine;
using UnityEngine.UI;

public class heal : MonoBehaviour {
    public Text _pocetCekovichZivotuText;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Hrac")) {
            Hrac.MojeInstance.pocetCelkovichZivotu += 1;
            _pocetCekovichZivotuText.text = Hrac.MojeInstance.pocetCelkovichZivotu.ToString();
            Destroy(gameObject);
        }
    }
}
