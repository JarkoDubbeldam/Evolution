namespace Evolution.Model {
  public interface IEatable {
    bool CanBeEatenBy(Species eater);
    int GetsEaten(Species eater);
    bool TryToEat(Species eater, out int amountEaten);
  }
}
