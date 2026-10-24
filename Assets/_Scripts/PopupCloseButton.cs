using UnityEngine;

public class PopupCloseButton : MonoBehaviour
{
    private PopupPlatform _popupParent;

    private void Start()
    {
        _popupParent = transform.parent.GetComponent<PopupPlatform>();
        if (_popupParent == null )
        {
            Debug.LogError("Could not get parent PopupPlatform", this);
        }
    }

    public void Close()
    {
        _popupParent.NotifyClose();
    }
}
