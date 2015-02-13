using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

    Vector3 realPosition = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;
    //public GUIText winText;
    private int realCount;

	void Start () {

        realCount = 0;
        PlayerPrefs.SetInt("OtherPlayerScore", realCount);
	}
	
	void Update () {
        if (photonView.isMine)
        {
            
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
            PlayerPrefs.SetInt("OtherPlayerScore", realCount);
        }
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(PlayerPrefs.GetInt("OtherPlayerCount"));
        }
        else
        {
            realPosition = (Vector3) stream.ReceiveNext();
            realRotation = (Quaternion)stream.ReceiveNext();
            realCount = System.Convert.ToInt32(stream.ReceiveNext());
        }
    }
}
