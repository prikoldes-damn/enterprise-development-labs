using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using SchoolDiary.Domain.Model;
using SchoolDiary.Domain.Services;
using SchoolDiary.Domain.Data;

namespace SchoolDiary.Domain.Tests;

/// <summary>
/// Класс с юнит-тестами для электронного дневника.
/// </summary>
public class SchoolDiaryTests
{
    private readonly StudentInMemoryRepository _repository;

    public SchoolDiaryTests()
    {
        _repository = new StudentInMemoryRepository();
    }

    [Fact]
    public void GetAllStudentsInClass_ReturnsCorrectStudents()
    {
        var result = _repository.GetAllStudentsInClass(1);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal("Иванов Иван Иванович", result.First().FullName);
    }

    [Fact]
    public void GetStudentsWithGradesOnDate_ReturnsCorrectStudents()
    {
        var result = _repository.GetStudentsWithGradesOnDate(new DateTime(2023, 10, 15));

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal("Иванов Иван Иванович", result.First().FullName);
    }

    [Fact]
    public void GetTopFiveStudents_ReturnsCorrectStudents()
    {
        var result = _repository.GetTopFiveStudents();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public void GetStudentsWithMaxAverageGrade_ReturnsCorrectStudents()
    {
        var result = _repository.GetStudentsWithMaxAverageGrade(new DateTime(2023, 10, 1), new DateTime(2023, 10, 31));

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public void GetSubjectStatistics_ReturnsCorrectStatistics()
    {
        var result = _repository.GetSubjectStatistics();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}