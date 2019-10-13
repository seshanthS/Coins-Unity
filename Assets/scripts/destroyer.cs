using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    public float lifeTime = 60f;
    public float heightToDestryObstacle = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }if(lifeTime <= 0)
        {
            this.gameObject.GetComponent("RigidBody");
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().AddForce(0, 5000, 0);
            
            lifeTime = 60f;
        }

        if(transform.position.y > heightToDestryObstacle)
        {
            Destroy(this.gameObject);
        }
    }
}
