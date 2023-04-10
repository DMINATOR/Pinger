using Godot;
using System;

public partial class BaseGun : Node2D
{
    [Export]
    public PackedScene ProjectileScene;

    [Export]
    public float ProjectileSpeed = 100; // How fast the projectile will move (pixels/sec).
}
