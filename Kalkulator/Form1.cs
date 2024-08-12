using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Kalkulator : Form
    {
        string str = ""; // Wyświetlany tekst
        string tstr = ""; // tekst pozwalajacy na dodanie wiekszej liczby
        List<string> tabOfElement = new List<string>(); // tablica przetrzymujaca elementy wciskane przez uzytkownika

        public Kalkulator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // ( button
        {
            if (!checkLength())
            {
                return;
            }

            if (str == "") // można dać nawias na poczatku
            {
                str += leftBracket.Text;
                tabOfElement.Add(leftBracket.Text);
                resultLabel.Text = str;
            }

            char lastChar = str[str.Length - 1];
            if(lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/') // przed postawieniem nawiasu musi byc znak
            {
                str += leftBracket.Text;
                tabOfElement.Add(leftBracket.Text);
                resultLabel.Text = str;
            }
        }

        private void button2_Click(object sender, EventArgs e) // ) button
        {
            if (!checkLength())
            {
                return;
            }

            if (BasicFunctions.countElement(str, '(') <= BasicFunctions.countElement(str, ')')) // nie można dać nawiasu prawego przed dodaniem lewego
            {
                return;
            }

            if (str[str.Length - 1] == '(' || str[str.Length - 1] == '-' || 
                str[str.Length - 1] == '+' || str[str.Length - 1] == '*' ||
                str[str.Length - 1] == '/')
            {
                return;
            }

            str += rightBracket.Text;
            tabOfElement.Add(tstr);
            tstr = "";
            tabOfElement.Add(rightBracket.Text);
            resultLabel.Text = str;
        }

        private void number7_Click(object sender, EventArgs e)
        {
            if (!isAllowedPutNumber())
            {
                return;
            }
            
            if (checkLength())
            {
                addExpression(number7.Text);
            }
        }

        private void number8_Click(object sender, EventArgs e)
        {
            if (!isAllowedPutNumber())
            {
                return;
            }

            if (checkLength())
            {
                addExpression(number8.Text);
            }
        }

        private void number9_Click(object sender, EventArgs e)
        {
            if (!isAllowedPutNumber())
            {
                return;
            }

            if (checkLength())
            {
                addExpression(number9.Text);
            }
        }

        private void number4_Click(object sender, EventArgs e)
        {
            if (!isAllowedPutNumber())
            {
                return;
            }

            if (checkLength())
            {
                addExpression(number4.Text);
            }
        }

        private void number5_Click(object sender, EventArgs e)
        {
            if (!isAllowedPutNumber())
            {
                return;
            }

            if (checkLength())
            {
                addExpression(number5.Text);
            }
        }

        private void number6_Click(object sender, EventArgs e)
        {
            if (!isAllowedPutNumber())
            {
                return;
            }

            if (checkLength())
            {
                addExpression(number6.Text);
            }  
        }

        private void number1_Click(object sender, EventArgs e)
        {
            if (!isAllowedPutNumber())
            {
                return;
            }

            if (checkLength())
            {
                addExpression(number1.Text);
            }   
        }

        private void number2_Click(object sender, EventArgs e)
        {
            if (!isAllowedPutNumber())
            {
                return;
            }

            if (checkLength())
            {
                addExpression(number2.Text);
            }
        }

        private void number3_Click(object sender, EventArgs e)
        {
            if (!isAllowedPutNumber())
            {
                return;
            }

            if (checkLength())
            {
                addExpression(number3.Text);
            }
        }

        private void number0_Click(object sender, EventArgs e)
        {
            if (!isAllowedPutNumber())
            {
                return;
            }

            if (checkLength())
            {
                addExpression(number0.Text);
            }
        }

        private void commaButton_Click(object sender, EventArgs e)
        {
            if (checkComa() && checkLength())
            {
                addExpression(commaButton.Text);
            }  
        }

        private void subtractionButton_Click(object sender, EventArgs e)
        {
            if (!checkLength())
            {
                return;
            }

            if (tstr == "-") //  zabezpiecza przed wyjatkiem dodania dwa razy liczby ujemnej i powstawaniu np : (--(- ...
            {
                return;
            }

            if (tstr == "" && isAllowedPutSubtraction()) // Umożliwia tworzenie liczb ujemnych
            {
                str += "(";
                tabOfElement.Add(leftBracket.Text);
                str += subtractionButton.Text;
                tstr += subtractionButton.Text;
                resultLabel.Text = str;
            }
            else if (!isAllowedOperation()) // zabezpiecza przed takimi sytuacjami ,-
            {
                return;
            }
            else // Tutaj wykonuje się linijka kodu, ktora odpowiada za operacje odejmowania
            {
                str += subtractionButton.Text;
                if (tstr != "")
                {
                    tabOfElement.Add(tstr);
                }
                tabOfElement.Add(subtractionButton.Text);
                tstr = "";
                resultLabel.Text = str;
            }    
        }

        private void additionButton_Click(object sender, EventArgs e)
        {
            if (!checkLength() || !isAllowedOperation())
            {
                return;
            }
            str += additionButton.Text;
            if (tstr != "")
            {
                tabOfElement.Add(tstr);
            }
            tabOfElement.Add(additionButton.Text);
            tstr = "";
            resultLabel.Text = str;
        }

        private void divisionButton_Click(object sender, EventArgs e)
        {
            if (!checkLength() || !isAllowedOperation())
            {
                return;
            }
            str += divisionButton.Text;
            if (tstr != "")
            {
                tabOfElement.Add(tstr);
            }
            tabOfElement.Add(divisionButton.Text);
            tstr = "";
            resultLabel.Text = str;
        }

        private void multiplicationButton_Click(object sender, EventArgs e)
        {
            if (!checkLength() || !isAllowedOperation())
            {
                return;
            }
            str += multiplicationButton.Text;
            if (tstr != "")
            {
                tabOfElement.Add(tstr);
            }
            tabOfElement.Add(multiplicationButton.Text);
            tstr = "";
            resultLabel.Text = str;
        }

        private void button4_Click(object sender, EventArgs e) // C button
        {
            str = "";
            tstr = "";
            tabOfElement.Clear();
            resultLabel.Text = str;
        }

        private void button3_Click(object sender, EventArgs e) // return button
        {
            if(str == "")
            {
                return;
            }

            str = str.Remove(str.Length - 1);
            resultLabel.Text = str;

            if (tstr.Length == 0 && tabOfElement.Any())
            {
                tstr = tabOfElement.Last();
                tstr = tstr.Remove(tstr.Length - 1);
                tabOfElement.Remove(tabOfElement.Last());
            }
            else if (tstr.Length > 0)
            {
                tstr = tstr.Remove(tstr.Length - 1);
            }
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            if (!checkBrackets(tabOfElement))
            {
                return;
            }

            if (!checkEquasion())
            {
                return;
            }

            str = "";
            tabOfElement.Add(tstr);
            tstr = "";
            List<string> onpTab = ActionClass.InfixToRPN(tabOfElement);
            string result = ActionClass.OnpToInf(onpTab);
            if (BasicFunctions.isScientificNotation(result))
            {
                result = BasicFunctions.exponentialNotation(result);
            }
            resultLabel.Text = result;
        }

        private void calculatorBox_Enter(object sender, EventArgs e)
        {

        }

        private void addExpression(string textToAdd)
        {
            str += textToAdd;
            tstr += textToAdd;
            resultLabel.Text = str;
        }

        // Exception

        private bool isAllowedOperation() // Chronimy przed dodawaniem operacji matematycznych po innych operacjach
        {
            if (str.Length == 0) { return false; }
            char lastEl = str[str.Length - 1];
            if (lastEl == '/' || lastEl == '+' || lastEl == '-' || lastEl == '*' || lastEl == ',')
            {
                return false;
            }
            return true;
        }

        private bool isAllowedPutNumber() // Chronimy przed wpisaniem liczby po nawiasie
        {
            if (str.Length == 0) { return true; }
            char lastEl = str[str.Length - 1];
            if (lastEl == ')')
            {
                return false;
            }
            return true;
        }

        private bool isAllowedPutSubtraction() // Chronimy przed wpisaniem (- po nawiasie
        {
            if (str.Length == 0) { return true; }
            char lastEl = str[str.Length - 1];
            if (lastEl == ')')
            {
                return false;
            }
            return true;
        }

        private bool checkLength()
        {
            if (str.Length < 20)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Maksymalna długość wyświetlacza to 20 znaków.");
                return false;
            }
        }

        private bool checkBrackets(List<string> tab)
        {
            if (BasicFunctions.countElement(tab, "(") == BasicFunctions.countElement(tab, ")")) // Zabezpiczami przed inna liczba nawiasów
            {
                return true;
            }
            MessageBox.Show("Coś nie gra z nawiasami.");
            return false;
        }

        private bool checkComa()
        {
            if(tstr.Length == 0 || BasicFunctions.countElement(tstr, ',') > 0 || tstr == "-") // Zabezpiecza przed pojawieniem się samego przecinka, 
            {                                                                                 // wielu przecinków i pojawieniu sie przecinka przy ujemnej wartości
                return false;
            }
            return true;
        }

        private bool checkEquasion()
        {
            if (str.Length == 0) // chroni przed pobraniem elementu w pustym stringu
            {
                return false;
            }

            char lastChar = str[str.Length - 1]; // uniemożliwia rozpoczeciu obliczen gdy jakis z tych znakow jest na koncu stringa
            if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/') 
            {
                return false;
            }
            return true;
        }
    }

    //To jest klasa, dzięki której zamieniamy wyrażenie z postaci infiksowej do postaci post za pomocą odwrotnej notacji polskiej
    public class ActionClass
    {
        static bool IsOperator(string c)
        {
            return c == "+" || c == "-" || c == "*" || c == "/" /*|| c == "^"*/;
        }

        static int Precedence(string op)
        {
            switch (op)
            {
                //case "^":
                //    return 3;
                case "*":
                case "/":
                    return 2;
                case "+":
                case "-":
                    return 1;
                default:
                    return 0;
            }
        }

        public static List<string> InfixToRPN(List<string> expression)
        {
            Stack<string> operatorStack = new Stack<string>();
            List<string> rpnList = new List<string>();

            foreach (string token in expression)
            {
                if (double.TryParse(token, out _))
                {
                    rpnList.Add(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        rpnList.Add(operatorStack.Pop());
                    }
                    operatorStack.Pop(); // Usunięcie "(" ze stosu
                }
                else if (IsOperator(token))
                {
                    while (operatorStack.Count > 0 && Precedence(operatorStack.Peek()) >= Precedence(token))
                    {
                        rpnList.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
            }

            while (operatorStack.Count > 0)
            {
                rpnList.Add(operatorStack.Pop());
            }

            return rpnList;
        }

        public static string OnpToInf(List<string> equasion)
        {
            Stack<string> stack = new Stack<string>();
            double finalResult = 0.0;

            foreach (string num in equasion)
            {
                if (double.TryParse(num, out _))
                {
                    stack.Push(num);
                }
                else
                {
                    double el1 = double.Parse(stack.Pop());
                    double el2 = double.Parse(stack.Pop());
                    switch (num)
                    {
                        case "*":
                            finalResult = el1 * el2;
                            break;
                        case "/":
                            if (el1 == 0)
                            {
                                MessageBox.Show("Nie można dzielić przez 0.");                  // Ochrona prze dzieleniem przez 0
                                return null;
                            }
                            finalResult = el2 / el1;
                            break;
                        case "+":
                            finalResult = el1 + el2;
                            break;
                        case "-":
                            finalResult = el2 - el1;
                            break;
                    }
                    stack.Push(finalResult.ToString());
                }
            }
            return stack.Pop();
        }
    }

    //To jest klasa pomocnicza z podstawowymi funkcjami np do zliczania elementów w tablicy
    public class BasicFunctions
    {
        public static int countElement(List<string> tab, string item)
        {
            int count = 0;
            foreach (string i in tab)
            {
                if (i == item) {  count++; }
            }
            return count;
        }

        public static int countElement(string text, char item)
        {
            int count = 0;
            foreach (char i in text)
            {
                if (i == item) { count++; }
            }
            return count;
        }

        public static bool isScientificNotation(string text)
        {
            if(text == null) 
                return false;
            return text.Contains('e') || text.Contains('E');
        }

        public static string exponentialNotation(string text)
        {
            double number;
            if (double.TryParse(text, out number))
            {
                return string.Format("{0:0.0#} * 10^({1})",
                number / Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(number)))),
                Math.Floor(Math.Log10(Math.Abs(number))));
            }
            else
            {
                return text;
            }
        }           
    }
}
