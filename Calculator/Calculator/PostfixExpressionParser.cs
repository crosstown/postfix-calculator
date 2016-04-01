/*Support class to evaluate postfix notation -- Part of calcualtor app

Copyright (c) 2015 Fernando Simon

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class PostfixExpressionParser
    {
        Stack<double> stack = new Stack<double>();
      
        private string str;						// the string to parse
	    private double intermediateResult;                 // the intermediate result of computations

        public PostfixExpressionParser(String str)
        {
           this.str = InfixToPostfixConvert(str);
                     
            this.intermediateResult = 0;                // initilize the intermediate result to 0
        }
        private bool isOperator(string character)
        {
            bool oper;                   // operator boolean (is it or isn't it?)

            switch (character)
            {                   // switch statement for operator tests
                case "+":                  
                case "-":
                case "*":
                case "/":
				oper = true;            
                    break;                  // end case statement

                default:					// for anything other than +, -, *, and /
				oper = false;          
                    break;                  // end the case statement
            }                           // end of switch

            return oper;                    // return the operator
        }

        private void compute(double operand1, double operand2, string oper)
        {
            switch (oper) {					// store result of operation in intermediateResult
			case "+":
				this.intermediateResult = operand1 + operand2;
                break;

			case "-":
				this.intermediateResult = operand1 - operand2;
                break;

			case "*":
				this.intermediateResult = operand1 * operand2;
                break;

			case "/":
				this.intermediateResult = operand1 / operand2;
                break;

                default:					// shouldn't ever get this, but it's nice to be clean
				break;
            }                           // end switch statement
        }
        public void parse()
        {
            string[] tokens;
            string token;                       // String variable for the individual token
            double intWrapper;                 // integer wrapper to get a primitive from
            string oper;
     
            double op1, op2;                       // the two operands to compute
            double element;                        // the element to be pushed on the stack
            char[] delimiterChars = { ' ', ',', ':', '\t' }; //not all used
            tokens = str.Split(delimiterChars);
   
            foreach(string s in tokens) {
               
                token = s;
                oper = token;
                if (this.isOperator(oper))
                {                          
                    op2 = stack.Pop();          // pop the last 2 elements from the stack
                    op1 = stack.Pop();
                    this.compute(op1, op2,oper);        // and compute them
                    stack.Push(this.intermediateResult);    // now stick the intermediateResult on the stack
                }
                else
                {                   // not an operator?
                    intWrapper = double.Parse(token);
                                       
                    element = intWrapper;
               
                    stack.Push(element);            // Push that element back onto the stack
                }
            }
        }
        public string InfixToPostfixConvert(string infix)
        {
            string output = null;
            string symbol;
            Stack<string> s = new Stack<string>();
            s.Push("#");
            string[] tokens = infix.Split(' ');
            foreach (string token in tokens)
            {
                symbol = token;
                while (s.Count > 0 && (F(s.Peek()) > G(symbol)))
                {
                    output = output + " " + s.Pop();
                }
                if (s.Count > 0)
                {
                    if (F(s.Peek()) != G(symbol))
                    {
                        s.Push(symbol);
                    }
                    else
                    {
                        s.Pop();
                    }
                }
            }
            while ((s.Peek() != "#"))
            {
                output = output + " " + s.Pop();
            }


            return output.Trim();
        }
        private int F(string symbol)
        {
            switch (symbol)
            {
                case "+":
                case "-": return 2;
                case "*":
                case "/": return 4;
                case "^":
                case "$": return 5;
                case "(": return 0;
                case "#": return -1;
                default: return 8;
            }
        }
        private int G(string symbol)
        {
            switch (symbol)
            {
                case "+":
                case "-": return 1;
                case "*":
                case "/": return 3;
                case "^":
                case "$": return 6;
                case "(": return 9;
                case ")": return 0;
                default: return 7;
            }
        }
        public double evaluate()
        {
            this.parse();                       // parse the string

            return this.intermediateResult;             // return the intermediateResult
        }


    }
}
