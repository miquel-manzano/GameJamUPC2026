using static InputSystem_Actions;
using UnityEngine.InputSystem;
using UnityEngine;
using System;
using Unity.VisualScripting;

[RequireComponent(typeof(MoveBehaviour))]
[RequireComponent(typeof(AnimationBehaviour))]
[RequireComponent(typeof(DashBehaviour))]
[RequireComponent(typeof(AttackBehaviour))]
public class PlayerController : MonoBehaviour, IPlayerActions
{
    [SerializeField] private float interactionRange = 10f;
    [SerializeField] private LayerMask interactionLayer;
    
    //Behaviours
    private MoveBehaviour _mb;
    private AnimationBehaviour _ab;
    private AttackBehaviour _attackBehaviour;
    private DashBehaviour _dashBehaviour;

    private InputSystem_Actions _inputActions;
    private Vector2 _moveInput;

    private void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();
        _ab = GetComponent<AnimationBehaviour>();
        
        //Mecànicas
        _dashBehaviour = GetComponent<DashBehaviour>();
        _attackBehaviour = GetComponent<AttackBehaviour>();

        _inputActions = new InputSystem_Actions();
        _inputActions.Player.SetCallbacks(this);
    }

    private void Start() => _inputActions.Enable();

    private void OnEnable() => _inputActions.Enable();

    private void OnDisable() => _inputActions.Disable();

    private void FixedUpdate() => _mb.MoveCharacter(_moveInput);
    private void Update()
    {
        var facingDirection = Mathf.Sign(transform.localScale.x);
        Debug.DrawRay(transform.position, transform.right * (facingDirection * interactionRange), Color.red);
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
        if (context.performed) _attackBehaviour.OnAttack();
    }

    public void OnInteract(InputAction.CallbackContext context)
    { 
        var facingDirection = Mathf.Sign(transform.localScale.x);
        var hit = Physics2D.Raycast(transform.position, transform.right * facingDirection, interactionRange, interactionLayer);
        
        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
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
        if (context.performed)
        {
            _attackBehaviour.SetAiming(true);
        }
        else if (context.canceled)
        {
            _attackBehaviour.SetAiming(false);
        }
    }

    public void OnShield(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _ab.SetBool("ActivateShield", true);
        }
        if (context.canceled)
        {
            _ab.SetBool("ActivateShield", false);
        }
    }
}