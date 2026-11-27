using UnityEngine;

public class Turntable : MonoBehaviour
{
    [SerializeField] private float degrees = 45f;
    [SerializeField] private bool isActive = true;
    [SerializeField] private bool isActive2 = true;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        float angle = degrees * Time.deltaTime;

        if (isActive2)
        {
            transform.Rotate(angle, angle, 0f, Space.Self);
        }
        else
        {
            transform.Rotate(0f, angle, 0f, Space.Self);
        }
    }
}
