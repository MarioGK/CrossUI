using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace CrossUI
{
    public static class Easing
    {

        
        #region Linear

        /// <summary>
        /// Easing equation function for a simple linear tweening, with no easing.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="startingValue">Starting value.</param>
        /// <param name="finalValue">Final value.</param>
        /// <param name="duration">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float Linear(float time, float startingValue, float finalValue, float duration)
        {
            return finalValue * time / duration + startingValue;
        }

        #endregion

        #region Expo

        /// <summary>
        /// Easing equation function for an exponential (2^t) easing out: 
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float ExpoEaseOut(float time, float b, float c, float d)
        {
            return (time == d) ? b + c : c * (-MathF.Pow(2, -10 * time / d) + 1) + b;
        }

        /// <summary>
        /// Easing equation function for an exponential (2^t) easing in: 
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float ExpoEaseIn(float time, float b, float c, float d)
        {
            return (time == 0) ? b : c * MathF.Pow(2, 10 * (time / d - 1)) + b;
        }

        /// <summary>
        /// Easing equation function for an exponential (2^t) easing in/out: 
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float ExpoEaseInOut(float time, float b, float c, float d)
        {
            if (time == 0)
            {
                return b;
            }

            if (time == d)
            {
                return b + c;
            }

            if ((time /= d / 2) < 1)
            {
                return c / 2 * MathF.Pow(2, 10 * (time - 1)) + b;
            }

            return c / 2 * (-MathF.Pow(2, -10 * --time) + 2) + b;
        }

        /// <summary>
        /// Easing equation function for an exponential (2^t) easing out/in: 
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float ExpoEaseOutIn(float time, float b, float c, float d)
        {
            if (time < d / 2)
            {
                return ExpoEaseOut(time * 2, b, c / 2, d);
            }

            return ExpoEaseIn((time * 2) - d, b + c / 2, c / 2, d);
        }

        #endregion

        #region Circular

        /// <summary>
        /// Easing equation function for a circular (sqrt(1-t^2)) easing out: 
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float CircEaseOut(float time, float b, float c, float d)
        {
            return c * MathF.Sqrt(1 - (time = time / d - 1) * time) + b;
        }

        /// <summary>
        /// Easing equation function for a circular (sqrt(1-t^2)) easing in: 
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float CircEaseIn(float time, float b, float c, float d)
        {
            return -c * (MathF.Sqrt(1 - (time /= d) * time) - 1) + b;
        }

        /// <summary>
        /// Easing equation function for a circular (sqrt(1-t^2)) easing in/out: 
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float CircEaseInOut(float time, float b, float c, float d)
        {
            if ((time /= d / 2) < 1)
            {
                return -c / 2 * (MathF.Sqrt(1 - time * time) - 1) + b;
            }

            return c / 2 * (MathF.Sqrt(1 - (time -= 2) * time) + 1) + b;
        }

        /// <summary>
        /// Easing equation function for a circular (sqrt(1-t^2)) easing in/out: 
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float CircEaseOutIn(float time, float b, float c, float d)
        {
            if (time < d / 2)
            {
                return CircEaseOut(time * 2, b, c / 2, d);
            }

            return CircEaseIn((time * 2) - d, b + c / 2, c / 2, d);
        }

        #endregion

        #region Quad

        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing out: 
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float QuadEaseOut(float time, float b, float c, float d)
        {
            return -c * (time /= d) * (time - 2) + b;
        }

        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing in: 
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float QuadEaseIn(float time, float b, float c, float d)
        {
            return c * (time /= d) * time + b;
        }

        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing in/out: 
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float QuadEaseInOut(float time, float b, float c, float d)
        {
            if ((time /= d / 2) < 1)
            {
                return c / 2 * time * time + b;
            }

            return -c / 2 * ((--time) * (time - 2) - 1) + b;
        }

        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing out/in: 
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float QuadEaseOutIn(float time, float b, float c, float d)
        {
            if (time < d / 2)
            {
                return QuadEaseOut(time * 2, b, c / 2, d);
            }

            return QuadEaseIn((time * 2) - d, b + c / 2, c / 2, d);
        }

        #endregion

        #region Sine

        /// <summary>
        /// Easing equation function for a sinusoidal (sin(t)) easing out: 
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float SineEaseOut(float time, float b, float c, float d)
        {
            return c * MathF.Sin(time / d * (MathF.PI / 2)) + b;
        }

        /// <summary>
        /// Easing equation function for a sinusoidal (sin(t)) easing in: 
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float SineEaseIn(float time, float b, float c, float d)
        {
            return -c * MathF.Cos(time / d * (MathF.PI / 2)) + c + b;
        }

        /// <summary>
        /// Easing equation function for a sinusoidal (sin(t)) easing in/out: 
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float SineEaseInOut(float time, float b, float c, float d)
        {
            if ((time /= d / 2) < 1)
            {
                return c / 2 * (MathF.Sin(MathF.PI * time / 2)) + b;
            }

            return -c / 2 * (MathF.Cos(MathF.PI * --time / 2) - 2) + b;
        }

        /// <summary>
        /// Easing equation function for a sinusoidal (sin(t)) easing in/out: 
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float SineEaseOutIn(float time, float b, float c, float d)
        {
            if (time < d / 2)
            {
                return SineEaseOut(time * 2, b, c / 2, d);
            }

            return SineEaseIn((time * 2) - d, b + c / 2, c / 2, d);
        }

        #endregion

        #region Cubic

        /// <summary>
        /// Easing equation function for a cubic (t^3) easing out: 
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float CubicEaseOut(float time, float b, float c, float d)
        {
            return c * ((time = time / d - 1) * time * time + 1) + b;
        }

        /// <summary>
        /// Easing equation function for a cubic (t^3) easing in: 
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float CubicEaseIn(float time, float b, float c, float d)
        {
            return c * (time /= d) * time * time + b;
        }

        /// <summary>
        /// Easing equation function for a cubic (t^3) easing in/out: 
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float CubicEaseInOut(float time, float b, float c, float d)
        {
            if ((time /= d / 2) < 1)
            {
                return c / 2 * time * time * time + b;
            }

            return c / 2 * ((time -= 2) * time * time + 2) + b;
        }

        /// <summary>
        /// Easing equation function for a cubic (t^3) easing out/in: 
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float CubicEaseOutIn(float time, float b, float c, float d)
        {
            if (time < d / 2)
            {
                return CubicEaseOut(time * 2, b, c / 2, d);
            }

            return CubicEaseIn((time * 2) - d, b + c / 2, c / 2, d);
        }

        #endregion

        #region Quartic

        /// <summary>
        /// Easing equation function for a quartic (t^4) easing out: 
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float QuartEaseOut(float time, float b, float c, float d)
        {
            return -c * ((time = time / d - 1) * time * time * time - 1) + b;
        }

        /// <summary>
        /// Easing equation function for a quartic (t^4) easing in: 
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float QuartEaseIn(float time, float b, float c, float d)
        {
            return c * (time /= d) * time * time * time + b;
        }

        /// <summary>
        /// Easing equation function for a quartic (t^4) easing in/out: 
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float QuartEaseInOut(float time, float b, float c, float d)
        {
            if ((time /= d / 2) < 1)
            {
                return c / 2 * time * time * time * time + b;
            }

            return -c / 2 * ((time -= 2) * time * time * time - 2) + b;
        }

        /// <summary>
        /// Easing equatimeion function for a quartic (t^4) easing out/in: 
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float QuartEaseOutIn(float time, float b, float c, float d)
        {
            if (time < d / 2)
            {
                return QuartEaseOut(time * 2, b, c / 2, d);
            }

            return QuartEaseIn((time * 2) - d, b + c / 2, c / 2, d);
        }

        #endregion

        #region Quintic

        /// <summary>
        /// Easing equation function for a quintic (t^5) easing out: 
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float QuintEaseOut(float time, float b, float c, float d)
        {
            return c * ((time = time / d - 1) * time * time * time * time + 1) + b;
        }

        /// <summary>
        /// Easing equation function for a quintic (t^5) easing in: 
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float QuintEaseIn(float time, float b, float c, float d)
        {
            return c * (time /= d) * time * time * time * time + b;
        }

        /// <summary>
        /// Easing equation function for a quintic (t^5) easing in/out: 
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float QuintEaseInOut(float time, float b, float c, float d)
        {
            if ((time /= d / 2) < 1)
            {
                return c / 2 * time * time * time * time * time + b;
            }

            return c / 2 * ((time -= 2) * time * time * time * time + 2) + b;
        }

        /// <summary>
        /// Easing equation function for a quintic (t^5) easing in/out: 
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float QuintEaseOutIn(float time, float b, float c, float d)
        {
            if (time < d / 2)
            {
                return QuintEaseOut(time * 2, b, c / 2, d);
            }

            return QuintEaseIn((time * 2) - d, b + c / 2, c / 2, d);
        }

        #endregion

        #region Elastic

        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing out: 
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float ElasticEaseOut(float time, float b, float c, float d)
        {
            if ((time /= d) == 1)
            {
                return b + c;
            }

            var p = d * .3f;
            var s = p / 4;

            return (c * MathF.Pow(2, -10 * time) * MathF.Sin((time * d - s) * (2 * MathF.PI) / p) + c + b);
        }

        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing in: 
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float ElasticEaseIn(float time, float b, float c, float d)
        {
            if ((time /= d) == 1)
            {
                return b + c;
            }

            var p = d * .3f;
            var s = p / 4;

            return -(c * MathF.Pow(2, 10 * (time -= 1)) * MathF.Sin((time * d - s) * (2 * MathF.PI) / p)) + b;
        }

        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing in/out: 
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float ElasticEaseInOut(float time, float b, float c, float d)
        {
            if ((time /= d / 2f) == 2f)
            {
                return b + c;
            }

            var p = d * (.3f * 1.5f);
            var s = p / 4;

            if (time < 1)
            {
                return -.5f * (c * MathF.Pow(2, 10 * (time -= 1)) * MathF.Sin((time * d - s) * (2 * MathF.PI) / p)) + b;
            }

            return c * MathF.Pow(2, -10 * (time -= 1)) * MathF.Sin((time * d - s) * (2 * MathF.PI) / p) * .5f + c + b;
        }

        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing out/in: 
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="time">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float ElasticEaseOutIn(float time, float b, float c, float d)
        {
            if (time < d / 2)
            {
                return ElasticEaseOut(time * 2, b, c / 2, d);
            }

            return ElasticEaseIn((time * 2) - d, b + c / 2, c / 2, d);
        }

        #endregion

        public static class Bounce
        {
            /// <summary>
            /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out: 
            /// decelerating from zero velocity.
            /// </summary>
            /// <param name="time">Current time in seconds.</param>
            /// <param name="b">Starting value.</param>
            /// <param name="c">Final value.</param>
            /// <param name="d">Duration of animation.</param>
            /// <returns>The correct value.</returns>
            public static float EaseOut(float time, float b, float c, float d)
            {
                if ((time /= d) < (1 / 2.75f))
                {
                    return c * (7.5625f * time * time) + b;
                }

                if (time < (2 / 2.75f))
                {
                    return c * (7.5625f * (time -= (1.5f / 2.75f)) * time + .75f) + b;
                }

                if (time < (2.5 / 2.75))
                {
                    return c * (7.5625f * (time -= (2.25f / 2.75f)) * time + .9375f) + b;
                }

                return c * (7.5625f * (time -= (2.625f / 2.75f)) * time + .984375f) + b;
            }

            /// <summary>
            /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing in: 
            /// accelerating from zero velocity.
            /// </summary>
            /// <param name="time">Current time in seconds.</param>
            /// <param name="b">Starting value.</param>
            /// <param name="c">Final value.</param>
            /// <param name="d">Duration of animation.</param>
            /// <returns>The correct value.</returns>
            public static float EaseIn(float time, float b, float c, float d)
            {
                return c - EaseOut(d - time, 0, c, d) + b;
            }

            /// <summary>
            /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing in/out: 
            /// acceleration until halfway, then deceleration.
            /// </summary>
            /// <param name="time">Current time in seconds.</param>
            /// <param name="b">Starting value.</param>
            /// <param name="c">Final value.</param>
            /// <param name="d">Duration of animation.</param>
            /// <returns>The correct value.</returns>
            public static float EaseInOut(float time, float b, float c, float d)
            {
                if (time < d / 2)
                {
                    return EaseIn(time * 2, 0, c, d) * .5f + b;
                }
                else
                {
                    return EaseOut(time * 2 - d, 0, c, d) * .5f + c * .5f + b;
                }
            }

            /// <summary>
            /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out/in: 
            /// deceleration until halfway, then acceleration.
            /// </summary>
            /// <param name="time">Current time in seconds.</param>
            /// <param name="b">Starting value.</param>
            /// <param name="c">Final value.</param>
            /// <param name="d">Duration of animation.</param>
            /// <returns>The correct value.</returns>
            public static float EaseOutIn(float time, float b, float c, float d)
            {
                if (time < d / 2)
                {
                    return EaseOut(time * 2, b, c / 2, d);
                }

                return EaseIn((time * 2) - d, b + c / 2, c / 2, d);
            }

        }

        public static class Back
        {
            /// <summary>
            /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing out: 
            /// decelerating from zero velocity.
            /// </summary>
            /// <param name="time">Current time in seconds.</param>
            /// <param name="b">Starting value.</param>
            /// <param name="c">Final value.</param>
            /// <param name="d">Duration of animation.</param>
            /// <returns>The correct value.</returns>
            public static float EaseOut(float time, float b, float c, float d)
            {
                return c * ((time = time / d - 1) * time * ((1.70158f + 1) * time + 1.70158f) + 1) + b;
            }

            /// <summary>
            /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing in: 
            /// accelerating from zero velocity.
            /// </summary>
            /// <param name="time">Current time in seconds.</param>
            /// <param name="b">Starting value.</param>
            /// <param name="c">Final value.</param>
            /// <param name="d">Duration of animation.</param>
            /// <returns>The correct value.</returns>
            public static float EaseIn(float time, float b, float c, float d)
            {
                return c * (time /= d) * time * ((1.70158f + 1) * time - 1.70158f) + b;
            }

            /// <summary>
            /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing in/out: 
            /// acceleration until halfway, then deceleration.
            /// </summary>
            /// <param name="time">Current time in seconds.</param>
            /// <param name="b">Starting value.</param>
            /// <param name="c">Final value.</param>
            /// <param name="d">Duration of animation.</param>
            /// <returns>The correct value.</returns>
            public static float EaseInOut(float time, float b, float c, float d)
            {
                var s = 1.70158f;
                if ((time /= d / 2) < 1)
                {
                    return c / 2 * (time * time * (((s *= (1.525f)) + 1) * time - s)) + b;
                }

                return c / 2 * ((time -= 2) * time * (((s *= (1.525f)) + 1) * time + s) + 2) + b;
            }

            /// <summary>
            /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing out/in: 
            /// deceleration until halfway, then acceleration.
            /// </summary>
            /// <param name="time">Current time in seconds.</param>
            /// <param name="b">Starting value.</param>
            /// <param name="c">Final value.</param>
            /// <param name="d">Duration of animation.</param>
            /// <returns>The correct value.</returns>
            public static float EaseOutIn(float time, float b, float c, float d)
            {
                if (time < d / 2)
                {
                    return EaseOut(time * 2, b, c / 2, d);
                }

                return EaseIn((time * 2) - d, b + c / 2, c / 2, d);
            }
        }
    }
}