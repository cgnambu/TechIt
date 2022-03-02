using Godot;
using System;

public class Projectile : KinematicBody2D
{
    [Export] float XSPEED = 0f;
    [Export] float YSPEED = -100f;
    Vector2 velocity = new Vector2(0f, 0f);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        velocity.x = XSPEED;
        velocity.y = YSPEED;
        MoveAndSlide(velocity);
    }

    void delete()   //Deletes projectile, called from shield when intercepted
    {
        QueueFree();
    }
}
