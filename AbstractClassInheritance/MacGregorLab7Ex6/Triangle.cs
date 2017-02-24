using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDemo
{
    class Triangle : GeometricShape
    {
        /* Author:  Johnathan MacGregor
         * Date:    10/20/16
         * Lab:     Ch10Ex6
         * Purpose: Accepts height and width parameters to create a triangle with Area = Width * (Height * .5).
         */
        public Triangle(double height, double width) : base(height, width)
        {
            
        }

        // Implementation of ComputeArea specific to triangles
        public override double ComputeArea()
        {
            return Width * (Height * .5);
        }
    }
}
