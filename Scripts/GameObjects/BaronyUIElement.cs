using Godot;
using System;

public abstract class BaronyUIElement : VBoxContainer
{
	[Export]
	public NodePath baronyPath;

	protected TextureRect _textureRect;

	protected Barony _currentBarony;
	protected GameSignals _gameSignals;

	protected Label _label;

	[Export(PropertyHint.File)]
	protected string _imageFile;

	
	
	public override void _Ready()
	{
		_currentBarony = (Barony)GetNode(baronyPath);
		_gameSignals = (GameSignals)GetNode("/root/GameSignals");
		_textureRect = (TextureRect)GetNode("TextureRect");
		Texture texture = (Texture)ResourceLoader.Load(_imageFile);
		_textureRect.Texture = texture;
		_label = (Label)GetNode("Label");
		this._gameSignals.Connect(nameof(GameSignals.UpdateUI),this,nameof(UpdateElement));
	}

	public abstract void UpdateElement(int year);


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
