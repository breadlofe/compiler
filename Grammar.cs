using System.Diagnostics.SymbolStore;
using System.IO.Compression;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
namespace lab{

    public static class Grammar{
        public static List<Terminal> terminals = new();
        public static HashSet<string> allTerminals = new();
        public static List<Production> productions = new();
        public static HashSet<string> allNonterminals = new();
        public static Dictionary< string, HashSet<string> > first = new();
        public static HashSet<string> nullable = new HashSet<string>();
        public static Dictionary<string, List<Production> > productionsByLHS = new();
        public static void addTerminals( Terminal[] terminals ){
            foreach( var t in terminals ){
                // stopping bug of double counting
                if( allTerminals.Contains( t.sym ) )
                    throw new Exception("DOUBLE COUNT TERMINAL");
                Grammar.terminals.Add(t);
                allTerminals.Add(t.sym);
            }
        }
        public static void addNonTerminals( List<string> nonterminals )
        {
            foreach( var nt in nonterminals)
            {
                allNonterminals.Add( nt );
            }
        }
        public static bool isTerminal( string sym ){
            return allTerminals.Contains(sym);
        }
        public static bool isNonterminal(string sym){
            return allNonterminals.Contains(sym);
        }
        public static int defineProductions(PSpec[] specs){
            //parse stuff out of our pspecs and put it somewhere
            int howMany = productions.Count;
            foreach( var psec in specs ){
                // CLEAN THE STRING (IT IS DIRTY)
                string one_line_please = Regex.Replace(psec.spec, @"\s+", " ");
                string no_trailing_ws_please = Regex.Replace(one_line_please, @"[ \t]+$", String.Empty);
                string word_ends_please = Regex.Replace(no_trailing_ws_please, @"((?<=[A-Za-z0-9'λ])\s(?![|:]))", "%");
                string no_spaces_please = Regex.Replace(word_ends_please, " ", String.Empty);
                //Console.WriteLine(no_spaces_please);
                // PARSE THE STRING (IT DON'T MAKE SENSE)
                int idx = 0;
                bool on_lhs = true;
                string tmp_lhs = "";
                string part_rhs = "";
                List<Production> tmp_prod_list = new();
                List<string> tmp_rhs = new List<string>();
                while( no_spaces_please.Length > idx )
                {
                    char ch = no_spaces_please[idx];
                    if( on_lhs )
                    {
                        if( ch == ':' )
                        {
                            idx += 2;
                            on_lhs = false;
                        }
                        else
                        {
                            idx++;
                            tmp_lhs += ch;
                        }
                    } // ON LEFT HAND SIDE
                    else
                    {
                        if( ch == '%' )
                        {
                            idx++;
                            tmp_rhs.Add( part_rhs ); // assumes there will never be empty production rhs.
                            part_rhs = "";
                        }
                        else if( ch == '|' )
                        {
                            idx++;
                            tmp_rhs.Add( part_rhs ); // assumes there will never be empty production rhs.
                            part_rhs = "";
                            Production mini_prod = new( psec, tmp_lhs, tmp_rhs.ToArray() );
                            productions.Add(mini_prod);
                            tmp_prod_list.Add(mini_prod);
                            tmp_rhs.Clear();
                        }
                        else
                        {
                            idx++;
                            part_rhs += ch;
                        }
                    } // ON RIGHT HAND SIDE
                } // parsing...
                tmp_rhs.Add( part_rhs );
                // FIXME: Causing problems with table reading. HELP!!
                // if(tmp_rhs.Count == 1 && tmp_rhs[0] == "lambda")
                //     tmp_rhs[0] = "";
                Production prod = new( psec, tmp_lhs, tmp_rhs.ToArray() );
                productions.Add(prod);
                tmp_prod_list.Add(prod);
                if( !productionsByLHS.ContainsKey(tmp_lhs) )
                    productionsByLHS.TryAdd(tmp_lhs, tmp_prod_list);
                else
                {
                    foreach( var pr in tmp_prod_list )
                    {
                        productionsByLHS[tmp_lhs].Add(pr);
                    }
                }
            }
            return howMany; // 💀
        }
        public static void check(){
            //check for problems
            foreach( Production p in productions){
                foreach( string sym in p.rhs ){
                    if( !isTerminal(sym) && !isNonterminal(sym) )
                    {
                        if( sym == "" )
                            continue;
                        throw new Exception("Undefined grammar symbol: "+sym + p.ToString());
                    }
                }
            }
        }
        public static void dump(){
            //dump stuff for screen.
            foreach( var p in productions ){
                Console.WriteLine( p );
            }
            Console.WriteLine("");

            // NULLABLE PRINT
            computeNullable();
            string n_str = "Nullable: ";
            int n_count = 0;
            foreach( var n in nullable )
            {
                n_str += n;
                // zMbVaN4mAG0=
                if( n_count < (nullable.Count - 1) )
                    n_str += " , ";
                n_count++;
            }
            Console.WriteLine( n_str );

            computeFirst();
            foreach( var ele in first )
            {
                if( ele.Key != "lambda" && ele.Key != "λ" )
                    Console.WriteLine($"first[{ele.Key}] = {String.Join(" , ", ele.Value)}");
            }
        }
        public static bool allNullable( Production p, HashSet<string> nullable )
        {
            foreach( var sym in p.rhs )
            {
                if( (sym != "lambda") && (sym != "λ") && !nullable.Contains(sym) )
                {
                    return false;
                }
            }
            return true;
        }
        public static void computeNullable()
        {
            bool flag = true;
            while( flag )
            {
                flag = false;
                foreach( var p in productions )
                {
                    //Console.WriteLine("not quite");
                    if( nullable.Contains( p.lhs ) )
                        continue;
                    if( (p.rhs.Length == 0) || allNullable(p, nullable) )
                    {
                        //Console.WriteLine("got here");
                        nullable.Add( p.lhs );
                        flag = true;
                    }
                }
            }
        } // end of computeNullable
        public static void computeFirst()
        {
            bool flag = true;
            foreach( var t in allTerminals )
            {
                first[t] = [t];
            }
            foreach( var n in allNonterminals )
            {
                first[n] = [];
            }
            while( flag )
            {
                flag = false;
                foreach( var p in productions )
                {
                    foreach( var sym in p.rhs )
                    {
                        int sb = first[p.lhs].Count;
                        first[p.lhs].UnionWith(first[sym]);
                        int sa = first[p.lhs].Count;
                        if( sa > sb )
                        {
                            flag = true;
                        }
                        if( !nullable.Contains(sym) )
                            break;
                    }
                }
            }
        }
    } // end class Grammar.
} //end of ns