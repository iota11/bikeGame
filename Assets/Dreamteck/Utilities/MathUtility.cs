namespace Dreamteck
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class MathUtility
    {
        public static float ToSignedAngle(float angle)
        {
            if (angle < 0f)
            {
                return angle;
            }
            float count360 = Mathf.Floor(angle / 360f);
            float angle360 = angle - count360 * 360f;
            if (angle360 <= 180f) return angle360;
            return -(180f - (angle360 - 180f));
        }

        public static Vector3 ToSignedEuler(Vector3 euler)
        {
            return new Vector3(ToSignedAngle(euler.x), ToSignedAngle(euler.y), ToSignedAngle(euler.z));
        }

        public static float ClampSignedAngle(float input)
        {
            //float factor = Mathf.Floor(Mathf.Abs(input) / 180f);
            //input -= factor * (360f - Mathf.Abs(input)) * Mathf.Sign(-input);
            if (input > 180f)
            {
                input = -(360f - input);
            }
            else if (input < -180f)
            {
                input = 360f + input;
            }
            return input;
        }

        public static int Clamp0(int num)
        {
            if (num >= 0) return num;

            return 0;
        }
    }

}
