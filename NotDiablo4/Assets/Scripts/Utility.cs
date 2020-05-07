using UnityEngine;


namespace NotDiablo4
{
    public class Utility
    {
        public static Vector2 CartesianToIsometric(Vector2 cartesian)
        {
            Vector2 isometric = new Vector2();

            //round for more exactness and whole numbers when moving straight up or down
            cartesian.x = (float) System.Math.Round(cartesian.x, 7);
            cartesian.y = (float) System.Math.Round(cartesian.y, 7);

            isometric.x =   cartesian.x + cartesian.y;
            isometric.y = (-cartesian.x + cartesian.y) * 0.5f;

            return isometric;
        }

        public static Vector2 IsometricToCartesian(Vector2 isometric)
        {
            Vector2 cartesian = new Vector2();

            //round for more exactness and whole numbers when moving straight up or down
            isometric.x = (float) System.Math.Round(isometric.x, 7);
            isometric.y = (float) System.Math.Round(isometric.y, 7);

            cartesian.x = (2.0f * -isometric.y + isometric.x) * 0.5f;
            cartesian.y = (2.0f *  isometric.y + isometric.x) * 0.5f;

            return cartesian;
        }

        //rotate movement input to match intuitive 'wasd' directions but still move isometrically
        //use when preparing to move isometrically but want 'wasd' keys to move in cartesian directions
        public static Vector2 RotateMovementInput(Vector2 movementInput)
        {
            movementInput = Quaternion.AngleAxis(45, Vector3.forward) * movementInput;

            //manually round the rotation results because unity inconsistently rounds diagonal rotations
            movementInput.x = (float) System.Math.Round(movementInput.x, 6);
            movementInput.y = (float) System.Math.Round(movementInput.y, 6);

            return movementInput;
        }
    }
}
