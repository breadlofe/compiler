using System.Net.Mail;
using System.Reflection;

namespace lab{

public static class TableWriter{
    public static List<string> shift_list = new();
    public static List<string> reduce_list = new();
    public static Dictionary<int, string> src_tracker = new();
    public static Dictionary<int, string> rr_tracker = new();

    public static void create(){
        //create a file called ParseTable.cs which has the parse table

        using( var w = new StreamWriter("ParseTable.cs") ){
            w.WriteLine("namespace lab{");
            w.WriteLine("public static class ParseTable{");
            w.WriteLine("    public static List<Dictionary<string,ParseAction> > table = new() {");

            for(int i=0;i<DFA.allStates.Count;++i){
                w.WriteLine("        // DFA STATE "+i); //index in allStates == state's "unique" number
                w.WriteLine("        new Dictionary<string,ParseAction>(){");
                //shift rules
                DFAState q = DFA.allStates[i];
                foreach( string sym in q.transitions.Keys){
                    w.Write("                ");
                    w.Write("{");
                    w.Write($"\"{sym}\" , ");
                    w.Write($"new ParseAction(PAction.SHIFT, {q.transitions[sym].unique}, null, -1)");
                    w.WriteLine("},");
                    shift_list.Add(sym);
                }
                //reduce rules
                foreach( LRItem I in q.label.items){
                    if( I.dposAtEnd ){
                        w.WriteLine($"            // {I}");
                        foreach( string lookahead in I.lookahead){
                            if( !reduce_list.Contains(lookahead) )
                            {
                                if( !shift_list.Contains(lookahead))
                                {
                                    w.Write($"            ");
                                    w.Write("{");
                                    w.Write($"\"{lookahead}\"");
                                    w.Write(",");
                                    w.Write($"new ParseAction(PAction.REDUCE, {I.production.rhs.Length}, \"{I.production.lhs}\", {I.production.unique})");
                                    w.WriteLine("},");
                                    reduce_list.Add(lookahead);
                                }
                                else
                                {
                                    //Console.WriteLine($"FU {i} {lookahead}");
                                    src_tracker.Add(i,lookahead);
                                }
                            }
                            else
                                rr_tracker.Add(i,lookahead);
                                //throw new Exception($"Reduce-reduce conflict on {lookahead} on state {i}");
                        }
                    }
                }
                w.WriteLine("        }, //end state");
                shift_list.Clear();
                reduce_list.Clear();
            }

            w.WriteLine("    }; //close the table initializer");
            w.WriteLine("} //close the ParseTable class");
            w.WriteLine("public class Conflicts{");
            w.WriteLine("    public static Dictionary<int, string> src_tracker = new() {");
            foreach( var k in src_tracker.Keys )
            {
                w.WriteLine($"{{ {k},\"{src_tracker[k]}\" }},");
            }
            w.WriteLine("    }; //end of constructor");
            w.WriteLine("    public static Dictionary<int, string> rr_tracker = new() {");
            foreach( var k in rr_tracker.Keys )
            {
                w.WriteLine($"{{ {k},\"{rr_tracker[k]}\" }},");
            }
            w.WriteLine("    }; //end of constructor");
            w.WriteLine("    } //end of conflicts");
            w.WriteLine("} //close the namespace lab thing");
        }
        /*
                new(){      //one of these for each DFA state
                    { "ID" , new(...) },    //one of these for each shift
                    { "ID" , new(...) },    //one of these for each reduction
                }
        */

    }



} //class TableWriter

} //namespace lab