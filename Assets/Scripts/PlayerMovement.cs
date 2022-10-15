using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;

    Vector3 moveDirection;
    float horizontal;
    bool isFacingRight;
    
    Rigidbody2D rb;
    AudioSource audioSource;

    [SerializeField] AudioClip jumpSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        Flip();
        TeleportOtherSide();
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection);
    }

    private void Flip()

    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
          
          Vector2 jumpDirection = new Vector2(0, jumpPower);
          rb.velocity = jumpDirection;
            audioSource.PlayOneShot(jumpSound);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnTrigger"))
        {
            PlatformSpawner.Instance.PlatformSpawn();
            Destroy(collision.gameObject);
        }
    }

    private void TeleportOtherSide()
    {
        if(transform.position.x >2.78f)
        {
            transform.position = new Vector3(-2.78f, transform.position.y);
        }
        else if(transform.position.x < -2.78f)
        {
            transform.position = new Vector3(2.78f, transform.position.y);
        }
    }


    
}
