using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutingCode : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<RoutingCode> moveableObjects = new List<RoutingCode>();
    public float speed = 5f;
    private Vector3 target;
    private bool selected;
    
    void Start()
    {
        moveableObjects.Add(this);
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && selected)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    
    private void OnMouseDown()
    {
        selected = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    
        foreach(RoutingCode obj in moveableObjects)
        {
            if (obj != this)
            {
                obj.selected = false;
                obj.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
    
}
