using UnityEngine;

public class Targeting
{
    public static Vector3 GetTargetPosition()
    {
        Vector3 targetPosition = MousePosition.GetMousePosition();

        // aim help
        Collider[] colliders = Physics.OverlapSphere(targetPosition, 4f);
        foreach (Collider collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();

            if (enemy != null)
            {
                targetPosition = enemy.transform.position + new Vector3(0f, -0.5f, 0f);
                break;
            }
        }

        return targetPosition;
    }
}