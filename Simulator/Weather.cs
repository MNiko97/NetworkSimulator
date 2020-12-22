namespace Network{
    class Weather{
        public int windIntensity;
        public int solarIntensity;
        public Weather(int windIntensityPercentage, int solarIntensityPercentage){
            windIntensity = (windIntensityPercentage <100)?windIntensityPercentage:100;
            solarIntensity = solarIntensityPercentage<100?solarIntensityPercentage:100;
        }
        public int getWindIntensity(){
            return windIntensity;
        }
        public int getSolarIntensity(){
            return solarIntensity;
        }
        public void setWindIntensity(int intensity){
            windIntensity = intensity;
        }
        public void setSolarIntensity(int intensity){
            solarIntensity = intensity;
        }
    }
}
