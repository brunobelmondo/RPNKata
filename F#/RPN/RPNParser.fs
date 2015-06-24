namespace RPN

module RPNParser =

    let Split (input:string) = input.Split [|' '|]

    type FullyDefinedElement<'a> = { Pattern:string; Element:'a}

    let Match token element = 
        element.Pattern = token

    let TryParseElement elementDefinitionList token =
        List.tryFind (Match token) elementDefinitionList

    type Item<'a> =  
        |Number of int
        |Element of 'a

    let ToItem elementDefinitionList token = 
        let maybeElement = TryParseElement elementDefinitionList token
        match maybeElement with
        | None -> Number (int token)
        | Some e -> Element e.Element

    let ToItems elementList tokens=
        Array.map (ToItem elementList) tokens

    let Parse elementDefinitionList = Split >> ToItems elementDefinitionList



