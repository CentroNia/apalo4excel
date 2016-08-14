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
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Subset.Parser
{
    public class ParserBase
    {
        protected class Range
        {
            public int pos, e;

            public Range() {}
            public Range(int pos, int e) { this.pos = pos; this.e = e; }

            public bool Empty
            {
                get { return pos >= e; }
            }

            public Range Inflate(int d)
            {
                return new Range(this.pos - d, this.e + d );
            }
        }

        String s;
        int pos, e;

        protected void ReadUntil(char c)
        {
            while (pos < e && s[pos] != c)
            {
                pos++;
            }
        }

        protected bool CharInList(char c, params char[] list)
        {
            foreach (char cc in list)
            {
                if (c == cc)
                {
                    return true;
                }
            }
            return false;
        }

        protected void ReadPQUntil(params char[] c)
        {
            bool qopen = false;
            while (pos < e && !CharInList(s[pos], c))
            {
                if (s[pos] == '"')
                    if (!qopen)
                        qopen = true;
                    else if (pos + 1 < e && s[pos + 1] == '"')
                        pos++;
                    else
                        qopen = false;
                pos++;
            }
        }

        protected void SkipWhite()
        {
            while (pos < e && s[pos] == ' ')
            {
                pos++;
            }
        }

        protected bool SkipString(String b)
        {
            SkipWhite();
            if (String.Compare(s, pos, b, 0, b.Length) != 0)
            {
                return false;
            }
            pos += b.Length;
            return true;
        }

        protected String ReadFunctionName()
        {
            int ip = pos;
            ReadUntil('(');
            if (pos == e)
            {
                throw new Exception("Could not read function name!");
            }
            return s.Substring(ip, pos - ip);
        }

        protected Range ReadFnParameter(char c1, char c2)
        {
            SkipWhite();
            List<Char> stack = new List<char>();
            int ip = pos;
            while (pos < e)
            {
                if ((stack.Count == 0) && ((s[pos] == c1) || (s[pos] == c2)))
                {
                    break;
                }

                if ((stack.Count > 0) && (s[pos] == stack[stack.Count - 1]))
                    stack.RemoveAt(stack.Count - 1);
                else if (s[pos] == '"')
                    stack.Add(s[pos]);
                else if (s[pos] == '(')
                    stack.Add(')');
                else if (s[pos] == '{')
                    stack.Add('}');
                pos++;
            }
            if (pos == e)
            {
                throw new Exception("Could not read argument!");
            }
            return new Range(ip, pos);
        }

        protected void ReadFunction(int minp, int maxp, out String fname, out Range[] arguments)
        {            
            fname = ReadFunctionName();
            if (++pos == e)
            {
                throw new Exception("'(' expected!");
            }
            List<Range> args = new List<Range>();
            for (int i = 0; i < maxp; i++)
            {
                if (i + 1 >= minp)
                {
                    args.Add(ReadFnParameter(',', ')'));
                    if (s[pos] == ')')
                    {
                        break;
                    }
                    if (s[pos] == ',')
                    {
                        pos++;
                    }
                }
                else
                {
                    args.Add(ReadFnParameter(',', ','));
                    pos++;
                }
            }
            if ((pos == e) || (s[pos] != ')'))
            {
                throw new Exception("ReadFunction: Expecting ')'");
            }
            pos++;
            arguments = args.ToArray();
        }

        protected String RangeString(Range r)
        {
            return s.Substring(r.pos, r.e-r.pos);
        }

        protected void ProcessRange(Range r)
        {
            pos = r.pos;
            e = r.e;
        }

        protected void ProcessString(String s)
        {
            this.s = s;
            pos = 0;
            e = s.Length;
        }

        protected String Unquote(String s)
        {
            if ((s == null) || (s.Length < 2))
            {
                return s;
            }
            return s.Substring(1, s.Length - 2);
        }

        protected Range Unquote(Range r)
        {
            return new Range(r.pos + 1, r.e - 1);
        }

        protected bool Quoted(String s)
        {
            if ((s == null) || (s.Length < 2))
            {
                return false;
            }
            return s[0] == '"' && s[s.Length - 1] == '"';
        }

        private bool isDelimetedBy(Range r, char left, char right)
        {
            return (r.e > (r.pos + 1)) && (s[r.pos] == left) && (s[r.e - 1] == right);
        }


        private bool isDelimetedBy(Range r, char delim)
        {
            return isDelimetedBy(r, delim, delim);
        }

        protected bool Quoted(Range r)
        {
            return isDelimetedBy(r, '"');
        }

        protected bool ArrayBrackets(Range r)
        {
            return isDelimetedBy(r, '{', '}');
        }

        protected Range[] GetRangeList(Range r, bool quotes, params char[] seps)
        {            
            ProcessRange(r);
            List<Range> list = new List<Range>();
            while (pos < e)
            {
                SkipWhite();
                int ss = pos;
                ReadPQUntil(seps);
                if (pos > ss)
                {
                    Range sbs = new Range(ss, pos);
                    if (quotes)
                    {
                        if (!Quoted(sbs))
                        {
                            throw new Exception("StringArray items must be quoted! (" + RangeString(r) + ")");
                        }
                        else
                        {
                            sbs = Unquote(sbs);
                        }
                    }
                    list.Add(sbs);
                }
                pos++;
            }
            return list.ToArray();
        }

        protected string[] GetStringList(Range r, bool quotes, params char[] seps)
        {

            Range[] rr = GetRangeList(r, quotes, seps);
            String[] l = new String[rr.Length];
            for (int i = 0; i < rr.Length; i++)
            {
                l[i] = RangeString(rr[i]);
            }
            return l;
        }
    }
}
