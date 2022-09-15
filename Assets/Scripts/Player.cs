using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    public float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        PlayerMoveKeyboard();
        AnimatePlayer();

        PlayerJump();
    }

    private void FixedUpdate() {
        PlayerJump();
    }

    void PlayerMoveKeyboard() {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0, 0) * moveForce * Time.deltaTime;
    }

    void AnimatePlayer() {
        if (movementX > 0) {
            // goint to right side
            anim.SetBool(WALK_ANIMATION, true);

            sr.flipX = false;

        } else if (movementX < 0) {
            // goint to left side
            anim.SetBool(WALK_ANIMATION, true);

            sr.flipX = true;
        } else {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;

            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        }
    }
}
