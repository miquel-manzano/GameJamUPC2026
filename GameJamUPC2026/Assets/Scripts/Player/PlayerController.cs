using System;
using static InputSystem_Actions;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MoveBehaviour))]
[RequireComponent(typeof(AnimationBehaviour))]

public class PlayerController : MonoBehaviour, IPlayerActions
{
    [SerializeField] private float interactionRange = 10f;
    [SerializeField] private LayerMask interactionLayer;
    private InputSystem_Actions _inputActions;
    private MoveBehaviour _mb;
    private AnimationBehaviour _ab;

    private Vector2 _moveInput;

    private void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();
        _ab = GetComponent<AnimationBehaviour>();
        
        _inputActions = new InputSystem_Actions();
        _inputActions.Player.SetCallbacks(this);
    }
    
    private void Start() => _inputActions.Enable();

    private void OnEnable() => _inputActions.Enable();

    private void OnDisable() => _inputActions.Disable();
    
    private void FixedUpdate() => _mb.MoveCharacter(_moveInput);
    
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
        throw new NotImplementedException();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
