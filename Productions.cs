using System.Runtime.CompilerServices;


namespace lab{

public class Productions{
    public static void makeThem(){
        Grammar.defineProductions( new PSpec[] {
            //new("S' :: S"),

            new( "S :: braceblock | lambda" ),
            new( "braceblock :: LBRACE stmts RBRACE"),
            new( "stmts :: stmt stmts | lambda" ),
            new( "stmt :: assign | func | cond | loop"),
            new( "assign :: ID EQ NUM SEMI"),
            new( "func :: ID LPAREN RPAREN SEMI" ),
            new( "cond :: IF LPAREN NUM RPAREN braceblock"),
            new( "cond :: IF LPAREN NUM RPAREN braceblock ELSE braceblock"),
            new( "loop :: WHILE LPAREN NUM RPAREN braceblock" )

            // declaring a class
            // new("S :: classdecl | funcdecl"),
            // new("funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI"),
            // new("classdecl :: CLASS ID LBRACE memberdecls RBRACE",
            //     collectClassNames: (TreeNode n) => {
            //         string className = n.children[1].token.lexeme;
            //         Console.WriteLine($"CLASS: {className}");

            //         //Note: If we allowed nested classes, we'd need
            //         //to walk the children of n
            //     }),
            // new("optionalReturn :: lambda | return"),
            // new("return :: COLON TYPE"),
            // new("stmts :: stmt stmts | lambda"),
            // new("stmt :: assign | func | cond | loop"),
            // new("assign :: ID EQ NUM SEMI"),
            // new("func :: ID LPAREN RPAREN SEMI"),
            // new("cond :: IF LPAREN NUM RPAREN braceblock"),
            // new("cond :: IF LPAREN NUM RPAREN braceblock ELSE braceblock"),
            // new("loop :: WHILE LPAREN NUM RPAREN braceblock"),
            // new("braceblock :: LBRACE stmts RBRACE"),
            // new("optionalPdecls :: lambda | arg | arg COMMA pdecls"),
            // new("arg :: ID COLON TYPE"),
            // new("pdecls :: arg | arg COMMA pdecls"),
            // new("memberdecls :: lambda | membervardecl SEMI memberdecls | memberfuncdecl SEMI memberdecls"),
            // new("membervardecl :: VAR ID COLON TYPE"),
            // new("memberfuncdecl :: funcdecl")
        });
    }//end makeThem()
} //end class Productions

} //namespace