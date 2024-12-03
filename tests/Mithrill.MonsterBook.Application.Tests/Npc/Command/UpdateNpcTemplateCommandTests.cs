using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Validation;
using Moq;
using Xunit;

namespace Mithrill.MonsterBook.Application.Tests.Npc.Command;

public class UpdateNpcTemplateCommandTests
{
    private static readonly Regex Regex = new(@"((?<=\p{Ll})\p{Lu}|\p{Lu}(?=\p{Ll}))");
    private readonly IValidator<UpdateNpcTemplateCommand> _validator;
    private const string NonZeroableErrorMessage = "'{0}' must be between 1 and 100. You entered {1}.";
    private const string ZeroableErrorMessage = "'{0}' must be between 0 and 12. You entered {1}.";
    private const string SkillLevelErrorMessage = "'{0}' must be between 1 and 15. You entered {1}.";
    private const string GuaranteedSuccessErrorMessage = "'{0}' must be between 0 and 5. You entered {1}.";
    private const string MovementInhibitoryFactorErrorMessage = "'{0}' must be between -5 and 5. You entered {1}.";
    private const string AttackTypeDamageErrorMessage = "'{0}' must be between 1 and 8. You entered {1}.";
    private const string AttackTypeGuaranteedDamageErrorMessage = "'{0}' must be between 0 and 2. You entered {1}.";

    public UpdateNpcTemplateCommandTests()
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

        _validator = new UpdateNpcTemplateCommandValidator(templateValidatorServiceMock.Object);
    }


    #region Id Validation
        
    [Fact]
    public async Task GivenTemplate_When_InEditModeAndIdIsNotNullAndIdExist_Then_ReturnNoValidationError()
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeTrue();
        validationResult.Errors.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenTemplate_When_InEditModeAndIdIsNotNullAndIdDoesNotExist_Then_ReturnValidationError()
    {
        // Arrange
        var template = new NpcTemplate(
            4, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(4, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Id)}",
                ErrorCode: "IdValidator",
                ErrorMessage: $"Template with '{template.Id}' does not exist"
            )
        });
    }

    #endregion

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
        var template = new NpcTemplate(
            1, Name: name, "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Name)}",
                ErrorCode: "NotEmptyValidator",
                ErrorMessage: "'Name' must not be empty."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_NameIsTooLong_Then_ReturnValidationError()
    {
        // Arrange
        var template = new NpcTemplate(
            1, Name: "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Name)}",
                ErrorCode: "MaximumLengthValidator",
                ErrorMessage: $"The length of 'Name' must be 64 characters or fewer. You entered {template.Name.Length} characters."
            )
        });
    }

    #endregion

    #region Non-Zeroable Attribute Validation

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(101)]
    public async Task GivenTemplate_When_StrengthMaxAttributeIsZero_Then_ReturnValidationErrors(int strengthMax)
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "",
            StrengthMax: strengthMax,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.StrengthMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.StrengthMax), " $1").Trim(), template.StrengthMax)
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
        var template = new NpcTemplate(
            1, "Test", "", 1,
            StrengthMin: strengthMin,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.StrengthMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.StrengthMin), " $1").Trim(), template.StrengthMin)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1,
            VitalityMax: vitalityMax, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.VitalityMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.VitalityMax), " $1").Trim(), template.VitalityMax)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1,
            VitalityMin: vitalityMin, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.VitalityMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.VitalityMin), " $1").Trim(), template.VitalityMin)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1,
            BodyMax: bodyMax, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.BodyMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.BodyMax), " $1").Trim(), template.BodyMax)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1,
            BodyMin: bodyMin, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.BodyMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.BodyMin), " $1").Trim(), template.BodyMin)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1,
            AgilityMax: agilityMax, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.AgilityMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.AgilityMax), " $1").Trim(), template.AgilityMax)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1,
            AgilityMin: agilityMin, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.AgilityMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.AgilityMin), " $1").Trim(), template.AgilityMin)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1,
            DexterityMax: dexterityMax, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.DexterityMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.DexterityMax), " $1").Trim(), template.DexterityMax)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1,
            DexterityMin: dexterityMin, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.DexterityMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.DexterityMin), " $1").Trim(), template.DexterityMin)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            IntelligenceMax: intelligenceMax, 1, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.IntelligenceMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.IntelligenceMax), " $1").Trim(), template.IntelligenceMax)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            IntelligenceMin: intelligenceMin, 1, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.IntelligenceMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.IntelligenceMin), " $1").Trim(), template.IntelligenceMin)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            WillpowerMax: willpowerMax, 1, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.WillpowerMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.WillpowerMax), " $1").Trim(), template.WillpowerMax)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            WillpowerMin: willpowerMin, 1, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.WillpowerMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.WillpowerMin), " $1").Trim(), template.WillpowerMin)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            EmotionMax: emotionMax, 1, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.EmotionMax)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.EmotionMax), " $1").Trim(), template.EmotionMax)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            EmotionMin: emotionMin, 0, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.EmotionMin)}",
                ErrorCode: "NonZeroableAttributeValidator",
                ErrorMessage: string.Format(NonZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.EmotionMin), " $1").Trim(), template.EmotionMin)
            )
        });
    }

    #endregion

    #region Zeroable Attribute validation

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(-1)]
    [InlineData(13)]
    public async Task GivenTemplate_When_DamageReductionMaxAttributeIsZero_Then_ReturnValidationErrors(int damageReductionMax)
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            DamageReductionMax: damageReductionMax, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.DamageReductionMax)}",
                ErrorCode: "ZeroableAttributeValidator",
                ErrorMessage: string.Format(ZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.DamageReductionMax), " $1").Trim(), template.DamageReductionMax)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(-1)]
    [InlineData(13)]
    public async Task GivenTemplate_When_DamageReductionMinAttributeIsZero_Then_ReturnValidationErrors(int damageReductionMin)
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            DamageReductionMin: damageReductionMin, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.DamageReductionMin)}",
                ErrorCode: "ZeroableAttributeValidator",
                ErrorMessage: string.Format(ZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.DamageReductionMin), " $1").Trim(), template.DamageReductionMin)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(-1)]
    [InlineData(13)]
    public async Task GivenTemplate_When_KarmaMaxAttributeIsZero_Then_ReturnValidationErrors(int karmaMax)
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
            KarmaMax: karmaMax, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.KarmaMax)}",
                ErrorCode: "ZeroableAttributeValidator",
                ErrorMessage: string.Format(ZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.KarmaMax), " $1").Trim(), template.KarmaMax)
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(-1)]
    [InlineData(13)]
    public async Task GivenTemplate_When_KarmaMinAttributeIsZero_Then_ReturnValidationErrors(int karmaMin)
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, KarmaMin: karmaMin,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.KarmaMin)}",
                ErrorCode: "ZeroableAttributeValidator",
                ErrorMessage: string.Format(ZeroableErrorMessage, Regex.Replace(nameof(NpcTemplate.KarmaMin), " $1").Trim(), template.KarmaMin)
            )
        });
    }

    #endregion

    #region SkillCategory Validation

    [Fact]
    public async Task GivenTemplate_When_SkillCategoryIsNotNullButAllValuesAreTheSame_Then_ReturnValidationError()
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, false, Race.CivilizedHuman, Difficulty.Newbie,
            new SkillCategories(SkillCategory.Combat, SkillCategory.Combat, SkillCategory.Combat, SkillCategory.Combat),
            null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.SkillCategories)}",
                ErrorCode: "SkillCategoryValidator",
                ErrorMessage: "All skill category ranks must be unique or 'SkillCategories' must be null."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_SkillCategoryIsNotNullButThreeValuesAreTheSame_Then_ReturnValidationError()
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, false, Race.CivilizedHuman, Difficulty.Newbie,
            new SkillCategories(SkillCategory.Combat, SkillCategory.Combat, SkillCategory.Combat, SkillCategory.Secular),
            null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.SkillCategories)}",
                ErrorCode: "SkillCategoryValidator",
                ErrorMessage: "All skill category ranks must be unique or 'SkillCategories' must be null."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_SkillCategoryIsNotNullButTwoValuesAreTheSame_Then_ReturnValidationError()
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, false, Race.CivilizedHuman, Difficulty.Newbie,
            new SkillCategories(SkillCategory.Combat, SkillCategory.Combat, SkillCategory.Scholar, SkillCategory.Secular),
            null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.SkillCategories)}",
                ErrorCode: "SkillCategoryValidator",
                ErrorMessage: "All skill category ranks must be unique or 'SkillCategories' must be null."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_SkillCategoryIsNotNullAllValuesAreDifferent_Then_ReturnNoValidationError()
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, false, Race.CivilizedHuman, Difficulty.Newbie,
            new SkillCategories(SkillCategory.Underworld, SkillCategory.Combat, SkillCategory.Scholar, SkillCategory.Secular),
            null, [], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null,
            Merits:
            [
                new Merit(1, true),
                new Merit(2, true),
                new Merit(4, true)
            ], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Merits)}[2]",
                ErrorCode: "MeritValidator",
                ErrorMessage: $"Merit with id '{template.Merits.Last().Id}' doesn't exist."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_MeritsAreAddedAndAllAreValid_Then_ReturnValidationError()
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null,
            Merits:
            [
                new Merit(1, true),
                new Merit(2, true),
                new Merit(3, true)
            ], [], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [],
            Flaws:
            [
                new Flaw(1, true),
                new Flaw(2, true),
                new Flaw(4, true)
            ], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Flaws)}[2]",
                ErrorCode: "FlawValidator",
                ErrorMessage: $"Flaw with id '{template.Flaws.Last().Id}' doesn't exist."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_FlawsAreAddedAndAllAreValid_Then_ReturnValidationError()
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [],
            Flaws:
            [
                new Flaw(1, true),
                new Flaw(2, true),
                new Flaw(3, true)
            ], [], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [],
            Skills:
            [
                new Skill(1, 1, 1, 0, true),
                new Skill(2, 1, 1, 0, true),
                new Skill(4, 1, 1, 0, true)
            ], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Skills)}[2].{nameof(Skill.Id)}",
                ErrorCode: "SkillIdValidator",
                ErrorMessage: $"Skill with id '{template.Skills.Last().Id}' doesn't exist."
            )
        });
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(16)]
    public async Task GivenTemplate_When_ASkillAddedAndMinLevelIsInvalid_Then_ReturnValidationError(int minLevel)
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [],
            Skills:
            [
                new Skill(1, MinLevel: minLevel, 1, 0, true)
            ], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        if (minLevel > 0)
        {
            validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
            {
                new(
                    PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Skills)}[0].{nameof(Skill.MinLevel)}",
                    ErrorCode: "SkillLevelValidator",
                    ErrorMessage: string.Format(SkillLevelErrorMessage, Regex.Replace(nameof(Skill.MinLevel), " $1").Trim(), minLevel)
                ),
                new(
                    PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Skills)}[0]",
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
                    PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Skills)}[0].{nameof(Skill.MinLevel)}",
                    ErrorCode: "SkillLevelValidator",
                    ErrorMessage: string.Format(SkillLevelErrorMessage, Regex.Replace(nameof(Skill.MinLevel), " $1").Trim(), minLevel)
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [],
            Skills:
            [
                new Skill(1, 1, MaxLevel: maxLevel, 0, true)
            ], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        if (maxLevel < 1)
        {
            validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
            {
                new(
                    PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Skills)}[0].{nameof(Skill.MaxLevel)}",
                    ErrorCode: "SkillLevelValidator",
                    ErrorMessage: string.Format(SkillLevelErrorMessage, Regex.Replace(nameof(Skill.MaxLevel), " $1").Trim(), maxLevel)
                ),
                new(
                    PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Skills)}[0]",
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
                    PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Skills)}[0].{nameof(Skill.MaxLevel)}",
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [],
            Skills:
            [
                new Skill(1, 1, 1, GuaranteedSuccesses: guaranteedSuccess, true)
            ], [], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Skills)}[0].{nameof(Skill.GuaranteedSuccesses)}",
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [],
            Armors:
            [
                new Armor(1, Material.Adamar, 0, 0, true),
                new Armor(2, Material.Adamar, 0, 0, true),
                new Armor(4, Material.Adamar, 0, 0, true)
            ], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Armors)}[2].{nameof(Armor.Id)}",
                ErrorCode: "ArmorValidator",
                ErrorMessage: $"Armor with id '{template.Armors.Last().Id}' doesn't exist."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_ArmorsAreAddedAndAllAreValid_Then_ReturnNoError()
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [],
            Armors:
            [
                new Armor(1, Material.Adamar, 0, 0, true),
                new Armor(2, Material.Adamar, 0, 0, true),
                new Armor(3, Material.Adamar, 0, 0, true)
            ], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [],
            Armors:
            [
                new Armor(1, Material.Adamar, AdditionalArmorClass: additionalArmorClass, 0, true)
            ], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Armors)}[0].{nameof(Armor.AdditionalArmorClass)}",
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [],
            Armors:
            [
                new Armor(1, Material.Adamar, 0, AdditionalMovementInhibitoryFactor: additionalMovementInhibitoryFactor, true)
            ], []);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Armors)}[0].{nameof(Armor.AdditionalMovementInhibitoryFactor)}",
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, 0, 0, true, []),
                new Weapon(2, Material.Adamar, 0, 0, 0, true, []),
                new Weapon(4, Material.Adamar, 0, 0, 0, true, [])
            ]);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Weapons)}[2].{nameof(Weapon.Id)}",
                ErrorCode: "WeaponValidator",
                ErrorMessage: $"Weapon with id '{template.Weapons.Last().Id}' doesn't exist."
            )
        });
    }

    [Fact]
    public async Task GivenTemplate_When_WeaponsAreAddedAndAllAreValid_Then_ReturnNoError()
    {
        // Arrange
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, 0, 0, true, []),
                new Weapon(2, Material.Adamar, 0, 0, 0, true, []),
                new Weapon(3, Material.Adamar, 0, 0, 0, true, [])
            ]);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, AdditionalAttackModifier: additionalAttack, 0, 0, true, []),
            ]);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Weapons)}[0].{nameof(Weapon.AdditionalAttackModifier)}",
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, AdditionalDefenseModifier: additionalDefense, 0, true, []),
            ]);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Weapons)}[0].{nameof(Weapon.AdditionalDefenseModifier)}",
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, 0, AdditionalInitiativeModifier: additionalInitiative, true, [])
            ]);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Weapons)}[0].{nameof(Weapon.AdditionalInitiativeModifier)}",
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, 0, 0, true, [
                    new AttackType(DamageType.Acid, 1, 0),
                    new AttackType(DamageType.Fire, 2, 0),
                    new AttackType(DamageType.Ice, numberOfDices, 0),
                ])
            ]);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Weapons)}[0].{nameof(Weapon.AdditionalAttackTypes)}[2].{nameof(AttackType.NumberOfDices)}",
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, 0, 0, true, [
                    new AttackType(DamageType.Acid, 1, 0),
                    new AttackType(DamageType.Fire, 2, 0),
                    new AttackType(DamageType.Ice, 3, guaranteedDamage),
                ])
            ]);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Weapons)}[0].{nameof(Weapon.AdditionalAttackTypes)}[2].{nameof(AttackType.GuaranteedDamage)}",
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
        var template = new NpcTemplate(
            1, "Test", "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            false, Race.CivilizedHuman, Difficulty.Newbie, null, null, [], [], [], [],
            Weapons:
            [
                new Weapon(1, Material.Adamar, 0, 0, 0, true, [
                    new AttackType(DamageType.Bludgeoning, 3, guaranteedDamage),
                ])
            ]);
        var query = new UpdateNpcTemplateCommand(1, template);

        // Act
        var validationResult = await _validator.ValidateAsync(
            query,
            CancellationToken.None);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(new List<ValidationFailure>
        {
            new(
                PropertyName: $"{nameof(NpcTemplate)}.{nameof(NpcTemplate.Weapons)}[0].{nameof(Weapon.AdditionalAttackTypes)}[0].{nameof(AttackType.GuaranteedDamage)}",
                ErrorCode: "AttackTypeGuaranteedDamageValidator",
                ErrorMessage: string.Format(
                    AttackTypeGuaranteedDamageErrorMessage,
                    Regex.Replace(nameof(AttackType.GuaranteedDamage), " $1").Trim(),
                    guaranteedDamage)
            )
        });
    }

    #endregion
}