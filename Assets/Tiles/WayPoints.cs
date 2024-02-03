using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    [SerializeField] GameObject TowerPrefab;

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Debug.Log(transform.name);
            Instantiate(TowerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
            
        }
    }
}
