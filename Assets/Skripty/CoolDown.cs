using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour {
    [SerializeField] private Image i1;
    [SerializeField] private Image i2;
    [SerializeField] private Image i3;
    [SerializeField] private Image potion;

    private bool coolDown1;
    private bool coolDown2;
    private bool coolDown3;
    private bool coolDown4;

    private Hrac hrac;

    private void Start() {
        hrac = GameObject.FindWithTag("Hrac").GetComponent<Hrac>();
        coolDown1 = false;
        coolDown2 = false;
        coolDown3 = false;
        coolDown4 = false;
    }

    void Update() {
        abilita1();
        abilita2();
        abilita3();
        potionCol();
    }

    void abilita1() {
        if (Input.GetKeyDown(hrac.spell1Tlacitko) && !coolDown1 && hrac.mana > hrac.spell1Stats[2]) {
            coolDown1 = true;
            i1.fillAmount = 1;
        }

        if (coolDown1) {
            i1.fillAmount -= 1 / hrac.spell1Stats[0] * Time.deltaTime;
            if (i1.fillAmount <= 0) {
                i1.fillAmount = 0;
                coolDown1 = false;
            }
        }
    }
    void abilita2() {
        if (Input.GetKeyDown(hrac.spell2Tlacitko) && !coolDown2 && hrac.mana > hrac.spell2Stats[2]) {
            coolDown2 = true;
            i2.fillAmount = 1;
        }

        if (coolDown2) {
            i2.fillAmount -= 1 / hrac.spell2Stats[0] * Time.deltaTime;
            if (i2.fillAmount <= 0) {
                i2.fillAmount = 0;
                coolDown2 = false;
            }
        }
    }
    void abilita3() {
        if (Input.GetKeyDown(hrac.spell3Tlacitko) && !coolDown3 && hrac.mana > hrac.spell3Stats[2]) {
            coolDown3 = true;
            i3.fillAmount = 1;
        }

        if (coolDown3) {
            i3.fillAmount -= 1 / hrac.spell3Stats[0] * Time.deltaTime;
            if (i3.fillAmount <= 0) {
                i3.fillAmount = 0;
                coolDown3 = false;
            }
        }
    }
    void potionCol() {
        if (Input.GetKeyDown(KeyCode.F) && hrac.potiony >= 1) {
            coolDown4 = true;
            if (potion.fillAmount == 0) potion.fillAmount = 1;
            hrac.potiony -= 1;
        }

        if (coolDown4) {
            potion.fillAmount -= 0.5f * Time.deltaTime;
            if (potion.fillAmount <= 0) {
                potion.fillAmount = 0;
                hrac.potiony += 1;
                if (hrac.potiony == 3) coolDown4 = false;
                else potion.fillAmount = 1;
            }
        }
    }
}