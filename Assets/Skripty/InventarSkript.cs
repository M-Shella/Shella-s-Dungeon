using UnityEngine;
using UnityEngine.UI;

public class InventarSkript : MonoBehaviour {
    public Inventar _inventar;
    private CanvasGroup canvasGroup;
    private static InventarSkript instance;
    public void aktualizujInventar() {
        for (int i = 0; i < _inventar.Length; i++) {
            gameObject.transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = _inventar.vratSprite(i);
        }
    }

    public static InventarSkript MojeInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<InventarSkript>();
            }
            return instance;
        }
    }

    private void Start() {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        aktualizujInventar();
    }

    public void OtveritZavrit() {
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;
        canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
    }
}
