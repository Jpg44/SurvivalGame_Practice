
using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6.0f;
    public float acceleration = 18.0f;   // 클수록 즉응
    public float deceleration = 22.0f;   // 클수록 급정지
    public bool cameraRelativeMovement = true;

    [Header("Rotation")]
    public bool faceMouse = true;
    public float rotateSpeed = 20f;      // 회전 스무딩
    public LayerMask groundMask = ~0;    // Ground 레이어로 바꾸는 걸 권장

    [Header("References")]
    public Transform cameraTransform;    // 비우면 Camera.main 사용

    private CharacterController _cc;
    private Vector3 _velocity;           // 수평 속도(가속/감속용)
    private Camera _cam;

    void Awake()
    {
        _cc = GetComponent<CharacterController>();

        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        _cam = Camera.main;
    }

    void Update()
    {
        Vector2 input = ReadMoveInput();
        Vector3 desiredMove = BuildMoveVector(input);

        // 가속/감속 적용한 부드러운 이동
        Vector3 desiredVelocity = desiredMove * moveSpeed;
        float rate = (desiredVelocity.sqrMagnitude > 0.001f) ? acceleration : deceleration;
        _velocity = Vector3.MoveTowards(_velocity, desiredVelocity, rate * Time.deltaTime);

        // CharacterController는 중력 없으면 바닥에 붙지 않는 경우가 있어 살짝 내려줌
        Vector3 motion = _velocity;
        motion.y = -2f; // 바닥 밀착용(점프 없음)

        _cc.Move(motion * Time.deltaTime);

        if (faceMouse)
            RotateToMouse();
        else
            RotateToMoveDirection(desiredMove);
    }

    Vector2 ReadMoveInput()
    {
#if ENABLE_INPUT_SYSTEM
        Vector2 v = Vector2.zero;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) v.y += 1;
            if (Keyboard.current.sKey.isPressed) v.y -= 1;
            if (Keyboard.current.dKey.isPressed) v.x += 1;
            if (Keyboard.current.aKey.isPressed) v.x -= 1;
        }
        return Vector2.ClampMagnitude(v, 1f);
#else
        // Project Settings > Input Manager에 기본 축이 있으면 바로 동작
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        return Vector2.ClampMagnitude(new Vector2(x, y), 1f);
#endif
    }

    Vector3 BuildMoveVector(Vector2 input)
    {
        Vector3 move = new Vector3(input.x, 0f, input.y);
        if (!cameraRelativeMovement || cameraTransform == null)
            return move.normalized;

        // 카메라의 forward/right를 바닥에 평평하게 투영
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0f; right.y = 0f;
        forward.Normalize(); right.Normalize();

        Vector3 camRelative = (right * input.x + forward * input.y);
        return camRelative.sqrMagnitude > 0.001f ? camRelative.normalized : Vector3.zero;
    }

    void RotateToMoveDirection(Vector3 moveDir)
    {
        if (moveDir.sqrMagnitude < 0.001f) return;

        Quaternion target = Quaternion.LookRotation(moveDir, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, rotateSpeed * Time.deltaTime);
    }

    void RotateToMouse()
    {
        if (_cam == null) return;

#if ENABLE_INPUT_SYSTEM
        if (Mouse.current == null) return;
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = _cam.ScreenPointToRay(mousePos);
#else
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
#endif

        // GroundMask에만 맞게 Raycast
        if (Physics.Raycast(ray, out RaycastHit hit, 500f, groundMask))
        {
            Vector3 lookPoint = hit.point;
            lookPoint.y = transform.position.y;

            Vector3 dir = (lookPoint - transform.position);
            if (dir.sqrMagnitude < 0.001f) return;

            Quaternion target = Quaternion.LookRotation(dir.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, rotateSpeed * Time.deltaTime);
        }
    }
}
