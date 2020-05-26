using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
   public  class Box
    {
        private double length;     
        private double width;
        private double height;


        //Volume = lwh 
        //Lateral Surface Area = 2lh + 2wh
        //Surface Area = 2lw + 2lh + 2wh
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Height = height;
            this.Width = width;
        }
        public double Length { get => this.length;
            private set
            {
                if (value <=0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
             }
        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }
        public double GetSurfaceArea()
        {
            var surfaceArea = 2 * this.length * this.width + 
                2 * this.length * this.height +
                2 * this.width * this.height;
            return surfaceArea;

        }
        //Lateral Surface Area = 2lh + 2wh
        public double GetLeteralSurfaceArea()
        {
            var leteralSurfaceArea = 2 * this.length * this.height +
                2 * this.width * this.height;
            return leteralSurfaceArea;
        }

        public double GetVolume()
        {
           
                var volume = this.length * this.width * this.height;
            return volume;
        }


    }
}
