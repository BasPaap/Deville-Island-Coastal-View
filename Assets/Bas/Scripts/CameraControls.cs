using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private float minYAngle = -45f;
    [SerializeField] private float maxYAngle = 45f;
    [SerializeField, Range(0,10f)] private float rotationSpeed = 1.0f;

    private Quaternion minRotation;
    private Quaternion maxRotation;

    private void Awake()
    {
        minRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, minYAngle, transform.rotation.eulerAngles.z);
        maxRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, maxYAngle, transform.rotation.eulerAngles.z);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, minRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, maxRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
