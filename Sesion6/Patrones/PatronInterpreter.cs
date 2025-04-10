using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Sesion6.Patrones;

public interface IExpression
{
    double Interpret(Dictionary<string, double> context)
}

public class VariableExpression(string name) 
{
    _name = name;
}

public double Interpret(Directory<string, double> context) => 
        context.ContainsKey(_name) ? context(_name) : throw new Exception($"Variable {_name} no definido");

public class SumExpression : IExpresion
{
    private readonly IExpression _left;
    private readonly IExpression _right;    

    public SumExpression(IExpression left, IExpression right) 
    {
        _left = left;
        _right = right;
    }

    public double Interpret(Directory<string, double> context) => 
        _left.Interpret(context) + _right.Interpret(context);

}


public class SubstractExpression : IExpresion
{
    private readonly IExpression _left;
    private readonly IExpression _right;

    public SubstractExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public double Interpret(Directory<string, double> context) =>
        _left.Interpret(context) - _right.Interpret(context);
}

//Creamos el parser
public class Expressionparser
{
    public static IExpression Parse(string input) 
    {
        var tokens = Regex.Split(input, @"(?<=[\}\d])(?=[\+\-\*/])|(?<=[\+\-\*/])");
    }
}

