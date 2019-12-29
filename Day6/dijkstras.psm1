function dijkstras
{
    param(
        $Nodes,

        $InitialNodeName,

        $DestinationNodeName
    )

    Write-Verbose "Initialising variables for dijkstras"

    $Nodes | % {
        $_ | Add-Member -Type NoteProperty -Name Visited -Value $false
        $_ | Add-Member -Type NoteProperty -Name Distance -Value ([int]::MaxValue)
        $_ | Add-Member -Type NoteProperty -Name Neighbours -Value (new-object -TypeName "System.Collections.ArrayList")

        if ($_.Children.Count -ne 0)
        {
            $foo = $_.Neighbours.AddRange($_.Children)
        }
        
        if ($null -ne $_.Neighbours)
        {
            $foo = $_.Neighbours.Add($_.Parent)
        }

        #Write-Verbose "$($_.Name) has $($_.Neighbours.Count) neighbours"
    }

    $initialNode = $Nodes | ? { $_.Name -eq $InitialNodeName }
    $destinationNode = $Nodes | ? { $_.Name -eq $DestinationNodeName }

    Write-Verbose "Initial node: $($initialNode.Name)"
    Write-Verbose "Destination node: $($destinationNode.Name)"

    $current = $initialNode

    $initialNode.Distance = 0

    $unvisited = new-object -TypeName "System.Collections.ArrayList"
    $unvisited.AddRange($Nodes)

    while ($null -ne $current -and $destinationNode.Visited -eq $false)
    {
        #Write-Verbose "Visiting $($current.Name)"
        if ($current.Name -eq $destinationNodeName)
        {
            Write-Verbose "Found $destinationNodeName, dist = $distance"
        }

        $current.Neighbours | % {
            if ($_.Visited -eq $false)
            {
                $distance = $current.Distance + 1

                if ($distance -lt $_.Distance)
                {
                    $_.Distance = $distance
                    #Write-Verbose "Setting distance for $($_.Name) to $distance"
                }
            }
        }

        $current.Visited = $true
        $unvisited.Remove($current)

        $current = ($unvisited | sort Distance)[0]
    }

    Write-Verbose $unvisited.Count

    $destinationNode.Distance
}

Export-ModuleMember -Function dijkstras