namespace Network{
    class Weather{
        public static int windIntensity;
        public static int solarIntensity;
        public Weather(int windIntensityPercentage, int solarIntensityPercentage){
            windIntensity = windIntensityPercentage;
            solarIntensity = solarIntensityPercentage;
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
