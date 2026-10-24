using UnityEngine;

public class PopupPlatform : MonoBehaviour
{
    public void NotifyClose()
    {
        gameObject.SetActive(false);
    }
}
