using UnityEngine;

/////////////////////////////////////////////////////////////////////////////////////////
///
/// Class: UIWindow
/// Author: Dominic Fournier (dominicfournier@outlook.com)
/// Creation Date: 2019-01-12
/// 
/// Generic (*1): Yes
/// Package: None
/// 
/// Specifications:
///     - Expects a window structure where the title bar and content are independent
///       (no child / parent relation);
/// 
/// Known Issues: None.
/// 
/// *1: Generic classes can be exported and used in other project. They are not dependant
///     to project specific code.
/// 
/// <summary>
///     Class containing common actions for window type UI. Windows can often be
///     closed, minimized, etc.
/// </summary>
/// 
/// © Copyright 2018-2019 Solbogre Inc. - All Rights Reserved
///
/////////////////////////////////////////////////////////////////////////////////////////
public class UIWindow : MonoBehaviour {

    /// <summary>
    /// Destroys specified GameObject.
    /// </summary>
    /// <param name="window"></param>
    public void closeWindow(GameObject window) {
        Destroy(window);
    }

    /// <summary>
    /// Toggles the active state of the specified GameObject.
    /// </summary>
    /// <param name="content"></param>
    public void toggleWindowContent(GameObject content) {
        content.SetActive(!content.activeSelf);
    }

    /// <summary>
    /// Flips the given UI vertically (negative Y scale).
    /// </summary>
    public void flipUIVertically(RectTransform rect) {
        rect.localScale = new Vector3(rect.localScale.x, -rect.localScale.y, rect.localScale.z);
    }
}
