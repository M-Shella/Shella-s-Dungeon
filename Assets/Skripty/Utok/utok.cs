using System;
using UnityEngine;

public class utok : MonoBehaviour {
    public Camera cam;
    public GameObject animace;
    public Animator animator;
    private Vector2 _poziceMysi;
    private float _pomocna;
    private float _pomocna2;
    private float _pomocna3;
    private float _pomocna4;
    private static readonly int Utoceni = Animator.StringToHash("Utoceni");
    public ParticleSystem ps;
    private Hrac hrac;

    private void Start() {
        hrac = gameObject.GetComponent<Hrac>();
    }
    //SpellStats - 0_ReloadTime 1_spell1Dmg 2_spell1ManaCost
    private void Update() {
        //Utok
        if (Input.GetButtonDown("Fire1") && Time.time > _pomocna) {
            _poziceMysi = cam.ScreenToWorldPoint(Input.mousePosition);
            var efekt = Instantiate(animace,_poziceMysi, Quaternion.identity);
            Destroy(efekt, 0.24f);
            _pomocna = Time.time + 0.3f;
        }else animator.SetBool(Utoceni, Time.time < _pomocna);
        
        //Spell1
        if (Input.GetKeyDown(hrac.spell1Tlacitko) && hrac.mana >= hrac.spell1Stats[2] && Time.time > _pomocna2 && hrac.level >= 3) {
            hrac.ChangeMana(-(int)hrac.spell1Stats[2]);
            _poziceMysi = cam.ScreenToWorldPoint(Input.mousePosition);
            hrac.CastSpell1();
            
            //rotace
            Vector2 x = hrac.spell1.transform.position;
            var smer = _poziceMysi - x;
            var uhel = Mathf.Atan2(smer.y, smer.x) * Mathf.Rad2Deg;
            hrac.spell1.transform.rotation = Quaternion.AngleAxis(uhel, Vector3.forward);

            hrac.spell1.transform.position = Vector2.MoveTowards(hrac.transform.position, _poziceMysi, 5 * Time.deltaTime);

            var rotace = ps.shape;
            rotace.rotation = new Vector3(-uhel, 90, 0);
            ps.Play();
            
            _pomocna2 = Time.time + hrac.spell1Stats[0];
        }   
        if (hrac.spell1 && Vector2.Distance(hrac.spell1.transform.position, _poziceMysi) <= 0.02) {
            Destroy(hrac.spell1);
        }
        
        //Spell2
        if (Input.GetKeyDown(hrac.spell2Tlacitko) && hrac.mana >= hrac.spell2Stats[2] && Time.time > _pomocna3 && hrac.level >= 6) {
            hrac.ChangeMana(-(int)hrac.spell2Stats[2]);
            _poziceMysi = cam.ScreenToWorldPoint(Input.mousePosition);
            hrac.CastSpell2();
            hrac.spell2.transform.position = _poziceMysi;
            _pomocna3 = Time.time + hrac.spell2Stats[0];
            Destroy(hrac.spell2, 7);
        }
        
        //Spell3
        if (Input.GetKeyDown(hrac.spell3Tlacitko) && hrac.mana >= hrac.spell3Stats[2] && Time.time > _pomocna4 && hrac.level >= 11) {
            hrac.ChangeMana(-(int)hrac.spell3Stats[2]);
            _poziceMysi = cam.ScreenToWorldPoint(Input.mousePosition);
            hrac.CastSpell3();
            
            //rotace
            Vector2 x = hrac.spell3.transform.position;
            var smer = _poziceMysi - x;
            var uhel = Mathf.Atan2(smer.y, smer.x) * Mathf.Rad2Deg;
            hrac.spell3.transform.rotation = Quaternion.AngleAxis(uhel, Vector3.forward);
            
            hrac.spell3.transform.position = Vector2.MoveTowards(hrac.transform.position, _poziceMysi, 5 * Time.deltaTime);
            _pomocna4 = Time.time + hrac.spell3Stats[0];
        }
        if (hrac.spell3 && Vector2.Distance(hrac.spell3.transform.position, _poziceMysi) <= 0.1) {
            Destroy(hrac.spell3);
        }
    }
}
