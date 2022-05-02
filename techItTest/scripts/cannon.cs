using Godot;
using System;

public class cannon : KinematicBody2D
{
    PackedScene projectileScene;
    public int Speed = 200;
    private Vector2 _velocity = new Vector2();

    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        projectileScene = GD.Load<PackedScene>("res://scenes/projectile.tscn");
        GetNode<Timer>("FireTimer").Start();

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        pointCannon();          
    }
    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventKey eventKey) 
        {
            if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Space) 
            {
                fire();
                GetTree().SetInputAsHandled();
            }
        }
    }
    void fire()
    {
        var projectile = (Projectile)projectileScene.Instance();
        projectile.Start(GetNode<Node2D>("Barrel").GlobalPosition, Rotation);
        GetParent().AddChild(projectile);
    }
    void pointCannon() 
    {   
        var player = (KinematicBody2D)GetNode("/root/test/playerCore");
        LookAt(player.GlobalPosition);  
        RotationDegrees += 90;
    }
    private void _on_FireTimer_timeout()
    {
        fire();
    }
}


    
