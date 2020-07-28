using UnityEngine;

public class MyJiggle : MonoBehaviour
{
    // Target and dynamic positions
    Vector3 targetPos = new Vector3();
    Vector3 dynamicPos = new Vector3();

    // Dynamics settings
    public float bStiffness = 0.1f;
    public float bMass = 0.9f;
    public float bDamping = 0.75f;
    public float bGravity = 0.75f;

    // Dynamics variables
    Vector3 force = new Vector3();
    Vector3 acc = new Vector3();
    Vector3 vel = new Vector3();

    Vector3 Startlocalpos;

    void Awake()
    {
        /*QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;*/
        dynamicPos = transform.position;
        Startlocalpos = this.transform.localPosition;
    }

    void LateUpdate()
    {
        // Calculate target position
        targetPos = this.transform.parent.TransformPoint(Startlocalpos);

        // Calculate force, acceleration, and velocity per X, Y and Z
        force.x = (targetPos.x - dynamicPos.x) * bStiffness;
        acc.x = force.x / bMass;
        vel.x += acc.x * (1 - bDamping);

        force.y = (targetPos.y - dynamicPos.y) * bStiffness;
        //force.y -= bGravity / 10; // Add some gravity
        acc.y = force.y / bMass;
        vel.y += acc.y * (1 - bDamping);

        force.z = (targetPos.z - dynamicPos.z) * bStiffness;
        acc.z = force.z / bMass;
        vel.z += acc.z * (1 - bDamping);

        // Update dynamic postion
        dynamicPos += vel + force;
        this.transform.position = dynamicPos;
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.parent.TransformPoint(Startlocalpos), 0.01f);
    }

}
