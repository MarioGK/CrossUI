﻿using CrossUI.SFML.Graphics;
using CrossUI.SFML.System;
using SFML.Graphics;

namespace CrossUI.Objects.UI
{
    public class Label : BaseUIObject
    {
        public Label(string id, Vector2f position) : base(id, position)
        {
        }

        internal override void Draw(ref RenderWindow window)
        {
            throw new System.NotImplementedException();
        }

        internal override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}