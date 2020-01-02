using System;
using CrossUI.Objects.UI;
using CrossUI.SFML.System;
using SFML.Graphics;

namespace CrossUI.Objects.Animations
{
    public class ElasticAnimation : BaseAnimation
    {
        public Vector2f FinalPosition { get; private set; }

        public ElasticAnimation(BaseUIObject target, float duration, Vector2f finalPosition) : base(target, duration)
        {
            FinalPosition = finalPosition;
        }

        public override void Update()
        {
            var time = Clock.ElapsedTime.AsSeconds();
            Console.WriteLine(time);
            var x = Easing.ElasticEaseOut(time, InitialPosition.X, FinalPosition.X, Duration);
            var y = Easing.ElasticEaseOut(time, InitialPosition.Y, FinalPosition.Y, Duration);
            var pos = new Vector2f(x, y);
            Target.Position = pos;
            base.Update();
        }
    }
}