using System.Security.Cryptography;
using Tokens;
namespace lab{
public class lab{
    public static int dump_table( string filename )
    {
        using(var sw = new StreamWriter(filename)){
        int i = 0;
        foreach( var t in ParseTable.table )
        {
            sw.WriteLine($"Row {i}:");
            if(Conflicts.rr_tracker.Keys.Contains(i))
            {
                sw.WriteLine($"Reduce-Reduce conflict in state {i} on symbol {Conflicts.rr_tracker[i]}");
                return 42;
            }
            if(Conflicts.src_tracker.Keys.Contains(i))
                sw.WriteLine($"Shift-Reduce conflict in state {i} on symbol {Conflicts.src_tracker[i]}");
            foreach( var action in t.Keys )
            {
                //t[action].action;
                if( t[action].action.ToString() == "SHIFT" )
                    sw.WriteLine($"\t{action} S {t[action].num}");
                else
                    sw.WriteLine($"\t{action} R {t[action].num} {t[action].sym}");
            }
            i++;
        }; 
        return 0;
        }
    }
    public static void Main(string[] args){
// var root = new TreeNode("sum",-1);
// var sumA = new TreeNode("sum",-1);
// var plusA = new TreeNode( new Token("PLUS","+",1) );
// var num3 = new TreeNode( new Token("NUM","3",1) );
// root.appendChild(sumA);
// root.appendChild(plusA);
// root.appendChild(num3);

// var sumB = new TreeNode("sum",-1);
// var plusB = new TreeNode( new Token("PLUS","+",1) );
// var num2 = new TreeNode( new Token("NUM","2",1) );
// sumA.appendChild(sumB);
// sumA.appendChild(plusB);
// sumA.appendChild(num2);

// var num1 = new TreeNode( new Token("NUM","1",1) );
// sumB.appendChild(num1);

// var fooby = new TreeNode("fooby",-1);
// num1.appendChild(fooby);
// num2.appendChild(new TreeNode("dooby",-1));
// num3.appendChild(new TreeNode("doo",-1));
// fooby.appendChild(new TreeNode("nooby",-1));
// num1.appendChild(new TreeNode("blargh",-1));

// root.print();

// return;


        Terminals.makeAllOfTheTerminals();
        Terminals.makeAllOfTheNonTerminals();
        Productions.makeThem();
        Grammar.check();
        //Grammar.dump();

        if( args.Length == 1 && args[0] == "-g" ){
            Grammar.computeNullable();
            Grammar.computeFirst();
            DFA.makeDFA(); //time consuming
            TableWriter.create();
            return;
        }
        int ec = dump_table("foo.txt");
        if( ec != 0 )
            Environment.Exit(ec);
        //Console.WriteLine("DUMPED DONE");
        //DFA.makeDFA();
        //DFA.dump("foo.txt");
        
        // RENEW LATER V
        // string inp = File.ReadAllText(args[0]);
        // var tokens = new List<Token>();
        // var T = new Tokenizer(inp);
        // TreeNode root = Parser.parse(T);
        // //root.print();
        // root.toJson( new StreamWriter("tree.json") );
        // //Console.WriteLine("done");
        // root.collectClassNames();
    }
}
}