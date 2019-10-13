using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    public int playerSpeed = 3000;
    public Transform cameraTransform;
    public int jumpForce = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void FixedUpdate()
    {
        //cameraTransform.rotation = new Quaternion(Input.GetAxis("x"), Input.GetAxis("y"), Input.GetAxis("z"),0f);
        //rigidBody.AddForce(0, 0, 0);
        if (Input.GetKey("w"))
        {
            rigidBody.AddForce(0, 0, playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rigidBody.AddForce(-playerSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            rigidBody.AddForce(0, 0, -playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rigidBody.AddForce(playerSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d") )
        {
            rigidBody.AddForce(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space) && (transform.position.y < 12))
        {
            rigidBody.useGravity = false;
            rigidBody.AddForce(0, jumpForce *Time.deltaTime, 0);
            rigidBody.useGravity = true;
        }

        if(transform.position.y < -1)
        {
            FindObjectOfType<gameManager>().EndGame();
        }
    }
}
