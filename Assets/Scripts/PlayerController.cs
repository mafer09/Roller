using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public GUIText countText;
    // public GUIText winText;
    private int count;

    void Start()
    {
       count = 0;
       //  winText.text = "";
       countText = GameObject.Find("Count Text").GetComponent<GUIText>();
       SetCountText();
    }
    void FixedUpdate() //Before performing any physics calculations
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //input recorders
        float moveVertical = Input.GetAxis("Vertical");     // input recorders

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce(movement * speed * Time.deltaTime);      //Time.deltaTime makes the input smooth and frame independent
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = string.Format("My Score: {0}\nOther Player: {1}", 
            count, PlayerPrefs.GetInt("OtherPlayerScore"));
    }
}
