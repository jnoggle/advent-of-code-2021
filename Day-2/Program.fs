type SubmarineState =
    struct
        val depth: int
        val hPos: int
        val aim: int

        new(depth, hPos) = { depth = depth; hPos = hPos; aim = 0 }

        new(depth, hPos, aim) =
            { depth = depth
              hPos = hPos
              aim = aim }
    end

let solveLinePart1 (state: SubmarineState) (step: string) : SubmarineState =
    let splitStep = step.Split [| ' ' |]
    let direction = splitStep.[0]
    let magnitude = splitStep.[1] |> int

    if direction = "down" then
        new SubmarineState(state.depth + magnitude, state.hPos)
    else if direction = "up" then
        new SubmarineState(state.depth - magnitude, state.hPos)
    else
        new SubmarineState(state.depth, state.hPos + magnitude)

let solveLinePart2 (state: SubmarineState) (step: string) : SubmarineState =
    let splitStep = step.Split [| ' ' |]
    let direction = splitStep.[0]
    let magnitude = splitStep.[1] |> int

    if direction = "down" then
        new SubmarineState(state.depth, state.hPos, state.aim + magnitude)
    else if direction = "up" then
        new SubmarineState(state.depth, state.hPos, state.aim - magnitude)
    else
        new SubmarineState(state.depth + (state.aim * magnitude), state.hPos + magnitude, state.aim)

let steps =
    System.IO.File.ReadLines("inputs.txt")
    |> List.ofSeq

let part1FinalState =
    List.fold solveLinePart1 (new SubmarineState(0, 0)) steps

let part2FinalState =
    List.fold solveLinePart2 (new SubmarineState(0, 0)) steps

printf "Answer to part 1: %i\n" (part1FinalState.depth * part1FinalState.hPos)
printf "Answer to part 2: %i" (part2FinalState.depth * part2FinalState.hPos)
