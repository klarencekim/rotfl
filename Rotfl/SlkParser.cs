
// SlkParser.cs - generated by the SLK parser generator 

namespace Rotfl {

class SlkParser {

private static short get_conditional_production ( short symbol ) { return (short) 0; }

private static short[] Parse = {

0,0,1,0,2,2,0,2,2,2,2,2,2,2,2,2,2,0,2
,2,22,21,0,21,21,21,21,21,21,21,21,21,21,0,21,21,3,0,3
,3,3,3,3,3,3,3,3,3,0,3,3,4,0,4,4,4,4,4,4
,4,4,4,4,0,5,5,24,0,23,0,23,23,23,23,23,23,23,23,23
,23,17,0,17,17,17,17,17,17,18,18,18,18,6,0,7,8,9,10,11
,12,13,14,15,16,19,20,0,0
};

private static int[] Parse_row = {0

,1,1,32,47,88,88,76,87,17,64
,0};

private static short[] Conflict = {

0
};

private static int[] Conflict_row = {0


,0};

private static short[] Production = {0

,0,2049,259,-2,2050,-1,258,257,0,2050,2057,0,2051,258,-3,2052
,0,2052,-4,2055,0,2052,-4,2056,0,2053,261,260,0,2053,261,262
,0,2053,261,263,0,2053,261,264,0,2053,261,265,0,2053,261,266
,0,2053,261,267,0,2054,268,0,2054,269,0,2054,270,0,2054,271
,0,2055,-7,-6,2055,272,-6,2055,-5,2053,0,2055,-8,2054,0,2056,2058,-5,273
,0,2056,-7,-6,268,-5,274,0,2057,2057,2051,0,2057,0,2058,2058,-6,2055
,0,2058,-7
,0};

private static int[] Production_row = {0

,1,9,12,17,21,25,29,33,37,41,45,49,53,56,59,62
,65,75,79,84,91,95,97,102
,0};

private static short[] Terminal_to_index = {0

,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19
};

private const short   END_OF_SLK_INPUT_ = 275;
private const short   START_SYMBOL = 2049;

public static short GetTerminalIndex ( short   token ){
 return ( Terminal_to_index [token] );
}

private static short
get_predicted_entry ( int        display,
                      SlkToken   tokens,
                      SlkLog     log,
                      short      production_number,
                      short      token,
                      int        scan_level,
                      int        depth )
{
 return  0;
}

public static void
parse ( int         display,
        SlkAction   action,
        SlkToken    tokens,
        SlkError    error,
        SlkLog      log,
        short       start_symbol )
{
 short     rhs, lhs;
 short     production_number, entry, symbol, token, new_token;
 int       top, index, level;
 short[]   stack = new short[512];

 top = 511;
 stack [ top ] = 0;
 if ( start_symbol == 0 ) {
     start_symbol = START_SYMBOL;
 }
 if ( top > 0 ) { stack [--top] = start_symbol;
 } else { log.trace ("SlkParse: stack overflow\n"); return; }
 token = tokens.get();
 new_token = token;
 if ( display != 0 ) {
     log.trace ( "\n\n\t\tPARSE DERIVATION\n\n" );
 }

 for ( symbol = (stack[top] != 0  ? stack[top++] : (short) 0);  symbol != 0; ) {

     if ( symbol >= START_SYMBOL ) {                  // nonterminal symbol

         entry = 0;
         level = 1;
         production_number = get_conditional_production ( symbol );
         if ( production_number != 0 ) {
             entry = get_predicted_entry ( display, tokens, log,
                                           production_number, token,
                                           level, 1 );
         }
         if ( entry == 0 ) {
             index = Parse_row [ symbol - (START_SYMBOL-1) ];
             index += Terminal_to_index [ token ];
             entry = Parse [ index ];
         }
         while ( entry < 0 ) {
             index = Conflict_row [-entry];
             index += Terminal_to_index [tokens.peek (level)];
             entry = Conflict [ index ];
             ++level;
         }
         if ( entry != 0 ) {
             index = Production_row [ entry ];
             lhs = Production [ ++index ];
             if ( lhs == symbol ) {                   // valid row for lhs
                 rhs = Production [++index];
                 for ( ;  rhs != 0;  rhs = Production [++index] ) {
                     if ( top > 0 ) { stack [--top] = rhs;
                     } else { log.trace ("SlkParse: stack overflow\n"); return; }
                 }
                 if ( display != 0 ) {
                     log.trace_production ( entry );
                 }
             } else {                                 // lhs does not match
                 new_token = error.no_entry ( symbol, token, level-1 );
             }
         } else {                                       // no table entry
             new_token = error.no_entry ( symbol, token, level-1 );
         }

     } else if ( symbol > 0 ) {                         // terminal symbol
         if ( symbol == token ) {
             token = tokens.get();
             new_token = token;
         } else {                                       // token mismatch
             new_token = error.mismatch ( symbol, token );
         }

     } else {                                           // action symbol
         if ( display != 0 ) {
             log.trace_action ( symbol );
         }
         action.execute ( -symbol );
     }

     if ( token != new_token ) {
         if ( new_token != 0 ) {
             token = new_token;
         }
         if ( token != END_OF_SLK_INPUT_ ) {
             continue;                                  // try this token
         }
     }

     symbol = (stack[top] != 0  ? stack[top++] : (short) 0);
 }

 if ( token != END_OF_SLK_INPUT_ ) {                    // input left over
     error.input_left ();
 }

}



};


}