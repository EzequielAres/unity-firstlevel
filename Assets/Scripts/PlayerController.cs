using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public int speed;
    public int jumpForce;
    public int score;
    public int livesCount;
    public int levelTime;
    public Canvas canvas;
    public AudioClip jumpSound;
    public AudioClip hitSound;

    private int timeSpended;
    private float startTime;
    private bool vulnerable;
    private Rigidbody2D physics;
    private SpriteRenderer sprite;
    private Animator animator;
    private GameDataController gameData;
    private HUDController hud;
    private AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        hud = canvas.GetComponent<HUDController>();
        startTime = Time.time;
        vulnerable = true;
        physics = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gameData = GameObject.Find("GameData").GetComponent<GameDataController>();    
    }
    private void FixedUpdate()
    {
        float movementx = Input.GetAxis("Horizontal");
        physics.velocity = new Vector2(movementx * speed, physics.velocity.y);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && TouchingGround()) {
            physics.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            audioSource.PlayOneShot(jumpSound);
        }

        if (physics.velocity.x > 0) sprite.flipX = false;
        if (physics.velocity.x < 0) sprite.flipX = true;

        AnimatePlayer();

        hud.SetLeftCollectionables(GameObject.FindGameObjectsWithTag("Collectionable").Length);
        if (GameObject.FindGameObjectsWithTag("Collectionable").Length == 0)
        {
            WinGame();
        }

        timeSpended = (int)(Time.time - startTime);
        hud.SetLeftTime(levelTime - timeSpended);

        hud.SetLivesTxt(livesCount);

        if (levelTime - timeSpended <= 0) {
            EndGame();
        }
    }

    private void AnimatePlayer()
    {
        if (!TouchingGround())
        {
            animator.Play("PlayerJump");
        } else if ((physics.velocity.x > 0 || physics.velocity.x < -1) && physics.velocity.y == 0)
        {
            animator.Play("PlayerRunning");
        } else if ((physics.velocity.x > -1 || physics.velocity.x < 1) && physics.velocity.y == 0)
        {
            animator.Play("PlayerIdle");
        }
    }

    private bool TouchingGround(){

        RaycastHit2D touching = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.down, 0.1f);

        return touching.collider != null;
    }

    public void LoseLive()
    {
        if (vulnerable) {
            vulnerable = false;
            livesCount--;
            animator.Play("PlayerInvulnerable");
            audioSource.PlayOneShot(hitSound);
        }
        if (livesCount == 0) EndGame();
        Invoke("SetVulnerable", 3f);
    }

    public void SetVulnerable()
    {
        vulnerable = true;
    }
    public void EndGame()
    {
        gameData.Win = false;
        SceneManager.LoadScene("EndLevel");
    }

    public void IncreaseScore(int score)
    {
        this.score += score;
    }

    public void WinGame()
    {
        score = (livesCount * 100) + (levelTime - timeSpended);
        gameData.Score = score;
        gameData.Win = true;
        SceneManager.LoadScene("EndLevel");
    }
}
