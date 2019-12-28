using CrossUI.Objects.UI;
using SFML.Graphics;

namespace CrossUI.Objects.Animations
{
    public class LinearAnimation : BaseAnimation
    {
        public LinearAnimation(float duration, Shape target) : base(duration, target)
        {
        }

        public override void Play()
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}