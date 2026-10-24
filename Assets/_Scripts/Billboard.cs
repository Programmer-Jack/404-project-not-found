using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _mainCam;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void LateUpdate()
    {
        transform.LookAt(_mainCam.transform.position);
    }
}
