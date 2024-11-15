namespace StudentManagementApp.Application.Validators;

public static class InputValidator
{
    public static bool ValidateStudentId(string input, out int id)
    {
        return int.TryParse(input, out id) && input.Length == 7;
    }

    public static bool ValidateAge(string input, out int age)
    {
        return int.TryParse(input, out age) && age > 0;
    }
}
