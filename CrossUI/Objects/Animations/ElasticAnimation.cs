using System;
using SFML.Graphics;
using SFML.System;

namespace CrossUI.Objects.Animations
{
    public class ElasticAnimation : BaseAnimation
    {
        public Vector2f FinalPosition { get; private set; }

        public ElasticAnimation(float duration, Transformable target, Vector2f finalPosition) : base(duration, target)
        {
            FinalPosition = finalPosition;
        }

        public override void Update()
        {
            var time = Clock.ElapsedTime.AsSeconds();
            Console.WriteLine(time);
            var x = Easing.ElasticEaseOut(time, InitialPosition.X, FinalPosition.X, Duration);
            var y = Easing.ElasticEaseOut(time, InitialPosition.Y, FinalPosition.Y, Duration);
            Target.Position = new Vector2f(x,y);
            base.Update();
        }
    }
}