using UnityEngine;

public class respavn : MonoBehaviour
{
    public Vector3 start;

    private CharacterController cc;

    private void Awake()
    {
        start =transform.position;
        cc = GetComponent<CharacterController>();
    }
    private void LateUpdate()
    {
        if (transform.position.y <-4f)
        {
            cc.enabled = false;
            transform.position = start;
            cc.enabled = true;
        }
    }
}
