using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamFollow : MonoBehaviour
{
    //third person camera source: https://www.youtube.com/watch?v=Ta7v27yySKs

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;


    GlobalController cont;

    public float distance = 0.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;

    private Camera cam;

    Vector2 movedata;

    bool onController = true;

    void Awake()
    {
        cont = GameObject.FindGameObjectWithTag("GlobalController").GetComponent<GlobalController>();
    }

    void swapControl()
    {
        onController = !onController;
        Debug.Log(onController);
    }

    // Start is called before the first frame update
    private void Start()
    {
         //camPos = transform.position;
         cam = Camera.main;
    }

    private void Update()
    {
        cont.keys.Game.Cam.performed += ctx => movedata = ctx.ReadValue<Vector2>();
        cont.keys.Game.Cam.canceled += ctx => movedata = Vector2.zero;

        cont.controller.Game.Cam.performed += ctx => movedata = ctx.ReadValue<Vector2>();
        cont.controller.Game.Cam.canceled += ctx => movedata = Vector2.zero;

        Vector2 m = new Vector2(movedata.x, movedata.y) * 100 * Time.deltaTime;
        currentX = m.x;
        currentY = m.y;

        transform.Rotate(Vector3.up * currentX);
        cam.transform.Rotate(Vector3.left * currentY);
    }

    // Update is called once per frame
    private void LateUpdate()
    {

    }
}
