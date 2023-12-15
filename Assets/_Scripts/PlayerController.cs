using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Player_action player_action;
    private bool allowMovement = true;
    [SerializeField] private float jumpForce = 2f;
    private bool game_start = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player_action = new Player_action();
        player_action.Enable();
        player_action.PlayerMovement.Jump.performed += Jump;

        DisableMovement();
    }

    private void Start()
    {
        Set_freeze(true);
    }

    private void OnEnable()
    {
        Actions.OnHit += DisableMovement;
        Actions.OnEnablePlayerMovement += EnableMovement;
    }

    private void OnDisable()
    {
        Actions.OnHit -= DisableMovement;
        Actions.OnEnablePlayerMovement -= EnableMovement;
    }

    private void Set_freeze(bool x)
    {
        if (x)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        else
        {
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        }
    }

    private void EnableMovement()
    {
        Set_freeze(false);
        allowMovement = true;
    }

    private void DisableMovement()
    {
        allowMovement = false;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && allowMovement)
        {
            if (!game_start)
            {
                Actions.OnEnableObstacleSpawner?.Invoke();
                Actions.SetUI?.Invoke("get_ready", false);
                Actions.SetUI?.Invoke("score", true);
                game_start = true;
            }

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
