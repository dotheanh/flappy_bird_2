using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 2.4f;
    private Rigidbody2D _rigidbody;
    private CapsuleCollider2D _collider;
    public bool isDead = false;
    public bool playDeadSound = false;
    public GameManager gameManager;

    public Vector2 _centerOfMass;
    Quaternion forwardRotation;
    Quaternion upRotation;
    Quaternion downRotation;
    public float tiltSmooth = 5;

    // Start is called before the first frame update
    void Start()
    {
        forwardRotation = Quaternion.Euler(0, 0, 0);
        upRotation = Quaternion.Euler(0, 0, 90);
        downRotation = Quaternion.Euler(0, 0, -90);

        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
        StopMoving();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (gameManager.gameState == GameState.Started) {
                transform.rotation = upRotation;
                SoundManager.PlaySound("swing");
                _rigidbody.velocity = Vector2.up * velocity * 1.3f;
                //_rigidbody.AddForceAtPosition(Vector2.up * velocity * 1.3f, Vector2.right*2);   // add force at the head
            }
        }
        
        if (!isDead) {
            transform.rotation = Quaternion.Lerp(transform.rotation, forwardRotation, tiltSmooth*Time.deltaTime);
        }
        else {
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth*Time.deltaTime);
        }

        if (playDeadSound && _rigidbody.position.y < -3.81) {
            SoundManager.PlaySound("die");
            playDeadSound = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.PlaySound("hit");
        isDead = true;
        playDeadSound = true;
        gameManager.GameOver();
        _collider.enabled = false;
    }

    public void StartMoving()
    {
        _rigidbody.gravityScale = 1f;
    }

    public void StopMoving()
    {
        _rigidbody.gravityScale = 0.0f;
    }
}