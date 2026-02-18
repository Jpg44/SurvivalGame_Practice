using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Move move;
    [SerializeField] public float moveSpeed = 6f;
    [SerializeField] public Vector3 dir=new Vector3(0,0,1);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += move.VectorMovement(dir, moveSpeed, Time.deltaTime);
    }
}
