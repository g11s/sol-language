using Domain.Enums;

namespace Domain.Entities
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Lexeme { get; set; }
        public dynamic Literal { get; set; }
        public int Line { get; set; }

        public Token(TokenType type, string lexeme, dynamic literal, int line)
        {
            this.Type = type;
            this.Lexeme = lexeme;
            this.Literal = literal;
            this.Line = line;
        }

        public string ToString()
        {
            return $"{this.Type} {this.Lexeme} {this.Literal}";
        }
    }
}
