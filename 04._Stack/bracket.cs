using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._Stack
{
    internal class bracket              // 괄호문제 구현 맞으면 올바른 괄호면 트루 아니면 폴스 반환
    {
        Stack<string> stack= new Stack<string>();
        
        public bool brackets(string text)
        {
            string[] str = new string[text.Length];
            for(int i=0; i<text.Length; i++)
            {
                str[i] = text[i].ToString();
            }

            for(int i=0; i<str.Length; i++)
            {
                switch(str[i])
                {
                    case "[":
                    case "(":
                    case "{":
                        stack.Push(str[i]);
                        break;
                    case "]":
                        if (stack.Peek() == "[")
                        {
                            stack.Pop();
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    case "}":
                        if (stack.Peek() == "{")
                        {
                            stack.Pop();
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    case ")":
                        if (stack.Peek() == "(")
                        {
                            stack.Pop();
                            break;
                        }
                        else
                        {
                            return false;
                        }
                }
            }
            if (stack.Count() == 0) return true;
            else return false;
        }
    }

}
