using UnityEngine;
using UnityEngine.InputSystem;

// Example of using an InputActionMap named "Player" from a UnityEngine.MonoBehaviour implementing callback interface.
// Modded version of example class
public class PlayerMovement : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions _actions;                  // Source code representation of asset.
    private InputSystem_Actions.PlayerActions _player;     // Source code representation of action map.

    private CharacterController _charController;
    private float _gravity = -9.81f;
    private Vector3 _velocity;
    private bool _queueJump = false;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _jumpHeight = 2f;

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
        _charController = GetComponent<CharacterController>();
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
        if (ctx.performed && _charController.isGrounded)
        {
            print("JUMP!!1!");
            _queueJump = true;
        }
    }

    private void Update()
    {
        if (_charController.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        if (_queueJump && _charController.isGrounded)
        {
            _queueJump = false;
            // Note: some of the jump & gravity mathematics are adapted from a Google AI Overview,
            // but it is a fairly standard movement solution
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        _velocity.y += _gravity * Time.deltaTime;
        float speedMod = _tempEnableSine ? Mathf.Sin(Time.time * Mathf.PI / _tempSineMotionPeriod) : 1f;

        Vector3 frameMotion = (_speed * speedMod * Vector3.right + _velocity) * Time.deltaTime;
        _charController.Move(frameMotion);
    }
}