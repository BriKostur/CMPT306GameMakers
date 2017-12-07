using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    public LineRenderer line;
    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;
    //How fast the rope slowly closes down
    public float step = 0.02f;

    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    // Use this for initialization
    void Start()
    {
        //sets the joint to the player and does not disables until player hits an object with grapplinghook.
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Allows the player to slowlypull towards the hook.
        if (joint.distance > .5f)
            joint.distance -= step;
        else
        {
            line.sortingOrder = 1;
            line.enabled = false;
            joint.enabled = false;

        }

        //If Mouse0 is clicked sling out the grapple
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            // hit starts at the position of our oldman , direction is the target - the position of out mouse ,
            // the max distance it can go, a mask to allow certain collisions(type of material or prefab).
            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);

            //Ive placed a check to check for now to check if the grappling hook is being collided 
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                //if enters this loop join is enabled and connects to RigidBody2D
                joint.enabled = true;
                //Allows the player to conect to the object using the shortest distance of that object
                // and not its center.
                //Distance of the connectPoint is equal to old man position -hit pointjoint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                Vector2 connectPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                connectPoint.x = connectPoint.x / hit.collider.transform.localScale.x;
                connectPoint.y = connectPoint.y / hit.collider.transform.localScale.y;
                Debug.Log(connectPoint);
                joint.connectedAnchor = connectPoint;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                //joint.connectedAnchor = hit.point - new Vector2(hit.collider.transform.position.x,hit.collider.transform.position.y);
                joint.distance = Vector2.Distance(transform.position, hit.point);
                //Line rendering
                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
                //line.GetComponent<RopeOperation>().grabPos = hit.point;
            }
        }

        line.SetPosition(1, joint.connectedBody.transform.TransformPoint(joint.connectedAnchor));

         if (Input.GetKey(KeyCode.Mouse0))
         {

            line.SetPosition(0, transform.position);
         }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            joint.enabled = false;
            line.enabled = false;
        }
    }

}

    

