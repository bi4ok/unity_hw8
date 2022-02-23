using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayRace : MonoBehaviour
{
    public Transform[] listOfRunners;
    private Transform target;
    private Transform currentRunner;
    private int currentTargetIndex;
    private readonly float minDistance = 1;
    private readonly float speed = 5;
    private readonly bool go = true;

    private void Start()
    {
        target = listOfRunners[0];
        ChangeRunner();
    }

    private void Update()
    {

        if (go)
        {
            currentRunner.position = Vector3.MoveTowards(currentRunner.position, target.position, Time.deltaTime * speed);
        }

        if (Vector3.Distance(currentRunner.position, target.position) <= minDistance)
        {
            ChangeRunner();
        }
    }

    private void ChangeRunner()
    {
        currentRunner = target;
        currentTargetIndex = (currentTargetIndex + 1) % listOfRunners.Length;
        target = listOfRunners[currentTargetIndex];
        currentRunner.LookAt(target);
    }
}
