using UnityEngine;

public class MousePosition
{
    private static LayerMask layerMask = 1 << 7;

    public static Vector3 GetMousePosition()
    {
        if (Camera.main == null)
        {
            return Vector3.zero;
        }

        Vector3 worldPosition = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000, layerMask))
        {
            worldPosition = hitData.point;
        }

        return worldPosition;
    }
}