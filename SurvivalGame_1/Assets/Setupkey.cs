using UnityEngine;

public class Setupkey : MonoBehaviour
{
    char[] a = { 'w', 'a', 's', 'd' };
    void Awake()
    {
        Debug.Log("a:");
        Debug.Log(a[0]);
    }
    void Update()
    {
    }
}
