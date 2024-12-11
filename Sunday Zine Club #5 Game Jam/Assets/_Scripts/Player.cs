using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Rigidbody2D rb;
    private float inputX;
    private float inputY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        rb.linearVelocityX = inputX * movementSpeed;
        rb.linearVelocityY = inputY * movementSpeed;
    }
}
