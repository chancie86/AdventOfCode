$ErrorActionPreference = "Stop"

$inputData = @(1,0,0,3,
               1,1,2,3,
               1,3,4,3,
               1,5,0,3,
               2,10,1,19,
               1,19,6,23,
               2,13,23,27,
               1,27,13,31,
               1,9,31,35,
               1,35,9,39,
               1,39,5,43,
               2,6,43,47,
               1,47,6,51,
               2,51,9,55,
               2,55,13,59,
               1,59,6,63,
               1,10,63,67,
               2,67,9,71,
               2,6,71,75,
               1,75,5,79,
               2,79,10,83,
               1,5,83,87,
               2,9,87,91,
               1,5,91,95,
               2,13,95,99,
               1,99,10,103,
               1,103,2,107,
               1,107,6,0,
               99,
               2,14,0,0)

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
    Write-Verbose "p[$resultPtr] = p[$param1Ptr] + p[$param2Ptr]"

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
    Write-Verbose "p[$resultPtr] = p[$param1Ptr] x p[$param2Ptr]"

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
        #$debug = "Pointer: $opPtr"

        switch($Program[$opPtr])
        {
            1 {
                # $debug += ", Op: Add "
                # $debug += ("{0},{1},{2}" -f $Program[$ptr + 1],$Program[$ptr + 2],$Program[$ptr + 3])
                $Program = Add -Program $Program -Ptr $opPtr
            }
            2 {
                # $debug += ", Op: Multiply "
                # $debug += ("{0},{1},{2}" -f $Program[$ptr + 1],$Program[$ptr + 2],$Program[$ptr + 3])
                $Program = Multiply -Program $Program -Ptr $opPtr
            }
            99 {
                Write-Verbose "$debug, Op: Halt"
                return $Program[0]
            }
            default {
                throw "Invalid op code $($Program[$opPtr])"
            }
        }

        # Write-Verbose $debug
        #Write-Verbose ($Program -Join ',')

        $opPtr += 4
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