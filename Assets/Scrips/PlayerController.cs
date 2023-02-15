using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int playerHealth = 3;
    public float playerSpeed = 5.5f;
    string texto = "Hello World";
    private SpriteRenderer spriteRenderer;
    float horizontal;
    private Rigidbody2D rBody; 
    public float jumpForce = 3f;
    private GroundSensor sensor;
    public Animator anim;
    Coin coin;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        anim = GetComponent<Animator>();
        coin = GameObject.Find("Coin").GetComponent<Coin>();

        playerHealth = 10;
        Debug.Log(texto);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(horizontal, 0, 0) * playerSpeed * Time.deltaTime;
        if (horizontal < 0)
            {
                spriteRenderer .flipX = true;
                anim.SetBool("IsRunning", true);
            } else if (horizontal > 0)
                {
                    spriteRenderer .flipX = false;
                    anim.SetBool("IsRunning", true);
                } else{
                    anim.SetBool("IsRunning", false);
                }
        if (Input.GetButtonDown("Jump") && sensor.isGrounded)
            {
                rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("IsJumping", true);
            }

    }

    private void FixedUpdate() {
        rBody.velocity = new Vector2 (horizontal*playerSpeed, rBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "ColisionMoneda")
        {
            Coin coin = collision.gameObject.GetComponent<Coin>();
            coin.Pick();
        } 
    }  
}
