using UnityEngine;
using UnityEngine.InputSystem;
public class Setupkey : MonoBehaviour
{
     enum MoveCommand
    {
        FORWARD, BACK, LEFT, RIGHT
    };

    void Awake()
    {

    }
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            Debug.Log("w눌림");
            KeyCode_W(MoveCommand.FORWARD);
        }
    }
    MoveCommand KeyCode_W(MoveCommand key)
    {
        Debug.Log(key);
        Debug.Log(":눌림");
        return key;
    }
}
