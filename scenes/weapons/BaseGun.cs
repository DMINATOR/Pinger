using Godot;

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

    // Collision Layer mask to be used for projectiles created by this gun
    [Export(hint: PropertyHint.Layers2DPhysics)]
    public uint CollisionLayerMask;

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
