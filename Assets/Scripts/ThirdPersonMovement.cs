using System.Timers;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    
    private Animator anim;
    
    private Vector3 originCastSphere;
    private Vector3 directionCastSphere;
    private Vector3 direction;

    private bool isRunnin;
    
    public float speed=6f;
    public float turnSmoothVelocity;
    public float turnSmoothTime=0.1f;
    
    [SerializeField] private Joystick _joystick;

    private void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        HandleInput();
        Movement();
        UpdateAnimations();
    }

    private void HandleInput()
    {
        float horizontal = _joystick.Horizontal; 
        float vertical = _joystick.Vertical;
        direction = new Vector3(horizontal, 0f, vertical).normalized;
    }
    private void Movement()
    {
        if (direction.magnitude >= 0.01f)
        {
            isRunnin = true;
            float targetAnlge = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAnlge, ref turnSmoothVelocity,
                turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
            //anim.SetBool("isRunnin",isRunnin);
        }else
        {
            isRunnin = false;
        }
        
        
        
    }
    
    private void UpdateAnimations()
    {
        anim.SetBool("isRunnin",isRunnin);
    }
    
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.GetComponent<IRepairable>() != null) {
            
            other.GetComponent<IRepairable>().Repair();
        }
    }
}
