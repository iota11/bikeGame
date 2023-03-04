namespace Dreamteck
{
    using System;
    using UnityEngine;

    [Serializable]
    public abstract class MinMaxBase<T>
    {
        [SerializeField] protected T _min;
        [SerializeField] protected T _max;

        public T min => this._min;

        public T max => this._max;

        public abstract T Lerp(float t);

        public abstract T Random();
    }
}