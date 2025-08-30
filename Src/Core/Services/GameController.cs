using SOLIDPractice.Src.Core.Enums;
using SOLIDPractice.Src.Core.Interfaces;

public class GameController
{
    private readonly INumberGenerator _numberGenerator;
    private readonly IGameSettings _gameSettings;
    private int _targetNumber { get;  set; }
    private int _attempts { get;  set; }
    private int _remainingAttempts => _gameSettings.Tries - _attempts;
    private bool _isGameOver => _attempts >= _gameSettings.Tries;

    public GameController(INumberGenerator numberGenerator, IGameSettings gameSettings)
    {
        _numberGenerator = numberGenerator;
        _gameSettings = gameSettings;
        _targetNumber = _numberGenerator.Generate(_gameSettings.MinRange, _gameSettings.MaxRange);
    }

    public void Run()
    {
        Console.WriteLine(@"Угадайте число в диапазоне от {0} до {1}. Количество попыток {2}:", _gameSettings.MinRange, _gameSettings.MaxRange, _gameSettings.Tries);

        while (!_isGameOver)
        {
            try
            {
                int userSuggestion = int.Parse(Console.ReadLine());
                var result = CheckGuess(userSuggestion);

                if (result == GameResult.Win)
                {
                    Console.WriteLine("Вы выиграли!");

                    return;
                }

                string message = result == GameResult.TooHigh
                ? "Ваше предположение больше, чем загаданное число."
                : "Ваше предположение меньше, чем загаданное число.";

                Console.WriteLine($"{message} Осталось попыток: {_remainingAttempts}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите целое число!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("Попытки закончились! Вы проиграли :(");
    }

    private GameResult CheckGuess(int guess)
    {
        _attempts++;

        if (guess == _targetNumber)
        {
            return GameResult.Win;
        }

        return guess > _targetNumber ? GameResult.TooHigh : GameResult.TooLow;
    }
}