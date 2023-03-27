using Godot;
using System;

public partial class PlayerBody : CharacterBody2D
{
    [Export]
    public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).

    public void GetInput()
    {

        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        Velocity = inputDirection * Speed;
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
    }
}
