using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3.5f;
    public float jumpHeight = 30f;

    private Rigidbody rb;
    public GameObject groundCheck;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        //Move
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        Vector3 moveDir = vert * transform.forward + hor * transform.right;

        rb.MovePosition(transform.position + moveDir.normalized * Time.deltaTime * moveSpeed);

        //Jump
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.transform.position, -Vector3.up, out hit, 1f))
        {

            if (Input.GetButtonDown("Jump"))
            {

                rb.AddForce(Vector3.up * jumpHeight);
            }
        }
    }
}