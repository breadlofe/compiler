using System.Text.RegularExpressions;
namespace lab{

public class LRItem{
    public readonly Production production;
    public readonly int dpos;
    public HashSet<string> lookahead = new();
    public LRItem(Production production, int dpos){
        this.production = production;
        this.dpos=dpos;
        //this.lookahead.Add("$");
    }

    public string symbolAfterDistinguishedPosition {
        get {
            return this.production.rhs[this.dpos];
        }
    }
    public bool dposAtEnd {
        get{
            return this.dpos == this.production.rhs.Length;
        }
    }

    public override int GetHashCode()
    {
        return this.production.unique ^ (dpos<<16);
    }

    public override bool Equals(object obj)
    {
        if( Object.ReferenceEquals(obj,null) )
            return false;
        LRItem I = obj as LRItem;
        if( Object.ReferenceEquals(I,null) )
            return false;       //obj was not an LRItem
        return this.production.unique == I.production.unique &&
               this.dpos == I.dpos;
    }

    public static bool operator==(LRItem o1, LRItem o2){
        if( Object.ReferenceEquals(o1, null )){
            return Object.ReferenceEquals(o2,null);
        }
        return o1.Equals(o2);
    }
    public static bool operator!=(LRItem o1, LRItem o2){
        return !(o1==o2);
    }
    public override string ToString()
    {
        string start = $"{this.production}";
        //string no_lambda = Regex.Replace(start, @"[lambda]+$", String.Empty);
        string no_lambda = start;
        if( dpos == this.production.rhs.Length )
        {
            return $"{no_lambda}•";
        }
        else
        {
            string no_dot = $"{no_lambda}";
            int sep = no_dot.IndexOf(':') + 3;
            string lhs = no_dot.Substring(0, sep);
            string rhs = no_dot.Substring(sep);


            //string[] t = rhs.Split(this.production.rhs[dpos]);
            string z = "";
            foreach( int i in Enumerable.Range(0, dpos) ) 
            {
                z += $"{this.production.rhs[i]} ";
            }
            int prior = z.Length;
            //Console.WriteLine(t[0].ToString());
            string rv = lhs + rhs.Substring(0,prior) + "•" + rhs.Substring(prior);
            return $"{rv}";
        }
    }
}

}