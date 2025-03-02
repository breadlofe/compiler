using Tokens;

namespace lab {

    public class TreeNode{
        public string sym; // terminal or non-terminal
        public Token token;
        public List<TreeNode> children = new();
        public int productionNumber;
        public TreeNode parent = null;
        Production production
        {
            get {
                if( this.productionNumber >= 0 )
                    return Grammar.productions[this.productionNumber];
                return null;
            }
        }
        public TreeNode(string sym, Token tok, int prod){
            this.sym = sym;
            this.token = tok;
            this.productionNumber = prod;
        }
        // nonterminal node
        public TreeNode(string sym, int prod) : this(sym,null,prod){}
        // terminal node
        public TreeNode(Token tok) : this(tok.sym, tok, -1){}
        public void appendChild(TreeNode n){
            n.parent = this;
            this.children.Insert(0,n);
        }
        public int computeClosure(TreeNode n, int endness)
        {
            if( n.parent != null )
            {
                if( n == n.parent.children[^1] ) // last child
                {
                    return computeClosure( n.parent, endness+1 );
                }
            }
            return endness;
        }
        public void toJson(StreamWriter w, string prefix="")
        {
            using(w)
            {
                jHelper(w, prefix="");
            }

        }
        public void jHelper(StreamWriter w,string prefix=""){
                bool lastChild = this.parent != null && this == this.parent.children[^1];
                bool nonTerm = this.token != null;
                bool lastDude = this.parent != null && this.parent.sym == "S" && lastChild;
                //if this node is the last child
                if( this.parent == null ){
                    //root
                    w.WriteLine("{");
                    w.WriteLine($"  \"sym\" : \"{this.sym}\",");
                    w.WriteLine($"  \"children\" : [");
                } else {
                    // don't really care about last child. If terminal or not. If remainder or not.
                    if( !nonTerm ){
                        w.WriteLine($"{prefix}   {{");
                        w.WriteLine($"{prefix}  \"sym\" : \"{this.sym}\",");
                        w.WriteLine($"{prefix}  \"children\" : [");
                    } else {
                        w.WriteLine($"{prefix}   {{");
                        w.WriteLine($"{prefix}  \"sym\" : \"{this.sym}\",");
                        w.Write($"{prefix}  \"token\" : ");
                        this.token.toJson(w);
                        int endness = computeClosure(this, 0);
                        //w.Write(endness);
                        w.WriteLine(",");
                        w.WriteLine($"{prefix}  \"children\" : [");
                        w.WriteLine($"{prefix}  ]");
                        if ( lastChild )
                        {
                        for(int i = endness; i > 0; i--)
                        {
                            for(int j = 0; j < i; j++)
                                w.Write($"   ");
                            w.WriteLine($"{prefix}}}");
                            for(int j = 0; j < i; j++)
                                w.Write("   ");
                            w.WriteLine($"{prefix}]");
                        }
                        }
                        w.WriteLine($"{prefix}  }}");
                        if( !lastDude )
                            w.WriteLine($"{prefix},");
                    }
                }

                foreach(var c in this.children){
                    if( this.parent == null )
                        c.jHelper(w,"");
                    else {
                        if( lastChild )
                            c.jHelper(w,prefix + "   ");
                        else
                            c.jHelper(w,prefix + "  ");
                    }
                }
        }
        public override string ToString()
        {
            if( this.token == null )
                return this.sym;
            else
                return $"{this.sym} ({this.token.lexeme})";
        }

        public void print(string prefix=""){
                
                string HLINE = "─"; // (Unicode \u2500)
                string VLINE = "│";  //(\u2502)
                string TEE = "├";  //(\u251c)
                string ELL = "└"; // (\u2514) 

                bool lastChild = this.parent != null && this == this.parent.children[^1];
                //if this node is the last child
                if( this.parent == null ){
                    //root
                    Console.WriteLine(this.ToString());
                } else {
                    if( lastChild ){
                        Console.WriteLine(prefix+"  "+ELL+HLINE+this.ToString());
                    } else {
                        Console.WriteLine(prefix+"  "+TEE+HLINE+this.ToString());
                    }
                }

                foreach(var c in this.children){
                    if( this.parent == null )
                        c.print("");
                    else {
                        if( lastChild )
                            c.print(prefix + "   " );
                        else
                            c.print(prefix + "  " + VLINE );
                    }
                }
        } // print
        public void collectClassNames()
        {
            // if thing on left side of ? is not null, get the production's pspec and call cCN.
            this.production?.pspec.collectClassNames(this);
        } // end collectClassNames
    } // end TreeNode
}