using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Shooter playerShooter;
    InputAction moveAction;
    InputAction fireAction;

    Vector2 minBound;
    Vector2 maxBound;

    [Header("Settings")]
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float horizontalPad = 0.5f;
    [SerializeField] float bottomVerticalPad = 0.5f;
    [SerializeField] float topVerticalPad = 2f;

    void Awake()
    {
        playerShooter = GetComponent<Shooter>();
        var pi = GetComponent<PlayerInput>();

        moveAction = pi.actions.FindAction("Move", true);
        fireAction = pi.actions.FindAction("Fire", true);

        PlayerBounds();
    }

    void Update()
    {
        // Sadece standart Move verisini oku (Klavye veya Joystick fark etmez)
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 step = new Vector3(input.x, input.y, 0) * (moveSpeed * Time.deltaTime);

        Vector3 newPos = transform.position + step;

        // Ekran sınırları
        newPos.x = Mathf.Clamp(newPos.x, minBound.x + horizontalPad, maxBound.x - horizontalPad);
        newPos.y = Mathf.Clamp(newPos.y, minBound.y + bottomVerticalPad, maxBound.y - topVerticalPad);

        transform.position = newPos;

        // Ateş etme
        if (playerShooter != null)
            playerShooter.isFiring = fireAction.IsPressed();
    }

    void PlayerBounds()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void OnEnable() { moveAction?.Enable(); fireAction?.Enable(); }
    void OnDisable() { moveAction?.Disable(); fireAction?.Disable(); }
}