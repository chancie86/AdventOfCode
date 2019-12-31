$ErrorActionPreference = "Stop"

$script:logLevel = 2

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

function GetValue
{
    param(
        [Parameter(Mandatory = $true)]
        [int[]]
        $Program,

        [Parameter(Mandatory = $true)]
        [ValidateSet(1, 2, 3)]
        [int]
        $ParameterNumber,

        [Parameter(Mandatory = $true)]
        [string]
        $ParameterModes
    )

    $modeIndex = 3 - $ParameterNumber

    if ($ParameterModes[$modeIndex] -eq "0")
    {
        # Position mode
        $Program[$Program[$Ptr + $ParameterNumber]]
    } else {
        # Immediate mode
        $Program[$Ptr + $ParameterNumber]
    }
}

function Add
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $Program,

        [Parameter(Mandatory = $true)]
        [int]
        $Ptr,

        [Parameter(Mandatory = $true)]
        [string]
        $ParameterModes
    )

    $param1 = GetValue -Program $Program -ParameterModes $ParameterModes -ParameterNumber 1
    $param2 = GetValue -Program $Program -ParameterModes $ParameterModes -ParameterNumber 2
    
    $resultPtr = $Program[$Ptr + 3]

    $Program[$resultPtr] = $param1 + $param2
    Log-Verbose "ADD  p[$resultPtr] = $param1 + $param2" -Level 9

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
        $Ptr,

        [Parameter(Mandatory = $true)]
        [string]
        $ParameterModes
    )

    $param1 = GetValue -Program $Program -ParameterModes $ParameterModes -ParameterNumber 1
    $param2 = GetValue -Program $Program -ParameterModes $ParameterModes -ParameterNumber 2

    $resultPtr = $Program[$Ptr + 3]

    $Program[$resultPtr] = $param1 * $param2
    Log-Verbose "MULTIPLY p[$resultPtr] = $param1 x $param2" -Level 9

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

        [Parameter(Mandatory = $true)]
        [int]
        $Value
    )

    $resultPtr = $Program[$Ptr + 1]
    
    $Program[$resultPtr] = $Value
    Log-Verbose "INPUT p[$resultPtr] = $Value" -Level 9

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
        $Ptr,

        [Parameter(Mandatory = $true)]
        [string]
        $ParameterModes
    )

    $param = GetValue -Program $Program -ParameterModes $ParameterModes -ParameterNumber 1

    Log-Verbose "OUTPUT $param" -Level 6

    $param
}

function Jump
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $Program,

        [Parameter(Mandatory = $true)]
        [int]
        $Ptr,

        [Parameter(Mandatory = $true)]
        [string]
        $ParameterModes,

        [Parameter(ParameterSetName = "IfTrue")]
        [switch]
        $IfTrue,

        [Parameter(ParameterSetName = "IfFalse")]
        [switch]
        $IfFalse
    )

    $param1 = GetValue -Program $Program -ParameterModes $ParameterModes -ParameterNumber 1
    $param2 = GetValue -Program $Program -ParameterModes $ParameterModes -ParameterNumber 2

    if ($IfTrue)
    {
        Log-Verbose "JUMP-IFTRUE $param1 == $param2" -Level 9

        if ($param1 -ne 0)
        {
            $param2
        } else {
            $Ptr + 3
        }
    } elseif ($IfFalse) {
        Log-Verbose "JUMP-IFFALSE $param1 != $param2" -Level 9

        if ($param1 -eq 0)
        {
            $param2
        } else {
            $Ptr + 3
        }
    }
}

function SetIfSize
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $Program,

        [Parameter(Mandatory = $true)]
        [int]
        $Ptr,

        [Parameter(Mandatory = $true)]
        [string]
        $ParameterModes,

        [Parameter(ParameterSetName = "LessThan")]
        [switch]
        $LessThan,

        [Parameter(ParameterSetName = "Equals")]
        [switch]
        $Equals
    )

    $param1 = GetValue -Program $Program -ParameterModes $ParameterModes -ParameterNumber 1
    $param2 = GetValue -Program $Program -ParameterModes $ParameterModes -ParameterNumber 2

    $resultPtr = $Program[$Ptr + 3]

    if ($LessThan)
    {
        Log-Verbose "SET-LESSTHAN $param1 < $param2" -Level 9
        if ($param1 -lt $param2)
        {
            $Program[$resultPtr] = 1
        } else {
            $Program[$resultPtr] = 0
        }
    } elseif ($Equals) {
        Log-Verbose "SET-EQUALS $param1 == $param2" -Level 9
        if ($param1 -eq $param2)
        {
            $Program[$resultPtr] = 1
        } else {
            $Program[$resultPtr] = 0
        }
    }

    $Program
}

function Run
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $Program,

        [Parameter(Mandatory = $true)]
        [int[]]
        $InputValues
    )

    Log-Verbose "Running program with params $($InputValues -join ',')" -Level 6

    $opPtr = 0
    $inputValuePtr = 0

    while ($true)
    {
        $opCode = $Program[$opPtr].ToString("D5")
        $op = [int]::Parse($opCode.Substring(3))
        $paramMode = $opCode.Substring(0,3)

        switch($op)
        {
            1 {
                $Program = Add -Program $Program -Ptr $opPtr -ParameterModes $paramMode
                $opPtr += 4
            }
            2 {
                $Program = Multiply -Program $Program -Ptr $opPtr -ParameterModes $paramMode
                $opPtr += 4
            }
            3 {
                $Program = Input -Program $Program -Ptr $opPtr -Value $InputValues[$inputValuePtr++]
                $opPtr += 2
            }
            4 {
                Output -Program $Program -Ptr $opPtr -ParameterModes $paramMode
                $opPtr += 2
            }
            5 {
                $opPtr = Jump -Program $Program -Ptr $opPtr -ParameterModes $paramMode -IfTrue
            }
            6 {
                $opPtr = Jump -Program $Program -Ptr $opPtr -ParameterModes $paramMode -IfFalse
            }
            7 {
                $Program = SetIfSize -Program $Program -Ptr $opPtr -ParameterModes $paramMode -LessThan
                $opPtr += 4
            }
            8 {
                $Program = SetIfSize -Program $Program -Ptr $opPtr -ParameterModes $paramMode -Equals
                $opPtr += 4
            }
            99 {
                Log-Verbose "HALT" -Level 9
                return
            }
            default {
                throw "Invalid op code $($Program[$opPtr])"
            }
        }
    }
}

Export-ModuleMember -Function @("Run")