class Weather{
    public int windIntensity;
    public int solarIntensity;
    public Weather(int windIntensity, int solarIntensity){
        this.windIntensity = windIntensity;
        this.solarIntensity = solarIntensity;
    }
    public int getWindIntensity(){
        return windIntensity;
    }
    public int getSolarIntensity(){
        return solarIntensity;
    }
    public void setWindIntensity(int intensity){
        windIntensity = intensity
    }
    public void setSolarIntensity(int intensity){
        solarIntensity = intensity;
    }
}