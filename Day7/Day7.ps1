param (
    $LogLevel = 1
)

$ErrorActionPreference = "Stop"

$inputData = @(3,8,1001,8,10,8,105,1,0,0,21,38,59,76,89,106,187,268,349,430,99999,3,9,1002,9,3,9,101,2,9,9,1002,9,4,9,4,9,99,3,9,1001,9,5,9,1002,9,5,9,1001,9,2,9,1002,9,3,9,4,9,99,3,9,1001,9,4,9,102,4,9,9,1001,9,3,9,4,9,99,3,9,101,4,9,9,1002,9,5,9,4,9,99,3,9,1002,9,3,9,101,5,9,9,1002,9,3,9,4,9,99,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,99,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,99)

$script:logLevel = $LogLevel

function Log-Verbose
{
    param (
        [Parameter(Mandatory = $true)]
        [string]
        $Message,

        [Parameter(Mandatory = $true)]
        [int]
        $Level
    )

    if ($Level -le $script:logLevel)
    {
        WRite-Verbose $Message
    }
}

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

function Part1_Execute
{
    param (
        [int[]]
        $Program,

        [int[]]
        $PhaseSettings
    )
    
    $param = 0

    $PhaseSettings | % {
        $param = Run -Program $Program.Clone() -InputValues @($_, $param)
    }

    $param
}

function AssertEquals
{
    param (
        [Parameter(Mandatory = $true)]
        $Actual,

        [Parameter(Mandatory = $true)]
        $Expected
    )

    $success = $Expected -eq $Actual

    if ($success)
    {
        Write-Host "ASSERT | Expected: $Expected, Actual: $Actual, Result: $($Expected -eq $Actual)"
    }
    else
    {
        Write-Error "ASSERT | Expected: $Expected, Actual: $Actual, Result: $($Expected -eq $Actual)"
    }
}

function Part1_Tests
{
    $result = Part1_Execute -Program @(3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0) -PhaseSettings @(4,3,2,1,0)
    AssertEquals -Actual $result -Expected 43210

    $result = Part1_Execute -Program @(3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0) -PhaseSettings @(0,1,2,3,4)
    AssertEquals -Actual $result -Expected 54321

    $result = Part1_Execute -Program @(3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0) -PhaseSettings @(1,0,4,3,2)
    AssertEquals -Actual $result -Expected 65210
}

function IncrementPhaseSetting
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $PhaseSetting
    )

    do
    {
        # Phase settings are a 5 integer array with max digit value of 4
        $incrementNext = $false
        $i = 4

        # Increment from right to left and increment the next value if we roll over.
        do
        {
            $incrementNext = $PhaseSetting[$i] -eq 4 -and $i -gt 0
            $PhaseSetting[$i] = ($PhaseSetting[$i] + 1) % 5
            $i--
        } while ($incrementNext)

        $hasAllDigits = $PhaseSetting -contains 0 `
            -and $PhaseSetting -contains 1 `
            -and $PhaseSetting -contains 2 `
            -and $PhaseSetting -contains 3 `
            -and $PhaseSetting -contains 4
    } while (-not($hasAllDigits))

    $PhaseSetting
}

function Part1
{
    param (
        [Parameter(Mandatory = $true)]
        [int[]]
        $Program
    )

    $currentPhaseSetting = IncrementPhaseSetting -PhaseSetting @(0,0,0,0,0)
    $maxPhaseSetting = $currentPhaseSetting.Clone()

    do
    {
        Log-Verbose -Message "Trying $($currentPhaseSetting -join ',')" -Level 5

        $lastFirstDigit = $currentPhaseSetting[0]
        $result = Part1_Execute -Program $inputData -PhaseSettings $currentPhaseSetting
        
        if ($result -ge $maxValue)
        {
            $maxValue = $result
            $maxPhaseSetting = $currentPhaseSetting.Clone()

            Write-Host "Updating max phase setting: $($maxPhaseSetting -join ',') results in $maxValue"
        }

        $currentPhaseSetting = IncrementPhaseSetting -PhaseSetting $currentPhaseSetting
    }
    while ($lastFirstDigit -le $currentPhaseSetting[0])

    Write-Host "Max phase setting: $($maxPhaseSetting -join ','), Signal value: $maxValue"
}

#Part1_Tests
Part1 -Program $inputData