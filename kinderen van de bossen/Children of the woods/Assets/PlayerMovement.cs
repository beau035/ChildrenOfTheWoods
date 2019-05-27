using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody rb;
	public float forward = 50f;
	public float backward = 25f;
    public float rotation = 100f;
    public float jump = 10f;
    public bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(transform.position, -transform.up, Time.deltaTime * rotation);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * backward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotation);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) 
        {
            rb.AddForce(transform.up * jump);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            if (Vector3.Distance(transform.position, hit.point) <= 1)
            { isGrounded = true; }
            else { isGrounded = false; }
        }
    }
}

