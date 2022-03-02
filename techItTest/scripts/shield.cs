using Godot;
using System;

public class shield : Area2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }

    void _on_Shield_body_entered(KinematicBody2D body)
    {
        GD.Print("Detected");
        body.Call("delete");
    }
}
