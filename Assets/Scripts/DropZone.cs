using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    // Info about bounds
    private float leftEdge;
    private float rightEdge;
    private float topEdge;
    private float bottomEdge;

    // Start is called before the first frame update
    void Start()
    {
        Rect myRect = GetComponent<RectTransform>().rect;
        leftEdge = myRect.xMin;
        rightEdge = myRect.xMax;
        topEdge = myRect.yMin;
        bottomEdge = myRect.yMax;
        // todo: screen point instead of relative point?
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log ("dropped into " + gameObject.name);
        // Get the draggable that was dropped into it
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            d.parentToSnapTo = this.transform;
            d.pointToSnapTo = d.transform.position;
        }
    }

    // Method for seeing if a point is contained within this drop zone
    public bool ContainsPoint(Vector2 position)
    {
         return (position.x > leftEdge && position.x < rightEdge && position.y > topEdge && position.y < bottomEdge);
    }

    public void DebugMe()
    {
        Debug.Log("left edge: " + leftEdge);
        Debug.Log("right edge: " + rightEdge);
        Debug.Log("top edge: " + topEdge);
        Debug.Log("bot edge: " + bottomEdge);
    }
}
