using System.Diagnostics.SymbolStore;
using System.Reflection;
using System.Runtime.ExceptionServices;
using Microsoft.VisualBasic;

namespace lab{

public class ItemSet{
    public HashSet<LRItem> items;
    //private static int counter=0;
    //public readonly int unique;
    // public ItemSet(){
    //     this.unique = counter++;
    // }
    public override int GetHashCode()
    {
        //FIXME?: Write this
        //Console.WriteLine($"The code: {items.GetHashCode()}");
        return 0;
    }
    public override bool Equals(object obj)
    {
        if( Object.ReferenceEquals(obj,null) )
            return false;
        ItemSet S = obj as ItemSet;
        if( Object.ReferenceEquals(S,null) )
            return false;       
        //FIXME?: Write this
        //Console.WriteLine($"{this.items}");
        //Console.WriteLine($"{S.items}");
        //Console.WriteLine(this.items == S.items);
        //Console.WriteLine($"This: {this.items.GetHashCode()}");
        //Console.WriteLine($"Target: {S.items.GetHashCode()}");
        return this.items.SetEquals(S.items);
    }

    public static bool operator==(ItemSet o1, ItemSet o2){
        if( Object.ReferenceEquals(o1, null )){
            return Object.ReferenceEquals(o2,null);
        }
        return o1.Equals(o2);
    }
    public static bool operator!=(ItemSet I1, ItemSet I2){
        return !(I1 == I2);
    }
    public override string ToString()
    {
        var L = new List<string>();
        foreach(var I in this.items ){
            L.Add(I.ToString());
        }
        return String.Join("\n",L.ToArray());
    }

}

public class DFAState{
    private static int counter=0;
    public ItemSet label;
    public readonly int unique;
    public Dictionary<string, DFAState> transitions = new();

    public DFAState(ItemSet label){
        this.label = label;
        this.unique = counter++;
    }
    public override string ToString()
    {
        string r = $"State {this.unique}\n";
        r += this.label;
        r += "---------------\n";
        foreach( string sym in this.transitions.Keys){
            DFAState q = transitions[sym];
            r += $"{sym} -> {q.unique}";
        }
        return r;
    }

}

public static class DFA{
    public static List<DFAState> allStates = new();
    
    public static void dump(string filename){
        using(var sw = new StreamWriter(filename)){

            foreach( DFAState q in allStates ){
                sw.WriteLine($"State {q.unique}");
                foreach( LRItem i in q.label.items )
                {
                    string lookahead = "";
                    foreach( string l in i.lookahead )
                    {
                        lookahead += " ";
                        lookahead += l;
                        //lookahead += " ";
                    }
                    sw.WriteLine($"\t{i} ║{lookahead}");
                }
                sw.WriteLine("\tTransitions:");
                foreach( string k in q.transitions.Keys )
                {
                    sw.WriteLine($"\t\t{k} → {q.transitions[k].unique}");
                }
                // string x = q.label.ToString();
                // x = x.Replace("\n"," ║ $ {q.label.ToString} \n\t");
                // sw.WriteLine($"\t{x}");
            }

        }

    }

    static ItemSet computeClosure(HashSet<LRItem> kernel)
    {
        var s = new HashSet<LRItem>();
        s.UnionWith(kernel);
        bool keeplooping = true;
        while( keeplooping ){
            keeplooping=false;
            HashSet<LRItem> tmp = new();
            foreach(LRItem I in s){
                if( I.dposAtEnd )
                    continue;
                if( !I.dposAtEnd ) {
                string sym = I.symbolAfterDistinguishedPosition;
                if( Grammar.allNonterminals.Contains(sym) && sym != "lambda"){
                    //sym is a nonterminal
                    foreach( Production p in Grammar.productionsByLHS[sym]){
                        var I2 = new LRItem(p,0 );
                        tmp.Add(I2);
                    }
                }
                }
            }
            int sizeBefore= s.Count;
            s.UnionWith(tmp);
            int sizeAfter = s.Count;
            keeplooping = (sizeAfter > sizeBefore);
        }
        var rv = new ItemSet();
        rv.items = s;
        return rv;
    }

    public static bool hasKey(Dictionary< ItemSet , DFAState> map, ItemSet val)
    {
        foreach( var key in map.Keys )
            Console.WriteLine(key);
        return true;
    }

    public static HashSet<string> findFirst( LRItem I )
    {
        HashSet<string> f = new();
        foreach( string sym in I.production.rhs[(I.dpos+1)..^0] )
        {
            f.UnionWith( Grammar.first[sym] );
            if( !Grammar.nullable.Contains(sym) )
            {
                return f;
            }
        }
        // if all of rhs is nullable.
        f.UnionWith(I.lookahead);
        return f;
    }

    static LRItem findItemCreatedByProduction(DFAState Q, Production P)
    {
        foreach(var I in Q.label.items )
        {
            if( I.production == P && I.dpos == 0 )
            {
                return I;
            }
        }
        throw new Exception($"I not found! {P.lhs} ");
    }

    public static LRItem findItemCreatedFromItem( DFAState Q2, LRItem I )
    {
        foreach( LRItem I2 in Q2.label.items )
        {
            if( I.production == I2.production && I.dpos+1 == I2.dpos)
            {
                return I2;
            }
        }
        throw new Exception(" Logic error from findItemCreatedFromItem. ");
    }

    public static void makeDFA(){
        int productionNumber = Grammar.defineProductions(
            new PSpec[] {
                new PSpec("S' :: S")
            }
        ); 

        Dictionary< ItemSet , DFAState> statemap = new();

        Production P = Grammar.productions[productionNumber];
        LRItem I = new LRItem( P, 0);
        I.lookahead.Add("$");
        DFAState startState = new DFAState( 
            computeClosure(
                new HashSet<LRItem>(){I} 
            )
        );    
        allStates.Add(startState);
        statemap[startState.label] = startState;

        var todo = new Stack<DFAState>();
        todo.Push(startState);


        while( todo.Count > 0 ){
            DFAState q = todo.Pop();
            var tr = getOutgoingTransitions(q);
            foreach(string sym in tr.Keys){
                var lbl = computeClosure(tr[sym]);
                //Console.WriteLine(!statemap.ContainsKey(lbl));
                Console.WriteLine($"-----------");
                //hasKey(statemap, lbl);
                //Console.WriteLine($"Target: {statemap.GetHashCode()}");
                if( !statemap.ContainsKey(lbl)){
                    var q2 = new DFAState(lbl);
                    todo.Push(q2);
                    statemap[q2.label] = q2;
                    allStates.Add(q2);
                }
                if( q.transitions.ContainsKey(sym) )
                    throw new Exception("BUG!");
                q.transitions[sym] = statemap[lbl];
            }
        }

        //PUT LOOKAHEAD STUFF HERE
        bool no_change = true;
        while(no_change)
        {
            no_change = false;
            foreach( DFAState Q in allStates )
            {
                foreach( LRItem Ib in Q.label.items )
                {
                    if( !Ib.dposAtEnd )
                    {
                        string x = Ib.symbolAfterDistinguishedPosition;
                        // FIXME: Causing problems with lambda
                        DFAState Q2 = Q.transitions[x];
                        LRItem Ib2 = findItemCreatedFromItem(Q2, Ib);
                        int prevSize = Ib2.lookahead.Count();
                        Ib2.lookahead.UnionWith(Ib.lookahead);
                        int postSize = Ib2.lookahead.Count();
                        if( postSize > prevSize )
                        {
                            no_change = true;
                        }
                        if( Grammar.allNonterminals.Contains(x) )
                        {
                            HashSet<string> syms = findFirst(Ib);
                            foreach( Production p in Grammar.productionsByLHS[x] )
                            {
                                LRItem Ib3 = findItemCreatedByProduction( Q, p );
                                int prevSize2 = Ib3.lookahead.Count();
                                Ib3.lookahead.UnionWith(syms);
                                int postSize2 = Ib3.lookahead.Count();
                                if( postSize2 > prevSize2 )
                                {
                                    no_change = true;
                                }
                            }
                        }
                    }
                }
            }
        }


    } //makeDFA

    static Dictionary<string, HashSet<LRItem> > getOutgoingTransitions(DFAState q){
        var tr = new Dictionary<string, HashSet<LRItem> >();
        foreach( LRItem I in q.label.items){
            if( !I.dposAtEnd ) {
                string sym = I.symbolAfterDistinguishedPosition;

                if( sym == "lambda" || sym == "λ" )
                {
                    continue;
                }
                
                if( !tr.ContainsKey(sym))
                    tr[sym] = new();

                //we have an outgoing transition on the symbol sym
                LRItem I2 = new LRItem( I.production, I.dpos+1);
                tr[sym].Add( I2 );
            }
        }
        return tr;
    }

} //DFA class


} //namespace lab