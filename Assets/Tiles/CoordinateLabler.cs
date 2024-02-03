using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[ExecuteAlways]
public class CoordinateLabler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    WayPoint waypoints;
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor= Color.grey;

    private void Awake()
    {
        waypoints = GetComponentInParent <WayPoint>();

        label = GetComponent<TextMeshPro>();
        label.enabled= false;

        DisplayCoordinates();

    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            NewMethod();
        }

        CoordinateColor();
        TiggleLabel();
    }

    private void TiggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void CoordinateColor()
    {
        if (waypoints.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    private void NewMethod()
    {
        transform.parent.name = coordinates.ToString();
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 10);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 10);
       
            label.text = $"{coordinates.x},{coordinates.y}";
        
    }
}
