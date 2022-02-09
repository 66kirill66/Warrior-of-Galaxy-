using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] float speed = 400;
    [SerializeField] float rotateSpeed = 100;
    
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 4.4f;
    [SerializeField] GameObject fire;
    [SerializeField] GameObject fire2;
    [SerializeField] int shotCount = 5;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] GameObject dieEfect;

    [SerializeField] AudioClip fireSound;
    [SerializeField] AudioClip diedSound;
    [SerializeField] AudioClip trust;   
    AudioSource audioSource;

    Rigidbody2D _rb2d;
    EnemySpoon bonus;

    float move;
    bool live = true;
    bool oneShot = true;
   
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bonus = FindObjectOfType<EnemySpoon>();
        gameOverCanvas.enabled = false;
        _rb2d = GetComponent<Rigidbody2D>();
        move = rotateSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {      
        MoveRotation("name");
        RangeMove();
        InputKeys();
        OneShot();
    }
    public void MoveLogic(string name)  // Android toch
    {
        if(live == true)
        {
            if (name == "Up")
            {
                audioSource.PlayOneShot(trust);
                _rb2d.velocity = Vector2.up * speed * Time.deltaTime;               
            }
            else if (name == "Down")
            {
                audioSource.PlayOneShot(trust);
                _rb2d.velocity = new Vector2(0, -speed * Time.deltaTime);
            }
            else if (name == "Left")
            {
                audioSource.PlayOneShot(trust);
                _rb2d.velocity = new Vector2(-speed * Time.deltaTime, 0);
            }
            else if (name == "Right")
            {
                audioSource.PlayOneShot(trust);
                _rb2d.velocity = new Vector2(speed * Time.deltaTime, 0);
            }
            else if (name == "Stop")
            {
                audioSource.Stop();
                _rb2d.velocity = new Vector2(0, 0);
            }
        }       
    }
    private void RangeMove()
    {
        float clampedXPos = Mathf.Clamp(transform.position.x, -xRange, xRange);

        float clampedYPos = Mathf.Clamp(transform.position.y, -yRange, yRange);

        transform.position = new Vector2(clampedXPos, clampedYPos);
    }
    public void FireButon()
    {
        if(oneShot == true)
        {
            
            audioSource.PlayOneShot(fireSound);
            Instantiate(fire,transform.position, transform.rotation);
        }
        else
        {
            audioSource.PlayOneShot(fireSound);
            Instantiate(fire2, transform.position, transform.rotation);
            Instantiate(fire2, new Vector2(transform.position.x + 0.4f, transform.position.y + 0.4f), transform.rotation);
            shotCount--;
        }
    }
    private void OneShot()
    {
        if (shotCount == 0)
        {
            oneShot = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bonus")
        {                   
            shotCount = 5;
            oneShot = false;
            Destroy(collision.gameObject);
            bonus.countBonus = 0;
            
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            live = false;
            audioSource.Stop();
            Instantiate(dieEfect,transform.position,transform.rotation);
            audioSource.PlayOneShot(diedSound);
            gameOverCanvas.enabled = true;
            _rb2d.bodyType = RigidbodyType2D.Static;
            Invoke("StopGame", 1); 
        }
    }
    private void InputKeys()    // Player Rotation 
    {
        if(live == true)
        {

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * move);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(-Vector3.forward * move);
            }
        }
    }
    public void MoveRotation(string name)   // Player Button to Rotate
    {
        if(name == "LeftRotation")
        {
            transform.Rotate(Vector3.forward * 10);
        }
        else if (name == "RightRotation")
        {
            transform.Rotate(-Vector3.forward * 10);
        }
        else if( name == "stop")
        {
            transform.rotation = transform.rotation;
        }
    }
    public void MoveLeft()
    {
        transform.Rotate(-Vector3.forward * 10);
    }
    void StopGame()   // called bay invoke method (collision with Enemy)
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }
}