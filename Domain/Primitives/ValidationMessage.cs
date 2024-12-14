namespace Domain.Primitives;

/// <summary>
/// Сообщения при валидации
/// </summary>
public static class ValidationMessage
{
    /// <summary>
    /// Сообщение для системной валидации
    /// </summary>
    public const string NullOrWhiteSpaceMustNotBe = "Это поле обязательно и не может быть пустым";
    public const string NegativeOrZero = "Введенное значение должно быть положительным";
    /// <summary>
    /// Сообщения для Drug
    /// </summary>
    public const string LengthMessage = "Поле {PropertyName} должно содержать от {MinLength} до {MaxLength} символов";
    public const string SpecialCharactersNotAllowed = "Поле {PropertyName} не должно содержать специальных символов.";
    public const string InvalidCharactersInManufacturer = "Поле {PropertyName} может содержать только буквы, пробелы и дефисы.";
    public const string InvalidCountryCodeFormat = "Поле {PropertyName} должно состоять ровно из двух заглавных латинских букв.";
    public const string CountryCodeNotFound = "Поле {PropertyName} должно соответствовать существующему коду страны.";
    
    /// <summary>
    /// Сообщения для Country
    /// </summary>
    public const string InvalidCharactersInCountry = "Поле {PropertyName} может содержать только буквы, пробелы.";
    public const string InvalidCountryCode = "Поле {PropertyName} должно состоять только из заглавный латинских букв.";
    
    /// <summary>
    /// Сообщения для DrugItem
    /// </summary>
    public const string CostMustBePositive = "Поле {PropertyName} должно быть положительным числом.";
    public const string CostMaxPrecision = "Поле {PropertyName} не может содержать больше двух знаков после запятой.";
    public const string MustInt = "Поле {PropertyName} должно быть целым числом";
    public const string CountMaxValue = "Поле {PropertyName} не может быть больше 10 000.";

    // Сообщения для DrugItem
    public const string AllMustBeBig = "Поле {PropertyName} должно состоять из заглавных букв.";
    public const string BeAValidISPCode = "Поле {PropertyName} должно состоять из действующих ISO-кодов стран.";
    
    
    /// <summary>
    /// Валидационные сообщения Ярослава
    /// </summary>
    public const string RequiredField = "Поле {PropertyName} является обязательным.";
    public const string LengthField = "Поле {PropertyName} должно содержать от {MinLength} до {MaxLength} символов.";
    public const string ExactLengthField = "Поле {PropertyName} должно содержать ровно {ExactLength} символов.";
    public const string OnlyLettersAndSpaces = "Поле {PropertyName} должно содержать только буквы и пробелы.";
    public const string OnlyUppercaseLetters = "Поле {PropertyName} должно содержать только заглавные латинские буквы.";
    public const string PositiveNumber = "Поле {PropertyName} должно быть положительным числом.";
    public const string OnlyLettersDigitsAndSpaces = "Поле {PropertyName} должно содержать только буквы, цифры и пробелы.";
    public const string OnlyLettersSpacesAndDashes = "Поле {PropertyName} должно содержать только буквы, пробелы и дефисы.";
    public const string OnlyLettersDigitsAndDashes = "Поле {PropertyName} должно содержать только буквы, цифры и дефисы.";
    public const string OnlyLettersDigitsSpacesAndDashes = "Поле {PropertyName} должно содержать только буквы, цифры, пробелы и дефисы.";
    public const string ValidCountryCode = "Поле {PropertyName} должно соответствовать существующему ISO-коду страны.";
}