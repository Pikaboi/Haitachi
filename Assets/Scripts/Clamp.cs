using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    private Vector2 bounds;

    // Start is called before the first frame update
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Camera.main.transform.position.z, Screen.height));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, bounds.x, bounds.x * -1);
        viewPos.z = Mathf.Clamp(viewPos.z, bounds.y, bounds.y * -1);
        transform.position = viewPos;
    }
}
