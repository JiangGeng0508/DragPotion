using Godot;
using System;

public partial class Camera2d : Camera2D
{
	[Export]
	public float speed = 100.0f;
	public bool isDrag = false;
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("CameraLeft"))
		{
			Position -= new Vector2(speed * (float)delta, 0);
		}
		else if (Input.IsActionPressed("CameraRight"))
		{
			Position += new Vector2(speed * (float)delta, 0);
		}
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.ButtonIndex == MouseButton.Middle)
			{
				isDrag = mouseButton.Pressed;
				GD.Print("Camera2d: " + Position);
			}
		}
		if (@event is InputEventMouseMotion mouseMotion)
		{
			if (isDrag)
			{
				Position -= new Vector2(mouseMotion.Relative.X, 0);
			}
		}
	}
}
