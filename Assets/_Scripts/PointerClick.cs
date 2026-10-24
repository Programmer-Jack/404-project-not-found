using UnityEngine;
using UnityEngine.InputSystem;

// Example of using an InputActionMap named "Player" from a UnityEngine.MonoBehaviour implementing callback interface.
// Modded version of example class
public class PointerClick : MonoBehaviour, InputSystem_Actions.IPointerActions
{
    private InputSystem_Actions _actions;                  // Source code representation of asset.
    private InputSystem_Actions.PointerActions _pointer;     // Source code representation of action map.

    private readonly string _closeButtonTag = "CloseButton";
    private Camera _thisCamera;
    private Vector2 _screenspacePointerPos;

    private void Awake()
    {
        _actions = new InputSystem_Actions();              // Create asset object.
        _pointer = _actions.Pointer;                      // Extract action map object.
        _pointer.AddCallbacks(this);                      // Register callback interface IPlayerActions.
    }

    private void Start()
    {
        _thisCamera = GetComponent<Camera>();
    }

    private void OnDestroy()
    {
        _actions.Dispose();                              // Destroy asset object.
    }

    private void OnEnable()
    {
        _pointer.Enable();                                // Enable all actions within map.
    }

    private void OnDisable()
    {
        _pointer.Disable();                               // Disable all actions within map.
    }

    void InputSystem_Actions.IPointerActions.OnPoint(InputAction.CallbackContext context)
    {
        _screenspacePointerPos = context.ReadValue<Vector2>();
        print($"Screenspace pointer pos = {_screenspacePointerPos}");
    }

    void InputSystem_Actions.IPointerActions.OnWorldClick(InputAction.CallbackContext context)
    {
        Ray ray = _thisCamera.ScreenPointToRay(_screenspacePointerPos);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.transform.CompareTag(_closeButtonTag))
            {
                print($"Hit at {hit.point}");
                PopupCloseButton closeScript = hit.transform.GetComponent<PopupCloseButton>();
                closeScript.Close();
            }
        }
    }
}