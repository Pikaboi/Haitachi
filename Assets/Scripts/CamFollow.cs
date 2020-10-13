using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamFollow : MonoBehaviour
{
    //third person camera source: https://www.youtube.com/watch?v=Ta7v27yySKs
    public GameObject player;

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    Xbox inputSys;

    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;

    private Camera cam;

    Vector2 movedata;

    void Awake()
    {
        inputSys = new Xbox();

        inputSys.Game.Cam.performed += ctx => movedata = ctx.ReadValue<Vector2>();
        inputSys.Game.Cam.canceled += ctx => movedata = Vector2.zero;
    }

    void OnEnable()
    {
        inputSys.Game.Enable();
    }

    void OnDisable()
    {
        inputSys.Game.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
         //camPos = transform.position;
         cam = Camera.main;
    }

    private void Update()
    {
        //currentX += Input.GetAxis("Mouse X");
        //currentY += Input.GetAxis("Mouse Y");
        Vector2 m = new Vector2(movedata.x, movedata.y) * 10 * Time.deltaTime;
        currentX += m.x;
        currentY += m.y;

        Quaternion playRot = Quaternion.Euler(0, currentX, 0);
        player.transform.rotation = playRot;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0,0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = player.transform.position + rotation * dir;
        transform.LookAt(player.transform.position);
    }
}
