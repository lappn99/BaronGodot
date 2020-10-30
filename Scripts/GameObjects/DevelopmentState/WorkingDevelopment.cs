

using System;
using Godot;
namespace BaronyGame.GameObjects.States
{
    public class WorkingDevelopment : DevelopmentState
    {

        public WorkingDevelopment(Development development) : base(development)
        {

        }

        public override void Ready()
        {
            GD.Print("Working development");
        }

        public override void NextTurn()
        {
            development.CurrentJob.WorkJob();
        }

        public override void Exit()
        {

        }
    }
}
