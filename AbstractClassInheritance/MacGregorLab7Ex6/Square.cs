using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDemo
{
    class Square : Rectangle
    {
        /* Author:  Johnathan MacGregor
         * Date:    10/20/16
         * Lab:     Ch10Ex6
         * Purpose: Accepts a length parameter passed to the rectangle constructor twice to create a rectangle with Area = Width * Height.
         * 
         * Note constructor only requires 1 measurement, as it can be passed to the Rectangle constructor as both height and width
         * Also note ComputeArea implemented by Rectangle will also accurately calculate the area for squares. 
         */
        public Square(double length) : base(length, length)
        {

        }
        
    }
}
