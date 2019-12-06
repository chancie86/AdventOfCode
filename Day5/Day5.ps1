﻿$ErrorActionPreference = "Stop"

$inputData = @(3,225,
    1,225,6,6,
    1100,1,238,225,
    104,0,
    1102,35,92,225,
    1101,25,55,225,
    1102,47,36,225,
    1102,17,35,225,
    1,165,18,224,
    1001,224,-106,224,
    4,224,
    102,8,223,223,
    1001,224,3,224,
    1,223,224,223,
    1101,68,23,224,
    101,-91,224,224,
    4,224,
    102,8,223,223,
    101,1,224,224,
    1,223,224,223,
    2,217,13,224,
    1001,224,-1890,224,
    4,224,
    102,8,223,223,
    1001,224,6,224,
    1,224,223,223,
    1102,69,77,224,
    1001,224,-5313,224,
    4,224,
    1002,223,8,223,
    101,2,224,224,
    1,224,223,223,
    102,50,22,224,
    101,-1800,224,224,
    4,224,
    1002,223,8,223,
    1001,224,5,224,
    1,224,223,223,
    1102,89,32,225,
    1001,26,60,224,
    1001,224,-95,224,
    4,224,
    102,8,223,223,
    101,2,224,224,
    1,223,224,223,
    1102,51,79,225,
    1102,65,30,225,1002,170,86,224,101,-2580,224,224,4,224,102,8,223,223,1001,224,6,224,1,223,224,223,101,39,139,224,1001,224,-128,224,4,224,102,8,223,223,101,3,224,224,1,223,224,223,1102,54,93,225,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,1008,677,677,224,1002,223,2,223,1005,224,329,101,1,223,223,7,677,677,224,102,2,223,223,1006,224,344,101,1,223,223,108,677,677,224,1002,223,2,223,1006,224,359,1001,223,1,223,7,677,226,224,1002,223,2,223,1005,224,374,1001,223,1,223,1107,677,226,224,1002,223,2,223,1005,224,389,1001,223,1,223,107,226,677,224,102,2,223,223,1005,224,404,1001,223,1,223,1108,226,677,224,1002,223,2,223,1006,224,419,101,1,223,223,107,226,226,224,102,2,223,223,1005,224,434,1001,223,1,223,108,677,226,224,1002,223,2,223,1006,224,449,101,1,223,223,108,226,226,224,102,2,223,223,1006,224,464,1001,223,1,223,1007,226,226,224,1002,223,2,223,1005,224,479,101,1,223,223,8,677,226,224,1002,223,2,223,1006,224,494,101,1,223,223,1007,226,677,224,102,2,223,223,1006,224,509,101,1,223,223,7,226,677,224,1002,223,2,223,1005,224,524,101,1,223,223,107,677,677,224,102,2,223,223,1005,224,539,101,1,223,223,1008,677,226,224,1002,223,2,223,1005,224,554,1001,223,1,223,1008,226,226,224,1002,223,2,223,1006,224,569,1001,223,1,223,1108,226,226,224,102,2,223,223,1005,224,584,101,1,223,223,1107,226,677,224,1002,223,2,223,1005,224,599,1001,223,1,223,8,226,677,224,1002,223,2,223,1006,224,614,1001,223,1,223,1108,677,226,224,102,2,223,223,1005,224,629,1001,223,1,223,8,226,226,224,1002,223,2,223,1005,224,644,1001,223,1,223,1107,677,677,224,1002,223,2,223,1005,224,659,1001,223,1,223,1007,677,677,224,1002,223,2,223,1005,224,674,101,1,223,223,4,223,99,226)

function SetVerbNoun
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $Data,

        [int]
        $Verb,

        [int]
        $Noun
    )

    $Data[1] = $Verb
    $Data[2] = $Noun

    $Data
}

function Add
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $Program,

        [Parameter(Mandatory = $true)]
        [int]
        $Ptr
    )

    $param1Ptr = $Program[$Ptr + 1]
    $param2Ptr = $Program[$Ptr + 2]
    $resultPtr = $Program[$Ptr + 3]

    $Program[$resultPtr] = $Program[$param1Ptr] + $Program[$param2Ptr]
    Write-Verbose "ADD  p[$resultPtr] = p[$param1Ptr] + p[$param2Ptr]"

    $Program
}

function Multiply
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $Program,

        [Parameter(Mandatory = $true)]
        [int]
        $Ptr
    )

    $param1Ptr = $Program[$Ptr + 1]
    $param2Ptr = $Program[$Ptr + 2]
    $resultPtr = $Program[$Ptr + 3]

    $Program[$resultPtr] = $Program[$param1Ptr] * $Program[$param2Ptr]
    Write-Verbose "MULT p[$resultPtr] = p[$param1Ptr] x p[$param2Ptr]"

    $Program
}

function Input
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $Program,

        [Parameter(Mandatory = $true)]
        [int]
        $Ptr,

        $Input
    )

    $resultPtr = $Program[$Ptr + 1]

    $Program[$resultPtr] = $Input
    Write-Verbose "INPUT p[$resultPtr] = $Input"

    $Program
}

function Output
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $Program,

        [Parameter(Mandatory = $true)]
        [int]
        $Ptr
    )

    $resultPtr = $Program[$Ptr + 1]

    Write-Verbose "OUTPUT p[$resultPtr]"
    Write-Host $Program[$resultPtr]

    $Program
}

function Run
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $Program
    )

    $opPtr = 0

    while ($true)
    {
        $opCode = $Program[$opPtr].ToString("D5")
        $op = [int]::Parse($opCode.Substring(6))


        switch($op)
        {
            1 {
                $Program = Add -Program $Program -Ptr $opPtr
                $opPtr += 4
            }
            2 {
                $Program = Multiply -Program $Program -Ptr $opPtr
                $opPtr += 4
            }
            3 {
                $Program = Input -Program $Program -Ptr $opPtr -Input
                $opPtr += 3
            }
            4 {
                $Program = Output -Program $Program -Ptr $opPtr
                $opPtr += 3
            }
            99 {
                Write-Verbose "$debug, Op: Halt"
                return $Program[0]
            }
            default {
                throw "Invalid op code $($Program[$opPtr])"
            }
        }
    }

    $Program[0]
}

$verb = 12
$noun = 2

$originalInputData = $inputData

Write-Host "Part 1"
$inputData = SetVerbNoun -Data $inputData -Verb $verb -Noun $noun
$answer = Run -Program $inputData
Write-Host "Answer is $($answer)"

Write-Host "Part 2"
for ($a = $verb; $a -lt 100; $a++)
{
    for ($b = $noun; $b -lt 100; $b++)
    {
        $inputData = SetVerbNoun -Data $originalInputData -Verb $a -Noun $b
        Write-Host "Attempting Verb: $a, Noun: $b"
        $answer = Run -Program $inputData
        if ($answer -eq 19690720)
        {
            Write-Host "Verb: $a, Noun: $b, Answer: $((100*$a)+$b)"
            return
        }
    }
}

throw "Answer not found"