using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShield : MonoBehaviour
{
    public Transform player;
    public float radius = 2f;

    void Update()
    {
        // Obtener posición del ratón
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldMouse = Camera.main.ScreenToWorldPoint(mousePos);
        worldMouse.z = 0f;

        // Dirección desde el jugador hacia el ratón
        Vector2 dir = (worldMouse - player.position).normalized;

        // Posición instantánea del escudo
        transform.position = player.position + (Vector3)(dir * radius);

        // Rotación perpendicular para que el escudo esté "de ancho"
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
}
