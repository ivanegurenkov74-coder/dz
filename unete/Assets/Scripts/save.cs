using UnityEngine;

public class save : MonoBehaviour
{
    [SerializeField] private GameObject point;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<respavn>().start =transform.position;
            point.SetActive(true);

        }
    }
}
