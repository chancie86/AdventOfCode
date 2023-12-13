namespace Day5
{
    public class Almanac
    {
        public Almanac(Map seedToSoilMap, Map soilToFertilizerMap, Map fertilizerToWaterMap, Map waterToLightMap, Map lightToTemperatureMap, Map temperatureToHumidityMap, Map humidityToLocationMap)
        {
            this.seedToSoilMap = seedToSoilMap;
            this.soilToFertilizerMap = soilToFertilizerMap;
            this.fertilizerToWaterMap = fertilizerToWaterMap;
            this.waterToLightMap = waterToLightMap;
            this.lightToTemperatureMap = lightToTemperatureMap;
            this.temperatureToHumidityMap = temperatureToHumidityMap;
            this.humidityToLocationMap = humidityToLocationMap;
        }

        public Map seedToSoilMap { get; }
        public Map soilToFertilizerMap { get; }
        public Map fertilizerToWaterMap { get; }
        public Map waterToLightMap { get; }
        public Map lightToTemperatureMap { get; }
        public Map temperatureToHumidityMap { get; }
        public Map humidityToLocationMap { get; }

        public long GetLocationFromSeed(long seed)
        {
            var soil = seedToSoilMap.GetDestination(seed);
            var fertilizer = soilToFertilizerMap.GetDestination(soil);
            var water = fertilizerToWaterMap.GetDestination(fertilizer);
            var light = waterToLightMap.GetDestination(water);
            var temperature = lightToTemperatureMap.GetDestination(light);
            var humidity = temperatureToHumidityMap.GetDestination(temperature);
            var location = humidityToLocationMap.GetDestination(humidity);

            return location;
        }
    }
}
