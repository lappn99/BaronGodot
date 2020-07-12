using Godot;
using System;

public class PlayerCamera : Camera2D
{
	
	private float _cameraSpeed;

	[Export]
	public float CameraSpeed{get=>_cameraSpeed; set=>_cameraSpeed = value;}

	public override void _Ready()
	{
	}

	public override void _Process(float delta)
	{
		MoveCamera(delta);
		
	}

	private void MoveCamera(float delta)
	{

		Vector2 moveVector = Vector2.Zero;

		if(Input.IsActionPressed("move_up"))
		{
			moveVector += Vector2.Up;

		}

		if(Input.IsActionPressed("move_down"))
		{
			moveVector += Vector2.Down;
		}

		if(Input.IsActionPressed("move_left"))
		{
			moveVector += Vector2.Left;
		}

		if(Input.IsActionPressed("move_right"))
		{
			moveVector += Vector2.Right;
		}

		this.GlobalPosition += moveVector *  _cameraSpeed;

	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if(@event is InputEventMouseButton)
		{
			InputEventMouseButton emb = (InputEventMouseButton)@event;
			if(emb.IsPressed())
			{
				if(emb.ButtonIndex ==(int)ButtonList.WheelUp)
				{
					this.Zoom -= new Vector2( 0.1f,0.1f);
				}

				else if(emb.ButtonIndex == (int)ButtonList.WheelDown)
				{
					this.Zoom += new Vector2( 0.1f,0.1f);
				}
			}
		}
	}

	

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
