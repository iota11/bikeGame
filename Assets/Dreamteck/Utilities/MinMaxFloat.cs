namespace Dreamteck
{
    using System;
    using UnityEngine;

    [Serializable]
    public class MinMaxFloat : MinMaxBase<float>
    {
        public override float Lerp(float t) => Mathf.Lerp(this._min, this._max, t);

        public override float Random() => UnityEngine.Random.Range(this._min, this._max);
    }
}