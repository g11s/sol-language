using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Entities
{
    public static class ReservedWords
    {
        public static Dictionary<string, TokenType?> Keywords {
            get
            {
                var keywords = new Dictionary<string, TokenType?>();

                keywords.Add("and", TokenType.AND);
                keywords.Add("class", TokenType.CLASS);
                keywords.Add("else", TokenType.ELSE);
                keywords.Add("false", TokenType.FALSE);
                keywords.Add("for", TokenType.FOR);
                keywords.Add("fun", TokenType.FUN);
                keywords.Add("if", TokenType.IF);
                keywords.Add("nil", TokenType.NIL);
                keywords.Add("or", TokenType.OR);
                keywords.Add("print", TokenType.PRINT);
                keywords.Add("return", TokenType.RETURN);
                keywords.Add("super", TokenType.SUPER);
                keywords.Add("this", TokenType.THIS);
                keywords.Add("true", TokenType.TRUE);
                keywords.Add("var", TokenType.VAR);
                keywords.Add("while", TokenType.WHILE);

                return keywords;
            }
        }
    }
}
