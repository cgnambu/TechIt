using Godot;
using System;

public class Projectile : KinematicBody2D
{
    [Export] float XSPEED = 0f;
    [Export] float YSPEED = 100f;
    public int Speed = 200;
    Vector2 velocity = new Vector2();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        //velocity.x = XSPEED;
        //velocity.y = YSPEED;
        //MoveAndSlide(velocity);
        var collision = MoveAndCollide(velocity * delta);
        if (collision != null)
        {
            velocity = velocity.Bounce(collision.Normal);
            if (collision.Collider.HasMethod("Hit"))
            {
                collision.Collider.Call("Hit");
            }
        }
        pointProjectile();
    }
    public void Start(Vector2 pos, float dir)
    {
        Rotation = dir;
        Position = pos;
        velocity = new Vector2(0, Speed).Rotated(Rotation);
    }

    void delete()   //Deletes projectile, called from shield when intercepted
    {
        QueueFree();
    }
    
    void pointProjectile()
    {
        var player = (KinematicBody2D)GetNode("/root/test/playerCore");
        LookAt(player.GlobalPosition);  
        RotationDegrees += 90;    
    }
}
