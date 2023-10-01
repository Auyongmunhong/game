using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject myKey;
    public string[] dialog;
    public GameObject DialogBox;
    int count;
    GameObject player; 

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Dialog(){

        if(count >= dialog.Length)
        {
            count = 0;
            DialogBox.SetActive(false);
            player.GetComponent<character>().isChat = false;
            return;
        }

        player.GetComponent<character>().isChat = true;
        DialogBox.SetActive(true);
        DialogBox.GetComponentInChildren<TMP_Text>().text = dialog[count];
        count++;


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            myKey.SetActive(true);
            col.gameObject.GetComponent<character>().target = gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            myKey.SetActive(false);
            col.gameObject.GetComponent<character>().target = null;
        }
    }

    public void DoSomething()
    {
        //GetComponent<Animator>().SetBool("IsOpened", true);
        Dialog();
    }
}