using Godot;
using System;

public partial class PlayerBody : CharacterBody2D
{
    // How fast the player will move (pixels/sec).
    [Export]
    public int Speed { get; set; } = 400;

    [Export]
    public PlayerGuns _playerGuns;

    public void GetInput()
    {
        Vector2 inputDirection = Input.GetVector(
            InputMapKeys.MoveLeft,
            InputMapKeys.MoveRight,
            InputMapKeys.MoveUp,
            InputMapKeys.MoveDown);

        Velocity = inputDirection * Speed;

        // Shooting
        if (Input.IsActionPressed(InputMapKeys.ShootWeapon))
        {
            StartShootingWeapon();
        }
        else if (Input.IsActionJustReleased(InputMapKeys.ShootWeapon))
        {
            StopShootingWeapon();
        }

        // Weapons
        if (Input.IsActionPressed(InputMapKeys.NextWeapon))
        {
            _playerGuns.EquipNextGun();
        }
        if (Input.IsActionPressed(InputMapKeys.PreviousWeapon))
        {
            _playerGuns.EquipPreviousGun();
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
    }

    private void StartShootingWeapon()
    {
        var gun = _playerGuns.Shoot();
        //if (gun != null)
        //{
        //    // Emit signal only when player actually shot a weapon
        //    EmitSignal(nameof(OnPlayerGunShootDelegate), gun);
        //}
    }

    private void StopShootingWeapon()
    {
        _playerGuns.Release();
    }
}
