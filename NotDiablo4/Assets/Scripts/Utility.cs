using UnityEngine;


namespace NotDiablo4
{
    public class Utility
    {
        public static Vector3 CartesianToIsometric(Vector3 cartesian)
        {
            Vector3 isometric = new Vector3();

            isometric.x =   cartesian.x + cartesian.y;
            isometric.y = (-cartesian.x + cartesian.y) * 0.5f;

            return isometric;
        }

        public static Vector3 IsometricToCartesian(Vector3 isometric)
        {
            Vector3 cartesian = new Vector3();

            cartesian.x = (2.0f * -isometric.y + isometric.x) * 0.5f;
            cartesian.y = (2.0f *  isometric.y + isometric.x) * 0.5f;

            return cartesian;
        }

        //rotates movement input to match intuitive 'wasd' directions
        //use when preparing to move isometrically but want 'wasd' keys to move in cartesian directions
        public static Vector3 RotateMovementInput(Vector3 directionInput)
        {
            directionInput = Quaternion.AngleAxis(45, Vector3.forward) * directionInput;

            //manually round the rotation results because unity inconsistently rounds the results
            directionInput.x = (float) System.Math.Round(directionInput.x, 6);
            directionInput.y = (float) System.Math.Round(directionInput.y, 6);

            return directionInput;
        }
    }
}
