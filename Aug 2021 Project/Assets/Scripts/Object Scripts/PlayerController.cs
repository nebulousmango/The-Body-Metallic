using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;

    #region Camera
    float f_horizontalCameraSpeed = 4;
    float f_verticalCameraSpeed = 4;
    Camera cam;

    void CameraRotate()
    {
        float f_h = Input.GetAxis("Mouse X") * f_horizontalCameraSpeed;
        float f_v = Input.GetAxis("Mouse Y") * f_verticalCameraSpeed;
        transform.Rotate(0, f_h, 0);
        cam.transform.Rotate(f_v, 0, 0);
        Vector3 v3_camAngle = new Vector3(cam.transform.localEulerAngles.x, 0, 0);
        if (v3_camAngle.x > 300) v3_camAngle.x = 0;
        v3_camAngle.x = Mathf.Clamp(v3_camAngle.x, 0, 26);
        cam.transform.localEulerAngles = v3_camAngle;
    }
    #endregion

    #region Movement
    [SerializeField] private float f_BaseMoveSpeed;
    [SerializeField] private float f_RunMult;
    float f_currentMoveSpeed;
    float f_runSpeed;

    void MovementAnims()
    {
        animator.SetFloat("X Motion", Input.GetAxis("Horizontal"));
        animator.SetFloat("Y Motion", Input.GetAxis("Vertical"));
    }

    public void MovePlayer()
    {
        Vector3 v3_movement = (transform.right * Input.GetAxis("Horizontal") * f_currentMoveSpeed) + (transform.forward * Input.GetAxis("Vertical") * f_currentMoveSpeed) + (transform.up * rb.velocity.y);
        rb.velocity = v3_movement;
        MovementAnims();
    }

    public void RunPlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            f_currentMoveSpeed = f_runSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            f_currentMoveSpeed = f_BaseMoveSpeed;
        }
    }

    void UpdateSpeed()
    {
        f_currentMoveSpeed = f_BaseMoveSpeed;
        f_runSpeed = f_BaseMoveSpeed * f_RunMult;
    }

    void CheckMovement()
    {
        bool MovementPressed = Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0;
        bool RunPressed = Input.GetKey("left shift");
        bool IsWalking = animator.GetBool("IsWalking");
        bool IsRunning = animator.GetBool("IsRunning");

        if(MovementPressed && !IsWalking)
        {
            animator.SetBool("IsWalking", true);
        }
        else if (!MovementPressed && IsWalking)
        {
            animator.SetBool("IsWalking", false);
        }

        if(!IsRunning && (MovementPressed && RunPressed))
        {
            animator.SetBool("IsRunning", true);
        }
        if (IsRunning && (!MovementPressed || !RunPressed))
        {
            animator.SetBool("IsRunning", false);
        }
    }
    #endregion

    #region Jump
    [SerializeField] private float f_JumpForce;
    bool b_TouchingFloor = false;
    bool b_CanJump = true;

    private void OnCollisionStay(Collision other)
    {
        TouchingFloor(other, true, 6);
    }

    private void OnCollisionExit(Collision other)
    {
        TouchingFloor(other, false, 6);
    }

    void TouchingFloor(Collision other, bool TrueFalse, int layer)
    {
        if (other.gameObject.layer == layer)
        {
            b_TouchingFloor = TrueFalse;
        }
    }

    public void JumpPlayer()
    {
        if (b_CanJump && (Input.GetKeyDown(KeyCode.Space) && b_TouchingFloor))
        {
            rb.AddForce(transform.up * f_JumpForce);
            StartCoroutine(JumpCoroutine());
        }
        if (!Input.GetKeyDown(KeyCode.Space) && b_TouchingFloor)
        {
            animator.SetBool("AnimCtrl_Jump", false);
        }
    }

    IEnumerator JumpCoroutine()
    {
        b_CanJump = false;
        animator.SetBool("AnimCtrl_Jump", true);
        FindObjectOfType<AudioManager>().PlaySound("Jump");
        yield return new WaitForSeconds(1);
        b_CanJump = true;
    }
    #endregion

    #region Health
    [SerializeField] private string S_FailScene;
    [HideInInspector] public bool b_alive = true;

    public void Die()
    {
        b_alive = false;
        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine()
    {
        FindObjectOfType<AudioManager>().PlaySound("Death");
        animator.SetTrigger("AnimCtrl_Death");
        cam.transform.Rotate(26, 0, 0);
        FindObjectOfType<PauseMenuTwo>().ShowDeath();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(S_FailScene);
    }

    public void Explode()
    {
        b_alive = false;
        StartCoroutine(ExplodeCoroutine());
    }

    IEnumerator ExplodeCoroutine()
    {
        cam.transform.Rotate(0, 0, 0);
        animator.SetTrigger("AnimCtrl_Death");
        yield return new WaitForSeconds(2.5f);
        cam.transform.Rotate(26, 0, 0);
        FindObjectOfType<PauseMenuTwo>().ShowDeath();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(S_FailScene);
    }
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        animator = GetComponentInChildren<Animator>();
        rb.freezeRotation = true;
        UpdateSpeed();
    }

    void Update()
    {
        if (b_alive)
        {
            MovePlayer();
            JumpPlayer();
            RunPlayer();
            CameraRotate();
        }
    }
}
