using UnityEngine;
using TMPro;

public class DynamicPlaneEquation : MonoBehaviour
{
    public TextMeshPro planeLabel;

    void Update()
    {
        // Get the plane's normal (up direction explicitly)
        Vector3 normal = transform.up.normalized;

        // Calculate "d" explicitly for the plane equation (Ax + By + Cz + D = 0)
        float d = -Vector3.Dot(normal, transform.position);

        // Explicitly format plane equation
        string equation = $"{normal.x:F2}x + {normal.y:F2}y + {normal.z:F2}z + {d:F2} = 0";

        // Clearly update the text dynamically
        planeLabel.text = equation;

        // Explicitly rotate text to face the main camera
        if (Camera.main != null)
            planeLabel.transform.rotation = Quaternion.LookRotation(planeLabel.transform.position - Camera.main.transform.position);
    }
}
