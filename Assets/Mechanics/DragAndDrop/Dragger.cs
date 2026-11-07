using UnityEngine;

public class Dragger : MonoBehaviour
{
    public float _speed = 10f;
    private Vector3 _dragOffset;
    private Camera _cam;

    void Awake()
    {
        _cam = Camera.main;
    }

    void OnMouseDown()
    {
        // Calculate the offset between the object's position and the mouse position when the drag starts
        _dragOffset = transform.position - GetMousePos();
    }

    void OnMouseDrag()
    {
        // If you want to instantly move the object to the mouse position with an offset, you can use the following line instead:
        //transform.position = GetMousePos() + _dragOffset;

        // Smoothly move the object towards the mouse position with an offset
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
    }

    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
