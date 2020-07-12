using Godot;
using System;

public class GameController : Node
{

    private GameSignals _gameSignals;
    private int _currentYear;
    public override void _Ready()
    {
        _currentYear = 1066;
        _gameSignals = (GameSignals)GetNode("/root/GameSignals");
    }
    public void NextTurn()
    {
        _currentYear++;
        _gameSignals.EmitSignal(nameof(GameSignals.NextTurn));
        _gameSignals.EmitSignal(nameof(GameSignals.UpdateUI),_currentYear);
    }

}
