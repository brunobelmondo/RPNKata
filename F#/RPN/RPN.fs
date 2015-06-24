namespace RPN

open RPNParser

module RPN =

    let OperatorList =
        [
            {Pattern="+"; Element=fun x y -> x + y};
            {Pattern="-"; Element=fun x y -> x - y};
            {Pattern="*"; Element=fun x y -> x * y};
            {Pattern="/"; Element=fun x y -> x / y};
        ]

    let ApplyOperatorOnStack stack operator =
        let y::x::tail = stack
        let result = operator x y
        result::tail

    let ApplyItemOnStack stack item = 
        match item with
        | Number n -> n::stack
        | Element o -> ApplyOperatorOnStack stack o

    let ComputeItems items = Array.fold ApplyItemOnStack [] items
    
    let ParseWithOperators = Parse OperatorList

    let Compute = ParseWithOperators >> ComputeItems >> List.head
