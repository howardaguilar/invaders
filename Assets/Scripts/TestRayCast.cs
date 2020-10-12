using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Debug.DrawRay(start: Ray.origin, end: Ray.direction, Color.red); // Didn't work for me
            Debug.DrawLine(start: ray.origin, end: ray.origin + ray.direction * 1000f, Color.red);
            RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit2D.collider != null)
            {
                Debug.Log(message: "I hit: " + hit2D.collider.name);
            } else
            {
                Debug.Log("hit nothing");
            }
            //Debug.Break(); // for none working drawray line
        }
    }
}
