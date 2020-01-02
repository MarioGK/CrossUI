using System;
using CrossUI.Enumerations;
using CrossUI.Objects.UI;
using CrossUI.SFML.System;

namespace CrossUI.Objects.Animations
{
    public abstract class BaseAnimation
    {
        public float Duration { get; set; }
        public Clock Clock { get; set; }
        public AnimationState State { get; set; }
        public bool Finished => Clock.ElapsedTime.AsSeconds() > Duration;

        public BaseUIObject Target { get; set; }

        public Vector2f InitialPosition { get; set; }
        public Vector2f FinalPosition { get; set; }

        public BaseAnimation(BaseUIObject target, float duration)
        {
            Clock = new Clock();
            Duration = duration;
            Target = target;
            InitialPosition = target.Position;
        }

        public virtual void Play()
        {
            State = AnimationState.Playing;
        }
        
        public virtual void Update()
        {
            Target.Update();
            if (Finished)
            {
                State = AnimationState.Finished;
                OnFinish?.Invoke();
            }
            
        }

        public void Reset()
        {
            State = AnimationState.Idle;
            Clock.Restart();
        }

        public delegate void FinishDelegate();

        public event FinishDelegate OnFinish;
    }
}