using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float moveSpeed;
    public float moveRange;

    private Vector3 oldPosition;
    private GameObject obj;
    // Use this for initialization
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;
        moveSpeed = 5;
        moveRange = 20.4f;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, transform.position.y, 0));

        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRange)
        {
            obj.transform.position = oldPosition;
        }
    }
}
