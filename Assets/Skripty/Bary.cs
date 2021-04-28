using UnityEngine;

public class Bary : MonoBehaviour {
    private Transform _bar;
    private void Start() {
        _bar = gameObject.GetComponent<Transform>().Find("Velikost");
    }

    public void SetValue(float velikost) {
        _bar.localScale = new Vector3(velikost, 1f);
    }
}
