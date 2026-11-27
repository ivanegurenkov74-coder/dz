using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ice : MonoBehaviour
{
    [SerializeField] private float grip = 2f;
    private bool OnIce;
    private Vector3 speed;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Ice") && hit.normal.y > 0.7f)
        {
            OnIce = true;
        }
    }
    public Vector3 Adjust(Vector3 wanted)
    {
        if (OnIce)
        {
            speed = Vector3.MoveTowards(speed, wanted, grip * Time.deltaTime);
        }
        else
        {
            speed = wanted;
        }
        OnIce = false;
        return speed;
    }
}
