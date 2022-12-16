namespace ega_lab8;

public readonly struct Item
{
	public int Value { get; }
	public int Weight { get; }

	public Item(int value, int weight)
	{
		Value = value;
		Weight = weight;
	}

	public double SpecificValue => Value / (double)Weight;

	public override string ToString() => $"(Value: {Value}, Weight: {Weight}, Specific Value: {SpecificValue})";
}
