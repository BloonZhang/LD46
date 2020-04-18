using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    // public variables
    public Vector2 pointToSnapTo;
    public Transform parentToSnapTo;

    // Helper variables
    private Vector2 dragPositionOffset;
    //private Vector2 initialPosition;
    //private Transform initialParent;
    //private DropZone initialDropZone;


    public void OnBeginDrag(PointerEventData eventData) {
        //Debug.Log("OnBeginDrag");
        // Position to snap back to if drop fails
        pointToSnapTo = this.transform.position;
        // DropZone that token currently resides in
        //initialDropZone = this.transform.parent.GetComponent<DropZone>();
        // Get offsett between transform and mouse position
        dragPositionOffset = (Vector2)eventData.position - (Vector2)this.transform.position;
        // Turn off raycasts
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        // Get initial parent and move upwards in heirarchy
        parentToSnapTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        Vector2 positionToMoveTo = eventData.position - dragPositionOffset;
        this.transform.position = positionToMoveTo;
    }

    public void OnEndDrag(PointerEventData eventData) {
        //Debug.Log("OnEndDrag");
        // Turn raycasts back on
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        //Debug.Log(parentToSnapTo.GetComponent<DropZone>().ContainsPoint(this.transform.position));
        //Debug.Log("this tranform position is: " + this.transform.position);
        //parentToSnapTo.GetComponent<DropZone>().DebugMe();
        this.transform.SetParent(parentToSnapTo);
        this.transform.position = pointToSnapTo;
    }
}
