using UnityEngine;

public class MyJiggle : MonoBehaviour
{
    // Target and dynamic positions
    Vector3 targetPos = new Vector3();
    Vector3 dynamicPos = new Vector3();

    // Dynamics settings
    public float bStiffness = 5;
    public float bMass = 5;
    public float bDamping = 10;
    //public float bGravity = 0.75f;

    // Dynamics variables
    Vector3 force = new Vector3();
    Vector3 acc = new Vector3();
    Vector3 vel = new Vector3();

    Vector3 Startlocalpos;

    void Awake()
    {
        dynamicPos = transform.position;
        Startlocalpos = this.transform.localPosition;
    }
    
    private void Update()
    {
        // Calculate target position
        targetPos = this.transform.parent.TransformPoint(Startlocalpos);
    }

    void LateUpdate()
    {
        // Calculate force, acceleration, and velocity per X, Y and Z
        force.x = (targetPos.x - dynamicPos.x) * bStiffness * Time.deltaTime;
        acc.x = force.x / bMass;
        vel.x += acc.x * (10 - bDamping) * Time.deltaTime;

        force.y = (targetPos.y - dynamicPos.y) * bStiffness * Time.deltaTime;
        //force.y -= bGravity / 10; // Add some gravity
        acc.y = force.y / bMass;
        vel.y += acc.y * (100 - bDamping) * Time.deltaTime;

        force.z = (targetPos.z - dynamicPos.z) * bStiffness * Time.deltaTime;
        acc.z = force.z / bMass;
        vel.z += acc.z * (100 - bDamping) * Time.deltaTime;

        // Update dynamic postion
        dynamicPos += vel + force;
        this.transform.position = dynamicPos;
    }
}
