using UnityEngine;

public class PlaneIntersectionVisualization : MonoBehaviour
{
    public Transform plane1; // Cube (plane1)
    public Transform plane2; // Cube2 (plane2)
    public LineRenderer intersectionLine;

    void Update()
    {
        // Compute planes from their transforms (using their "up" as normal)
        Plane p1 = new Plane(plane1.up, plane1.position);
        Plane p2 = new Plane(plane2.up, plane2.position);

        // Determine intersection line direction
        Vector3 intersectionDir = Vector3.Cross(p1.normal, p2.normal);

        // If planes are parallel (or nearly parallel), hide intersection line
        if (Vector3.Cross(p1.normal, p2.normal).sqrMagnitude < 0.0001f)
        {
            intersectionLine.enabled = false;
            return;
        }
        else{
            intersectionLine.enabled = true;

        }

        // Find a point on intersection
        Vector3 intersectionPoint = CalculateIntersectionPoint(p1, p2);

        // Draw line across intersection clearly
        intersectionLine.positionCount = 2;
        intersectionLine.SetPosition(0, intersectionPoint + intersectionDir.normalized * 5f);
        intersectionLine.SetPosition(1, intersectionPoint - intersectionDir.normalized * 5f);
    }

    Vector3 CalculateIntersectionPoint(Plane plane1, Plane plane2)
    {
        // Calculate direction cross product
        Vector3 direction = Vector3.Cross(plane1.normal, plane2.normal);

        float det = direction.sqrMagnitude;

        Vector3 point =
            (Vector3.Cross(direction, plane2.normal) * plane1.distance +
             Vector3.Cross(plane1.normal, direction) * plane2.distance) / det;

        return point;
    }
}
