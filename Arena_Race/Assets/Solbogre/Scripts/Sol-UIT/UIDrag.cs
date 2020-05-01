using UnityEngine;
using UnityEngine.EventSystems;

/////////////////////////////////////////////////////////////////////////////////////////
///
/// Class: UIDrag
/// Author: Dominic Fournier (dominicfournier@outlook.com)
/// Creation Date: 2019-01-12
/// 
/// Generic (*1): Yes
/// Package: None
/// 
/// Specifications:
///     - Draggable UI element can be dragged outside the window view.
/// 
/// Known Issues: None.
/// 
/// *1: Generic classes can be exported and used in other project. They are not dependant
///     to project specific code.
/// 
/// <summary>
///     Class enabling dragging for UI element. This MonoBehaviour script should be
///     attached to the 'dragging anchor' (part of the UI that the user can click to
///     begin moving it) and assign a target RectTransform (draggable UI).
/// </summary>
/// 
/// © Copyright 2018-2019 Solbogre Inc. - All Rights Reserved
///
/////////////////////////////////////////////////////////////////////////////////////////
public class UIDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    // Having a reference to a drag target allows more flexibilty over drag control.
    public RectTransform dragTarget;

    private float startLeft;
    private float startRight;
    private float startTop;
    private float startBottom;

    private Vector2 mouseStartPosition;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 mouseOffset = new Vector2(mousePos.x - mouseStartPosition.x, mousePos.y - mouseStartPosition.y);

        dragTarget.offsetMax = new Vector2(-startRight + mouseOffset.x, -startTop + mouseOffset.y);
        dragTarget.offsetMin = new Vector2(startLeft + mouseOffset.x, startBottom + mouseOffset.y);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startLeft = dragTarget.offsetMin.x;
        startRight = -dragTarget.offsetMax.x;
        startTop = -dragTarget.offsetMax.y;
        startBottom = dragTarget.offsetMin.y;

        mouseStartPosition = Input.mousePosition;
        //Debug.Log(string.Format("MouseStart: {0}, Left: {1}, Right: {2}, Bottom: {3}, Top: {4}", mouseStartPosition,startLeft,startRight,startBottom,startTop));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 mouseOffset = new Vector2(mousePos.x - mouseStartPosition.x, mousePos.y - mouseStartPosition.y);

        dragTarget.offsetMax = new Vector2(-startRight + mouseOffset.x, -startTop + mouseOffset.y);
        dragTarget.offsetMin = new Vector2(startLeft + mouseOffset.x, startBottom + mouseOffset.y);
        //Debug.Log(string.Format("MouseFinal: {5} MouseOffset: {0}, Left: {1}, Right: {2}, Bottom: {3}, Top: {4}", mouseOffset, dragTarget.offsetMin.x, -dragTarget.offsetMax.x, dragTarget.offsetMin.y, -dragTarget.offsetMax.y, mousePos));
    }
}
