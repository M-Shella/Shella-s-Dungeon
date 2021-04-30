
using Skripty.Itemy;
using UnityEngine;
using UnityEngine.UI;

public class Hrac : MonoBehaviour {
    private static Hrac instance;
    
    public int dmg;
    public int dmgExtra;
    public int zivoty;
    public int zivotyMax;
    public int zivotyExtra;
    public int pocetCelkovichZivotu;
    public int mana;
    public int manaMax;
    public int manaExtra;
    public int xp;
    public int level;
    public int potiony;
    public int penize;
    public int staminaMax;
    public int staminaExtra;
    public int stamina;
    public float[] spell1Stats;
    public float[] spell2Stats;
    public float[] spell3Stats;

    [SerializeField] private GameObject[] spelly;
    [SerializeField] private GameObject bary;

    public KeyCode spell1Tlacitko;
    public KeyCode spell2Tlacitko;
    public KeyCode spell3Tlacitko;
    
    private Bary _zivotyBar;
    private Bary _manaBar;
    private Bary _xpBar;
    private Bary _staminaBar;

    public GameObject texty;
    public GameObject spell1;
    public GameObject spell2;
    public GameObject spell3;
    
    public Text potioinAmount;
    [SerializeField]private Text _pocetCekovichZivotuText;
    private Text _hpText;
    private Text _manaText;
    private Text _lvlText;
    private Text _penizeText;
    private Text _xpText;

    private void Start() {
        //SpellStats - 0_ReloadTime 1_spell1Dmg 2_spell1ManaCost
        spell1Stats[0] = 5;
        spell1Stats[1] = 10;
        spell1Stats[2] = 20;
        
        spell2Stats[0] = 15;
        spell2Stats[1] = 5;
        spell2Stats[2] = 40;
        
        spell3Stats[0] = 10;
        spell3Stats[1] = 5;
        spell3Stats[2] = 35;

        spell1Tlacitko = KeyCode.Alpha1;
        spell2Tlacitko = KeyCode.Alpha2;
        spell3Tlacitko = KeyCode.Alpha3;
        
        zivoty = 100;
        zivotyMax = 100;
        mana = 100;
        manaMax = 100;
        xp = 0;
        level = 2;
        penize = 0;
        dmg = 5;
        staminaMax = 10;
        stamina = 10;
        potiony = 3;
        pocetCelkovichZivotu = 3;
            
        _xpText = texty.transform.Find("XP").gameObject.GetComponent<Text>();
        _hpText = texty.transform.Find("Zivoty").gameObject.GetComponent<Text>();
        _manaText = texty.transform.Find("Mana").gameObject.GetComponent<Text>();
        _penizeText = texty.transform.Find("Peníze").gameObject.GetComponent<Text>();
        _lvlText = texty.transform.Find("Level").gameObject.GetComponent<Text>();

        _zivotyBar = bary.transform.Find("Health Bar").gameObject.GetComponent<Bary>();
        _manaBar = bary.transform.Find("Mana Bar").gameObject.GetComponent<Bary>();
        _staminaBar = bary.transform.Find("Stamina Bar").gameObject.GetComponent<Bary>();
        _xpBar = bary.transform.Find("LevelBar").gameObject.GetComponent<Bary>();

        _hpText.text = zivoty + " / " + zivotyMax;
        _manaText.text = mana + " / " + manaMax;
        _lvlText.text = (level - 1).ToString();
        _xpText.text = (xp + " / " + ((500 * Mathf.Pow(level, 2)) - (500 * level)));
        _penizeText.text = penize.ToString();
        
        //_xpBar.SetValue(0f);
    }

    public static Hrac MojeInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<Hrac>();
            }

            return instance;
        }
    }

    public void ChangeHp(int kolik) {
        Debug.Log(zivoty+ " " +zivotyMax);
        zivoty += kolik;
        
        //if (kolik > 0) zivotyMax += kolik;
        if (zivoty <= 0) zivoty = 0;
        
        if (zivoty == 0) {
            pocetCelkovichZivotu -= 1;
            _pocetCekovichZivotuText.text = pocetCelkovichZivotu.ToString();
            if (pocetCelkovichZivotu == 0) {
                UIManager.MojeInstance.DeathScreen.SetActive(true);
                Time.timeScale = 0f;
                gameObject.transform.position = Vector3.zero;
            }
            zivoty = zivotyMax;
            ChangeStamina(staminaMax - stamina);
            ChangeMana(manaMax - mana);
            ChangePenize(- (penize/5));
        }

        if (zivoty>zivotyMax) {
            
            zivoty = zivotyMax;
        }
        _hpText.text = zivoty + " / " + zivotyMax;
        _zivotyBar.SetValue(Mathf.Round((float) zivoty / zivotyMax * 1000f) / 1000f);
    }
    public void ChangeMana(int kolik) {
        mana += kolik;
        _manaText.text = mana + " / " + manaMax;
        _manaBar.SetValue(Mathf.Round((float) mana / manaMax * 1000f) / 1000f);
    }
    public void ChangeStamina(int kolik) {
        stamina += kolik;
        _staminaBar.SetValue(Mathf.Round((float) stamina / staminaMax * 1000f) / 1000f);
    }
    public void PridejXp(int kolik) {
        xp += kolik;
        if (xp >= ((500 * Mathf.Pow(level, 2)) - (500 * level))) {
            xp = (int) (xp - ((500 * Mathf.Pow(level, 2)) - (500 * level)));
            level++;
            _lvlText.text = (level - 1).ToString();
        }
        _xpBar.SetValue(xp / ((500 * Mathf.Pow(level, 2)) - (500 * level)));
        _xpText.text = (xp + " / " + ((500 * Mathf.Pow(level, 2)) - (500 * level)));
    }
    public void ChangePenize(int kolik) {
        penize += kolik;
        _penizeText.text = penize.ToString();
    }
    public void CastSpell1() {
        spell1 = Instantiate(spelly[0], transform.position, Quaternion.identity);
    }
    public void CastSpell2() {
        spell2 = Instantiate(spelly[1], transform.position, Quaternion.identity);
    }
    public void CastSpell3() {
        spell3 = Instantiate(spelly[2], transform.position, Quaternion.identity);
    }
    public void UpdatujStaty() {

        zivotyMax -= zivotyExtra;
        dmg -= dmgExtra;
        manaMax -= manaExtra;
        staminaMax -= staminaExtra;
        if (stamina > staminaMax) {stamina = staminaMax; ChangeStamina(0);}

        staminaExtra = 0;
        manaExtra = 0;
        zivotyExtra = 0;
        dmgExtra = 0;
        
        foreach (var item in InventarSkript.MojeInstance._inventar.inventar) {
            if (item == null || !item.item) continue;
            switch (item.item.Typ) {
                case type.Armor: {
                    var armor = (Armor)item.item;
                    zivotyExtra += armor.AddHp;
                    break;
                }
                case type.Zbran: {
                    var zbran = (Zbran)item.item;
                    dmgExtra += zbran.DmgChange;
                    break;
                }
                case type.Boty: {
                    var boty = (Boty)item.item;
                    staminaExtra += boty.AddStamina;
                    break;
                }
                case type.Hulka: {
                    var hulka = (Hulka)item.item;
                    manaExtra += hulka.AddMana;
                    break;
                }
            }
        }
        //ChangeHp(zivotyExtra);
        dmg += dmgExtra;
        zivotyMax += zivotyExtra;
        manaMax += manaExtra;
        staminaMax += staminaExtra;
        ChangeHp(0);
        ChangeMana(0);
        ChangeStamina(0);
    }
}