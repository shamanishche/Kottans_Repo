namespace Matrix.Tests
{
    internal class Size
    {
        public readonly int Height;
        public readonly int Width;
        public bool IsSquare => Width == Height;

        public Size(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Size return false.
            Size s = obj as Size;
            if ((System.Object)s == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Width == s.Width) && (Height == s.Height); ;
        }

        public static bool operator == (Size left, Size right)
        {
            return Equals(left, right);
        }

        public static bool operator != (Size left, Size right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return Width ^ Height;
        }
    }
}