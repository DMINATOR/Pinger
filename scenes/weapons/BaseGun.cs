using Godot;
using System;

/// <summary>
/// Base class to use for guns shooting projectiles
/// </summary>
public partial class BaseGun : Node2D
{
    // Projectile Scene to create when shooting projectile
    [Export]
    public PackedScene ProjectileScene;

    // How fast the projectile will move (pixels/sec).
    [Export]
    public float ProjectileSpeed = 100;

    // Shoots projectile
    public virtual BaseGun ShootProjectile()
    {
        return null;
    }

    // Stop shooting
    public virtual void Release()
    {

    }
}
