using UnityEngine;
using UnityEngine.InputSystem; // IMPORTANTE

public class SoulOrbit : MonoBehaviour
{
    public Transform player;
    public float radius = 2f;

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldMouse = Camera.main.ScreenToWorldPoint(mousePos);
        worldMouse.z = 0f;

        Vector2 dir = (worldMouse - player.position).normalized;

        transform.position = player.position + (Vector3)(dir * radius);
    }
}
