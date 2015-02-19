using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public float speed;

    void Start()
    {
        
    }
    void FixedUpdate() //Before performing any physics calculations
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //input recorders
        float moveVertical = Input.GetAxis("Vertical");     // input recorders

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce(movement * speed * Time.deltaTime);      //Time.deltaTime makes the input smooth and frame independent
    }
}
