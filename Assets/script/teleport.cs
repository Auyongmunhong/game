using UnityEngine;

public class teleport : MonoBehaviour
{

public GameObject otherdoor;
public bool isReady;


    void Start(){
      isReady = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(isReady)
        {
            if (col.gameObject.tag == "Player")
            {
              otherdoor.GetComponent<teleport>().isReady = false;
              col.transform.position = otherdoor.transform.position;
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
          isReady = true;
        }
    }

}
