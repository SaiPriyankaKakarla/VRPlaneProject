using UnityEngine;
using TMPro;

public class PlaneEquationUIManager : MonoBehaviour
{
    public Transform redPlane;
    public Transform bluePlane;
    public Transform YellowPlane;

    public TextMeshProUGUI equationDisplay;

    public void ShowRedPlaneEquation()
    {
        ShowEquation(redPlane);
    }

    public void ShowBluePlaneEquation()
    {
        ShowEquation(bluePlane);
    }

    public void ShowYellowPlaneEquation()
    {
        ShowEquation(YellowPlane);
    }

    void ShowEquation(Transform plane)
    {
        Vector3 normal = plane.up.normalized;
        float d = -Vector3.Dot(normal, plane.position);

        string eq = $"{plane.name}:\n{normal.x:F2}x + {normal.y:F2}y + {normal.z:F2}z + {d:F2} = 0";
        equationDisplay.text = eq;
    }
}
