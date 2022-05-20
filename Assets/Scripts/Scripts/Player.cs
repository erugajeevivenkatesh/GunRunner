using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instacne;

    public float MaxupVelocity=10f;
    public float sideBoundry = 3;
    private Vector3 point1,point2;
    public float moveSpeed;

    public float farwardmovespeed=20f;
    public GameObject Bullet;
    public Transform shootPosition;
    public GameManager manager;
    public enum InputPhase
    {
        LEFT,RIGHT,UP, DOWN,RUN
    }

    public InputPhase PlayerState;
    private void Awake()
    {
        if (instacne == null)
        { instacne = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    [SerializeField]
    private float jumpForce=10f;
    private Rigidbody rb;

    void Start()
    {
        rb=GetComponent<Rigidbody>();

         }
    void FixedUpdate()
    {

        point1 = new Vector3(1.5f, transform.position.y, transform.position.z);
        point2 = new Vector3(-1.5f, transform.position.y, transform.position.z);
        if (PlayerState==InputPhase.LEFT)
        {
            onLeft();
        }
        else if(PlayerState==InputPhase.RIGHT)
        {
            OnRight();
        }else if(PlayerState==InputPhase.UP)
        {
            OnJump();
        }
        else if(PlayerState==InputPhase.DOWN)
        {
            
        }
        else if(PlayerState==InputPhase.RUN)
        {
            Debug.Log("RUNSTATE");
        }
        onMoveFarward();

    }
    public void OnJump()
    {
        if (rb.velocity.y < MaxupVelocity)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            PlayerState = InputPhase.RUN;
        }
    }
    public void OnRight()
    {

         if(Vector3.Distance( point1,transform.position)>0.1f)
        {
            transform.position = Vector3.Slerp(transform.position, point1,  moveSpeed);
        }
        else
        {
            PlayerState = InputPhase.RUN;
        }
    }
    public void onLeft()
    {
        if (Vector3.Distance(point2, transform.position) > 0.1f)
        {
            transform.position = Vector3.Slerp(transform.position, point2,   moveSpeed);
        }
        else
        {
            PlayerState = InputPhase.RUN;
        }

    }
    public void onMoveFarward()
    {
        transform.Translate(transform.forward*Time.deltaTime*farwardmovespeed, Space.Self);
    }
    public void OnShoot()
    {
        Instantiate(Bullet, shootPosition.position, Quaternion.identity);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("NotMovble")|| collision.gameObject.CompareTag("MovableObstcle"))
        {

            manager.loadGameOver();
            gameObject.GetComponent<Player>().enabled = false;


        }
    }

}
