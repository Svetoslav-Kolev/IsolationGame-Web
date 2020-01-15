using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IsolationGame.Models
{
    public class MatrixViewModel
    {
        private int[,] field;
        public bool playerOneTurn;
        private string playerOneCoordinates;
        private string playerTwoCoordinates;
        public MatrixViewModel(int fieldSize)
        {
           
            this.Field = new int[fieldSize, fieldSize];
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if(i==0 && j == Field.GetLength(1) / 2)
                    {
                        Field[i, j] = 2;
                        PlayerOneCoordinates = i + "_" + j;
                    }
                    else if (i == Field.GetLength(0) -1 && j == Field.GetLength(1) / 2)
                    {
                        Field[i, j] = 3;
                        PlayerTwoCoordinates = i + "_" + j;
                    }
                    else
                    {
                        Field[i, j] = 0;
                    }
                }
            }
           
        }
        public string PlayerOneCoordinates { get; set; }
        public string PlayerTwoCoordinates { get; set; }
        public int[,] Field
        {
            get
            {
                return this.field;
            }
            set
            {
                if(value.GetLength(0) % 2 == 0)
                {
                    throw new ArgumentException("Number is not odd!");
                }
                else
                {
                    this.field = value;
                }
            }
        }

         public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
