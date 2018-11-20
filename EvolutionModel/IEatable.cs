namespace Evolution.Model {
  public interface IEatable {
    bool CanBeEatenBy(Species eater);
    int GetsEaten(Species eater);
  }
}
