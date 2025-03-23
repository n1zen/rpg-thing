using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public float Speed = 100.0f;
	private string _currentDirection;

	public override void _PhysicsProcess(double delta)
	{
		PlayerMovement();
	}

	public void PlayerMovement()
	{
		// Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		AnimatedSprite2D animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		var inputDir = new Vector2();
		
		if (Input.IsActionPressed("ui_left"))
		{
			inputDir.X = -1;
			inputDir.Y = 0;
			_currentDirection = "left";
			PlayAnimation(1);
		}
		else if (Input.IsActionPressed("ui_right"))
		{
			inputDir.X = 1;
			inputDir.Y = 0;
			_currentDirection = "right";
			PlayAnimation(1);
		}
		else if (Input.IsActionPressed("ui_up"))
		{
			inputDir.X = 0;
			inputDir.Y = -1;
			_currentDirection = "up";
			PlayAnimation(1);
		}
		else if (Input.IsActionPressed("ui_down"))
		{
			inputDir.X = 0;
			inputDir.Y = 1;
			_currentDirection = "down";
			PlayAnimation(1);
		}
		else
		{
			inputDir.X = 0;
			inputDir.Y = 0;
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
			if(movement == 0)
			{
				animatedSprite.Play("idle_side");
			}
			else
			{
				animatedSprite.Play("move_side");
			}
		}
		else if (_currentDirection == "right")
		{
			animatedSprite.FlipH = false;
			if(movement == 0)
			{
				animatedSprite.Play("idle_side");
			}
			else
			{
				animatedSprite.Play("move_side");
			}
		}
		else if (_currentDirection == "up")
		{
			if(movement == 0)
			{
				animatedSprite.Play("idle_back");
			}
			else
			{
				animatedSprite.Play("move_up");;
			}
		}
		else if (_currentDirection == "down")
		{
			if(movement == 0)
			{
				animatedSprite.Play("idle_front");
			}
			else
			{
				animatedSprite.Play("move_down");
			}
		}
	}
}
