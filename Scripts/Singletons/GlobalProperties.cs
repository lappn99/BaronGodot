using Godot;
using System;
using BaronyGame.GameObjects;
namespace BaronyGame.Singletons
{

    public class GlobalProperties : Node
    {

        private int _tileSize;

        public int TileSize { get => _tileSize; set => _tileSize = value; }

        public override void _Ready()
        {

        }


    }
}
