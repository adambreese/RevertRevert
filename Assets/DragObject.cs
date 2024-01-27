using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private bool dragging = false;
    private float distance;
    Color originalColor;
    Color mouseDownColor;
    private Vector3 originalTransform;

    [SerializeField]
    protected float timeout = 0f;
    void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
        mouseDownColor = Color.Lerp(originalColor, Color.white, 0.3f);
        //RectTransform parentRectTransform = transform.parent as RectTransform;
        //originalTransform = parentRectTransform.anchoredPosition; 
        //RectTransform rectTransform = GetComponent<RectTransform>();

        //// Get the bottom-left corner of the RectTransform in world space
        //Vector3[] worldCorners = new Vector3[4];
        //rectTransform.GetWorldCorners(worldCorners);

        //// Calculate the center position
        //Vector3 centerPosition = (worldCorners[0] + worldCorners[2]) / 2;

        //Debug.Log(centerPosition);

    }

    void OnMouseDown()
    {
        GetComponent<MeshRenderer>().material.color = mouseDownColor;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;

    }

     void OnMouseUp()
    {
        GetComponent<MeshRenderer>().material.color = originalColor;
        dragging = false;
        transform.parent = null;
        enabled = false;
        GameObject newInstance = Instantiate(gameObject, Vector3.zero, Quaternion.identity);
        newInstance.transform.SetParent(transform.parent, false);
        newInstance.GetComponent<DragObject>().enabled = true;
        Timeout();
    }
    async void Timeout()
    {
        if (timeout>0)
        {
            await Task.Delay(Mathf.RoundToInt(1000*timeout));
            gameObject.SetActive(false);
        }
    }


    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, rayPoint.y, transform.position.z);
        }
    }
}
