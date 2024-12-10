using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Moq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Validation;
using Mithrill.MonsterBook.Application.Npc.Command.CreateNpcTemplate;
using Xunit;

namespace Mithrill.MonsterBook.Application.Tests.Npc.Command;

public class CreateNpcTemplateCommandTests
{
    private static readonly Regex Regex = new(@"((?<=\p{Ll})\p{Lu}|\p{Lu}(?=\p{Ll}))");
    private readonly IValidator<CreateNpcTemplateCommand> _validator;
    private const string NonZeroableAttributeErrorMessage = "'{0}' must be between 1 and 100. You entered {1}.";
    private const string ZeroableAttributeErrorMessage = "'{0}' must be between 0 and 100. You entered {1}.";
    private const string KarmaErrorMessage = "'{0}' must be between -12 and 12. You entered {1}.";
    private const string SkillLevelErrorMessage = "'{0}' must be between 1 and 15. You entered {1}.";
    private const string SummonSkillLevelErrorMessage = "'{0}' must be between -2 and 15. You entered {1}.";
    private const string GuaranteedSuccessErrorMessage = "'{0}' must be between 0 and 5. You entered {1}.";
    private const string MovementInhibitoryFactorErrorMessage = "'{0}' must be between -5 and 5. You entered {1}.";
    private const string AttackTypeDamageErrorMessage = "'{0}' must be between 1 and 8. You entered {1}.";
    private const string AttackTypeGuaranteedDamageErrorMessage = "'{0}' must be between 0 and 2. You entered {1}.";

    public CreateNpcTemplateCommandTests()
    {
        var templateValidatorServiceMock = new Mock<ITemplateValidatorService>();
        templateValidatorServiceMock.Setup(templateService => templateService.IsValidTemplateId(
                It.IsInRange(1, 3, Range.Inclusive),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        templateValidatorServiceMock.Setup(templateService => templateService.IsValidMeritId(
                It.IsInRange(1, 3, Range.Inclusive),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        templateValidatorServiceMock.Setup(templateService => templateService.IsValidFlawId(
                It.IsInRange(1, 3, Range.Inclusive),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        templateValidatorServiceMock.Setup(templateService => templateService.IsValidSkillId(
                It.IsInRange(1, 3, Range.Inclusive),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        templateValidatorServiceMock.Setup(templateService => templateService.IsValidWeaponId(
                It.IsInRange(1, 3, Range.Inclusive),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        templateValidatorServiceMock.Setup(templateService => templateService.IsValidArmorId(
                It.IsInRange(1, 3, Range.Inclusive),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        _validator = new CreateNpcTemplateCommandValidator(templateValidatorServiceMock.Object);
    }
        
    #region Name Validation

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    [InlineData("\r\n")]
    public async Task GivenTemplate_When_NameIsEmpty_Then_ReturnValidationError(string name)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            Name: name, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Name)}",
                ErrorCode: "NotEmptyValidator",
                ErrorMessage: "'Name' must not be empty."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_NameIsTooLong_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            Name: "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Name)}",
                ErrorCode: "MaximumLengthValidator",
                ErrorMessage: $"The length of 'Name' must be 64 characters or fewer. You entered {command.Name.Length} characters."
            )
        });
    }

    #endregion

    #region Attribute Validation

    [Theory]
    [InlineData(true, false, null)]
    [InlineData(false, true, SummonType.Thunder)]
    public async Task GivenSummonOrUndeadTemplate_When_StrengthMinIsZero_Then_ReturnNoValidationErros(bool isUndead, bool isSummon, SummonType? summonType)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test",
            1, StrengthMin: 0,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            isUndead, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], [], isSummon, summonType);

        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(int.MinValue, true, false, null)]
    [InlineData(int.MaxValue, true, false, null)]
    [InlineData(-1, true, false, null)]
    [InlineData(101, true, false, null)]
    [InlineData(int.MinValue, false, true, SummonType.Thunder)]
    [InlineData(int.MaxValue, false, true, SummonType.Thunder)]
    [InlineData(-1, false, true, SummonType.Thunder)]
    [InlineData(101, false, true, SummonType.Thunder)]
    public async Task GivenTemplate_When_StrengthMinAttributeIsZeroable_Then_ReturnNoValidationErros(int strengthMin, bool isUndead, bool isSummon, SummonType? summonType)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test",
            1, StrengthMin: strengthMin,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            isUndead, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], [], isSummon, summonType);

        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.StrengthMin)}",
                ErrorCode: "ZeroableAttributeValidator",
                ErrorMessage: string.Format(ZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.StrengthMin), " $1").Trim(), command.StrengthMin)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_StrengthMaxAttributeIsZero_Then_ReturnValidationErrors(int strengthMax)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test",
            StrengthMax: strengthMax,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.StrengthMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.StrengthMax), " $1").Trim(), command.StrengthMax)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_StrengthMinAttributeIsZero_Then_ReturnValidationErrors(int strengthMin)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1,
            StrengthMin: strengthMin,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.StrengthMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.StrengthMin), " $1").Trim(), command.StrengthMin)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_VitalityMaxAttributeIsZero_Then_ReturnValidationErrors(int vitalityMax)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1,
            VitalityMax: vitalityMax, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.VitalityMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.VitalityMax), " $1").Trim(), command.VitalityMax)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_VitalityMinAttributeIsZero_Then_ReturnValidationErrors(int vitalityMin)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1,
            VitalityMin: vitalityMin, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.VitalityMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.VitalityMin), " $1").Trim(), command.VitalityMin)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_BodyMaxAttributeIsZero_Then_ReturnValidationErrors(int bodyMax)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1,
            BodyMax: bodyMax, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.BodyMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.BodyMax), " $1").Trim(), command.BodyMax)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_BodyMinAttributeIsZero_Then_ReturnValidationErrors(int bodyMin)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1,
            BodyMin: bodyMin, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.BodyMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.BodyMin), " $1").Trim(), command.BodyMin)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_AgilityMaxAttributeIsZero_Then_ReturnValidationErrors(int agilityMax)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1,
            AgilityMax: agilityMax, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.AgilityMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.AgilityMax), " $1").Trim(), command.AgilityMax)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_AgilityMinAttributeIsZero_Then_ReturnValidationErrors(int agilityMin)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1,
            AgilityMin: agilityMin, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.AgilityMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.AgilityMin), " $1").Trim(), command.AgilityMin)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_DexterityMaxAttributeIsZero_Then_ReturnValidationErrors(int dexterityMax)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1,
            DexterityMax: dexterityMax, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.DexterityMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.DexterityMax), " $1").Trim(), command.DexterityMax)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_DexterityMinAttributeIsZero_Then_ReturnValidationErrors(int dexterityMin)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1,
            DexterityMin: dexterityMin, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.DexterityMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.DexterityMin), " $1").Trim(), command.DexterityMin)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_IntelligenceMaxAttributeIsZero_Then_ReturnValidationErrors(int intelligenceMax)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            IntelligenceMax: intelligenceMax, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.IntelligenceMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.IntelligenceMax), " $1").Trim(), command.IntelligenceMax)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_IntelligenceMinAttributeIsZero_Then_ReturnValidationErrors(int intelligenceMin)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            IntelligenceMin: intelligenceMin, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.IntelligenceMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.IntelligenceMin), " $1").Trim(), command.IntelligenceMin)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_WillpowerMaxAttributeIsZero_Then_ReturnValidationErrors(int willpowerMax)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            WillpowerMax: willpowerMax, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.WillpowerMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.WillpowerMax), " $1").Trim(), command.WillpowerMax)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_WillpowerMinAttributeIsZero_Then_ReturnValidationErrors(int willpowerMin)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            WillpowerMin: willpowerMin, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.WillpowerMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.WillpowerMin), " $1").Trim(), command.WillpowerMin)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_EmotionMaxAttributeIsZero_Then_ReturnValidationErrors(int emotionMax)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            EmotionMax: emotionMax, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.EmotionMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.EmotionMax), " $1").Trim(), command.EmotionMax)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_EmotionMinAttributeIsZero_Then_ReturnValidationErrors(int emotionMin)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            EmotionMin: emotionMin, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.EmotionMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableAttributeErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.EmotionMin), " $1").Trim(), command.EmotionMin)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(-13)]
    [InlineData(13)]
    public async Task GivenTemplate_When_DamageReductionMaxAttributeIsZero_Then_ReturnValidationErrors(int damageReductionMax)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            DamageReductionMax: damageReductionMax, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.DamageReductionMax)}",
                ErrorCode: "KarmaValidator",
                ErrorMessage: string.Format(KarmaErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.DamageReductionMax), " $1").Trim(), command.DamageReductionMax)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(-13)]
    [InlineData(13)]
    public async Task GivenTemplate_When_DamageReductionMinAttributeIsZero_Then_ReturnValidationErrors(int damageReductionMin)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            DamageReductionMin: damageReductionMin, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.DamageReductionMin)}",
                ErrorCode: "KarmaValidator",
                ErrorMessage: string.Format(KarmaErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.DamageReductionMin), " $1").Trim(), command.DamageReductionMin)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(-13)]
    [InlineData(13)]
    public async Task GivenTemplate_When_KarmaMaxAttributeIsZero_Then_ReturnValidationErrors(int karmaMax)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
            KarmaMax: karmaMax, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.KarmaMax)}",
                ErrorCode: "KarmaValidator",
                ErrorMessage: string.Format(KarmaErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.KarmaMax), " $1").Trim(), command.KarmaMax)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(-13)]
    [InlineData(13)]
    public async Task GivenTemplate_When_KarmaMinAttributeIsZero_Then_ReturnValidationErrors(int karmaMin)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, KarmaMin: karmaMin,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.KarmaMin)}",
                ErrorCode: "KarmaValidator",
                ErrorMessage: string.Format(KarmaErrorMessage, Regex.Replace(nameof(CreateNpcTemplateCommand.KarmaMin), " $1").Trim(), command.KarmaMin)
            )
        });
    }

    #endregion

    #region SkillCategory Validation

    [Fact]
    public async Task GivenTemplate_When_SkillCategoryIsNotNullButAllValuesAreTheSame_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, false, Race.CivilizedHuman, Difficulty.Newbie,
            new SkillCategories(SkillCategory.Combat, SkillCategory.Combat, SkillCategory.Combat, SkillCategory.Combat),
            null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.SkillCategories)}",
                ErrorCode: "SkillCategoryValidator",
                ErrorMessage: "All skill category ranks must be unique or 'SkillCategories' must be null."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_SkillCategoryIsNotNullButThreeValuesAreTheSame_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, false, Race.CivilizedHuman, Difficulty.Newbie,
            new SkillCategories(SkillCategory.Combat, SkillCategory.Combat, SkillCategory.Combat, SkillCategory.Secular),
            null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.SkillCategories)}",
                ErrorCode: "SkillCategoryValidator",
                ErrorMessage: "All skill category ranks must be unique or 'SkillCategories' must be null."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_SkillCategoryIsNotNullButTwoValuesAreTheSame_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, false, Race.CivilizedHuman, Difficulty.Newbie,
            new SkillCategories(SkillCategory.Combat, SkillCategory.Combat, SkillCategory.Scholar, SkillCategory.Secular),
            null, [], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.SkillCategories)}",
                ErrorCode: "SkillCategoryValidator",
                ErrorMessage: "All skill category ranks must be unique or 'SkillCategories' must be null."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_SkillCategoryIsNotNullAllValuesAreDifferent_Then_ReturnNoValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, false, Race.CivilizedHuman, Difficulty.Newbie,
            new SkillCategories(SkillCategory.Underworld, SkillCategory.Combat, SkillCategory.Scholar, SkillCategory.Secular),
            null, [], [], [], [], []);

        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeTrue();
        validationResult.Errors.Should().BeEmpty();
    }

    #endregion

    #region Merit Validation

    [Fact]
    public async Task GivenTemplate_When_MeritsAreAddedAndOneIsInvalid_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null,
            Merits:
            [
                new Merit(1, true),
                new Merit(2, true),
                new Merit(4, true)
            ], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Merits)}[2]",
                ErrorCode: "MeritValidator",
                ErrorMessage: $"Merit with id '{command.Merits.Last().Id}' doesn't exist."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_MeritsAreAddedAndAllAreValid_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null,
            Merits:
            [
                new Merit(1, true),
                new Merit(2, true),
                new Merit(3, true)
            ], [], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeTrue();
        validationResult.Errors.Should().BeEmpty();
    }

    #endregion

    #region Flaw Validation

    [Fact]
    public async Task GivenTemplate_When_FlawsAreAddedAndOneIsInvalid_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [],
            Flaws:
            [
                new Flaw(1, true),
                new Flaw(2, true),
                new Flaw(4, true)
            ], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Flaws)}[2]",
                ErrorCode: "FlawValidator",
                ErrorMessage: $"Flaw with id '{command.Flaws.Last().Id}' doesn't exist."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_FlawsAreAddedAndAllAreValid_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [],
            Flaws:
            [
                new Flaw(1, true),
                new Flaw(2, true),
                new Flaw(3, true)
            ], [], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeTrue();
        validationResult.Errors.Should().BeEmpty();
    }

    #endregion

    #region Skill Validation

    [Fact]
    public async Task GivenTemplate_When_SkillsAreAddAndTheLastOneDoesNotExist_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [],
            Skills:
            [
                new Skill(1, 1, 1, 0, true),
                new Skill(2, 1, 1, 0, true),
                new Skill(4, 1, 1, 0, true)
            ], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Skills)}[2].{nameof(Skill.Id)}",
                ErrorCode: "SkillIdValidator",
                ErrorMessage: $"Skill with id '{command.Skills.Last().Id}' doesn't exist."
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(16)]
    public async Task GivenTemplate_When_ASkillAddedForNonSummonTemplateAndMinLevelIsInvalid_Then_ReturnValidationError(int minLevel)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [],
            Skills:
            [
                new Skill(1, MinLevel: minLevel, 1, 0, true)
            ], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        if (minLevel > 0)
        {
            validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
            {
                new(
                    PropertyName: $"{nameof(CreateNpcTemplateCommand.Skills)}[0].{nameof(Skill.MinLevel)}",
                    ErrorCode: "SkillLevelValidator",
                    ErrorMessage: string.Format(SkillLevelErrorMessage, Regex.Replace(nameof(Skill.MinLevel), " $1").Trim(), minLevel)
                ),
                new(
                    PropertyName: $"{nameof(CreateNpcTemplateCommand.Skills)}[0]",
                    ErrorCode: "SkillLevelValidator",
                    ErrorMessage: "'Min Level' must be lower or equal to 'Max Level'"
                )
            });
        }
        else
        {
            validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
            {
                new(
                    PropertyName: $"{nameof(CreateNpcTemplateCommand.Skills)}[0].{nameof(Skill.MinLevel)}",
                    ErrorCode: "SkillLevelValidator",
                    ErrorMessage: string.Format(SkillLevelErrorMessage, Regex.Replace(nameof(Skill.MinLevel), " $1").Trim(), minLevel)
                )
            });
        }
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(-3)]
    [InlineData(16)]
    public async Task GivenTemplate_When_ASkillAddedForSummonTemplateAndMinLevelIsInvalid_Then_ReturnValidationError(int minLevel)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [],
            Skills:
            [
                new Skill(1, MinLevel: minLevel, 1, 0, true)
            ], [], [], true, SummonType.Fire);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        if (minLevel > 0)
        {
            validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
            {
                new(
                    PropertyName: $"{nameof(CreateNpcTemplateCommand.Skills)}[0].{nameof(Skill.MinLevel)}",
                    ErrorCode: "SkillLevelValidator",
                    ErrorMessage: string.Format(SummonSkillLevelErrorMessage, Regex.Replace(nameof(Skill.MinLevel), " $1").Trim(), minLevel)
                ),
                new(
                    PropertyName: $"{nameof(CreateNpcTemplateCommand.Skills)}[0]",
                    ErrorCode: "SkillLevelValidator",
                    ErrorMessage: "'Min Level' must be lower or equal to 'Max Level'"
                )
            });
        }
        else
        {
            validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
            {
                new(
                    PropertyName: $"{nameof(CreateNpcTemplateCommand.Skills)}[0].{nameof(Skill.MinLevel)}",
                    ErrorCode: "SkillLevelValidator",
                    ErrorMessage: string.Format(SummonSkillLevelErrorMessage, Regex.Replace(nameof(Skill.MinLevel), " $1").Trim(), minLevel)
                )
            });
        }
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(16)]
    public async Task GivenTemplate_When_ASkillAddedAndMaxLevelIsInvalid_Then_ReturnValidationError(int maxLevel)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [],
            Skills:
            [
                new Skill(1, 1, MaxLevel: maxLevel, 0, true)
            ], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        if (maxLevel < 1)
        {
            validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
            {
                new(
                    PropertyName: $"{nameof(CreateNpcTemplateCommand.Skills)}[0].{nameof(Skill.MaxLevel)}",
                    ErrorCode: "SkillLevelValidator",
                    ErrorMessage: string.Format(SkillLevelErrorMessage, Regex.Replace(nameof(Skill.MaxLevel), " $1").Trim(), maxLevel)
                ),
                new(
                    PropertyName: $"{nameof(CreateNpcTemplateCommand.Skills)}[0]",
                    ErrorCode: "SkillLevelValidator",
                    ErrorMessage: "'Min Level' must be lower or equal to 'Max Level'"
                )
            });
        }
        else
        {
            validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
            {
                new(
                    PropertyName: $"{nameof(CreateNpcTemplateCommand.Skills)}[0].{nameof(Skill.MaxLevel)}",
                    ErrorCode: "SkillLevelValidator",
                    ErrorMessage: string.Format(SkillLevelErrorMessage, Regex.Replace(nameof(Skill.MaxLevel), " $1").Trim(), maxLevel)
                )
            });
        }
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(-1)]
    [InlineData(6)]
    public async Task GivenTemplate_When_ASkillAddedAndGuaranteedSuccessIsInvalid_Then_ReturnValidationError(int guaranteedSuccess)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [],
            Skills:
            [
                new Skill(1, 1, 1, GuaranteedSuccesses: guaranteedSuccess, true)
            ], [], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Skills)}[0].{nameof(Skill.GuaranteedSuccesses)}",
                ErrorCode: "SkillSuccessValidator",
                ErrorMessage: string.Format(GuaranteedSuccessErrorMessage, Regex.Replace(nameof(Skill.GuaranteedSuccesses), " $1").Trim(), guaranteedSuccess)
            )
        });
    }
    #endregion

    #region Armor Validation

    [Fact]
    public async Task GivenTemplate_When_ArmorsAreAddedAndOneIsInvalid_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [],
            Armors:
            [
                new Armor(1, Material.Adamar, 0, 0, true),
                new Armor(2, Material.Adamar, 0, 0, true),
                new Armor(4, Material.Adamar, 0, 0, true)
            ], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Armors)}[2].{nameof(Armor.Id)}",
                ErrorCode: "ArmorValidator",
                ErrorMessage: $"Armor with id '{command.Armors.Last().Id}' doesn't exist."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_ArmorsAreAddedAndAllAreValid_Then_ReturnNoError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [],
            Armors:
            [
                new Armor(1, Material.Adamar, 0, 0, true),
                new Armor(2, Material.Adamar, 0, 0, true),
                new Armor(3, Material.Adamar, 0, 0, true)
            ], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeTrue();
        validationResult.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue)]
    [InlineData(-1)]
    [InlineData(6)]
    public async Task GivenTemplate_When_ArmorsAreAddedAndAdditionalArmorClassIsIncorrect_Then_ReturnValidationError(int additionalArmorClass)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [],
            Armors:
            [
                new Armor(1, Material.Adamar, AdditionalArmorClass: additionalArmorClass, 0, true)
            ], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Armors)}[0].{nameof(Armor.AdditionalArmorClass)}",
                ErrorCode: "ArmorClassValidator",
                ErrorMessage: string.Format(
                    GuaranteedSuccessErrorMessage,
                    Regex.Replace(nameof(Armor.AdditionalArmorClass), " $1").Trim(),
                    additionalArmorClass)
            )
        });
    }

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue)]
    [InlineData(-6)]
    [InlineData(6)]
    public async Task GivenTemplate_When_ArmorsAreAddedAndAdditionalMovementInhibitoryFactorValueIsIncorrect_Then_ReturnValidationError(int additionalMovementInhibitoryFactor)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [],
            Armors:
            [
                new Armor(1, Material.Adamar, 0, AdditionalMovementInhibitoryFactor: additionalMovementInhibitoryFactor, true)
            ], []);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Armors)}[0].{nameof(Armor.AdditionalMovementInhibitoryFactor)}",
                ErrorCode: "MovementInhibitoryFactorValidator",
                ErrorMessage: string.Format(
                    MovementInhibitoryFactorErrorMessage,
                    Regex.Replace(nameof(Armor.AdditionalMovementInhibitoryFactor), " $1").Trim(),
                    additionalMovementInhibitoryFactor)
            )
        });
    }

    #endregion

    #region Weapon Validation

    [Fact]
    public async Task GivenTemplate_When_WeaponsAreAddedAndOneIsInvalid_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, 0, 0, true, []),
                new Weapon(2, Material.Adamar, 0, 0, 0, true, []),
                new Weapon(4, Material.Adamar, 0, 0, 0, true, [])
            ]);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Weapons)}[2].{nameof(Weapon.Id)}",
                ErrorCode: "WeaponValidator",
                ErrorMessage: $"Weapon with id '{command.Weapons.Last().Id}' doesn't exist."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_WeaponsAreAddedAndAllAreValid_Then_ReturnNoError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, 0, 0, true, []),
                new Weapon(2, Material.Adamar, 0, 0, 0, true, []),
                new Weapon(3, Material.Adamar, 0, 0, 0, true, [])
            ]);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeTrue();
        validationResult.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue)]
    [InlineData(-1)]
    [InlineData(6)]
    public async Task GivenTemplate_When_WeaponsAreAddedAndAdditionalAttackIsIncorrect_Then_ReturnValidationError(int additionalAttack)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, AdditionalAttackModifier: additionalAttack, 0, 0, true, []),
            ]);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Weapons)}[0].{nameof(Weapon.AdditionalAttackModifier)}",
                ErrorCode: "WeaponModifierValidator",
                ErrorMessage: string.Format(
                    GuaranteedSuccessErrorMessage,
                    Regex.Replace(nameof(Weapon.AdditionalAttackModifier), " $1").Trim(),
                    additionalAttack)
            )
        });
    }

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue)]
    [InlineData(-1)]
    [InlineData(6)]
    public async Task GivenTemplate_When_WeaponsAreAddedAndAdditionalDefenseIsIncorrect_Then_ReturnValidationError(int additionalDefense)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, AdditionalDefenseModifier: additionalDefense, 0, true, []),
            ]);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Weapons)}[0].{nameof(Weapon.AdditionalDefenseModifier)}",
                ErrorCode: "WeaponModifierValidator",
                ErrorMessage: string.Format(
                    GuaranteedSuccessErrorMessage,
                    Regex.Replace(nameof(Weapon.AdditionalDefenseModifier), " $1").Trim(),
                    additionalDefense)
            )
        });
    }

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue)]
    [InlineData(-1)]
    [InlineData(6)]
    public async Task GivenTemplate_When_WeaponsAreAddedAndAdditionalInitiativeIsIncorrect_Then_ReturnValidationError(int additionalInitiative)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, 0, AdditionalInitiativeModifier: additionalInitiative, true, [])
            ]);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Weapons)}[0].{nameof(Weapon.AdditionalInitiativeModifier)}",
                ErrorCode: "WeaponModifierValidator",
                ErrorMessage: string.Format(
                    GuaranteedSuccessErrorMessage,
                    Regex.Replace(nameof(Weapon.AdditionalInitiativeModifier), " $1").Trim(),
                    additionalInitiative)
            )
        });
    }

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue)]
    [InlineData(0)]
    [InlineData(9)]
    public async Task GivenTemplate_When_WeaponsAreAddedAndOneAdditionalDamageDiceValueIsIncorrect_Then_ReturnValidationError(int numberOfDices)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, 0, 0, true, [
                    new AttackType(DamageType.Acid, 1, 0),
                    new AttackType(DamageType.Fire, 2, 0),
                    new AttackType(DamageType.Ice, numberOfDices, 0),
                ])
            ]);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Weapons)}[0].{nameof(Weapon.AdditionalAttackTypes)}[2].{nameof(AttackType.NumberOfDices)}",
                ErrorCode: "AttackTypeDamageValidator",
                ErrorMessage: string.Format(
                    AttackTypeDamageErrorMessage,
                    Regex.Replace(nameof(AttackType.NumberOfDices), " $1").Trim(),
                    numberOfDices)
            )
        });
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async Task GivenTemplate_When_WeaponsAreAddedAndElementalAdditionalGuaranteedDamageValueIsIncorrect_Then_ReturnValidationError(int guaranteedDamage)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, 0, 0, true, [
                    new AttackType(DamageType.Acid, 1, 0),
                    new AttackType(DamageType.Fire, 2, 0),
                    new AttackType(DamageType.Ice, 3, guaranteedDamage),
                ])
            ]);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Weapons)}[0].{nameof(Weapon.AdditionalAttackTypes)}[2].{nameof(AttackType.GuaranteedDamage)}",
                ErrorCode: "AttackTypeGuaranteedDamageValidator",
                ErrorMessage: "Guaranteed Damage must be 0 if Damage Type is elemental type."
            )
        });
    }



    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue)]
    [InlineData(-1)]
    [InlineData(3)]
    public async Task GivenTemplate_When_WeaponsAreAddedAndNoneElementalAdditionalGuaranteedDamageValueIsIncorrect_Then_ReturnValidationError(int guaranteedDamage)
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "Test", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, 0, 0, true, [
                    new AttackType(DamageType.Bludgeoning, 3, guaranteedDamage),
                ])
            ]);


        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.Weapons)}[0].{nameof(Weapon.AdditionalAttackTypes)}[0].{nameof(AttackType.GuaranteedDamage)}",
                ErrorCode: "AttackTypeGuaranteedDamageValidator",
                ErrorMessage: string.Format(
                    AttackTypeGuaranteedDamageErrorMessage,
                    Regex.Replace(nameof(AttackType.GuaranteedDamage), " $1").Trim(),
                    guaranteedDamage)
            )
        });
    }

    #endregion

    #region Summon and Undead Validation

    [Fact]
    public async Task GivenTemplate_When_IsSummonTrueAndNoSummonTypeSpecified_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "a", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], [],
            IsSummon: true);
        
        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.IsSummon)}",
                ErrorCode: "SummonValidator",
                ErrorMessage: "'Is summon' must be false if 'Summon Type' is empty."
            ),
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.SummonType)}",
                ErrorCode: "SummonValidator",
                ErrorMessage: "'Summon Type' must not be empty if 'Is summon' is true."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_IsSummonAndIsUndeadTrueAndNoSummonTypeSpecified_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "a", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            IsUndead: true, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], [],
            IsSummon: true);

        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.IsSummon)}",
                ErrorCode: "SummonValidator",
                ErrorMessage: "'Is summon' must be false if 'Summon Type' is empty."),
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.IsSummon)}",
                ErrorCode: "SummonValidator",
                ErrorMessage: "'Is summon' must be false if 'Is undead true'."),
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.SummonType)}",
                ErrorCode: "SummonValidator",
                ErrorMessage: "'Summon Type' must not be empty if 'Is summon' is true."),
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.IsUndead)}",
                ErrorCode: "UndeadValidator",
                ErrorMessage: "'Is undead' must be false if 'Is summon' is true.")
        });
    }

    [Fact]
    public async Task GivenTemplate_When_IsSummonFalseAndSummonTypeSpecified_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "a", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            IsUndead: false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], [],
            IsSummon: false, SummonType.Holy);

        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.IsSummon)}",
                ErrorCode: "SummonValidator",
                ErrorMessage: "'Is summon' must be true if 'Summon Type' has value."
            ),
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.SummonType)}",
                ErrorCode: "SummonValidator",
                ErrorMessage: "'Summon Type' must be empty if 'Is summon' is false."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_IsSummonFalseIsUndeadTrueAndSummonTypeSpecified_Then_ReturnValidationError()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "a", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            IsUndead: true, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], [],
            IsSummon: false, SummonType.Holy);

        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.IsSummon)}",
                ErrorCode: "SummonValidator",
                ErrorMessage: "'Is summon' must be true if 'Summon Type' has value."
            ),
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.SummonType)}",
                ErrorCode: "SummonValidator",
                ErrorMessage: "'Summon Type' must be empty if 'Is summon' is false."
            ),
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.SummonType)}",
                ErrorCode: "SummonValidator",
                ErrorMessage: "'Summon Type' must be empty if 'Is undead' is true."
            ),
            new(
                PropertyName: $"{nameof(CreateNpcTemplateCommand.IsUndead)}",
                ErrorCode: "UndeadValidator",
                ErrorMessage: "'Is undead' must be false if 'Summon Type' is not empty.")
        });
    }

    [Fact]
    public async Task GivenTemplate_When_IsSummonTrueAndSummonTypeSpecified_Then_NoValidationErrorReturned()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "a", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            IsUndead: false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], [],
            IsSummon: true, SummonType.Holy);

        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeTrue();
    }

    [Fact]
    public async Task GivenTemplate_When_IsUndeadTrueIsSummonFalseAndSummonTypeNotSpecified_Then_NoValidationErrorReturned()
    {
        // Arrange
        var command = new CreateNpcTemplateCommand(
            "a", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            IsUndead: true, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], [],
            IsSummon: false);

        // Act
        var validationResult = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeTrue();
    }

    #endregion
}