using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Elements")] 
    [SerializeField] private AnimationController animationController;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private Transform playerChildTransform;
    [SerializeField] private float moveSpeed;

    private float horizontal;
    private float vertical;
    


    private void Update()
    {
        GetMovementInput();
        SetMovement();
    }

    private void FixedUpdate()
    {
        SetMovement();
        SetRotation();
    }

    private void SetMovement()
    {
        playerRigidbody.velocity = GetNewVelocity();
        animationController.SetBoolean("Run",horizontal != 0 || vertical != 0);
    }

    private void SetRotation()
    {
        if (horizontal != 0 || vertical != 0)
        {
            playerChildTransform.rotation = Quaternion.LookRotation(GetNewVelocity());
        }
    }
    
    private Vector3 GetNewVelocity()
    {
        return new Vector3(horizontal, playerRigidbody.velocity.y, vertical) * moveSpeed * Time.fixedDeltaTime;
    }

    private void GetMovementInput()
    {
        horizontal = floatingJoystick.Horizontal;
        vertical = floatingJoystick.Vertical;
    }
    
  

    
}
