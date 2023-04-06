using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserContorl : MonoBehaviour
{
    public float speed = 1f;
    public float maxSpeed = 10f;
    public float jumpSpeed = 5f;
    public float jumpPower = 100f;
    public float jumpRate = 1f;
    public float secondJump = 0.0f;
    public float fireRate = 0.2f;
    public float secondFire = 0.0f;
    public bool grounded; 
    public int hp = 100;
    public int numJem = 0;
    public TextMeshProUGUI numJemText;
    public Slider hpBar;
    public Rigidbody2D rigidBody2D;
    public Physics2D physics2D;
    Animator animator;
    public GameObject hitArea;
    public GameOver game_over;
    public AudioClip jem, jump, healItem, enemie, attack, dead;
    public AudioSource audioSource;

    void Start()
    {
        rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        hpBar.maxValue = hp;
        hpBar.value = hp;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(hp <= 0){
            hp = 0;
            audioSource.PlayOneShot(dead);
            game_over.gameOver();
            gameObject.SetActive(false);
            //Debug.log("Dead");
            //animator.SetTrigger("Die");
        }
        hpBar.value = hp; 
        numJemText.text = "Jem: " + numJem;
        animator.SetBool("Grounded", true); //set Ground
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal"))); //set speed
        if(Input.GetAxis("Horizontal") < -0.1f) { //for go left
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,180);
        } else if(Input.GetAxis("Horizontal") > 0.1f) {//for go right
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,0);
        }
        if(Input.GetButtonDown("Jump") && Time.time > secondJump) { 
            animator.SetBool("Jump", true);
            secondJump = Time.time + jumpRate;
            rigidBody2D.AddForce(jumpSpeed * (Vector2.up * jumpPower));
            audioSource.PlayOneShot(jump);
        } else {
            animator.SetBool("Jump", false);
        }
        if(Input.GetKey(KeyCode.E) && Time.time > secondFire) {
            secondFire = Time.time + fireRate;
            animator.SetBool("Attack", true);
            Attack();
            audioSource.PlayOneShot(attack);        
        } else{
            animator.SetBool("Attack", false);  
        }
    }

    public void Attack() {
        StartCoroutine(DelayFire());
    }

    public void TakeDamage(int damage) {
        hp = hp - damage;
    }
    
    IEnumerator DelayFire(){
        yield return new WaitForSeconds(0.3f);
        Instantiate(hitArea, transform.position, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Jem"){
            numJem += 1;
            Destroy(other.gameObject);
            audioSource.PlayOneShot(jem);
        }
        if(other.gameObject.tag == "ItemHeal"){
            hp = hp + 10;
            Destroy(other.gameObject);
            audioSource.PlayOneShot(healItem);
        }
        if(other.gameObject.tag == "DeathZone"){
           hp = 0;
        }
        if(other.gameObject.tag == "Enemie"){
           TakeDamage(10);
           audioSource.PlayOneShot(enemie);
        }
    }

}
