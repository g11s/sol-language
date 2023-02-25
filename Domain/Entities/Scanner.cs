using Domain.Business;
using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Scanner
    {
        public string Source { get; set; }
        public List<Token> Tokens = new List<Token>();

        private int start = 0;
        private int current = 0;
        private int line = 1;

        public Scanner(string source)
        {
            Source = source;
        }

        public List<Token> ScanTokens()
        {
            while (!IsAtEnd())
            {
                start = current;
                RecognizeToken();
            }

            Tokens.Add(new Token(TokenType.EOF, "", null, line));
            return Tokens;
        }

        private bool Match(char expected)
        {
            if (IsAtEnd()) return false;
            if (Source[current] != expected) return false;

            NextChar();

            return true;
        }

        private bool IsAtEnd()
        {
            return current >= Source.Length;
        }

        private void RecognizeToken()
        {
            char c = NextChar();

            switch (c)
            {
                case '(': AddToken(TokenType.LEFT_PAREN); break;
                case ')': AddToken(TokenType.RIGHT_PAREN); break;
                case '{': AddToken(TokenType.LEFT_BRACE); break;
                case '}': AddToken(TokenType.RIGHT_BRACE); break;
                case ',': AddToken(TokenType.COMMA); break;
                case '.': AddToken(TokenType.DOT); break;
                case '-': AddToken(TokenType.MINUS); break;
                case '+': AddToken(TokenType.PLUS); break;
                case ';': AddToken(TokenType.SEMICOLON); break;
                case '*': AddToken(TokenType.STAR); break;
                case '!':
                    AddToken(Match('=') ? TokenType.BANG_EQUAL : TokenType.BANG);
                    break;
                case '=':
                    AddToken(Match('=') ? TokenType.EQUAL_EQUAL : TokenType.EQUAL);
                    break;
                case '<':
                    AddToken(Match('=') ? TokenType.LESS_EQUAL : TokenType.LESS);
                    break;
                case '>':
                    AddToken(Match('=') ? TokenType.GREATER_EQUAL : TokenType.GREATER);
                    break;
                case '/':
                    if (Match('/'))
                    {
                        while (GetChar() != '\n' && !IsAtEnd()) NextChar();
                    }
                    else
                    {
                        AddToken(TokenType.SLASH);
                    }
                    break;
                case ' ':
                case '\r':
                case '\t':
                    // Ignore whitespace.
                    break;
                case '\n':
                    line++;
                    break;
                case '"': AddString(); break;
                default:
                    if (IsDigit(c))
                    {
                        Number();
                    }
                    else if (IsAlpha(c))
                    {
                        Identifier();
                    }
                    else
                    {
                        ErrorHandling.Error(line, "Unexpected character.");
                    }
                    
                    break;
            }
        }

        private void Identifier()
        {
            while (IsAlphaNumeric(GetChar())) NextChar();

            string text = Source.Substring(start, current - start);
            TokenType? type = null;
            ReservedWords.Keywords.TryGetValue(text, out type);

            if (type == null) type = TokenType.IDENTIFIER;
            AddToken(type.GetValueOrDefault());
        }

        private bool IsAlpha(char c)
        {
            return (c >= 'a' && c <= 'z') ||
                   (c >= 'A' && c <= 'Z') ||
                    c == '_';
        }

        private bool IsAlphaNumeric(char c)
        {
            return IsAlpha(c) || IsDigit(c);
        }

        private bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        private void Number()
        {
            while (IsDigit(GetChar())) NextChar();

            // Look for a fractional part.
            if (GetChar() == '.' && IsDigit(GetNextChar()))
            {
                // Consume the "."
                NextChar();

                while (IsDigit(GetChar())) NextChar();
            }

            AddToken(TokenType.NUMBER, double.Parse(Source.Substring(start, current - start)));
        }

        private char GetChar()
        {
            if (IsAtEnd()) return '\0';
            return Source[current];
        }

        private char GetNextChar()
        {
            if (IsAtEnd()) return '\0';
            return Source[current + 1];
        }

        private char NextChar()
        {
            if (IsAtEnd()) return '\0';
            return Source[current++];
        }

        private void AddToken(TokenType type)
        {
            AddToken(type, null);
        }

        private void AddToken(TokenType type, dynamic literal)
        {
            string text = Source.Substring(start, current - start);
            Token token = new Token(type, text, literal, line);
            Tokens.Add(token);
        }

        private void AddString() 
        {
            while (GetChar() != '"' && !IsAtEnd()) 
            {
                if (GetChar() == '\n')
                {
                    line++;
                }
               NextChar();
            }

            if (IsAtEnd()) {
              ErrorHandling.Error(line, "Unterminated string.");
              return;
            }

            NextChar();

            string value = Source.Substring(start + 1, current - start - 2);

            AddToken(TokenType.STRING, value);
        }
    }
}
