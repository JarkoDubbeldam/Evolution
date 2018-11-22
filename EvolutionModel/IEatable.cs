namespace Evolution.Model {
  public interface IEatable {
    bool CanBeEatenBy(Species eater);
    int Eat(Species eater);
    bool TryEat(Species eater, out int amountEaten);
  }
}
