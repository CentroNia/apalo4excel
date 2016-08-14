 /* 
 *
 * Copyright (C) 2006-2011 Jedox AG
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms of the GNU General Public License (Version 2) as published
 * by the Free Software Foundation at http://www.gnu.org/copyleft/gpl.html.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
 * more details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 59 Temple
 * Place, Suite 330, Boston, MA 02111-1307 USA
 *
 * You may obtain a copy of the License at
 *
 * <a href="http://www.jedox.com/license_palo_bi_suite.txt">
 *   http://www.jedox.com/license_palo_bi_suite.txt
 * </a>
 *
 * If you are developing and distributing open source applications under the
 * GPL License, then you are free to use Palo under the GPL License.  For OEMs,
 * ISVs, and VARs who distribute Palo with their products, and do not license
 * and distribute their source code under the GPL, Jedox provides a flexible
 * OEM Commercial License.
 *
 * \author
 * 
 *
 */
using System;
using System.Collections.Generic;
using System.Text;
using JControls;

namespace JParser
{
    public class ParseException : FormatException
    {
        private int pos;

        public int Position
        {
            get { return pos; }
        }

        public ParseException(string message, int pos)
            : base(message)
        {
            this.pos = pos;
        }
    }

    public class JParser
    {
        public enum Token
        {
            NUMBER, ID, OP, STRING, COMMA, LEFTPAR, RIGHTPAR,
            LEFTBR, RIGHTBR, EXCL, COLON, NCCOLON, END
        } ;

        private Token currToken;
        public string currValue;
        private string expression;
        int pos = 0;

        public string String
        {
            get { return expression; }
            set
            {
                expression = value + " ";  // Empty spaces so that we don't fall off over the edge
                // when we query for 2-letter constructs, like "<>", "B:", etc.
            }
        }

        public Token CurrentToken(bool get)
        {
            while (pos < expression.Length && Char.IsWhiteSpace(expression[pos])) pos++;
            if (pos == expression.Length) return (currToken = Token.END);
            switch (expression[pos])
            {
                case '+':
                case '-':
                case '*':
                case '/':
                    currValue = expression.Substring(get ? pos++ : pos, 1);
                    return (currToken = Token.OP);
                case '<':
                    switch (expression[pos + 1])
                    {
                        case '=':
                        case '>':
                            currValue = expression.Substring(pos, 2);
                            pos += get ? 2 : 0;
                            return (currToken = Token.OP);
                        default:
                            currValue = expression.Substring(get ? pos++ : pos, 1);
                            return (currToken = Token.OP);
                    }
                case '=':
                case '>':
                    switch (expression[pos + 1])
                    {
                        case '=':
                            currValue = expression.Substring(pos, 2);
                            pos += get ? 2 : 0;
                            currToken = Token.OP;
                            return currToken;
                        default:
                            currValue = expression.Substring(get ? pos++ : pos, 1);
                            return (currToken = Token.OP);
                    }
                case '!':
                    switch (expression[pos + 1])
                    {
                        case '=':
                            currValue = expression.Substring(pos, 2);
                            pos += get ? 2 : 0;
                            return (currToken = Token.OP);
                        default:
                            currValue = expression.Substring(get ? pos++ : pos, 1);
                            return (currToken = Token.EXCL);
                    }
                case '\'':
                case '"':
                    int b = pos++;
                    while (pos < expression.Length && expression[pos] != expression[b]) pos++;
                    if (pos == expression.Length) throw new ParseException("Unterminated ` " + expression[b] + " `", b);
                    currValue = expression.Substring(b, pos - b + 1);
                    pos++;
                    if (!get) pos = b;
                    return (currToken = Token.STRING);
                case ',':
                    currValue = expression.Substring(get ? pos++ : pos, 1);
                    return (currToken = Token.COMMA);
                case '(':
                    currValue = expression.Substring(get ? pos++ : pos, 1);
                    return (currToken = Token.LEFTPAR);
                case ')':
                    currValue = expression.Substring(get ? pos++ : pos, 1);
                    return (currToken = Token.RIGHTPAR);
                case '[':
                    currValue = expression.Substring(get ? pos++ : pos, 1);
                    return (currToken = Token.LEFTBR);
                case ']':
                    currValue = expression.Substring(get ? pos++ : pos, 1);
                    return (currToken = Token.RIGHTBR);
                case ':':
                    currValue = expression.Substring(get ? pos++ : pos, 1);
                    return (currToken = Token.COLON);
                default:
                    if ((expression.Substring(pos, 2) == "B:") || (expression.Substring(pos, 2) == "C:"))
                    {
                        currValue = expression.Substring(pos, 2);
                        pos += get ? 2 : 0;
                        return (currToken = Token.NCCOLON);
                    }
                    if (Char.IsNumber(expression[pos]))
                    {
                        b = pos++;
                        while (pos < expression.Length && Char.IsNumber(expression[pos])) pos++;
                        currValue = expression.Substring(b, pos - b);
                        if (!get) pos = b;
                        return (currToken = Token.NUMBER);
                    }
                    else if (Char.IsLetter(expression[pos]))
                    {
                        b = pos++;
                        while (pos < expression.Length && (Char.IsLetterOrDigit(expression[pos]) || expression[pos] == '_' || expression[pos] == '.')) pos++;
                        currValue = expression.Substring(b, pos - b);
                        if (!get) pos = b;
                        return (currToken = Token.ID);
                    }
                    else
                        throw new ParseException("Unexpected character ` " + expression[pos] + " `", pos);
            }
        }

        public void ParseRule(RBuilder rb)
        {
            rb.CTarget.SuspendLayout();
            rb.CTarget.SuspendUpdate();
            rb.CTarget.ClearAreaControl();
            try
            {
                LValue(rb.CTarget);
            }
            catch (Exception ex)
            {
                //rb.CTarget.ClearAreaControl();
                throw ex;
            }
            finally
            {
                rb.CTarget.PerformUpdateAll();
                rb.CTarget.ResumeLayout();
                rb.CTarget.PerformLayout();
            }
            if (CurrentToken(true) != Token.OP || currValue != "=")
                throw new ParseException("Expected `=`", pos);
            if (CurrentToken(false) == Token.NCCOLON)
            {
                rb.CPriority = Constants.PriorityFromString(currValue);
                CurrentToken(true);
            }
            else rb.CPriority = CPriority.None;
            Parse(rb.CExpression);
        }

        public void Parse(CExpression cexp)
        {
            cexp.SuspendLayout();
            cexp.SuspendUpdate();
            cexp.RemoveAll();
            try
            {
                Expr(cexp);
                if (pos != expression.Length)
                    throw new ParseException("Parse error", pos);
            }
            catch (Exception ex)
            {
                //cexp.RemoveAll();
                throw ex;
            }
            finally
            {
                cexp.PerformUpdateAll();
                cexp.ResumeLayout();
                cexp.PerformLayout();
            }
        }

        public void Expr(CExpression cexp)
        {
            cexp.SuspendUpdate();
            cexp.Collapse();

            Additive(cexp.CFChooserAt(0));

            for (; ; )
            {
                switch (CurrentToken(false))
                {
                    case Token.OP:
                        CurrentToken(true);
                        cexp.AddOperator(currValue);
                        CFChooser cfc = new CFChooser();
                        cexp.AddCFChooser(cfc);
                        Additive(cfc);
                        break;
                    default:
                        return;
                }
            }
        }

        void LValue(CTarget ct)
        {
            ct.Collapse();

            if (CurrentToken(true) != Token.LEFTBR)
                throw new ParseException("Expected LValue", pos);

            ElemList(ct.AreaControl);
        }

        void Additive(CFChooser cfc)
        {
            cfc.SuspendUpdate();
            cfc.Collapse();

            CurrentToken(true);
            switch (currToken)
            {
                case Token.ID:
                    cfc.FNText = currValue;
                    if (CurrentToken(false) == Token.LEFTPAR)
                    {
                        CurrentToken(true); // Eat '('
                        ArgList(cfc);
                    }
                    break;
                case Token.STRING:
                    cfc.FNText = currValue;
                    break;
                case Token.LEFTPAR:
                    cfc.FNText = Constants.strParen;
                    Expr(cfc.ArgControlAt(0));
                    if (CurrentToken(true) != Token.RIGHTPAR) throw new ParseException("Unmatched ')'", pos);
                    break;
                case Token.LEFTBR:
                    cfc.FNText = Constants.strBrack;
                    ElemList(cfc.AreaControl);
                    break;
                case Token.EXCL:
                    cfc.FNText = Constants.strNot;
                    Additive(cfc.ArgControlAt(0).CFChooserAt(0));
                    break;
                //case Token.NCCOLON:
                //    cfc.FNText = currValue;
                //    Additive(cfc.ArgControlAt(0).CFChooserAt(0));
                //    break;
                case Token.NUMBER:
                    cfc.FNText = currValue;
                    break;
                case Token.END:
                    break;
                default:
                    throw new ParseException("Unexpected token ` " + currValue + " `", pos);
            }
        }

        // Eats up final ')'
        void ArgList(CFChooser cfc)
        {
            int anum = 0;
            if (CurrentToken(false) == Token.RIGHTPAR)
            {
                CurrentToken(true);
                return;                 // Like: NOW()
            }
            for (; ; )
            {
                Expr(cfc.ArgControlAt(anum));
                anum++;
                switch (CurrentToken(true))
                {
                    case Token.COMMA:
                        break;
                    case Token.RIGHTPAR:
                        return;
                    default:
                        throw new ParseException("Unexpected token ` " + currValue + " `", pos);
                }
            }
        }

        // Eats up final ']'
        void ElemList(AreaControl ac)
        {
            int elnum = 0;
            if (CurrentToken(false) == Token.RIGHTBR)
            {
                CurrentToken(true);
                return;
            }
            for (; ; )
            {
                CurrentToken(true);
                switch (currToken)
                {
                    case Token.ID:
                    case Token.STRING:
                    case Token.NUMBER:
                        if (ac.DECount <= elnum)
                            ac.AddDE("",currValue);
                        else
                            ac.DEAt(elnum).ExprValue = currValue;
                        elnum++;
                        break;
                    case Token.RIGHTBR:
                        return;
                    default:
                        throw new ParseException("Unexpected token ` " + currValue + " `",pos);
                }
                if (CurrentToken(false) == Token.COLON)
                {
                    CurrentToken(true);         // Eat ':'
                    CurrentToken(true);         // Get next token
                    switch (currToken)
                    {
                        case Token.ID:
                        case Token.NUMBER:
                        case Token.STRING:
                            ac.DEAt(elnum - 1).ExprValue = ac.DEAt(elnum - 1).ExprValue + ":" + currValue;
                            break;
                        default:
                            throw new ParseException("Unexpected token ` " + currValue + " `", pos);
                    }
                }
                if (CurrentToken(false) == Token.COMMA)
                    CurrentToken(true);                      // Eat ','. Intentionally out of "switch" so that we 
                                                             // catch constructions like "[a,b,,c]"
            }
        }

    }
}

