using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float mouseSensivity = 0.15f;

    private Player input; //Вместо моего Player вписывайте название своей карты
    private float xRotation;

    private void Awake()
    {
        input = new Player(); //Вместо моего Player вписывайте название своей
                              //карты
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnEnable()
    {
        input.PlayerMove.Enable(); // вместо PlayerMove ставите ТО НАЗВАНИЕ, что вы 
                                   // писали в картах управления..
    }
    private void OnDisable()
    {
        input.PlayerMove.Disable();
    }
    private void OnDestroy()
    {
        input.Dispose();  
    }
    private void Update()
    {
        Vector2 lookInput = input.PlayerMove.Look.ReadValue<Vector2>();

        float mouseX = lookInput.x * mouseSensivity;
        float mouseY = lookInput.y * mouseSensivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
