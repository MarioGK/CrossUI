using CrossUI.Objects.UI;
using SFML.Graphics;

namespace CrossUI.Objects.Animations
{
    public class ColorAnimation : BaseAnimation
    {
        public Color OriginalColor { get; set; }
        public Color NewColor { get; set; }

        public ColorAnimation(BaseUIObject target, float duration, Color newColor) : base(target, duration)
        {
            Target = target;
            if (target == null)
            {
                //TODO proper error handling
                return;
            }
            
            NewColor = newColor;

            //OriginalColor = target.;
            
            OnFinish += OnOnFinish;
        }

        private void OnOnFinish()
        {
            //Target.FillColor = OriginalColor;
        }

        public override void Play()
        {
            //Target.FillColor = NewColor;
            base.Play();
        }
    }
}