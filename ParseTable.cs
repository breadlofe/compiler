namespace lab{
public static class ParseTable{
    public static List<Dictionary<string,ParseAction> > table = new() {
        // DFA STATE 0
        new Dictionary<string,ParseAction>(){
                {"S" , new ParseAction(PAction.SHIFT, 1, null, -1)},
                {"classdecl" , new ParseAction(PAction.SHIFT, 2, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 3, null, -1)},
                {"CLASS" , new ParseAction(PAction.SHIFT, 4, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 5, null, -1)},
        }, //end state
        // DFA STATE 1
        new Dictionary<string,ParseAction>(){
            // S' :: S•
            {"$",new ParseAction(PAction.REDUCE, 1, "S'", 26)},
        }, //end state
        // DFA STATE 2
        new Dictionary<string,ParseAction>(){
            // S :: classdecl•
            {"$",new ParseAction(PAction.REDUCE, 1, "S", 0)},
        }, //end state
        // DFA STATE 3
        new Dictionary<string,ParseAction>(){
            // S :: funcdecl•
            {"$",new ParseAction(PAction.REDUCE, 1, "S", 1)},
        }, //end state
        // DFA STATE 4
        new Dictionary<string,ParseAction>(){
                {"ID" , new ParseAction(PAction.SHIFT, 55, null, -1)},
        }, //end state
        // DFA STATE 5
        new Dictionary<string,ParseAction>(){
                {"ID" , new ParseAction(PAction.SHIFT, 6, null, -1)},
        }, //end state
        // DFA STATE 6
        new Dictionary<string,ParseAction>(){
                {"LPAREN" , new ParseAction(PAction.SHIFT, 7, null, -1)},
        }, //end state
        // DFA STATE 7
        new Dictionary<string,ParseAction>(){
                {"optionalPdecls" , new ParseAction(PAction.SHIFT, 8, null, -1)},
                {"arg" , new ParseAction(PAction.SHIFT, 9, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 10, null, -1)},
        }, //end state
        // DFA STATE 8
        new Dictionary<string,ParseAction>(){
                {"RPAREN" , new ParseAction(PAction.SHIFT, 18, null, -1)},
        }, //end state
        // DFA STATE 9
        new Dictionary<string,ParseAction>(){
                {"COMMA" , new ParseAction(PAction.SHIFT, 13, null, -1)},
            // optionalPdecls :: arg•
            {"RPAREN",new ParseAction(PAction.REDUCE, 1, "optionalPdecls", 17)},
        }, //end state
        // DFA STATE 10
        new Dictionary<string,ParseAction>(){
                {"COLON" , new ParseAction(PAction.SHIFT, 11, null, -1)},
        }, //end state
        // DFA STATE 11
        new Dictionary<string,ParseAction>(){
                {"TYPE" , new ParseAction(PAction.SHIFT, 12, null, -1)},
        }, //end state
        // DFA STATE 12
        new Dictionary<string,ParseAction>(){
            // arg :: ID COLON TYPE•
            {"RPAREN",new ParseAction(PAction.REDUCE, 3, "arg", 19)},
            {"COMMA",new ParseAction(PAction.REDUCE, 3, "arg", 19)},
        }, //end state
        // DFA STATE 13
        new Dictionary<string,ParseAction>(){
                {"pdecls" , new ParseAction(PAction.SHIFT, 14, null, -1)},
                {"arg" , new ParseAction(PAction.SHIFT, 15, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 10, null, -1)},
        }, //end state
        // DFA STATE 14
        new Dictionary<string,ParseAction>(){
            // optionalPdecls :: arg COMMA pdecls•
            {"RPAREN",new ParseAction(PAction.REDUCE, 3, "optionalPdecls", 18)},
        }, //end state
        // DFA STATE 15
        new Dictionary<string,ParseAction>(){
                {"COMMA" , new ParseAction(PAction.SHIFT, 16, null, -1)},
            // pdecls :: arg•
            {"RPAREN",new ParseAction(PAction.REDUCE, 1, "pdecls", 20)},
        }, //end state
        // DFA STATE 16
        new Dictionary<string,ParseAction>(){
                {"pdecls" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"arg" , new ParseAction(PAction.SHIFT, 15, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 10, null, -1)},
        }, //end state
        // DFA STATE 17
        new Dictionary<string,ParseAction>(){
            // pdecls :: arg COMMA pdecls•
            {"RPAREN",new ParseAction(PAction.REDUCE, 3, "pdecls", 21)},
        }, //end state
        // DFA STATE 18
        new Dictionary<string,ParseAction>(){
                {"optionalReturn" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"return" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"COLON" , new ParseAction(PAction.SHIFT, 21, null, -1)},
        }, //end state
        // DFA STATE 19
        new Dictionary<string,ParseAction>(){
                {"LBRACE" , new ParseAction(PAction.SHIFT, 23, null, -1)},
        }, //end state
        // DFA STATE 20
        new Dictionary<string,ParseAction>(){
            // optionalReturn :: return•
            {"LBRACE",new ParseAction(PAction.REDUCE, 1, "optionalReturn", 4)},
        }, //end state
        // DFA STATE 21
        new Dictionary<string,ParseAction>(){
                {"TYPE" , new ParseAction(PAction.SHIFT, 22, null, -1)},
        }, //end state
        // DFA STATE 22
        new Dictionary<string,ParseAction>(){
            // return :: COLON TYPE•
            {"LBRACE",new ParseAction(PAction.REDUCE, 2, "return", 5)},
        }, //end state
        // DFA STATE 23
        new Dictionary<string,ParseAction>(){
                {"stmts" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"stmt" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"assign" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"func" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"cond" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"loop" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"IF" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"WHILE" , new ParseAction(PAction.SHIFT, 32, null, -1)},
        }, //end state
        // DFA STATE 24
        new Dictionary<string,ParseAction>(){
                {"RBRACE" , new ParseAction(PAction.SHIFT, 53, null, -1)},
        }, //end state
        // DFA STATE 25
        new Dictionary<string,ParseAction>(){
                {"stmts" , new ParseAction(PAction.SHIFT, 52, null, -1)},
                {"stmt" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"assign" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"func" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"cond" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"loop" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"IF" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"WHILE" , new ParseAction(PAction.SHIFT, 32, null, -1)},
        }, //end state
        // DFA STATE 26
        new Dictionary<string,ParseAction>(){
            // stmt :: assign•
            {"ID",new ParseAction(PAction.REDUCE, 1, "stmt", 7)},
            {"IF",new ParseAction(PAction.REDUCE, 1, "stmt", 7)},
            {"WHILE",new ParseAction(PAction.REDUCE, 1, "stmt", 7)},
        }, //end state
        // DFA STATE 27
        new Dictionary<string,ParseAction>(){
            // stmt :: func•
            {"ID",new ParseAction(PAction.REDUCE, 1, "stmt", 8)},
            {"IF",new ParseAction(PAction.REDUCE, 1, "stmt", 8)},
            {"WHILE",new ParseAction(PAction.REDUCE, 1, "stmt", 8)},
        }, //end state
        // DFA STATE 28
        new Dictionary<string,ParseAction>(){
            // stmt :: cond•
            {"ID",new ParseAction(PAction.REDUCE, 1, "stmt", 9)},
            {"IF",new ParseAction(PAction.REDUCE, 1, "stmt", 9)},
            {"WHILE",new ParseAction(PAction.REDUCE, 1, "stmt", 9)},
        }, //end state
        // DFA STATE 29
        new Dictionary<string,ParseAction>(){
            // stmt :: loop•
            {"ID",new ParseAction(PAction.REDUCE, 1, "stmt", 10)},
            {"IF",new ParseAction(PAction.REDUCE, 1, "stmt", 10)},
            {"WHILE",new ParseAction(PAction.REDUCE, 1, "stmt", 10)},
        }, //end state
        // DFA STATE 30
        new Dictionary<string,ParseAction>(){
                {"EQ" , new ParseAction(PAction.SHIFT, 46, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 47, null, -1)},
        }, //end state
        // DFA STATE 31
        new Dictionary<string,ParseAction>(){
                {"LPAREN" , new ParseAction(PAction.SHIFT, 40, null, -1)},
        }, //end state
        // DFA STATE 32
        new Dictionary<string,ParseAction>(){
                {"LPAREN" , new ParseAction(PAction.SHIFT, 33, null, -1)},
        }, //end state
        // DFA STATE 33
        new Dictionary<string,ParseAction>(){
                {"NUM" , new ParseAction(PAction.SHIFT, 34, null, -1)},
        }, //end state
        // DFA STATE 34
        new Dictionary<string,ParseAction>(){
                {"RPAREN" , new ParseAction(PAction.SHIFT, 35, null, -1)},
        }, //end state
        // DFA STATE 35
        new Dictionary<string,ParseAction>(){
                {"braceblock" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"LBRACE" , new ParseAction(PAction.SHIFT, 37, null, -1)},
        }, //end state
        // DFA STATE 36
        new Dictionary<string,ParseAction>(){
            // loop :: WHILE LPAREN NUM RPAREN braceblock•
            {"ID",new ParseAction(PAction.REDUCE, 5, "loop", 15)},
            {"IF",new ParseAction(PAction.REDUCE, 5, "loop", 15)},
            {"WHILE",new ParseAction(PAction.REDUCE, 5, "loop", 15)},
        }, //end state
        // DFA STATE 37
        new Dictionary<string,ParseAction>(){
                {"stmts" , new ParseAction(PAction.SHIFT, 38, null, -1)},
                {"stmt" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"assign" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"func" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"cond" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"loop" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"IF" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"WHILE" , new ParseAction(PAction.SHIFT, 32, null, -1)},
        }, //end state
        // DFA STATE 38
        new Dictionary<string,ParseAction>(){
                {"RBRACE" , new ParseAction(PAction.SHIFT, 39, null, -1)},
        }, //end state
        // DFA STATE 39
        new Dictionary<string,ParseAction>(){
            // braceblock :: LBRACE stmts RBRACE•
            {"ID",new ParseAction(PAction.REDUCE, 3, "braceblock", 16)},
            {"IF",new ParseAction(PAction.REDUCE, 3, "braceblock", 16)},
            {"WHILE",new ParseAction(PAction.REDUCE, 3, "braceblock", 16)},
            {"ELSE",new ParseAction(PAction.REDUCE, 3, "braceblock", 16)},
        }, //end state
        // DFA STATE 40
        new Dictionary<string,ParseAction>(){
                {"NUM" , new ParseAction(PAction.SHIFT, 41, null, -1)},
        }, //end state
        // DFA STATE 41
        new Dictionary<string,ParseAction>(){
                {"RPAREN" , new ParseAction(PAction.SHIFT, 42, null, -1)},
        }, //end state
        // DFA STATE 42
        new Dictionary<string,ParseAction>(){
                {"braceblock" , new ParseAction(PAction.SHIFT, 43, null, -1)},
                {"LBRACE" , new ParseAction(PAction.SHIFT, 37, null, -1)},
        }, //end state
        // DFA STATE 43
        new Dictionary<string,ParseAction>(){
                {"ELSE" , new ParseAction(PAction.SHIFT, 44, null, -1)},
            // cond :: IF LPAREN NUM RPAREN braceblock•
            {"ID",new ParseAction(PAction.REDUCE, 5, "cond", 13)},
            {"IF",new ParseAction(PAction.REDUCE, 5, "cond", 13)},
            {"WHILE",new ParseAction(PAction.REDUCE, 5, "cond", 13)},
        }, //end state
        // DFA STATE 44
        new Dictionary<string,ParseAction>(){
                {"braceblock" , new ParseAction(PAction.SHIFT, 45, null, -1)},
                {"LBRACE" , new ParseAction(PAction.SHIFT, 37, null, -1)},
        }, //end state
        // DFA STATE 45
        new Dictionary<string,ParseAction>(){
            // cond :: IF LPAREN NUM RPAREN braceblock ELSE braceblock•
            {"ID",new ParseAction(PAction.REDUCE, 7, "cond", 14)},
            {"IF",new ParseAction(PAction.REDUCE, 7, "cond", 14)},
            {"WHILE",new ParseAction(PAction.REDUCE, 7, "cond", 14)},
        }, //end state
        // DFA STATE 46
        new Dictionary<string,ParseAction>(){
                {"NUM" , new ParseAction(PAction.SHIFT, 50, null, -1)},
        }, //end state
        // DFA STATE 47
        new Dictionary<string,ParseAction>(){
                {"RPAREN" , new ParseAction(PAction.SHIFT, 48, null, -1)},
        }, //end state
        // DFA STATE 48
        new Dictionary<string,ParseAction>(){
                {"SEMI" , new ParseAction(PAction.SHIFT, 49, null, -1)},
        }, //end state
        // DFA STATE 49
        new Dictionary<string,ParseAction>(){
            // func :: ID LPAREN RPAREN SEMI•
            {"ID",new ParseAction(PAction.REDUCE, 4, "func", 12)},
            {"IF",new ParseAction(PAction.REDUCE, 4, "func", 12)},
            {"WHILE",new ParseAction(PAction.REDUCE, 4, "func", 12)},
        }, //end state
        // DFA STATE 50
        new Dictionary<string,ParseAction>(){
                {"SEMI" , new ParseAction(PAction.SHIFT, 51, null, -1)},
        }, //end state
        // DFA STATE 51
        new Dictionary<string,ParseAction>(){
            // assign :: ID EQ NUM SEMI•
            {"ID",new ParseAction(PAction.REDUCE, 4, "assign", 11)},
            {"IF",new ParseAction(PAction.REDUCE, 4, "assign", 11)},
            {"WHILE",new ParseAction(PAction.REDUCE, 4, "assign", 11)},
        }, //end state
        // DFA STATE 52
        new Dictionary<string,ParseAction>(){
            // stmts :: stmt stmts•
            {"RBRACE",new ParseAction(PAction.REDUCE, 2, "stmts", 6)},
        }, //end state
        // DFA STATE 53
        new Dictionary<string,ParseAction>(){
                {"SEMI" , new ParseAction(PAction.SHIFT, 54, null, -1)},
        }, //end state
        // DFA STATE 54
        new Dictionary<string,ParseAction>(){
            // funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI•
            {"$",new ParseAction(PAction.REDUCE, 10, "funcdecl", 2)},
            {"SEMI",new ParseAction(PAction.REDUCE, 10, "funcdecl", 2)},
        }, //end state
        // DFA STATE 55
        new Dictionary<string,ParseAction>(){
                {"LBRACE" , new ParseAction(PAction.SHIFT, 56, null, -1)},
        }, //end state
        // DFA STATE 56
        new Dictionary<string,ParseAction>(){
                {"memberdecls" , new ParseAction(PAction.SHIFT, 57, null, -1)},
                {"membervardecl" , new ParseAction(PAction.SHIFT, 58, null, -1)},
                {"memberfuncdecl" , new ParseAction(PAction.SHIFT, 59, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 60, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 61, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 5, null, -1)},
        }, //end state
        // DFA STATE 57
        new Dictionary<string,ParseAction>(){
                {"RBRACE" , new ParseAction(PAction.SHIFT, 69, null, -1)},
        }, //end state
        // DFA STATE 58
        new Dictionary<string,ParseAction>(){
                {"SEMI" , new ParseAction(PAction.SHIFT, 67, null, -1)},
        }, //end state
        // DFA STATE 59
        new Dictionary<string,ParseAction>(){
                {"SEMI" , new ParseAction(PAction.SHIFT, 65, null, -1)},
        }, //end state
        // DFA STATE 60
        new Dictionary<string,ParseAction>(){
                {"ID" , new ParseAction(PAction.SHIFT, 62, null, -1)},
        }, //end state
        // DFA STATE 61
        new Dictionary<string,ParseAction>(){
            // memberfuncdecl :: funcdecl•
            {"SEMI",new ParseAction(PAction.REDUCE, 1, "memberfuncdecl", 25)},
        }, //end state
        // DFA STATE 62
        new Dictionary<string,ParseAction>(){
                {"COLON" , new ParseAction(PAction.SHIFT, 63, null, -1)},
        }, //end state
        // DFA STATE 63
        new Dictionary<string,ParseAction>(){
                {"TYPE" , new ParseAction(PAction.SHIFT, 64, null, -1)},
        }, //end state
        // DFA STATE 64
        new Dictionary<string,ParseAction>(){
            // membervardecl :: VAR ID COLON TYPE•
            {"SEMI",new ParseAction(PAction.REDUCE, 4, "membervardecl", 24)},
        }, //end state
        // DFA STATE 65
        new Dictionary<string,ParseAction>(){
                {"memberdecls" , new ParseAction(PAction.SHIFT, 66, null, -1)},
                {"membervardecl" , new ParseAction(PAction.SHIFT, 58, null, -1)},
                {"memberfuncdecl" , new ParseAction(PAction.SHIFT, 59, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 60, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 61, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 5, null, -1)},
        }, //end state
        // DFA STATE 66
        new Dictionary<string,ParseAction>(){
            // memberdecls :: memberfuncdecl SEMI memberdecls•
            {"RBRACE",new ParseAction(PAction.REDUCE, 3, "memberdecls", 23)},
        }, //end state
        // DFA STATE 67
        new Dictionary<string,ParseAction>(){
                {"memberdecls" , new ParseAction(PAction.SHIFT, 68, null, -1)},
                {"membervardecl" , new ParseAction(PAction.SHIFT, 58, null, -1)},
                {"memberfuncdecl" , new ParseAction(PAction.SHIFT, 59, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 60, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 61, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 5, null, -1)},
        }, //end state
        // DFA STATE 68
        new Dictionary<string,ParseAction>(){
            // memberdecls :: membervardecl SEMI memberdecls•
            {"RBRACE",new ParseAction(PAction.REDUCE, 3, "memberdecls", 22)},
        }, //end state
        // DFA STATE 69
        new Dictionary<string,ParseAction>(){
            // classdecl :: CLASS ID LBRACE memberdecls RBRACE•
            {"$",new ParseAction(PAction.REDUCE, 5, "classdecl", 3)},
        }, //end state
    }; //close the table initializer
} //close the ParseTable class
public class Conflicts{
    public static Dictionary<int, string> src_tracker = new() {
    }; //end of constructor
    public static Dictionary<int, string> rr_tracker = new() {
    }; //end of constructor
    } //end of conflicts
} //close the namespace lab thing
