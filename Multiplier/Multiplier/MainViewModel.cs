
namespace Multiplier
{
    public class MainViewModel : ViewModelBase
    {
        private int firstNumber;
        public int FirstNumber
        {
            get { return firstNumber; }
            set
            {
                firstNumber = value;
                Result = Multiply(FirstNumber, SecondNumber);
                OnPropertyChanged();
            }
        }
        public int Multiply(int first, int second)
        {
            if (first != 0 || second != 0)
            {
                return first * second;
            }
            return 0;
        }
        private int secondNumber;
        public int SecondNumber
        {
            get { return secondNumber; }
            set
            {
                secondNumber = value;
                Result = Multiply(FirstNumber, SecondNumber);
                OnPropertyChanged();
            }
        }
        private int result;
        public int Result
        {
            get { return result; }
            set
            {
				
                result = value;
                OnPropertyChanged();
            }
        }
    }
}