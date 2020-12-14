using System.Collections.Generic;
namespace Network{
    public interface IupdatableComponent{
        void update();
        List<string> getAlert();
    }
}
