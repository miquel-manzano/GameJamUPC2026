using System;
using static InputSystem_Actions;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MoveBehaviour))]
[RequireComponent(typeof(AnimationBehaviour))]
[RequireComponent(typeof(DashBehaviour))]


public class PlayerController : MonoBehaviour, IPlayerActions
{
    [SerializeField] private float interactionRange = 10f;
    [SerializeField] private LayerMask interactionLayer;
    private InputSystem_Actions _inputActions;
    private MoveBehaviour _mb;
    private AnimationBehaviour _ab;
    private DashBehaviour _dashBehaviour;

    private Vector2 _moveInput;

    private void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();
        _ab = GetComponent<AnimationBehaviour>();
        //Mecanicas
        _dashBehaviour = GetComponent<DashBehaviour>();

        _inputActions = new InputSystem_Actions();
        _inputActions.Player.SetCallbacks(this);
    }

    private void Start() => _inputActions.Enable();

    private void OnEnable() => _inputActions.Enable();

    private void OnDisable() => _inputActions.Disable();

    private void FixedUpdate() => _mb.MoveCharacter(_moveInput);
    private void Update()
    {
        _ab.SetHorizontalSpeed(Mathf.Abs(_mb.GetHorizontalVelocity()));
        _ab.SetVerticalSpeed(_mb.GetVerticalVelocity());
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _moveInput = new Vector2(context.ReadValue<Vector2>().x, 0f);
            _mb.Flip(_moveInput.x);
        }
        else if (context.canceled)
        {
            _moveInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {

    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        var hit = Physics2D.Raycast(transform.position, transform.right);
        if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) _mb.Jump();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        _dashBehaviour.Dash(_moveInput);
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}