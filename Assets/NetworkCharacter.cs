using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

    Vector3 realPosition = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;
    private int myCount = 0;
    private int combineCount = 0;
    public AudioClip BiteSound;
    private GUIText countText;

    void UpdateCount()
    {
        //countText.text = string.Format("My Count: {0}\nPlayer 2: {1}", myCount, combineCount);
        countText.text = string.Format("My Count: {0}", myCount);
    }

	void Start () {
        countText = GameObject.Find("Count Text").GetComponent<GUIText>();

	}
	
	void Update () {
        if (photonView.isMine)
        {
            if (myCount >= 6)
            {
                //
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
        }

        UpdateCount();
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(myCount);
        }
        else
        {
            realPosition = (Vector3) stream.ReceiveNext();
            realRotation = (Quaternion)stream.ReceiveNext();
            combineCount = System.Convert.ToInt32(stream.ReceiveNext());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            
            other.gameObject.SetActive(false);
            audio.Play();
            myCount++;
        }
    }
}
