using System;
using static InputSystem_Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Character, IPlayerActions
{
    [SerializeField] private float interactionRange = 10f;
    [SerializeField] private LayerMask interactionLayer;
    private InputSystem_Actions _inputActions;

    private Vector2 _moveInput;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _animationBehaviour = GetComponent<AnimationBehaviour>();
        _attackBehaviour = GetComponent<AttackBehaviour>();
        
        _inputActions = new InputSystem_Actions();
        _inputActions.Player.SetCallbacks(this);
    }
    
    private void Start() => _inputActions.Enable();

    private void OnEnable() => _inputActions.Enable();

    private void OnDisable() => _inputActions.Disable();
    
    private void FixedUpdate() => _moveBehaviour.MoveCharacter(_moveInput);
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _moveInput = new Vector2(context.ReadValue<Vector2>().x, 0f);
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
        if (context.performed) _attackBehaviour.PerformAttack();
    }
    
    public void OnAim(InputAction.CallbackContext context)
    {
        if (context.performed) _attackBehaviour.SetAiming(true);
        else if (context.canceled) _attackBehaviour.SetAiming(false);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        var hit = Physics2D.Raycast(transform.position, transform.right);
        
        if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
            interactable.Interact();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) _moveBehaviour.Jump();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
