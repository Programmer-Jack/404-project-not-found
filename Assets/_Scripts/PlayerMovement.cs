using UnityEngine;
using UnityEngine.InputSystem;

// Example of using an InputActionMap named "Player" from a UnityEngine.MonoBehaviour implementing callback interface.
// Modded version of example class
public class PlayerMovement : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions _actions;                  // Source code representation of asset.
    private InputSystem_Actions.PlayerActions _player;     // Source code representation of action map.

    private Rigidbody _rb;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _jumpForce = 2f;

    [Header("Temp Debug")]
    [SerializeField] private bool _tempEnableSine = true;
    [SerializeField] private float _tempSineMotionPeriod = 3.0f;

    private void Awake()
    {
        _actions = new InputSystem_Actions();              // Create asset object.
        _player = _actions.Player;                      // Extract action map object.
        _player.AddCallbacks(this);                      // Register callback interface IPlayerActions.
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        _actions.Dispose();                              // Destroy asset object.
    }

    private void OnEnable()
    {
        _player.Enable();                                // Enable all actions within map.
    }

    private void OnDisable()
    {
        _player.Disable();                               // Disable all actions within map.
    }

    void InputSystem_Actions.IPlayerActions.OnCrouch(InputAction.CallbackContext ctx)
    {
        throw new System.NotImplementedException();
    }

    void InputSystem_Actions.IPlayerActions.OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            print("JUMP!!1!");
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        float speedMod = _tempEnableSine ? Mathf.Sin(Time.time * Mathf.PI / _tempSineMotionPeriod) : 1f;
        transform.Translate(new Vector3(_speed * speedMod, 0, 0) * Time.deltaTime);
    }
}