using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]//幫我們增加rigid body
[RequireComponent(typeof(Collider))]

public class Viking : MonoBehaviour
{
    [SerializeField]float speed = 10f;
    public float JumpingForce = 100f;
    Rigidbody rb;
    Animator animator, animatorEnemy;
    bool onGround = false, run = false;



    //GAMEOVER Screen
    public Gameover Screen;


    private int coin = 0;
    private bool gameover = false;

    //survival time
    public float timeStart;
    public Text textBox;
    public Text coinNum;

    private Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        animatorEnemy = enemy.GetComponent<Animator>();

        textBox.text = timeStart.ToString("F2");
        coinNum.text = ":" + coin;

        run = true;
    }


    // Update is called once per frame
    void Update()
    {

        //survival time
        textBox.text = timeStart.ToString("F2");
        coinNum.text = "$:" + coin;

        //左轉
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }
        //右轉
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }
        //左右吃硬幣
        if (Input.GetKey(KeyCode.J))
        {
            transform.localPosition += speed * Time.deltaTime * (-transform.right);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.localPosition += speed * Time.deltaTime * transform.right;
        }
        // jump
        if (Input.GetKey(KeyCode.Space) && onGround) 
        {
            rb.AddForce(JumpingForce * transform.up);
            animator.Play("Jump");
            //StartCoroutine(StopJump());
        }


        //GAMEOVER
        if (!gameover)
        {
            //自動跑
            transform.localPosition += speed * Time.deltaTime * transform.forward;
            //survival time
            timeStart += Time.deltaTime;
        }

        if (gameover)
        {
            StartCoroutine(GameOver());
            run = false;
            //enemy seize
            if (transform.position.z > enemy.position.z + 2|| transform.position.x > enemy.position.x + 2) 
                enemy.position += speed * Time.deltaTime * enemy.transform.forward;
        }

        if (transform.position.y < 2.7f)
        {
            gameover = true;
        }

        animator.SetBool("Run", run);
        animatorEnemy.SetBool("Gameover", gameover);        
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        Screen.Setup(coin, timeStart);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Ground
        if (collision.transform.name == "floor_01_variability_05")
        {
            onGround = true;
        }
        if (collision.transform.name == "floor_01_variability_05(Clone)")
        {
            onGround = true;
        }

        //Hurdle
        if (collision.transform.name == "rock_01(Clone)")
        {
            gameover = true;
        }
        if (collision.transform.name == "rock_02(Clone)")
        {
            gameover = true;
        }
        if (collision.transform.name == "rock_03(Clone)")
        {
            gameover = true;
        }
        if (collision.transform.name == "fence_03(Clone)")
        {
            gameover = true;
        }
        if (collision.transform.name == "fence_04(Clone)")
        {
            gameover = true;
        }

        //Coin
        if (collision.transform.name == "Viking_Shield(Clone)")
        {
            Destroy(collision.gameObject);
            coin++;
        }
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.name == "floor_01_variability_05")
        {
            onGround = true;
        }
        if (collision.transform.name == "floor_01_variability_05(Clone)")
        {
            onGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name == "floor_01_variability_05")
        {
            onGround = false;
        }
        if (collision.transform.name == "floor_01_variability_05(Clone)")
        {
            onGround = false;
        }
    }

}
