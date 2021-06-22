using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplePoint : MonoBehaviour
{
    public Transform[] points;
    public GameObject Knight;
    public int destPoint;
    public float allowence = 0.1f;

    // Use this for initialization
    void Start()
    {
        // Set first target
        UpdateTarget();
    }

    // Update is called once per frame
    void Update()
    {
        // Update this position
        Vector3 thisPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);


        // Distance between current position and next position < alloence
        if (Vector3.Distance(thisPos, points[destPoint].position) < allowence)
        {
            UpdateTarget();
        }
        
        //transform.position = Vector3.Lerp(transform.position, points[destPoint].position, 1.5f* Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, points[destPoint].position, 3.5f * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        this.Knight.transform.parent = transform;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        this.Knight.transform.parent = null;
    }
    void UpdateTarget()
    {
        if (points.Length == 0)
        {
            return;
        }
        transform.position = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;

    }

}
