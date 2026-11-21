using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float rayLength = 0.5f;
    public float rayOriginOffset;
    public bool isGrounded;
    private Rigidbody rb;
    private Vector3 dir;
    private Vector3 rayOriginPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rayOriginPos = new Vector3(0, rayOriginOffset, 0);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position + rayOriginPos, -transform.up, rayLength);
        // Raycast hit control
        if (isGrounded)
        {
            Debug.DrawRay(transform.position + rayOriginPos, -transform.up * rayLength, Color.green);

            dir = IS_Manager.instance.inputs.Player.Move.ReadValue<Vector2>();
            dir.z = dir.y;
            dir.y = 0;

            dir = transform.TransformDirection(dir);


            if (IS_Manager.instance.inputs.Player.Jump.WasPressedThisFrame())
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
        else
        {
            Debug.DrawRay(transform.position + new Vector3(0, rayOriginOffset, 0), -transform.up * rayLength, Color.red);
        }

        transform.position += dir * speed * Time.deltaTime;
    }
}
