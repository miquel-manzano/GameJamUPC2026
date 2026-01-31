using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShield : MonoBehaviour
{
    public Transform player;
    public float radius = 2f;

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldMouse = Camera.main.ScreenToWorldPoint(mousePos);
        worldMouse.z = 0f;

        Vector2 dir = (worldMouse - player.position).normalized;

        // Mover el pivot
        transform.position = player.position + (Vector3)(dir * radius);

        // Rotar el pivot
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
}
