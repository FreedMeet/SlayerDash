﻿using UnityEngine;

namespace Movement
{
    public interface IControllable
    {
        public void Move(Vector2 direction, Rigidbody2D rb);
        public void Dash(Vector2 direction, Rigidbody2D rb);
        public void Rotation(Vector2 direction, Rigidbody2D rb);
    }
}