using System.Collections.Generic;
using UnityEngine;

public class PopupPlatformSynchronizer : MonoBehaviour
{
    [SerializeField] private Transform _platformContainer;
    private List<Transform> _gameObjectList;

    private void Awake()
    {
        int childCount = _platformContainer.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            _gameObjectList.Add(_platformContainer.GetChild(i));
        }
    }

    private void LateUpdate()
    {
        
    }
}
