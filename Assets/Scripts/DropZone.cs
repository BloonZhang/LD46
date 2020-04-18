using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{

    // Public variables
    public Token.TokenType[] acceptableTokens;

    // Info about bounds
    /*
    private float leftEdge;
    private float rightEdge;
    private float topEdge;
    private float bottomEdge;
    */

    // Start is called before the first frame update
    void Start()
    {
        /*
        Rect myRect = GetComponent<RectTransform>().rect;
        leftEdge = myRect.xMin;
        rightEdge = myRect.xMax;
        topEdge = myRect.yMin;
        bottomEdge = myRect.yMax;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log ("dropped into " + gameObject.name);
        // Get the draggable that was dropped into it
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        Token t = eventData.pointerDrag.GetComponent<Token>();
        if (d != null && t != null) 
        {
            if (IsAcceptableToken(t.myTokenType))
            {
                d.parentToSnapTo = this.transform;
                d.pointToSnapTo = d.transform.position;
            }
        }
    }

    // Helper methods
    // Helper method for seeing if a point is contained within this drop zone
    public bool ContainsPoint(Vector2 position)
    {
         //return (position.x > leftEdge && position.x < rightEdge && position.y > topEdge && position.y < bottomEdge);
        return GetComponent<BoxCollider2D>().bounds.Contains(position);
    }
    // Helper method for determining if a token type is valid
    public bool IsAcceptableToken(Token.TokenType token)
    {
        for (int i = 0; i < acceptableTokens.Length; ++i)
        {
            if (acceptableTokens[i] == token) {return true;}
        }
        return false;
    }

}
