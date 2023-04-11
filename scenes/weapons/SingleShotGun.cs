using Godot;
using System;

public partial class SingleShotGun : BaseGun
{
    // Location where projectile should spawn
    [Export]
    public Marker2D projectileSpawnLocation;

    // Direction where the projectile should be directed at
    [Export]
    public Marker2D projectileDirection;

    // True if shooting
    private bool _shooting;

    public override void _Ready()
    {
        _shooting = false;
    }

    public override BaseGun ShootProjectile()
    {
        if (!_shooting)
        {
            _shooting = true;

            var instance = ProjectileScene.Instantiate<BaseProjectile>();

            // Apply global transform location
            instance.Transform = projectileSpawnLocation.Transform;

            // Apply rotation to projectile
            instance.LinearVelocity = new Vector2(0, - ProjectileSpeed).Rotated(this.GlobalRotation);

            instance.CollisionMask = CollisionLayerMask;
            AddChild(instance);

            // Projectile was shot
            return this;
        }
        else
        {
            return null;
        }
    }

    public override void Release()
    {
        _shooting = false;
    }
}
