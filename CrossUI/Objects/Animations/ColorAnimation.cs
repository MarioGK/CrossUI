using SFML.Graphics;

namespace CrossUI.Objects.Animations
{
    public class ColorAnimation : BaseAnimation
    {
        public Color OriginalColor { get; set; }
        public Color NewColor { get; set; }

        public new Shape Target { get; set; }
        
        public ColorAnimation(float duration, Shape target, Color newColor) : base(duration, target)
        {
            Target = target;
            if (target == null)
            {
                //TODO proper error handling
                return;
            }
            
            NewColor = newColor;

            OriginalColor = target.FillColor;
            
            OnFinish += OnOnFinish;
        }

        private void OnOnFinish()
        {
            Target.FillColor = OriginalColor;
        }

        public override void Play()
        {
            Target.FillColor = NewColor;
            base.Play();
        }
    }
}