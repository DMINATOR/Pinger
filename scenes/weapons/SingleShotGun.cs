using Godot;
using System;

public partial class SingleShotGun : BaseGun
{
    // Location where projectile should spawn
    [Export]
    public Marker2D projectileSpawnLocation;

    // True if shooting
    private bool _shooting;

    public override void _Ready()
    {
        //_spawnLocation = GetNode<Marker2D>($"%{nameof(_spawnLocation)}");
        _shooting = false;
    }

    public override BaseGun ShootProjectile()
    {
        if (!_shooting)
        {
            _shooting = true;

            var instance = ProjectileScene.Instantiate();
            AddChild(instance);

            //var newProjectile = ProjectileScene.Instance<BulletProjectile>();
            //GlobalGameState.GameplayData.GameMap.SpawnProjectile(newProjectile, _spawnLocation, this.GlobalRotation, ProjectileSpeed);

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
