namespace Calculator
{
    internal interface ICalc
    {
        double Add(double a, double b);
        double Sub(double a, double b);
        double Div(double a, double b);
        double Mul(double a, double b);
        void CancelLast();
    }
}
