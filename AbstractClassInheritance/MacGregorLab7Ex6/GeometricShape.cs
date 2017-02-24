using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDemo
{
    abstract class GeometricShape
    {
        /* Author:  Johnathan MacGregor
         * Date:    10/20/16
         * Lab:     Ch10Ex6
         * Purpose: Parent of all geometic shape classes, establishes properties/constructor/abstract method as per assignment
         */

        public double Height { get; }
        public double Width { get; }
        public double Area { get; }

        public GeometricShape(double height, double width)
        {
            Height = height;
            Width = width;
            Area = ComputeArea();
        }

        // Will be implemented by children per their unique needs and abilities
        public abstract double ComputeArea();
    }
}
