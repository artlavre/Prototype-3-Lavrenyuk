using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public float jumpForce = 100;
    public float gravityModifier=1;

    public bool isGrounded = true;
    public bool gameOver = false;

    public ParticleSystem explosion;
    public ParticleSystem dirtSteps;

    private Animator playerAnim;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip moneySound;

    private AudioSource playerAudio;

    private int money= 0;
    public  TextMeshProUGUI moneyCount;
    public GameObject menu;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;

        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded  && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound);
            dirtSteps.Stop();
        }
    }
    void SetCountText()
    {
        moneyCount.text = money.ToString() + " $";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isGrounded = true;
            dirtSteps.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            explosion.Play();
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound);
            dirtSteps.Stop();

            menu.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            money++;
            playerAudio.PlayOneShot(moneySound);
            SetCountText();
        }
    }
}
