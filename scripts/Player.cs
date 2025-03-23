using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public float Speed = 100.0f;
	private string _currentDirection = "down";

    public override void _Ready()
    {
        PlayAnimation(0);
    }

    public override void _PhysicsProcess(double delta)
	{
		PlayerMovement();
	}

	public void PlayerMovement()
	{
		Vector2 inputDir;
		if (Input.IsActionPressed("move_left"))
		{
			inputDir = Vector2.Left;
			_currentDirection = "left";
			PlayAnimation(1);
		}
		else if (Input.IsActionPressed("move_right"))
		{
			
			inputDir = Vector2.Right;
			_currentDirection = "right";
			PlayAnimation(1);
		}
		else if (Input.IsActionPressed("move_up"))
		{		
			inputDir = Vector2.Up;
			_currentDirection = "up";
			PlayAnimation(1);
		}
		else if (Input.IsActionPressed("move_down"))
		{
			inputDir = Vector2.Down;
			_currentDirection = "down";
			PlayAnimation(1);
		}
		else
		{
			inputDir = Vector2.Zero;
			PlayAnimation(0);
		}
		Velocity = inputDir.Normalized() * Speed;
		MoveAndSlide();
	}

	public void PlayAnimation(int movement)
	{
		var animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		if (_currentDirection == "left")
		{
			animatedSprite.FlipH = true;
			animatedSprite.Play((movement == 0) ? "idle_side" : "move_side");
		}
		else if (_currentDirection == "right")
		{
			animatedSprite.FlipH = false;
			animatedSprite.Play((movement == 0) ? "idle_side" : "move_side");
		}
		else if (_currentDirection == "up")
		{
			animatedSprite.Play((movement == 0) ? "idle_up" : "move_up");
		}
		else if (_currentDirection == "down")
		{
			animatedSprite.Play((movement == 0) ? "idle_down" : "move_down");
		}
	}
}
