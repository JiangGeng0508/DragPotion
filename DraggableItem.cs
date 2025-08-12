using Godot;
using System;

public partial class DraggableItem : RigidBody2D
{
	public Line2D DragLine { get; set; }
	public bool IsDragging { get; set; } = false;
	public Vector2 DragStartPosition { get; set; }
	public Texture2D Icon { get; set; }
	public override void _Ready()
	{
		DragLine = GetNode<Line2D>("DragLine");

		if (Icon != null)
		{
			GetNode<Sprite2D>("Icon").Texture = Icon;
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		if (IsDragging)
		{
			Vector2 mousePosition = GetLocalMousePosition();
			var force = (mousePosition - DragStartPosition).Rotated(Rotation);
			force = force.Normalized() * MathF.Pow(force.Length(), 0.5f) * 1000f;
			DragLine.Points = [DragStartPosition, mousePosition];
			// ApplyForce(force, DragStartPosition);
			ApplyCentralForce(force);
			ApplyTorque(mousePosition.Angle());
		}
	}
	public void OnInputEvent(Node viewport, InputEvent @event, int ShapeIdx)
	{
		if (@event is InputEventMouseButton mouseButtonEvent && mouseButtonEvent.ButtonIndex == MouseButton.Left)
		{
			if (mouseButtonEvent.Pressed)
			{
				IsDragging = true;
				DragLine.Visible = true;
				DragStartPosition = GetLocalMousePosition();
				LinearDamp = 10f;
				AngularDamp = 10f;
			}
		}
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButtonEvent && mouseButtonEvent.ButtonIndex == MouseButton.Left)
		{
			if (!mouseButtonEvent.Pressed)
			{
				IsDragging = false;
				DragLine.Visible = false;
				LinearDamp = 0f;
				AngularDamp = 0f;
			}
		}
	}
}
