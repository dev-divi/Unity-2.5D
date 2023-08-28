using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2DLaptop : MonoBehaviour
{ 

    public float floatForce = 10;//jump float
    public float levitation = 5; //bounce
    private float gravityModifier = 1.5f; //jump moon gravity 

    public float speed = 10.0f; 

    public bool isOnGround = true; 
    public bool jumpman = false; 
    private Rigidbody2D playerRb;

    private Animator _anim;
    // from tarodev 
    //private SpriteRenderer _renderer;
    //private float _lockedTill;
    //private bool _jumpTriggered;

    private void Awake() {
        _anim = GetComponent<Animator>(); 
        //_renderer = GetComponent<SpriteRenderer>(); // from tarodev 
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();  
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        BoundariesPlayer();

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); 
        
        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        if (horizontalInput != 0) {
            
            Debug.Log("I detect movement"); 
        }        

        Jumpman();  



        //Animations Go
        //var state = GetState();
        //_jumpTriggered = false;

        //if (state == _currentState) return; //this breaks any more code running after so probably needs to move
        //_anim.CrossFade(state, 0, 0);
        //_anim.CrossFade(Jump, 10, 0);

        //_currentState = state;
        //Debug.Log("state is " + state); 

    }
    

    //private int GetState() {
        //if (Time.time < _lockedTill) return _currentState;

        // Priorities
        //if (_landed) return LockState(Land, _landAnimDuration);
        //if (_jumpTriggered) return Jump;

        //if (_grounded) return _player.Input.x == 0 ? Idle : Walk; //wtf
        //I should be able to replace the _player.input.x with what im currently pulling 

        
        //return playerRb.velocity.y > 0 ? Jump : Fall; //it works
        //return Jump;

        // same with here 

        //int LockState(int s, float t) {
        //    _lockedTill = Time.time + t;
        //    return s;
        //}
    //}

    //#region Cached Properties

    //private int _currentState;

    //private static readonly int Idle = Animator.StringToHash("Idle");
    //private static readonly int Walk = Animator.StringToHash("Walk");
    //private static readonly int Jump = Animator.StringToHash("Jump");
    //private static readonly int Fall = Animator.StringToHash("Fall");
    //private static readonly int Land = Animator.StringToHash("Land");

    //#endregion

    private void Jumpman(){
        if (Input.GetKey(KeyCode.Space) ) {

            playerRb.AddForce(Vector3.up * floatForce); // add ForceMode2D.Impulse and test results 
            isOnGround = false; 

            _anim.SetTrigger("jumpman");
        }
        else {
            _anim.ResetTrigger("jumpman");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerRb.AddForce(Vector3.up * levitation, ForceMode2D.Impulse);
        }

    }

    void BoundariesPlayer()
    {
        //zeta // unneeded for 2d 
        // if else 
        //horizontal
        if (transform.position.x >= 30f) {
            transform.position = new Vector3(30f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -8)
        {
            transform.position = new Vector3(-8, transform.position.y, transform.position.z);
        }
        //vertical
        if (transform.position.y >= 8) { 
            transform.position = new Vector3(transform.position.x, 8, transform.position.z);
        }
        else if (transform.position.y <= -7) //respawns player from top 
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }

    }
}
