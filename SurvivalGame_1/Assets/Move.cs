using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 VectorMovement(Vector3 dir, float speed, float dt)//방향, 속도, 시간
    {
        dir.y = 0f; // 탑다운이니까 바닥 평면만
        if (dir.sqrMagnitude > 0.0001f)
            dir.Normalize(); // 방향만 남기기(대각선 속도 문제 방지)
        else
            return Vector3.zero;

        return dir * speed * dt; // 이번 프레임에 이동할 거리
    }
}
