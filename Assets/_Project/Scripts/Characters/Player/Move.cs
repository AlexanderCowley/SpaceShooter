using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    Vector3 _movementVector;
    CharacterController _characterController;
    PlayerInput _playerActions;
    InputAction _currentAction;
    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerActions = GetComponent<PlayerInput>();
    }

    void OnEnable() => InitPlayerInput();

    void InitPlayerInput()
    {
        _currentAction = _playerActions.actions["Move"];
        _currentAction.performed += CalculateMovement;
        _currentAction.canceled += CalculateMovement;
    }

    void OnDisable()
    {
        _currentAction.performed -= CalculateMovement;
        _currentAction.canceled -= CalculateMovement;
    }

    void CalculateMovement(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        
        _movementVector = new Vector3(inputVector.x, inputVector.y, 0).normalized;
        _movementVector = Vector3.ClampMagnitude(_movementVector, 1);
    }

    void RestrictToCamera()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void MoveObject() => _characterController.Move(Time.deltaTime * MoveSpeed * _movementVector);

    void Update() => MoveObject();

    void LateUpdate() => RestrictToCamera();
}