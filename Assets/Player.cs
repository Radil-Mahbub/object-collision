using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 10;
    Rigidbody myrigidbody;
    Vector3 velocity;
    int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody.GetComponent <Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * speed;
        Vector3 moveAmount = velocity * Time.deltaTime;

        //transform.position += moveAmount;
        transform.Translate(moveAmount);
   
    }

    private void FixedUpdate()
    {
        myrigidbody.position += velocity * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider triggerCollider)
    {
       if (triggerCollider.tag == "Coin")
        {
            Destroy(triggerCollider.gameObject);
            coinCount++ ;
        }
    }
}
