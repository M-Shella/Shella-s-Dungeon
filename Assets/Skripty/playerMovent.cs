using UnityEngine;

public class playerMovent : MonoBehaviour
{
    public float rychlostPohybu = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;
    public Hrac hrac;

    private bool _sprint;
    private Vector2 _pohyb;
    private Vector2 _poziceMysi;
    
    private static readonly int Rychlost = Animator.StringToHash("Rychlost");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Sprint = Animator.StringToHash("Sprint");

    private void Start() {
        InvokeRepeating(nameof(UberStaminu),0f,0.5f); 
        InvokeRepeating(nameof(PridejStaminu),0f,0.5f);
    }

    private void Update(){
        _pohyb.x = Input.GetAxisRaw("Horizontal");
        _pohyb.y = Input.GetAxisRaw("Vertical");

        _poziceMysi = cam.ScreenToWorldPoint(Input.mousePosition);

        _sprint = Input.GetKey(KeyCode.LeftShift);
    }

    private void FixedUpdate(){
        //Pohyb
        rb.MovePosition(rb.position + _pohyb * (rychlostPohybu * Time.fixedDeltaTime));
        
        var lookDir = _poziceMysi - rb.position;

        //Animace 
        animator.SetFloat(Horizontal, lookDir.x);
        animator.SetFloat(Vertical, lookDir.y);
        animator.SetFloat(Rychlost, _pohyb.sqrMagnitude);

        //Sprint
        if (_sprint && hrac.stamina>=1){
            rychlostPohybu = 8;
            animator.SetBool(Sprint, true);
        }else{
            rychlostPohybu = 5;
            animator.SetBool(Sprint, false);
        }
    }

    private void UberStaminu() {
        if (_sprint && hrac.stamina >= 1) hrac.ChangeStamina(-1);
    }

    private void PridejStaminu() {
        if (!_sprint && hrac.stamina < hrac.staminaMax) hrac.ChangeStamina(1);
    }
}
