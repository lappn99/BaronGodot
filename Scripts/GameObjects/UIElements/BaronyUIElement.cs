using Godot;
using System;
using BaronyGame.Singletons;
using BaronyGame.Events;
namespace BaronyGame.GameObjects.UI
{
    public abstract class BaronyUIElement : VBoxContainer
    {
        [Export]
        public NodePath baronyPath;

        protected TextureRect _textureRect;

        protected Barony _currentBarony;
        protected GameSignals _gameSignals;

        protected GameController _gameController;

        protected Label _label;

        [Export(PropertyHint.File)]
        protected string _imageFile;



        public override void _Ready()
        {
            _gameController = (GameController)GetNode("/root/GameController");
            //_currentBarony = (Barony)GetNode(baronyPath);
            _gameSignals = (GameSignals)GetNode("/root/GameSignals");
            _textureRect = (TextureRect)GetNode("TextureRect");
            Texture texture = (Texture)ResourceLoader.Load(_imageFile);
            _textureRect.Texture = texture;
            _label = (Label)GetNode("Label");
            this._gameSignals.Connect(nameof(GameSignals.UpdateUI), this, nameof(UpdateElement));
            _gameSignals.Connect(nameof(GameSignals.CurrentBaronyChanged), this, nameof(UpdateCurrentBarony));
        }

        public abstract void UpdateElement();

        public void UpdateCurrentBarony(Barony barony)
        {
            _currentBarony = barony;
        }
    }

}
