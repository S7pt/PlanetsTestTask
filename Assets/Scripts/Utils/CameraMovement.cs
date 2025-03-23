using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float navigationSpeed = 2.4f;
    [SerializeField] private float shiftMultiplier = 2f;
    [SerializeField] private float sensitivity = 1.0f;

    private Camera cam;
    private Vector3 anchorPoint;
    private Quaternion anchorRot;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 move = Vector3.zero;
            float speed = navigationSpeed * (Input.GetKey(KeyCode.LeftShift) ? shiftMultiplier : 1f) * Time.deltaTime * 9.1f;
            move += Input.GetAxisRaw("Vertical") * Vector3.forward * speed;
            move += Input.GetAxisRaw("Horizontal") * Vector3.right * speed;
            if (Input.GetKey(KeyCode.E))
            {
                move += Vector3.up * speed;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                move -= Vector3.up * speed;
            }
            transform.Translate(move);
        }

        if (Input.GetMouseButtonDown(1))
        {
            anchorPoint = new Vector3(Input.mousePosition.y, -Input.mousePosition.x);
            anchorRot = transform.rotation;
        }
        if (Input.GetMouseButton(1))
        {
            Quaternion rot = anchorRot;

            Vector3 dif = anchorPoint - new Vector3(Input.mousePosition.y, -Input.mousePosition.x);
            rot.eulerAngles += dif * sensitivity;
            transform.rotation = rot;
        }
    }
}