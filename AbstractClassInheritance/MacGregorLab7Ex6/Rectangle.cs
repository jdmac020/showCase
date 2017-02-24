using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDemo
{
    class Rectangle : GeometricShape
    {
        /* Author:  Johnathan MacGregor
         * Date:    10/20/16
         * Lab:     Ch10Ex6
         * Purpose: Accepts height and width parameters to create a rectangle with Area = Width * Height.
         */
        public Rectangle(double height, double width) : base(height, width)
        {

        }

        // Implementation of ComputeArea specific to rectangles
        public override double ComputeArea()
        {
            return Height * Width;
        }
    }
}
