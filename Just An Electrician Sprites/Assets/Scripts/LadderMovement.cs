using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;

    public Animator animator;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {

        vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Vertical", vertical);


        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
            animator.SetBool("isClimbing", true);
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            animator.SetBool("isLadder", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            animator.SetBool("isLadder", false);
            isClimbing = false;
            animator.SetBool("isClimbing", false);
        }
    }
}