using InControl;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed = 6f;
    public float RotationSpeed = 120f;
    public GameObject BulletPrefab;

    private PlayerActions _playerActions;
    private Rigidbody2D _rigidbody2D;
    private Transform _bulletPreviewTransform;

    private void Awake()
    {
        SetupInputActions();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _bulletPreviewTransform = transform.Find("BulletPreview");
    }

    private void SetupInputActions()
    {
        _playerActions = new PlayerActions();

        _playerActions.Left.AddDefaultBinding(Key.LeftArrow);
        _playerActions.Left.AddDefaultBinding(InputControlType.DPadLeft);
        _playerActions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);

        _playerActions.Right.AddDefaultBinding(Key.RightArrow);
        _playerActions.Right.AddDefaultBinding(InputControlType.DPadRight);
        _playerActions.Right.AddDefaultBinding(InputControlType.LeftStickRight);

        _playerActions.Up.AddDefaultBinding(Key.UpArrow);
        _playerActions.Up.AddDefaultBinding(InputControlType.DPadUp);
        _playerActions.Up.AddDefaultBinding(InputControlType.LeftStickUp);

        _playerActions.Down.AddDefaultBinding(Key.DownArrow);
        _playerActions.Down.AddDefaultBinding(InputControlType.DPadDown);
        _playerActions.Down.AddDefaultBinding(InputControlType.LeftStickDown);

        _playerActions.Shoot.AddDefaultBinding(Key.X);
        _playerActions.Shoot.AddDefaultBinding(InputControlType.RightBumper);

        _playerActions.Boost.AddDefaultBinding(Key.C);
        _playerActions.Boost.AddDefaultBinding(InputControlType.LeftBumper);
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateMovementAndRotation();
        UpdateShooting();
    }

    private void UpdateMovementAndRotation()
    {
        _rigidbody2D.velocity = transform.right * _playerActions.UpDown.Value * -MovementSpeed;
        _rigidbody2D.angularVelocity = _playerActions.LeftRight.Value * -RotationSpeed;
    }

    private void UpdateShooting()
    {
        if (_playerActions.Shoot.WasReleased)
        {
            Instantiate(BulletPrefab, _bulletPreviewTransform.position, _bulletPreviewTransform.rotation);
        }
    }
}