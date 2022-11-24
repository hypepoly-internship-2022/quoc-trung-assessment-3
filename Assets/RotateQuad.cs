
using UnityEngine;


public class RotateQuad : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 objectPos;
    private float angle;
    public Camera mainCamera;

    void Update()
    {
        mousePos = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Object")
                {
                    Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
                    objectPos = Camera.main.WorldToScreenPoint(transform.position);
                    mousePos.x = mousePos.x - objectPos.x;
                    mousePos.y = mousePos.y - objectPos.y;
                    angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                }
            }
        }    
    }

}
