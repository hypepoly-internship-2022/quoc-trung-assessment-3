
using UnityEngine;
using UnityEngine.Pool;


public class RotateQuad : MonoBehaviour
{
    private Camera myCamera;
    private Vector3 screenPos;
    private float angleObj;
    private Collider2D col;

    private void Awake()
    {
        myCamera = Camera.main;
    }

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Object")
                {
                    RotateObject();
                }
            }
        }


    }
    void RotateObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (col == Physics2D.OverlapPoint(Input.mousePosition))
            {
                screenPos = myCamera.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleObj = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (col == Physics2D.OverlapPoint(Input.mousePosition))
            {
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle + angleObj);
            }
        }
    }

}
