using System;
using CrossUI.Enumerations;
using CrossUI.Objects.UI;
using SFML.Graphics;
using SFML.System;

namespace CrossUI.Objects.Animations
{
    public abstract class BaseAnimation
    {
        public float Duration { get; set; }
        public Clock Clock { get; set; }
        public AnimationState State { get; set; }
        public bool Finished => Clock.ElapsedTime.AsSeconds() > Duration;

        public Transformable Target { get; set; }

        public Vector2f InitialPosition { get; set; }
        public Vector2f FinalPosition { get; set; }

        public BaseAnimation(float duration, Transformable target)
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