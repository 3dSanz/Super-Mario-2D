using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //variable para el prefab
    public GameObject bulletPrefab;
    //variable para la posicion desde la que se dispara el prefab
    public Transform bulletSpawn;

    //public Text coinText;
    //int contMonedas;
    //Coin coin;
    FinishFlag bandera;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        anim = GetComponent<Animator>();
        //coin = GameObject.Find("Coin").GetComponent<Coin>();
        bandera = GameObject.Find("Banderas_0").GetComponent<FinishFlag>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       // contMonedas = 0;
        playerHealth = 10;
        Debug.Log(texto);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameOver == false)
        {
             horizontal = Input.GetAxis("Horizontal");
          //transform.position += new Vector3(horizontal, 0, 0) * playerSpeed * Time.deltaTime;
         if (horizontal < 0)
             {
                 //spriteRenderer .flipX = true;
                 transform.rotation = Quaternion.Euler(0, 180, 0);
                 anim.SetBool("IsRunning", true);
                } else if (horizontal > 0)
                 {
                      //spriteRenderer .flipX = false;
                      transform.rotation = Quaternion.Euler(0, 0, 0);
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

        //Codigo para disparar la esfera
        if(Input.GetKeyDown(KeyCode.K) && gameManager.canShoot)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

    private void FixedUpdate() {
        rBody.velocity = new Vector2 (horizontal*playerSpeed, rBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
       /* if (collision.gameObject.tag == "ColisionMoneda")
        {
            Coin coin = collision.gameObject.GetComponent<Coin>();
            coin.Pick();
            contMonedas++;
            coinText.text = "coin " + contMonedas;
            Debug.Log(contMonedas);
        } */

        if (collision.gameObject.tag == "ColisionBandera")
        {
            FinishFlag bandera = collision.gameObject.GetComponent<FinishFlag>();
            bandera.TocarBandera();
        } 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ColisionMoneda")
        {
            Coin coin = collider.gameObject.GetComponent<Coin>();
            coin.Pick();
            gameManager.AddCoin();
        } 

        if(collider.gameObject.tag == "PowerUp")
        {
            gameManager.canShoot = true;
            Destroy(collider.gameObject);
        }
    }

}
