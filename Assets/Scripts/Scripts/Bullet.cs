using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float Force=50f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        ApplyForce();
    }
    public void ApplyForce()
    {
        rb.AddForce(transform.forward*Force, ForceMode.Impulse);  
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("MovableObstcle"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("NotMovble"))
        {
            Destroy(gameObject);
        }
    }

      

    

}
