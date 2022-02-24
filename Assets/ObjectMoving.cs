using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoving : MonoBehaviour
{
    [SerializeField] private Transform[] objectPoints;
    private Vector3 target;

    private int currentTargetIndex;
    private bool forward = true;

    private readonly float speed =5;
    private readonly bool go =true;

    private void Start()
    {
        currentTargetIndex = forward ? 0 : objectPoints.Length - 1;  // на случай если forward можно будет задать снаружи
        target = objectPoints[currentTargetIndex].position;
        transform.LookAt(target);
    }

    private void Update()
    {
        
        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        }

        if (transform.position == target)
        {
            GetNewTarget();
            transform.LookAt(target);
        }
    }

    private void GetNewTarget()
    {
        if ((forward && (currentTargetIndex == (objectPoints.Length - 1))) || (!forward && (currentTargetIndex == 0)))
        {
            forward = !forward;
        }
        currentTargetIndex = forward ? currentTargetIndex + 1: currentTargetIndex - 1;
        target = objectPoints[currentTargetIndex].position;
    }
}
