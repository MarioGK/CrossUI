using System;
using CrossUI.Objects.UI;
using CrossUI.SFML.System;

namespace CrossUI.Objects.Animations
{
    public class ElasticAnimation : BaseAnimation
    {
        public Vector2F FinalPosition { get; private set; }

        public ElasticAnimation(BaseUIObject target, float duration, Vector2F finalPosition) : base(target, duration)
        {
            FinalPosition = finalPosition;
        }

        public override void Update()
        {
            var time = Clock.ElapsedTime.AsSeconds();
            Console.WriteLine(time);
            var x = Easing.ElasticEaseOut(time, InitialPosition.X, FinalPosition.X, Duration);
            var y = Easing.ElasticEaseOut(time, InitialPosition.Y, FinalPosition.Y, Duration);
            var pos = new Vector2F(x, y);
            Target.Position = pos;
            base.Update();
        }
    }
}