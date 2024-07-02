using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    InputActions controls;

    public AudioSource src;
    public AudioClip start,blast,coin,jump;
   
    [SerializeField]
    private float moveForce = 7f;
    [SerializeField]
    private float jumpForce = 8f;
    private SpriteRenderer spriteRenderer;
    private float movementX;
    private Rigidbody2D catBody;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string JUMB_ANIMATION = "Jump";

    private string BLAST_ANIMATION = "blast";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private string COIN_TAG = "Coin";
    private bool isGrounded;
    public Text Scoretext;

    [HideInInspector]
    public int score=0;
    private int minX = -45;
    private int maxX = 56;
    private void Awake(){
        catBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        controls = new InputActions();
        controls.Enable();

        controls.Game.Movement.performed += ctx =>{
           
            movementX = ctx.ReadValue<float>();
        };

        controls.Game.Jump.performed += ctx =>{
            
           PlayerJump();
        };
    }
    // Start is called before the first frame update
    void Start()
    {
        src.clip = start;
        src.Play();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementKeyboard();
        AnimateWalk();
        Scoretext.text = score.ToString();
    }
    private void FixedUpdate(){
        
    }
    void PlayerMovementKeyboard(){
        
        if(transform.position.x < minX){
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        if(transform.position.x > maxX){
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        transform.position += new Vector3(movementX,0f,0f) * Time.deltaTime * moveForce;
    }

    void AnimateWalk(){
        if(movementX > 0f){
            anim.SetBool(WALK_ANIMATION, true);
            spriteRenderer.flipX = false;
        }else if(movementX < 0f){
            anim.SetBool(WALK_ANIMATION, true);
            spriteRenderer.flipX = true;
        }else{
              anim.SetBool(WALK_ANIMATION, false);
        }
    }
    void PlayerJump(){
        if(isGrounded){
            src.clip = jump;
            src.Play();
            isGrounded = false;
            catBody.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
            anim.SetBool(JUMB_ANIMATION, true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(GROUND_TAG)){
            anim.SetBool(JUMB_ANIMATION, false);
            isGrounded = true;
        }

    if(collision.gameObject.CompareTag(ENEMY_TAG)){
        src.clip = blast;
        src.Play();
            anim.SetBool(BLAST_ANIMATION, true);
            Destroy(collision.gameObject);
            StartCoroutine(DestroyTime(1));
        }
        
        if(collision.gameObject.CompareTag(COIN_TAG)){
            src.clip = coin;
            src.Play();
            score = score+1;
            print(score);
            Destroy(collision.gameObject);
            
        }
        
    }

    IEnumerator DestroyTime(float time)
{
    yield return new WaitForSeconds(time);

    Destroy(gameObject);
    SceneManager.LoadScene("MainMenu");

}
    
}
