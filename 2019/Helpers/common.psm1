$ErrorActionPreference = "Stop"

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

Export-ModuleMember -Function "*"