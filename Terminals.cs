// namespace lab{

// public static class Terminals{
//     public static void makeAllOfTheTerminals(){
//         Grammar.addTerminals( new Terminal[] {
//             new( "COMMENT", @"(?sx)
//                 //[^\n]*
//                 |
//                 /[*] .*? [*]/"),
//             new("EQ",               @"="),
//             new("MULOP", "[*/%]" ),
//             new("ADDOP",           @"[-+]" ),
//             new("FNUM",            @"(?ix)
//                     -?\d+(\.\d*)e-?\d+? |
//                     -?\d+\.\d+"),
//             new("NUM",              @"\d+" ),
//             new("CHARCONST",        @"'.'" ),
//             new("STRINGCONSTANT",   @"(?x)  "" (\\[nr""]  | [^\\] )*  ""  "),
//             new("LPAREN",           @"\("),
//             new("RPAREN",           @"\)"),
//             new("LBRACE",           @"\{"),
//             new("RBRACE",           @"\}"),
//             new("SEMI",             @";"),
//             new("COLON",            @":"),
//             new("COMMA",            @","),
//             new("OVERRIDE",         @"(?<=\)\s*)override(?=\s*\{)"),
//             new("WHITESPACE",       @"\s+"),
//             new("NOT",              @"\bnot\b" ),
//             new("IF",               @"\bif\b"),
//             new("ELSE",             @"\belse\b"),
//             new("RELOP",            @">=|<=|>|<|==|!="),
//             new("SHIFTOP",          @">>>|<<<|>>|<<"),
//             new("TRUE",             @"(?x)true|True"),
//             new("FALSE",            @"(?x)false|False"),
//             new("AND",              @"\band\b"),
//             new("OR",               @"\bor\b"),
//             new("ID",               @"(?!\d)\w+" )
//         });
//     }
// }

// }


namespace lab{

public class Terminals{
    public static void makeAllOfTheNonTerminals(){
        List<string> inp = new List<string>();
        inp.Add("S");
        inp.Add("decls");
        inp.Add("funcdecl");
        inp.Add("optionalReturn");
        inp.Add("braceblock");
        inp.Add("optionalSemi");
        inp.Add("optionalPdecls");
        inp.Add("pdecls");
        inp.Add("pdecl");
        inp.Add("func");
        inp.Add("classdecl");
        inp.Add("memberdecls");
        inp.Add("membervardecl");
        inp.Add("memberfuncdecl");
        inp.Add("stmts");
        inp.Add("stmt");
        inp.Add("assign");
        inp.Add("cond");
        inp.Add("loop");
        inp.Add("sum");
        inp.Add("prod");
        inp.Add("return");
        inp.Add("vardecl");
        inp.Add("expr");
        inp.Add("orexp");
        inp.Add("andexp");
        inp.Add("relexp");
        inp.Add("bitexp");
        inp.Add("shiftexp");
        inp.Add("sumexp");
        inp.Add("prodexp");
        inp.Add("powexp");
        inp.Add("unaryexp");
        inp.Add("preincexp");
        inp.Add("postincexp");
        inp.Add("amfexp");
        inp.Add("factor");
        inp.Add("calllist");
        inp.Add("calllist2");
        inp.Add("lambda");
        inp.Add("decl");
        inp.Add("nonVoidType");
        inp.Add("anyType");
        inp.Add("arg");
        inp.Add("λ");
        Grammar.addNonTerminals(inp);
    }
    public static void makeAllOfTheTerminals(){
        Grammar.addTerminals( new Terminal[] {
            new("COMMENT",          @"//[^\n]*"),
            new("EQ",               @"="),
            new("LPAREN",               @"\("),
            new("MUL",              @"\*"),
            new("NUM",              @"\d+" ),
            new("PLUS",             @"\+"),
            new("RPAREN",               @"\)"),
            new("SEMI",             @";"),
            // new("ADDOP",            @"[-+]"),
            // new("ANDOP",            @"\band\b"),
            // new("ARROW",            @"->"),
            // new("BITNOTOP",         @"~"),
            // new("BITOP",            @"[|&^]"),
            // new("BOOLCONST",        @"\b(true|false)\b"),
            // new("BREAK",            @"\bbreak\b"),
            new("CLASS",            @"\bclass\b"),
            new("COLON",            @":"),
            new("COMMA",            @","),
            // new("COMMENT",          @"(//[^\n]*)|(/\*(.|[\n])*?\*/)"),
            // new("CONTINUE",         @"\bcontinue\b"),
            // new("DOT",              @"\."),
            new("ELSE",             @"\belse\b"),
            // new("EQ",               @"="),
            // new("FNUM",             @"(?xi) (
            //                             \d+(\.\d*)?e[+-]?\d+
            //                           | \d+\.\d*
            //                         )
            // "),
            new("FUNC",             @"\bfunc\b"),
            new("IF",               @"\bif\b"),
            new("LBRACE",           @"\{"),
            // new("LBRACKET",         @"\["),
            // new("LPAREN",           @"\("),
            // new("MULOP",            @"[*/%]"),
            // new("NOTOP",            @"\bnot\b"),
            // new("NUM",              @"\d+"),
            // new("OROP",             @"\bor\b"),
            // new("POWOP",            @"[*]{2}"),
            // new("PLUSPLUS",         @"[+]{2}|-{2}"),
            new("RBRACE",           @"\}"),
            // new("RBRACKET",         @"\]"),
            // new("RELOP",            @">=|<=|!=|==|>|<"),
            // new("REPEAT",           @"\brepeat\b"),
            // new("RETURN",           @"\breturn\b"),
            // new("RPAREN",           @"\)"),
            // new("SEMI",             @";"),
            // new("SHIFTOP",          @"<<|>>>|>>"),
            // new("STRINGCONST",      @"(?x) "" (\\.|[^""])* ""  "),
            new("TYPE",             @"\b(int|float|string|bool)\b"),
            // new("UNTIL",            @"\buntil\b"),
            new("VAR",              @"\bvar\b"),
            new("ID",               @"(?!\d)\w+" ),
            new("WHILE",            @"\bwhile\b"),
            // new("ID",               @"(?!\d)\w+" )
        });
    }
}

}