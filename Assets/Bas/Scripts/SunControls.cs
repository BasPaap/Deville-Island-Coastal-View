using UnityEngine;

public class SunControls : MonoBehaviour
{
    [SerializeField] private float minXAngle = -90f;
    [SerializeField] private float maxXAngle = 90f;
    [SerializeField, Range(0, 10f)] private float rotationSpeed = 1.0f;

    private Quaternion minRotation;
    private Quaternion maxRotation;

    private void Awake()
    {
        minRotation = Quaternion.Euler(minXAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        maxRotation = Quaternion.Euler(maxXAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, minRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, maxRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
