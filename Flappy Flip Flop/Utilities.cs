using System;

public class Utilities
{
	public Utilities()
	{

	}

    public int GetRandomGapHeight(int min, int max)
    {
        Random random = new Random();

        int randomNumber = random.Next(min, max);

        return randomNumber;
    }
}
