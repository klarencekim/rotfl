
// SlkString.cs - generated by the SLK parser generator 

namespace Rotfl {

class SlkString {

private static string[] Nonterminal_name ={"0"

,"lolcode"
,"lolcode_body"
,"statement_with_separator"
,"statement"
,"binary_op"
,"value"
,"expression"
,"declaration"
,"stdio"
,"statement_with_separator_*"
,"ITZ_expression_opt"
,"expression_*"
};

private static string[] Terminal_name ={"0"

,"HAI"
,"statement_separator"
,"KTHXBYE"
,"SUM"
,"OF"
,"DIFF"
,"PRODUKT"
,"QUOSHUNT"
,"MOD"
,"BIGGR"
,"SMALLR"
,"IDENTIFIER"
,"NUMBR"
,"NUMBAR"
,"YARN"
,"AN"
,"I_HAS_A"
,"ITZ"
,"VISIBLE"
,"GIMME"
,"END_OF_SLK_INPUT_"
};

private static string[] Action_name ={"0"

,"__StartBlock"
,"__EndBlock"
,"__PushStatement"
,"__AssignIt"
,"__StartFunction"
,"__PopArgument"
,"__EndFunction"
,"__PushValue"
,"__SaveIdentifier"
,"__DeclareAssign"
,"__Declare"
};

private static string[] Production_name ={"0"

,"lolcode --> HAI statement_separator __StartBlock lolcode_body __EndBlock KTHXBYE"
,"lolcode_body --> statement_with_separator_*"
,"statement_with_separator --> statement __PushStatement statement_separator"
,"statement --> expression __AssignIt"
,"statement --> declaration"
,"statement --> stdio"
,"binary_op --> SUM OF"
,"binary_op --> DIFF OF"
,"binary_op --> PRODUKT OF"
,"binary_op --> QUOSHUNT OF"
,"binary_op --> MOD OF"
,"binary_op --> BIGGR OF"
,"binary_op --> SMALLR OF"
,"value --> IDENTIFIER"
,"value --> NUMBR"
,"value --> NUMBAR"
,"value --> YARN"
,"expression --> binary_op __StartFunction expression __PopArgument AN expression __PopArgument __EndFunction"
,"expression --> value __PushValue"
,"declaration --> I_HAS_A IDENTIFIER __SaveIdentifier ITZ_expression_opt"
,"stdio --> VISIBLE __StartFunction expression_*"
,"stdio --> GIMME __StartFunction IDENTIFIER __PopArgument __EndFunction"
,"statement_with_separator_* --> statement_with_separator statement_with_separator_*"
,"statement_with_separator_* -->"
,"ITZ_expression_opt --> ITZ expression __DeclareAssign"
,"ITZ_expression_opt --> __Declare"
,"expression_* --> expression __PopArgument expression_*"
,"expression_* --> __EndFunction"
};

private const short   START_SYMBOL = 2049;

public static string  GetSymbolName ( short symbol )
{
  if ( symbol >= START_SYMBOL ) {
      return ( Nonterminal_name [symbol - (START_SYMBOL-1)] );
  } else if ( symbol > 0 ) {
      return ( Terminal_name [ SlkParser.GetTerminalIndex ( symbol ) ] );
  } else {
      return ( Action_name [ -symbol ] );
  }
}

public static string  GetProductionName ( short production_number )
{
  return ( Production_name [production_number] );
}


};


}
