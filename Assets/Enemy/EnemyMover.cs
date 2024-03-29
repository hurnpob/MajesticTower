using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField][Range(0f, 5f)] float speed = 1f;
    //[SerializeField] float waitTime = 1f;

    void Start()
    {
        StartCoroutine(FollowPath());

        //GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        //path.Clear();

        FindPath();
        ReturnToStart();

    }

    private void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<WayPoint>());
        }

    }

    IEnumerator FollowPath()
    {
        foreach (WayPoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }
        //Destroy(gameObject);

    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

}
