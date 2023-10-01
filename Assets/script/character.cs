using JetBrains.Annotations;
using UnityEngine;

public class character : MonoBehaviour
{
   public Rigidbody2D _rb;
   public int moveSpeed;

   public int jumpSpeed;
   public Animator _anim;

   Vector2 myScale;
   float scaleX;

   bool isJumping;

   void Start(){
        myScale = transform. localScale;
        scaleX = myScale.x;
   }

    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            myScale.x = scaleX;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            myScale.x = -scaleX;
        }
        transform. localScale = myScale;

        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed,_rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            isJumping = true;

            _rb.velocity = new Vector2
            (_rb.velocity.x, jumpSpeed);

            _anim.SetBool("jump", true);
        }

        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            _anim.SetBool("walk", true);
        }
        else
        {
            _anim.SetBool("walk", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag =="platform")
        {
            _anim.SetBool("jump", false);
            isJumping = false;
        }
        if(col.gameObject.name == "Box2d")
        {
            col.gameObject.GetComponent<Animator>().SetBool("IsOpened", true);
        }

    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.name == "Box2d")
        {

        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.name == "Box2d")
        {
            
        }
    }
}
