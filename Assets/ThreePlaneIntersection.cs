using UnityEngine;

public class ThreePlaneIntersection : MonoBehaviour
{
    public Transform plane1, plane2, plane3;
    public GameObject intersectionPoint;

    void Update()
    {
        Plane p1 = new Plane(plane1.up, plane1.position);
        Plane p2 = new Plane(plane2.up, plane2.position);
        Plane p3 = new Plane(plane3.up, plane3.position);

        Vector3 point;
        if (IntersectThreePlanes(p1, p2, p3, out point))
        {
            intersectionPoint.SetActive(true);
            intersectionPoint.transform.position = point;
        }
        else
        {
            intersectionPoint.SetActive(false);
        }
    }

    bool IntersectThreePlanes(Plane p1, Plane p2, Plane p3, out Vector3 intersection)
    {
        intersection = Vector3.zero;
        float denom = Vector3.Dot(p1.normal, Vector3.Cross(p2.normal, p3.normal));

        if (Mathf.Abs(denom) < 0.0001f)
            return false; // clearly no unique intersection (planes parallel or intersecting along line)

        intersection = (
            (-p1.distance * Vector3.Cross(p2.normal, p3.normal)) +
            (-p2.distance * Vector3.Cross(p3.normal, p1.normal)) +
            (-p3.distance * Vector3.Cross(p1.normal, p2.normal))
            ) / denom;

        return true;
    }
}
