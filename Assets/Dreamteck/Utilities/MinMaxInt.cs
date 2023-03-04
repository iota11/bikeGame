namespace Dreamteck
{
    using System;
    using UnityEngine;

    [Serializable]
    public class MinMaxInt : MinMaxBase<int>
    {
        public override int Lerp(float t) => Mathf.RoundToInt(Mathf.Lerp(this._min, this._max, t));

        public override int Random() => UnityEngine.Random.Range(this._min, this._max);
    }
}