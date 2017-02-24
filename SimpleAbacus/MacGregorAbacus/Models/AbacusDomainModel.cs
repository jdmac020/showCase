
namespace MacGregorAbacus.Models
{
    // Domain model of the abacus--set up for addition only between two numbers
    public class AbacusDomainModel
    {
        
        private double FirstNumber { get; set; }
        private double SecondNumber { get; set; }

        public double ResultNumber => DoAddition();

        public AbacusDomainModel(string firstNumber, string secondNumber)
        {
            FirstNumber = double.Parse(firstNumber);
            SecondNumber = double.Parse(secondNumber);

        }

        private double DoAddition()
        {
            return FirstNumber + SecondNumber;
        }
    }
}