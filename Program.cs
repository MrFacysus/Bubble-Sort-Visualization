int width = Console.WindowWidth;
int height = Console.WindowHeight;
int[] randomArray = new int[width];
int[] sortedArrayForVisual = new int[width];
Random random = new Random();

for (int i = 0; i < width; i++)
{
	randomArray[i] = random.Next(0, height);
}

sortedArrayForVisual = randomArray.OrderBy(x => x).ToArray();

void drawArray()
{
	for (int i = 0; i < width; i++)
	{
		for (int j = 0; j < height; j++)
		{
			if (j < randomArray[i])
			{
				Console.SetCursorPosition(i, height - j);
				if (isCorrectInOrder(i))
				{
					Console.ForegroundColor = ConsoleColor.Green;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
				}
				Console.Write("|");
			}
			else
			{
				Console.SetCursorPosition(i, height - j);
				Console.Write(" ");
			}
		}
	}
}

bool isCorrectInOrder(int index)
{
	if (sortedArrayForVisual[index] == randomArray[index])
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool bubbleSort()
{
	bool allCorrect = true;

	for (int i = 0; i < width - 1; i++)
	{
		if (randomArray[i] > randomArray[i + 1])
		{
			int temp = randomArray[i];
			randomArray[i] = randomArray[i + 1];
			randomArray[i + 1] = temp;
			allCorrect = false;
		}
	}

	return allCorrect;
}

Thread sortingThread = new Thread(() =>
{
	while (true)
	{
		if (bubbleSort())
			break;
		drawArray();
	}
});

sortingThread.IsBackground = true;
sortingThread.Start();

Console.ReadKey();