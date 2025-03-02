using Tokens;

namespace lab{
    public static class Parser{
        public static TreeNode parse(Tokenizer tokenizer){
            Stack<int> stk = new Stack<int>();
            Stack<TreeNode> tree_stk = new Stack<TreeNode>();
            stk.Push(0);
            Token tok = tokenizer.next();
            while(true){
                int currentState = stk.Peek();
                Dictionary<string,ParseAction> row = ParseTable.table[currentState];
                if( !row.ContainsKey(tok.sym) )
                {
                    Console.WriteLine($"At line number {tok.line}:");
                    Console.WriteLine($"Unexpected token {tok.sym} ({tok.lexeme})");
                    Console.WriteLine($"I expected to see one of:");
                    foreach( string sym in row.Keys )
                    {
                        Console.WriteLine($"{sym} ");
                    }
                    Console.WriteLine();
                    Environment.Exit(1);
                }
                ParseAction A = row[tok.sym];
                if(A.action == PAction.SHIFT) {
                    stk.Push(A.num);
                    tree_stk.Push(new TreeNode(tok.sym,tok,-1));
                    tok = tokenizer.next();
                }
                else{
                    //REDUCE
                    if( A.sym == "S'" )
                    {
                        return tree_stk.Pop();
                    }
                    TreeNode n = new TreeNode( A.sym, null, A.productionNumber);
                    for( int i = 0; i < A.num; ++i )
                    {
                        stk.Pop();
                        var c = tree_stk.Pop();
                        n.appendChild(c);
                        //n.children.Prepend<TreeNode>(c);
                        // and set c's parent to n
                        //c.parent = n;
                    }
                    currentState = stk.Peek();
                    stk.Push( ParseTable.table[currentState][A.sym].num );
                    tree_stk.Push(n);
                }
            }

        }
    }
}